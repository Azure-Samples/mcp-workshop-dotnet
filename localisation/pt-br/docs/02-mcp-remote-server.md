# 02: Servidor MCP Remoto

Neste passo, você está implantando o servidor MCP no Azure.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Containerizar Servidor MCP com `Dockerfile`](#containerizar-servidor-mcp-com-dockerfile)
- [Implantar Servidor MCP no Azure com `azd`](#implantar-servidor-mcp-no-azure-com-azd)

## Containerizar Servidor MCP com `Dockerfile`

Na [sessão anterior](./01-mcp-server.md), você já criou um aplicativo servidor MCP. Vamos continuar usando-o.

1. Certifique-se de que o Docker Desktop esteja funcionando.
1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navegue até o projeto do aplicativo.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Crie um `Dockerfile`.

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. Abra o `Dockerfile`, adicione as linhas de código abaixo e salve-o.

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

1. Construa uma imagem de contêiner.

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. Execute a imagem do contêiner.

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. Abra `.vscode/mcp.json` e adicione o servidor MCP containerizado.

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
        // 👇👇👇 Adicionar 👇👇👇
        "mcp-todo-http": {
            "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 Adicionar 👆👆👆
      }
    }
    ```

1. Inicie o servidor MCP, `mcp-todo-http`, e teste-o seguindo [este documento](./01-mcp-server.md#testar-servidor-mcp).
1. Uma vez que o teste esteja concluído, pare o contêiner e remova-o.

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## Implantar Servidor MCP no Azure com `azd`

1. Certifique-se de estar logado no Azure.

    ```bash
    azd auth login --check-status
    ```

   Se você ainda não fez login, execute `azd auth login` com sua conta Azure.

1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navegue até o projeto do aplicativo.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Inicialize o template `azd`.

    ```bash
    azd init
    ```

   Ele faz várias perguntas. Selecione as opções seguintes:

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   Em seguida, ele cria o arquivo `azure.yaml`.

1. Abra o arquivo `azure.yaml` e atualize-o com as seguintes linhas de código.

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

            # 👇👇👇 Adicionar 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 Adicionar 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. Implante o servidor MCP.

    ```bash
    azd up
    ```

   Ele faz várias perguntas:

   - `? Enter a unique environment name` 👉 Digite qualquer nome. Por exemplo, `mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 Escolha sua assinatura Azure para usar.
   - `? Enter a value for the 'location' infrastructure parameter` 👉 Escolha o local para implantar o servidor MCP.

1. Uma vez concluído, você pode encontrar a URL do servidor MCP no terminal, que se parece com `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`. Anote esta URL.
1. Abra `.vscode/mcp.json` e adicione o servidor MCP implantado. `{{azure-container-apps-url}}` deve ser substituído pela URL obtida no passo anterior.

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
        // 👇👇👇 Adicionar 👇👇👇
        "mcp-todo-remote": {
            "url": "http://{{azure-container-apps-url}}/mcp"
        }
        // 👆👆👆 Adicionar 👆👆👆
      }
    }
    ```

1. Inicie o servidor MCP, `mcp-todo-remote`, e teste-o seguindo [este documento](./01-mcp-server.md#testar-servidor-mcp).

---

Ótimo. Você completou a etapa "Implantação do Servidor MCP Remoto". Agora vamos para o [PASSO 03: Cliente MCP](./03-mcp-client.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../../../../issues).
