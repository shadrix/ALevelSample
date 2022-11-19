using System;
using ALevelSample.Models;

namespace ALevelSample.Services;

public class NotificationService
{
    private readonly SimpleLoggerService _simpleLoggerService;

    public NotificationService(SimpleLoggerService simpleLoggerService)
    {
        _simpleLoggerService = simpleLoggerService;
    }

    public void Notify(NotifyType type, string massage, string to)
    {
        // For example, sent email to user
        _simpleLoggerService.Log(LogType.Info, $"Notification was sent for type {type}");
    }
}