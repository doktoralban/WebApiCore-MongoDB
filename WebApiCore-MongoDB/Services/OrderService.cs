using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore_MongoDB.Models;

namespace WebApiCore_MongoDB.Services
{
    public class OrderService  
    {
        private readonly IMongoCollection<vOrdersAndDetails> _vOrdersAndDetails;

        public OrderService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _vOrdersAndDetails = database.GetCollection<vOrdersAndDetails>("vOrdersAndDetails");
        }


        public List<vOrdersAndDetails> GetOrderAndDetails()
        {
            return _vOrdersAndDetails.Find(vOrdersAndDetails => true).ToList().Take(100).ToList();
        }





    }
}
