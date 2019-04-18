using System.ComponentModel.DataAnnotations;

namespace test.Repository.MySql.data.model
{
    public class DataMySql
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}