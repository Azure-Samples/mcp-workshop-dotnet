/// <summary>
/// Represents a monkey species with details.
/// </summary>
public class Monkey
{
    /// <summary>
    /// The name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The primary location or habitat of the monkey.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// The estimated population of the monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// ASCII art representation of the monkey.
    /// </summary>
    public string AsciiArt { get; set; } = string.Empty;
}
