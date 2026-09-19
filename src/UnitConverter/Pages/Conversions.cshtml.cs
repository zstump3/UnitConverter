using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;
using UnitConverter.Models;

/// <summary>
/// Handles the mile to kilometers conversion page.
/// </summary>
public class ConversionsModel : PageModel
{
    /// <summary>
    /// Stores the number of miles
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public ConversionModel Conversion { get; set; } = new();

    [BindProperty (SupportsGet = true)]
    public string Input
    {
        get => Conversion.Input;
        set => Conversion.Input = value;
    }

    [BindProperty(SupportsGet = true)]
    public string Output
    {
        get => Conversion.Output;
        set => Conversion.Output = value;
    }

    [BindProperty(SupportsGet = true)]
    public string ConversionType
    {
        get => Conversion.ConversionType;
        set => Conversion.ConversionType = value;
    }

    /// <summary>
    /// Used for the conversions of different types of measurements. Takes an input and displays the output of the
    /// Conversion.
    /// </summary>
    public void OnGet()
    {
        ViewData["ConversionType"] =
            Conversion.ConversionType.Replace("To", " to ");

        ViewData["Title"] = "Conversions";

        //Initalize the input and validate the input.
        double inputValue = 3.1415;
        try
        {
            inputValue = Convert.ToDouble(Conversion.Input);
        }
        catch (FormatException)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number";

            return;
        }
        catch (OverflowException)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number";

            return;
        }

        //Switch expression for choosing between the conversions
        //TODO Maybe work to add all the conversions later
        double? convertedValue = Conversion.ConversionType switch
        {
            //TODO Make the URL names syntax friendly. Take the URL input and make all lowercase.
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

        if (convertedValue is null)
        {
            ViewData["ErrorMessage"] = "Unknown conversion type";

            return;
        }

        //Display the OutPut of the conversion
        Output = convertedValue.ToString();
    }
}
