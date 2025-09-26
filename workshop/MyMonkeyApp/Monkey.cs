/// <summary>
/// Represents a monkey with basic information and characteristics.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location where the monkey is typically found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional details about the monkey.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ASCII art representation of the monkey.
    /// </summary>
    public string AsciiArt { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the monkey.
    /// </summary>
    /// <returns>A formatted string containing the monkey's information.</returns>
    public override string ToString()
    {
        return $"{Name} - {Location}";
    }
}