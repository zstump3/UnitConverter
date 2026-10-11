using System.Text.Json.Serialization;

namespace UnitConverter.Models;
/// <summary>
/// Represents one log event read from a Serilog JSON log file
/// </summary>
public class LogEntry
{
    /// <summary>
    /// Gets or sets the time the log event occured
    /// </summary>
    [JsonPropertyName("@t")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the rendered log message
    /// </summary>
    [JsonPropertyName("@m")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the Log level
    /// </summary>
    [JsonPropertyName("@l")]
    public string? Level { get; set; }

    /// <summary>
    /// Gets or sets the exception information
    /// </summary>
    [JsonPropertyName("@x")]
    public string? Exception { get; set; }

    /// <summary>
    /// Gets or sets the input value included in the log event
    /// </summary>
    public dynamic? Input { get; set; }

    /// <summary>
    /// Gets or sets the type of conversion included in the log event
    /// </summary>
    public string? ConversionType { get; set; }

    /// <summary>
    /// Gets or sets the conversion result included in the log event
    /// </summary>
    public dynamic? Result { get; set; }
}
