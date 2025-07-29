이 프로젝트는 .NET 9를 사용하고 C# 13을 사용합니다.

생성된 모든 코드가 메인 폴더 내의 하위 폴더일 수 있는 MyMonkeyApp 프로젝트 내에 있는지 확인하세요.

GitHub에서 https://github.com/YOUR_USERNAME/YOUR_REPO_NAME 에 있습니다

## 프로젝트 컨텍스트
이것은 원숭이 종 데이터를 관리하고 MCP 서버를 통해 GitHub와 통합하는 콘솔 애플리케이션입니다.

## C# 코딩 표준
- 클래스 이름, 메서드 이름, 속성에는 PascalCase 사용
- 지역 변수와 매개변수에는 camelCase 사용
- 목적을 명확히 나타내는 설명적인 이름 사용
- 공개 메서드와 클래스에 XML 문서화 주석 추가
- 타입이 명확할 때 지역 변수에 `var` 사용
- 가독성이 향상될 때 명시적 타입 선호
- 비동기 작업에 async/await 사용
- 데이터 액세스에 리포지토리 패턴 따르기
- try-catch 블록으로 적절한 예외 처리 사용
- 리소스 관리 시 IDisposable 구현
- null 참조 예외를 피하기 위해 nullable 참조 타입 사용
- 더 깔끔한 코드 조직을 위해 파일 범위 네임스페이스 사용

## 명명 규칙
- 클래스: `MonkeyHelper`, `Monkey`, `Program`
- 메서드: `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`
- 속성: `Name`, `Location`, `Population`
- 변수: `selectedMonkey`, `monkeyCount`, `userInput`
- 상수: `MAX_MONKEYS`, `DEFAULT_POPULATION`

## 아키텍처
- 대화형 메뉴가 있는 콘솔 애플리케이션
- 데이터 관리를 위한 정적 도우미 클래스
- 데이터 표현을 위한 모델 클래스
- UI와 비즈니스 로직 간의 관심사 분리

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../../issues)를 생성해 주세요.