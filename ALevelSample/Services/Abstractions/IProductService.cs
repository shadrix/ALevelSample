using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, double price);
    Task<Product> GetProductAsync(int id);
}