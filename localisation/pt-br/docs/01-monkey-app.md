# 01: Desenvolvimento de Aplicativo Monkey com MCP

Neste passo, você está construindo um aplicativo de console simples usando servidores MCP.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Verificar Modo Agente do GitHub Copilot](#verificar-modo-agente-do-github-copilot)
- [Preparar Instruções Personalizadas](#preparar-instruções-personalizadas)
- [Preparar Desenvolvimento do Servidor MCP](#preparar-desenvolvimento-do-servidor-mcp)
- [Desenvolver Lógica de Gerenciamento de Lista de Tarefas](#desenvolver-lógica-de-gerenciamento-de-lista-de-tarefas)
- [Remover Lógica da API](#remover-lógica-da-api)
- [Converter para Servidor MCP](#converter-para-servidor-mcp)
- [Executar Servidor MCP](#executar-servidor-mcp)
- [Testar Servidor MCP](#testar-servidor-mcp)

## Verificar Modo Agente do GitHub Copilot

1. Clique no ícone do GitHub Copilot no topo do GitHub Codespace ou VS Code e abra a janela do GitHub Copilot.

   ![Abrir GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Se for solicitado para fazer login ou se cadastrar, faça-o. É gratuito.
1. Certifique-se de estar usando o Modo Agente do GitHub Copilot.

   ![Modo Agente do GitHub Copilot](../../../docs/images/setup-02.png)

1. Selecione o modelo para `GPT-4.1` ou `Claude Sonnet 4`.
1. Certifique-se de ter configurado os [Servidores MCP](./00-setup.md#configurar-servidores-mcp).

## Iniciar Servidor MCP &ndash; GitHub

1. Abra a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e procure `MCP: List Servers`.
1. Escolha `github` e clique em `Start Server`. Você pode ser solicitado a fazer login no GitHub para usar este servidor MCP.

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
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. Abra `.github/copilot-instructions.md` e substitua `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME` pelo seu. Por exemplo, `https://github.com/octocat/monkey-app`.

## Criar Aplicativo de Console

1. Crie um aplicativo de console no diretório `workshop`.

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

## Gerenciar Repositório GitHub

1. Digite o seguinte prompt no GitHub Copilot para fazer push do aplicativo de console criado.

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. Digite o seguinte prompt no GitHub Copilot para gerar um issue no repositório.

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. Atribua `@Copilot` ao issue e observe o que está acontecendo.

## Iniciar Servidor MCP &ndash; Monkey MCP

1. Abra a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e procure `MCP: List Servers`.
1. Certifique-se de que o servidor MCP `github` está em execução.
1. Escolha `monkeymcp` e clique em `Start Server`.

## Desenvolver Aplicativo Monkey com GitHub Copilot e Servidores MCP

1. Digite o seguinte prompt para obter a lista de macacos.

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. Digite o seguinte prompt para obter uma ideia do modelo de dados para um macaco.

    ```text
    What would a data model look like for this structure?
    ```

1. Digite o seguinte prompt para criar um arquivo para a classe do modelo de dados.

    ```text
    Let's create a new file for this class.
    ```

1. Digite o seguinte prompt para criar uma classe `MonkeyHelper`.

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. Digite o seguinte prompt para atualizar o aplicativo de console.

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. Digite o seguinte prompt no GitHub Copilot para fazer push do aplicativo de console atualizado.

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK. Você completou o passo "Desenvolvimento de Aplicativo Monkey com MCP". Vamos para o [PASSO 02: Servidor MCP](./02-mcp-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou errônea, por favor crie um [issue](../../../../../issues).