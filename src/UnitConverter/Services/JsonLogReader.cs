using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using UnitConverter.Models;

namespace UnitConverter.Services;

/// <summary>
/// Reads log entries from Serilog JSON log files
/// </summary>
public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;

    /// <summary>
    /// Initialize a new instance of the JsonReader class
    /// </summary>
    /// <param name="environment">
    ///The hosting environment used to locate the root.
    /// </param>
    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(
            environment.ContentRootPath,
            "Logs");
    }

    /// <summary>
    /// Reads and deserialize the available JSON log entries
    /// </summary>
    /// <returns>A collection of log entries</returns>
    public IEnumerable<LogEntry> Read()
    {
        var entries = new List<LogEntry>();

        string[] logFiles;

        try
        {
            logFiles = Directory.GetFiles(
                _logDirectory,
                "*.json");
        }
        catch (DirectoryNotFoundException)
        {
            return entries;
        }

        foreach (string logFile in logFiles)
        {
            string[] lines;

            try
            {
                var lineList = new List<string>();

                using var stream = new FileStream(
                    logFile,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite | FileShare.Delete);

                using var reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();

                    if (line is not null)
                    {
                        lineList.Add(line);
                    }
                }

                lines = lineList.ToArray();
            }
            catch (IOException ex)
            {
                // Console.WriteLine(
                //     $"Could not read {logFile}: {ex.Message}");

                continue;
            }

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                LogEntry? entry;

                try
                {
                    entry = JsonSerializer.Deserialize<LogEntry>(line);
                }
                catch (JsonException)
                {
                    continue;
                }

                if (entry is null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(entry.Level))
                {
                    entry.Level = "Information";
                }

                entries.Add(entry);
            }
        }
        //Used this to find errors
        //Console.WriteLine($"Entries read: {entries.Count}");

        return entries;
    }
}
