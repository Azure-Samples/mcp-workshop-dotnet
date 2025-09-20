# Monkey 콘솔 애플리케이션 구현

요약
- 사용 가능한 모든 원숭이를 나열하고, 이름으로 특정 원숭이의 세부 정보를 가져오고, 무작위 원숭이를 선택할 수 있는 C# 콘솔 애플리케이션을 만듭니다.
- 앱은 `Monkey` 모델 클래스를 사용하고 시각적 매력을 위해 ASCII 아트를 포함해야 합니다.

요구사항
- CLI 명령 또는 상호작용 인터페이스로 다음을 지원해야 합니다:
  - 모든 원숭이 목록 보기 (예: `list`)
  - 이름으로 원숭이의 세부 정보 조회 (예: `show <name>`)
  - 무작위 원숭이 출력 (예: `random`)
- `Monkey` 모델은 최소한 다음 속성을 포함해야 함:
  - `Id` (int)
  - `Name` (string)
  - `Species` (string)
  - `Age` (int)
  - `Description` (string)
- ASCII 아트는 원숭이의 요약 또는 상세 출력에 포함되어야 함.
- 테스트(단위 테스트)와 샘플 데이터(예: JSON 파일)를 포함하는 것이 권장됨.

구현 세부사항
- 언어 및 런타임: C# (.NET 7 이상 권장)
- 프로젝트 구조 제안:
  - `src/Monkey.ConsoleApp/` - 콘솔 앱
  - `src/Monkey.Core/` - `Monkey` 모델 및 비즈니스 로직
  - `tests/Monkey.Tests/` - 단위 테스트
- 데이터 소스: `data/monkeys.json`와 같은 정적 JSON 파일로 초기 데이터 제공
- CLI 구현 옵션:
  - `System.CommandLine` 또는 간단한 커스텀 파서를 사용
- ASCII 아트: 각 원숭이 요약(한 줄) 또는 상세보기 시 큰 ASCII 아트 블록 출력

작업 체크리스트
- [ ] `Monkey` 모델 정의 (`src/Monkey.Core/Models/Monkey.cs`)
- [ ] 샘플 데이터 추가 (`data/monkeys.json`)
- [ ] 콘솔 앱 프로젝트 생성 및 기본 명령 구현 (`src/Monkey.ConsoleApp/`)
- [ ] `list`, `show <name>`, `random` 동작 구현
- [ ] ASCII 아트 출력 기능 추가
- [ ] 단위 테스트 추가 (`tests/Monkey.Tests/`)
- [ ] README 및 사용 예시 추가

라벨
- enhancement
- good first issue

세부 지침 / 구현 힌트
1. `Monkey` 모델과 JSON 직렬화/역직렬화를 위해 `System.Text.Json`을 사용하세요.
2. `data/monkeys.json`에는 최소 5개의 원숭이 항목을 포함하세요(다양한 나이/종).
3. `random` 명령은 `Random` 클래스를 사용해 선택하세요.
4. ASCII 아트는 `Resources/monkey.txt`처럼 파일로 분리하여 필요 시 로드하는 방식을 추천합니다.
5. 단위 테스트 예: `List_ReturnsAllMonkeys`, `Show_ReturnsMonkeyByName`, `Random_ReturnsMonkey`.

참고: 이 이슈는 새 기능(Enhancement)으로, 초보 기여자가 시작하기 좋은 작은 모듈화 작업입니다.
