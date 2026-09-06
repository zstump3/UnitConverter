using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;


public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";

        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";

        double inputValue = Convert.ToDouble(Input);
        double convertedValue = new UnitOf.Length()
            .FromMiles(inputValue)
            .ToKilometers();

        Output = convertedValue.ToString();

    }
}
