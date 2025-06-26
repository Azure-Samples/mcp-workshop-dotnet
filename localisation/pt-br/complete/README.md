# Servidor MCP: Aplicação de Tarefas

Este é um servidor MCP, hospedado no [Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview), que gerencia itens de lista de tarefas.

## Pré-requisitos

- [SDK do .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) com
  - Extensão [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## Começando

- [Executar servidor MCP ASP.NET Core localmente](#executar-servidor-mcp-aspnet-core-localmente)
- [Executar servidor MCP ASP.NET Core localmente em um contêiner](#executar-servidor-mcp-aspnet-core-localmente-em-um-contêiner)
- [Executar servidor MCP ASP.NET Core remotamente](#executar-servidor-mcp-aspnet-core-remotamente)
- [Conectar servidor MCP a um host/cliente MCP](#conectar-servidor-mcp-a-um-hostcliente-mcp)
  - [VS Code + Modo Agente + Servidor MCP local](#vs-code--modo-agente--servidor-mcp-local)
  - [VS Code + Modo Agente + Servidor MCP local em contêiner](#vs-code--modo-agente--servidor-mcp-local-em-contêiner)
  - [VS Code + Modo Agente + Servidor MCP remoto](#vs-code--modo-agente--servidor-mcp-remoto)
  - [MCP Inspector + Servidor MCP local](#mcp-inspector--servidor-mcp-local)
  - [MCP Inspector + Servidor MCP local em contêiner](#mcp-inspector--servidor-mcp-local-em-contêiner)
  - [MCP Inspector + Servidor MCP remoto](#mcp-inspector--servidor-mcp-remoto)

### Executar servidor MCP ASP.NET Core localmente

1. Obter a raiz do repositório.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Executar a aplicação servidor MCP.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### Executar servidor MCP ASP.NET Core localmente em um contêiner

1. Obter a raiz do repositório.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Construir a aplicação servidor MCP como uma imagem de contêiner.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. Executar a aplicação servidor MCP em um contêiner

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### Executar servidor MCP ASP.NET Core remotamente

1. Fazer login no Azure

    ```bash
    # Fazer login com Azure Developer CLI
    azd auth login
    ```

1. Implantar a aplicação servidor MCP no Azure

    ```bash
    azd up
    ```

   Durante o provisionamento e implantação, você será solicitado a fornecer ID da assinatura, localização, nome do ambiente.

1. Após a conclusão da implantação, obtenha as informações executando os seguintes comandos:

   - FQDN do Azure Container Apps:

     ```bash
     azd env get-value AZURE_RESOURCE_MCP_TODO_LIST_FQDN
     ```

### Conectar servidor MCP a um host/cliente MCP

#### VS Code + Modo Agente + Servidor MCP local

1. Obter a raiz do repositório.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copiar `mcp.json` para a raiz do repositório.

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

1. Abrir a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e pesquisar `MCP: List Servers`.
1. Escolher `mcp-todo-list-aca-local` e depois clicar em `Start Server`.
1. Inserir prompts. Estes são apenas exemplos:

    ```text
    - Mostre-me a lista de tarefas
    - Adicionar "reunião às 11h"
    - Completar o item de tarefa #1
    - Excluir o item de tarefa #2
    ```

1. Confirmar o resultado.

#### VS Code + Modo Agente + Servidor MCP local em contêiner

1. Obter a raiz do repositório.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copiar `mcp.json` para a raiz do repositório.

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

1. Abrir a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e pesquisar `MCP: List Servers`.
1. Escolher `mcp-todo-list-aca-container` e depois clicar em `Start Server`.
1. Inserir prompts. Estes são apenas exemplos:

    ```text
    - Mostre-me a lista de tarefas
    - Adicionar "reunião às 11h"
    - Completar o item de tarefa #1
    - Excluir o item de tarefa #2
    ```

1. Confirmar o resultado.

#### VS Code + Modo Agente + Servidor MCP remoto

1. Abrir a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e pesquisar `MCP: List Servers`.
1. Escolher `mcp-todo-list-aca-remote` e depois clicar em `Start Server`.
1. Inserir o FQDN do Azure Container Apps.
1. Inserir prompts. Estes são apenas exemplos:

    ```text
    - Mostre-me a lista de tarefas
    - Adicionar "reunião às 11h"
    - Completar o item de tarefa #1
    - Excluir o item de tarefa #2
    ```

1. Confirmar o resultado.

#### MCP Inspector + Servidor MCP local

1. Executar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir um navegador web e navegar para a aplicação web MCP Inspector a partir da URL exibida pela aplicação (ex. http://localhost:6274)
1. Definir o tipo de transporte como `Streamable HTTP` 
1. Definir a URL para o endpoint Streamable HTTP da sua aplicação Function em execução e **Conectar**:

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. Clicar em **List Tools**.
1. Clicar em uma ferramenta e **Run Tool** com valores apropriados.

#### MCP Inspector + Servidor MCP local em contêiner

1. Executar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir um navegador web e navegar para a aplicação web MCP Inspector a partir da URL exibida pela aplicação (ex. http://localhost:6274)
1. Definir o tipo de transporte como `Streamable HTTP` 
1. Definir a URL para o endpoint Streamable HTTP da sua aplicação Function em execução e **Conectar**:

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. Clicar em **List Tools**.
1. Clicar em uma ferramenta e **Run Tool** com valores apropriados.

#### MCP Inspector + Servidor MCP remoto

1. Executar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir um navegador web e navegar para a aplicação web MCP Inspector a partir da URL exibida pela aplicação (ex. http://0.0.0.0:6274)
1. Definir o tipo de transporte como `Streamable HTTP` 
1. Definir a URL para o endpoint Streamable HTTP da sua aplicação Function em execução e **Conectar**:

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. Clicar em **List Tools**.
1. Clicar em uma ferramenta e **Run Tool** com valores apropriados.

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../issues).