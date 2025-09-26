# 00 : Environnement de Développement

Dans cette étape, vous configurez l'environnement de développement pour l'atelier.

## Prérequis

Référez-vous au document [README](../README.md#prérequis) pour la préparation.

## Commencer

- [Utiliser GitHub Codespaces](#utiliser-github-codespaces)
- [Utiliser Visual Studio Code](#utiliser-visual-studio-code)
  - [Installer PowerShell 👉 Pour les Utilisateurs Windows](#installer-powershell--pour-les-utilisateurs-windows)
  - [Installer git CLI](#installer-git-cli)
  - [Installer GitHub CLI](#installer-github-cli)
  - [Installer Docker Desktop](#installer-docker-desktop)
  - [Installer Visual Studio Code](#installer-visual-studio-code)
  - [Démarrer Visual Studio Code](#démarrer-visual-studio-code)
- [Configurer les Serveurs MCP](#configurer-les-serveurs-mcp)
- [Vérifier le Mode Agent GitHub Copilot](#vérifier-le-mode-agent-github-copilot)

## Utiliser GitHub Codespaces

1. Cliquez sur ce lien 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. Une fois que l'instance GitHub Codespace est prête, ouvrez un terminal et exécutez les commandes suivantes pour vérifier que tout ce dont vous avez besoin a été correctement installé.

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

1. Vérifiez le statut de votre dépôt.

    ```bash
    git remote -v
    ```

   Vous devriez voir la sortie suivante :

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   Si vous voyez quelque chose de différent, supprimez l'instance GitHub Codespace et recréez-la.

1. Exécutez la commande suivante pour forker ce dépôt vers votre compte GitHub.

    ```bash
    git remote -v > remote.txt
    git add . && git commit -m "Add remote.txt for forking"
    ```

   Vous pourriez voir un message comme ci-dessous :

    ```text
    You don't have write access to the Azure-Samples/mcp-workshop-dotnet repository, so you cannot push changes to it.
    To obtain write access we will point this codespace at your fork of Azure-Samples/mcp-workshop-dotnet, creating that fork if it doesn't exist.

    Would you like to proceed?
    ```

   Entrez `y`, et il forkera automatiquement ce dépôt vers votre compte GitHub.

1. Vérifiez à nouveau le dépôt distant.

    ```bash
    git remote -v
    ```

   Vous devriez pouvoir voir à la fois `origin` et `upstream`.

    ```text
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (push)
    ```

1. Descendez à la section [Configurer les Serveurs MCP](#configurer-les-serveurs-mcp).

**👇👇👇 Si vous préférez utiliser VS Code sur votre machine locale, suivez les instructions ci-dessous. La section ci-dessous ne s'applique pas à ceux qui utilisent GitHub Codespaces. 👇👇👇**

## Utiliser Visual Studio Code

### Installer PowerShell 👉 Pour les Utilisateurs Windows

1. Vérifiez si vous avez déjà installé PowerShell.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   Si vous ne voyez pas le chemin de la commande `pwsh`, cela signifie que vous n'avez pas encore installé PowerShell. Visitez la [page d'installation de PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) et suivez les instructions.

1. Vérifiez la version de votre PowerShell.

    ```bash
    pwsh --version
    ```

   La version `7.5.0` ou supérieure est recommandée. Si votre version est inférieure, visitez la [page d'installation de PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) et suivez les instructions.

### Installer node.js

1. Vérifiez si vous avez déjà installé node.js.

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   Si vous ne voyez pas le chemin de commande de `node`, cela signifie que vous n'avez pas encore installé node.js. Visitez la [page de téléchargement de node.js](https://nodejs.org/en/download) et suivez les instructions.

1. Vérifiez la version de votre node.js.

    ```bash
    node --version
    ```

   La version `22.17.x` (LTS la plus récente) est recommandée. Si votre version est inférieure, visitez la [page de téléchargement de node.js](https://nodejs.org/en/download) et suivez les instructions.

### Installer git CLI

1. Vérifiez si vous avez déjà installé git CLI.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   Si vous ne voyez pas le chemin de la commande `git`, cela signifie que vous n'avez pas encore installé git CLI. Visitez la [page d'installation de git CLI](https://git-scm.com/downloads) et suivez les instructions.

1. Vérifiez la version de votre git CLI.

    ```bash
    git --version
    ```

   La version `2.39.0` ou supérieure est recommandée. Si votre version est inférieure, visitez la [page d'installation de git CLI](https://git-scm.com/downloads) et suivez les instructions.

### Installer GitHub CLI

1. Vérifiez si vous avez déjà installé GitHub CLI.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   Si vous ne voyez pas le chemin de la commande `gh`, cela signifie que vous n'avez pas encore installé GitHub CLI. Visitez la [page d'installation de GitHub CLI](https://cli.github.com/) et suivez les instructions.

1. Vérifiez la version de votre GitHub CLI.

    ```bash
    gh --version
    ```

   La version `2.65.0` ou supérieure est recommandée. Si votre version est inférieure, visitez la [page d'installation de GitHub CLI](https://cli.github.com/) et suivez les instructions.

1. Vérifiez si vous êtes connecté à GitHub.

    ```bash
    gh auth status
    ```

   Si vous n'êtes pas encore connecté, exécutez `gh auth login` et connectez-vous.

### Installer Docker Desktop

1. Vérifiez si vous avez déjà installé Docker Desktop.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   Si vous ne voyez pas le chemin de la commande `docker`, cela signifie que vous n'avez pas encore installé Docker Desktop. Visitez la [page d'installation de Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) et suivez les instructions.

1. Vérifiez la version de votre Docker CLI.

    ```bash
    docker --version
    ```

   La version `28.0.4` ou supérieure est recommandée. Si votre version est inférieure, visitez la [page d'installation de Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) et suivez les instructions.

### Installer Visual Studio Code

1. Vérifiez si vous avez déjà installé VS Code.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   Si vous ne voyez pas le chemin de la commande `code`, cela signifie que vous n'avez pas encore installé VS Code. Visitez la [page d'installation de Visual Studio Code](https://code.visualstudio.com/) et suivez les instructions.

1. Vérifiez la version de votre VS Code.

    ```bash
    code --version
    ```

   La version `1.99.0` ou supérieure est recommandée. Si votre version est inférieure, visitez la [page d'installation de Visual Studio Code](https://code.visualstudio.com/) et suivez les instructions.

   > **REMARQUE** : Il se peut que vous ne puissiez pas exécuter la commande `code`. Dans ce cas, suivez [ce document](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line) pour la configuration.

### Démarrer Visual Studio Code

1. Créez un répertoire de travail.
1. Exécutez la commande pour faire un fork de ce dépôt et le cloner sur votre machine locale.

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. Naviguez dans le répertoire cloné.

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Exécutez VS Code depuis le terminal.

    ```bash
    code .
    ```

1. Ouvrez un nouveau terminal dans VS Code et exécutez la commande suivante pour vérifier le statut de votre dépôt.

    ```bash
    git remote -v
    ```

   Vous devriez voir la sortie suivante. Si vous voyez `Azure-Samples` dans `origin`, vous devriez le cloner à nouveau depuis votre dépôt forké.

    ```bash
    origin  https://github.com/<votre ID GitHub>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<votre ID GitHub>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. Vérifiez si les deux extensions ont été installées : [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) et [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   Si vous ne voyez rien, cela signifie que vous n'avez pas encore installé ces extensions. Exécutez la commande suivante pour installer les extensions.

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## Configurer les Serveurs MCP

1. Définissez la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copiez les paramètres du serveur MCP.

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

## Vérifier le Mode Agent GitHub Copilot

1. Cliquez sur l'icône GitHub Copilot en haut de GitHub Codespace ou VS Code et ouvrez la fenêtre GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si on vous demande de vous connecter ou de vous inscrire, faites-le. C'est gratuit.
1. Assurez-vous d'utiliser le Mode Agent GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Sélectionnez le modèle comme `GPT-4.1` ou `Claude Sonnet 4`.

---

Parfait. Vous avez terminé l'étape "Environnement de Développement". Passons maintenant à [ÉTAPE 01 : Serveur MCP](./01-mcp-server.md).

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).