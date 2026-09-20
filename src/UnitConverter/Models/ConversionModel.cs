namespace UnitConverter.Models;

public class ConversionModel
{
    public string Input {get; set;} = "3.1415";

    public string Output {get; set;} = string.Empty;

    public string ConversionType {get; set;} = ConversionTypes.MilesToKilometers;
}
