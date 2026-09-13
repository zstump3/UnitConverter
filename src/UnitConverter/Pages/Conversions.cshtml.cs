using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

/// <summary>
/// Handles the mile to kilometers conversion page.
/// </summary>
public class ConversionsModel : PageModel
{
    /// <summary>
    /// Stores the number of miles
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = "3.1415";

    /// <summary>
    /// Stores the converted number of kilometers
    /// </summary>
    public string Output { get; set; } = string.Empty;

    /// <summary>
    /// Used for getting the conversion type the end user wishes to do.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = "MilesToKilometers";

    /// <summary>
    /// Used for the conversions of different types of measurements. Takes an input and displays the output of the
    /// Conversion.
    /// </summary>
    public void OnGet()
    {
        ViewData["ConversionType"] =
            ConversionType.Replace("To", " to ");

        ViewData["Title"] = "Conversions";

        //Initalize the input and validate the input.
        double inputValue = 3.1415;
        try
        {
            inputValue = Convert.ToDouble(Input);
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
        double? convertedValue = ConversionType switch
        {
            //TODO Make the URL names syntax friendly. Take the URL input and make all lowercase.
            "MilesToKilometers" =>
                new UnitOf.Length().FromMiles(inputValue).ToKilometers(),

            "KilometersToMiles" =>
                new UnitOf.Length().FromKilometers(inputValue).ToMiles(),

            "FahrenheitToCelsius" =>
                new UnitOf.Temperature().FromFahrenheit(inputValue).ToCelsius(),

            "CelsiusToFahrenheit" =>
                new UnitOf.Temperature().FromCelsius(inputValue).ToFahrenheit(),

            "PoundsToKilograms" =>
                new UnitOf.Mass().FromPounds(inputValue).ToKilograms(),

            "KilogramsToPounds" =>
                new UnitOf.Mass().FromKilograms(inputValue).ToPounds(),

            "KilobytesToTerabytes" =>
                new UnitOf.DataStorage().FromKilobytes(inputValue).ToTerabytes(),

            "TerabytesToKilobytes" =>
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
