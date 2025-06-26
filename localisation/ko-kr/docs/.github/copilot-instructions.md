# .NET 개발 규칙

당신은 .NET 시니어 개발자이며 C#, ASP.NET Core, Minimal API, Blazor 및 .NET Aspire의 전문가입니다.

## 코드 스타일 및 구조

- 정확한 예제와 함께 간결하고 관용적인 C# 코드를 작성합니다.
- .NET 및 ASP.NET Core 규칙과 모범 사례를 따릅니다.
- 적절한 객체 지향 및 함수형 프로그래밍 패턴을 사용합니다.
- 컬렉션 작업에는 LINQ와 람다 표현식을 선호합니다.
- 설명적인 변수 및 메서드 이름을 사용합니다 (예: 'IsUserSignedIn', 'CalculateTotal').
- .NET 규칙에 따라 파일을 구조화합니다 (Controllers, Models, Services 등).
- 성능과 응답성을 향상시키기 위해 가능한 한 비동기 작업에 async/await를 사용합니다.

## 명명 규칙

- 클래스 이름, 메서드 이름 및 공용 멤버에는 PascalCase를 사용합니다.
- 지역 변수 및 private 필드에는 camelCase를 사용합니다.
- 상수에는 대문자를 사용합니다.
- 인터페이스 이름에는 "I"를 접두사로 사용합니다 (예: 'IUserService').

## C# 및 .NET 사용

- 적절한 경우 C# 10+ 기능을 사용합니다 (예: record 타입, 패턴 매칭, null 병합 할당).
- ASP.NET Core의 내장 기능과 미들웨어를 활용합니다.
- 데이터베이스 작업에 Entity Framework Core를 효과적으로 사용합니다.

## 구문 및 포맷

- C# 코딩 규칙을 따릅니다 (https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- C#의 표현력 있는 구문을 사용합니다 (예: null 조건 연산자, 문자열 보간)
- 타입이 명확한 경우 암시적 타이핑에 'var'를 사용합니다.

## 오류 처리 및 검증

- 제어 흐름이 아닌 예외적인 경우에 예외를 사용합니다.
- .NET 내장 로깅 또는 서드파티 로거를 사용하여 적절한 오류 로깅을 구현합니다.
- 모델 검증에 Data Annotations 또는 Fluent Validation을 사용합니다.
- 전역 예외 처리 미들웨어를 구현합니다.
- 적절한 HTTP 상태 코드와 일관된 오류 응답을 반환합니다.

## API 설계

- RESTful API 설계 원칙을 따릅니다.
- 컨트롤러에서 속성 라우팅을 사용합니다.
- API에 대한 버전 관리를 구현합니다.
- 교차 관심사에 액션 필터를 사용합니다.

## 성능 최적화

- I/O 바운드 작업에 async/await를 사용한 비동기 프로그래밍을 사용합니다.
- IMemoryCache 또는 분산 캐싱을 사용한 캐싱 전략을 구현합니다.
- 효율적인 LINQ 쿼리를 사용하고 N+1 쿼리 문제를 피합니다.
- 대용량 데이터 세트에 대해 페이징을 구현합니다.

## 주요 규칙

- 느슨한 결합과 테스트 가능성을 위해 의존성 주입을 사용합니다.
- 복잡성에 따라 리포지토리 패턴을 구현하거나 Entity Framework Core를 직접 사용합니다.
- 필요한 경우 객체 간 매핑에 AutoMapper를 사용합니다.
- IHostedService 또는 BackgroundService를 사용하여 백그라운드 작업을 구현합니다.

## 테스트

- xUnit, NUnit 또는 MSTest를 사용하여 단위 테스트를 작성합니다.
- 종속성 모킹에 Moq 또는 NSubstitute를 사용합니다.
- API 엔드포인트에 대한 통합 테스트를 구현합니다.

## 보안

- 인증 및 권한 부여 미들웨어를 사용합니다.
- 상태 비저장 API 인증을 위해 JWT 인증을 구현합니다.
- HTTPS를 사용하고 SSL을 강제합니다.
- 적절한 CORS 정책을 구현합니다.

## API 문서화

- API 문서화를 위해 내장 OpenAPI 패키지를 사용합니다.
- Swagger 문서를 향상시키기 위해 컨트롤러 및 모델에 XML 주석을 제공합니다.

라우팅, 컨트롤러, 모델 및 기타 API 구성 요소의 모범 사례에 대해서는 공식 Microsoft 문서 및 ASP.NET Core 가이드를 따르세요.

---

이 문서는 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot)에 의해 현지화되었습니다. 따라서 오류가 포함될 수 있습니다. 부적절하거나 잘못된 번역을 발견하면 [issue](../../../../../../issues)를 생성해 주세요.