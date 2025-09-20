using System;
using System.Collections.Generic;

namespace MyMonkeyApp;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> monkeys = new()
    {
        new Monkey { Name = "Capuchin", Location = "Central & South America", Population = 100000, AsciiArt = "(\"( 0_0 )\")" },
        new Monkey { Name = "Mandrill", Location = "Central Africa", Population = 20000, AsciiArt = "( :{ )" },
        new Monkey { Name = "Howler", Location = "South America", Population = 50000, AsciiArt = "( o.o )~~" },
        new Monkey { Name = "Proboscis", Location = "Borneo", Population = 7000, AsciiArt = "( :O )" },
        new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 3200, AsciiArt = "( =^.^= )" }
    };

    private static readonly List<string> asciiArts = new()
    {
        "(\"( 0_0 )\")",
        "( :{ )",
        "( o.o )~~",
        "( :O )",
        "( =^.^= )",
        "( >_< )",
        "( ^_^ )",
        "( *_* )",
        "( 'o' )",
        "( @.@ )"
    };

    /// <summary>
    /// Gets all monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a monkey by name (case-insensitive).
    /// </summary>
    public static Monkey? GetMonkeyByName(string name) =>
        monkeys.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Gets a random monkey.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// Gets a random ASCII art.
    /// </summary>
    public static string GetRandomAsciiArt()
    {
        var rand = new Random();
        return asciiArts[rand.Next(asciiArts.Count)];
    }
}
