using System.Collections.Generic;
using ALevelSample.Data.Entities;

namespace ALevelSample.Models;

public class Order
{
    public int Id { get; set; }

    public UserEntity? User { get; set; }

    public IEnumerable<OrderItem>? OrderItems { get; set; }
}