using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static readonly Dictionary<string, int> accessCounts = new();
    private static readonly object lockObj = new();

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        using var httpClient = new HttpClient();
        // MCP 서버의 엔드포인트 URL을 실제로 입력해야 합니다.
        var url = "https://monkey-mcp-server.example.com/api/monkeys";
        var result = await httpClient.GetFromJsonAsync<List<Monkey>>(url);
        monkeys = result ?? new List<Monkey>();
        return monkeys;
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다(동기).
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        if (monkeys == null)
            throw new InvalidOperationException("먼저 GetMonkeysAsync를 호출해야 합니다.");
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (monkeys == null)
            throw new InvalidOperationException("먼저 GetMonkeysAsync를 호출해야 합니다.");
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 무작위 원숭이를 반환하고, 해당 원숭이의 액세스 횟수를 1 증가시킵니다.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        if (monkeys == null || monkeys.Count == 0)
            throw new InvalidOperationException("먼저 GetMonkeysAsync를 호출해야 합니다.");
        var random = new Random();
        var selected = monkeys[random.Next(monkeys.Count)];
        lock (lockObj)
        {
            if (!accessCounts.ContainsKey(selected.Name))
                accessCounts[selected.Name] = 0;
            accessCounts[selected.Name]++;
        }
        return selected;
    }

    /// <summary>
    /// 특정 원숭이의 무작위 선택 액세스 횟수를 반환합니다.
    /// </summary>
    public static int GetAccessCount(string name)
    {
        lock (lockObj)
        {
            return accessCounts.TryGetValue(name, out var count) ? count : 0;
        }
    }
}