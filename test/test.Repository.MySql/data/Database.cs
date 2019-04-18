using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.MySql;
using test.Repository.MySql.data.domain;
using test.Repository.MySql.data.model;
using test.Repository.MySql.data.repository;

namespace test.Repository.MySql.data
{
    public class Database : IDataBase
    {
        private readonly IOptions<AppSettings> _options;

        public Database(IOptions<AppSettings> options)
        {
            _options = options;
        }

        public Lazy<DataMySqlRepository> DataMysql
        {
            get
            {
                
                var dbOptions = new DbContextOptionsBuilder<DatabaseContext<DataMySql>>()
                    .UseMySql(_options.Value.MySqlConnectionString)
                    .Options;
                return new Lazy<DataMySqlRepository>(new DataMySqlRepository(dbOptions,
                    facade => { facade.EnsureCreated(); },
                    null
                    , builder =>
                    {
                        builder.Entity<DataMySql>().HasKey(z=>z.Id);
                        
                    }));
            }
        }
    }
}