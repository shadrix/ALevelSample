using System;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;

namespace ALevelSample.Services;

public class SimpleLoggerService : ILoggerService
{
    public void Log(LogType logType, string massage)
    {
        var log = $"{DateTime.UtcNow} {logType} {massage}";
        Console.WriteLine(log);
    }
}