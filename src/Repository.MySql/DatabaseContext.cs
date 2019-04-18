using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Repository.MySql
{
    public class DatabaseContext<T> : DbContext
        where T : class
    {
        private readonly DatabaseFacade _database;
        private readonly Action<DbContextOptionsBuilder> _dbContextOptionsBuilderAction;
        private readonly Action<ModelBuilder> _modelBuilderAction;

        protected DatabaseContext(DbContextOptions<DatabaseContext<T>> options
            , Action<DatabaseFacade> constructorAction
            , Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction
            ,Action<ModelBuilder> modelBuilderAction)
            : base(options)
        {
            _database = Database;
            constructorAction.Invoke(Database);
            _dbContextOptionsBuilderAction = dbContextOptionsBuilderAction;
            _modelBuilderAction = modelBuilderAction;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _dbContextOptionsBuilderAction?.Invoke(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _modelBuilderAction?.Invoke(modelBuilder);
        }
    }
}