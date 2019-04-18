using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.MySql
{
    internal interface IGenericRepository<TEntity>
        where TEntity : class
    {
        //Get & find 
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(IEnumerable<string> includes);
        Task<TEntity> Find(object id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<string> includes);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<string> includes);

        //create
        Task Create(TEntity entity);

        //update 
        Task Update(TEntity entity);

        //delete
        Task Delete(TEntity entity);
    }
}