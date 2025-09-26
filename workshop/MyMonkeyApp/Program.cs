/// <summary>
/// Monkey Console Application - A fun interactive program to explore monkey data
/// </summary>

Console.Clear();
DisplayWelcomeBanner();

bool running = true;
while (running)
{
    DisplayMenu();
    var choice = Console.ReadLine()?.Trim();

    switch (choice)
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
            DisplayGoodbyeMessage();
            break;
        default:
            DisplayInvalidChoice();
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

/// <summary>
/// Displays the welcome banner with ASCII art.
/// </summary>
static void DisplayWelcomeBanner()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                                                          ║
    ║              🐵 MONKEY CONSOLE APPLICATION 🐵            ║
    ║                                                          ║
    ║            Explore the wonderful world of monkeys!      ║
    ║                                                          ║
    ╚══════════════════════════════════════════════════════════╝
    ");
    Console.ResetColor();
    
    // Display a random welcome monkey
    var welcomeMonkey = MonkeyHelper.GetRandomMonkey();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"    Welcome! Here's {welcomeMonkey.Name} to greet you:");
    Console.WriteLine(welcomeMonkey.AsciiArt);
    Console.ResetColor();
}

/// <summary>
/// Displays the main menu options.
/// </summary>
static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n" + new string('=', 50));
    Console.WriteLine("           🐒 MAIN MENU 🐒");
    Console.WriteLine(new string('=', 50));
    Console.ResetColor();
    
    Console.WriteLine("1. 📋 List all monkeys");
    Console.WriteLine("2. 🔍 Get details for a specific monkey by name");
    Console.WriteLine("3. 🎲 Get a random monkey");
    Console.WriteLine("4. 🚪 Exit application");
    Console.WriteLine();
    Console.Write("Please select an option (1-4): ");
}

/// <summary>
/// Lists all available monkeys with their basic information.
/// </summary>
static void ListAllMonkeys()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n🐵 ALL AVAILABLE MONKEYS 🐵\n");
    Console.ResetColor();

    var monkeys = MonkeyHelper.GetMonkeys();
    for (int i = 0; i < monkeys.Count; i++)
    {
        var monkey = monkeys[i];
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{i + 1}. {monkey.Name}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"   Location: {monkey.Location}");
        Console.WriteLine($"   Details: {monkey.Details}");
        Console.WriteLine();
        Console.ResetColor();
    }
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total monkeys available: {monkeys.Count}");
    Console.ResetColor();
}

/// <summary>
/// Prompts user for a monkey name and displays detailed information.
/// </summary>
static void GetMonkeyByName()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n🔍 FIND MONKEY BY NAME 🔍\n");
    Console.ResetColor();
    
    Console.Write("Enter the monkey name: ");
    var name = Console.ReadLine()?.Trim();
    
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Please enter a valid monkey name.");
        Console.ResetColor();
        return;
    }
    
    var monkey = MonkeyHelper.GetMonkeyByName(name);
    if (monkey != null)
    {
        DisplayMonkeyDetails(monkey);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ Sorry, no monkey found with the name '{name}'.");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n💡 Available monkeys:");
        var monkeys = MonkeyHelper.GetMonkeys();
        foreach (var availableMonkey in monkeys)
        {
            Console.WriteLine($"   • {availableMonkey.Name}");
        }
        Console.ResetColor();
    }
}

/// <summary>
/// Gets and displays a random monkey with statistics.
/// </summary>
static void GetRandomMonkey()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n🎲 RANDOM MONKEY SELECTION 🎲\n");
    Console.ResetColor();
    
    var randomMonkey = MonkeyHelper.GetRandomMonkey();
    
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("🎉 Here's your randomly selected monkey:");
    Console.ResetColor();
    
    DisplayMonkeyDetails(randomMonkey);
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"📊 Random monkey selections made: {MonkeyHelper.GetRandomAccessCount()}");
    Console.ResetColor();
}

/// <summary>
/// Displays detailed information about a specific monkey.
/// </summary>
/// <param name="monkey">The monkey to display details for.</param>
static void DisplayMonkeyDetails(Monkey monkey)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"\n🐒 {monkey.Name} 🐒");
    Console.WriteLine(new string('-', monkey.Name.Length + 6));
    Console.ResetColor();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(monkey.AsciiArt);
    Console.ResetColor();
    
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"📍 Location: {monkey.Location}");
    Console.WriteLine($"📝 Details: {monkey.Details}");
    Console.ResetColor();
}

/// <summary>
/// Displays an invalid choice message.
/// </summary>
static void DisplayInvalidChoice()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ Invalid choice! Please select a number between 1 and 4.");
    Console.ResetColor();
}

/// <summary>
/// Displays a goodbye message when exiting the application.
/// </summary>
static void DisplayGoodbyeMessage()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                                                          ║
    ║                    👋 GOODBYE! 👋                        ║
    ║                                                          ║
    ║              Thanks for exploring monkeys with us!      ║
    ║                                                          ║
    ╚══════════════════════════════════════════════════════════╝
    ");
    
    // Display a farewell monkey
    var farewellMonkeys = new[]
    {
        @"
       \   /
        \ /
         V
        /|\
       / | \
          |
         / \
        ",
        @"
      .-""-.
     /     \
    | ^   ^ |
     \  o  /
      '---'
     Bye! 👋
        ",
        @"
     .-.-.
    /     \
   |  @  @ |
   |   <   |
    \ ___ /
     '---'
        "
    };
    
    var random = new Random();
    var selectedArt = farewellMonkeys[random.Next(farewellMonkeys.Length)];
    Console.WriteLine(selectedArt);
    Console.ResetColor();
}
