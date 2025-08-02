using MyMonkeyApp.Data;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Services;

public class MonkeyService
{
    private readonly List<Monkey> _monkeys;
    private readonly Random _random;

    public MonkeyService()
    {
        _monkeys = MonkeyData.GetMonkeys();
        _random = new Random();
    }

    /// <summary>
    /// Get all monkeys
    /// </summary>
    /// <returns>List of all monkeys</returns>
    public List<Monkey> GetAllMonkeys()
    {
        return _monkeys;
    }

    /// <summary>
    /// Find a monkey by name (case-insensitive)
    /// </summary>
    /// <param name="name">Name of the monkey to search for</param>
    /// <returns>Monkey if found, null otherwise</returns>
    public Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Get a random monkey
    /// </summary>
    /// <returns>A randomly selected monkey</returns>
    public Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
            throw new InvalidOperationException("No monkeys available");

        int randomIndex = _random.Next(_monkeys.Count);
        return _monkeys[randomIndex];
    }

    /// <summary>
    /// Get the total number of monkeys
    /// </summary>
    /// <returns>Total count of monkeys</returns>
    public int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}