# Workshop MCP para .NET

Você está interessado em construir um servidor MCP? Que tal um cliente MCP? Onde você gostaria de executar o servidor MCP - localhost ou Azure? Vamos construir e implantá-los!

## Objetivos do Workshop

- Construir um servidor MCP de lista de tarefas de duas maneiras diferentes.
- Construir uma aplicação web Blazor como cliente MCP.
- Containerizar o servidor MCP.
- Executar o servidor MCP localmente e remotamente no Azure.
- Implantar o servidor MCP no Azure Container Apps.

## Workshop no Seu Idioma

Este material do workshop está atualmente disponível nos seguintes idiomas:

[English](../../README.md) | [Español](../es-es/) | [Français](../fr-fr/) | [日本語](../ja-jp/) | [한국어](../ko-kr/) | [Português](./README.md) | [中文(简体)](../zh-cn/)

## Pré-requisitos

- [Assinatura do Azure](https://azure.microsoft.com/free)

Durante este workshop, [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces) é altamente recomendado porque não há necessidade de preparação, exceto um navegador web.

[![Abrir no GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

No entanto, se você realmente precisar usar sua máquina, certifique-se de ter instalado tudo identificado abaixo.

- [SDK do .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - Extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Para usuários do Windows 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 ou posterior
- [Docker Desktop](https://docs.docker.com/desktop/)

## Instruções do Workshop

Este é um workshop de ritmo próprio. Siga as instruções passo a passo na documentação do workshop:

| Passo                              | Link                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: Configuração do Ambiente de Desenvolvimento | [00-setup.md](./docs/00-setup.md)                         |
| 01: Desenvolvimento de App Monkey com MCP | [01-monkey-app.md](./docs/01-monkey-app.md)               |
| 02: Desenvolvimento do Servidor MCP        | [02-mcp-server.md](./docs/02-mcp-server.md)               |
| 03: Implantação do Servidor MCP Remoto  | [03-mcp-remote-server.md](./docs/03-mcp-remote-server.md) |
| 04: Desenvolvimento do Cliente MCP        | [04-mcp-client.md](./docs/04-mcp-client.md)               |

## Amostra Completa

Se você ficar preso enquanto segue as instruções acima, pode encontrar o exemplo completo aqui 👉 [complete](./complete/)

## Leia Mais...

- [Documentação Oficial do MCP](https://modelcontextprotocol.io/)
- [SDK do MCP C#](https://github.com/modelcontextprotocol/csharp-sdk)
- [Amostras do MCP C#](https://github.com/microsoft/mcp-dotnet-samples)
- [Workshop GitHub Copilot Vibe Coding](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../../../issues).