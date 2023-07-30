using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAN_S4.Models.DataModel
{
    public class Comment
    {

        [BsonId]
        [BsonElement("Id_Comment")]
        public string _id { get; set; }

        public string Id_Account { get; set; }

        public string Id_Product { get; set; }

        [BsonElement("Content")]
        [Required(ErrorMessage = "Tên Content không được để trống")]
        [MinLength(1, ErrorMessage = "Content không thể ít hơn 1 ký tự !")]
        [MaxLength(500, ErrorMessage = "Content không được quá 500 ký tự !")]
        public string Content { get; set; }

        public string DateTime { get; set; }
    }
}
