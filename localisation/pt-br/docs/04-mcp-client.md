# 04: Cliente MCP

Neste passo, você está construindo um cliente MCP para gerenciamento de lista de tarefas.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Preparar Token de Acesso Pessoal (PAT) do GitHub](#preparar-token-de-acesso-pessoal-pat-do-github)
- [Preparar Desenvolvimento do Cliente MCP](#preparar-desenvolvimento-do-cliente-mcp)
- [Implementar Cliente MCP](#implementar-cliente-mcp)
- [Executar Aplicação do Servidor MCP](#executar-aplicação-do-servidor-mcp)
- [Executar Aplicação do Cliente MCP](#executar-aplicação-do-cliente-mcp)
- [Limpar Recursos](#limpar-recursos)

## Preparar Token de Acesso Pessoal (PAT) do GitHub

Para o desenvolvimento da aplicação cliente MCP, você precisa de acesso a um modelo de IA. Neste workshop, [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini) do [GitHub Models](https://github.com/marketplace?type=models) é usado.

Para acessar o GitHub Models, você deve ter o [Token de Acesso Pessoal (PAT) do GitHub](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens).

Para obter o PAT, vá para [Configurações do GitHub](https://github.com/settings/personal-access-tokens/new) e crie um novo PAT. Certifique-se de definir as permissões como "somente leitura" em "Models".

## Preparar Desenvolvimento do Cliente MCP

Na [sessão anterior](./01-mcp-server.md), você já copiou tanto a aplicação do servidor MCP quanto a do cliente. Vamos continuar usando-a.

1. Certifique-se de que você tem a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navegue para o diretório `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Adicione o PAT do GitHub à aplicação cliente. Certifique-se de substituir `{{ GITHUB_PAT }}` pelo seu PAT do GitHub emitido da seção anterior.

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. Execute a aplicação.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Verifique se a aplicação está funcionando inserindo prompts. Aqui está um exemplo:

    ```text
    Por que o céu é tão azul?
    ```

1. Pare a aplicação digitando `CTRL`+`C`.

## Implementar Cliente MCP

1. Certifique-se de que você está no diretório da aplicação cliente MCP.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. Adicione o pacote NuGet para o cliente MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Abra `Program.cs` e adicione diretivas `using` extras com o seguinte:

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 Adicionar 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 Adicionar 👆👆👆
    
    using OpenAI;
    ```

1. No mesmo `Program.cs`, encontre a linha `var app = builder.Build();` e adicione as seguintes linhas de código logo acima dela.

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 Adicionar 👇👇👇
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
    // 👆👆👆 Adicionar 👆👆👆
    
    var app = builder.Build();
    ```

1. Abra `Components/Pages/Chat/Chat.razor` e adicione diretivas `@using` extras.

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 Adicionar 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 Adicionar 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. No mesmo `Components/Pages/Chat/Chat.razor`, adicione `IMcpClient` como outra dependência.

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 Adicionar 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 Adicionar 👆👆👆 *@
    
    @implements IDisposable
    ```

1. No mesmo `Components/Pages/Chat/Chat.razor`, adicione um campo privado no bloco de código `@code { ... }`.

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 Adicionar 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 Adicionar 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. No mesmo `Components/Pages/Chat/Chat.razor`, substitua `OnInitialized()` por `OnInitializedAsync()`.

    ```csharp
    // Antes
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // Depois
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## Executar Aplicação do Servidor MCP

1. Certifique-se de que você está no diretório `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Execute a aplicação do servidor MCP.

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## Executar Aplicação do Cliente MCP

1. Certifique-se de que você está no diretório `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Execute a aplicação do cliente MCP.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Quando um navegador web abrir, insira prompts sobre itens da lista de tarefas. Aqui estão alguns exemplos:

    ```text
    Me diga a lista de tarefas.
    Agendar 9h para uma reunião.
    Agendar 12h para almoço.
    A reunião das 9h terminou.
    Mudar o horário do almoço para 13h.
    Agendar outra reunião às 13h.
    Cancelar a reunião das 13h.
    ```

👉 **DESAFIO**: Substitua o Servidor MCP por um contêiner ou servidor remoto criado na [sessão anterior](./02-mcp-remote-server.md).

## Limpar Recursos

1. Exclua todas as imagens de contêiner usadas.

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Exclua todos os recursos implantados no Azure.

    ```bash
    azd down --force --purge
    ```

---

Parabéns! 🎉 Você completou todas as sessões do workshop com sucesso!

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../../../../issues).
