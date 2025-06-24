# 00: Development Environment

In this step, you're setting up development environment for the workshop.

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

## Use GitHub Codespaces

1. Click this link 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. Once the GitHub Codespace instance is ready, open a terminal and run the following command to check out everything you need has been properly installed or not.

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

1. Check out your repository status.

    ```bash
    git remote -v
    ```

   You should be able to see the following.

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   If you see something different from above, delete the GitHub Codespace instance and recreate it.

1. Move down to bottom of this page.

**👇👇👇 If you'd like to use VS Code on your local machine instead, follow the instruction below. The section below doesn't apply to those who use GitHub Codespaces. 👇👇👇**

## Use Visual Studio Code

### Install PowerShell 👉 For Windows Users

1. Check whether you've already installed PowerShell or not.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   If you don't see the command path of `pwsh`, it means you haven't installed PowerShell yet. Visit [PowerShell installation page](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) and follow the instructions.

1. Check out the version of your PowerShell.

    ```bash
    pwsh --version
    ```

   `7.5.0` or higher is recommended. If yours is lower than that, visit [PowerShell installation page](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) and follow the instructions.

### Install git CLI

1. Check whether you've already installed git CLI or not.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   If you don't see the command path of `git`, it means you haven't installed the git CLI yet. Visit [git CLI installation page](https://git-scm.com/downloads) and follow the instructions.

1. Check out the version of your git CLI.

    ```bash
    git --version
    ```

   `2.39.0` or higher is recommended. If yours is lower than that, visit [git CLI installation page](https://git-scm.com/downloads) and follow the instructions.

### Install GitHub CLI

1. Check whether you've already installed GitHub CLI or not.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   If you don't see the command path of `gh`, it means you haven't installed the GitHub CLI yet. Visit [GitHub CLI installation page](https://cli.github.com/) and follow the instructions.

1. Check out the version of your GitHub CLI.

    ```bash
    gh --version
    ```

   `2.65.0` or higher is recommended. If yours is lower than that, visit [GitHub CLI installation page](https://cli.github.com/) and follow the instructions.

1. Check whether you've signed into GitHub or not.

    ```bash
    gh auth status
    ```

   If you haven't signed in yet, run `gh auth login` and sign-in.

### Install Docker Desktop

1. Check whether you've already installed Docker Desktop or not.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   If you don't see the command path of `docker`, it means you haven't installed Docker Desktop yet. Visit [Docker Desktop installation page](https://docs.docker.com/get-started/introduction/get-docker-desktop/) and follow the instructions.

1. Check out the version of your Docker CLI.

    ```bash
    docker --version
    ```

   `28.0.4` or higher is recommended. If yours is lower than that, visit [Docker Desktop installation page](https://docs.docker.com/get-started/introduction/get-docker-desktop/) and follow the instructions.

### Install Visual Studio Code

1. Check whether you've already installed VS Code or not.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   If you don't see the command path of `code`, it means you haven't installed VS Code yet. Visit [Visual Studio Code installation page](https://code.visualstudio.com/) and follow the instructions.

1. Check out the version of your VS Code.

    ```bash
    code --version
    ```

   `1.99.0` or higher is recommended. If yours is lower than that, visit [Visual Studio Code installation page](https://code.visualstudio.com/) and follow the instructions.

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

1. Open a new terminal within VS Code and run the following command to check out your repository status.

    ```bash
    git remote -v
    ```

   You should be able to see the following. If you see `Azure-Samples` in `origin`, you should clone it again from your forked repository.

    ```bash
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. Check out whether both extensions have been installed or not &ndash; [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) and [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

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

---

OK. You've completed the "Development Environment" step. Let's move onto [STEP 01: MCP Server](./01-mcp-server.md).
