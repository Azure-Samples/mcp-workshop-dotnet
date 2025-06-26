# 00: 开发环境

在这一步中，您正在为工作坊设置开发环境。

## 先决条件

请参考 [README](../README.md#prerequisites) 文档进行准备。

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

1. 转到 [设置 MCP 服务器](#设置-mcp-服务器) 部分。

**👇👇👇 如果您希望在本地机器上使用 VS Code，请按照以下说明操作。以下部分不适用于使用 GitHub Codespaces 的用户。👇👇👇**

## 使用 Visual Studio Code

### 安装 PowerShell 👉 Windows 用户

如果您使用 Windows，需要安装 PowerShell。如果您已经安装了 PowerShell，可以跳过此步骤。

1. 转到 [PowerShell 官方网站](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) 并安装最新版本。

### 安装 git CLI

如果您已经安装了 git CLI，可以跳过此步骤。

1. 转到 [git 官方网站](https://git-scm.com/downloads) 并安装最新版本。

### 安装 GitHub CLI

如果您已经安装了 GitHub CLI，可以跳过此步骤。

1. 转到 [GitHub CLI 官方网站](https://cli.github.com/) 并安装最新版本。

### 安装 Docker Desktop

如果您已经安装了 Docker Desktop，可以跳过此步骤。

1. 转到 [Docker Desktop 官方网站](https://docs.docker.com/get-started/get-docker/) 并安装最新版本。

### 安装 Visual Studio Code

如果您已经安装了 Visual Studio Code，可以跳过此步骤。

1. 转到 [Visual Studio Code 官方网站](https://code.visualstudio.com/) 并安装最新版本。

### 启动 Visual Studio Code

1. 打开终端并运行以下命令来克隆此存储库：

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. 导航到存储库目录：

    ```bash
    cd mcp-workshop-dotnet
    ```

1. 打开 Visual Studio Code：

    ```bash
    code .
    ```

## 设置 MCP 服务器

在本节中，您正在为工作坊设置 MCP 服务器。

1. 安装必要的 Visual Studio Code 扩展。打开 Visual Studio Code 并转到扩展视图（`Ctrl+Shift+X` 或 `Cmd+Shift+X`）。

1. 搜索并安装以下扩展：
   - **C# Dev Kit** - 用于 .NET 开发
   - **GitHub Copilot** - 用于 AI 协助

1. 安装后，重新启动 Visual Studio Code。

1. 通过在终端中运行以下命令来安装必要的 npm 包：

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## 检查 GitHub Copilot 代理模式

1. 点击 GitHub Codespace 或 VS Code 顶部的 GitHub Copilot 图标并打开 GitHub Copilot 窗口。

   ![Open GitHub Copilot Chat](../../../docs/images/setup-02.png)

1. 如果要求您登录或注册，请照做。这是免费的。
1. 确保您正在使用 GitHub Copilot 代理模式。

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-03.png)

1. 选择模型为 `GPT-4.1` 或 `Claude Sonnet 4`。

---

很好。您已完成"开发环境"步骤。让我们继续进行 [步骤 01: MCP 服务器](./01-mcp-server.md)。

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../issues)。