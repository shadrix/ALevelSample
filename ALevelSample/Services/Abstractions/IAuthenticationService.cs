using System.Threading.Tasks;
using ALevelSample.Model;

namespace ALevelSample.Services.Abstractions;
public interface IAuthenticationService
{
    Task<LoginResult> Login(string login, string password);
    Task<RegisterResult> Register(string login, string password);
}
