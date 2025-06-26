# 01: MCP Server

In this step, you're building an MCP server for to-do list management.

## Prerequisites

Refer to the [README](../README.md#prerequisites) doc for preparation.

## Getting Started

- [Check GitHub Copilot Agent Mode](#check-github-copilot-agent-mode)
- [Prepare Custom Instructions](#prepare-custom-instructions)
- [Prepare MCP Server Development](#prepare-mcp-server-development)
- [Develop To-do List Management Logic](#develop-to-do-list-management-logic)
- [Remove API Logic](#remove-api-logic)
- [Convert to MCP Server](#convert-to-mcp-server)
- [Run MCP Server](#run-mcp-server)
- [Test MCP Server](#test-mcp-server)

## Check GitHub Copilot Agent Mode

1. Click the GitHub Copilot icon on the top of GitHub Codespace or VS Code and open GitHub Copilot window.

   ![Open GitHub Copilot Chat](./images/setup-01.png)

1. If you're asked to login or sign up, do it. It's free of charge.
1. Make sure you're using GitHub Copilot Agent Mode.

   ![GitHub Copilot Agent Mode](./images/setup-02.png)

1. Select model to either `GPT-4.1` or `Claude Sonnet 4`.
1. Make sure that you've configured [MCP Servers](./00-setup.md#set-up-mcp-servers).

## Prepare Custom Instructions

1. Set the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copy custom instructions.

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

## Prepare MCP Server Development

In the `start` directory, an ASP.NET Core Minimal API app is already scaffolded. You'll use it as a starting point.

1. Make sure you've got the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copy scaffolded app to `workshop` from `start`.

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

## Develop To-do List Management Logic

1. Make sure that you're using GitHub Copilot Agent Mode with the model of `Claude Sonnet 4` or `GPT-4.1`.
1. Make sure that the `context7` MCP server is up and running.
1. Use the prompt like below to implement a to-do list management logic.

    ```text
    I'd like to implement a to-do list management logic in the ASP.NET Core Minimal API app. Follow the instructions below for the app development.
    
    - Use context7.
    - Identify all the steps first, which you're going to do.
    - Your working directory is `workshop/src/McpTodoServer.ContainerApp`.
    - Use SQLite as a database and should use the in-memory feature.
    - Use EntityFramework Core for database transaction.
    - Initialize database at the start of the app.
    - To-do item only contains `ID`, `Text` and `IsCompleted` columns.
    - To-do list management has 5 features - create, list, update, complete and delete.
    - If necessary, add NuGet packages that are compatible with .NET 9.
    - DO NOT implement API endpoints for the to-do list management.
    - DO NOT add any initial data.
    - DO NOT refer to the `complete` directory.
    - DO NOT refer to the `start` directory.
    ```

1. Click the ![the keep button image](https://img.shields.io/badge/keep-blue) button of GitHub Copilot to take the changes.
1. Use the prompt like below to verify the development result.

    ```text
    I'd like to build the app. Follow the instructions.

    - Use context7.
    - Build the app and verify if the app is built properly.
    - If building the app fails, analyze the issues and fix them.
    ```

   > **NOTE**:
   >
   > - Until the build succeeds, iterate this step.
   > - If the build keeps failing, check out the error messages and ask them to GitHub Copilot Agent to figure them out.

1. Click the ![the keep button image](https://img.shields.io/badge/keep-blue) button of GitHub Copilot to take the changes.
1. Use the prompt like below to verify the development result.

    ```text
    I'd like to add `TodoTool` class to the app. Follow the instructions.

    - Use context7.
    - Identify all the steps first, which you're going to do.
    - Your working directory is `workshop/src/McpTodoServer.ContainerApp`.
    - The `TodoTool` class should contain 5 methods - create, list, update, complete and delete.
    - DO NOT register dependency.
    ```

## Remove API Logic

1. Make sure you've got the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navigate to the app project.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Open `Program.cs` and remove all the followings:

   ```csharp
   // 👇👇👇 Remove 👇👇👇
   // Add services to the container.
   // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
   builder.Services.AddOpenApi();
   // 👆👆👆 Remove 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remove 👇👇👇
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.MapOpenApi();
   }
   // 👆👆👆 Remove 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remove 👇👇👇
   var summaries = new[]
   {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   };
   // 👆👆👆 Remove 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remove 👇👇👇
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
   // 👆👆👆 Remove 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remove 👇👇👇
   record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
   // 👆👆👆 Remove 👆👆👆
   ```

1. Remove NuGet package.

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```

## Convert to MCP Server

1. Add NuGet package for the MCP server.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Open `Program.cs`, find `var app = builder.Build();` and add the following code snippet just above the line:

    ```csharp
    // 👇👇👇 Add 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 Add 👆👆👆
    
    var app = builder.Build();
    ```

1. In the same `Program.cs`, find `app.Run();` and add the following code snippet just above the line:

    ```csharp
    // 👇👇👇 Add 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 Add 👆👆👆
    
    app.Run();
    ```

1. Open `TodoTool.cs` and add decorators like below.

   > **NOTE**: The method names might be different depending on how GitHub Copilot generates them.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    [McpServerToolType]
    // 👆👆👆 Add 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 Add 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 Add 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 Add 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 Add 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 Add 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 Add 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 Add 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 Add 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 Add 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 Add 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. In the same `TodoTool.cs`, add extra `using` directives:

   > **NOTE**: The namespace might be different depending on how GitHub Copilot generates them.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 Add 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. Build the app.

    ```bash
    dotnet build
    ```

## Run MCP Server

1. Make sure you've got the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navigate to the app project.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Run the MCP server app.

    ```bash
    dotnet run
    ```

1. Open Command Palette by typing `F1` or `Ctrl`+`Shift`+`P` on Windows or `Cmd`+`Shift`+`P` on Mac OS, and search `MCP: Add Server...`.
1. Choose `HTTP (HTTP or Server-Sent Events)`.
1. Enter `http://localhost:5242` as the server URL.
1. Enter `mcp-todo-list` as server ID.
1. Choose `Workspace settings` as the location to save the MCP settings.
1. Open `.vscode/mcp.json` and see the MCP server added.

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
        // 👇👇👇 Added 👇👇👇
        "mcp-todo-list": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 Added 👆👆👆
      }
    }
    ```

## Test MCP Server

1. Open GitHub Copilot Chat as Agent Mode.
1. Enter one of the prompts below:

    ```text
    Show me the to-do list.
    Add "lunch at 12pm".
    Mark lunch as completed.
    Add "meeting at 3pm".
    Change the meeting to 3:30pm.
    Cancel the meeting.
    ```

1. If an error occurs, ask GitHub Copilot to fix it:

    ```text
    I got an error "xxx". Please find the issue and fix it.
    ```

---

OK. You've completed the "MCP Server Development" step. Let's move onto [STEP 02: MCP Remote Server](./02-mcp-remote-server.md).
