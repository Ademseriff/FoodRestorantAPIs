using BasketApi.Models;
using BasketApi.Models.Contexts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Events;


namespace BasketApi.Consumers
{
    public class BasketItemAddedEventConsumer : IConsumer<BasketItemAddedEvent>
    {
        private readonly BasketAPIDbContext database;

        public BasketItemAddedEventConsumer(BasketAPIDbContext basketAPIDbContext)
        {
            database = basketAPIDbContext;
        }

        public async Task Consume(ConsumeContext<BasketItemAddedEvent> context)
        {
            try
            {
                BasketAdd basketAdd = new BasketAdd();
                basketAdd.Product = context.Message.Product;
                basketAdd.Price = context.Message.Price;
                basketAdd.Category = (Enums.FoodCategory)context.Message.Category;

                await database.AddAsync(basketAdd);
                await database.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Veritabanı güncelleme hatası
                Console.WriteLine($"Veritabanı güncelleme hatası: {ex.Message}");

                if (ex.InnerException != null)
                {
                    // İç istisnayı kontrol et
                    Console.WriteLine($"İç İstisna: {ex.InnerException.Message}");
                }

                // Daha fazla işlemler veya loglama ekleyebilirsiniz.
            }
            catch (Exception ex)
            {
                // Diğer genel hatalar
                Console.WriteLine($"Genel hata: {ex.Message}");
            }

        }
    }
}
