using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Models.DataModel
{
    public class Product
    {
        [BsonId]
        public string  _id { get; set; }

        public string ProductName { get; set; }

        public string Images { get; set; }

        public float Quantity { get; set; }

        public int Id_Cate { get; set; }

        public float Price { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
