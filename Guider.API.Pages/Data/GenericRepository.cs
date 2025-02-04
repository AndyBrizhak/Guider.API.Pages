using Guider.API.Pages.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Guider.API.Pages.Data
{
    public class GenericRepository
    {
        private readonly IMongoCollection<GenericDocument> _collection;

        public GenericRepository(MongoDbContext context)
        {
            _collection = context.GenericCollection;
        }

        public async Task<List<GenericDocument>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<GenericDocument?> GetByIdAsync(string id) =>
            await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(GenericDocument document) =>
            await _collection.InsertOneAsync(document);

        public async Task UpdateAsync(string id, BsonDocument newData) =>
            await _collection.UpdateOneAsync(
                Builders<GenericDocument>.Filter.Eq(doc => doc.Id, id),
                Builders<GenericDocument>.Update.Set(doc => doc.Data, newData));

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(doc => doc.Id == id);

        public async Task<List<GenericDocument>> SearchByFieldAsync(string key, string value)
        {
            var filter = Builders<GenericDocument>.Filter.Eq($"data.{key}", value);
            return await _collection.Find(filter).ToListAsync();
        }

    }

}
