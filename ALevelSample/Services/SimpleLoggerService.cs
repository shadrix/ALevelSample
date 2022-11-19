using System;
using System.Diagnostics;
using ALevelSample.Config;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class SimpleLoggerService : ILoggerService
{
    private readonly LoggerOption _loggerOptions;

    public SimpleLoggerService(IOptions<LoggerOption> loggerOptions)
    {
        _loggerOptions = loggerOptions.Value;
    }

    public void Log(LogType logType, string massage)
    {
        var log = $"{DateTime.UtcNow} {logType} {massage}";
        Console.WriteLine(log);
        Debug.WriteLine($"write log to {_loggerOptions.Path}");
    }
}