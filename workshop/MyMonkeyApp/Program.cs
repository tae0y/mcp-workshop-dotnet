
using System;
using System.Threading.Tasks;

class Program
{
    static readonly string[] AsciiArts = new[]
    {
			  @"                         .-""""-.  w
	  /  -   -  \
	 |  o   o  |
	 |    ^    |
	 |  '-'  |
	  \  ~  /
		'---'
		/   \
	  (     )
		`---'",
			  @"                   .-""""-.
		  / -   - \
		 |  o   o  |
		 |   .-.   |
		 |  (   )  |
		  \  ~  /
			`---'
		  /     \
		 (       )
		  `-----'",
			  @"                     .-""""-.
		  /  . .  \
		 |  o   o  |
		 |   ^     |
		 |  '-'    |
		  \  ~  /
			`---'
		  /     \
		 (       )
		  `-----'",
			  @"                      .-""""-.
		  /  o o  \
		 |   ^    |
		 |  '-'   |
		  \  ~  /
			`---'
		  /     \
		 (       )
		  `-----'"
    };

	static async Task Main(string[] args)
	{
		await MonkeyHelper.InitializeAsync();
		var running = true;
		var rand = new Random();
		while (running)
		{
			Console.Clear();
			// 랜덤 ASCII art 출력
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(AsciiArts[rand.Next(AsciiArts.Length)]);
			Console.ResetColor();
			Console.WriteLine("\n==== Monkey App ====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();
			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					running = false;
					Console.WriteLine("Goodbye!");
					break;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			if (running)
			{
				Console.WriteLine("\nPress any key to return to menu...");
				Console.ReadKey();
			}
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("\n{0,-20} {1,-25} {2,10}", "Name", "Location", "Population");
		Console.WriteLine(new string('-', 60));
		foreach (var m in monkeys)
		{
			Console.WriteLine("{0,-20} {1,-25} {2,10}", m.Name, m.Location, m.Population);
		}
	}

	static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
		if (monkey == null)
		{
			Console.WriteLine("Monkey not found.");
			return;
		}
		PrintMonkeyDetails(monkey);
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		PrintMonkeyDetails(monkey);
		Console.WriteLine($"(Random monkey picked {MonkeyHelper.GetRandomPickCount()} times)");
	}

	static void PrintMonkeyDetails(Monkey m)
	{
		Console.WriteLine($"Name: {m.Name}");
		Console.WriteLine($"Location: {m.Location}");
		Console.WriteLine($"Population: {m.Population}");
		Console.WriteLine($"Details: {m.Details}");
		Console.WriteLine($"Image: {m.Image}");
		Console.WriteLine($"Coordinates: {m.Latitude}, {m.Longitude}");
	}
}
