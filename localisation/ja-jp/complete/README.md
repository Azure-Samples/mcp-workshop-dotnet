# MCPサーバー: To-Doアプリ

これは[Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview)でホストされているMCPサーバーで、To-Doリストアイテムを管理します。

## 前提条件

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) と以下の拡張機能
  - [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit) 拡張機能
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## はじめに

- [ASP.NET Core MCPサーバーをローカルで実行](#aspnet-core-mcpサーバーをローカルで実行)
- [ASP.NET Core MCPサーバーをコンテナでローカル実行](#aspnet-core-mcpサーバーをコンテナでローカル実行)
- [ASP.NET Core MCPサーバーをリモートで実行](#aspnet-core-mcpサーバーをリモートで実行)
- [MCPサーバーをMCPホスト/クライアントに接続](#mcpサーバーをmcpホストクライアントに接続)
  - [VS Code + エージェントモード + ローカルMCPサーバー](#vs-code--エージェントモード--ローカルmcpサーバー)
  - [VS Code + エージェントモード + コンテナ内ローカルMCPサーバー](#vs-code--エージェントモード--コンテナ内ローカルmcpサーバー)
  - [VS Code + エージェントモード + リモートMCPサーバー](#vs-code--エージェントモード--リモートmcpサーバー)
  - [MCP Inspector + ローカルMCPサーバー](#mcp-inspector--ローカルmcpサーバー)
  - [MCP Inspector + コンテナ内ローカルMCPサーバー](#mcp-inspector--コンテナ内ローカルmcpサーバー)
  - [MCP Inspector + リモートMCPサーバー](#mcp-inspector--リモートmcpサーバー)

### ASP.NET Core MCPサーバーをローカルで実行

1. リポジトリのルートを取得する。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. MCPサーバーアプリを実行する。

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### ASP.NET Core MCPサーバーをコンテナでローカル実行

1. リポジトリのルートを取得する。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. MCPサーバーアプリをコンテナイメージとしてビルドする。

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. MCPサーバーアプリをコンテナで実行する

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### ASP.NET Core MCPサーバーをリモートで実行

1. Azureにログインする

    ```bash
    # Azure Developer CLIでログイン
    azd auth login
    ```

1. MCPサーバーアプリをAzureにデプロイする

    ```bash
    azd up
    ```

   プロビジョニングとデプロイ中に、サブスクリプションID、場所、環境名の提供を求められます。

1. デプロイが完了した後、以下のコマンドを実行して情報を取得する：

   - Azure Container Apps FQDN:

     ```bash
     azd env get-value AZURE_RESOURCE_MCP_TODO_LIST_FQDN
     ```

### MCPサーバーをMCPホスト/クライアントに接続

#### VS Code + エージェントモード + ローカルMCPサーバー

1. リポジトリのルートを取得する。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. `mcp.json`をリポジトリのルートにコピーする。

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

1. `F1`またはWindowsでは`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`でコマンドパレットを開き、`MCP: List Servers`を検索する。
1. `mcp-todo-list-aca-local`を選択し、`Start Server`をクリックする。
1. プロンプトを入力する。以下は例です：

    ```text
    - To-Doリストを表示して
    - "11時に会議"を追加して
    - To-Doアイテム #1を完了にして
    - To-Doアイテム #2を削除して
    ```

1. 結果を確認する。

#### VS Code + エージェントモード + コンテナ内ローカルMCPサーバー

1. リポジトリのルートを取得する。

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. `mcp.json`をリポジトリのルートにコピーする。

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

1. `F1`またはWindowsでは`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`でコマンドパレットを開き、`MCP: List Servers`を検索する。
1. `mcp-todo-list-aca-container`を選択し、`Start Server`をクリックする。
1. プロンプトを入力する。以下は例です：

    ```text
    - To-Doリストを表示して
    - "11時に会議"を追加して
    - To-Doアイテム #1を完了にして
    - To-Doアイテム #2を削除して
    ```

1. 結果を確認する。

#### VS Code + エージェントモード + リモートMCPサーバー

1. `F1`またはWindowsでは`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`でコマンドパレットを開き、`MCP: List Servers`を検索する。
1. `mcp-todo-list-aca-remote`を選択し、`Start Server`をクリックする。
1. Azure Container Apps FQDNを入力する。
1. プロンプトを入力する。以下は例です：

    ```text
    - To-Doリストを表示して
    - "11時に会議"を追加して
    - To-Doアイテム #1を完了にして
    - To-Doアイテム #2を削除して
    ```

1. 結果を確認する。

#### MCP Inspector + ローカルMCPサーバー

1. MCP Inspectorを実行する。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. ウェブブラウザを開き、アプリケーションで表示されるURLからMCP Inspector Webアプリに移動する（例：http://localhost:6274）
1. トランスポートタイプを`Streamable HTTP`に設定する
1. 実行中のFunctionアプリのStreamable HTTPエンドポイントにURLを設定し、**Connect**する：

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. **List Tools**をクリックする。
1. ツールをクリックし、適切な値で**Run Tool**する。

#### MCP Inspector + コンテナ内ローカルMCPサーバー

1. MCP Inspectorを実行する。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. ウェブブラウザを開き、アプリケーションで表示されるURLからMCP Inspector Webアプリに移動する（例：http://localhost:6274）
1. トランスポートタイプを`Streamable HTTP`に設定する
1. 実行中のFunctionアプリのStreamable HTTPエンドポイントにURLを設定し、**Connect**する：

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. **List Tools**をクリックする。
1. ツールをクリックし、適切な値で**Run Tool**する。

#### MCP Inspector + リモートMCPサーバー

1. MCP Inspectorを実行する。

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. ウェブブラウザを開き、アプリケーションで表示されるURLからMCP Inspector Webアプリに移動する（例：http://0.0.0.0:6274）
1. トランスポートタイプを`Streamable HTTP`に設定する
1. 実行中のFunctionアプリのStreamable HTTPエンドポイントにURLを設定し、**Connect**する：

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. **List Tools**をクリックする。
1. ツールをクリックし、適切な値で**Run Tool**する。

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../issues)を作成してください。