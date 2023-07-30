using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Models.DataModel
{
    public class Discout_Code
    {
        [BsonId]
        [BsonElement("Id_Code ")]
        public string _id { get; set; }

        [BsonElement("Code")]
        [Required(ErrorMessage = "Tên Content không được để trống")]
        [MaxLength(6, ErrorMessage = "Content không được quá 6 ký tự !")]
        public string Code { get; set; }

        [BsonElement("Price")]
        [Required(ErrorMessage = "Tên giá không được để trống")]
        public string Price { get; set; }

        [BsonElement("Create_At")]
        [Required(ErrorMessage = "ngày tạo không được để trống")]
        public string Create_At { get; set; }

        [BsonElement("Update_At")]
        [Required(ErrorMessage = "ngày hết hạn không được để trống")]
        public string Update_At { get; set; }
    }
}
