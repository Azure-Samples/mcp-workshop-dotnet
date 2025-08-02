using MyMonkeyApp.Models;
using System.Text.Json;

namespace MyMonkeyApp.Services;

/// <summary>
/// 원숭이 데이터를 관리하는 정적 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> _monkeys = new();
    private static readonly Dictionary<string, int> _accessCounts = new();
    private static readonly Random _random = new();
    private static bool _isInitialized = false;

    /// <summary>
    /// Monkey MCP 서버에서 모든 원숭이 목록을 가져옵니다
    /// </summary>
    /// <returns>원숭이 목록</returns>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (!_isInitialized)
        {
            await LoadMonkeysFromMcpAsync();
        }
        return new List<Monkey>(_monkeys);
    }

    /// <summary>
    /// 모든 원숭이 목록을 동기적으로 가져옵니다 (초기화되지 않은 경우 빈 목록 반환)
    /// </summary>
    /// <returns>원숭이 목록</returns>
    public static List<Monkey> GetMonkeys()
    {
        if (!_isInitialized)
        {
            Console.WriteLine("원숭이 데이터가 아직 로드되지 않았습니다. GetMonkeysAsync()를 먼저 호출하세요.");
            return new List<Monkey>();
        }
        return new List<Monkey>(_monkeys);
    }

    /// <summary>
    /// 이름으로 특정 원숭이를 찾습니다
    /// </summary>
    /// <param name="name">원숭이 이름</param>
    /// <returns>찾은 원숭이 또는 null</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        var monkey = _monkeys.FirstOrDefault(m =>
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));

        if (monkey != null)
        {
            IncrementAccessCount(monkey.Name);
        }

        return monkey;
    }

    /// <summary>
    /// 무작위 원숭이를 선택하고 액세스 횟수를 추적합니다
    /// </summary>
    /// <returns>무작위로 선택된 원숭이</returns>
    /// <exception cref="InvalidOperationException">원숭이 목록이 비어있을 때</exception>
    public static Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
        {
            throw new InvalidOperationException("원숭이 목록이 비어있습니다. 먼저 데이터를 로드하세요.");
        }

        var randomMonkey = _monkeys[_random.Next(_monkeys.Count)];
        IncrementAccessCount(randomMonkey.Name);

        return randomMonkey;
    }

    /// <summary>
    /// 특정 원숭이의 액세스 횟수를 가져옵니다
    /// </summary>
    /// <param name="monkeyName">원숭이 이름</param>
    /// <returns>액세스 횟수</returns>
    public static int GetAccessCount(string monkeyName)
    {
        return _accessCounts.TryGetValue(monkeyName, out var count) ? count : 0;
    }

    /// <summary>
    /// 모든 원숭이의 액세스 횟수를 가져옵니다
    /// </summary>
    /// <returns>원숭이 이름과 액세스 횟수의 딕셔너리</returns>
    public static Dictionary<string, int> GetAllAccessCounts()
    {
        return new Dictionary<string, int>(_accessCounts);
    }

    /// <summary>
    /// 액세스 횟수를 초기화합니다
    /// </summary>
    public static void ResetAccessCounts()
    {
        _accessCounts.Clear();
    }

    /// <summary>
    /// 현재 로드된 원숭이 수를 반환합니다
    /// </summary>
    /// <returns>원숭이 수</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }

    /// <summary>
    /// 데이터 로드 상태를 확인합니다
    /// </summary>
    /// <returns>데이터가 로드되었으면 true</returns>
    public static bool IsInitialized()
    {
        return _isInitialized;
    }

    /// <summary>
    /// 특정 원숭이의 액세스 횟수를 증가시킵니다
    /// </summary>
    /// <param name="monkeyName">원숭이 이름</param>
    private static void IncrementAccessCount(string monkeyName)
    {
        _accessCounts[monkeyName] = _accessCounts.TryGetValue(monkeyName, out var count) ? count + 1 : 1;
    }

    /// <summary>
    /// Monkey MCP 서버에서 원숭이 데이터를 로드합니다
    /// </summary>
    private static async Task LoadMonkeysFromMcpAsync()
    {
        try
        {
            // 실제 MCP 서버 호출 시뮬레이션
            // 실제 구현에서는 MCP 클라이언트를 통해 호출해야 합니다
            var sampleData = GetSampleMonkeyData();
            _monkeys = sampleData;
            _isInitialized = true;

            Console.WriteLine($"✅ {_monkeys.Count}마리의 원숭이 데이터를 성공적으로 로드했습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ 원숭이 데이터 로드 실패: {ex.Message}");
            _monkeys = new List<Monkey>();
        }
    }

    /// <summary>
    /// 샘플 원숭이 데이터를 제공합니다 (MCP 서버 연동 전 테스트용)
    /// </summary>
    /// <returns>샘플 원숭이 목록</returns>
    private static List<Monkey> GetSampleMonkeyData()
    {
        return new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
                Population = 10000,
                Latitude = -8.783195,
                Longitude = 34.508523
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
                Population = 23000,
                Latitude = 12.769013,
                Longitude = -85.602364
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
                Population = 1000,
                Latitude = 36.204824,
                Longitude = 138.252924
            }
        };
    }
}
