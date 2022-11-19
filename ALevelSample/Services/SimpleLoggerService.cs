using System;
using ALevelSample.Models;

namespace ALevelSample.Services;

public class SimpleLoggerService
{
    public void Log(LogType logType, string massage)
    {
        var log = $"{DateTime.UtcNow} {logType} {massage}";
        Console.WriteLine(log);
    }
}