# 01: Desenvolvimento de Aplicativo Monkey com MCP

Neste passo, você está construindo um aplicativo de console simples usando servidores MCP.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Verificar Modo Agente do GitHub Copilot](#verificar-modo-agente-do-github-copilot)
- [Iniciar Servidor MCP – GitHub](#iniciar-servidor-mcp--github)
- [Preparar Instruções Personalizadas](#preparar-instruções-personalizadas)
- [Criar Aplicativo de Console](#criar-aplicativo-de-console)
- [Gerenciar Repositório GitHub](#gerenciar-repositório-github)
- [Iniciar Servidor MCP – Monkey MCP](#iniciar-servidor-mcp--monkey-mcp)
- [Desenvolver Aplicativo Monkey com GitHub Copilot e Servidores MCP](#desenvolver-aplicativo-monkey-com-github-copilot-e-servidores-mcp)

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
    Envie as alterações atuais para o branch `main` do repositório.
    ```

1. Digite o seguinte prompt no GitHub Copilot para gerar um issue no repositório.

    ```text
    Crie uma nova issue do GitHub no meu repositório intitulada 'Implementar Aplicação de Console Monkey' com os seguintes requisitos:
    
    - Criar um app de console C# que possa listar todos os macacos disponíveis, obter detalhes de um macaco específico por nome, e escolher um macaco aleatório.
    - O app deve usar uma classe modelo Monkey e incluir arte ASCII para apelo visual.
    - Adicionar rótulos apropriados como 'enhancement' e 'good first issue'.
    - Adicionar alguns detalhes sobre como podemos proceder para implementar isso e uma checklist do que precisaremos fazer.
    ```

1. Atribua `@Copilot` ao issue e observe o que está acontecendo.

## Iniciar Servidor MCP &ndash; Monkey MCP

1. Abra a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e procure `MCP: List Servers`.
1. Certifique-se de que o servidor MCP `github` está em execução.
1. Escolha `monkeymcp` e clique em `Start Server`.

## Desenvolver Aplicativo Monkey com GitHub Copilot e Servidores MCP

1. Digite o seguinte prompt para obter a lista de macacos.

    ```text
    Obtenha uma lista de macacos que estão disponíveis e exiba-os em uma tabela com seus detalhes.
    ```

1. Digite o seguinte prompt para obter uma ideia do modelo de dados para um macaco.

    ```text
    Como seria um modelo de dados para esta estrutura?
    ```

1. Digite o seguinte prompt para criar um arquivo para a classe do modelo de dados.

    ```text
    Vamos criar um novo arquivo para esta classe.
    ```

1. Digite o seguinte prompt para criar uma classe `MonkeyHelper`.

    ```text
    Vamos criar uma nova classe chamada MonkeyHelper que é estática. Ela deve gerenciar uma coleção de dados de macacos. Inclua métodos para obter todos os macacos, obter um macaco aleatório, encontrar um macaco por nome, e rastrear a contagem de acesso quando um macaco aleatório é escolhido. Os dados dos macacos devem vir do servidor Monkey MCP que acabamos de obter.
    ```

1. Digite o seguinte prompt para atualizar o aplicativo de console.

    ```text
    Vamos atualizar o app agora para ter um menu bonito com as seguintes opções que chamará esse `MonkeyHelper`.
    
    1. Listar todos os macacos
    2. Obter detalhes de um macaco específico por nome
    3. Obter um macaco aleatório
    4. Sair do app

    Também exiba arte ASCII engraçada aleatoriamente.
    ```

1. Digite o seguinte prompt no GitHub Copilot para fazer push do aplicativo de console atualizado.

    ```text
    Envie as alterações atuais para o branch `mymonkeyapp` do repositório.
    Antes de enviar as alterações, certifique-se de que o diretório `workshop` está incluído no push.
    Com este branch, crie um PR contra o branch `main` do seu repositório, não do upstream.
    Conecte este PR à issue criada anteriormente.
    Em seguida, faça merge deste PR e feche a issue.
    ```

---

OK. Você completou o passo "Desenvolvimento de Aplicativo Monkey com MCP". Vamos para o [PASSO 02: Servidor MCP](./02-mcp-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou errônea, por favor crie um [issue](../../../../../issues).