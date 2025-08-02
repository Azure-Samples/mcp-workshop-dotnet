# 01: MCP를 사용한 Monkey 앱 개발

이 단계에서는 MCP 서버를 사용하여 간단한 콘솔 앱을 구축합니다.

## 전제 조건

준비에 대해서는 [README](../README.md#전제-조건) 문서를 참조하세요.

## 시작하기

- [GitHub Copilot 에이전트 모드 확인](#github-copilot-에이전트-모드-확인)
- [MCP 서버 시작 – GitHub](#mcp-서버-시작--github)
- [사용자 정의 지침 준비](#사용자-정의-지침-준비)
- [콘솔 앱 생성](#콘솔-앱-생성)
- [GitHub 저장소 관리](#github-저장소-관리)
- [MCP 서버 시작 – Monkey MCP](#mcp-서버-시작--monkey-mcp)
- [GitHub Copilot과 MCP 서버로 Monkey 앱 개발](#github-copilot과-mcp-서버로-monkey-앱-개발)

## GitHub Copilot 에이전트 모드 확인

1. GitHub Codespace 또는 VS Code 상단의 GitHub Copilot 아이콘을 클릭하고 GitHub Copilot 창을 엽니다.

   ![GitHub Copilot 채팅 열기](../../../docs/images/setup-01.png)

1. 로그인 또는 가입을 요청받으면 진행하세요. 무료입니다.
1. GitHub Copilot 에이전트 모드를 사용하고 있는지 확인하세요.

   ![GitHub Copilot 에이전트 모드](../../../docs/images/setup-02.png)

1. 모델을 `GPT-4.1` 또는 `Claude Sonnet 4` 중 하나로 선택하세요.
1. [MCP 서버](./00-setup.md#mcp-서버-설정)를 구성했는지 확인하세요.

## MCP 서버 시작 &ndash; GitHub

1. `F1` 또는 Windows에서 `Ctrl`+`Shift`+`P`, Mac OS에서 `Cmd`+`Shift`+`P`를 입력하여 명령 팔레트를 열고 `MCP: List Servers`를 검색합니다.
1. `github`을 선택한 다음 `Start Server`를 클릭합니다. 이 MCP 서버를 사용하기 위해 GitHub에 로그인하라는 메시지가 표시될 수 있습니다.

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
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. `.github/copilot-instructions.md`를 열고 `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME`을 여러분의 것으로 바꿉니다. 예: `https://github.com/octocat/monkey-app`.

## 콘솔 앱 생성

1. `workshop` 디렉토리 아래에 콘솔 앱을 생성합니다.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

## GitHub 저장소 관리

1. 생성된 콘솔 앱을 푸시하기 위해 GitHub Copilot에 다음 프롬프트를 입력합니다.

    ```text
    현재 변경사항을 저장소의 `main` 브랜치에 푸시하세요.
    ```

1. 저장소에 이슈를 생성하기 위해 GitHub Copilot에 다음 프롬프트를 입력합니다.

    ```text
    내 저장소에 'Monkey 콘솔 애플리케이션 구현'이라는 제목으로 다음 요구사항을 포함한 새 GitHub 이슈를 생성하세요:
    
    - 사용 가능한 모든 원숭이를 나열하고, 이름으로 특정 원숭이의 세부 정보를 가져오고, 무작위 원숭이를 선택할 수 있는 C# 콘솔 앱을 만드세요.
    - 앱은 Monkey 모델 클래스를 사용하고 시각적 매력을 위해 ASCII 아트를 포함해야 합니다.
    - 'enhancement' 및 'good first issue'와 같은 적절한 레이블을 추가하세요.
    - 이를 구현하는 방법에 대한 세부 정보와 수행해야 할 작업의 체크리스트를 추가하세요.
    ```

1. 이슈에 `@Copilot`을 할당하고 무슨 일이 일어나는지 관찰합니다.

## MCP 서버 시작 &ndash; Monkey MCP

1. `F1` 또는 Windows에서 `Ctrl`+`Shift`+`P`, Mac OS에서 `Cmd`+`Shift`+`P`를 입력하여 명령 팔레트를 열고 `MCP: List Servers`를 검색합니다.
1. `github` MCP 서버가 실행 중인지 확인합니다.
1. `monkeymcp`를 선택한 다음 `Start Server`를 클릭합니다.

## GitHub Copilot과 MCP 서버로 Monkey 앱 개발

1. 원숭이 목록을 얻기 위해 다음 프롬프트를 입력합니다.

    ```text
    사용 가능한 원숭이들의 목록을 가져와서 세부 정보와 함께 테이블로 표시해주세요.
    ```

1. 원숭이의 데이터 모델에 대한 아이디어를 얻기 위해 다음 프롬프트를 입력합니다.

    ```text
    이 구조에 대한 데이터 모델은 어떻게 생겼을까요?
    ```

1. 데이터 모델 클래스를 위한 파일을 생성하기 위해 다음 프롬프트를 입력합니다.

    ```text
    이 클래스를 위한 새 파일을 만들어 봅시다.
    ```

1. `MonkeyHelper` 클래스를 생성하기 위해 다음 프롬프트를 입력합니다.

    ```text
    MonkeyHelper라는 정적 클래스를 새로 만들어 봅시다. 원숭이 데이터의 컬렉션을 관리해야 합니다. 모든 원숭이를 가져오고, 무작위 원숭이를 가져오고, 이름으로 원숭이를 찾고, 무작위 원숭이가 선택될 때 액세스 횟수를 추적하는 메서드를 포함하세요. 원숭이 데이터는 방금 얻은 Monkey MCP 서버에서 가져와야 합니다.
    ```

1. 콘솔 앱을 업데이트하기 위해 다음 프롬프트를 입력합니다.

    ```text
    이제 `MonkeyHelper`를 호출할 다음 옵션들로 멋진 메뉴를 가지도록 앱을 업데이트해 봅시다.
    
    1. 모든 원숭이 나열
    2. 이름으로 특정 원숭이의 세부 정보 가져오기
    3. 무작위 원숭이 가져오기
    4. 앱 종료

    또한 재미있는 ASCII 아트를 무작위로 표시하세요.
    ```

1. 업데이트된 콘솔 앱을 푸시하기 위해 GitHub Copilot에 다음 프롬프트를 입력합니다.

    ```text
    현재 변경사항을 저장소의 `mymonkeyapp` 브랜치에 푸시하세요.
    변경 사항을 푸시하기 전에 `workshop` 디렉토리가 푸시에 포함되어 있는지 확인하세요.
    이 브랜치로 당신의 저장소의 `main` 브랜치에 대한 PR을 생성하세요. 업스트림이 아닙니다.
    이 PR을 이전에 생성된 이슈에 연결하세요.
    그런 다음 이 PR을 병합하고 이슈를 닫으세요.
    ```

---

좋습니다. "MCP를 사용한 Monkey 앱 개발" 단계를 완료했습니다. [STEP 02: MCP 서버](./02-mcp-server.md)로 이동합시다.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../issues)를 생성해 주세요.