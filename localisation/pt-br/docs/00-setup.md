# 00: Ambiente de Desenvolvimento

Neste passo, você está configurando o ambiente de desenvolvimento para o workshop.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Usar GitHub Codespaces](#usar-github-codespaces)
- [Usar Visual Studio Code](#usar-visual-studio-code)
  - [Instalar PowerShell 👉 Para Usuários Windows](#instalar-powershell--para-usuários-windows)
  - [Instalar git CLI](#instalar-git-cli)
  - [Instalar GitHub CLI](#instalar-github-cli)
  - [Instalar Docker Desktop](#instalar-docker-desktop)
  - [Instalar Visual Studio Code](#instalar-visual-studio-code)
  - [Iniciar Visual Studio Code](#iniciar-visual-studio-code)
- [Configurar Servidores MCP](#configurar-servidores-mcp)
- [Verificar Modo Agente GitHub Copilot](#verificar-modo-agente-github-copilot)

## Usar GitHub Codespaces

1. Clique neste link 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. Uma vez que a instância do GitHub Codespace esteja pronta, abra um terminal e execute os seguintes comandos para verificar se tudo que você precisa foi instalado corretamente.

    ```bash
    # Node.js
    node --version
    npm --version
    ```

    ```bash
    # .NET SDK
    dotnet --list-sdks
    ```

    ```bash
    # PowerShell
    pwsh --version
    ```

1. Verifique o status do seu repositório.

    ```bash
    git remote -v
    ```

   Você deve ver a seguinte saída:

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   Se você ver algo diferente do acima, exclua a instância do GitHub Codespace e recrie-a.

1. Execute o seguinte comando para fazer fork deste repositório para sua conta do GitHub.

    ```bash
    git remote -v > remote.txt
    git add . && git commit -m "Add remote.txt for forking"
    ```

   Você pode ver uma mensagem como abaixo:

    ```text
    You don't have write access to the Azure-Samples/mcp-workshop-dotnet repository, so you cannot push changes to it.
    To obtain write access we will point this codespace at your fork of Azure-Samples/mcp-workshop-dotnet, creating that fork if it doesn't exist.

    Would you like to proceed?
    ```

   Digite `y`, e ele automaticamente fará fork deste repositório para sua conta do GitHub.

1. Verifique o repositório remoto novamente.

    ```bash
    git remote -v
    ```

   Você será capaz de ver tanto `origin` quanto `upstream`.

    ```text
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (push)
    ```

1. Vá para a seção [Configurar Servidores MCP](#configurar-servidores-mcp).

**👇👇👇 Se você preferir usar VS Code em sua máquina local, siga as instruções abaixo. A seção abaixo não se aplica àqueles que usam GitHub Codespaces. 👇👇👇**

## Usar Visual Studio Code

### Instalar PowerShell 👉 Para Usuários Windows

1. Verifique se você já instalou o PowerShell.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   Se você não vir o caminho do comando `pwsh`, isso significa que você ainda não instalou o PowerShell. Visite a [página de instalação do PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) e siga as instruções.

1. Verifique a versão do seu PowerShell.

    ```bash
    pwsh --version
    ```

   A versão `7.5.0` ou superior é recomendada. Se sua versão for inferior a essa, visite a [página de instalação do PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) e siga as instruções.

### Instalar node.js

1. Verifique se você já instalou o node.js.

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   Se você não vir o caminho do comando `node`, significa que ainda não instalou o node.js. Visite a [página de download do node.js](https://nodejs.org/en/download) e siga as instruções.

1. Verifique a versão do seu node.js.

    ```bash
    node --version
    ```

   A versão `22.17.x` (LTS mais recente) é recomendada. Se sua versão for inferior a essa, visite a [página de download do node.js](https://nodejs.org/en/download) e siga as instruções.

### Instalar git CLI

1. Verifique se você já instalou o git CLI.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   Se você não vir o caminho do comando `git`, isso significa que você ainda não instalou o git CLI. Visite a [página de instalação do git CLI](https://git-scm.com/downloads) e siga as instruções.

1. Verifique a versão do seu git CLI.

    ```bash
    git --version
    ```

   A versão `2.39.0` ou superior é recomendada. Se sua versão for inferior a essa, visite a [página de instalação do git CLI](https://git-scm.com/downloads) e siga as instruções.

### Instalar GitHub CLI

1. Verifique se você já instalou o GitHub CLI.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   Se você não vir o caminho do comando `gh`, isso significa que você ainda não instalou o GitHub CLI. Visite a [página de instalação do GitHub CLI](https://cli.github.com/) e siga as instruções.

1. Verifique a versão do seu GitHub CLI.

    ```bash
    gh --version
    ```

   A versão `2.65.0` ou superior é recomendada. Se sua versão for inferior a essa, visite a [página de instalação do GitHub CLI](https://cli.github.com/) e siga as instruções.

1. Verifique se você fez login no GitHub.

    ```bash
    gh auth status
    ```

   Se você ainda não fez login, execute `gh auth login` e faça login.

### Instalar Docker Desktop

1. Verifique se você já instalou o Docker Desktop.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   Se você não vir o caminho do comando `docker`, isso significa que você ainda não instalou o Docker Desktop. Visite a [página de instalação do Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) e siga as instruções.

1. Verifique a versão do seu Docker CLI.

    ```bash
    docker --version
    ```

   A versão `28.0.4` ou superior é recomendada. Se sua versão for inferior a essa, visite a [página de instalação do Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) e siga as instruções.

### Instalar Visual Studio Code

1. Verifique se você já instalou o VS Code.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   Se você não vir o caminho do comando `code`, isso significa que você ainda não instalou o VS Code. Visite a [página de instalação do Visual Studio Code](https://code.visualstudio.com/) e siga as instruções.

1. Verifique a versão do seu VS Code.

    ```bash
    code --version
    ```

   A versão `1.99.0` ou superior é recomendada. Se sua versão for inferior a essa, visite a [página de instalação do Visual Studio Code](https://code.visualstudio.com/) e siga as instruções.

   > **NOTA**: Você pode não conseguir executar o comando `code`. Neste caso, siga [este documento](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line) para configuração.

### Iniciar Visual Studio Code

1. Crie um diretório de trabalho.
1. Execute o comando para fazer fork deste repositório e cloná-lo para sua máquina local.

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. Navegue para o diretório clonado.

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Execute o VS Code a partir do terminal.

    ```bash
    code .
    ```

1. Abra um novo terminal dentro do VS Code e execute o seguinte comando para verificar o status do seu repositório.

    ```bash
    git remote -v
    ```

   Você deve ver a seguinte saída. Se você vir `Azure-Samples` no `origin`, deve clonar novamente do seu repositório bifurcado.

    ```bash
    origin  https://github.com/<seu ID do GitHub>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<seu ID do GitHub>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. Verifique se ambas as extensões foram instaladas: [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) e [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   Se você não vir nada, isso significa que você ainda não instalou essas extensões. Execute o seguinte comando para instalar as extensões.

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## Configurar Servidores MCP

1. Defina a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie as configurações do servidor MCP.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp -r $REPOSITORY_ROOT/docs/.vscode/. \
          $REPOSITORY_ROOT/.vscode/
    ```

    ```powershell
    # PowerShell
    New-Item -ItemType Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/* `
              -Destination $REPOSITORY_ROOT/.vscode/ -Recurse -Force
    ```

## Verificar Modo Agente GitHub Copilot

1. Clique no ícone do GitHub Copilot no topo do GitHub Codespace ou VS Code e abra a janela do GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Se for solicitado para fazer login ou se inscrever, faça-o. É gratuito.
1. Certifique-se de estar usando o Modo Agente do GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Selecione o modelo como `GPT-4.1` ou `Claude Sonnet 4`.

---

Ótimo. Você completou a etapa "Ambiente de Desenvolvimento". Agora vamos para o [PASSO 01: Servidor MCP](./01-mcp-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../../../../issues).