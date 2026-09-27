using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    public void OnGet()
    {

    }

    /// <summary>
    ///Handles a request to convert miles to kilometers
    /// </summary>
    /// <param name="input">The number of miles to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetMilesToKilometers(string input)
    {
        return RedirectToConversion(
            ConversionTypes.MilesToKilometers,
            input);
    }

    /// <summary>
    ///Handles a request to convert kilometers to miles
    /// </summary>
    /// <param name="input">The number of kilometers to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToConversion(
            ConversionTypes.KilometersToMiles,
            input);
    }

    /// <summary>
    ///Handles a request to convert Fahrenheit to Celsius
    /// </summary>
    /// <param name="input">The number of Fahrenheit to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return RedirectToConversion(
            ConversionTypes.FahrenheitToCelsius,
            input);
    }

    /// <summary>
    ///Handles a request to convert Celsius to Fahrenheit
    /// </summary>
    /// <param name="input">The number of Celsius to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return RedirectToConversion(
            ConversionTypes.CelsiusToFahrenheit,
            input);
    }

    /// <summary>
    /// Provides some numbers that are shared by the quick conversion dropdowns
    /// </summary>
    public IEnumerable<SelectListItem> AmountOptions =>
    [
        new("1", "1"),
        new("5", "5"),
        new("10", "10"),
        new("25", "25"),
        new("50", "50")
    ];

    /// <summary>
    ///Handles a request to convert Pounds to Kilograms
    /// </summary>
    /// <param name="input">The number of Pounds to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return RedirectToConversion(
            ConversionTypes.PoundsToKilograms,
            input);
    }

    /// <summary>
    ///Handles a request to convert Kilograms to Pounds
    /// </summary>
    /// <param name="input">The number of Kilograms to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return RedirectToConversion(
            ConversionTypes.KilogramsToPounds,
            input);
    }

    /// <summary>
    ///Handles a request to convert Kilobytes to Terabytes
    /// </summary>
    /// <param name="input">The number of Kilobytes to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilobytesToTerabytes(string input)
    {
        return RedirectToConversion(
            ConversionTypes.KilobytesToTerabytes
            ,input);
    }

    /// <summary>
    ///Handles a request to convert Terabytes to Kilobytes
    /// </summary>
    /// <param name="input">The number of Terabytes to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetTerabytesToKilobytes(string input)
    {
        return RedirectToConversion(
            ConversionTypes.TerabytesToKilobytes,
            input);
    }

    private IActionResult RedirectToConversion(string conversionType, string input)
    {
        return RedirectToPage("/Conversions", new { conversionType, input });
    }
}
