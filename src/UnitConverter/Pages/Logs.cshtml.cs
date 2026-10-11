using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class LogsModel : PageModel
{
    private readonly ILogReader _logReader;

    public LogsModel(ILogReader logReader)
    {
        _logReader = logReader;
    }

    public List<LogEntry> Entries { get; private set; } = [];

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Level { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ConversionType { get; set; }

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
