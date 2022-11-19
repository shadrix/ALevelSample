using ALevelSample.Models;
using ALevelSample.Repositories;

namespace ALevelSample.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly SimpleLoggerService _simpleLoggerService;
    private readonly NotificationService _notificationService;

    public UserService(
        UserRepository userRepository,
        SimpleLoggerService simpleLoggerService,
        NotificationService notificationService)
    {
        _userRepository = userRepository;
        _simpleLoggerService = simpleLoggerService;
        _notificationService = notificationService;
    }

    public string AddUser(string firstName, string lastName)
    {
       var id = _userRepository.AddUser(firstName, lastName);
       _simpleLoggerService.Log(LogType.Info, $"Created user with Id = {id}");
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
            _simpleLoggerService.Log(LogType.Warning, $"Not founded user with Id = {id}");
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