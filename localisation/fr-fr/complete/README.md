# Serveur MCP : Application de Tâches

Ceci est un serveur MCP, hébergé sur [Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview), qui gère les éléments de liste de tâches.

## Prérequis

- [SDK .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) avec
  - Extension [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## Commencer

- [Exécuter le serveur MCP ASP.NET Core localement](#exécuter-le-serveur-mcp-aspnet-core-localement)
- [Exécuter le serveur MCP ASP.NET Core localement dans un conteneur](#exécuter-le-serveur-mcp-aspnet-core-localement-dans-un-conteneur)
- [Exécuter le serveur MCP ASP.NET Core à distance](#exécuter-le-serveur-mcp-aspnet-core-à-distance)
- [Connecter le serveur MCP à un hôte/client MCP](#connecter-le-serveur-mcp-à-un-hôteclient-mcp)
  - [VS Code + Mode Agent + Serveur MCP local](#vs-code--mode-agent--serveur-mcp-local)
  - [VS Code + Mode Agent + Serveur MCP local dans un conteneur](#vs-code--mode-agent--serveur-mcp-local-dans-un-conteneur)
  - [VS Code + Mode Agent + Serveur MCP distant](#vs-code--mode-agent--serveur-mcp-distant)
  - [MCP Inspector + Serveur MCP local](#mcp-inspector--serveur-mcp-local)
  - [MCP Inspector + Serveur MCP local dans un conteneur](#mcp-inspector--serveur-mcp-local-dans-un-conteneur)
  - [MCP Inspector + Serveur MCP distant](#mcp-inspector--serveur-mcp-distant)
  - [Application Client MCP + Serveur MCP local](#application-client-mcp--serveur-mcp-local)
  - [Application Client MCP + Serveur MCP local en conteneur](#application-client-mcp--serveur-mcp-local-en-conteneur)
  - [Application Client MCP + Serveur MCP distant](#application-client-mcp--serveur-mcp-distant)

### Exécuter le serveur MCP ASP.NET Core localement

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Exécuter l'application serveur MCP.

    ```bash
    cd $REPOSITORY_ROOT/complete
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### Exécuter le serveur MCP ASP.NET Core localement dans un conteneur

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Construire l'application serveur MCP comme une image conteneur.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. Exécuter l'application serveur MCP dans un conteneur

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### Exécuter le serveur MCP ASP.NET Core à distance

1. Se connecter à Azure

    ```bash
    # Se connecter avec Azure Developer CLI
    azd auth login
    ```

1. Déployer l'application serveur MCP sur Azure

    ```bash
    azd up
    ```

   Pendant l'approvisionnement et le déploiement, vous serez invité à fournir l'ID d'abonnement, l'emplacement et le nom d'environnement.

1. Une fois le déploiement terminé, obtenez les informations d'URL à partir du terminal.

### Connecter le serveur MCP à un hôte/client MCP

#### VS Code + Mode Agent + Serveur MCP local

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copier `mcp.json` à la racine du dépôt.

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

1. Ouvrir la Palette de Commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et rechercher `MCP: List Servers`.
1. Choisir `mcp-todo-list-aca-local` puis cliquer sur `Start Server`.
1. Entrer des prompts. Voici quelques exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Terminer l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

#### VS Code + Mode Agent + Serveur MCP local dans un conteneur

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copier `mcp.json` à la racine du dépôt.

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

1. Ouvrir la Palette de Commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et rechercher `MCP: List Servers`.
1. Choisir `mcp-todo-list-aca-container` puis cliquer sur `Start Server`.
1. Entrer des prompts. Voici quelques exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Terminer l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

#### VS Code + Mode Agent + Serveur MCP distant

1. Ouvrir la Palette de Commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et rechercher `MCP: List Servers`.
1. Choisir `mcp-todo-list-aca-remote` puis cliquer sur `Start Server`.
1. Entrer le FQDN d'Azure Container Apps.
1. Entrer des prompts. Voici quelques exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Terminer l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

#### MCP Inspector + Serveur MCP local

1. Exécuter MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Ouvrir un navigateur web et naviguer vers l'application web MCP Inspector depuis l'URL affichée par l'application (par ex. http://localhost:6274)
1. Définir le type de transport sur `Streamable HTTP` 
1. Définir l'URL sur le point de terminaison Streamable HTTP de votre application Function en cours d'exécution et **Connecter** :

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. Cliquer sur **List Tools**.
1. Cliquer sur un outil et **Run Tool** avec des valeurs appropriées.

#### MCP Inspector + Serveur MCP local dans un conteneur

1. Exécuter MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Ouvrir un navigateur web et naviguer vers l'application web MCP Inspector depuis l'URL affichée par l'application (par ex. http://localhost:6274)
1. Définir le type de transport sur `Streamable HTTP` 
1. Définir l'URL sur le point de terminaison Streamable HTTP de votre application Function en cours d'exécution et **Connecter** :

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. Cliquer sur **List Tools**.
1. Cliquer sur un outil et **Run Tool** avec des valeurs appropriées.

#### MCP Inspector + Serveur MCP distant

1. Exécuter MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Ouvrir un navigateur web et naviguer vers l'application web MCP Inspector depuis l'URL affichée par l'application (par ex. http://0.0.0.0:6274)
1. Définir le type de transport sur `Streamable HTTP` 
1. Définir l'URL sur le point de terminaison Streamable HTTP de votre application Function en cours d'exécution et **Connecter** :

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. Cliquer sur **List Tools**.
1. Cliquer sur un outil et **Run Tool** avec des valeurs appropriées.

#### Application Client MCP + Serveur MCP local

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Naviguer vers le répertoire de l'application client MCP.

    ```bash
    cd $REPOSITORY_ROOT/complete/src/McpTodoClient.BlazorApp
    ```

1. Exécuter l'application client MCP.

    ```bash
    dotnet watch run
    ```

1. Ouvrir un navigateur web et entrer des prompts. Ce ne sont que des exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Compléter l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

#### Application Client MCP + Serveur MCP local en conteneur

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Naviguer vers le répertoire de l'application client MCP.

    ```bash
    cd $REPOSITORY_ROOT/complete/src/McpTodoClient.BlazorApp
    ```

1. Ouvrir `Program.cs`, remplacer `http://localhost:5242` par `http://localhost:8080` et l'enregistrer.

1. Exécuter l'application client MCP.

    ```bash
    dotnet watch run
    ```

1. Ouvrir un navigateur web et entrer des prompts. Ce ne sont que des exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Compléter l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

#### Application Client MCP + Serveur MCP distant

1. Obtenir la racine du dépôt.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Naviguer vers le répertoire de l'application client MCP.

    ```bash
    cd $REPOSITORY_ROOT/complete/src/McpTodoClient.BlazorApp
    ```

1. Ouvrir `Program.cs`, remplacer `http://localhost:5242` par l'URL d'Azure Container Apps et l'enregistrer.

1. Exécuter l'application client MCP.

    ```bash
    dotnet watch run
    ```

1. Ouvrir un navigateur web et entrer des prompts. Ce ne sont que des exemples :

    ```text
    - Montrez-moi la liste de tâches
    - Ajouter "réunion à 11h"
    - Compléter l'élément de tâche #1
    - Supprimer l'élément de tâche #2
    ```

1. Confirmer le résultat.

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).