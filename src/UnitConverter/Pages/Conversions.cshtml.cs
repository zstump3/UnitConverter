using System.Globalization;
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
    public string Input { get; set; } = string.Empty;
    /// <summary>
    /// Stores the converted number of kilometers
    /// </summary>
    public string Output { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    /// <summary>
    /// Sets the input and converts ot from miles to kilometers
    /// </summary>
    public void OnGet()
    {
        //Initalize the input and validate the input.
        double inputValue = 0;
        try
        {
            inputValue = Convert.ToDouble(Input);
        }
        catch (Exception ex)
        {
            ViewData["Error Message"] = "Input must be a valid number" + ex.Message;
        }

        //Switch expression for choosing between the conversions
        double? convertedValue = ConversionType switch
        {
            "MilesToKilometers" =>
                new UnitOf.Length().FromMiles(inputValue).ToKilometers(),

            "KilometersToMiles" =>
                new UnitOf.Length().FromKilometers(inputValue).ToMiles(),


            _ => null
        };

        if (convertedValue is null)
        {
            ViewData["Error Message"] = "Unknown conversion type";
        }

        //Display the OutPut of the conversion
        Output = convertedValue.ToString();

    }
}
