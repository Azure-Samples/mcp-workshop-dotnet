# 02: MCPリモートサーバー

このステップでは、MCPサーバーをAzureにデプロイします。

## 前提条件

準備については[README](../README.md#前提条件)ドキュメントを参照してください。

## はじめに

- [`Dockerfile`でMCPサーバーをコンテナ化](#dockerfile-でmcpサーバーをコンテナ化)
- [`azd`でMCPサーバーをAzureにデプロイ](#azd-でmcpサーバーをazureにデプロイ)

## `Dockerfile`でMCPサーバーをコンテナ化

[前のセッション](./01-mcp-server.md)では、すでにMCPサーバーアプリを作成しました。それを使い続けましょう。

1. Docker Desktopが起動して実行されていることを確認してください。
1. 環境変数`$REPOSITORY_ROOT`が設定されていることを確認してください。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. アプリプロジェクトに移動します。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. `Dockerfile`を作成します。

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. `Dockerfile`を開き、以下のコード行を追加して保存します。

    ```dockerfile
    # syntax=docker/dockerfile:1
    
    FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
    
    COPY . /source
    
    WORKDIR /source/src/McpTodoServer.ContainerApp
    
    RUN dotnet publish -c Release -o /app
    
    FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
    
    WORKDIR /app
    
    COPY --from=build /app .
    
    USER $APP_UID
    
    ENTRYPOINT ["dotnet", "McpTodoServer.ContainerApp.dll"]
    ```

1. コンテナイメージをビルドします。

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. コンテナイメージを実行します。

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. `.vscode/mcp.json`を開き、MCPサーバーのURLをコンテナ化されたMCPサーバーに置き換えます。

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // 変更前
          "url": "http://localhost:5242/mcp"

          // 変更後
          "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 追加 👆👆👆
      }
    }
    ```

1. MCPサーバー`mcp-todo`を開始し、[このドキュメント](./01-mcp-server.md#mcpサーバーをテスト)に従ってテストします。
1. テストが完了したら、コンテナを停止して削除します。

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## `azd`でMCPサーバーをAzureにデプロイ

1. Azureにログインしていることを確認してください。

    ```bash
    azd auth login --check-status
    ```

   まだログインしていない場合は、Azureアカウントで`azd auth login`を実行してください。

1. 環境変数`$REPOSITORY_ROOT`が設定されていることを確認してください。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. アプリプロジェクトに移動します。

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. `azd`テンプレートを初期化します。

    ```bash
    azd init
    ```

   いくつかの質問をします。以下のオプションを選択してください：

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   その後、`azure.yaml`ファイルが作成されます。

1. `azure.yaml`ファイルを開き、以下のコード行で更新します。

    ```yml
    # yaml-language-server: $schema=https://raw.githubusercontent.com/Azure/azure-dev/main/schemas/v1.0/azure.yaml.json
    
    name: workshop
    metadata:
        template: azd-init@1.17.2
    services:
        mcptodoserver-containerapp:
            project: src/McpTodoServer.ContainerApp
            host: containerapp
            language: dotnet

            # 👇👇👇 追加 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 追加 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. MCPサーバーをデプロイします。

    ```bash
    azd up
    ```

   いくつかの質問をします：

   - `? Enter a unique environment name` 👉 任意の名前を入力してください。例：`mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 使用するAzureサブスクリプションを選択してください。
   - `? Enter a value for the 'location' infrastructure parameter` 👉 MCPサーバーをデプロイする場所を選択してください。

1. 完了すると、ターミナルでMCPサーバーのURLを見つけることができます。これは`https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`のように見えます。このURLをメモしてください。
1. `.vscode/mcp.json`を開き、MCPサーバーのURLをデプロイされたMCPサーバーに置き換えます。`{{azure-container-apps-url}}`は前のステップで取得したURLに置き換える必要があります。

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // 変更前
          "url": "http://localhost:8080/mcp"

          // 変更後
          "url": "http://{{azure-container-apps-url}}/mcp"
        }
      }
    }
    ```

1. MCPサーバー`mcp-todo`を開始し、[このドキュメント](./01-mcp-server.md#mcpサーバーをテスト)に従ってテストします。

---

完了しました。「MCPリモートサーバーデプロイメント」ステップを完了しました。次は[ステップ03：MCPクライアント](./03-mcp-client.md)に進みましょう。

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../../../../issues)を作成してください。
