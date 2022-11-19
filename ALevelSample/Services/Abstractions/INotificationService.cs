using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface INotificationService
{
    void Notify(NotifyType type, string massage, string to);
}