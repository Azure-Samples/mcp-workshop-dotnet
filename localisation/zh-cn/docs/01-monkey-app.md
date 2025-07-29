# 01: 使用 MCP 开发 Monkey 应用

在这一步中，您将使用 MCP 服务器构建一个简单的控制台应用程序。

## 先决条件

请参考 [README](../README.md#先决条件) 文档进行准备。

## 开始

- [检查 GitHub Copilot 代理模式](#检查-github-copilot-代理模式)
- [准备自定义指令](#准备自定义指令)
- [准备 MCP 服务器开发](#准备-mcp-服务器开发)
- [开发待办事项列表管理逻辑](#开发待办事项列表管理逻辑)
- [删除 API 逻辑](#删除-api-逻辑)
- [转换为 MCP 服务器](#转换为-mcp-服务器)
- [运行 MCP 服务器](#运行-mcp-服务器)
- [测试 MCP 服务器](#测试-mcp-服务器)

## 检查 GitHub Copilot 代理模式

1. 单击 GitHub Codespace 或 VS Code 顶部的 GitHub Copilot 图标并打开 GitHub Copilot 窗口。

   ![打开 GitHub Copilot 聊天](../../../docs/images/setup-01.png)

1. 如果要求您登录或注册，请执行此操作。这是免费的。
1. 确保您正在使用 GitHub Copilot 代理模式。

   ![GitHub Copilot 代理模式](../../../docs/images/setup-02.png)

1. 将模型选择为 `GPT-4.1` 或 `Claude Sonnet 4`。
1. 确保您已配置 [MCP 服务器](./00-setup.md#设置-mcp-服务器)。

## 启动 MCP 服务器 &ndash; GitHub

1. 通过按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P` 或在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 选择 `github` 然后单击 `Start Server`。您可能会被要求登录到 GitHub 以使用此 MCP 服务器。

## 准备自定义指令

1. 设置 `$REPOSITORY_ROOT` 环境变量。

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
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. 打开 `.github/copilot-instructions.md` 并将 `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME` 替换为您的。例如，`https://github.com/octocat/monkey-app`。

## 创建控制台应用程序

1. 在 `workshop` 目录下创建控制台应用程序。

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

## 管理 GitHub 存储库

1. 向 GitHub Copilot 输入以下提示以推送创建的控制台应用程序。

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. 向 GitHub Copilot 输入以下提示以在存储库上生成问题。

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. 将 `@Copilot` 分配给问题并观察发生的情况。

## 启动 MCP 服务器 &ndash; Monkey MCP

1. 通过按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P` 或在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 确保 `github` MCP 服务器正在运行。
1. 选择 `monkeymcp` 然后单击 `Start Server`。

## 使用 GitHub Copilot 和 MCP 服务器开发 Monkey 应用

1. 输入以下提示以获取猴子列表。

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. 输入以下提示以获得猴子数据模型的想法。

    ```text
    What would a data model look like for this structure?
    ```

1. 输入以下提示为数据模型类创建文件。

    ```text
    Let's create a new file for this class.
    ```

1. 输入以下提示创建 `MonkeyHelper` 类。

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. 输入以下提示更新控制台应用程序。

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. 向 GitHub Copilot 输入以下提示以推送更新的控制台应用程序。

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK. 您已经完成了"使用 MCP 开发 Monkey 应用"步骤。让我们继续进行 [步骤 02：MCP 服务器](./02-mcp-server.md)。

---

**免责声明**：本文档由 GitHub Copilot 进行本地化，可能包含错误或不准确之处。如果您发现任何问题，请通过 [GitHub Issues](https://github.com/Azure-Samples/mcp-workshop-dotnet/issues) 提供反馈。