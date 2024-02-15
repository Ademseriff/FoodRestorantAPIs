
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderApi.Consumers;
using OrderApi.Models.Contexts;
using Shared;

namespace OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //OrderViewCompLatedEventConsumers
            builder.Services.AddDbContext<OrderApiDbContext>(opt => opt.UseSqlServer(
               builder.Configuration.GetConnectionString("MSSQLSERVER")));

            builder.Services.AddMassTransit(configurator =>
            {
                configurator.AddConsumer<OrderCreatedEventConsumers>();
                configurator.AddConsumer<OrderViewRequestEventConsumers>();
                configurator.AddConsumer<OrderComplatedEventConsumers>();
                configurator.AddConsumer<OrderFailedEventConsumers>();
                configurator.AddConsumer<OrderViewCompLatedEventConsumers>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);

                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_AddRequestEventQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumers>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_ViewRequestEventQueue, e => e.ConfigureConsumer<OrderViewRequestEventConsumers>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_OrderComplatedEventQueue, e => e.ConfigureConsumer<OrderComplatedEventConsumers>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_OrderFailedEventQueue, e => e.ConfigureConsumer<OrderFailedEventConsumers>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_OrderViewComplatedEventQueue, e => e.ConfigureConsumer<OrderViewCompLatedEventConsumers>(contex));
                });
            });


            var app = builder.Build();


            app.Run();
        }
    }
}
