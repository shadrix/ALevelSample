using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<int> AddOrderAsync(string user, List<OrderItem> items);
    Task<OrderEntity?> GetOrderAsync(int id);
    Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id);
}