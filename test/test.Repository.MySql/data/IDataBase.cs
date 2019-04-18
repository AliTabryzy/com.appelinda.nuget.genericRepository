using System;
using test.Repository.MySql.data.repository;

namespace test.Repository.MySql.data
{
    public interface IDataBase
    {
        Lazy<DataMySqlRepository> DataMysql { get;}
    }
}