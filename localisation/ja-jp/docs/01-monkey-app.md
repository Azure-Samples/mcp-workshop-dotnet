# 01: MCPを使ったMonkeyアプリ開発

このステップでは、MCPサーバーを使用してシンプルなコンソールアプリを構築します。

## 前提条件

準備については[README](../README.md#前提条件)ドキュメントを参照してください。

## 開始

- [GitHub Copilot エージェントモードの確認](#github-copilot-エージェントモードの確認)
- [MCPサーバーの開始 – GitHub](#mcpサーバーの開始--github)
- [カスタム指示の準備](#カスタム指示の準備)
- [コンソールアプリの作成](#コンソールアプリの作成)
- [GitHubリポジトリの管理](#githubリポジトリの管理)
- [MCPサーバーの開始 – Monkey MCP](#mcpサーバーの開始--monkey-mcp)
- [GitHub CopilotとMCPサーバーでMonkeyアプリを開発](#github-copilotとmcpサーバーでmonkeyアプリを開発)

## GitHub Copilot エージェントモードの確認

1. GitHub CodespaceまたはVS CodeのトップにあるGitHub Copilotアイコンをクリックし、GitHub Copilotウィンドウを開きます。

   ![GitHub Copilot Chatを開く](../../../docs/images/setup-01.png)

1. ログインまたはサインアップを求められた場合は実行してください。無料です。
1. GitHub Copilot エージェントモードを使用していることを確認してください。

   ![GitHub Copilot エージェントモード](../../../docs/images/setup-02.png)

1. モデルを`GPT-4.1`または`Claude Sonnet 4`のいずれかに選択してください。
1. [MCPサーバー](./00-setup.md#mcpサーバーをセットアップ)を設定していることを確認してください。

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
    現在の変更をリポジトリの`main`ブランチにプッシュしてください。
    ```

1. リポジトリにissueを生成するために、GitHub Copilotに以下のプロンプトを入力します。

    ```text
    私のリポジトリに「Monkey コンソールアプリケーションの実装」というタイトルで新しいGitHub issue を作成し、以下の要件を含めてください：
    
    - 利用可能なすべてのサルをリストし、名前で特定のサルの詳細を取得し、ランダムなサルを選ぶことができるC#コンソールアプリを作成する。
    - アプリはMonkeyモデルクラスを使用し、視覚的な魅力のためにASCII アートを含める必要がある。
    - 'enhancement' や 'good first issue' などの適切なラベルを追加する。
    - これをどのように実装するかについての詳細と、実行する必要があることのチェックリストを追加する。
    ```

1. issueに`@Copilot`をアサインし、何が起こっているかを観察します。

## MCPサーバーの開始 &ndash; Monkey MCP

1. `F1`または Windows では`Ctrl`+`Shift`+`P`、Mac OSでは`Cmd`+`Shift`+`P`を押してコマンドパレットを開き、`MCP: List Servers`を検索します。
1. `github` MCPサーバーが稼働していることを確認します。
1. `monkeymcp`を選択して`Start Server`をクリックします。

## GitHub CopilotとMCPサーバーでMonkeyアプリを開発

1. サルのリストを取得するために以下のプロンプトを入力します。

    ```text
    利用可能なサルのリストを取得し、詳細とともにテーブルで表示してください。
    ```

1. サルのデータモデルのアイデアを得るために以下のプロンプトを入力します。

    ```text
    この構造のデータモデルはどのようなものになりますか？
    ```

1. データモデルクラス用のファイルを作成するために以下のプロンプトを入力します。

    ```text
    このクラス用の新しいファイルを作成しましょう。
    ```

1. `MonkeyHelper`クラスを作成するために以下のプロンプトを入力します。

    ```text
    MonkeyHelperという静的な新しいクラスを作成しましょう。サルのデータのコレクションを管理する必要があります。すべてのサルを取得し、ランダムなサルを取得し、名前でサルを見つけ、ランダムなサルが選ばれたときのアクセス数を追跡するメソッドを含めてください。サルのデータは、先ほど取得したMonkey MCPサーバーから取得する必要があります。
    ```

1. コンソールアプリを更新するために以下のプロンプトを入力します。

    ```text
    その`MonkeyHelper`を呼び出す以下のオプションを持つ素敵なメニューを持つようにアプリを更新しましょう。
    
    1. すべてのサルをリスト
    2. 名前で特定のサルの詳細を取得
    3. ランダムなサルを取得
    4. アプリを終了

    また、面白いASCIIアートをランダムに表示してください。
    ```

1. 更新されたコンソールアプリをプッシュするために、GitHub Copilotに以下のプロンプトを入力します。

    ```text
    現在の変更をリポジトリの`mymonkeyapp`ブランチにプッシュしてください。
    変更をプッシュする前に、`workshop`ディレクトリがプッシュに含まれていることを確認してください。
    このブランチで、あなたのリポジトリの`main`ブランチに対してPRを作成してください。アップストリームではありません。
    このPRを以前に作成されたissueに接続してください。
    その後、このPRをマージしてissueを閉じてください。
    ```

---

OK。「MCPを使ったMonkeyアプリ開発」ステップが完了しました。[STEP 02: MCPサーバー](./02-mcp-server.md)に進みましょう。

---

この文書は[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、エラーが含まれている可能性があります。不適切または誤った翻訳を見つけた場合は、[issue](../../../../../issues)を作成してください。