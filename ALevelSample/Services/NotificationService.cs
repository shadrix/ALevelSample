using System;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;

namespace ALevelSample.Services;

public class NotificationService : INotificationService
{
    private readonly ILoggerService _loggerService;

    public NotificationService(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    public void Notify(NotifyType type, string massage, string to)
    {
        // For example, sent email to user
        _loggerService.Log(LogType.Info, $"Notification was sent for type {type}");
    }
}