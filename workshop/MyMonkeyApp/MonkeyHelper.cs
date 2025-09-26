/// <summary>
/// Static helper class for managing monkey data and operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys;
    private static int _randomAccessCount = 0;

    /// <summary>
    /// Static constructor to initialize monkey data.
    /// </summary>
    static MonkeyHelper()
    {
        _monkeys = new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa",
                Details = "Baboons are terrestrial monkeys known for their dog-like snouts and colorful bottoms.",
                AsciiArt = @"
      .-""-.
     /     \
    | o   o |
     \  >  /
      '---'
    "
            },
            new Monkey
            {
                Name = "Capuchin",
                Location = "Central and South America",
                Details = "Capuchin monkeys are highly intelligent primates known for their problem-solving abilities.",
                AsciiArt = @"
    .-""-._.-""-._
   /             \
  |  o       o   |
   \      ^     /
    '.  \___/  .'
      '-----'
    "
            },
            new Monkey
            {
                Name = "Chimpanzee",
                Location = "Africa",
                Details = "Chimpanzees are our closest living relatives, sharing about 98% of human DNA.",
                AsciiArt = @"
     .-""""""-.
    /        \
   |  o    o  |
   |     <    |
    \   ---  /
     '......'
    "
            },
            new Monkey
            {
                Name = "Gibbon",
                Location = "Southeast Asia",
                Details = "Gibbons are small apes known for their incredible arm strength and swinging abilities.",
                AsciiArt = @"
    .-.   .-.
   (   \ /   )
    \   V   /
     |  o  |
     |  ^  |
     '---'
    "
            },
            new Monkey
            {
                Name = "Orangutan",
                Location = "Borneo and Sumatra",
                Details = "Orangutans are highly intelligent great apes with distinctive reddish-brown hair.",
                AsciiArt = @"
   .-""""""""""-.
  /            \
 |   o      o   |
 |      <>      |
  \    ____    /
   '...........'
    "
            },
            new Monkey
            {
                Name = "Macaque",
                Location = "Asia",
                Details = "Macaques are Old World monkeys known for their adaptability to various environments.",
                AsciiArt = @"
     .------.
    /        \
   |  @    @  |
   |     v    |
    \   ___  /
     '------'
    "
            }
        };
    }

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A read-only list of all monkeys.</returns>
    public static IReadOnlyList<Monkey> GetMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found, null otherwise.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the collection and increments the access count.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        _randomAccessCount++;
        var random = new Random();
        var index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    /// <returns>The count of random monkey accesses.</returns>
    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }
}