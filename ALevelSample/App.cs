using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample;

public class App
{
    private readonly ApplicationDbContext _dbContext;

    public App(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Start()
    {
        var data = await _dbContext.Users.ToListAsync();
    }
}