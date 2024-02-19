
using MassTransit;
using OrderBackupApi.Consumers;
using OrderBackupApi.Services;
using Shared;

namespace OrderBackupApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMassTransit(configurator =>
            {

               
                configurator.AddConsumer<OrderBackupCreatedEventConsumers>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.Backup_EventQueue, e => e.ConfigureConsumer<OrderBackupCreatedEventConsumers>(contex));

                });
            });
            //ioc continera mongodbyi ekledik.
            builder.Services.AddSingleton<MongoDBService>();

            var app = builder.Build();



            app.Run();
        }
    }
}
