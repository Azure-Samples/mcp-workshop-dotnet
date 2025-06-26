# 01: MCPサーバー

このステップでは、To-Doリスト管理用のMCPサーバーを構築します。

## 前提条件

準備については[README](../README.md#prerequisites)ドキュメントを参照してください。

## はじめに

- [GitHub Copilotエージェントモードを確認](#github-copilotエージェントモードを確認)
- [カスタム指示を準備](#カスタム指示を準備)
- [MCPサーバー開発を準備](#mcpサーバー開発を準備)
- [To-Doリスト管理ロジックを開発](#to-doリスト管理ロジックを開発)
- [APIロジックを削除](#apiロジックを削除)
- [MCPサーバーに変換](#mcpサーバーに変換)
- [MCPサーバーを実行](#mcpサーバーを実行)
- [MCPサーバーをテスト](#mcpサーバーをテスト)

## GitHub Copilotエージェントモードを確認

1. GitHub CodespaceまたはVS Codeの上部にあるGitHub Copilotアイコンをクリックして、GitHub Copilotウィンドウを開きます。

   ![Open GitHub Copilot Chat](./images/setup-01.png)

1. ログインまたはサインアップを求められた場合は、そうしてください。無料です。
1. GitHub Copilotエージェントモードを使用していることを確認してください。

   ![GitHub Copilot Agent Mode](./images/setup-02.png)

1. モデルを`GPT-4.1`または`Claude Sonnet 4`に選択してください。
1. [MCPサーバー](./00-setup.md#set-up-mcp-servers)を設定していることを確認してください。

## カスタム指示を準備

1. 環境変数`$REPOSITORY_ROOT`を設定します。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. カスタム指示をコピーします。

    ```bash
    # bash/zsh
    cp -r $REPOSITORY_ROOT/docs/.github/. \
          $REPOSITORY_ROOT/.github/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/* `
              -Destination $REPOSITORY_ROOT/.github/ -Recurse -Force
    ```

## MCPサーバー開発を準備

`start`ディレクトリには、ASP.NET Core Minimal APIアプリがすでにスキャフォールドされています。これを出発点として使用します。

1. 環境変数`$REPOSITORY_ROOT`があることを確認してください。

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. スキャフォールドされたアプリを`start`から`workshop`にコピーします。

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cp -r $REPOSITORY_ROOT/start/. \
          $REPOSITORY_ROOT/workshop/
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    Copy-Item -Path $REPOSITORY_ROOT/start/* `
              -Destination $REPOSITORY_ROOT/workshop/ -Recurse -Force
    ```

## To-Doリスト管理ロジックを開発

1. `Claude Sonnet 4`または`GPT-4.1`モデルでGitHub Copilotエージェントモードを使用していることを確認してください。
1. `context7` MCPサーバーが稼働していることを確認してください。
1. 以下のようなプロンプトを使用してTo-Doリスト管理ロジックを実装します。

    ```text
    ASP.NET Coreを使用してTo-Doリストアプリケーションを開発したいと思います。指示に従ってください。

    - context7を使用してください。
    - 最初に実行する全てのステップを特定してください。
    - 作業ディレクトリは`workshop/src/McpTodoServer.ContainerApp`です。
    - アプリケーションには、ID、タイトル、説明、完了ステータス、作成日、更新日のプロパティを持つタスク管理のモデルを含める必要があります。
    - 必要に応じて、.NET 9と互換性のあるNuGetパッケージを追加してください。
    - To-Doリスト管理のAPIエンドポイントは実装しないでください。
    - 初期データは追加しないでください。
    - `complete`ディレクトリを参照しないでください。
    - `start`ディレクトリを参照しないでください。
    ```

1. GitHub Copilotの![the keep button image](https://img.shields.io/badge/keep-blue)ボタンをクリックして変更を適用します。

1. 以下のようなプロンプトを使用してTodoToolクラスを追加します。

    ```text
    アプリケーションに`TodoTool`クラスを追加したいと思います。指示に従ってください。

    - context7を使用してください。
    - 最初に実行する全てのステップを特定してください。
    - 作業ディレクトリは`workshop/src/McpTodoServer.ContainerApp`です。
    - `TodoTool`クラスには5つのメソッドが含まれている必要があります - 作成、一覧表示、更新、完了、削除。
    - 依存関係を登録しないでください。
    ```

1. GitHub Copilotの![the keep button image](https://img.shields.io/badge/keep-blue)ボタンをクリックして変更を適用します。

1. 以下のようなプロンプトを使用してアプリケーションをビルドします。

    ```text
    アプリケーションをビルドしたいと思います。指示に従ってください。

    - context7を使用してください。
    - アプリケーションをビルドし、正しくビルドされるかどうかを確認してください。
    - ビルドが失敗した場合は、問題を分析して修正してください。
    ```

   > **注**:
   >
   > - ビルドが成功するまでこのステップを繰り返してください。
   > - ビルドが失敗し続ける場合は、エラーメッセージを確認してGitHub Copilot Agentに解決を依頼してください。

## APIロジックを削除

1. GitHub Copilot Chatをエージェントモードで開きます。
1. 以下のようなプロンプトを使用してAPIロジックを削除します。

    ```text
    アプリケーションからすべてのAPIロジックを削除したいと思います。指示に従ってください。

    - context7を使用してください。
    - 最初に実行する全てのステップを特定してください。
    - 作業ディレクトリは`workshop/src/McpTodoServer.ContainerApp`です。
    - すべてのAPIエンドポイントを削除しますが、モデルとツールクラスは保持してください。
    - APIロジックを削除した後もアプリケーションがビルドされることを確認してください。
    ```

1. GitHub Copilotの![the keep button image](https://img.shields.io/badge/keep-blue)ボタンをクリックして変更を適用します。

## MCPサーバーに変換

1. GitHub Copilot Chatをエージェントモードで開きます。
1. 以下のようなプロンプトを使用してアプリケーションをMCPサーバーに変換します。

    ```text
    このアプリケーションをMCPサーバーに変換したいと思います。指示に従ってください。

    - context7を使用してください。
    - 最初に実行する全てのステップを特定してください。
    - 作業ディレクトリは`workshop/src/McpTodoServer.ContainerApp`です。
    - MCPに必要なNuGetパッケージを追加してください。
    - To-Doリスト管理リクエストを処理できるMCPサーバーを実装してください。
    - メソッドには以下を含める必要があります：タスク一覧表示、タスク作成、タスク更新、タスク完了、タスク削除。
    - 変換後にアプリケーションがビルドされることを確認してください。
    ```

1. GitHub Copilotの![the keep button image](https://img.shields.io/badge/keep-blue)ボタンをクリックして変更を適用します。

## MCPサーバーを実行

1. ターミナルを開いてアプリケーションディレクトリに移動します。

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. アプリケーションを実行します。

    ```bash
    dotnet run
    ```

   以下のような出力が表示されるはずです：

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    ```

## MCPサーバーをテスト

1. GitHub Copilot Chatをエージェントモードで開きます。
1. 以下のプロンプトのいずれかを入力します：

    ```text
    To-Doリストを表示してください。
    "12時にランチ"を追加してください。
    ランチを完了としてマークしてください。
    "午後3時に会議"を追加してください。
    会議を午後3時30分に変更してください。
    会議をキャンセルしてください。
    ```

1. エラーが発生した場合は、GitHub Copilotに修正を依頼してください：

    ```text
    "xxx"というエラーが発生しました。問題を見つけて修正してください。
    ```

---

完了しました。「MCPサーバー開発」ステップを完了しました。次は[ステップ02：MCPリモートサーバー](./02-mcp-remote-server.md)に進みましょう。

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../issues)を作成してください。