# 04: MCPクライアント

このステップでは、To-Doリスト管理用のMCPクライアントを構築します。

## 前提条件

準備については[README](../README.md#前提条件)ドキュメントを参照してください。

## はじめに

- [GitHub個人アクセストークン（PAT）の準備](#github個人アクセストークンpatの準備)
- [MCPクライアント開発の準備](#mcpクライアント開発の準備)
- [MCPクライアントの実装](#mcpクライアントの実装)
- [MCPサーバーアプリの実行](#mcpサーバーアプリの実行)
- [MCPクライアントアプリの実行](#mcpクライアントアプリの実行)
- [リソースのクリーンアップ](#リソースのクリーンアップ)

## GitHub個人アクセストークン（PAT）の準備

MCPクライアントアプリ開発のために、AIモデルへのアクセスが必要です。このワークショップでは、[GitHub Models](https://github.com/marketplace?type=models)の[OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini)を使用します。

GitHub Modelsにアクセスするには、[GitHub個人アクセストークン（PAT）](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)が必要です。

PATを取得するには、[GitHub設定](https://github.com/settings/personal-access-tokens/new)に移動して新しいPATを作成します。必ず"Models"に対して権限を"読み取り専用"に設定してください。

## MCPクライアント開発の準備

[前のセッション](./01-mcp-server.md)で、MCPサーバーとクライアントアプリの両方をすでにコピーしました。それを使い続けましょう。

1. 環境変数`$REPOSITORY_ROOT`があることを確認してください。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. `workshop`ディレクトリに移動します。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. クライアントアプリにGitHub PATを追加します。`{{ GITHUB_PAT }}`を前のセクションで発行されたGitHub PATに置き換えてください。

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. アプリを実行します。

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. プロンプトを入力してアプリが動作しているか確認します。以下は例です：

    ```text
    なぜ空はそんなに青いのですか？
    ```

1. `CTRL`+`C`を入力してアプリを停止します。

## MCPクライアントの実装

1. MCPクライアントアプリディレクトリにいることを確認してください。

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. MCPクライアント用のNuGetパッケージを追加します。

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. `Program.cs`を開き、追加の`using`ディレクティブを以下のように追加します：

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 追加 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 追加 👆👆👆
    
    using OpenAI;
    ```

1. 同じ`Program.cs`で、`var app = builder.Build();`行を見つけて、その直前に以下のコード行を追加します。

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 追加 👇👇👇
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
    // 👆👆👆 追加 👆👆👆
    
    var app = builder.Build();
    ```

1. `Components/Pages/Chat/Chat.razor`を開き、追加の`@using`ディレクティブを追加します。

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 追加 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 追加 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. 同じ`Components/Pages/Chat/Chat.razor`で、`IMcpClient`を別の依存関係として追加します。

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 追加 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 追加 👆👆👆 *@
    
    @implements IDisposable
    ```

1. 同じ`Components/Pages/Chat/Chat.razor`で、`@code { ... }`コードブロックにプライベートフィールドを追加します。

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 追加 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 追加 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. 同じ`Components/Pages/Chat/Chat.razor`で、`OnInitialized()`を`OnInitializedAsync()`に置き換えます。

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

## MCPサーバーアプリの実行

1. `workshop`ディレクトリにいることを確認してください。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. MCPサーバーアプリを実行します。

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## MCPクライアントアプリの実行

1. `workshop`ディレクトリにいることを確認してください。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. MCPクライアントアプリを実行します。

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Webブラウザが開いたら、To-Doリスト項目に関するプロンプトを入力します。以下は例です：

    ```text
    To-Doリストを教えて。
    午前9時に会議を予約して。
    12時にランチを予約して。
    午前9時の会議は終了しました。
    ランチの時間を午後1時に変更して。
    午後1時に別の会議を予約して。
    午後1時の会議をキャンセルして。
    ```

👉 **チャレンジ**：[前のセッション](./02-mcp-remote-server.md)で作成したコンテナまたはリモートサーバーでMCPサーバーを置き換えてください。

## リソースのクリーンアップ

1. 使用したすべてのコンテナイメージを削除します。

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Azureにデプロイしたすべてのリソースを削除します。

    ```bash
    azd down --force --purge
    ```

---

おめでとうございます！🎉 ワークショップのすべてのセッションを正常に完了しました！

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../../../../issues)を作成してください。
