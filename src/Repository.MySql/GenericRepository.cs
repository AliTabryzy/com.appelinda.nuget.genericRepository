using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Repository.MySql
{
    public class GenericRepository<TEntity> : DatabaseContext<TEntity>, IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(DbContextOptions<DatabaseContext<TEntity>> options
            ,Action<DatabaseFacade> constructorAction
            ,Action<DbContextOptionsBuilder> dbContextOptionBuilderAction
            ,Action<ModelBuilder> modelBuilderAction) 
            : base(options,constructorAction,dbContextOptionBuilderAction,modelBuilderAction)
        {
        }

        public async Task<TEntity> Find(object id)
        {
            switch (id)
            {
                case long longVal:
                    return await FindAsync<TEntity>(longVal);
                case string stringVal:
                    return await FindAsync<TEntity>(stringVal);
                case int intVal:
                    return await FindAsync<TEntity>(intVal);
                default:
                    throw new NotSupportedException();
            }
        }


        public IQueryable<TEntity> GetAll(IEnumerable<string> includes)
        {
            var query = Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.AsNoTracking();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<string> includes)
        {
            var query = Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await
                query
                    .AsNoTracking()
                    .FirstOrDefaultAsync(predicate);
        }


        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }


        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes)
        {
            var query = Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query
                .AsNoTracking()
                .Where(predicate);
        }


        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);
        }

        public async Task Create(TEntity entity)
        {
            if (entity == null) return;
            await Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null) return;
            Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            if (entity == null) return;
            Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }
    }
}