# Atelier MCP pour .NET

Êtes-vous intéressé par la construction d'un serveur MCP ? Qu'en est-il d'un client MCP ? Où aimeriez-vous exécuter le serveur MCP - localhost ou Azure ? Construisons et déployons-les !

## Objectifs de l'Atelier

- Construire un serveur MCP de liste de tâches de deux manières différentes.
- Construire une application web Blazor comme client MCP.
- Containeriser le serveur MCP.
- Exécuter le serveur MCP localement et à distance sur Azure.
- Déployer le serveur MCP sur Azure Container Apps.

## Atelier dans Votre Langue

Ce matériel d'atelier est actuellement fourni dans les langues suivantes :

[English](../../README.md) | [Español](../es-es/) | [Français](./README.md) | [日本語](../ja-jp/) | [한국어](../ko-kr/) | [Português](../pt-br/) | [中文(简体)](../zh-cn/)

## Prérequis

- [Abonnement Azure](https://azure.microsoft.com/free)

Pendant cet atelier, [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces) est fortement recommandé car il n'y a pas besoin de préparation, à l'exception d'un navigateur web.

[![Ouvrir dans GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

Cependant, si vous avez vraiment besoin d'utiliser votre machine, assurez-vous d'avoir installé tout ce qui est identifié ci-dessous.

- [SDK .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - Extension [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Pour les utilisateurs Windows 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 ou ultérieur
- [Docker Desktop](https://docs.docker.com/desktop/)

## Instructions de l'Atelier

Ceci est un atelier à rythme personnel. Suivez les instructions étape par étape dans la documentation de l'atelier :

| Étape                              | Lien                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: Configuration de l'Environnement de Développement | [00-setup.md](./docs/00-setup.md)                         |
| 01: Développement d'App Monkey avec MCP | [01-monkey-app.md](./docs/01-monkey-app.md)               |
| 02: Développement du Serveur MCP        | [02-mcp-server.md](./docs/02-mcp-server.md)               |
| 03: Déploiement du Serveur MCP Distant  | [03-mcp-remote-server.md](./docs/03-mcp-remote-server.md) |
| 04: Développement du Client MCP        | [04-mcp-client.md](./docs/04-mcp-client.md)               |

## Échantillon Complet

Si vous êtes bloqué en suivant les instructions ci-dessus, vous pouvez trouver l'exemple complet ici 👉 [complete](./complete/)

## En Savoir Plus...

- [Documentation Officielle MCP](https://modelcontextprotocol.io/)
- [SDK MCP C#](https://github.com/modelcontextprotocol/csharp-sdk)
- [Échantillons MCP C#](https://github.com/microsoft/mcp-dotnet-samples)
- [Atelier GitHub Copilot Vibe Coding](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../issues).