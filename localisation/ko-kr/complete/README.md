# MCP 서버: 할 일 앱

이것은 [Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview)에서 호스팅되는 MCP 서버로, 할 일 목록 항목을 관리합니다.

## 전제 조건

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- 다음을 포함한 [Visual Studio Code](https://code.visualstudio.com/)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit) 확장
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## 시작하기

- [ASP.NET Core MCP 서버를 로컬에서 실행](#aspnet-core-mcp-서버를-로컬에서-실행)
- [ASP.NET Core MCP 서버를 컨테이너에서 로컬 실행](#aspnet-core-mcp-서버를-컨테이너에서-로컬-실행)
- [ASP.NET Core MCP 서버를 원격으로 실행](#aspnet-core-mcp-서버를-원격으로-실행)
- [MCP 서버를 MCP 호스트/클라이언트에 연결](#mcp-서버를-mcp-호스트클라이언트에-연결)
  - [VS Code + 에이전트 모드 + 로컬 MCP 서버](#vs-code--에이전트-모드--로컬-mcp-서버)
  - [VS Code + 에이전트 모드 + 컨테이너의 로컬 MCP 서버](#vs-code--에이전트-모드--컨테이너의-로컬-mcp-서버)
  - [VS Code + 에이전트 모드 + 원격 MCP 서버](#vs-code--에이전트-모드--원격-mcp-서버)
  - [MCP Inspector + 로컬 MCP 서버](#mcp-inspector--로컬-mcp-서버)
  - [MCP Inspector + 컨테이너의 로컬 MCP 서버](#mcp-inspector--컨테이너의-로컬-mcp-서버)
  - [MCP Inspector + 원격 MCP 서버](#mcp-inspector--원격-mcp-서버)

### ASP.NET Core MCP 서버를 로컬에서 실행

1. 리포지토리 루트를 가져옵니다.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. MCP 서버 앱을 실행합니다.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### ASP.NET Core MCP 서버를 컨테이너에서 로컬 실행

1. 리포지토리 루트를 가져옵니다.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. MCP 서버 앱을 컨테이너 이미지로 빌드합니다.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. MCP 서버 앱을 컨테이너에서 실행합니다

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### ASP.NET Core MCP 서버를 원격으로 실행

1. Azure에 로그인합니다

    ```bash
    # Azure Developer CLI로 로그인
    azd auth login
    ```

1. MCP 서버 앱을 Azure에 배포합니다

    ```bash
    azd up
    ```

   프로비저닝 및 배포 중에 구독 ID, 위치, 환경 이름을 제공하라는 메시지가 표시됩니다.

1. 배포가 완료된 후 다음 명령을 실행하여 정보를 가져옵니다:

   - Azure Container Apps FQDN:

     ```bash
     azd env get-value AZURE_RESOURCE_MCP_TODO_LIST_FQDN
     ```

### MCP 서버를 MCP 호스트/클라이언트에 연결

#### VS Code + 에이전트 모드 + 로컬 MCP 서버

1. 리포지토리 루트를 가져옵니다.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. `mcp.json`을 리포지토리 루트에 복사합니다.

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. Windows에서는 `F1` 또는 `Ctrl`+`Shift`+`P`, Mac OS에서는 `Cmd`+`Shift`+`P`를 입력하여 명령 팔레트를 열고 `MCP: List Servers`를 검색합니다.
1. `mcp-todo-list-aca-local`을 선택한 후 `Start Server`를 클릭합니다.
1. 프롬프트를 입력합니다. 다음은 예시입니다:

    ```text
    - 할 일 목록을 보여주세요
    - "오전 11시 회의" 추가하기
    - 할 일 항목 #1 완료하기
    - 할 일 항목 #2 삭제하기
    ```

1. 결과를 확인합니다.

#### VS Code + 에이전트 모드 + 컨테이너의 로컬 MCP 서버

1. 리포지토리 루트를 가져옵니다.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. `mcp.json`을 리포지토리 루트에 복사합니다.

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. Windows에서는 `F1` 또는 `Ctrl`+`Shift`+`P`, Mac OS에서는 `Cmd`+`Shift`+`P`를 입력하여 명령 팔레트를 열고 `MCP: List Servers`를 검색합니다.
1. `mcp-todo-list-aca-container`를 선택한 후 `Start Server`를 클릭합니다.
1. 프롬프트를 입력합니다. 다음은 예시입니다:

    ```text
    - 할 일 목록을 보여주세요
    - "오전 11시 회의" 추가하기
    - 할 일 항목 #1 완료하기
    - 할 일 항목 #2 삭제하기
    ```

1. 결과를 확인합니다.

#### VS Code + 에이전트 모드 + 원격 MCP 서버

1. Windows에서는 `F1` 또는 `Ctrl`+`Shift`+`P`, Mac OS에서는 `Cmd`+`Shift`+`P`를 입력하여 명령 팔레트를 열고 `MCP: List Servers`를 검색합니다.
1. `mcp-todo-list-aca-remote`를 선택한 후 `Start Server`를 클릭합니다.
1. Azure Container Apps FQDN을 입력합니다.
1. 프롬프트를 입력합니다. 다음은 예시입니다:

    ```text
    - 할 일 목록을 보여주세요
    - "오전 11시 회의" 추가하기
    - 할 일 항목 #1 완료하기
    - 할 일 항목 #2 삭제하기
    ```

1. 결과를 확인합니다.

#### MCP Inspector + 로컬 MCP 서버

1. MCP Inspector를 실행합니다.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 웹 브라우저를 열고 앱에서 표시되는 URL에서 MCP Inspector 웹 앱으로 이동합니다 (예: http://localhost:6274)
1. 전송 유형을 `Streamable HTTP`로 설정합니다
1. 실행 중인 Function 앱의 Streamable HTTP 엔드포인트로 URL을 설정하고 **Connect**합니다:

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. **List Tools**를 클릭합니다.
1. 도구를 클릭하고 적절한 값으로 **Run Tool**합니다.

#### MCP Inspector + 컨테이너의 로컬 MCP 서버

1. MCP Inspector를 실행합니다.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 웹 브라우저를 열고 앱에서 표시되는 URL에서 MCP Inspector 웹 앱으로 이동합니다 (예: http://localhost:6274)
1. 전송 유형을 `Streamable HTTP`로 설정합니다
1. 실행 중인 Function 앱의 Streamable HTTP 엔드포인트로 URL을 설정하고 **Connect**합니다:

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. **List Tools**를 클릭합니다.
1. 도구를 클릭하고 적절한 값으로 **Run Tool**합니다.

#### MCP Inspector + 원격 MCP 서버

1. MCP Inspector를 실행합니다.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. 웹 브라우저를 열고 앱에서 표시되는 URL에서 MCP Inspector 웹 앱으로 이동합니다 (예: http://0.0.0.0:6274)
1. 전송 유형을 `Streamable HTTP`로 설정합니다
1. 실행 중인 Function 앱의 Streamable HTTP 엔드포인트로 URL을 설정하고 **Connect**합니다:

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. **List Tools**를 클릭합니다.
1. 도구를 클릭하고 적절한 값으로 **Run Tool**합니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../issues)를 생성해 주세요.