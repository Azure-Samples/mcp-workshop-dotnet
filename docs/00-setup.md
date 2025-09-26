# 00: Development Environment

In this step, you're setting up the development environment for the workshop.

## Prerequisites

Refer to the [README](../README.md#prerequisites) doc for preparation.

## Getting Started

- [Use GitHub Codespaces](#use-github-codespaces)
- [Use Visual Studio Code](#use-visual-studio-code)
  - [Install PowerShell 👉 For Windows Users](#install-powershell--for-windows-users)
  - [Install git CLI](#install-git-cli)
  - [Install GitHub CLI](#install-github-cli)
  - [Install Docker Desktop](#install-docker-desktop)
  - [Install Visual Studio Code](#install-visual-studio-code)
  - [Start Visual Studio Code](#start-visual-studio-code)
- [Set-up MCP Servers](#set-up-mcp-servers)
- [Check GitHub Copilot Agent Mode](#check-github-copilot-agent-mode)

## Use GitHub Codespaces

1. Click this link 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. Once the GitHub Codespace instance is ready, open a terminal and run the following commands to verify that everything you need has been properly installed.

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

1. Check your repository status.

    ```bash
    git remote -v
    ```

   You should see the following output:

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   If you see something different from above, delete the GitHub Codespace instance and recreate it.

1. Run the following command to fork this repository to your GitHub account.

    ```bash
    git remote -v > remote.txt
    git add . && git commit -m "Add remote.txt for forking"
    ```

   You might be seeing a message like below:

    ```text
    You don't have write access to the Azure-Samples/mcp-workshop-dotnet repository, so you cannot push changes to it.
    To obtain write access we will point this codespace at your fork of Azure-Samples/mcp-workshop-dotnet, creating that fork if it doesn't exist.

    Would you like to proceed?
    ```

   Enter `y`, and it will automatically fork this repository to your GitHub account.

1. Check the remote repository again.

    ```bash
    git remote -v
    ```

   You'll be able to see both `origin` and `upstream`.

    ```text
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (push)
    ```

1. Move down to the [Set-up MCP Servers](#set-up-mcp-servers) section.

**👇👇👇 If you'd like to use VS Code on your local machine instead, follow the instruction below. The section below doesn't apply to those who use GitHub Codespaces. 👇👇👇**

## Use Visual Studio Code

### Install PowerShell 👉 For Windows Users

1. Check whether you've already installed PowerShell.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   If you don't see the command path of `pwsh`, it means you haven't installed PowerShell yet. Visit [PowerShell installation page](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) and follow the instructions.

1. Check the version of your PowerShell.

    ```bash
    pwsh --version
    ```

   Version `7.5.0` or higher is recommended. If your version is lower than that, visit the [PowerShell installation page](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) and follow the instructions.

### Install node.js

1. Check whether you've already installed node.js.

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   If you don't see the command path of `node`, it means you haven't installed the node.js yet. Visit [node.js download page](https://nodejs.org/en/download) and follow the instructions.

1. Check the version of your node.js.

    ```bash
    node --version
    ```

   Version `22.17.x` (latest LTS) is recommended. If your version is lower than that, visit the [node.js download page](https://nodejs.org/en/download) and follow the instructions.

### Install git CLI

1. Check whether you've already installed git CLI.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   If you don't see the command path of `git`, it means you haven't installed the git CLI yet. Visit [git CLI installation page](https://git-scm.com/downloads) and follow the instructions.

1. Check the version of your git CLI.

    ```bash
    git --version
    ```

   Version `2.39.0` or higher is recommended. If your version is lower than that, visit the [git CLI installation page](https://git-scm.com/downloads) and follow the instructions.

### Install GitHub CLI

1. Check whether you've already installed GitHub CLI.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   If you don't see the command path of `gh`, it means you haven't installed the GitHub CLI yet. Visit [GitHub CLI installation page](https://cli.github.com/) and follow the instructions.

1. Check the version of your GitHub CLI.

    ```bash
    gh --version
    ```

   Version `2.65.0` or higher is recommended. If your version is lower than that, visit the [GitHub CLI installation page](https://cli.github.com/) and follow the instructions.

1. Check whether you've signed into GitHub.

    ```bash
    gh auth status
    ```

   If you haven't signed in yet, run `gh auth login` and sign in.

### Install Docker Desktop

1. Check whether you've already installed Docker Desktop.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   If you don't see the command path of `docker`, it means you haven't installed Docker Desktop yet. Visit [Docker Desktop installation page](https://docs.docker.com/get-started/introduction/get-docker-desktop/) and follow the instructions.

1. Check the version of your Docker CLI.

    ```bash
    docker --version
    ```

   Version `28.0.4` or higher is recommended. If your version is lower than that, visit the [Docker Desktop installation page](https://docs.docker.com/get-started/introduction/get-docker-desktop/) and follow the instructions.

### Install Visual Studio Code

1. Check whether you've already installed VS Code.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   If you don't see the command path of `code`, it means you haven't installed VS Code yet. Visit [Visual Studio Code installation page](https://code.visualstudio.com/) and follow the instructions.

1. Check the version of your VS Code.

    ```bash
    code --version
    ```

   Version `1.99.0` or higher is recommended. If your version is lower than that, visit the [Visual Studio Code installation page](https://code.visualstudio.com/) and follow the instructions.

   > **NOTE**: You might not be able to execute the `code` command. In this case, follow [this document](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line) for setup.

### Start Visual Studio Code

1. Create a working directory.
1. Run the command to fork this repo and clone it to your local machine.

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. Navigate into the cloned directory.

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Run VS Code from the terminal.

    ```bash
    code .
    ```

1. Open a new terminal within VS Code and run the following command to check your repository status.

    ```bash
    git remote -v
    ```

   You should see the following output. If you see `Azure-Samples` in the `origin`, you should clone it again from your forked repository.

    ```bash
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. Check whether both extensions have been installed: [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) and [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   If you see nothing, it means you haven't installed those extensions yet. Run the following command to install the extensions.

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## Set-up MCP Servers

1. Set the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copy MCP server settings.

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

## Check GitHub Copilot Agent Mode

1. Click the GitHub Copilot icon on the top of GitHub Codespace or VS Code and open GitHub Copilot window.

   ![Open GitHub Copilot Chat](./images/setup-01.png)

1. If you're asked to login or sign up, do it. It's free of charge.
1. Make sure you're using GitHub Copilot Agent Mode.

   ![GitHub Copilot Agent Mode](./images/setup-02.png)

1. Select model to either `GPT-4.1` or `Claude Sonnet 4`.

---

OK. You've completed the "Development Environment" step. Let's move onto [STEP 01: Monkey App](./01-monkey-app.md).
