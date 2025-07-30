# 04 : Client MCP

Dans cette étape, vous construisez un client MCP pour la gestion de liste de tâches.

## Prérequis

Référez-vous au document [README](../README.md#prérequis) pour la préparation.

## Commencer

- [Préparer le Token d'Accès Personnel (PAT) GitHub](#préparer-le-token-daccès-personnel-pat-github)
- [Préparer le Développement du Client MCP](#préparer-le-développement-du-client-mcp)
- [Implémenter le Client MCP](#implémenter-le-client-mcp)
- [Exécuter l'Application Serveur MCP](#exécuter-lapplication-serveur-mcp)
- [Exécuter l'Application Client MCP](#exécuter-lapplication-client-mcp)
- [Nettoyer les Ressources](#nettoyer-les-ressources)

## Préparer le Token d'Accès Personnel (PAT) GitHub

Pour le développement de l'application client MCP, vous avez besoin d'accéder à un modèle d'IA. Dans cet atelier, [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini) de [GitHub Models](https://github.com/marketplace?type=models) est utilisé.

Pour accéder à GitHub Models, vous devez avoir le [Token d'Accès Personnel (PAT) GitHub](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens).

Pour obtenir le PAT, allez sur [Paramètres GitHub](https://github.com/settings/personal-access-tokens/new) et créez un nouveau PAT. Assurez-vous de définir les permissions en "lecture seule" sur "Models".

## Préparer le Développement du Client MCP

Dans la [session précédente](./02-mcp-server.md), vous avez déjà copié à la fois l'application serveur MCP et client. Continuons à l'utiliser.

1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Naviguez vers le répertoire `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Ajoutez le PAT GitHub à l'application client. Assurez-vous de remplacer `{{ GITHUB_PAT }}` par votre PAT GitHub émis dans la section précédente.

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. Exécutez l'application.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Vérifiez si l'application fonctionne en entrant des prompts. Voici un exemple :

    ```text
    Pourquoi le ciel est-il si bleu ?
    ```

1. Arrêtez l'application en tapant `CTRL`+`C`.

## Implémenter le Client MCP

1. Assurez-vous d'être dans le répertoire de l'application client MCP.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. Ajoutez le package NuGet pour le client MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Ouvrez `Program.cs` et ajoutez des directives `using` supplémentaires avec ce qui suit :

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 Ajouter 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 Ajouter 👆👆👆
    
    using OpenAI;
    ```

1. Dans le même `Program.cs`, trouvez la ligne `var app = builder.Build();` et ajoutez les lignes de code suivantes juste au-dessus.

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 Ajouter 👇👇👇
    builder.Services.AddSingleton<IMcpClient>(sp =>
    {
        var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    
        var uri = new Uri("http://localhost:5242");
    
        var clientTransportOptions = new SseClientTransportOptions()
        {
            Endpoint = new Uri($"{uri.AbsoluteUri.TrimEnd('/')}/mcp")
        };
        var clientTransport = new SseClientTransport(clientTransportOptions, loggerFactory);
    
        var clientOptions = new McpClientOptions()
        {
            ClientInfo = new Implementation()
            {
                Name = "MCP Todo Client",
                Version = "1.0.0",
            }
        };
    
        return McpClientFactory.CreateAsync(clientTransport, clientOptions, loggerFactory).GetAwaiter().GetResult();
    });
    // 👆👆👆 Ajouter 👆👆👆
    
    var app = builder.Build();
    ```

1. Ouvrez `Components/Pages/Chat/Chat.razor` et ajoutez des directives `@using` supplémentaires.

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 Ajouter 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 Ajouter 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. Dans le même `Components/Pages/Chat/Chat.razor`, ajoutez `IMcpClient` comme autre dépendance.

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 Ajouter 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 Ajouter 👆👆👆 *@
    
    @implements IDisposable
    ```

1. Dans le même `Components/Pages/Chat/Chat.razor`, ajoutez un champ privé dans le bloc de code `@code { ... }`.

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 Ajouter 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 Ajouter 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. Dans le même `Components/Pages/Chat/Chat.razor`, remplacez `OnInitialized()` par `OnInitializedAsync()`.

    ```csharp
    // Avant
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // Après
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## Exécuter l'Application Serveur MCP

1. Assurez-vous d'être dans le répertoire `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Exécutez l'application serveur MCP.

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## Exécuter l'Application Client MCP

1. Assurez-vous d'être dans le répertoire `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Exécutez l'application client MCP.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Lorsqu'un navigateur web s'ouvre, entrez des prompts concernant les éléments de la liste de tâches. Voici quelques exemples :

    ```text
    Dis-moi la liste de choses à faire.
    Réserve 9h pour une réunion.
    Réserve 12h pour le déjeuner.
    La réunion de 9h est terminée.
    Change l'heure du déjeuner à 13h.
    Réserve une autre réunion à 13h.
    Annule la réunion de 13h.
    ```

👉 **DÉFI** : Remplacez le Serveur MCP par un conteneur ou serveur distant créé dans la [session précédente](./02-mcp-remote-server.md).

## Nettoyer les Ressources

1. Supprimez toutes les images de conteneur utilisées.

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Supprimez toutes les ressources déployées sur Azure.

    ```bash
    azd down --force --purge
    ```

---

Félicitations ! 🎉 Vous avez terminé toutes les sessions de l'atelier avec succès !

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).
