using ALevelSample;
using ALevelSample.Data;
using ALevelSample.Repositories;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
        => opts.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

    serviceCollection
        .AddTransient<IUserService, UserService>()
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<IUserRepository, UserRepository>()
        .AddTransient<IOrderRepository, OrderRepository>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<INotificationService, NotificationService>()
        .AddTransient<IOrderService, OrderService>()
        .AddTransient<IProductService, ProductService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

// It could be possible variant for production code
// BUT need to be careful and don't run extra migration
if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<ApplicationDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();