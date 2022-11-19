using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
}