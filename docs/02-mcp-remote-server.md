# 02: MCP Remote Server

In this step, you're deploying the MCP server to Azure.

## Prerequisites

Refer to the [README](../README.md#prerequisites) doc for preparation.

## Getting Started

- [Containerize MCP Server with `Dockerfile`](#containerize-mcp-server-with-dockerfile)
- [Deploy MCP Server to Azure with `azd`](#deploy-mcp-server-to-azure-with-azd)

## Containerize MCP Server with `Dockerfile`

In the [previous session](./01-mcp-server.md), you've already created an MCP server app. Let's keep using it.

1. Make sure Docker Desktop is up and running.
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
    cd $REPOSITORY_ROOT/workshop
    ```

1. Create a `Dockerfile`.

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. Open `Dockerfile`, add the code lines below, and save it.

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

1. Build a container image.

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. Run the container image.

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. Open `.vscode/mcp.json` and add the containerized MCP server.

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
        "mcp-todo-local": {
            "url": "http://localhost:5242/mcp"
        },
        // 👇👇👇 Add 👇👇👇
        "mcp-todo-http": {
            "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 Add 👆👆👆
      }
    }
    ```

1. Start the MCP server, `mcp-todo-http`, and test it by following [this document](./01-mcp-server.md#test-mcp-server).
1. Once the test is over, stop the container and remove it.

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## Deploy MCP Server to Azure with `azd`

1. Make sure you've got Azure logged in.

    ```bash
    azd auth login --check-status
    ```

   If you haven't logged in yet, run `azd auth login` with your Azure account.

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
    cd $REPOSITORY_ROOT/workshop
    ```

1. Initialize `azd` template.

    ```bash
    azd init
    ```

   It asks several questions. Select the options following:

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   Then, it creates `azure.yaml` file.

1. Open `azure.yaml` file and update it with the following code lines.

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

            # 👇👇👇 Add 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 Add 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. Deploy the MCP server.

    ```bash
    azd up
    ```

   It asks several questions:

   - `? Enter a unique environment name` 👉 Enter any name. For example, `mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 Choose your Azure subscription to use.
   - `? Enter a value for the 'location' infrastructure parameter` 👉 Choose location for the MCP server to be deployed.

1. Once completed, you can find the MCP server URL in the terminal, which looks like `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`. Take note this URL.
1. Open `.vscode/mcp.json` and add the deployed MCP server. `{{azure-container-apps-url}}` should be replaced with the URL taken from the previous step.

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
        "mcp-todo-local": {
            "url": "http://localhost:5242/mcp"
        },
        "mcp-todo-http": {
            "url": "http://localhost:8080/mcp"
        },
        // 👇👇👇 Add 👇👇👇
        "mcp-todo-remote": {
            "url": "http://{{azure-container-apps-url}}/mcp"
        }
        // 👆👆👆 Add 👆👆👆
      }
    }
    ```

1. Start the MCP server, `mcp-todo-remote`, and test it by following [this document](./01-mcp-server.md#test-mcp-server).

---

OK. You've completed the "MCP Remote Server Deployment" step. Let's move onto [STEP 03: MCP Client](./03-mcp-client.md).
