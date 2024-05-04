using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCSDLHD.Forms
{
    public class TaiKhoan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Chỉ cần nếu bạn muốn lưu _id dưới dạng string trong C#
        public string Id { get; set; }

        public string SĐT { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string NgheNghiep { get; set; }
    }
}
