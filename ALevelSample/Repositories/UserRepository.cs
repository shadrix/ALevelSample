using System;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;

namespace ALevelSample.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserEntity[] _mockStorage = new UserEntity[100];
    private int _mockStorageCursor = 0;

    public string AddUser(string firstName, string lastName)
    {
        var user = new UserEntity()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName
        };

        _mockStorage[_mockStorageCursor] = user;
        _mockStorageCursor++;
        return user.Id;
    }

    public UserEntity GetUser(string id)
    {
        foreach (var item in _mockStorage)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }
}