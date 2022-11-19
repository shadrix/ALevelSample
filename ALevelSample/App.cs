using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;

    public App(IUserService userService)
    {
        _userService = userService;
    }

    public void Start()
    {
        var firstName = "first name";
        var lastName = "last name";

        var userId = _userService.AddUser(firstName, lastName);

        _userService.GetUser(userId);
    }
}