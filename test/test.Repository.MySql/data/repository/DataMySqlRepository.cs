using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.MySql;
using test.Repository.MySql.data.model;

namespace test.Repository.MySql.data.repository
{
    public class DataMySqlRepository : GenericRepository<DataMySql>
    {
        public DataMySqlRepository(DbContextOptions<DatabaseContext<DataMySql>> options,
            Action<DatabaseFacade> constructorAction, Action<DbContextOptionsBuilder> dbContextOptionBuilderAction,
            Action<ModelBuilder> modelBuilderAction) : base(options, constructorAction, dbContextOptionBuilderAction,
            modelBuilderAction)
        {
        }
    }
}