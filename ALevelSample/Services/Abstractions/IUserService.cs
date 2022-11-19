using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<string> AddUser(string firstName, string lastName);
    Task<User> GetUser(string id);
}