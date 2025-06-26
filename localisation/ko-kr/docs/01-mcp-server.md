# 01: MCP 서버

이 단계에서는 할 일 목록 관리를 위한 MCP 서버를 구축합니다.

## 전제 조건

준비를 위해 [README](../README.md#prerequisites) 문서를 참조하세요.

## 시작하기

- [GitHub Copilot 에이전트 모드 확인](#github-copilot-에이전트-모드-확인)
- [사용자 정의 지침 준비](#사용자-정의-지침-준비)
- [MCP 서버 개발 준비](#mcp-서버-개발-준비)
- [할 일 목록 관리 로직 개발](#할-일-목록-관리-로직-개발)
- [API 로직 제거](#api-로직-제거)
- [MCP 서버로 변환](#mcp-서버로-변환)
- [MCP 서버 실행](#mcp-서버-실행)
- [MCP 서버 테스트](#mcp-서버-테스트)

## GitHub Copilot 에이전트 모드 확인

1. GitHub Codespace 또는 VS Code 상단의 GitHub Copilot 아이콘을 클릭하고 GitHub Copilot 창을 엽니다.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. 로그인하거나 가입하라는 메시지가 표시되면 그렇게 하세요. 무료입니다.
1. GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-01.png)

1. 모델을 `GPT-4.1` 또는 `Claude Sonnet 4`로 선택합니다.
1. [MCP 서버](./00-setup.md#set-up-mcp-servers)를 구성했는지 확인하세요.

## 사용자 정의 지침 준비

1. `$REPOSITORY_ROOT` 환경 변수를 설정합니다.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 사용자 정의 지침을 복사합니다.

    ```bash
    # bash/zsh
    cp -r $REPOSITORY_ROOT/docs/.github/. \
          $REPOSITORY_ROOT/.github/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/* `
              -Destination $REPOSITORY_ROOT/.github/ -Recurse -Force
    ```

## MCP 서버 개발 준비

`start` 디렉토리에는 ASP.NET Core Minimal API 앱이 이미 스캐폴딩되어 있습니다. 이를 시작점으로 사용합니다.

1. `$REPOSITORY_ROOT` 환경 변수가 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 스캐폴딩된 앱을 `start`에서 `workshop`으로 복사합니다.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cp -r $REPOSITORY_ROOT/start/. \
          $REPOSITORY_ROOT/workshop/
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    Copy-Item -Path $REPOSITORY_ROOT/start/* `
              -Destination $REPOSITORY_ROOT/workshop/ -Recurse -Force
    ```

## 할 일 목록 관리 로직 개발

1. `Claude Sonnet 4` 또는 `GPT-4.1` 모델로 GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.
1. `context7` MCP 서버가 실행 중인지 확인하세요.
1. 다음과 같은 프롬프트를 사용하여 할 일 목록 관리 로직을 구현합니다.

    ```text
    ASP.NET Core를 사용하여 할 일 목록 애플리케이션을 개발하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - 애플리케이션에는 ID, 제목, 설명, 완료 상태, 생성 날짜, 업데이트 날짜 속성을 가진 작업 관리 모델이 포함되어야 합니다.
    - 필요한 경우 .NET 9와 호환되는 NuGet 패키지를 추가하세요.
    - 할 일 목록 관리를 위한 API 엔드포인트를 구현하지 마세요.
    - 초기 데이터를 추가하지 마세요.
    - `complete` 디렉토리를 참조하지 마세요.
    - `start` 디렉토리를 참조하지 마세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

1. 다음과 같은 프롬프트를 사용하여 TodoTool 클래스를 추가합니다.

    ```text
    애플리케이션에 `TodoTool` 클래스를 추가하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - `TodoTool` 클래스에는 5개의 메서드가 포함되어야 합니다 - 생성, 목록, 업데이트, 완료, 삭제.
    - 종속성을 등록하지 마세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

1. 다음과 같은 프롬프트를 사용하여 애플리케이션을 빌드합니다.

    ```text
    애플리케이션을 빌드하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 애플리케이션을 빌드하고 제대로 빌드되는지 확인하세요.
    - 빌드가 실패하면 문제를 분석하고 수정하세요.
    ```

   > **참고**:
   >
   > - 빌드가 성공할 때까지 이 단계를 반복하세요.
   > - 빌드가 계속 실패하면 오류 메시지를 확인하고 GitHub Copilot Agent에게 해결을 요청하세요.

## API 로직 제거

1. GitHub Copilot Chat을 에이전트 모드로 엽니다.
1. 다음과 같은 프롬프트를 사용하여 API 로직을 제거합니다.

    ```text
    애플리케이션에서 모든 API 로직을 제거하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - 모든 API 엔드포인트를 제거하되 모델과 도구 클래스는 유지하세요.
    - API 로직을 제거한 후에도 애플리케이션이 빌드되는지 확인하세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

## MCP 서버로 변환

1. GitHub Copilot Chat을 에이전트 모드로 엽니다.
1. 다음과 같은 프롬프트를 사용하여 애플리케이션을 MCP 서버로 변환합니다.

    ```text
    이 애플리케이션을 MCP 서버로 변환하고 싶습니다. 지침을 따르세요.

    - context7을 사용하세요.
    - 먼저 수행할 모든 단계를 식별하세요.
    - 작업 디렉토리는 `workshop/src/McpTodoServer.ContainerApp`입니다.
    - MCP에 필요한 NuGet 패키지를 추가하세요.
    - 할 일 목록 관리 요청을 처리할 수 있는 MCP 서버를 구현하세요.
    - 메서드에는 작업 목록, 작업 생성, 작업 업데이트, 작업 완료, 작업 삭제가 포함되어야 합니다.
    - 변환 후 애플리케이션이 빌드되는지 확인하세요.
    ```

1. GitHub Copilot의 ![the keep button image](https://img.shields.io/badge/keep-blue) 버튼을 클릭하여 변경 사항을 적용합니다.

## MCP 서버 실행

1. 터미널을 열고 애플리케이션 디렉토리로 이동합니다.

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. 애플리케이션을 실행합니다.

    ```bash
    dotnet run
    ```

   다음과 같은 출력이 표시되어야 합니다:

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    ```

## MCP 서버 테스트

1. GitHub Copilot Chat을 에이전트 모드로 엽니다.
1. 다음 프롬프트 중 하나를 입력합니다:

    ```text
    할 일 목록을 보여주세요.
    "오후 12시 점심"을 추가하세요.
    점심을 완료로 표시하세요.
    "오후 3시 회의"를 추가하세요.
    회의를 오후 3시 30분으로 변경하세요.
    회의를 취소하세요.
    ```

1. 오류가 발생하면 GitHub Copilot에게 수정을 요청하세요:

    ```text
    "xxx" 오류가 발생했습니다. 문제를 찾아서 수정해 주세요.
    ```

---

좋습니다. "MCP 서버 개발" 단계를 완료했습니다. 이제 [2단계: MCP 원격 서버](./02-mcp-remote-server.md)로 이동하겠습니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.