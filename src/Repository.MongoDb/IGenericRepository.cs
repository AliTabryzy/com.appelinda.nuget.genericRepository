using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Repository.MongoDb
{
    internal interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> FindOne(FilterDefinition<TEntity> filterDefinition);
        Task<IEnumerable<TEntity>> FindMany(FilterDefinition<TEntity> filterDefinition,uint limit);
        Task<IEnumerable<TEntity>> FindMany(FilterDefinition<TEntity> filterDefinition,uint indexFrom,uint limit);

        Task<TEntity> CreateOne(TEntity T);    
        Task CreateMany(IEnumerable<TEntity> T);

        Task UpdateOne(FilterDefinition<TEntity> filterDefinition,UpdateDefinition<TEntity> updateDefinition);
        Task UpdateMany(FilterDefinition<TEntity> filterDefinition,UpdateDefinition<TEntity> updateDefinition);

        Task<long> Count(FilterDefinition<TEntity> filterDefinition);
        Task<long> EstimateCount();
        
        Task DeleteOne(FilterDefinition<TEntity> filterDefinition);
        Task DeleteMany(FilterDefinition<TEntity> filterDefinition);
    }
}