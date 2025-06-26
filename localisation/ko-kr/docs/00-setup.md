# 00: 개발 환경

이 단계에서는 워크샵을 위한 개발 환경을 설정합니다.

## 전제 조건

준비를 위해 [README](../README.md#prerequisites) 문서를 참조하세요.

## 시작하기

- [GitHub Codespaces 사용](#github-codespaces-사용)
- [Visual Studio Code 사용](#visual-studio-code-사용)
  - [PowerShell 설치 👉 Windows 사용자용](#powershell-설치--windows-사용자용)
  - [git CLI 설치](#git-cli-설치)
  - [GitHub CLI 설치](#github-cli-설치)
  - [Docker Desktop 설치](#docker-desktop-설치)
  - [Visual Studio Code 설치](#visual-studio-code-설치)
  - [Visual Studio Code 시작](#visual-studio-code-시작)
- [MCP 서버 설정](#mcp-서버-설정)
- [GitHub Copilot 에이전트 모드 확인](#github-copilot-에이전트-모드-확인)

## GitHub Codespaces 사용

1. 이 링크를 클릭하세요 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. GitHub Codespace 인스턴스가 준비되면 터미널을 열고 다음 명령을 실행하여 필요한 모든 것이 제대로 설치되었는지 확인합니다.

    ```bash
    # Node.js
    node --version
    npm --version
    ```

    ```bash
    # .NET SDK
    dotnet --list-sdks
    ```

    ```bash
    # PowerShell
    pwsh --version
    ```

1. 리포지토리 상태를 확인합니다.

    ```bash
    git remote -v
    ```

   다음 출력을 확인해야 합니다:

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   위와 다른 것이 보이면 GitHub Codespace 인스턴스를 삭제하고 다시 만드세요.

1. [MCP 서버 설정](#mcp-서버-설정) 섹션으로 이동하세요.

**👇👇👇 로컬 머신에서 VS Code를 사용하려면 아래 지침을 따르세요. 아래 섹션은 GitHub Codespaces를 사용하는 사람들에게는 적용되지 않습니다. 👇👇👇**

## Visual Studio Code 사용

### PowerShell 설치 👉 Windows 사용자용

Windows를 사용하는 경우 PowerShell을 설치해야 합니다. 이미 PowerShell이 설치되어 있다면 이 단계를 건너뛸 수 있습니다.

1. [PowerShell 공식 웹사이트](https://docs.microsoft.com/powershell/scripting/install/installing-powershell)로 가서 최신 버전을 설치하세요.

### git CLI 설치

이미 git CLI가 설치되어 있다면 이 단계를 건너뛸 수 있습니다.

1. [git 공식 웹사이트](https://git-scm.com/downloads)로 가서 최신 버전을 설치하세요.

### GitHub CLI 설치

이미 GitHub CLI가 설치되어 있다면 이 단계를 건너뛸 수 있습니다.

1. [GitHub CLI 공식 웹사이트](https://cli.github.com/)로 가서 최신 버전을 설치하세요.

### Docker Desktop 설치

이미 Docker Desktop이 설치되어 있다면 이 단계를 건너뛸 수 있습니다.

1. [Docker Desktop 공식 웹사이트](https://docs.docker.com/get-started/get-docker/)로 가서 최신 버전을 설치하세요.

### Visual Studio Code 설치

이미 Visual Studio Code가 설치되어 있다면 이 단계를 건너뛸 수 있습니다.

1. [Visual Studio Code 공식 웹사이트](https://code.visualstudio.com/)로 가서 최신 버전을 설치하세요.

### Visual Studio Code 시작

1. 터미널을 열고 다음 명령을 실행하여 이 리포지토리를 복제합니다:

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. 리포지토리 디렉토리로 이동합니다:

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Visual Studio Code를 엽니다:

    ```bash
    code .
    ```

## MCP 서버 설정

이 섹션에서는 워크샵용 MCP 서버를 설정합니다.

1. 필요한 Visual Studio Code 확장을 설치합니다. Visual Studio Code를 열고 확장 보기로 이동합니다 (`Ctrl+Shift+X` 또는 `Cmd+Shift+X`).

1. 다음 확장을 검색하고 설치합니다:
   - **C# Dev Kit** - .NET 개발용
   - **GitHub Copilot** - AI 지원용

1. 설치 후 Visual Studio Code를 다시 시작합니다.

1. 터미널에서 다음 명령을 실행하여 필요한 npm 패키지를 설치합니다:

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## GitHub Copilot 에이전트 모드 확인

1. GitHub Codespace 또는 VS Code 상단의 GitHub Copilot 아이콘을 클릭하고 GitHub Copilot 창을 엽니다.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-02.png)

1. 로그인하거나 가입하라는 메시지가 표시되면 그렇게 하세요. 무료입니다.
1. GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-03.png)

1. 모델을 `GPT-4.1` 또는 `Claude Sonnet 4`로 선택합니다.

---

좋습니다. "개발 환경" 단계를 완료했습니다. 이제 [1단계: MCP 서버](./01-mcp-server.md)로 이동하겠습니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../issues)를 생성해 주세요.