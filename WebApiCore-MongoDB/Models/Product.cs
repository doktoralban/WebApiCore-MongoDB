using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_MongoDB.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Key]
            public int productID { get; set; }
            public string productName { get; set; }
            public int supplierID { get; set; }
            public int categoryID { get; set; }
            public string quantityPerUnit { get; set; }
            public double unitPrice { get; set; }
            public int unitsInStock { get; set; }
            public int unitsOnOrder { get; set; }
            public int reorderLevel { get; set; }
            public bool discontinued { get; set; }
        

    }
}
