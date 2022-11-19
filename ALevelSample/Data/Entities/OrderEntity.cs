using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public UserEntity? User { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
}