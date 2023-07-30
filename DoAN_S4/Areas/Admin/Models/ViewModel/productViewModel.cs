using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.ViewModel
{
    public class productViewModel
    {
       
        public string _id { get; set; }

        public string  Name { get; set; }

        public string Images { get; set; }

        public float Quantity { get; set; }

        public string NameCategory { get; set; }

        public float Price { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }
    }
}
