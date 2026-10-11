namespace UnitConverter.Models;
/// <summary>
/// Provides the supported Conversion types
/// </summary>
public static class ConversionTypes
{
    /// <summary>
    /// Converts miles to kilometers
    /// </summary>
    public const string MilesToKilometers = "MilesToKilometers";

    /// <summary>
    /// Converts Kilometers to Miles
    /// </summary>
    public const string KilometersToMiles = "KilometersToMiles";

    /// <summary>
    /// Converts Fahrenheit to Celsius
    /// </summary>
    public const string FahrenheitToCelsius = "FahrenheitToCelsius";

    /// <summary>
    /// Converts Celsius to Fahrenheit
    /// </summary>
    public const string CelsiusToFahrenheit = "CelsiusToFahrenheit";

    /// <summary>
    /// Converts Pounds to Kilograms
    /// </summary>
    public const string PoundsToKilograms = "PoundsToKilograms";

    /// <summary>
    /// Converts Kilograms to Pounds
    /// </summary>
    public const string KilogramsToPounds = "KilogramsToPounds";

    /// <summary>
    /// Converts Kilobytes to Terabytes
    /// </summary>
    public const string KilobytesToTerabytes = "KilobytesToTerabytes";

    /// <summary>
    /// Converts Terabytes to Kilobytes
    /// </summary>
    public const string TerabytesToKilobytes = "TerabytesToKilobytes";

    /// <summary>
    /// Contains each conversion type and displays its name
    /// </summary>
    public static readonly IReadOnlyDictionary<string, string> All =

        new Dictionary<string, string>
        {
            [MilesToKilometers] = "Miles to Kilometers",
            [KilometersToMiles] = "Kilometers to Miles",
            [FahrenheitToCelsius] = "Fahrenheit to Celsius",
            [CelsiusToFahrenheit]  = "Celsius to Fahrenheit",
            [PoundsToKilograms] = "Pounds to Kilograms",
            [KilogramsToPounds]  = "Kilograms to Pounds",
            [KilobytesToTerabytes] = "Kilobytes to Terabytes",
            [TerabytesToKilobytes]  = "Terabytes to Kilobytes",

        };
}
