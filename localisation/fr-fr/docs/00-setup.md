# 00 : Environnement de Développement

Dans cette étape, vous configurez l'environnement de développement pour l'atelier.

## Prérequis

Référez-vous au document [README](../README.md#prerequisites) pour la préparation.

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

1. Descendez à la section [Configurer les Serveurs MCP](#configurer-les-serveurs-mcp).

**👇👇👇 Si vous préférez utiliser VS Code sur votre machine locale, suivez les instructions ci-dessous. La section ci-dessous ne s'applique pas à ceux qui utilisent GitHub Codespaces. 👇👇👇**

## Utiliser Visual Studio Code

### Installer PowerShell 👉 Pour les Utilisateurs Windows

Si vous utilisez Windows, vous devez installer PowerShell. Si vous avez déjà PowerShell installé, vous pouvez ignorer cette étape.

1. Allez sur le [site officiel de PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) et installez la dernière version.

### Installer git CLI

Si vous avez déjà git CLI installé, vous pouvez ignorer cette étape.

1. Allez sur le [site officiel de git](https://git-scm.com/downloads) et installez la dernière version.

### Installer GitHub CLI

Si vous avez déjà GitHub CLI installé, vous pouvez ignorer cette étape.

1. Allez sur le [site officiel de GitHub CLI](https://cli.github.com/) et installez la dernière version.

### Installer Docker Desktop

Si vous avez déjà Docker Desktop installé, vous pouvez ignorer cette étape.

1. Allez sur le [site officiel de Docker Desktop](https://docs.docker.com/get-started/get-docker/) et installez la dernière version.

### Installer Visual Studio Code

Si vous avez déjà Visual Studio Code installé, vous pouvez ignorer cette étape.

1. Allez sur le [site officiel de Visual Studio Code](https://code.visualstudio.com/) et installez la dernière version.

### Démarrer Visual Studio Code

1. Ouvrez un terminal et exécutez la commande suivante pour cloner ce dépôt :

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. Naviguez vers le répertoire du dépôt :

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Ouvrez Visual Studio Code :

    ```bash
    code .
    ```

## Configurer les Serveurs MCP

Dans cette section, vous configurez les serveurs MCP pour l'atelier.

1. Installez les extensions Visual Studio Code nécessaires. Ouvrez Visual Studio Code et allez à la vue Extensions (`Ctrl+Shift+X` ou `Cmd+Shift+X`).

1. Recherchez et installez les extensions suivantes :
   - **C# Dev Kit** - Pour le développement .NET
   - **GitHub Copilot** - Pour l'assistance IA

1. Une fois installées, redémarrez Visual Studio Code.

1. Installez les packages npm nécessaires en exécutant la commande suivante dans le terminal :

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## Vérifier le Mode Agent GitHub Copilot

1. Cliquez sur l'icône GitHub Copilot en haut de GitHub Codespace ou VS Code et ouvrez la fenêtre GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-02.png)

1. Si on vous demande de vous connecter ou de vous inscrire, faites-le. C'est gratuit.
1. Assurez-vous d'utiliser le Mode Agent GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-03.png)

1. Sélectionnez le modèle comme `GPT-4.1` ou `Claude Sonnet 4`.

---

Parfait. Vous avez terminé l'étape "Environnement de Développement". Passons maintenant à [ÉTAPE 01 : Serveur MCP](./01-mcp-server.md).

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../issues).