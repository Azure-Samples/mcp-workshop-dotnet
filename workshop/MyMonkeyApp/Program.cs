using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 콘솔 애플리케이션의 메인 프로그램
/// </summary>
internal class Program
{
    private static readonly Random Random = new();

    /// <summary>
    /// 애플리케이션의 진입점
    /// </summary>
    /// <param name="args">명령줄 인수</param>
    private static async Task Main(string[] args)
    {
        Console.Clear();
        DisplayWelcomeMessage();
        DisplayRandomAsciiArt();

        // 원숭이 데이터 초기화
        Console.WriteLine("🔄 원숭이 데이터를 로드하는 중...");
        await MonkeyHelper.GetMonkeysAsync();

        // 메인 메뉴 루프
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine();
            DisplayMenu();

            var choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            continueRunning = await ProcessMenuChoice(choice);

            if (continueRunning)
            {
                Console.WriteLine("\nEnter 키를 눌러 계속하세요...");
                Console.ReadLine();
                Console.Clear();
                DisplayRandomAsciiArt();
            }
        }

        DisplayGoodbyeMessage();
    }

    /// <summary>
    /// 환영 메시지를 표시합니다
    /// </summary>
    private static void DisplayWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🐵 원숭이 정보 시스템에 오신 것을 환영합니다! 🐵");
        Console.WriteLine("다양한 원숭이 종에 대해 알아보세요!");
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// 작별 메시지를 표시합니다
    /// </summary>
    private static void DisplayGoodbyeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🍌 원숭이 정보 시스템을 이용해 주셔서 감사합니다! 🍌");
        Console.WriteLine("다음에 또 만나요!");
        DisplayRandomAsciiArt();
        Console.ResetColor();
    }

    /// <summary>
    /// 메인 메뉴를 표시합니다
    /// </summary>
    private static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("┌─────────────────────────────────────────────┐");
        Console.WriteLine("│             🐵 메인 메뉴 🐵                   │");
        Console.WriteLine("├─────────────────────────────────────────────┤");
        Console.WriteLine("│  1. 🐒 모든 원숭이 나열                       │");
        Console.WriteLine("│  2. 🔍 이름으로 원숭이 세부 정보 가져오기        │");
        Console.WriteLine("│  3. 🎲 무작위 원숭이 가져오기                  │");
        Console.WriteLine("│  4. 👋 앱 종료                               │");
        Console.WriteLine("└─────────────────────────────────────────────┘");
        Console.ResetColor();
        Console.Write("선택하세요 (1-4): ");
    }

    /// <summary>
    /// 메뉴 선택을 처리합니다
    /// </summary>
    /// <param name="choice">사용자 선택</param>
    /// <returns>계속 실행할지 여부</returns>
    private static async Task<bool> ProcessMenuChoice(string? choice)
    {
        switch (choice)
        {
            case "1":
                await DisplayAllMonkeys();
                break;
            case "2":
                await SearchMonkeyByName();
                break;
            case "3":
                DisplayRandomMonkey();
                break;
            case "4":
                return false;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ 잘못된 선택입니다. 1-4 사이의 숫자를 입력하세요.");
                Console.ResetColor();
                break;
        }

        return true;
    }

    /// <summary>
    /// 모든 원숭이를 표시합니다
    /// </summary>
    private static async Task DisplayAllMonkeys()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐒 모든 원숭이 목록:");
        Console.ResetColor();
        Console.WriteLine();

        var monkeys = await MonkeyHelper.GetMonkeysAsync();

        if (monkeys.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원숭이 데이터가 없습니다.");
            Console.ResetColor();
            return;
        }

        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{i + 1,2}. {monkey.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"    📍 위치: {monkey.Location}");
            Console.WriteLine($"    👥 개체수: {monkey.Population:N0}");
            Console.WriteLine($"    👁️ 조회수: {accessCount}");
            Console.ResetColor();
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"총 {monkeys.Count}마리의 원숭이가 등록되어 있습니다.");
        Console.ResetColor();
    }

    /// <summary>
    /// 이름으로 원숭이를 검색합니다
    /// </summary>
    private static async Task SearchMonkeyByName()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🔍 원숭이 이름으로 검색:");
        Console.ResetColor();
        Console.Write("원숭이 이름을 입력하세요: ");

        var name = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ 이름을 입력해 주세요.");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);

        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"❌ '{name}' 이름의 원숭이를 찾을 수 없습니다.");
            Console.ResetColor();

            // 유사한 이름 제안
            var monkeys = await MonkeyHelper.GetMonkeysAsync();
            var suggestions = monkeys
                .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Take(3)
                .ToList();

            if (suggestions.Any())
            {
                Console.WriteLine("\n💡 혹시 이런 원숭이를 찾고 계신가요?");
                foreach (var suggestion in suggestions)
                {
                    Console.WriteLine($"   • {suggestion.Name}");
                }
            }
        }
        else
        {
            DisplayMonkeyDetails(monkey);
        }
    }

    /// <summary>
    /// 무작위 원숭이를 표시합니다
    /// </summary>
    private static void DisplayRandomMonkey()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🎲 무작위 원숭이 선택:");
        Console.ResetColor();
        Console.WriteLine();

        try
        {
            var randomMonkey = MonkeyHelper.GetRandomMonkey();
            DisplayMonkeyDetails(randomMonkey);
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ {ex.Message}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// 원숭이의 상세 정보를 표시합니다
    /// </summary>
    /// <param name="monkey">표시할 원숭이</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);

        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"║  🐵 {monkey.Name.PadRight(54)} ║");
        Console.ResetColor();
        Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
        Console.WriteLine($"║  📍 위치: {monkey.Location.PadRight(49)} ║");
        Console.WriteLine($"║  👥 개체수: {monkey.Population:N0}".PadRight(61) + " ║");
        Console.WriteLine($"║  🌍 좌표: {monkey.Latitude:F2}, {monkey.Longitude:F2}".PadRight(61) + " ║");
        Console.WriteLine($"║  👁️ 조회수: {accessCount}".PadRight(61) + " ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
        Console.ForegroundColor = ConsoleColor.Gray;

        // 설명을 여러 줄로 나누어 표시
        var details = monkey.Details;
        const int maxWidth = 58;

        while (details.Length > 0)
        {
            var line = details.Length <= maxWidth
                ? details
                : details.Substring(0, Math.Min(maxWidth, details.LastIndexOf(' ', maxWidth)));

            if (string.IsNullOrEmpty(line))
            {
                line = details.Substring(0, Math.Min(maxWidth, details.Length));
            }

            Console.WriteLine($"║  {line.PadRight(58)} ║");
            details = details.Substring(line.Length).TrimStart();
        }

        Console.ResetColor();
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
    }

    /// <summary>
    /// 무작위 ASCII 아트를 표시합니다
    /// </summary>
    private static void DisplayRandomAsciiArt()
    {
        var asciiArts = new[]
        {
            @"
      🐵
    /|  |\\
   (_|  |_)",

            @"
        🍌
    🐒 /|\ 
      / \",

            @"
      .-""-.
     /     \\
    | o   o |
     \  ~  /
      '---'
     🐵",

            @"
    🐵 <- 안녕하세요!
   /|\\
   / \\",

            @"
      🙈🙉🙊
    (원숭이 삼총사)",

            @"
        🌴
    🐒 < 바나나 어디?
       \\",

            @"
    ┌─🍌─┐
    │ 🐵 │ 
    └─ω─┘"
        };

        var selectedArt = asciiArts[Random.Next(asciiArts.Length)];

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(selectedArt);
        Console.ResetColor();
        Console.WriteLine();
    }
}
