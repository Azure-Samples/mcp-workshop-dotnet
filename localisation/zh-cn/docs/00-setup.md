# 00: 开发环境

在这一步中，您正在为工作坊设置开发环境。

## 先决条件

请参考 [README](../README.md#先决条件) 文档进行准备。

## 开始使用

- [使用 GitHub Codespaces](#使用-github-codespaces)
- [使用 Visual Studio Code](#使用-visual-studio-code)
  - [安装 PowerShell 👉 Windows 用户](#安装-powershell--windows-用户)
  - [安装 git CLI](#安装-git-cli)
  - [安装 GitHub CLI](#安装-github-cli)
  - [安装 Docker Desktop](#安装-docker-desktop)
  - [安装 Visual Studio Code](#安装-visual-studio-code)
  - [启动 Visual Studio Code](#启动-visual-studio-code)
- [设置 MCP 服务器](#设置-mcp-服务器)
- [检查 GitHub Copilot 代理模式](#检查-github-copilot-代理模式)

## 使用 GitHub Codespaces

1. 点击此链接 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. GitHub Codespace 实例准备就绪后，打开终端并运行以下命令以验证您需要的一切都已正确安装。

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

1. 检查您的存储库状态。

    ```bash
    git remote -v
    ```

   您应该看到以下输出：

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   如果您看到与上述不同的内容，请删除 GitHub Codespace 实例并重新创建它。

1. 运行以下命令将此存储库 fork 到您的 GitHub 账户。

    ```bash
    git remote -v > remote.txt
    git add . && git commit -m "Add remote.txt for forking"
    ```

   您可能会看到如下消息：

    ```text
    You don't have write access to the Azure-Samples/mcp-workshop-dotnet repository, so you cannot push changes to it.
    To obtain write access we will point this codespace at your fork of Azure-Samples/mcp-workshop-dotnet, creating that fork if it doesn't exist.

    Would you like to proceed?
    ```

   输入 `y`，它将自动将此存储库 fork 到您的 GitHub 账户。

1. 再次检查远程存储库。

    ```bash
    git remote -v
    ```

   您将能够看到 `origin` 和 `upstream`。

    ```text
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (push)
    ```

1. 确保您 fork 的存储库具有可用的 "Issues" 选项卡。如果没有，请转到 "Settings" 👉 向下滚动到 "Features" 部分 👉 勾选 "Issues" 复选框。

1. 转到 [设置 MCP 服务器](#设置-mcp-服务器) 部分。

**👇👇👇 如果您希望在本地机器上使用 VS Code，请按照以下说明操作。以下部分不适用于使用 GitHub Codespaces 的用户。👇👇👇**

## 使用 Visual Studio Code

### 安装 PowerShell 👉 Windows 用户

1. 检查您是否已经安装了 PowerShell。

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   如果您没有看到 `pwsh` 的命令路径，说明您还没有安装 PowerShell。访问 [PowerShell 安装页面](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) 并按照说明操作。

1. 检查您的 PowerShell 版本。

    ```bash
    pwsh --version
    ```

   建议使用版本 `7.5.0` 或更高版本。如果您的版本低于此版本，请访问 [PowerShell 安装页面](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) 并按照说明操作。

### 安装 node.js

1. 检查您是否已经安装了 node.js。

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   如果您没有看到 `node` 的命令路径，意味着您还没有安装 node.js。请访问 [node.js 下载页面](https://nodejs.org/en/download) 并按照说明操作。

1. 检查您的 node.js 版本。

    ```bash
    node --version
    ```

   建议使用版本 `22.17.x`（最新的 LTS）。如果您的版本低于此版本，请访问 [node.js 下载页面](https://nodejs.org/en/download) 并按照说明操作。

### 安装 git CLI

1. 检查您是否已经安装了 git CLI。

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   如果您没有看到 `git` 的命令路径，说明您还没有安装 git CLI。访问 [git CLI 安装页面](https://git-scm.com/downloads) 并按照说明操作。

1. 检查您的 git CLI 版本。

    ```bash
    git --version
    ```

   建议使用版本 `2.39.0` 或更高版本。如果您的版本低于此版本，请访问 [git CLI 安装页面](https://git-scm.com/downloads) 并按照说明操作。

### 安装 GitHub CLI

1. 检查您是否已经安装了 GitHub CLI。

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   如果您没有看到 `gh` 的命令路径，说明您还没有安装 GitHub CLI。访问 [GitHub CLI 安装页面](https://cli.github.com/) 并按照说明操作。

1. 检查您的 GitHub CLI 版本。

    ```bash
    gh --version
    ```

   建议使用版本 `2.65.0` 或更高版本。如果您的版本低于此版本，请访问 [GitHub CLI 安装页面](https://cli.github.com/) 并按照说明操作。

1. 检查您是否已登录 GitHub。

    ```bash
    gh auth status
    ```

   如果您还没有登录，请运行 `gh auth login` 并登录。

### 安装 Docker Desktop

1. 检查您是否已经安装了 Docker Desktop。

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   如果您没有看到 `docker` 的命令路径，说明您还没有安装 Docker Desktop。访问 [Docker Desktop 安装页面](https://docs.docker.com/get-started/introduction/get-docker-desktop/) 并按照说明操作。

1. 检查您的 Docker CLI 版本。

    ```bash
    docker --version
    ```

   建议使用版本 `28.0.4` 或更高版本。如果您的版本低于此版本，请访问 [Docker Desktop 安装页面](https://docs.docker.com/get-started/introduction/get-docker-desktop/) 并按照说明操作。

### 安装 Visual Studio Code

1. 检查您是否已经安装了 VS Code。

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   如果您没有看到 `code` 的命令路径，说明您还没有安装 VS Code。访问 [Visual Studio Code 安装页面](https://code.visualstudio.com/) 并按照说明操作。

1. 检查您的 VS Code 版本。

    ```bash
    code --version
    ```

   建议使用版本 `1.99.0` 或更高版本。如果您的版本低于此版本，请访问 [Visual Studio Code 安装页面](https://code.visualstudio.com/) 并按照说明操作。

   > **注意**：您可能无法执行 `code` 命令。在这种情况下，请按照 [此文档](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line) 进行设置。

### 启动 Visual Studio Code

1. 创建一个工作目录。
1. 运行命令来 fork 此存储库并将其克隆到您的本地机器。

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. 导航到克隆的目录。

    ```bash
    cd mcp-workshop-dotnet
    ```

1. 从终端运行 VS Code。

    ```bash
    code .
    ```

1. 在 VS Code 中打开新终端并运行以下命令来检查您的存储库状态。

    ```bash
    git remote -v
    ```

   您应该看到以下输出。如果您在 `origin` 中看到 `Azure-Samples`，您应该从您的 forked 存储库重新克隆。

    ```bash
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. 检查是否已安装这两个扩展：[GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) 和 [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat)。

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   如果您什么都没看到，说明您还没有安装这些扩展。运行以下命令来安装扩展。

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## 设置 MCP 服务器

1. 设置 `$REPOSITORY_ROOT` 环境变量。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 复制 MCP 服务器设置。

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

## 检查 GitHub Copilot 代理模式

1. 点击 GitHub Codespace 或 VS Code 顶部的 GitHub Copilot 图标并打开 GitHub Copilot 窗口。

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. 如果要求您登录或注册，请照做。这是免费的。
1. 确保您正在使用 GitHub Copilot 代理模式。

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. 选择模型为 `GPT-4.1` 或 `Claude Sonnet 4`。

---

很好。您已完成"开发环境"步骤。让我们继续进行 [步骤 01: MCP 服务器](./01-mcp-server.md)。

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../../issues)。