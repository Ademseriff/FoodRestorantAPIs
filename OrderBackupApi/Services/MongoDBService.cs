using MongoDB.Driver;

namespace OrderBackupApi.Services
{
  
        public class MongoDBService
        {
            readonly IMongoDatabase _Database;
            // mongodb://localhost:27017
            //IConfiguration ile vermiş olmamızın sebebi otomatik olarak çekebilmesi jsondan. order apiye bak program.csde configration ile verdik.
            public MongoDBService(IConfiguration configuration)
            {
                //bak burda yaptığımız gibi dependency injection ile elde ettigimiz connection string ile elde ettik.
                MongoClient client = new(configuration.GetConnectionString("MongoDB"));
                _Database = client.GetDatabase("OrderBackup");
            }

            public IMongoCollection<T> GetCollection<T>() => _Database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());


        }
 }

