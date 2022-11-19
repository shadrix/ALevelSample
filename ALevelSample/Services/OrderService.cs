using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class OrderService : BaseDataService<ApplicationDbContext>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<UserService> _loggerService;

    public OrderService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderRepository orderRepository,
        ILogger<UserService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _orderRepository = orderRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddOrderAsync(string user, List<OrderItem> items)
    {
        var id = await _orderRepository.AddOrderAsync(user, items);
        _loggerService.LogInformation($"Created order with Id = {id}");
        return id;
    }

    public async Task<Order> GetOrderAsync(int id)
    {
        var result = await _orderRepository.GetOrderAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded order with Id = {id}");
            return null!;
        }

        return new Order()
        {
            Id = result.Id,
            OrderItems = result.OrderItems.Select(s => new OrderItem()
            {
                Count = s.Count,
                ProductId = s.ProductId,
                Product = new Product()
                {
                    Id = s.Product!.Id,
                    Name = s.Product.Name,
                    Price = s.Product.Price
                }
            })
        };
    }

    public async Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(string id)
    {
        var result = await _orderRepository.GetOrderByUserIdAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded order fot current user Id = {id}");
            return null!;
        }

        return result.Select(r => new Order()
        {
            Id = r.Id,
            OrderItems = r.OrderItems.Select(s => new OrderItem()
            {
                Count = s.Count,
                ProductId = s.ProductId,
                Product = new Product()
                {
                    Id = s.Product!.Id,
                    Name = s.Product.Name,
                    Price = s.Product.Price
                }
            })
        }).ToList();
    }
}