using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()

    .ConfigureServices(services =>
    {
        var subscriptionKey = Environment.GetEnvironmentVariable("ComputerVisionKey");
        var endpoint = Environment.GetEnvironmentVariable("ComputerVisionEndPoint");

        var credentials = new ApiKeyServiceClientCredentials(subscriptionKey);
        var client = new ComputerVisionClient(credentials) { Endpoint = endpoint };

        services.AddSingleton<IComputerVisionClient>(_ => client);
    })

    .Build();

await host.RunAsync();
