# 00: 開発環境

このステップでは、ワークショップ用の開発環境をセットアップします。

## 前提条件

準備については[README](../README.md#prerequisites)ドキュメントを参照してください。

## はじめに

- [GitHub Codespacesを使用](#github-codespacesを使用)
- [Visual Studio Codeを使用](#visual-studio-codeを使用)
  - [PowerShellをインストール 👉 Windowsユーザー向け](#powershellをインストール--windowsユーザー向け)
  - [git CLIをインストール](#git-cliをインストール)
  - [GitHub CLIをインストール](#github-cliをインストール)
  - [Docker Desktopをインストール](#docker-desktopをインストール)
  - [Visual Studio Codeをインストール](#visual-studio-codeをインストール)
  - [Visual Studio Codeを開始](#visual-studio-codeを開始)
- [MCPサーバーをセットアップ](#mcpサーバーをセットアップ)
- [GitHub Copilotエージェントモードを確認](#github-copilotエージェントモードを確認)

## GitHub Codespacesを使用

1. このリンクをクリックしてください 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. GitHub Codespaceインスタンスの準備ができたら、ターミナルを開いて以下のコマンドを実行し、必要なものがすべて適切にインストールされていることを確認してください。

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

1. リポジトリのステータスを確認します。

    ```bash
    git remote -v
    ```

   以下の出力が表示されるはずです：

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   上記と異なるものが表示される場合は、GitHub Codespaceインスタンスを削除して再作成してください。

1. [MCPサーバーをセットアップ](#mcpサーバーをセットアップ)セクションに進んでください。

**👇👇👇 ローカルマシンでVS Codeを使用したい場合は、以下の手順に従ってください。以下のセクションはGitHub Codespacesを使用する人には適用されません。👇👇👇**

## Visual Studio Codeを使用

### PowerShellをインストール 👉 Windowsユーザー向け

Windowsを使用している場合は、PowerShellをインストールする必要があります。すでにPowerShellがインストールされている場合は、このステップをスキップできます。

1. [PowerShell公式ウェブサイト](https://docs.microsoft.com/powershell/scripting/install/installing-powershell)にアクセスして、最新バージョンをインストールしてください。

### git CLIをインストール

すでにgit CLIがインストールされている場合は、このステップをスキップできます。

1. [git公式ウェブサイト](https://git-scm.com/downloads)にアクセスして、最新バージョンをインストールしてください。

### GitHub CLIをインストール

すでにGitHub CLIがインストールされている場合は、このステップをスキップできます。

1. [GitHub CLI公式ウェブサイト](https://cli.github.com/)にアクセスして、最新バージョンをインストールしてください。

### Docker Desktopをインストール

すでにDocker Desktopがインストールされている場合は、このステップをスキップできます。

1. [Docker Desktop公式ウェブサイト](https://docs.docker.com/get-started/get-docker/)にアクセスして、最新バージョンをインストールしてください。

### Visual Studio Codeをインストール

すでにVisual Studio Codeがインストールされている場合は、このステップをスキップできます。

1. [Visual Studio Code公式ウェブサイト](https://code.visualstudio.com/)にアクセスして、最新バージョンをインストールしてください。

### Visual Studio Codeを開始

1. ターミナルを開いて以下のコマンドを実行し、このリポジトリをクローンします：

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. リポジトリディレクトリに移動します：

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Visual Studio Codeを開きます：

    ```bash
    code .
    ```

## MCPサーバーをセットアップ

このセクションでは、ワークショップ用のMCPサーバーをセットアップします。

1. 必要なVisual Studio Code拡張機能をインストールします。Visual Studio Codeを開いて拡張機能ビューに移動します（`Ctrl+Shift+X`または`Cmd+Shift+X`）。

1. 以下の拡張機能を検索してインストールします：
   - **C# Dev Kit** - .NET開発用
   - **GitHub Copilot** - AIアシスタンス用

1. インストール後、Visual Studio Codeを再起動します。

1. ターミナルで以下のコマンドを実行して、必要なnpmパッケージをインストールします：

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## GitHub Copilotエージェントモードを確認

1. GitHub CodespaceまたはVS Codeの上部にあるGitHub Copilotアイコンをクリックして、GitHub Copilotウィンドウを開きます。

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. ログインまたはサインアップを求められた場合は、そうしてください。無料です。
1. GitHub Copilotエージェントモードを使用していることを確認してください。

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. モデルを`GPT-4.1`または`Claude Sonnet 4`に選択してください。

---

完了しました。「開発環境」ステップを完了しました。次は[ステップ01：MCPサーバー](./01-mcp-server.md)に進みましょう。

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../../../../issues)を作成してください。