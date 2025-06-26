# MCP 服务器：待办事项应用

这是一个托管在 [Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview) 上的 MCP 服务器，用于管理待办事项列表项目。

## 先决条件

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) 及
  - [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit) 扩展
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## 开始使用

- [在本地运行 ASP.NET Core MCP 服务器](#在本地运行-aspnet-core-mcp-服务器)
- [在容器中本地运行 ASP.NET Core MCP 服务器](#在容器中本地运行-aspnet-core-mcp-服务器)
- [远程运行 ASP.NET Core MCP 服务器](#远程运行-aspnet-core-mcp-服务器)
- [将 MCP 服务器连接到 MCP 主机/客户端](#将-mcp-服务器连接到-mcp-主机客户端)
  - [VS Code + 代理模式 + 本地 MCP 服务器](#vs-code--代理模式--本地-mcp-服务器)
  - [VS Code + 代理模式 + 容器中的本地 MCP 服务器](#vs-code--代理模式--容器中的本地-mcp-服务器)
  - [VS Code + 代理模式 + 远程 MCP 服务器](#vs-code--代理模式--远程-mcp-服务器)
  - [MCP Inspector + 本地 MCP 服务器](#mcp-inspector--本地-mcp-服务器)
  - [MCP Inspector + 容器中的本地 MCP 服务器](#mcp-inspector--容器中的本地-mcp-服务器)
  - [MCP Inspector + 远程 MCP 服务器](#mcp-inspector--远程-mcp-服务器)

### 在本地运行 ASP.NET Core MCP 服务器

1. 获取存储库根目录。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. 运行 MCP 服务器应用。

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### 在容器中本地运行 ASP.NET Core MCP 服务器

1. 获取存储库根目录。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. 将 MCP 服务器应用构建为容器镜像。

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. 在容器中运行 MCP 服务器应用

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### 远程运行 ASP.NET Core MCP 服务器

1. 登录到 Azure

    ```bash
    # 使用 Azure Developer CLI 登录
    azd auth login
    ```

1. 将 MCP 服务器应用部署到 Azure

    ```bash
    azd up
    ```

   在配置和部署过程中，系统会要求您提供订阅 ID、位置和环境名称。

1. 部署完成后，运行以下命令获取信息：

   - Azure Container Apps FQDN:

     ```bash
     azd env get-value AZURE_RESOURCE_MCP_TODO_LIST_FQDN
     ```

### 将 MCP 服务器连接到 MCP 主机/客户端

#### VS Code + 代理模式 + 本地 MCP 服务器

1. 获取存储库根目录。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. 将 `mcp.json` 复制到存储库根目录。

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. 通过按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P`，在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 选择 `mcp-todo-list-aca-local`，然后点击 `Start Server`。
1. 输入提示。以下是一些示例：

    ```text
    - 显示待办事项列表
    - 添加"上午11点开会"
    - 完成待办事项 #1
    - 删除待办事项 #2
    ```

1. 确认结果。

#### VS Code + 代理模式 + 容器中的本地 MCP 服务器

1. 获取存储库根目录。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. 将 `mcp.json` 复制到存储库根目录。

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. 通过按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P`，在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 选择 `mcp-todo-list-aca-container`，然后点击 `Start Server`。
1. 输入提示。以下是一些示例：

    ```text
    - 显示待办事项列表
    - 添加"上午11点开会"
    - 完成待办事项 #1
    - 删除待办事项 #2
    ```

1. 确认结果。

#### VS Code + 代理模式 + 远程 MCP 服务器

1. 通过按 `F1` 或在 Windows 上按 `Ctrl`+`Shift`+`P`，在 Mac OS 上按 `Cmd`+`Shift`+`P` 打开命令面板，并搜索 `MCP: List Servers`。
1. 选择 `mcp-todo-list-aca-remote`，然后点击 `Start Server`。
1. 输入 Azure Container Apps FQDN。
1. 输入提示。以下是一些示例：

    ```text
    - 显示待办事项列表
    - 添加"上午11点开会"
    - 完成待办事项 #1
    - 删除待办事项 #2
    ```

1. 确认结果。

#### MCP Inspector + 本地 MCP 服务器

1. 运行 MCP Inspector。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 打开网络浏览器并从应用程序显示的 URL 导航到 MCP Inspector 网络应用（例如 http://localhost:6274）
1. 将传输类型设置为 `Streamable HTTP`
1. 将 URL 设置为您正在运行的 Function 应用的 Streamable HTTP 端点并**连接**：

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. 点击 **List Tools**。
1. 点击一个工具并使用适当的值 **Run Tool**。

#### MCP Inspector + 容器中的本地 MCP 服务器

1. 运行 MCP Inspector。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 打开网络浏览器并从应用程序显示的 URL 导航到 MCP Inspector 网络应用（例如 http://localhost:6274）
1. 将传输类型设置为 `Streamable HTTP`
1. 将 URL 设置为您正在运行的 Function 应用的 Streamable HTTP 端点并**连接**：

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. 点击 **List Tools**。
1. 点击一个工具并使用适当的值 **Run Tool**。

#### MCP Inspector + 远程 MCP 服务器

1. 运行 MCP Inspector。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 打开网络浏览器并从应用程序显示的 URL 导航到 MCP Inspector 网络应用（例如 http://0.0.0.0:6274）
1. 将传输类型设置为 `Streamable HTTP`
1. 将 URL 设置为您正在运行的 Function 应用的 Streamable HTTP 端点并**连接**：

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. 点击 **List Tools**。
1. 点击一个工具并使用适当的值 **Run Tool**。

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../../issues)。