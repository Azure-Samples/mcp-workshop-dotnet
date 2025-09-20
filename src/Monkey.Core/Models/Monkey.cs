using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Monkey.Core.Models
{
    public class Monkey
    {
        public Monkey()
        {
            Tags = new List<string>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("species")]
        public string Species { get; set; } = string.Empty;

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("habitat")]
        public string? Habitat { get; set; }

        [JsonPropertyName("diet")]
        public string? Diet { get; set; }

        [JsonPropertyName("asciiArtFile")]
        public string? AsciiArtFile { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
