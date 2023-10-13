// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging;
using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Storage.Blobs;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace ImageResize;

public class ResizeImageEventGridTrigger
{
    private const string StorageConnection = "StorageConnection";
    private const string ThumbnailWidth = "ThumbnailWidth";

    private static readonly List<string> suportedExtensions = ["gif", "png", "jpg", "jpeg"];

    private readonly BlobContainerClient _client;
    private readonly ILogger<ResizeImageEventGridTrigger> _logger;

    public ResizeImageEventGridTrigger(BlobContainerClient client, ILogger<ResizeImageEventGridTrigger> logger)
    {
        this._client = client ?? throw new ArgumentNullException(nameof(client));
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [Function(nameof(ResizeImageEventGridTrigger))]
    public async Task Run(
        [EventGridTrigger] CloudEvent cloudEvent,
        [BlobInput("{data.url}", Connection = StorageConnection)] Stream image
    )
    {
        this._logger.LogInformation("Event type: {type}, Event subject: {subject}", cloudEvent.Type, cloudEvent.Subject);

        if (image == null)
        {
            this._logger.LogError("Image not found");

            return;
        }

        var data = cloudEvent.Data.ToObjectFromJson<StorageBlobCreatedEventData>();
        var encoder = this.GetEncoder(data.Url);
        if (encoder == null)
        {
            this._logger.LogError("Image format not supported");

            return;
        }

        var blobName = this.GetBlobName(data.Url);
        var resized = await this.ResizeImageAsync(image, encoder);
        await this.UploadThumbnailAsync(blobName, resized);
    }

    private IImageEncoder GetEncoder(string blobUrl)
    {
        var encoder = default(IImageEncoder);
        var extension = Path.GetExtension(blobUrl).Replace(".", "").ToLowerInvariant();

        var isSupported = suportedExtensions.Contains(extension);
        if (isSupported == false)
        {
            return encoder;
        }

        switch (extension)
        {
            case "png":
                encoder = new PngEncoder();
                break;
            case "jpg":
            case "jpeg":
                encoder = new JpegEncoder();
                break;
            case "gif":
                encoder = new GifEncoder();
                break;
            default:
                break;
        }

        return encoder;
    }

    private string GetBlobName(string blobUrl)
    {
        var blob = new BlobClient(new Uri(blobUrl));

        return blob.Name;
    }

    private async Task<byte[]> ResizeImageAsync(Stream input, IImageEncoder encoder)
    {
        using var output = new MemoryStream();
        using var image = await Image.LoadAsync(input).ConfigureAwait(false);

        var thumbnailWidth = Convert.ToInt32(Environment.GetEnvironmentVariable(ThumbnailWidth));
        var divisor = image.Width / thumbnailWidth;
        var thumbnailHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

        image.Mutate(x => x.Resize(thumbnailWidth, thumbnailHeight));
        await image.SaveAsync(output, encoder);

        output.Position = 0;

        return output.ToArray();
    }

    private async Task UploadThumbnailAsync(string blobName, byte[] image)
    {
        using var stream = new MemoryStream(image);
        await this._client.UploadBlobAsync(blobName, stream).ConfigureAwait(false);
    }
}
