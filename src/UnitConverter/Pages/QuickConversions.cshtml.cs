using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{

    private readonly IConversionService _conversionService;

    public QuickConversions(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    /// <summary>
    /// Stores the result of the conversions
    /// </summary>
    public string? Output { get; set; }

    /// <summary>
    /// Used for the error message for end users
    /// </summary>
    public string? ErrorMessage { get; set; }

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
        return PerformConversion(
            input,
            ConversionTypes.MilesToKilometers);
    }

    /// <summary>
    ///Handles a request to convert kilometers to miles
    /// </summary>
    /// <param name="input">The number of kilometers to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilometersToMiles(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.KilometersToMiles);
    }

    /// <summary>
    ///Handles a request to convert Fahrenheit to Celsius
    /// </summary>
    /// <param name="input">The number of Fahrenheit to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.FahrenheitToCelsius);
    }

    /// <summary>
    ///Handles a request to convert Celsius to Fahrenheit
    /// </summary>
    /// <param name="input">The number of Celsius to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.CelsiusToFahrenheit);
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
        return PerformConversion(
            input,
            ConversionTypes.PoundsToKilograms);
    }

    /// <summary>
    ///Handles a request to convert Kilograms to Pounds
    /// </summary>
    /// <param name="input">The number of Kilograms to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.KilogramsToPounds);
    }

    /// <summary>
    ///Handles a request to convert Kilobytes to Terabytes
    /// </summary>
    /// <param name="input">The number of Kilobytes to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetKilobytesToTerabytes(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.KilobytesToTerabytes);
    }

    /// <summary>
    ///Handles a request to convert Terabytes to Kilobytes
    /// </summary>
    /// <param name="input">The number of Terabytes to convert</param>
    /// <returns>A redirect to Conversion Page with the conversion type and input</returns>
    public IActionResult OnGetTerabytesToKilobytes(string input)
    {
        return PerformConversion(
            input,
            ConversionTypes.TerabytesToKilobytes);
    }

    private IActionResult RedirectToConversion(string conversionType, string input)
    {
        return RedirectToPage("/Conversions", new { conversionType, input });
    }

    private IActionResult PerformConversion(string input, string conversionType)
    {
        Output = null;
        ErrorMessage = null;

        if (!decimal.TryParse(input, out decimal inputValue))
        {
            ErrorMessage = "Input must be a valid number.";
            return Page();
        }

        if (!ConversionTypes.All.ContainsKey(conversionType))
        {
            ErrorMessage = "Unknown conversion";
            return Page();
        }

        decimal result;

        try
        {
            result = _conversionService.Convert(inputValue, conversionType);
        }
        catch (OverflowException)
        {
            ErrorMessage = "The conversion result is outside the range.";
            return Page();
        }

        Output = result.ToString();

        return Page();
    }
}
