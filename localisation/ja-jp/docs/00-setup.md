# 00: 開発環境

このステップでは、ワークショップ用の開発環境をセットアップします。

## 前提条件

準備については[README](../README.md#前提条件)ドキュメントを参照してください。

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

1. PowerShellがすでにインストールされているかを確認します。

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   `pwsh`のコマンドパスが表示されない場合は、まだPowerShellがインストールされていません。[PowerShellインストールページ](https://learn.microsoft.com/powershell/scripting/install/installing-powershell)にアクセスして、指示に従ってください。

1. PowerShellのバージョンを確認します。

    ```bash
    pwsh --version
    ```

   バージョン `7.5.0` 以上が推奨されます。バージョンがそれより低い場合は、[PowerShellインストールページ](https://learn.microsoft.com/powershell/scripting/install/installing-powershell)にアクセスして、指示に従ってください。

### git CLIをインストール

1. git CLIがすでにインストールされているかを確認します。

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   `git`のコマンドパスが表示されない場合は、まだgit CLIがインストールされていません。[git CLIインストールページ](https://git-scm.com/downloads)にアクセスして、指示に従ってください。

1. git CLIのバージョンを確認します。

    ```bash
    git --version
    ```

   バージョン `2.39.0` 以上が推奨されます。バージョンがそれより低い場合は、[git CLIインストールページ](https://git-scm.com/downloads)にアクセスして、指示に従ってください。

### GitHub CLIをインストール

1. GitHub CLIがすでにインストールされているかを確認します。

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   `gh`のコマンドパスが表示されない場合は、まだGitHub CLIがインストールされていません。[GitHub CLIインストールページ](https://cli.github.com/)にアクセスして、指示に従ってください。

1. GitHub CLIのバージョンを確認します。

    ```bash
    gh --version
    ```

   バージョン `2.65.0` 以上が推奨されます。バージョンがそれより低い場合は、[GitHub CLIインストールページ](https://cli.github.com/)にアクセスして、指示に従ってください。

1. GitHubにサインインしているかを確認します。

    ```bash
    gh auth status
    ```

   まだサインインしていない場合は、`gh auth login`を実行してサインインしてください。

### Docker Desktopをインストール

1. Docker Desktopがすでにインストールされているかを確認します。

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   `docker`のコマンドパスが表示されない場合は、まだDocker Desktopがインストールされていません。[Docker Desktopインストールページ](https://docs.docker.com/get-started/introduction/get-docker-desktop/)にアクセスして、指示に従ってください。

1. Docker CLIのバージョンを確認します。

    ```bash
    docker --version
    ```

   バージョン `28.0.4` 以上が推奨されます。バージョンがそれより低い場合は、[Docker Desktopインストールページ](https://docs.docker.com/get-started/introduction/get-docker-desktop/)にアクセスして、指示に従ってください。

### Visual Studio Codeをインストール

1. VS Codeがすでにインストールされているかを確認します。

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   `code`のコマンドパスが表示されない場合は、まだVS Codeがインストールされていません。[Visual Studio Codeインストールページ](https://code.visualstudio.com/)にアクセスして、指示に従ってください。

1. VS Codeのバージョンを確認します。

    ```bash
    code --version
    ```

   バージョン `1.99.0` 以上が推奨されます。バージョンがそれより低い場合は、[Visual Studio Codeインストールページ](https://code.visualstudio.com/)にアクセスして、指示に従ってください。

   > **注意**: `code`コマンドを実行できない場合があります。その場合は、セットアップのために[このドキュメント](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line)に従ってください。

### Visual Studio Codeを開始

1. 作業ディレクトリを作成します。
1. このリポジトリをフォークしてローカルマシンにクローンするコマンドを実行します。

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. クローンしたディレクトリに移動します。

    ```bash
    cd mcp-workshop-dotnet
    ```

1. ターミナルからVS Codeを実行します。

    ```bash
    code .
    ```

1. VS Code内で新しいターミナルを開いて、以下のコマンドを実行してリポジトリのステータスを確認します。

    ```bash
    git remote -v
    ```

   以下の出力が表示されるはずです。`origin`に`Azure-Samples`が表示される場合は、フォークしたリポジトリから再度クローンしてください。

    ```bash
    origin  https://github.com/<あなたのGitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<あなたのGitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. 両方の拡張機能がインストールされているかを確認します：[GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot)と[GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat)。

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   何も表示されない場合は、まだこれらの拡張機能がインストールされていません。以下のコマンドを実行して拡張機能をインストールしてください。

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## MCPサーバーをセットアップ

1. `$REPOSITORY_ROOT`の環境変数を設定します。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. MCPサーバーの設定をコピーします。

    ```bash
    # bash/zsh
    cp -r $REPOSITORY_ROOT/docs/.vscode/. \
          $REPOSITORY_ROOT/.vscode/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/* `
              -Destination $REPOSITORY_ROOT/.vscode/ -Recurse -Force
    ```

1. `F1`キーを押すか、Windowsでは`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`を押してコマンドパレットを開き、`MCP: List Servers`を検索します。
1. `context7`を選択して`Start Server`をクリックします。

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