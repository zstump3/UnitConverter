using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnGetMilesToKilometers(string input)
    {
        return RedirectToConversion(
            ConversionTypes.MilesToKilometers,
            input);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToConversion(
            ConversionTypes.KilometersToMiles,
            input);
    }

    private IActionResult RedirectToConversion(string conversionType, string input)
    {
        return RedirectToPage("/Conversions", new { conversionType, input });
    }
}
