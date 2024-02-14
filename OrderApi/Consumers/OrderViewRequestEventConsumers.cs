using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models.Contexts;
using Shared.Events;
using Shared.Message;

namespace OrderApi.Consumers
{
    public class OrderViewRequestEventConsumers : IConsumer<OrderViewRequestEvent>
    {
        private readonly OrderApiDbContext database;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderViewRequestEventConsumers(OrderApiDbContext orderApiDbContext, IPublishEndpoint publishEndpoint)
        {
            database = orderApiDbContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderViewRequestEvent> context)
        {
            List<Models.OrderAdd> ordersDb = await database.orderAdds.ToListAsync();
            List<Models.OrderDetails> orderDetailsDb  =await  database.orderDetails.ToListAsync();
           
            OrderViewResponseEvent orderViewResponseEvent = new OrderViewResponseEvent();


           
               
                    orderViewResponseEvent.OrderViewResponseEventMessage = orderDetailsDb.Select(o => new OrderViewResponseEventMessage()
                    {
                        Category = o.Category,
                        Email = o.Email,
                        Product = o.Product,
                        TotalPrice = o.TotalPrice,
                        OrderId = o.OrderAddId,
                        PhoneNumber = o.PhoneNumber,
                        Adress = o.Adress

                    }).ToList();
               
           


            await publishEndpoint.Publish(orderViewResponseEvent);
        }
    }
}
