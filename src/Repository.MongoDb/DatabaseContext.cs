using MongoDB.Driver;

namespace Repository.MongoDb
{
    public abstract partial class DatabaseContext<T>
        where T : class
    {
        protected readonly IMongoCollection<T> Collection;

        protected DatabaseContext(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            Collection = database.GetCollection<T>(collectionName);
        }
        
        protected DatabaseContext(MongoClientSettings mongoClientSettings,string databaseName, string collectionName)
        {
            var client = new MongoClient(mongoClientSettings);
            var database = client.GetDatabase(databaseName);
            Collection = database.GetCollection<T>(collectionName);
        }
    }
}