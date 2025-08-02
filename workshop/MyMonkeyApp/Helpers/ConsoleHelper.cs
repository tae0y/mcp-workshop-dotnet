using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

public static class ConsoleHelper
{
    public static void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                  🐵 MONKEY EXPLORER 🐒                   ║
    ║                                                          ║
    ║    .-""-.       .-""-.       .-""-.       .-""-.           ║
    ║   /     \     /     \     /     \     /     \          ║
    ║  | () () |   | ^   ^ |   | -   - |   | o   o |         ║
    ║   \  ^  /     \  -  /     \  o  /     \  ~  /          ║
    ║    |||||       |||||       |||||       |||||           ║
    ║    |||||       |||||       |||||       |||||           ║
    ║                                                          ║
    ║            Welcome to the Monkey Database!               ║
    ╚══════════════════════════════════════════════════════════╝
");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine("           MONKEY MENU OPTIONS");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        Console.WriteLine("1. 📋 List all monkeys");
        Console.WriteLine("2. 🔍 Search monkey by name");
        Console.WriteLine("3. 🎲 Get random monkey");
        Console.WriteLine("4. 🚪 Exit");
        Console.WriteLine();
        Console.Write("Please select an option (1-4): ");
    }

    public static void DisplayMonkeyList(List<Monkey> monkeys)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 ALL MONKEYS IN THE DATABASE 🐒");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1:D2}. {monkey.Image} {monkey.Name}");
            Console.WriteLine($"    Species: {monkey.Species}");
            Console.WriteLine($"    Location: {monkey.Location}");
            Console.WriteLine($"    Population: {monkey.Population:N0}");
            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Total: {monkeys.Count} monkey species found! 🎉");
        Console.ResetColor();
    }

    public static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🔍 MONKEY DETAILS");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        Console.WriteLine($"📛 Name: {monkey.Name} {monkey.Image}");
        Console.WriteLine($"🧬 Species: {monkey.Species}");
        Console.WriteLine($"🌍 Location: {monkey.Location}");
        Console.WriteLine($"🎂 Age: {monkey.Age} years");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"📍 Coordinates: {monkey.Latitude:F4}, {monkey.Longitude:F4}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("📖 Details:");
        Console.WriteLine($"   {monkey.Details}");
        Console.ResetColor();
    }

    public static void DisplayRandomMonkey(Monkey monkey)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    🎲 RANDOM MONKEY SELECTION! 🎲
    
         ╔═══════════════════════════════╗
         ║                               ║
         ║    🎰 *SPINNING THE WHEEL* 🎰  ║
         ║                               ║
         ╚═══════════════════════════════╝
");
        Console.ResetColor();
        
        // Simulate spinning animation
        Console.Write("Selecting");
        for (int i = 0; i < 5; i++)
        {
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
        }
        Console.WriteLine();
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🎉 YOUR RANDOM MONKEY IS: 🎉");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        DisplayMonkeyDetails(monkey);
    }

    public static void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ Error: {message}");
        Console.ResetColor();
    }

    public static void DisplayNotFound(string searchTerm)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"😞 No monkey found with name: '{searchTerm}'");
        Console.WriteLine("💡 Tip: Try checking the spelling or search for a different monkey.");
        Console.ResetColor();
    }

    public static void DisplayInvalidOption()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Invalid option! Please select a number between 1 and 4.");
        Console.ResetColor();
    }

    public static void DisplayGoodbye()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                                                          ║
    ║    🐵 Thanks for using Monkey Explorer! 🐒               ║
    ║                                                          ║
    ║         \o/     \o/     \o/     \o/                      ║
    ║          |       |       |       |                      ║
    ║         / \     / \     / \     / \                     ║
    ║                                                          ║
    ║            See you next time! 👋                         ║
    ║                                                          ║
    ╚══════════════════════════════════════════════════════════╝
");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }
}