using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IUserRepository
{
    string AddUser(string firstName, string lastName);
    UserEntity GetUser(string id);
}