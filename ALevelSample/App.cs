using System;
using ALevelSample.Services;

namespace ALevelSample;

public class App
{
    private readonly UserService _userService;

    public App(UserService userService)
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