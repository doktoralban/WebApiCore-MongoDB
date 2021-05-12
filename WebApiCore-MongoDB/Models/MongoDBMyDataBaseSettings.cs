using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_MongoDB.Models
{
    //classın ve property lerin isimleri, appsettings teki isimle aynı isimde olmalı(MongoDBMyDataBaseSettings)
    public class MongoDBMyDataBaseSettings : IProductStoreDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductStoreDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
