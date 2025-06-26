# 00: Ambiente de Desenvolvimento

Neste passo, você está configurando o ambiente de desenvolvimento para o workshop.

## Pré-requisitos

Consulte o documento [README](../README.md#prerequisites) para preparação.

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

1. Vá para a seção [Configurar Servidores MCP](#configurar-servidores-mcp).

**👇👇👇 Se você preferir usar VS Code em sua máquina local, siga as instruções abaixo. A seção abaixo não se aplica àqueles que usam GitHub Codespaces. 👇👇👇**

## Usar Visual Studio Code

### Instalar PowerShell 👉 Para Usuários Windows

Se você estiver usando Windows, precisará instalar o PowerShell. Se já tiver o PowerShell instalado, pode pular esta etapa.

1. Vá ao [site oficial do PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) e instale a versão mais recente.

### Instalar git CLI

Se já tiver o git CLI instalado, pode pular esta etapa.

1. Vá ao [site oficial do git](https://git-scm.com/downloads) e instale a versão mais recente.

### Instalar GitHub CLI

Se já tiver o GitHub CLI instalado, pode pular esta etapa.

1. Vá ao [site oficial do GitHub CLI](https://cli.github.com/) e instale a versão mais recente.

### Instalar Docker Desktop

Se já tiver o Docker Desktop instalado, pode pular esta etapa.

1. Vá ao [site oficial do Docker Desktop](https://docs.docker.com/get-started/get-docker/) e instale a versão mais recente.

### Instalar Visual Studio Code

Se já tiver o Visual Studio Code instalado, pode pular esta etapa.

1. Vá ao [site oficial do Visual Studio Code](https://code.visualstudio.com/) e instale a versão mais recente.

### Iniciar Visual Studio Code

1. Abra um terminal e execute o seguinte comando para clonar este repositório:

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. Navegue para o diretório do repositório:

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Abra o Visual Studio Code:

    ```bash
    code .
    ```

## Configurar Servidores MCP

Nesta seção, você está configurando os servidores MCP para o workshop.

1. Instale as extensões necessárias do Visual Studio Code. Abra o Visual Studio Code e vá para a visualização de Extensões (`Ctrl+Shift+X` ou `Cmd+Shift+X`).

1. Pesquise e instale as seguintes extensões:
   - **C# Dev Kit** - Para desenvolvimento .NET
   - **GitHub Copilot** - Para assistência de IA

1. Após a instalação, reinicie o Visual Studio Code.

1. Instale os pacotes npm necessários executando o seguinte comando no terminal:

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## Verificar Modo Agente GitHub Copilot

1. Clique no ícone do GitHub Copilot no topo do GitHub Codespace ou VS Code e abra a janela do GitHub Copilot.

   ![Open GitHub Copilot Chat](./images/setup-02.png)

1. Se for solicitado para fazer login ou se inscrever, faça-o. É gratuito.
1. Certifique-se de estar usando o Modo Agente do GitHub Copilot.

   ![GitHub Copilot Agent Mode](./images/setup-03.png)

1. Selecione o modelo como `GPT-4.1` ou `Claude Sonnet 4`.

---

Ótimo. Você completou a etapa "Ambiente de Desenvolvimento". Agora vamos para o [PASSO 01: Servidor MCP](./01-mcp-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../issues).