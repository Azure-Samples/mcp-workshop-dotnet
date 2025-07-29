このプロジェクトは.NET 9を使用し、C# 13を使用しています。

生成されたすべてのコードは、メインフォルダー内のサブフォルダーである可能性があるMyMonkeyAppプロジェクト内にあることを確認してください。

GitHubの場所は https://github.com/YOUR_USERNAME/YOUR_REPO_NAME です

## プロジェクトのコンテキスト
これは、サルの種のデータを管理し、MCPサーバーを通じてGitHubと統合するコンソールアプリケーションです。

## C# コーディング標準
- クラス名、メソッド名、プロパティにはPascalCaseを使用する
- ローカル変数とパラメーターにはcamelCaseを使用する
- 目的を明確に示す記述的な名前を使用する
- パブリックメソッドとクラスにXMLドキュメンテーションコメントを追加する
- 型が明らかな場合はローカル変数に`var`を使用する
- 可読性が向上する場合は明示的な型を優先する
- 非同期操作にはasync/awaitを使用する
- データアクセスにはリポジトリパターンに従う
- try-catchブロックで適切な例外処理を使用する
- リソースを管理する際はIDisposableを実装する
- null参照例外を避けるためにnull許容参照型を使用する
- よりクリーンなコード組織のためにファイルスコープの名前空間を使用する

## 命名規則
- クラス: `MonkeyHelper`, `Monkey`, `Program`
- メソッド: `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`
- プロパティ: `Name`, `Location`, `Population`
- 変数: `selectedMonkey`, `monkeyCount`, `userInput`
- 定数: `MAX_MONKEYS`, `DEFAULT_POPULATION`

## アーキテクチャ
- インタラクティブメニュー付きコンソールアプリケーション
- データ管理用の静的ヘルパークラス
- データ表現用のモデルクラス
- UIとビジネスロジック間の関心の分離

---

この文書は[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、エラーが含まれている可能性があります。不適切または誤った翻訳を見つけた場合は、[issue](../../../../../../issues)を作成してください。