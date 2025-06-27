# Taller de MCP para .NET

¿Te interesa construir un servidor MCP? ¿Qué tal un cliente MCP? ¿Dónde te gustaría ejecutar el servidor MCP - localhost o Azure? ¡Vamos a construirlos y desplegarlos!

## Objetivos del Taller

- Construir un servidor MCP de lista de tareas de dos maneras diferentes.
- Construir una aplicación web Blazor como cliente MCP.
- Containerizar el servidor MCP.
- Ejecutar el servidor MCP localmente y remotamente en Azure.
- Desplegar el servidor MCP a Azure Container Apps.

## Taller en Tu Idioma

Este material del taller está actualmente disponible en los siguientes idiomas:

[English](../../README.md) | [Español](./README.md) | [Français](../fr-fr/) | [日本語](../ja-jp/) | [한국어](../ko-kr/) | [Português](../pt-br/) | [中文(简体)](../zh-cn/)

## Requisitos Previos

- [Suscripción de Azure](https://azure.microsoft.com/free)

Durante este taller, se recomienda encarecidamente [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces) porque no necesita preparación, excepto un navegador web.

[![Abrir en GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

Sin embargo, si realmente necesitas usar tu máquina, asegúrate de haber instalado todo lo identificado a continuación.

- [SDK de .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - Extensión [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Para usuarios de Windows 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 o posterior
- [Docker Desktop](https://docs.docker.com/desktop/)

## Instrucciones del Taller

Este es un taller de ritmo propio. Sigue las instrucciones paso a paso en la documentación del taller:

| Paso                              | Enlace                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: Configuración del Entorno de Desarrollo | [00-setup.md](./docs/00-setup.md)                         |
| 01: Desarrollo del Servidor MCP        | [01-mcp-server.md](./docs/01-mcp-server.md)               |
| 02: Despliegue del Servidor MCP Remoto  | [02-mcp-remote-server.md](./docs/02-mcp-remote-server.md) |
| 03: Desarrollo del Cliente MCP        | [03-mcp-client.md](./docs/03-mcp-client.md)               |

## Muestra Completa

Si te atascas mientras sigues las instrucciones anteriores, puedes encontrar el ejemplo completo aquí 👉 [complete](./complete/)

## Leer Más...

- [Documentación Oficial de MCP](https://modelcontextprotocol.io/)
- [SDK de MCP C#](https://github.com/modelcontextprotocol/csharp-sdk)
- [Muestras de MCP C#](https://github.com/microsoft/mcp-dotnet-samples)
- [Taller de GitHub Copilot Vibe Coding](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../issues).