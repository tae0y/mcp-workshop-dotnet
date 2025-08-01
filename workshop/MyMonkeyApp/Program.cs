using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Explorer console application.
/// </summary>
class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        RunMonkeyExplorer();
    }

    /// <summary>
    /// Runs the main monkey explorer application loop.
    /// </summary>
    private static void RunMonkeyExplorer()
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.WelcomeBanner);
        
        bool keepRunning = true;
        
        while (keepRunning)
        {
            DisplayMainMenu();
            string? choice = Console.ReadLine()?.Trim();
            
            switch (choice?.ToLower())
            {
                case "1":
                case "list":
                    ListAllMonkeys();
                    break;
                case "2":
                case "search":
                    SearchMonkeyByName();
                    break;
                case "3":
                case "random":
                    ShowRandomMonkey();
                    break;
                case "4":
                case "exit":
                case "quit":
                    keepRunning = false;
                    ShowGoodbyeMessage();
                    break;
                default:
                    Console.WriteLine("\n❌ Invalid option. Please try again.\n");
                    break;
            }
            
            if (keepRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                try
                {
                    Console.ReadKey();
                }
                catch (InvalidOperationException)
                {
                    // Handle redirected input - just wait briefly instead
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    private static void DisplayMainMenu()
    {
        Console.WriteLine($"\n{AsciiArt.MenuSeparator}");
        Console.WriteLine("                            MAIN MENU");
        Console.WriteLine($"{AsciiArt.MenuSeparator}\n");
        
        Console.WriteLine($"{AsciiArt.MonkeyIcon} 1. List All Monkeys");
        Console.WriteLine($"{AsciiArt.MonkeyIcon} 2. Search Monkey by Name");
        Console.WriteLine($"{AsciiArt.MonkeyIcon} 3. Random Monkey");
        Console.WriteLine($"{AsciiArt.MonkeyIcon} 4. Exit");
        
        Console.WriteLine($"\n{AsciiArt.MenuSeparator}");
        Console.Write("Enter your choice (1-4): ");
    }

    /// <summary>
    /// Lists all available monkeys with their basic information.
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.ListAllBanner);
        
        var monkeys = MonkeyHelper.GetAllMonkeys();
        
        Console.WriteLine($"\n{AsciiArt.PopulationIcon} Total Species: {MonkeyHelper.GetMonkeyCount()}\n");
        Console.WriteLine($"{AsciiArt.MenuSeparator}");
        
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1,2}. {AsciiArt.MonkeyIcon} {monkey.Name}");
            Console.WriteLine($"     {AsciiArt.TreeIcon} Habitat: {monkey.Habitat}");
            Console.WriteLine($"     {AsciiArt.PopulationIcon} Population: {monkey.Population:N0}");
            Console.WriteLine($"     Status: {monkey.ConservationStatus}");
            
            if (i < monkeys.Count - 1)
                Console.WriteLine();
        }
        
        Console.WriteLine($"{AsciiArt.MenuSeparator}");
    }

    /// <summary>
    /// Searches for a monkey by name and displays its details.
    /// </summary>
    private static void SearchMonkeyByName()
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.SearchBanner);
        
        Console.Write("\nEnter monkey name: ");
        string? searchName = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrWhiteSpace(searchName))
        {
            Console.WriteLine("\n❌ Please enter a valid monkey name.");
            return;
        }
        
        var monkey = MonkeyHelper.GetMonkeyByName(searchName);
        
        if (monkey == null)
        {
            Console.WriteLine($"\n❌ No monkey found with the name '{searchName}'.");
            Console.WriteLine("\nAvailable monkeys:");
            var allMonkeys = MonkeyHelper.GetAllMonkeys();
            foreach (var m in allMonkeys)
            {
                Console.WriteLine($"  • {m.Name}");
            }
        }
        else
        {
            Console.WriteLine($"\n✅ Found: {monkey.Name}");
            DisplayMonkeyDetails(monkey);
        }
    }

    /// <summary>
    /// Displays a randomly selected monkey.
    /// </summary>
    private static void ShowRandomMonkey()
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.RandomBanner);
        
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        
        Console.WriteLine($"\n🎉 Your random monkey is: {randomMonkey.Name}!");
        DisplayMonkeyDetails(randomMonkey);
    }

    /// <summary>
    /// Displays detailed information about a specific monkey.
    /// </summary>
    /// <param name="monkey">The monkey to display details for.</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine($"\n{AsciiArt.MenuSeparator}");
        Console.WriteLine($"               {monkey.Name.ToUpper()} DETAILS");
        Console.WriteLine($"{AsciiArt.MenuSeparator}");
        
        Console.WriteLine($"\n{AsciiArt.MonkeyIcon} Name: {monkey.Name}");
        Console.WriteLine($"{AsciiArt.TreeIcon} Habitat: {monkey.Habitat}");
        Console.WriteLine($"{AsciiArt.PopulationIcon} Population: {monkey.Population:N0}");
        Console.WriteLine($"📊 Conservation Status: {monkey.ConservationStatus}");
        Console.WriteLine($"\n📝 Details:");
        Console.WriteLine($"   {monkey.Details}");
        
        Console.WriteLine($"\n{AsciiArt.MenuSeparator}");
    }

    /// <summary>
    /// Displays the goodbye message when exiting the application.
    /// </summary>
    private static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.GoodbyeMessage);
    }
}
