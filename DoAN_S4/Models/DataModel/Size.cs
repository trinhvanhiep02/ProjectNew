using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Models.DataModel
{
    public class Size
    {
        [BsonId]
        [BsonElement("_id")]
        public int _id { get; set; }

        [BsonElement("SizeName")]
        [Required(ErrorMessage = "Tên size không được để trống")]
        [MinLength(1, ErrorMessage ="Size không thể ít hơn 1 ký tự !")]
        [MaxLength(5, ErrorMessage = "Size không được quá 5 ký tự !")]
        public string SizeName { get; set; }

        [BsonElement("Status")]
        public bool Status { get; set; }
    }
}
