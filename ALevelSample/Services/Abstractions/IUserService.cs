using System.Threading.Tasks;
using ALevelSample.Model;

namespace ALevelSample.Services.Abstractions;
public interface IUserService
{
    Task<User> GetUser(int id);
    Task<CollectionData<User>> GetUsersByPage(int page);
    Task<CollectionData<User>> GetUsersByDelay(int delay);
    Task<Employee> CreateUserEmployee(string name, string job);
    Task<Employee> UpdateUserEmployee(int id, string name, string job);
    Task<Employee> ModifyUserEmployee(int id, string name, string job);
    Task<VoidResult> RemoveUserEmployee(int id);
}
