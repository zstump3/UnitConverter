using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

/// <summary>
/// Displays and filters application log entries
/// </summary>
public class LogsModel : PageModel
{
    private readonly ILogReader _logReader;

    /// <summary>
    /// Initialize a new instance if the LogsModel class
    /// </summary>
    /// <param name="logReader">
    ///Service used to read the log entries from the JSON log files
    /// </param>
    public LogsModel(ILogReader logReader)
    {
        _logReader = logReader;
    }

    /// <summary>
    /// Gets the log entries that match the selected filter
    /// </summary>
    public List<LogEntry> Entries { get; private set; } = [];

    /// <summary>
    /// Gets or sets the text used to search log messages
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    /// <summary>
    /// Gets or sets the log level used to filter entries
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string? Level { get; set; }

    /// <summary>
    /// Gets or sets the Conversion type used to filter the log entries
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string? ConversionType { get; set; }

    /// <summary>
    /// Read the log entries and applies the selected filters
    /// </summary>
    public void OnGet()
    {
        foreach (LogEntry entry in _logReader.Read())
        {
            bool matches = true;

            if (!string.IsNullOrEmpty(Search) &&
                (entry.Message is null ||
                 !entry.Message.Contains(
                     Search,
                     StringComparison.OrdinalIgnoreCase)))
            {
                matches = false;
            }

            if (!string.IsNullOrWhiteSpace(Level) &&
                !string.Equals(
                    entry.Level,
                    Level,
                    StringComparison.OrdinalIgnoreCase))
            {
                matches = false;
            }

            if (!string.IsNullOrWhiteSpace(ConversionType) &&
                !string.Equals(
                    entry.ConversionType,
                    ConversionType,
                    StringComparison.OrdinalIgnoreCase))
            {
                matches = false;
            }

            if (matches)
            {
                Entries.Add(entry);
            }
        }
    }
}
