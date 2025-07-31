# 00: 개발 환경

이 단계에서는 워크샵을 위한 개발 환경을 설정합니다.

## 전제 조건

준비를 위해 [README](../README.md#전제-조건) 문서를 참조하세요.

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

1. PowerShell이 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   `pwsh`의 명령 경로가 보이지 않으면 PowerShell이 아직 설치되지 않았다는 의미입니다. [PowerShell 설치 페이지](https://learn.microsoft.com/powershell/scripting/install/installing-powershell)를 방문하여 지침을 따르세요.

1. PowerShell 버전을 확인하세요.

    ```bash
    pwsh --version
    ```

   버전 `7.5.0` 이상이 권장됩니다. 버전이 그보다 낮다면 [PowerShell 설치 페이지](https://learn.microsoft.com/powershell/scripting/install/installing-powershell)를 방문하여 지침을 따르세요.

### node.js 설치

1. node.js가 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   `node`의 명령 경로가 보이지 않는다면 아직 node.js를 설치하지 않았다는 의미입니다. [node.js 다운로드 페이지](https://nodejs.org/en/download)를 방문하여 지침을 따르세요.

1. node.js 버전을 확인하세요.

    ```bash
    node --version
    ```

   버전 `22.17.x` (최신 LTS)가 권장됩니다. 버전이 그보다 낮다면 [node.js 다운로드 페이지](https://nodejs.org/en/download)를 방문하여 지침을 따르세요.

### git CLI 설치

1. git CLI가 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   `git`의 명령 경로가 보이지 않으면 git CLI가 아직 설치되지 않았다는 의미입니다. [git CLI 설치 페이지](https://git-scm.com/downloads)를 방문하여 지침을 따르세요.

1. git CLI 버전을 확인하세요.

    ```bash
    git --version
    ```

   버전 `2.39.0` 이상이 권장됩니다. 버전이 그보다 낮다면 [git CLI 설치 페이지](https://git-scm.com/downloads)를 방문하여 지침을 따르세요.

### GitHub CLI 설치

1. GitHub CLI가 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   `gh`의 명령 경로가 보이지 않으면 GitHub CLI가 아직 설치되지 않았다는 의미입니다. [GitHub CLI 설치 페이지](https://cli.github.com/)를 방문하여 지침을 따르세요.

1. GitHub CLI 버전을 확인하세요.

    ```bash
    gh --version
    ```

   버전 `2.65.0` 이상이 권장됩니다. 버전이 그보다 낮다면 [GitHub CLI 설치 페이지](https://cli.github.com/)를 방문하여 지침을 따르세요.

1. GitHub에 로그인했는지 확인하세요.

    ```bash
    gh auth status
    ```

   아직 로그인하지 않았다면 `gh auth login`을 실행하여 로그인하세요.

### Docker Desktop 설치

1. Docker Desktop이 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   `docker`의 명령 경로가 보이지 않으면 Docker Desktop이 아직 설치되지 않았다는 의미입니다. [Docker Desktop 설치 페이지](https://docs.docker.com/get-started/introduction/get-docker-desktop/)를 방문하여 지침을 따르세요.

1. Docker CLI 버전을 확인하세요.

    ```bash
    docker --version
    ```

   버전 `28.0.4` 이상이 권장됩니다. 버전이 그보다 낮다면 [Docker Desktop 설치 페이지](https://docs.docker.com/get-started/introduction/get-docker-desktop/)를 방문하여 지침을 따르세요.

### Visual Studio Code 설치

1. VS Code가 이미 설치되어 있는지 확인하세요.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   `code`의 명령 경로가 보이지 않으면 VS Code가 아직 설치되지 않았다는 의미입니다. [Visual Studio Code 설치 페이지](https://code.visualstudio.com/)를 방문하여 지침을 따르세요.

1. VS Code 버전을 확인하세요.

    ```bash
    code --version
    ```

   버전 `1.99.0` 이상이 권장됩니다. 버전이 그보다 낮다면 [Visual Studio Code 설치 페이지](https://code.visualstudio.com/)를 방문하여 지침을 따르세요.

   > **참고**: `code` 명령을 실행할 수 없을 수도 있습니다. 이 경우 설정을 위해 [이 문서](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line)를 따르세요.

### Visual Studio Code 시작

1. 작업 디렉토리를 생성합니다.
1. 이 리포지토리를 포크하고 로컬 머신에 복제하는 명령을 실행합니다.

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. 복제된 디렉토리로 이동합니다.

    ```bash
    cd mcp-workshop-dotnet
    ```

1. 터미널에서 VS Code를 실행합니다.

    ```bash
    code .
    ```

1. VS Code 내에서 새 터미널을 열고 다음 명령을 실행하여 리포지토리 상태를 확인합니다.

    ```bash
    git remote -v
    ```

   다음 출력을 확인해야 합니다. `origin`에서 `Azure-Samples`가 보이면 포크된 리포지토리에서 다시 복제해야 합니다.

    ```bash
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. 두 확장이 모두 설치되었는지 확인하세요: [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) 및 [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   아무것도 보이지 않으면 해당 확장이 아직 설치되지 않았다는 의미입니다. 다음 명령을 실행하여 확장을 설치하세요.

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## MCP 서버 설정

1. `$REPOSITORY_ROOT` 환경 변수를 설정합니다.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. MCP 서버 설정을 복사합니다.

    ```bash
    # bash/zsh
    cp -r $REPOSITORY_ROOT/docs/.vscode/. \
          $REPOSITORY_ROOT/.vscode/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/* `
              -Destination $REPOSITORY_ROOT/.vscode/ -Recurse -Force
    ```

## GitHub Copilot 에이전트 모드 확인

1. GitHub Codespace 또는 VS Code 상단의 GitHub Copilot 아이콘을 클릭하고 GitHub Copilot 창을 엽니다.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. 로그인하거나 가입하라는 메시지가 표시되면 그렇게 하세요. 무료입니다.
1. GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. 모델을 `GPT-4.1` 또는 `Claude Sonnet 4`로 선택합니다.

---

좋습니다. "개발 환경" 단계를 완료했습니다. 이제 [1단계: MCP 서버](./01-mcp-server.md)로 이동하겠습니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.