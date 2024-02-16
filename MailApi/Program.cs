
using MailApi.Consumers;
using MailApi.Services.Abstractions;
using MailApi.Services.Concretes;
using MassTransit;
using Shared;

namespace MailApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //dependecy injection
            builder.Services.AddScoped<IMailService,MailService>();

            builder.Services.AddMassTransit(configurator =>
            {
                configurator.AddConsumer<MailSentEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.Mail_SentEventQueue, e => e.ConfigureConsumer<MailSentEventConsumer>(contex));

                });
            });
            
            var app = builder.Build();

         

            app.Run();
        }
    }
}
