using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models.Contexts;
using Shared.Events;
using Shared.Message;

namespace OrderApi.Consumers
{
    public class OrderViewCompLatedEventConsumers : IConsumer<OrderViewCompLatedEvent>
    {
        private readonly OrderApiDbContext database;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderViewCompLatedEventConsumers(OrderApiDbContext orderApiDbContext,IPublishEndpoint publishEndpoint)
        {
            database = orderApiDbContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderViewCompLatedEvent> context)
        {

            List<Models.OrderAdd> ordersDb = await database.orderAdds.ToListAsync();
            List<Models.OrderDetails> orderDetailsDb = await database.orderDetails.ToListAsync();

            OrderViewComplatedEventResponse orderViewComplatedEventResponse = new OrderViewComplatedEventResponse();
             
           List<OrderViewComplatedEventResponseMessage> messages = new List<OrderViewComplatedEventResponseMessage>();
            List<OrderViewComplatedEventResponseMessage> messagess = new List<OrderViewComplatedEventResponseMessage>();


            foreach (var database in ordersDb)
            {
                if (database.State == Enums.State.successful)
                {
                    messages = orderDetailsDb.Select(x => new OrderViewComplatedEventResponseMessage()
                    {
                    Adress = x.Adress,
                    Category = x.Category,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Product = x.Product,
                    TotalPrice = x.TotalPrice,
                    OrderId = x.OrderAddId

                    }).Where(x => x.OrderId == database.Id).ToList();


                    foreach (var y in messages)
                    {
                        messagess.Add(y);
                    }

                }
            }
            orderViewComplatedEventResponse.orderViewComplatedEventResponseMessages = messagess;

            await publishEndpoint.Publish(orderViewComplatedEventResponse);
        }
    }
}
