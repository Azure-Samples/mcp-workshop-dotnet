using System.Text;

using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ImageAnalysis;

/// <summary>
/// This represents the Blob Trigger function entity to analyze the image content.
/// </summary>
public class AnalyzeImageBlobTrigger
{
    private const string TableName = "ImageText";
    private const string StorageConnection = "StorageConnection";
    private const string StorageAccountName = "StorageAccountName";
    private const string ContainerName = "images";

    private readonly IComputerVisionClient _client;
    private readonly ILogger<AnalyzeImageBlobTrigger> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnalyzeImageBlobTrigger"/> class.
    /// </summary>
    /// <param name="client"><see cref="IComputerVisionClient"/> instance.</param>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/> instance.</param>
    public AnalyzeImageBlobTrigger(IComputerVisionClient client, ILogger<AnalyzeImageBlobTrigger> logger)
    {
        this._client = client ?? throw new ArgumentNullException(nameof(client));
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Invokes the Blob Trigger function.
    /// </summary>
    /// <param name="stream"><see cref="Stream"/> instance of the image from Blob Storage.</param>
    /// <param name="name">Image name.</param>
    /// <returns>Returns <see cref="ImageContent"/> stored into Table Storage.</returns>
    /// <remarks>
    /// The <see cref="BlobTriggerAttribute"/> binding runs when an image is uploaded to the given Blob container.
    /// Then the <see cref="TableOutputAttribute"/> binding stores the analysis data to Table Storage.
    /// </remarks>
    [Function(nameof(AnalyzeImageBlobTrigger))]
    [TableOutput(TableName, Connection = StorageConnection)]
    public async Task<ImageContent> Run([BlobTrigger($"{ContainerName}/{{name}}", Connection = StorageConnection)] Stream stream, string name)
    {
        var imageUrl = $"https://{Environment.GetEnvironmentVariable(StorageAccountName)}.blob.core.windows.net/{ContainerName}/{name}";

        // Get the analyzed image contents
        var textContext = await this.AnalyzeImageContent(imageUrl);

        return new ImageContent { PartitionKey = "Images", RowKey = Guid.NewGuid().ToString(), Text = textContext };
    }

    private async Task<string> AnalyzeImageContent(string imageUrl)
    {
        // Analyze the file using Computer Vision Client
        var textHeaders = await this._client.ReadAsync(imageUrl).ConfigureAwait(false);
        var operationLocation = textHeaders.OperationLocation;

        Thread.Sleep(2000);

        var numberOfCharsInOperationId = 36;
        var operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

        // Read back the results from the analysis request
        ReadOperationResult results;
        do
        {
            results = await this._client.GetReadResultAsync(Guid.Parse(operationId)).ConfigureAwait(false);
        }
        while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

        var textUrlFileResults = results.AnalyzeResult.ReadResults;

        // Assemble into readable string
        var text = new StringBuilder();
        foreach (var page in textUrlFileResults)
        foreach (var line in page.Lines)
        {
            text.AppendLine(line.Text);
        }

        return text.ToString();
    }
}
