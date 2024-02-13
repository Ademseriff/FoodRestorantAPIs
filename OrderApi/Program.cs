
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

            builder.Services.AddDbContext<OrderApiDbContext>(opt => opt.UseSqlServer(
               builder.Configuration.GetConnectionString("MSSQLSERVER")));

            builder.Services.AddMassTransit(configurator =>
            {
                configurator.AddConsumer<OrderCreatedEventConsumers>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);

                    _configure.ReceiveEndpoint(RabbitMQSettings.Order_AddRequestEventQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumers>(contex));
                });
            });


            var app = builder.Build();


            app.Run();
        }
    }
}
