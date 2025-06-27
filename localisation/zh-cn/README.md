# .NET MCP 工作坊

您是否有兴趣构建 MCP 服务器？MCP 客户端怎么样？您希望在哪里运行 MCP 服务器 - 本地主机还是 Azure？让我们一起构建和部署它们！

## 工作坊目标

- 以两种不同的方式构建待办事项列表 MCP 服务器。
- 构建 Blazor Web 应用作为 MCP 客户端。
- 容器化 MCP 服务器。
- 在本地和 Azure 上远程运行 MCP 服务器。
- 将 MCP 服务器部署到 Azure Container Apps。

## 您的语言版本工作坊

此工作坊材料目前提供以下语言版本：

[English](../../README.md) | [Español](../es-es/) | [Français](../fr-fr/) | [日本語](../ja-jp/) | [한국어](../ko-kr/) | [Português](../pt-br/) | [中文(简体)](./README.md)

## 先决条件

- [Azure 订阅](https://azure.microsoft.com/free)

在此工作坊期间，强烈推荐使用 [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces)，因为除了网络浏览器外，无需任何准备工作。

[![在 GitHub Codespaces 中打开](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

但是，如果您确实需要使用自己的机器，请确保已安装下面标识的所有内容。

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) 扩展
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Windows 用户 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 或更高版本
- [Docker Desktop](https://docs.docker.com/desktop/)

## 工作坊说明

这是一个自定进度的工作坊。请按照工作坊文档中的分步说明进行操作：

| 步骤                              | 链接                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: 开发环境设置 | [00-setup.md](./docs/00-setup.md)                         |
| 01: MCP 服务器开发        | [01-mcp-server.md](./docs/01-mcp-server.md)               |
| 02: MCP 远程服务器部署  | [02-mcp-remote-server.md](./docs/02-mcp-remote-server.md) |
| 03: MCP 客户端开发        | [03-mcp-client.md](./docs/03-mcp-client.md)               |

## 完整示例

如果您在按照上述说明操作时遇到困难，可以在这里找到完整的示例 👉 [complete](./complete/)

## 了解更多...

- [MCP 官方文档](https://modelcontextprotocol.io/)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [MCP C# 示例](https://github.com/microsoft/mcp-dotnet-samples)
- [GitHub Copilot Vibe Coding Workshop](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

本文档由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建 [issue](../../../../issues)。