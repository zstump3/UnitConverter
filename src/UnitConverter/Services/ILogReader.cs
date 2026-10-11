using Microsoft.VisualBasic;

namespace UnitConverter.Services;

using UnitConverter.Models;

public interface ILogReader
{
    IEnumerable<LogEntry> Read();
}
