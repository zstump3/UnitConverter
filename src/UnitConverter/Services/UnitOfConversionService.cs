using UnitConverter.Models;

namespace UnitConverter.Services;

public class UnitOfConversionService : IConversionService
{
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

            _ => null
        };
        if (convertedValue == null)
        {
        }

        return (decimal)convertedValue!;
    }
}
