using MassTransit;
using OrderApi.Models;
using OrderApi.Models.Contexts;
using Shared.Enums;
using Shared.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Consumers
{
    public class OrderCreatedEventConsumers : IConsumer<OrderCreatedEvent>
    {
        private readonly OrderApiDbContext database;

        public OrderCreatedEventConsumers(OrderApiDbContext orderApiDbContext)
        {
            database = orderApiDbContext;
            
        }
     

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            try
            {
                OrderAdd orderAdd = new OrderAdd();
                orderAdd.OrderId = context.Message.Id;
                orderAdd.State = Enums.State.pending;
                orderAdd.OrderDetails = context.Message.OrderCreatedEventMessage.Select(contex => new OrderDetails()
                {
                    TotalPrice = contex.TotalPrice,
                    Category = contex.Category,
                    Product = contex.Product,
                    Email = contex.Email,
                    Adress = contex.Adress,
                    PhoneNumber = contex.PhoneNumber
                    
                }).ToList();
                await database.AddAsync(orderAdd);
               await database.SaveChangesAsync();

            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
