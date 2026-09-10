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
    public void OnGet(string ConversionType, string Input)
    {
        double inputValue = 0;
        try
        {
            inputValue = Convert.ToDouble(Input);
        }
        catch (Exception ex)
        {
            ViewData["Error Message"] = "Input must be a valid number" + ex.Message;
        }
        double convertedValue = 0;
        switch (ConversionType)
        {
            case "MilestoKilometers":
                convertedValue = new UnitOf.Length()
                    .FromMiles(inputValue)
                    .ToKilometers();
                Output = convertedValue.ToString();
                break;

            case "KilometerstoMiles":
                convertedValue = new UnitOf.Length()
                    .FromKilometers(inputValue)
                    .ToMiles();
                Output = convertedValue.ToString();
                break;

        }


        // ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";

        // double inputValue = Convert.ToDouble(Input);
        // double convertedValue = new UnitOf.Length()
        //     .FromMiles(inputValue)
        //     .ToKilometers();

        // Output = convertedValue.ToString();

    }

}
