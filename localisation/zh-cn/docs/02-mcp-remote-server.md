# 02: MCP 远程服务器

在这一步中，您正在将 MCP 服务器部署到 Azure。

## 先决条件

请参考 [README](../README.md#先决条件) 文档进行准备。

## 开始使用

- [使用 `Dockerfile` 容器化 MCP 服务器](#使用-dockerfile-容器化-mcp-服务器)
- [使用 `azd` 将 MCP 服务器部署到 Azure](#使用-azd-将-mcp-服务器部署到-azure)

## 使用 `Dockerfile` 容器化 MCP 服务器

在[上一节](./01-mcp-server.md)中，您已经创建了一个 MCP 服务器应用程序。让我们继续使用它。

1. 确保 Docker Desktop 已启动并运行。
1. 确保您已设置环境变量 `$REPOSITORY_ROOT`。

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
    cd $REPOSITORY_ROOT/workshop
    ```

1. 创建 `Dockerfile`。

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. 打开 `Dockerfile`，添加下面的代码行，并保存。

    ```dockerfile
    # syntax=docker/dockerfile:1
    
    FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
    
    COPY . /source
    
    WORKDIR /source/src/McpTodoServer.ContainerApp
    
    RUN dotnet publish -c Release -o /app
    
    FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
    
    WORKDIR /app
    
    COPY --from=build /app .
    
    USER $APP_UID
    
    ENTRYPOINT ["dotnet", "McpTodoServer.ContainerApp.dll"]
    ```

1. 构建容器镜像。

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. 运行容器镜像。

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. 打开 `.vscode/mcp.json` 并将 MCP 服务器 URL 替换为容器化的 MCP 服务器。

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
        "mcp-todo": {
          // 之前
          "url": "http://localhost:5242/mcp"

          // 之后
          "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 添加 👆👆👆
      }
    }
    ```

1. 启动 MCP 服务器 `mcp-todo`，并按照[此文档](./01-mcp-server.md#测试-mcp-服务器)进行测试。
1. 测试完成后，停止容器并删除它。

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## 使用 `azd` 将 MCP 服务器部署到 Azure

1. 确保您已登录 Azure。

    ```bash
    azd auth login --check-status
    ```

   如果您尚未登录，请使用您的 Azure 账户运行 `azd auth login`。

1. 确保您已设置环境变量 `$REPOSITORY_ROOT`。

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
    cd $REPOSITORY_ROOT/workshop
    ```

1. 初始化 `azd` 模板。

    ```bash
    azd init
    ```

   它会询问几个问题。请按照以下选项选择：

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   然后，它会创建 `azure.yaml` 文件。

1. 打开 `azure.yaml` 文件并用以下代码行更新它。

    ```yml
    # yaml-language-server: $schema=https://raw.githubusercontent.com/Azure/azure-dev/main/schemas/v1.0/azure.yaml.json
    
    name: workshop
    metadata:
        template: azd-init@1.17.2
    services:
        mcptodoserver-containerapp:
            project: src/McpTodoServer.ContainerApp
            host: containerapp
            language: dotnet

            # 👇👇👇 添加 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 添加 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. 部署 MCP 服务器。

    ```bash
    azd up
    ```

   它会询问几个问题：

   - `? Enter a unique environment name` 👉 输入任何名称。例如，`mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 选择要使用的 Azure 订阅。
   - `? Enter a value for the 'location' infrastructure parameter` 👉 选择要部署 MCP 服务器的位置。

1. 完成后，您可以在终端中找到 MCP 服务器 URL，它看起来像 `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`。记下这个 URL。
1. 打开 `.vscode/mcp.json` 并将 MCP 服务器 URL 替换为已部署的 MCP 服务器。`{{azure-container-apps-url}}` 应该替换为从上一步获取的 URL。

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
        "mcp-todo": {
          // 之前
          "url": "http://localhost:8080/mcp"

          // 之后
          "url": "http://{{azure-container-apps-url}}/mcp"
        }
      }
    }
    ```

1. 启动 MCP 服务器 `mcp-todo`，并按照[此文档](./01-mcp-server.md#测试-mcp-服务器)进行测试。

---

很好。您已完成"MCP 远程服务器部署"步骤。让我们继续进行 [步骤 03: MCP 客户端](./03-mcp-client.md)。

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../../issues)。
