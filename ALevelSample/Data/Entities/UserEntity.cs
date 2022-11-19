using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class UserEntity
{
    public string Id { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}