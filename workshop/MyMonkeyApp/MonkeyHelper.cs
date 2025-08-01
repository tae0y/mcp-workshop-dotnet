using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static readonly Dictionary<string, int> randomAccessCounts = new();
    private static readonly HttpClient httpClient = new();
    private const string MonkeyApiUrl = "https://monkeymcp.azurewebsites.net/api/monkeys";

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys is not null)
            return monkeys;

        var response = await httpClient.GetStringAsync(MonkeyApiUrl);
        monkeys = JsonSerializer.Deserialize<List<Monkey>>(response) ?? new List<Monkey>();
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var list = await GetMonkeysAsync();
        return list.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 무작위 원숭이를 반환하고, 해당 원숭이의 선택 횟수를 기록합니다.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var list = await GetMonkeysAsync();
        if (list.Count == 0) return null;
        var random = new Random();
        var monkey = list[random.Next(list.Count)];
        if (randomAccessCounts.ContainsKey(monkey.Name))
            randomAccessCounts[monkey.Name]++;
        else
            randomAccessCounts[monkey.Name] = 1;
        return monkey;
    }

    /// <summary>
    /// 무작위 선택된 원숭이의 액세스 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomAccessCount(string name)
    {
        return randomAccessCounts.TryGetValue(name, out var count) ? count : 0;
    }
}
