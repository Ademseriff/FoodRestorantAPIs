
using BasketApi.Consumers;
using BasketApi.Models.Contexts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;

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
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.Basket_ItemAddedEventQueue, e => e.ConfigureConsumer<BasketItemAddedEventConsumer>(contex));
                });
            });


            var app = builder.Build();

            
       

            app.Run();
        }
    }
}
