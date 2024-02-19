using MassTransit;
using MongoDB.Driver;
using OrderBackupApi.Models;
using OrderBackupApi.Services;
using Shared.Events;
using Shared.Message;

namespace OrderBackupApi.Consumers
{
    public class OrderBackupCreatedEventConsumers : IConsumer<OrderCreatedEvent>
    {
        private readonly MongoDBService mongoDBService;

        public OrderBackupCreatedEventConsumers(MongoDBService mongoDBService)
        {
            this.mongoDBService = mongoDBService;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            try
            {
                IMongoCollection<OrderBackup> collection = mongoDBService.GetCollection<OrderBackup>();
                await collection.InsertOneAsync(new OrderBackup
                {
                    Id = context.Message.Id,
                    State = context.Message.State,
                    OrderBackupContents = context.Message.OrderCreatedEventMessage.Select(oi => new OrderBackupContent()
                    {
                        Adress = oi.Adress,
                        Category = oi.Category,
                        Email = oi.Email,
                        PhoneNumber = oi.PhoneNumber,
                       Product = oi.Product,
                       TotalPrice = oi.TotalPrice
                      
                    }).ToList()
                });
               
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama veya hata ayıklama amacıyla yazdırma
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
}
