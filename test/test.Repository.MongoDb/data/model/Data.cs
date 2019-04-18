using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test.Repository.MongoDb.data.model
{
    public class Data
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string Value { get; set; }
    }
}