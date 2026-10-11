namespace UnitConverter.Services;

/// <summary>
/// Defines the service that performs unit conversions
/// </summary>
public interface IConversionService
{
    /// <summary>
    /// Converts a value using the specified conversion type
    /// </summary>
    /// <param name="value">
    ///The value to convert
    /// </param>
    /// <param name="conversionType">
    ///The type of conversion to perform
    /// </param>
    /// <returns>The converted value</returns>
    decimal Convert(decimal value, string conversionType);
}
