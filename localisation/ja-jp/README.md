# .NET 向け MCP ワークショップ

MCPサーバーの構築に興味はありますか？MCPクライアントはどうでしょうか？MCPサーバーはどこで実行したいですか - localhost か Azure か？それらを構築してデプロイしてみましょう！

## ワークショップの目標

- 2つの異なる方法でTo-DoリストMCPサーバーを構築する。
- MCPクライアントとしてBlazor Webアプリを構築する。
- MCPサーバーをコンテナ化する。
- MCPサーバーをローカルおよびAzure上でリモートで実行する。
- MCPサーバーをAzure Container Appsにデプロイする。

## あなたの言語でのワークショップ

このワークショップ資料は現在、以下の言語で提供されています：

[English](../../README.md) | [Español](../es-es/) | [Français](../fr-fr/) | [日本語](./README.md) | [한국어](../ko-kr/) | [Português](../pt-br/) | [中文(简体)](../zh-cn/)

## 前提条件

- [Azureサブスクリプション](https://azure.microsoft.com/free)

このワークショップでは、Webブラウザ以外の準備が不要なため、[GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces) を強く推奨します。

[![GitHub Codespaces で開く](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

ただし、本当にご自身のマシンを使用する必要がある場合は、以下で確認されたすべてをインストールしていることを確認してください。

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) 拡張機能
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Windows ユーザー向け 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7以降
- [Docker Desktop](https://docs.docker.com/desktop/)

## ワークショップの手順

これは自分のペースで進めるワークショップです。ワークショップドキュメントのステップバイステップの手順に従ってください：

| ステップ                              | リンク                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: 開発環境セットアップ | [00-setup.md](./docs/00-setup.md)                         |
| 01: MCPを使ったMonkeyアプリ開発 | [01-monkey-app.md](./docs/01-monkey-app.md)               |
| 02: MCPサーバー開発        | [02-mcp-server.md](./docs/02-mcp-server.md)               |
| 03: MCPリモートサーバーデプロイメント  | [03-mcp-remote-server.md](./docs/03-mcp-remote-server.md) |
| 04: MCPクライアント開発        | [04-mcp-client.md](./docs/04-mcp-client.md)               |

## 完全なサンプル

上記の手順を実行中に行き詰まった場合は、こちらで完全な例を見つけることができます 👉 [complete](./complete/)

## 詳細を読む...

- [MCP公式ドキュメント](https://modelcontextprotocol.io/)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [MCP C# サンプル](https://github.com/microsoft/mcp-dotnet-samples)
- [GitHub Copilot Vibe Coding ワークショップ](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

このドキュメントは[GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)によってローカライズされました。そのため、誤りが含まれる可能性があります。不適切または間違った翻訳を見つけた場合は、[issue](../../../../issues)を作成してください。