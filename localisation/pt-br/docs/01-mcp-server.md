# 01: Servidor MCP

Neste passo, você está construindo um servidor MCP para gerenciamento de lista de tarefas.

## Pré-requisitos

Consulte o documento [README](../README.md#prerequisites) para preparação.

## Começando

- [Verificar Modo Agente GitHub Copilot](#verificar-modo-agente-github-copilot)
- [Preparar Instruções Personalizadas](#preparar-instruções-personalizadas)
- [Preparar Desenvolvimento do Servidor MCP](#preparar-desenvolvimento-do-servidor-mcp)
- [Desenvolver Lógica de Gerenciamento de Lista de Tarefas](#desenvolver-lógica-de-gerenciamento-de-lista-de-tarefas)
- [Remover Lógica de API](#remover-lógica-de-api)
- [Converter para Servidor MCP](#converter-para-servidor-mcp)
- [Executar Servidor MCP](#executar-servidor-mcp)
- [Testar Servidor MCP](#testar-servidor-mcp)

## Verificar Modo Agente GitHub Copilot

1. Clique no ícone do GitHub Copilot no topo do GitHub Codespace ou VS Code e abra a janela do GitHub Copilot.

   ![Open GitHub Copilot Chat](./images/setup-01.png)

1. Se for solicitado para fazer login ou se inscrever, faça-o. É gratuito.
1. Certifique-se de estar usando o Modo Agente do GitHub Copilot.

   ![GitHub Copilot Agent Mode](./images/setup-02.png)

1. Selecione o modelo como `GPT-4.1` ou `Claude Sonnet 4`.
1. Certifique-se de ter configurado [Servidores MCP](./00-setup.md#set-up-mcp-servers).

## Preparar Instruções Personalizadas

1. Defina a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie as instruções personalizadas.

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

## Preparar Desenvolvimento do Servidor MCP

No diretório `start`, uma aplicação ASP.NET Core Minimal API já está estruturada. Você a usará como ponto de partida.

1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie a aplicação estruturada para `workshop` a partir de `start`.

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

## Desenvolver Lógica de Gerenciamento de Lista de Tarefas

1. Certifique-se de estar usando o Modo Agente do GitHub Copilot com o modelo `Claude Sonnet 4` ou `GPT-4.1`.
1. Certifique-se de que o servidor MCP `context7` esteja em execução.
1. Use o prompt como abaixo para implementar a lógica de gerenciamento de lista de tarefas.

    ```text
    Gostaria de desenvolver uma aplicação de lista de tarefas usando ASP.NET Core. Siga as instruções.

    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - A aplicação deve incluir modelos para gerenciamento de tarefas com as propriedades: ID, título, descrição, status completado, data de criação e data de atualização.
    - Se necessário, adicione pacotes NuGet compatíveis com .NET 9.
    - NÃO implemente endpoints de API para gerenciamento de lista de tarefas.
    - NÃO adicione dados iniciais.
    - NÃO referencie o diretório `complete`.
    - NÃO referencie o diretório `start`.
    ```

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.

1. Use o prompt como abaixo para adicionar a classe TodoTool.

    ```text
    Gostaria de adicionar a classe `TodoTool` à aplicação. Siga as instruções.

    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - A classe `TodoTool` deve conter 5 métodos - criar, listar, atualizar, completar e excluir.
    - NÃO registre dependência.
    ```

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.

1. Use o prompt como abaixo para construir a aplicação.

    ```text
    Gostaria de construir a aplicação. Siga as instruções.

    - Use context7.
    - Construa a aplicação e verifique se ela constrói corretamente.
    - Se a construção falhar, analise os problemas e corrija-os.
    ```

   > **NOTA**:
   >
   > - Até que a construção seja bem-sucedida, itere este passo.
   > - Se a construção continuar falhando, verifique as mensagens de erro e peça ao GitHub Copilot Agent para resolvê-los.

## Remover Lógica de API

1. Abra o GitHub Copilot Chat como Modo Agente.
1. Use o prompt como abaixo para remover a lógica de API.

    ```text
    Gostaria de remover toda a lógica de API da aplicação. Siga as instruções.

    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - Remova todos os endpoints de API mas mantenha os modelos e classes de ferramentas.
    - Certifique-se de que a aplicação ainda construa após remover a lógica de API.
    ```

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.

## Converter para Servidor MCP

1. Abra o GitHub Copilot Chat como Modo Agente.
1. Use o prompt como abaixo para converter a aplicação para um servidor MCP.

    ```text
    Gostaria de converter esta aplicação para um servidor MCP. Siga as instruções.

    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - Adicione os pacotes NuGet necessários para MCP.
    - Implemente o servidor MCP que pode lidar com solicitações de gerenciamento de lista de tarefas.
    - Os métodos devem incluir: listar tarefas, criar tarefa, atualizar tarefa, completar tarefa e excluir tarefa.
    - Certifique-se de que a aplicação construa após a conversão.
    ```

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.

## Executar Servidor MCP

1. Abra um terminal e navegue para o diretório da aplicação.

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. Execute a aplicação.

    ```bash
    dotnet run
    ```

   Você deve ver uma saída similar à seguinte:

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    ```

## Testar Servidor MCP

1. Abra o GitHub Copilot Chat como Modo Agente.
1. Digite um dos prompts abaixo:

    ```text
    Mostre-me a lista de tarefas.
    Adicionar "almoço às 12h".
    Marcar almoço como completado.
    Adicionar "reunião às 15h".
    Alterar a reunião para 15h30.
    Cancelar a reunião.
    ```

1. Se ocorrer um erro, peça ao GitHub Copilot para corrigi-lo:

    ```text
    Recebi um erro "xxx". Por favor, encontre o problema e corrija-o.
    ```

---

Ótimo. Você completou a etapa "Desenvolvimento do Servidor MCP". Agora vamos para o [PASSO 02: Servidor MCP Remoto](./02-mcp-remote-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../issues).