using ALevelSample;
using ALevelSample.Repositories;
using ALevelSample.Services;

var logger = new SimpleLoggerService();

var app = new App(new UserService(new UserRepository(), logger, new NotificationService(logger)));
app.Start();