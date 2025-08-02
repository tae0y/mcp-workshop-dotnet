using MyMonkeyApp.Helpers;
using MyMonkeyApp.Services;

namespace MyMonkeyApp;

class Program
{
    private static MonkeyService? _monkeyService;
    
    static void Main(string[] args)
    {
        try
        {
            _monkeyService = new MonkeyService();
            RunApplication();
        }
        catch (Exception ex)
        {
            ConsoleHelper.DisplayError($"An unexpected error occurred: {ex.Message}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    private static void RunApplication()
    {
        ConsoleHelper.DisplayWelcomeMessage();
        ConsoleHelper.PressAnyKeyToContinue();

        bool continueRunning = true;
        
        while (continueRunning)
        {
            try
            {
                Console.Clear();
                ConsoleHelper.DisplayMenu();
                
                string input = Console.ReadLine() ?? string.Empty;
                
                switch (input.Trim())
                {
                    case "1":
                        DisplayAllMonkeys();
                        break;
                    case "2":
                        SearchMonkeyByName();
                        break;
                    case "3":
                        DisplayRandomMonkey();
                        break;
                    case "4":
                        continueRunning = false;
                        ConsoleHelper.DisplayGoodbye();
                        break;
                    default:
                        ConsoleHelper.DisplayInvalidOption();
                        ConsoleHelper.PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError($"An error occurred: {ex.Message}");
                ConsoleHelper.PressAnyKeyToContinue();
            }
        }
    }

    private static void DisplayAllMonkeys()
    {
        try
        {
            var monkeys = _monkeyService!.GetAllMonkeys();
            ConsoleHelper.DisplayMonkeyList(monkeys);
            ConsoleHelper.PressAnyKeyToContinue();
        }
        catch (Exception ex)
        {
            ConsoleHelper.DisplayError($"Failed to load monkeys: {ex.Message}");
            ConsoleHelper.PressAnyKeyToContinue();
        }
    }

    private static void SearchMonkeyByName()
    {
        try
        {
            Console.Clear();
            string searchName = ConsoleHelper.GetUserInput("🔍 Enter monkey name to search: ");
            
            if (string.IsNullOrWhiteSpace(searchName))
            {
                ConsoleHelper.DisplayError("Please enter a valid monkey name.");
                ConsoleHelper.PressAnyKeyToContinue();
                return;
            }

            var monkey = _monkeyService!.FindMonkeyByName(searchName.Trim());
            
            if (monkey != null)
            {
                ConsoleHelper.DisplayMonkeyDetails(monkey);
            }
            else
            {
                ConsoleHelper.DisplayNotFound(searchName);
            }
            
            ConsoleHelper.PressAnyKeyToContinue();
        }
        catch (Exception ex)
        {
            ConsoleHelper.DisplayError($"Failed to search for monkey: {ex.Message}");
            ConsoleHelper.PressAnyKeyToContinue();
        }
    }

    private static void DisplayRandomMonkey()
    {
        try
        {
            var randomMonkey = _monkeyService!.GetRandomMonkey();
            ConsoleHelper.DisplayRandomMonkey(randomMonkey);
            ConsoleHelper.PressAnyKeyToContinue();
        }
        catch (Exception ex)
        {
            ConsoleHelper.DisplayError($"Failed to get random monkey: {ex.Message}");
            ConsoleHelper.PressAnyKeyToContinue();
        }
    }
}
