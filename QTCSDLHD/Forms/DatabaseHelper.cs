using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCSDLHD.Forms
{
    internal class DatabaseHelper
    {
        private MongoClient client;
        private IMongoDatabase database;

        public DatabaseHelper()
        {
            // Thay thế 'yourDatabaseName' với tên database của bạn
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("TransportDB");
        }

        // Phương thức để lấy tất cả tài khoản từ collection 'TaiKhoan'
        public List<TaiKhoan> GetTaiKhoan()
        {
            var collection = database.GetCollection<TaiKhoan>("TaiKhoan");
            return collection.Find(new BsonDocument()).ToList();
        }

        public void AddTaiKhoan(TaiKhoan taiKhoan)
        {
            var collection = database.GetCollection<TaiKhoan>("TaiKhoan");
            collection.InsertOne(taiKhoan);
        }

        public bool UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            var collection = database.GetCollection<TaiKhoan>("TaiKhoan");
            var filter = Builders<TaiKhoan>.Filter.Eq("SĐT", taiKhoan.SĐT);
            var update = Builders<TaiKhoan>.Update
                .Set("Email", taiKhoan.Email)
                .Set("HoTen", taiKhoan.HoTen)
                .Set("MatKhau", taiKhoan.MatKhau)
                .Set("GioiTinh", taiKhoan.GioiTinh)
                .Set("NgaySinh", taiKhoan.NgaySinh)
                .Set("DiaChi", taiKhoan.DiaChi)
                .Set("NgheNghiep", taiKhoan.NgheNghiep);

            var result = collection.UpdateOne(filter, update);
            return result.ModifiedCount > 0;  // Trả về true nếu có bất kỳ tài khoản nào được cập nhật
        }

        public bool DeleteTaiKhoan(string sdt)
        {
            var collection = database.GetCollection<TaiKhoan>("TaiKhoan");
            var filter = Builders<TaiKhoan>.Filter.Eq("SĐT", sdt);
            var result = collection.DeleteOne(filter);
            return result.DeletedCount > 0;
        }

        public TaiKhoan FindTaiKhoanBySDT(string sdt)
        {
            var collection = database.GetCollection<TaiKhoan>("TaiKhoan");
            return collection.Find(taiKhoan => taiKhoan.SĐT == sdt).FirstOrDefault();
        }






    }
}

