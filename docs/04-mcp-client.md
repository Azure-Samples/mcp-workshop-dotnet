# 04: MCP Client

In this step, you're building an MCP client for to-do list management.

## Prerequisites

Refer to the [README](../README.md#prerequisites) doc for preparation.

## Getting Started

- [Prepare GitHub Personal Access Token (PAT)](#prepare-github-personal-access-token-pat)
- [Prepare MCP Client Development](#prepare-mcp-client-development)
- [Implement MCP Client](#implement-mcp-client)
- [Run MCP Server App](#run-mcp-server-app)
- [Run MCP Client App](#run-mcp-client-app)
- [Clean Up Resources](#clean-up-resources)

## Prepare GitHub Personal Access Token (PAT)

For the MCP client app development, you need to access to an AI model. In this workshop, [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini) from [GitHub Models](https://github.com/marketplace?type=models) is used.

To access to GitHub Models, you must have the [GitHub Personal Access Token (PAT)](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens).

To get the PAT, go to [GitHub Settings](https://github.com/settings/personal-access-tokens/new) and create a new PAT. Make sure that you must set the permissions to "read-only" on "Models".

## Prepare MCP Client Development

In the [previous session](./01-mcp-server.md), you've already copied both MCP server and client app. Let's keep using it.

1. Make sure you've got the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navigate to the `workshop` directory.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Add GitHub PAT to the client app. Make sure to replace `{{ GITHUB_PAT }}` with your GitHub PAT issued from the previous section.

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. Run the app.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Verify whether the app is up and running by entering prompts. Here's an example:

    ```text
    Why is the sky so blue?
    ```

1. Stop the app by typing `CTRL`+`C`.

## Implement MCP Client

1. Make sure that you're in the MCP client app directory.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. Add NuGet package for the MCP client.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Open `Program.cs` and add extra `using` directives with the following:

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 Add 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 Add 👆👆👆
    
    using OpenAI;
    ```

1. In the same `Program.cs`, find the `var app = builder.Build();` line and add the following code lines just above it.

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 Add 👇👇👇
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
    // 👆👆👆 Add 👆👆👆
    
    var app = builder.Build();
    ```

1. Open `Components/Pages/Chat/Chat.razor` and add extra `@using` directives.

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 Add 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 Add 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. In the same `Components/Pages/Chat/Chat.razor`, add `IMcpClient` as another dependency.

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 Add 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 Add 👆👆👆 *@
    
    @implements IDisposable
    ```

1. In the same `Components/Pages/Chat/Chat.razor`, add a private field in the `@code { ... }` code block.

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 Add 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 Add 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. In the same `Components/Pages/Chat/Chat.razor`, replace `OnInitialized()` with `OnInitializedAsync()`.

    ```csharp
    // Before
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // After
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## Run MCP Server App

1. Make sure that you're in the `workshop` directory.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Run the MCP server app.

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## Run MCP Client App

1. Make sure that you're in the `workshop` directory.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Run the MCP client app.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. When a web browser opens, enter prompts about to-do list items. Here are some examples:

    ```text
    Tell me the list to do.
    Book 9am for a meeting.
    Book 12pm for lunch.
    Meeting at 9am is over.
    Change the lunch time to 1pm.
    Book another meeting at 1pm.
    Cancel the meeting at 1pm.
    ```

👉 **CHALLENGE**: Replace THE MCP Server with a container or remote server created in the [previous session](./02-mcp-remote-server.md).

## Clean Up Resources

1. Delete all container images used.

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Delete all resources deployed onto Azure.

    ```bash
    azd down --force --purge
    ```

---

Congratulations! 🎉 You've completed all the workshop sessions successfully!
