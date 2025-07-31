# .NET용 MCP 워크샵

MCP 서버 구축에 관심이 있으신가요? MCP 클라이언트는 어떠세요? MCP 서버를 어디에서 실행하고 싶으신가요 - localhost 또는 Azure? 함께 구축하고 배포해보겠습니다!

## 워크샵 목표

- 두 가지 다른 방법으로 할 일 목록 MCP 서버 구축
- MCP 클라이언트로 Blazor 웹 앱 구축
- MCP 서버 컨테이너화
- MCP 서버를 로컬 및 Azure에서 원격으로 실행
- MCP 서버를 Azure Container Apps에 배포

## 당신의 언어로 된 워크샵

이 워크샵 자료는 현재 다음 언어로 제공됩니다:

[English](../../README.md) | [Español](../es-es/) | [Français](../fr-fr/) | [日本語](../ja-jp/) | [한국어](./README.md) | [Português](../pt-br/) | [中文(简体)](../zh-cn/)

## 전제 조건

- [Azure 구독](https://azure.microsoft.com/free)

이 워크샵 동안 웹 브라우저 외에는 준비가 필요하지 않기 때문에 [GitHub Codespaces](https://docs.github.com/codespaces/about-codespaces/what-are-codespaces)를 강력히 권장합니다.

[![GitHub Codespaces에서 열기](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

그러나 정말로 본인의 기기를 사용해야 한다면, 아래에서 확인된 모든 것이 설치되어 있는지 확인하세요.

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) 확장
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- 💥 Windows 사용자용 👉 [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 이상
- [Docker Desktop](https://docs.docker.com/desktop/)

## 워크샵 지침

이것은 자율 진행 워크샵입니다. 워크샵 문서의 단계별 지침을 따르세요:

| 단계                              | 링크                                                      |
|-----------------------------------|-----------------------------------------------------------|
| 00: 개발 환경 설정 | [00-setup.md](./docs/00-setup.md)                         |
| 01: MCP와 함께하는 Monkey 앱 개발 | [01-monkey-app.md](./docs/01-monkey-app.md)               |
| 02: MCP 서버 개발        | [02-mcp-server.md](./docs/02-mcp-server.md)               |
| 03: MCP 원격 서버 배포  | [03-mcp-remote-server.md](./docs/03-mcp-remote-server.md) |
| 04: MCP 클라이언트 개발        | [04-mcp-client.md](./docs/04-mcp-client.md)               |

## 완전한 샘플

위의 지침을 따르다가 막히면 여기에서 완전한 예제를 찾을 수 있습니다 👉 [complete](./complete/)

## 더 읽어보기...

- [MCP 공식 문서](https://modelcontextprotocol.io/)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [MCP C# 샘플](https://github.com/microsoft/mcp-dotnet-samples)
- [GitHub Copilot Vibe Coding 워크샵](https://github.com/microsoft/github-copilot-vibe-coding-workshop)

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../issues)를 생성해 주세요.