
using BasketApi.Consumers;
using BasketApi.Models.Contexts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Events;

namespace BasketApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<BasketAPIDbContext>(opt => opt.UseSqlServer(
               builder.Configuration.GetConnectionString("MSSQLSERVER")));

            builder.Services.AddMassTransit(configurator =>
            {
                configurator.AddConsumer<BasketItemAddedEventConsumer>();
                configurator.AddConsumer<BasketViewRequestEventConsumer>();
                configurator.AddConsumer<BasketDeleteRequestEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.Basket_ItemAddedEventQueue, e => e.ConfigureConsumer<BasketItemAddedEventConsumer>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.Basket_ViewRequestEventQueue, e => e.ConfigureConsumer<BasketViewRequestEventConsumer>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.Basket_DeleteRequestEventQueue, e => e.ConfigureConsumer<BasketDeleteRequestEventConsumer>(contex));
                });
            });


            var app = builder.Build();

            
       

            app.Run();
        }
    }
}
