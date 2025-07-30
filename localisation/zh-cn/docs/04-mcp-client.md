# 04: MCP 客户端

在这一步中，您正在构建用于待办事项列表管理的 MCP 客户端。

## 先决条件

请参考 [README](../README.md#先决条件) 文档进行准备。

## 开始使用

- [准备 GitHub 个人访问令牌 (PAT)](#准备-github-个人访问令牌-pat)
- [准备 MCP 客户端开发](#准备-mcp-客户端开发)
- [实现 MCP 客户端](#实现-mcp-客户端)
- [运行 MCP 服务器应用](#运行-mcp-服务器应用)
- [运行 MCP 客户端应用](#运行-mcp-客户端应用)
- [清理资源](#清理资源)

## 准备 GitHub 个人访问令牌 (PAT)

对于 MCP 客户端应用开发，您需要访问 AI 模型。在此工作坊中，使用来自 [GitHub Models](https://github.com/marketplace?type=models) 的 [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini)。

要访问 GitHub Models，您必须拥有 [GitHub 个人访问令牌 (PAT)](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)。

要获取 PAT，请转到 [GitHub 设置](https://github.com/settings/personal-access-tokens/new) 并创建新的 PAT。确保您必须将权限设置为在"Models"上"只读"。

## 准备 MCP 客户端开发

在[上一次会话](./02-mcp-server.md)中，您已经复制了 MCP 服务器和客户端应用。让我们继续使用它。

1. 确保您已获得环境变量 `$REPOSITORY_ROOT`。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 导航到 `workshop` 目录。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. 将 GitHub PAT 添加到客户端应用。确保将 `{{ GITHUB_PAT }}` 替换为您从上一节获得的 GitHub PAT。

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. 运行应用。

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. 通过输入提示验证应用是否正在运行。这里有一个例子：

    ```text
    为什么天空这么蓝？
    ```

1. 通过键入 `CTRL`+`C` 停止应用。

## 实现 MCP 客户端

1. 确保您在 MCP 客户端应用目录中。

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. 为 MCP 客户端添加 NuGet 包。

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. 打开 `Program.cs` 并添加以下额外的 `using` 指令：

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 添加 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 添加 👆👆👆
    
    using OpenAI;
    ```

1. 在同一个 `Program.cs` 中，找到 `var app = builder.Build();` 行，并在其正上方添加以下代码行。

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 添加 👇👇👇
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
    // 👆👆👆 添加 👆👆👆
    
    var app = builder.Build();
    ```

1. 打开 `Components/Pages/Chat/Chat.razor` 并添加额外的 `@using` 指令。

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 添加 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 添加 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. 在同一个 `Components/Pages/Chat/Chat.razor` 中，添加 `IMcpClient` 作为另一个依赖项。

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 添加 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 添加 👆👆👆 *@
    
    @implements IDisposable
    ```

1. 在同一个 `Components/Pages/Chat/Chat.razor` 中，在 `@code { ... }` 代码块中添加一个私有字段。

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 添加 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 添加 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. 在同一个 `Components/Pages/Chat/Chat.razor` 中，将 `OnInitialized()` 替换为 `OnInitializedAsync()`。

    ```csharp
    // 之前
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // 之后
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## 运行 MCP 服务器应用

1. 确保您在 `workshop` 目录中。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. 运行 MCP 服务器应用。

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## 运行 MCP 客户端应用

1. 确保您在 `workshop` 目录中。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. 运行 MCP 客户端应用。

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. 当网络浏览器打开时，输入关于待办事项列表项目的提示。以下是一些示例：

    ```text
    告诉我待办事项列表。
    预约上午9点开会。
    预约12点吃午饭。
    上午9点的会议结束了。
    将午餐时间改为下午1点。
    预约下午1点的另一次会议。
    取消下午1点的会议。
    ```

👉 **挑战**：将 MCP 服务器替换为在[上一次会话](./02-mcp-remote-server.md)中创建的容器或远程服务器。

## 清理资源

1. 删除所有使用的容器映像。

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. 删除部署到 Azure 的所有资源。

    ```bash
    azd down --force --purge
    ```

---

恭喜！🎉 您已成功完成所有工作坊会话！

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../../issues)。
