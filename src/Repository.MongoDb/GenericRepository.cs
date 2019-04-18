using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Repository.MongoDb
{
    public abstract class GenericRepository<T> : DatabaseContext<T>, IGenericRepository<T> where T : class
    {
        public GenericRepository(string connectionString, string databaseName, string collectionName) : base(
            connectionString,
            databaseName, collectionName)
        {
        }

        protected GenericRepository(MongoClientSettings mongoClientSettings, string databaseName, string collectionName)
            : base(mongoClientSettings, databaseName, collectionName)
        {
        }

        public async Task<T> FindOne(FilterDefinition<T> filterDefinition)
        {
            return await Collection.Find(filterDefinition).Limit(1).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindMany(FilterDefinition<T> filterDefinition, uint limit = 100)
        {
            return await Collection.Find(filterDefinition).Limit((int?) limit).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindMany(FilterDefinition<T> filterDefinition,uint indexFrom, uint limit)
        {
            if (limit < 1) throw new ArgumentOutOfRangeException($"{nameof(limit)} must be greater than 0");
            return await Collection.Find(filterDefinition).Skip((int?) indexFrom).Limit((int?) limit).ToListAsync();
        }


        public async Task<T> CreateOne(T T)
        {
            await Collection.InsertOneAsync(T);
            return T;
        }

        public async Task CreateMany(IEnumerable<T> T)
        {
            await Collection.InsertManyAsync(T);
        }

        public async Task UpdateOne(FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition)
        {
            await Collection.UpdateOneAsync(filterDefinition, updateDefinition);
        }

        public async Task UpdateMany(FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition)
        {
            await Collection.UpdateManyAsync(filterDefinition, updateDefinition);
        }

        public async Task<long> Count(FilterDefinition<T> filterDefinition)
        {
            return await Collection.CountDocumentsAsync(filterDefinition);
        }

        public async Task<long> EstimateCount()
        {
            return await Collection.EstimatedDocumentCountAsync();
        }

        public async Task DeleteOne(FilterDefinition<T> filterDefinition)
        {
            await Collection.DeleteOneAsync(filterDefinition);
        }

        public async Task DeleteMany(FilterDefinition<T> filterDefinition)
        {
            await Collection.DeleteManyAsync(filterDefinition);
        }
    }
}