using GreenPipes;
using MassTransit;
using MassTransit.Context;
using Microsoft.EntityFrameworkCore;
using Poc.MassTransit.worker;
using Poc.MassTransit.worker.Consumer;
using Poc.MassTransit.worker.Infra;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

var host = Host.CreateDefaultBuilder(args)
    
    .ConfigureServices((hostContext, services) =>
    {
        //var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();
        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

        //services.AddScoped<LogDbContext>(db => new LogDbContext(optionsBuilder.Options));
       services.AddScoped<IMongoContext, MongoContext>();

        services.AddScoped<ILogRepository, LogRepository>();
        services.AddHostedService<Worker>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<LogConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.UseHealthCheck(provider);


 
                cfg.Host(new Uri("amqp://guest:guest@localhost:5672"), config =>
                {
                    config.Username("guest");
                    config.Password("guest");
                });

                //cfg.Message<Log>(config => config.SetEntityName("logs") );
                
                
                cfg.ReceiveEndpoint("logsPortal", e =>
                {
                    e.Bind("logsPortal");
                    e.PrefetchCount = 10;
                    e.UseMessageRetry(r => r.Interval(2, 100));
                    e.Consumer<LogConsumer>(provider);
                });
                
            }));
            
        });
        services.AddMassTransitHostedService();
        

        

    })
    .Build();

    host.Run();

Console.WriteLine("Waiting for new messages.");

while (true) ;
