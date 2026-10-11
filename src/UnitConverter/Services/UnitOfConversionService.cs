using UnitConverter.Models;

namespace UnitConverter.Services;

/// <summary>
/// Performs unit conversion using the UnitOf library
/// </summary>
public class UnitOfConversionService : IConversionService
{
    /// <summary>
    /// Converts a value using the specified conversion type
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <param name="conversionType">The type of conversion to perform</param>
    /// <returns>The converted value</returns>
    /// <exception cref="ArgumentException">
    ///Thrown when the conversion type is not supported
    /// </exception>
    public decimal Convert(decimal value, string conversionType)
    {
        double inputValue = (double)value;

        double? convertedValue = conversionType switch
        {
            ConversionTypes.MilesToKilometers =>
                new UnitOf.Length().FromMiles(inputValue).ToKilometers(),

            ConversionTypes.KilometersToMiles =>
                new UnitOf.Length().FromKilometers(inputValue).ToMiles(),

            ConversionTypes.FahrenheitToCelsius =>
                new UnitOf.Temperature().FromFahrenheit(inputValue).ToCelsius(),

            ConversionTypes.CelsiusToFahrenheit =>
                new UnitOf.Temperature().FromCelsius(inputValue).ToFahrenheit(),

            ConversionTypes.PoundsToKilograms =>
                new UnitOf.Mass().FromPounds(inputValue).ToKilograms(),

            ConversionTypes.KilogramsToPounds =>
                new UnitOf.Mass().FromKilograms(inputValue).ToPounds(),

            ConversionTypes.KilobytesToTerabytes=>
                new UnitOf.DataStorage().FromKilobytes(inputValue).ToTerabytes(),

            ConversionTypes.TerabytesToKilobytes =>
                new UnitOf.DataStorage().FromTerabytes(inputValue).ToKilobytes(),

            _ =>  throw new ArgumentException(
                $"Unsupported conversion type: {conversionType}",
                nameof(conversionType))
        };

        return (decimal)convertedValue!;
    }
}
