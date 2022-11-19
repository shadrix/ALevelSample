using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface ILoggerService
{
    void Log(LogType logType, string massage);
}