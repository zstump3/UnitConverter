using Microsoft.VisualBasic;

namespace UnitConverter.Services;

using UnitConverter.Models;

/// <summary>
///  Defines a service that reads log entries from log files.
/// </summary>
public interface ILogReader
{

    /// <summary>
    /// Reads and returns the available log entries
    /// </summary>
    /// <returns>A collection of log entries</returns>
    IEnumerable<LogEntry> Read();
}
