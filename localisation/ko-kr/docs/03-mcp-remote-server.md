# 03: MCP 원격 서버

이 단계에서는 MCP 서버를 Azure에 배포합니다.

## 전제 조건

준비를 위해 [README](../README.md#전제-조건) 문서를 참조하세요.

## 시작하기

- [`Dockerfile`로 MCP 서버 컨테이너화](#dockerfile로-mcp-서버-컨테이너화)
- [`azd`로 MCP 서버를 Azure에 배포](#azd로-mcp-서버를-azure에-배포)

## `Dockerfile`로 MCP 서버 컨테이너화

[이전 세션](./02-mcp-server.md)에서 이미 MCP 서버 앱을 만들었습니다. 계속 사용해보겠습니다.

1. Docker Desktop이 실행되고 있는지 확인하세요.
1. 환경 변수 `$REPOSITORY_ROOT`가 설정되어 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 앱 프로젝트로 이동합니다.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. `Dockerfile`을 만듭니다.

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. `Dockerfile`을 열고 아래 코드 라인을 추가한 후 저장합니다.

    ```dockerfile
    # syntax=docker/dockerfile:1
    
    FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
    
    COPY . /source
    
    WORKDIR /source/src/McpTodoServer.ContainerApp
    
    RUN dotnet publish -c Release -o /app
    
    FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
    
    WORKDIR /app
    
    COPY --from=build /app .
    
    USER $APP_UID
    
    ENTRYPOINT ["dotnet", "McpTodoServer.ContainerApp.dll"]
    ```

1. 컨테이너 이미지를 빌드합니다.

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. 컨테이너 이미지를 실행합니다.

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. `.vscode/mcp.json`을 열고 MCP 서버 URL을 컨테이너화된 MCP 서버로 교체합니다.

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // 이전
          "url": "http://localhost:5242/mcp"

          // 이후
          "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 추가 👆👆👆
      }
    }
    ```

1. MCP 서버 `mcp-todo`를 시작하고 [이 문서](./02-mcp-server.md#mcp-서버-테스트)를 따라 테스트합니다.
1. 테스트가 완료되면 컨테이너를 중지하고 제거합니다.

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## `azd`로 MCP 서버를 Azure에 배포

1. Azure에 로그인되어 있는지 확인하세요.

    ```bash
    azd auth login --check-status
    ```

   아직 로그인하지 않았다면 Azure 계정으로 `azd auth login`을 실행하세요.

1. 환경 변수 `$REPOSITORY_ROOT`가 설정되어 있는지 확인하세요.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. 앱 프로젝트로 이동합니다.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. `azd` 템플릿을 초기화합니다.

    ```bash
    azd init
    ```

   몇 가지 질문을 합니다. 다음 옵션을 선택하세요:

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   그러면 `azure.yaml` 파일이 생성됩니다.

1. `azure.yaml` 파일을 열고 다음 코드 라인으로 업데이트합니다.

    ```yml
    # yaml-language-server: $schema=https://raw.githubusercontent.com/Azure/azure-dev/main/schemas/v1.0/azure.yaml.json
    
    name: workshop
    metadata:
        template: azd-init@1.17.2
    services:
        mcptodoserver-containerapp:
            project: src/McpTodoServer.ContainerApp
            host: containerapp
            language: dotnet

            # 👇👇👇 추가 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 추가 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. MCP 서버를 배포합니다.

    ```bash
    azd up
    ```

   몇 가지 질문을 합니다:

   - `? Enter a unique environment name` 👉 아무 이름이나 입력하세요. 예: `mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 사용할 Azure 구독을 선택하세요.
   - `? Enter a value for the 'location' infrastructure parameter` 👉 MCP 서버를 배포할 위치를 선택하세요.

1. 완료되면 터미널에서 MCP 서버 URL을 찾을 수 있습니다. 이는 `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`와 같이 보입니다. 이 URL을 기록해 두세요.
1. `.vscode/mcp.json`을 열고 MCP 서버 URL을 배포된 MCP 서버로 교체합니다. `{{azure-container-apps-url}}`는 이전 단계에서 얻은 URL로 교체해야 합니다.

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // 이전
          "url": "http://localhost:8080/mcp"

          // 이후
          "url": "http://{{azure-container-apps-url}}/mcp"
        }
      }
    }
    ```

1. MCP 서버 `mcp-todo`를 시작하고 [이 문서](./02-mcp-server.md#mcp-서버-테스트)를 따라 테스트합니다.

---

좋습니다. "MCP 원격 서버 배포" 단계를 완료했습니다. 이제 [4단계: MCP 클라이언트](./04-mcp-client.md)로 이동하겠습니다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.
