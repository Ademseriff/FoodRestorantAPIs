using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models.Contexts;
using Shared.Enums;
using Shared.Events;

namespace OrderApi.Consumers
{
    public class OrderFailedEventConsumers : IConsumer<OrderFailedEvent>
    {
        private readonly OrderApiDbContext database;

        public OrderFailedEventConsumers(OrderApiDbContext orderApiDbContext)
        {
            database = orderApiDbContext;
        }

        public async Task Consume(ConsumeContext<OrderFailedEvent> context)
        {
            // Önce güncellemek istediğiniz varlığı bulun
            var orderId = context.Message.id; // Örnek olarak sipariş numarasını kullanalım
            var orderToUpdate = await database.orderAdds.FirstOrDefaultAsync(x => x.Id == orderId);

            if (orderToUpdate != null)
            {
                // Varlık bulundu, şimdi güncelleme işlemini yapabiliriz
                // Örneğin, bir alanı güncelleyelim:
                orderToUpdate.State = Enums.State.failed;

                // Şimdi değişiklikleri veritabanına kaydedin
                await database.SaveChangesAsync();
            }
        }
    }
}
