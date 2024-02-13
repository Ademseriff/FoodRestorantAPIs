using BasketApi.Models.Contexts;
using MassTransit;
using Shared.Events;

namespace BasketApi.Consumers
{
    public class BasketDeleteRequestEventConsumer : IConsumer<BasketDeleteRequestEvent>
    {
        private readonly BasketAPIDbContext database;

        public BasketDeleteRequestEventConsumer(BasketAPIDbContext basketAPIDbContext)
        {
            database = basketAPIDbContext;
        }

        public async Task Consume(ConsumeContext<BasketDeleteRequestEvent> context)
        {
         
        database.basketAdds.RemoveRange(database.basketAdds);
          await database.SaveChangesAsync(); 
        }
    }
}
