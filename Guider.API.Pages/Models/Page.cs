namespace Guider.API.Pages.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Page
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("data")]
        public BsonDocument Data { get; set; } = new BsonDocument();
    }
}
