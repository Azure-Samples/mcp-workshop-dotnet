# 04: MCP 클라이언트

이 단계에서는 할 일 목록 관리를 위한 MCP 클라이언트를 구축합니다.

## 전제 조건

준비를 위해 [README](../README.md#전제-조건) 문서를 참조하세요.

## 시작하기

- [GitHub 개인 액세스 토큰(PAT) 준비](#github-개인-액세스-토큰pat-준비)
- [MCP 클라이언트 개발 준비](#mcp-클라이언트-개발-준비)
- [MCP 클라이언트 구현](#mcp-클라이언트-구현)
- [MCP 서버 앱 실행](#mcp-서버-앱-실행)
- [MCP 클라이언트 앱 실행](#mcp-클라이언트-앱-실행)
- [리소스 정리](#리소스-정리)

## GitHub 개인 액세스 토큰(PAT) 준비

MCP 클라이언트 앱 개발을 위해 AI 모델에 대한 액세스가 필요합니다. 이 워크샵에서는 [GitHub Models](https://github.com/marketplace?type=models)의 [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini)를 사용합니다.

GitHub Models에 액세스하려면 [GitHub 개인 액세스 토큰(PAT)](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)이 있어야 합니다.

PAT를 얻으려면 [GitHub 설정](https://github.com/settings/personal-access-tokens/new)으로 이동하여 새 PAT를 생성하세요. "Models"에 대한 권한을 "읽기 전용"으로 설정해야 합니다.

## MCP 클라이언트 개발 준비

[이전 세션](./02-mcp-server.md)에서 이미 MCP 서버와 클라이언트 앱을 모두 복사했습니다. 계속 사용해보겠습니다.

1. `$REPOSITORY_ROOT` 환경 변수가 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. `workshop` 디렉토리로 이동하세요.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. 클라이언트 앱에 GitHub PAT를 추가하세요. `{{ GITHUB_PAT }}`를 이전 섹션에서 발급받은 GitHub PAT로 교체하세요.

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. 앱을 실행하세요.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. 프롬프트를 입력하여 앱이 실행 중인지 확인하세요. 다음은 예시입니다:

    ```text
    하늘은 왜 그렇게 파란가요?
    ```

1. `CTRL`+`C`를 입력하여 앱을 중지하세요.

## MCP 클라이언트 구현

1. MCP 클라이언트 앱 디렉토리에 있는지 확인하세요.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. MCP 클라이언트용 NuGet 패키지를 추가하세요.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. `Program.cs`를 열고 다음과 같이 추가 `using` 지시문을 추가하세요:

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 추가 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 추가 👆👆👆
    
    using OpenAI;
    ```

1. 같은 `Program.cs`에서 `var app = builder.Build();` 라인을 찾고 바로 위에 다음 코드 라인을 추가하세요.

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 추가 👇👇👇
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
    // 👆👆👆 추가 👆👆👆
    
    var app = builder.Build();
    ```

1. `Components/Pages/Chat/Chat.razor`를 열고 추가 `@using` 지시문을 추가하세요.

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 추가 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 추가 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. 같은 `Components/Pages/Chat/Chat.razor`에서 `IMcpClient`를 다른 의존성으로 추가하세요.

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 추가 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 추가 👆👆👆 *@
    
    @implements IDisposable
    ```

1. 같은 `Components/Pages/Chat/Chat.razor`에서 `@code { ... }` 코드 블록에 private 필드를 추가하세요.

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 추가 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 추가 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. 같은 `Components/Pages/Chat/Chat.razor`에서 `OnInitialized()`를 `OnInitializedAsync()`로 교체하세요.

    ```csharp
    // 이전
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // 이후
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## MCP 서버 앱 실행

1. `workshop` 디렉토리에 있는지 확인하세요.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. MCP 서버 앱을 실행하세요.

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## MCP 클라이언트 앱 실행

1. `workshop` 디렉토리에 있는지 확인하세요.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. MCP 클라이언트 앱을 실행하세요.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. 웹 브라우저가 열리면 할 일 목록 항목에 대한 프롬프트를 입력하세요. 다음은 몇 가지 예시입니다:

    ```text
    할 일 목록을 알려주세요.
    오전 9시에 회의를 예약해주세요.
    오후 12시에 점심을 예약해주세요.
    오전 9시 회의가 끝났습니다.
    점심 시간을 오후 1시로 변경해주세요.
    오후 1시에 다른 회의를 예약해주세요.
    오후 1시 회의를 취소해주세요.
    ```

👉 **도전과제**: [이전 세션](./02-mcp-remote-server.md)에서 생성한 컨테이너 또는 원격 서버로 MCP 서버를 교체해보세요.

## 리소스 정리

1. 사용된 모든 컨테이너 이미지를 삭제하세요.

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Azure에 배포된 모든 리소스를 삭제하세요.

    ```bash
    azd down --force --purge
    ```

---

축하합니다! 🎉 모든 워크샵 세션을 성공적으로 완료했습니다!

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.
