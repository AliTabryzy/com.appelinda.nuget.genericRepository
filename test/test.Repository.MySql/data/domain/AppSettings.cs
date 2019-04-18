using System;
using Newtonsoft.Json;

namespace test.Repository.MySql.data.domain
{
    public class AppSettings
    {
        public MongoConnString MongoDbConnectionString { get; set; }

        public string MySqlConnectionString { get; set; }
    }


    public class MongoConnString
    {
        [JsonProperty("server")] public string Server { get; set; }
        [JsonProperty("port")] public int Port { get; set; }
        [JsonProperty("dbName")] public string DbName { get; set; }

        public override string ToString()
        {
            return $"mongodb://{Server}:{Convert.ToString(Port)}";
        }
    }
}