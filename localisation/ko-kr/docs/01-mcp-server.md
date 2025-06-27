# 01: MCP 서버

이 단계에서는 할 일 목록 관리를 위한 MCP 서버를 구축합니다.

## 전제 조건

준비를 위해 [README](../README.md#prerequisites) 문서를 참조하세요.

## 시작하기

- [GitHub Copilot 에이전트 모드 확인](#github-copilot-에이전트-모드-확인)
- [사용자 정의 지침 준비](#사용자-정의-지침-준비)
- [MCP 서버 개발 준비](#mcp-서버-개발-준비)
- [할 일 목록 관리 로직 개발](#할-일-목록-관리-로직-개발)
- [API 로직 제거](#api-로직-제거)
- [MCP 서버로 변환](#mcp-서버로-변환)
- [MCP 서버 실행](#mcp-서버-실행)
- [MCP 서버 테스트](#mcp-서버-테스트)

## GitHub Copilot 에이전트 모드 확인

1. GitHub Codespace 또는 VS Code 상단의 GitHub Copilot 아이콘을 클릭하고 GitHub Copilot 창을 엽니다.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. 로그인하거나 가입하라는 메시지가 표시되면 그렇게 하세요. 무료입니다.
1. GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-01.png)

1. 모델을 `GPT-4.1` 또는 `Claude Sonnet 4`로 선택합니다.
1. [MCP 서버](./00-setup.md#set-up-mcp-servers)를 구성했는지 확인하세요.

## 사용자 정의 지침 준비

1. `$REPOSITORY_ROOT` 환경 변수를 설정합니다.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 사용자 정의 지침을 복사합니다.

    ```bash
    # bash/zsh
    cp -r $REPOSITORY_ROOT/docs/.github/. \
          $REPOSITORY_ROOT/.github/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/* `
              -Destination $REPOSITORY_ROOT/.github/ -Recurse -Force
    ```

## MCP 서버 개발 준비

`start` 디렉토리에는 ASP.NET Core Minimal API 앱이 이미 스캐폴딩되어 있습니다. 이를 시작점으로 사용합니다.

1. `$REPOSITORY_ROOT` 환경 변수가 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 스캐폴딩된 앱을 `start`에서 `workshop`으로 복사합니다.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cp -r $REPOSITORY_ROOT/start/. \
          $REPOSITORY_ROOT/workshop/
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    Copy-Item -Path $REPOSITORY_ROOT/start/* `
              -Destination $REPOSITORY_ROOT/workshop/ -Recurse -Force
    ```

## 할 일 목록 관리 로직 개발

1. `Claude Sonnet 4` 또는 `GPT-4.1` 모델로 GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.
1. `context7` MCP 서버가 실행 중인지 확인하세요.
1. 다음과 같은 프롬프트를 사용하여 할 일 목록 관리 로직을 구현합니다.

    ```text
    ASP.NET Core를 사용하여 할 일 목록 애플리케이션을 개발하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - 애플리케이션에는 ID, 제목, 설명, 완료 상태, 생성 날짜, 업데이트 날짜 속성을 가진 작업 관리 모델이 포함되어야 합니다.
    - 필요한 경우 .NET 9와 호환되는 NuGet 패키지를 추가하세요.
    - 할 일 목록 관리를 위한 API 엔드포인트를 구현하지 마세요.
    - 초기 데이터를 추가하지 마세요.
    - `complete` 디렉토리를 참조하지 마세요.
    - `start` 디렉토리를 참조하지 마세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

1. 다음과 같은 프롬프트를 사용하여 TodoTool 클래스를 추가합니다.

    ```text
    애플리케이션에 `TodoTool` 클래스를 추가하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - `TodoTool` 클래스에는 5개의 메서드가 포함되어야 합니다 - 생성, 목록, 업데이트, 완료, 삭제.
    - 종속성을 등록하지 마세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

1. 다음과 같은 프롬프트를 사용하여 애플리케이션을 빌드합니다.

    ```text
    애플리케이션을 빌드하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 애플리케이션을 빌드하고 제대로 빌드되는지 확인하세요.
    - 빌드가 실패하면 문제를 분석하고 수정하세요.
    ```

   > **참고**:
   >
   > - 빌드가 성공할 때까지 이 단계를 반복하세요.
   > - 빌드가 계속 실패하면 오류 메시지를 확인하고 GitHub Copilot Agent에게 해결을 요청하세요.

## API 로직 제거

1. `$REPOSITORY_ROOT` 환경 변수가 설정되어 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 애플리케이션 프로젝트로 이동합니다.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. `Program.cs`를 열고 다음을 모두 제거합니다:

   ```csharp
   // 👇👇👇 제거 👇👇👇
   // Add services to the container.
   // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
   builder.Services.AddOpenApi();
   // 👆👆👆 제거 👆👆👆
   ```

   ```csharp
   // 👇👇👇 제거 👇👇👇
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.MapOpenApi();
   }
   // 👆👆👆 제거 👆👆👆
   ```

   ```csharp
   // 👇👇👇 제거 👇👇👇
   var summaries = new[]
   {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   };
   // 👆👆👆 제거 👆👆👆
   ```

   ```csharp
   // 👇👇👇 제거 👇👇👇
   app.MapGet("/weatherforecast", () =>
   {
       var forecast =  Enumerable.Range(1, 5).Select(index =>
           new WeatherForecast
           (
               DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
               Random.Shared.Next(-20, 55),
               summaries[Random.Shared.Next(summaries.Length)]
           ))
           .ToArray();
       return forecast;
   })
   .WithName("GetWeatherForecast");
   // 👆👆👆 제거 👆👆👆
   ```

   ```csharp
   // 👇👇👇 제거 👇👇👇
   record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
   // 👆👆👆 제거 👆👆👆
   ```

1. NuGet 패키지를 제거합니다.

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```## MCP 서버로 변환

1. MCP 서버용 NuGet 패키지를 추가합니다.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. `Program.cs`를 열고 `var app = builder.Build();`를 찾아 해당 라인 바로 위에 다음 코드 스니펫을 추가합니다:

    ```csharp
    // 👇👇👇 추가 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 추가 👆👆👆
    
    var app = builder.Build();
    ```

1. 같은 `Program.cs`에서 `app.Run();`를 찾아 해당 라인 바로 위에 다음 코드 스니펫을 추가합니다:

    ```csharp
    // 👇👇👇 추가 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 추가 👆👆👆
    
    app.Run();
    ```

1. `TodoTool.cs`를 열고 아래와 같이 데코레이터를 추가합니다.

   > **참고**: GitHub Copilot이 생성하는 방식에 따라 메서드 이름이 다를 수 있습니다.

    ```csharp
    // 👇👇👇 추가 👇👇👇
    [McpServerToolType]
    // 👆👆👆 추가 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 추가 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 추가 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 추가 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 추가 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 추가 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 추가 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 추가 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 추가 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 추가 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 추가 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. 같은 `TodoTool.cs`에서 추가 `using` 지시문을 추가합니다:

   > **참고**: GitHub Copilot이 생성하는 방식에 따라 네임스페이스가 다를 수 있습니다.

    ```csharp
    // 👇👇👇 추가 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 추가 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. 애플리케이션을 빌드합니다.

    ```bash
    dotnet build
    ```## MCP 서버 실행

1. `$REPOSITORY_ROOT` 환경 변수가 설정되어 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 애플리케이션 프로젝트로 이동합니다.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. MCP 서버 애플리케이션을 실행합니다.

    ```bash
    dotnet run
    ```

1. `F1`을 누르거나 Windows에서 `Ctrl`+`Shift`+`P`, Mac OS에서 `Cmd`+`Shift`+`P`를 눌러 명령 팔레트를 열고 `MCP: Add Server...`를 검색합니다.
1. `HTTP (HTTP or Server-Sent Events)`를 선택합니다.
1. 서버 URL로 `http://localhost:5242`를 입력합니다.
1. 서버 ID로 `mcp-todo-list`를 입력합니다.
1. MCP 설정을 저장할 위치로 `Workspace settings`를 선택합니다.
1. `.vscode/mcp.json`을 열어 MCP 서버가 추가되었는지 확인합니다.

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        // 👇👇👇 추가됨 👇👇👇
        "mcp-todo-list": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 추가됨 👆👆👆
      }
    }## MCP 서버 테스트

1. GitHub Copilot Chat을 에이전트 모드로 엽니다.
1. 다음 프롬프트 중 하나를 입력합니다:

    ```text
    할 일 목록을 보여주세요.
    "오후 12시 점심"을 추가하세요.
    점심을 완료로 표시하세요.
    "오후 3시 회의"를 추가하세요.
    회의를 오후 3시 30분으로 변경하세요.
    회의를 취소하세요.
    ```

1. 오류가 발생하면 GitHub Copilot에게 수정을 요청하세요:

    ```text
    "xxx" 오류가 발생했습니다. 문제를 찾아서 수정해 주세요.
    ```

---

좋습니다. "MCP 서버 개발" 단계를 완료했습니다. 이제 [2단계: MCP 원격 서버](./02-mcp-remote-server.md)로 이동하겠습니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.