namespace ImageAnalysis;

/// <summary>
/// This represents the entity for image content.
/// </summary>
public class ImageContent
{
    /// <summary>
    /// Gets or sets the partition key of the Table Storage.
    /// </summary>
    public string? PartitionKey { get; set; }

    /// <summary>
    /// Gets or sets the row key of the Table Storage.
    /// </summary>
    public string? RowKey { get; set; }

    /// <summary>
    /// Gets or sets the image analysis text.
    /// </summary>
    public string? Text { get; set; }
}