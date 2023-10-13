using Azure.Storage.Blobs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()

    .ConfigureServices(services =>
    {
        var storageConnection = Environment.GetEnvironmentVariable("StorageConnection");
        var thumbnailContainerName = Environment.GetEnvironmentVariable("ThumbnailContainerName");

        var blobServiceClient = new BlobServiceClient(storageConnection);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(thumbnailContainerName);

        services.AddSingleton<BlobContainerClient>(_ => blobContainerClient);
    })

    .Build();

await host.RunAsync();
