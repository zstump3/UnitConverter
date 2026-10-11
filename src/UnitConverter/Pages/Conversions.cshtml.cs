using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;
using UnitConverter.Models;

/// <summary>
/// Handles the unit conversion request for the Conversion Page.
/// </summary>
public class ConversionsModel : PageModel
{
    /// <summary>
    /// Gets or sets the conversion data submitted to the page
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public ConversionModel Conversion { get; set; } = new();

    /// <summary>
    /// Gets or sets the input value dor the conversion
    /// </summary>
    [BindProperty (SupportsGet = true)]
    public string Input
    {
        get => Conversion.Input;
        set => Conversion.Input = value;
    }

    /// <summary>
    /// Gets or sets the output value produced by the conversion
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string Output
    {
        get => Conversion.Output;
        set => Conversion.Output = value;
    }

    /// <summary>
    /// Gets or sets the type of conversion to perform
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string ConversionType
    {
        get => Conversion.ConversionType;
        set => Conversion.ConversionType = value;
    }

    /// <summary>
    /// Proccess the request conversion and prepares the result for display
    /// </summary>
    public void OnGet()
    {
        ViewData["Title"] = "Conversions";

        if (ConversionTypes.All.TryGetValue(
                Conversion.ConversionType,
                out string? displayName))

        {
            ViewData["ConversionType"] = displayName;
        }
        else
        {
            ViewData["ErrorMessage"] = "Unknown Conversion Type";
            return;
        }

        // ViewData["ConversionType"] =
        //     Conversion.ConversionType.Replace("To", " to ");

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
        Conversion.Output = convertedValue.ToString();
    }
}
