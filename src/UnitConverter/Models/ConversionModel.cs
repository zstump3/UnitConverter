namespace UnitConverter.Models;
/// <summary>
/// Represents the input, output, and the type of conversion
/// </summary>
public class ConversionModel
{

    /// <summary>
    /// Gets or sets the value to convert
    /// </summary>
    public string Input {get; set;} = "3.1415";

    /// <summary>
    /// Gets or sets the converted value
    /// </summary>
    public string Output {get; set;} = string.Empty;

    /// <summary>
    /// Gets or sets the type of conversion to perform
    /// </summary>
    public string ConversionType {get; set;} = ConversionTypes.MilesToKilometers;
}
