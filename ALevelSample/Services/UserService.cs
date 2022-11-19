using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _loggerService;
    private readonly INotificationService _notificationService;

    public UserService(
        IUserRepository userRepository,
        ILogger<UserService> loggerService,
        INotificationService notificationService)
    {
        _userRepository = userRepository;
        _loggerService = loggerService;
        _notificationService = notificationService;
    }

    public string AddUser(string firstName, string lastName)
    {
       var id = _userRepository.AddUser(firstName, lastName);
       _loggerService.LogInformation($"Created user with Id = {id}");
       var notifyMassage = "registration was successful";
       var notifyTo = "user@gmail.com";
       _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
       return id;
    }

    public User GetUser(string id)
    {
        var user = _userRepository.GetUser(id);

        if (user == null)
        {
            _loggerService.LogWarning($"Not founded user with Id = {id}");
            return null;
        }

        return new User()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = $"{user.FirstName} {user.LastName}"
        };
    }
}