using ALevelSample;
using ALevelSample.Repositories;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IUserRepository, UserRepository>()
    .AddTransient<INotificationService, NotificationService>()
    .AddSingleton<ILoggerService, SimpleLoggerService>()
    .AddTransient<App>();

var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
app!.Start();