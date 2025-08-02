using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Static helper class for managing monkey data and operations.
/// </summary>
public static class MonkeyHelper
{
    /// <summary>
    /// Collection of all available monkeys.
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Habitat = "African savannas and grasslands",
            Population = 200000,
            Details = "Highly social primates that live in troops and are known for their distinctive calls and complex social structures.",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Habitat = "Central and South American rainforests",
            Population = 100000,
            Details = "Intelligent New World monkeys known for their problem-solving abilities and tool use.",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Habitat = "Japanese mountains and hot springs",
            Population = 50000,
            Details = "Also known as snow monkeys, famous for bathing in hot springs during winter.",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Habitat = "Brazilian Atlantic coastal forests",
            Population = 3000,
            Details = "Endangered small monkey with a distinctive golden mane, known for cooperative breeding.",
            ConservationStatus = "Endangered"
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Habitat = "Borneo mangrove forests",
            Population = 7000,
            Details = "Large-nosed primates that are excellent swimmers and live primarily in trees.",
            ConservationStatus = "Endangered"
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Habitat = "Central and South American rainforests",
            Population = 25000,
            Details = "Acrobatic primates with long limbs and prehensile tails, excellent at swinging through trees.",
            ConservationStatus = "Vulnerable"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Habitat = "Central and South American forests",
            Population = 40000,
            Details = "Known for their incredibly loud calls that can be heard up to 5 kilometers away.",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Mandrill",
            Habitat = "Equatorial African rainforests",
            Population = 15000,
            Details = "Largest primates in the world with colorful faces and complex social hierarchies.",
            ConservationStatus = "Vulnerable"
        }
    };

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A list of all monkey species.</returns>
    public static List<Monkey> GetAllMonkeys()
    {
        return new List<Monkey>(_monkeys);
    }

    /// <summary>
    /// Finds a monkey by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the collection.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        int index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Gets the total count of monkeys in the collection.
    /// </summary>
    /// <returns>The number of monkey species available.</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}