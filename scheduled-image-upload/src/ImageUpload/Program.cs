using Azure.Storage.Blobs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()

    .ConfigureServices(services =>
    {
        var storageConnection = Environment.GetEnvironmentVariable("StorageConnection");
        var imageContainerName = Environment.GetEnvironmentVariable("ImageContainerName");

        var blobServiceClient = new BlobServiceClient(storageConnection);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(imageContainerName);

        services.AddSingleton<BlobContainerClient>(_ => blobContainerClient);
    })

    .Build();

host.Run();
