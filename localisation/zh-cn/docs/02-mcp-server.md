# 02: MCP 服务器

在这一步中，您正在构建用于待办事项列表管理的 MCP 服务器。

## 先决条件

请参考 [README](../README.md#先决条件) 文档进行准备。

## 开始使用

- [检查 GitHub Copilot 代理模式](#检查-github-copilot-代理模式)
- [准备自定义指令](#准备自定义指令)
- [准备 MCP 服务器开发](#准备-mcp-服务器开发)
- [开发待办事项列表管理逻辑](#开发待办事项列表管理逻辑)
- [删除 API 逻辑](#删除-api-逻辑)
- [转换为 MCP 服务器](#转换为-mcp-服务器)
- [运行 MCP 服务器](#运行-mcp-服务器)
- [测试 MCP 服务器](#测试-mcp-服务器)

## 检查 GitHub Copilot 代理模式

1. 点击 GitHub Codespace 或 VS Code 顶部的 GitHub Copilot 图标并打开 GitHub Copilot 窗口。

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. 如果要求您登录或注册，请照做。这是免费的。
1. 确保您正在使用 GitHub Copilot 代理模式。

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. 选择模型为 `GPT-4.1` 或 `Claude Sonnet 4`。
1. 确保您已配置 [MCP 服务器](./00-setup.md#设置-mcp-服务器)。

## 启动 MCP 服务器 &ndash; Awesome Copilot

1. 通过在 Windows 上按 `F1` 或 `Ctrl`+`Shift`+`P`，或在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 如果 `github` 和 `monkeymcp` MCP 服务器仍在运行，请停止它们。
1. 选择 `awesome-copilot` 然后点击 `Start Server`。

## 配置 Beast 模式

1. 输入以下提示来搜索 beast 模式提示。

    ```text
    Show me the list of copilot instructions for beast chatmode. It should be general purpose.
    ```

   应该返回类似于 `4.1 Beast Chat Mode` 的结果。如果不是，请再次搜索。

1. 输入以下提示来保存 beast 聊天模式。

    ```text
    Save it under the `.github/chatmodes` directory.
    ```

1. 选择 `4.1-Beast` 模式而不是 `Agent` 模式。它将自动将 LLM 更改为 `GPT 4.1`。

1. 设置环境变量 `$REPOSITORY_ROOT`。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 复制工作区设置。

    ```bash
    # bash/zsh
    cp $REPOSITORY_ROOT/docs/.vscode/settings.json \
       $REPOSITORY_ROOT/.vscode/settings.json
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/settings.json `
              -Destination $REPOSITORY_ROOT/.vscode/settings.json -Force
    ```

## 准备自定义指令

1. 设置环境变量 `$REPOSITORY_ROOT`。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 复制自定义指令。

    ```bash
    # bash/zsh
    cp $REPOSITORY_ROOT/docs/.github/todoapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/todoapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

## 准备 MCP 服务器开发

在 `start` 目录中，已经搭建了一个 ASP.NET Core Minimal API 应用。您将使用它作为起点。

1. 确保您有环境变量 `$REPOSITORY_ROOT`。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 将搭建的应用从 `start` 复制到 `workshop`。

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

## 开发待办事项列表管理逻辑

1. 确保您正在使用 GitHub Copilot 代理模式，模型为 `Claude Sonnet 4` 或 `GPT-4.1`。
1. 确保 `microsoft.docs.mcp` 和 `sequentialthinking` MCP 服务器都在运行。
1. 使用如下提示来实现待办事项列表管理逻辑。

    ```text
    我想在 ASP.NET Core Minimal API 应用程序中实现待办事项列表管理逻辑。请按照以下应用程序开发指示操作。
    
    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - 使用 SQLite 作为数据库，并应使用内存功能。
    - 使用 EntityFramework Core 进行数据库事务。
    - 在应用程序启动时初始化数据库。
    - 待办事项只包含 `ID`、`Text` 和 `IsCompleted` 列。
    - 待办事项列表管理有 5 个功能 - 创建、列表、更新、完成和删除。
    - 如有必要，添加与 .NET 9 兼容的 NuGet 包。
    - 不要为待办事项列表管理实现 API 端点。
    - 不要添加初始数据。
    - 不要引用 `complete` 目录。
    - 不要引用 `start` 目录。
    ```

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。
1. 使用如下提示来验证开发结果。

    ```text
    我想构建应用程序。按照指示操作。

    - 使用 context7。
    - 构建应用程序并验证其是否正确构建。
    - 如果构建失败，分析问题并修复它们。
    ```

   > **注意**：
   >
   > - 直到构建成功，重复此步骤。
   > - 如果构建持续失败，检查错误消息并要求 GitHub Copilot Agent 解决它们。

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。
1. 使用如下提示来验证开发结果。

    ```text
    我想向应用程序添加 `TodoTool` 类。按照指示操作。

    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - `TodoTool` 类应包含 5 个方法 - 创建、列表、更新、完成和删除。
    - 不要注册依赖项。
    ```

## 删除 API 逻辑

1. 确保您已设置 `$REPOSITORY_ROOT` 环境变量。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 导航到应用程序项目。

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. 打开 `Program.cs` 并删除以下所有内容：

   ```csharp
   // 👇👇👇 删除 👇👇👇
   // Add services to the container.
   // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
   builder.Services.AddOpenApi();
   // 👆👆👆 删除 👆👆👆
   ```

   ```csharp
   // 👇👇👇 删除 👇👇👇
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.MapOpenApi();
   }
   // 👆👆👆 删除 👆👆👆
   ```

   ```csharp
   // 👇👇👇 删除 👇👇👇
   var summaries = new[]
   {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   };
   // 👆👆👆 删除 👆👆👆
   ```

   ```csharp
   // 👇👇👇 删除 👇👇👇
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
   // 👆👆👆 删除 👆👆👆
   ```

   ```csharp
   // 👇👇👇 删除 👇👇👇
   record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
   // 👆👆👆 删除 👆👆👆
   ```

1. 移除 NuGet 包。

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```

## 转换为 MCP 服务器

1. 为 MCP 服务器添加 NuGet 包。

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. 打开 `Program.cs`，找到 `var app = builder.Build();` 并在该行之前添加以下代码段：

    ```csharp
    // 👇👇👇 添加 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 添加 👆👆👆
    
    var app = builder.Build();
    ```

1. 在同一个 `Program.cs` 中，找到 `app.Run();` 并在该行之前添加以下代码段：

    ```csharp
    // 👇👇👇 添加 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 添加 👆👆👆
    
    app.Run();
    ```

1. 打开 `TodoTool.cs` 并添加如下装饰器。

   > **注意**：方法名称可能因 GitHub Copilot 生成方式而异。

    ```csharp
    // 👇👇👇 添加 👇👇👇
    [McpServerToolType]
    // 👆👆👆 添加 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 添加 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 添加 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 添加 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 添加 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 添加 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 添加 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 添加 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 添加 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 添加 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 添加 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. 在同一个 `TodoTool.cs` 中，添加额外的 `using` 指令：

   > **注意**：命名空间可能因 GitHub Copilot 生成方式而异。

    ```csharp
    // 👇👇👇 添加 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 添加 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. 构建应用程序。

    ```bash
    dotnet build
    ```

## 运行 MCP 服务器

1. 确保您已设置 `$REPOSITORY_ROOT` 环境变量。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 导航到应用程序项目。

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. 运行 MCP 服务器应用程序。

    ```bash
    dotnet run
    ```

1. 按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P`，在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，然后搜索 `MCP: Add Server...`。
1. 选择 `HTTP (HTTP or Server-Sent Events)`。
1. 输入 `http://localhost:5242/mcp` 作为服务器 URL。
1. 输入 `mcp-todo` 作为服务器 ID。
1. 选择 `Workspace settings` 作为保存 MCP 设置的位置。
1. 打开 `.vscode/mcp.json` 查看已添加的 MCP 服务器。

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
        // 👇👇👇 已添加 👇👇👇
        "mcp-todo": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 已添加 👆👆👆
      }
    }
    ```

## 测试 MCP 服务器

1. 以代理模式打开 GitHub Copilot Chat。
1. 输入以下提示之一：

    ```text
    显示待办事项列表。
    添加"下午12点吃午饭"。
    将午饭标记为已完成。
    添加"下午3点开会"。
    将会议更改为下午3点30分。
    取消会议。
    ```

1. 如果发生错误，要求 GitHub Copilot 修复它：

    ```text
    我遇到了错误"xxx"。请找到问题并修复它。
    ```

---

很好。您已完成"MCP 服务器开发"步骤。让我们继续进行 [步骤 02: MCP 远程服务器](./02-mcp-remote-server.md)。

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../../issues)。