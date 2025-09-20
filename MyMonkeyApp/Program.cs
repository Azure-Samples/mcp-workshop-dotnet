using System;
using MyMonkeyApp;

namespace MyMonkeyApp;

/// <summary>
/// Entry point for the Monkey Console Application.
/// </summary>
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Monkey Console App!");
            Console.WriteLine(MonkeyHelper.GetRandomAsciiArt());
            Console.WriteLine();
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("\nSelect an option (1-4): ");
            var input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    DisplayAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    DisplayRandomMonkey();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    private static void DisplayAllMonkeys()
    {
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine("+------------------------+---------------------------+------------+");
        Console.WriteLine("| Name                   | Location                  | Population |");
        Console.WriteLine("+------------------------+---------------------------+------------+");
        foreach (var m in monkeys)
        {
            Console.WriteLine($"| {m.Name,-22} | {m.Location,-25} | {m.Population,10} |");
        }
        Console.WriteLine("+------------------------+---------------------------+------------+");
    }

    private static void GetMonkeyByName()
    {
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine() ?? string.Empty;
        var monkey = MonkeyHelper.GetMonkeyByName(name);
        if (monkey is not null)
        {
            Console.WriteLine($"\nName: {monkey.Name}");
            Console.WriteLine($"Location: {monkey.Location}");
            Console.WriteLine($"Population: {monkey.Population}");
            Console.WriteLine($"ASCII Art: {monkey.AsciiArt}");
        }
        else
        {
            Console.WriteLine("Monkey not found.");
        }
    }

    private static void DisplayRandomMonkey()
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine($"\nName: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population}");
        Console.WriteLine($"ASCII Art: {monkey.AsciiArt}");
    }
}
