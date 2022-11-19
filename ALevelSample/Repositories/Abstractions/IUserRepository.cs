using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IUserRepository
{
    Task<string> AddUserAsync(string firstName, string lastName);
    Task<UserEntity?> GetUserAsync(string id);
}