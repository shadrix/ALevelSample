using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IResourceService _resourceService;

    public App(
        IUserService userService,
        IAuthenticationService authenticationService,
        IResourceService resourceService)
    {
        _userService = userService;
        _authenticationService = authenticationService;
        _resourceService = resourceService;
    }

    public async Task Start()
    {
        var getUsersByPage1 = Task.Run(async () => await _userService.GetUsersByPage(2));
        var getUsersByPage2 = Task.Run(async () => await _userService.GetUsersByPage(3));
        var getUser1 = Task.Run(async () => await _userService.GetUser(2));
        var getUser2 = Task.Run(async () => await _userService.GetUser(23));
        var createUserEmployee = Task.Run(async () => await _userService.CreateUserEmployee("morpheus", "leader"));
        var updateUserEmployee = Task.Run(async () => await _userService.UpdateUserEmployee(2, "morpheus", "zion resident"));
        var modifyUserEmployee = Task.Run(async () => await _userService.ModifyUserEmployee(2, "morpheus", "zion resident"));
        var removeUserEmployee = Task.Run(async () => await _userService.RemoveUserEmployee(2));

        var login1 = Task.Run(async () => await _authenticationService.Login("eve.holt@reqres.in", "cityslicka"));
        var login2 = Task.Run(async () => await _authenticationService.Login("peter@klaven", null!));
        var register1 = Task.Run(async () => await _authenticationService.Register("eve.holt@reqres.in", "pistol"));
        var register2 = Task.Run(async () => await _authenticationService.Register("sydney@fife", null!));

        var getResources1 = Task.Run(async () => await _resourceService.GetResources());
        var getResources2 = Task.Run(async () => await _resourceService.GetResource(2));
        var getResources3 = Task.Run(async () => await _resourceService.GetResource(23));

        await Task.WhenAll(
            getUsersByPage1,
            getUsersByPage2,
            getUser1,
            getUser2,
            createUserEmployee,
            updateUserEmployee,
            modifyUserEmployee,
            removeUserEmployee,
            login1,
            login2,
            register1,
            register2,
            getResources1,
            getResources2,
            getResources3);

        var getUsersByPage1Result = await getUsersByPage1;
        var getUsersByPage2Result = await getUsersByPage2;
        var getUser1Result = await getUser1;
        var getUser2Result = await getUser2;
        var createUserEmployeeResult = await createUserEmployee;
        var updateUserEmployeeResult = await updateUserEmployee;
        var modifyUserEmployeeResult = await modifyUserEmployee;
        var removeUserEmployeeResult = await removeUserEmployee;
        var login1Result = await login1;
        var login2Result = await login2;
        var register1Result = await register1;
        var register2Result = await register2;
        var getResources1Result = await getResources1;
        var getResources2Result = await getResources2;
        var getResources3Result = await getResources3;
    }
}