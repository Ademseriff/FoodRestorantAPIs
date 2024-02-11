using BasketApi.Enums;
using BasketApi.Models;
using BasketApi.Models.Contexts;
using BasketApi.ViewModel;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Events;
using Shared.Message;

namespace BasketApi.Consumers
{
    public class BasketViewRequestEventConsumer : IConsumer<BasketViewRepuestEvent>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly BasketAPIDbContext database;

        public BasketViewRequestEventConsumer(IPublishEndpoint publishEndpoint, BasketAPIDbContext basketAPIDbContext)
        {
            this.publishEndpoint = publishEndpoint;
            database = basketAPIDbContext;
        }

        public async Task Consume(ConsumeContext<BasketViewRepuestEvent> context)
        {
            List<BasketAdd> Baskets = await database.basketAdds.ToListAsync();

            Shared.Message.OrderItemMessega orderItemMessega = new Shared.Message.OrderItemMessega() { };
            
            BasketViewResponseEvent ResponseEvent = new BasketViewResponseEvent()
            {
                Id = 1,
                OrderItems = Baskets.Select(oi => new OrderItemMessega()
                {
                     Id = oi.Id,
                     Price = oi.Price,
                     Product = oi.Product,
                     Category = (Category)oi.Category

                }).ToList(),
            };
           
         
            await publishEndpoint.Publish(ResponseEvent);

        }
    }
}
