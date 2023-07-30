using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DoAN_S4.Models.DataModel
{
    public class Color
    {
        [BsonId]
        [BsonElement("Id_Color")]
        public int _id { get; set; }

        [BsonElement("ColorName")]
        [Required(ErrorMessage = "Tên color không được để trống")]
        [MinLength(1, ErrorMessage = "color không thể ít hơn 1 ký tự !")]
        [MaxLength(5, ErrorMessage = "color không được quá 5 ký tự !")]
        public string ColorName { get; set; }

        [BsonElement("Status")]
        public bool Status { get; set; }
    }
}
