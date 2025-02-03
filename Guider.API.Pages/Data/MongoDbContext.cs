using Guider.API.Pages.Models;
using MongoDB.Driver;

namespace Guider.API.Pages.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDb:DatabaseName"]);
        }

        public IMongoCollection<GenericDocument> GenericCollection =>
            _database.GetCollection<GenericDocument>("GenericCollection");
    }

}
