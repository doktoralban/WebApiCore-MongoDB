using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore_MongoDB.Models;

namespace WebApiCore_MongoDB.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<vOrdersAndDetails> _vOrdersAndDetails;

        public ProductService(IProductStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);

            //..
            _vOrdersAndDetails = database.GetCollection<vOrdersAndDetails>("vOrdersAndDetails");
        }




        public List<Product> Get() =>
            _products.Find(product => true).ToList();

        public Product Get(string id) =>
            _products.Find<Product>(book => book.Id == id).FirstOrDefault();

        public List<vOrdersAndDetails> GetOrderAndDetails()
        {
            return     _vOrdersAndDetails.Find(vOrdersAndDetails => true).ToList().Take(1000000).ToList();
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn) =>
            _products.ReplaceOne(product => product.Id == id, productIn);

        public void Remove(Product productIn) =>
            _products.DeleteOne(product => product.Id == productIn.Id);

        public void Remove(string id) =>
            _products.DeleteOne(product => product.Id == id);



    }
}
 
