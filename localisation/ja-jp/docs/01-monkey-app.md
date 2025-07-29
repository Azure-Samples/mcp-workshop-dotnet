# 01: MCPを使ったMonkeyアプリ開発

このステップでは、MCPサーバーを使用してシンプルなコンソールアプリを構築します。

## 前提条件

準備については[README](../README.md#前提条件)ドキュメントを参照してください。

## 開始

- [GitHub Copilot エージェントモードの確認](#github-copilot-エージェントモードの確認)
- [カスタム指示の準備](#カスタム指示の準備)
- [MCPサーバー開発の準備](#mcpサーバー開発の準備)
- [To-doリスト管理ロジックの開発](#to-doリスト管理ロジックの開発)
- [APIロジックの削除](#apiロジックの削除)
- [MCPサーバーへの変換](#mcpサーバーへの変換)
- [MCPサーバーの実行](#mcpサーバーの実行)
- [MCPサーバーのテスト](#mcpサーバーのテスト)

## GitHub Copilot エージェントモードの確認

1. GitHub CodespaceまたはVS CodeのトップにあるGitHub Copilotアイコンをクリックし、GitHub Copilotウィンドウを開きます。

   ![GitHub Copilot Chatを開く](../../../docs/images/setup-01.png)

1. ログインまたはサインアップを求められた場合は実行してください。無料です。
1. GitHub Copilot エージェントモードを使用していることを確認してください。

   ![GitHub Copilot エージェントモード](../../../docs/images/setup-02.png)

1. モデルを`GPT-4.1`または`Claude Sonnet 4`のいずれかに選択してください。
1. [MCPサーバー](./00-setup.md#mcpサーバーのセットアップ)を設定していることを確認してください。

## MCPサーバーの開始 &ndash; GitHub

1. `F1`または Windows では`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`を押してコマンドパレットを開き、`MCP: List Servers`を検索します。
1. `github`を選択して`Start Server`をクリックします。このMCPサーバーを使用するためにGitHubにログインするよう求められる場合があります。

## カスタム指示の準備

1. `$REPOSITORY_ROOT`環境変数を設定します。

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
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. `.github/copilot-instructions.md`を開き、`https://github.com/YOUR_USERNAME/YOUR_REPO_NAME`をあなたのものに置き換えます。例：`https://github.com/octocat/monkey-app`。

## コンソールアプリの作成

1. `workshop`ディレクトリの下にコンソールアプリを作成します。

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

## GitHubリポジトリの管理

1. 作成したコンソールアプリをプッシュするために、GitHub Copilotに以下のプロンプトを入力します。

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. リポジトリにissueを生成するために、GitHub Copilotに以下のプロンプトを入力します。

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. issueに`@Copilot`をアサインし、何が起こっているかを観察します。

## MCPサーバーの開始 &ndash; Monkey MCP

1. `F1`または Windows では`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`を押してコマンドパレットを開き、`MCP: List Servers`を検索します。
1. `github` MCPサーバーが稼働していることを確認します。
1. `monkeymcp`を選択して`Start Server`をクリックします。

## GitHub CopilotとMCPサーバーでMonkeyアプリを開発

1. サルのリストを取得するために以下のプロンプトを入力します。

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. サルのデータモデルのアイデアを得るために以下のプロンプトを入力します。

    ```text
    What would a data model look like for this structure?
    ```

1. データモデルクラス用のファイルを作成するために以下のプロンプトを入力します。

    ```text
    Let's create a new file for this class.
    ```

1. `MonkeyHelper`クラスを作成するために以下のプロンプトを入力します。

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. コンソールアプリを更新するために以下のプロンプトを入力します。

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. 更新されたコンソールアプリをプッシュするために、GitHub Copilotに以下のプロンプトを入力します。

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK。「MCPを使ったMonkeyアプリ開発」ステップが完了しました。[STEP 02: MCPサーバー](./02-mcp-server.md)に進みましょう。