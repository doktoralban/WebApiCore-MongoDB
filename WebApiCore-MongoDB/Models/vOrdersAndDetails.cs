using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_MongoDB.Models
{
    public class vOrdersAndDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int orderID { get; set; }
        public string customerID { get; set; }
        public int employeeID { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public int shipVia { get; set; }
        public double freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipPostalCode { get; set; }
        public string shipCountry { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string quantityPerUnit { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public bool discontinued { get; set; }

    }
}
