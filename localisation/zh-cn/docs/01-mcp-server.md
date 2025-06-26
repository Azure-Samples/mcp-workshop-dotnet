# 01: MCP 服务器

在这一步中，您正在构建用于待办事项列表管理的 MCP 服务器。

## 先决条件

请参考 [README](../README.md#prerequisites) 文档进行准备。

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

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-01.png)

1. 选择模型为 `GPT-4.1` 或 `Claude Sonnet 4`。
1. 确保您已配置 [MCP 服务器](./00-setup.md#set-up-mcp-servers)。

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
    cp -r $REPOSITORY_ROOT/docs/.github/. \
          $REPOSITORY_ROOT/.github/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/* `
              -Destination $REPOSITORY_ROOT/.github/ -Recurse -Force
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
1. 确保 `context7` MCP 服务器正在运行。
1. 使用如下提示来实现待办事项列表管理逻辑。

    ```text
    我想使用 ASP.NET Core 开发一个待办事项列表应用程序。按照指示操作。

    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - 应用程序应包含任务管理模型，具有以下属性：ID、标题、描述、完成状态、创建日期和更新日期。
    - 如有必要，添加与 .NET 9 兼容的 NuGet 包。
    - 不要为待办事项列表管理实现 API 端点。
    - 不要添加初始数据。
    - 不要引用 `complete` 目录。
    - 不要引用 `start` 目录。
    ```

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。

1. 使用如下提示来添加 TodoTool 类。

    ```text
    我想向应用程序添加 `TodoTool` 类。按照指示操作。

    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - `TodoTool` 类应包含 5 个方法 - 创建、列表、更新、完成和删除。
    - 不要注册依赖项。
    ```

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。

1. 使用如下提示来构建应用程序。

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

## 删除 API 逻辑

1. 以代理模式打开 GitHub Copilot Chat。
1. 使用如下提示来删除 API 逻辑。

    ```text
    我想从应用程序中删除所有 API 逻辑。按照指示操作。

    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - 删除所有 API 端点但保留模型和工具类。
    - 确保在删除 API 逻辑后应用程序仍能构建。
    ```

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。

## 转换为 MCP 服务器

1. 以代理模式打开 GitHub Copilot Chat。
1. 使用如下提示将应用程序转换为 MCP 服务器。

    ```text
    我想将此应用程序转换为 MCP 服务器。按照指示操作。

    - 使用 context7。
    - 首先识别您要执行的所有步骤。
    - 您的工作目录是 `workshop/src/McpTodoServer.ContainerApp`。
    - 添加 MCP 所需的 NuGet 包。
    - 实现可以处理待办事项列表管理请求的 MCP 服务器。
    - 方法应包括：列出任务、创建任务、更新任务、完成任务和删除任务。
    - 确保转换后应用程序能够构建。
    ```

1. 点击 GitHub Copilot 的 ![the keep button image](https://img.shields.io/badge/keep-blue) 按钮来应用更改。

## 运行 MCP 服务器

1. 打开终端并导航到应用程序目录。

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. 运行应用程序。

    ```bash
    dotnet run
    ```

   您应该看到类似以下的输出：

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
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