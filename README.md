# MCP Workshop for .NET

Are you interested in building an MCP server? What about an MCP client? Where would you like to run the MCP server - localhost or Azure? Let's build and deploy them!

## Workshop Objectives

- Build a to-do list MCP server in two different ways.
- Build a Blazor web app as an MCP client.
- Containerize the MCP server.
- Run the MCP server locally and remotely on Azure.
- Deploy the MCP server to Azure Container Apps.

## Workshop in Your Language

This workshop material is currently provided in the following languages:

[English](./README.md) | [Español](./localisation/es-es/) | [Français](./localisation/fr-fr/) | [日本語](./localisation/ja-jp/) | [한국어](./localisation/ko-kr/) | [Português](./localisation/pt-br/) | [中文(简体)](./localisation/zh-cn/)

## Prerequisites

- [Azure Subscription](https://azure.microsoft.com/free)

During this workshop, [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces) is highly recommended because there's no need for preparation, except a web browser.

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

However, if you really need to use your machine, make sure you've installed everything identified below.

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 For Windows users 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 or later
- [Docker Desktop](https://docs.docker.com/desktop/)

## Workshop Instructions

This is a self-paced workshop. Follow the step-by-step instructions in the workshop documentation:

| Step                                | Link                                                      |
|-------------------------------------|-----------------------------------------------------------|
| 00: Development Environment Setup   | [00-setup.md](./docs/00-setup.md)                         |
| 01: Monkey App Development with MCP | [01-monkey-app.md](./docs/01-monkey-app.md)               |
| 02: MCP Server Development          | [02-mcp-server.md](./docs/02-mcp-server.md)               |
| 03: MCP Remote Server Deployment    | [03-mcp-remote-server.md](./docs/03-mcp-remote-server.md) |
| 04: MCP Client Development          | [04-mcp-client.md](./docs/04-mcp-client.md)               |

## Complete Sample

If you get stuck while following the instructions above, you can find the complete example here 👉 [complete](./complete/)

## Read More...

- [MCP Official Documentation](https://modelcontextprotocol.io/)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [MCP C# Samples](https://github.com/microsoft/mcp-dotnet-samples)
- [GitHub Copilot Vibe Coding Workshop](https://github.com/microsoft/github-copilot-vibe-coding-workshop)
