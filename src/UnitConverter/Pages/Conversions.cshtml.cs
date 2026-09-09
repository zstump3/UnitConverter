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
    public string Input { get; set; } = string.Empty;
    /// <summary>
    /// Stores the converted number of kilometers
    /// </summary>
    public string Output { get; set; } = string.Empty;
    public string ConversionType { get; set; } = string.Empty;

    /// <summary>
    /// Sets the input and converts ot from miles to kilometers
    /// </summary>
    public void OnGet(string conversionType, string input)
    {
        Input = "3.1415";
        input = Input ?? string.Empty;
        conversionType = ConversionType ?? string.Empty;
        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";

        double inputValue = Convert.ToDouble(Input);
        double convertedValue = new UnitOf.Length()
            .FromMiles(inputValue)
            .ToKilometers();

        Output = convertedValue.ToString();

    }
}
