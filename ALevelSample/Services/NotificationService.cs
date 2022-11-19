using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _loggerService;

    public NotificationService(ILogger<NotificationService> loggerService)
    {
        _loggerService = loggerService;
    }

    public void Notify(NotifyType type, string massage, string to)
    {
        // For example, sent email to user
        _loggerService.LogInformation($"Notification was sent for type {type}");
    }
}