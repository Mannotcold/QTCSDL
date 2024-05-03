using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace QTCSDLHD
{
    class MonggoDB
    {
        public static void Connect(string collection)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var emp = db.GetCollection<BsonDocument>(collection);
                MessageBox.Show("Kết nối đến MongoDB thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("$Lỗi khi kết nối đến MongoDB: { ex.Message}");
            }
        }

        public static void InsertData()
        {
            try
            {
                // Kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");

                // Lấy collection từ cơ sở dữ liệu
                var empCollection = db.GetCollection<BsonDocument>("HoaDon");

                // Tạo một document mới để thêm vào collection
                var document = new BsonDocument
{
    { "HoaDon", new BsonDocument
        {
            { "MaHD", "HD001" },
            { "NgayLap", "01/05/2024" },
            { "TongGiaVe", 500000 },
            { "PhuongThucThanhToan", "Chuyen khoan" },
            { "TongSoVe", 2 },
            { "TrangThaiThanhToan", "Da thanh toan" },
            { "SDT", "0123456789" }
        }
    },
    { "Ve", new BsonArray
        {
            new BsonDocument
            {
                { "MaVe", "ABC123" }
            },
            new BsonDocument
            {
                { "MaVe", "XYZ456" }
            }
        }
    }
};

                // Thêm document vào collection
                empCollection.InsertOne(document);

                MessageBox.Show("Thêm dữ liệu vào MongoDB thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi thêm dữ liệu vào MongoDB: {ex.Message}");
            }
        }


        public static void SearchAndDisplay(string maHD, string ngayLap, DataGridView dgvResults)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var collection = db.GetCollection<BsonDocument>("HoaDon");
                // Tạo filter để tìm kiếm theo mã hóa đơn
                var filter = Builders<BsonDocument>.Filter.Or(
            Builders<BsonDocument>.Filter.Eq("HoaDon.MaHD", maHD),
            Builders<BsonDocument>.Filter.Eq("HoaDon.NgayLap", ngayLap)
        );

                // Thực hiện tìm kiếm trong collection
                var result = collection.Find(filter).FirstOrDefault();

                // Kiểm tra kết quả tìm kiếm
                if (result != null)
                {
                    // Lấy dữ liệu từ kết quả tìm kiếm và gán vào các biến
                    string maHoaDon = result["HoaDon"]["MaHD"].AsString;
                    string ngayLap1 = result["HoaDon"]["NgayLap"].AsString;
                    int tongGiaVe = result["HoaDon"]["TongGiaVe"].AsInt32;
                    string phuongThucThanhToan = result["HoaDon"]["PhuongThucThanhToan"].AsString;
                    int tongSoVe = result["HoaDon"]["TongSoVe"].AsInt32;
                    string trangThaiThanhToan = result["HoaDon"]["TrangThaiThanhToan"].AsString;
                    string SDT = result["HoaDon"]["SDT"].AsString;
                    // Thêm dòng mới vào DataGridView với thông tin của hóa đơn
                    dgvResults.Rows.Clear();
                    dgvResults.Rows.Add(maHoaDon, ngayLap1, tongGiaVe, phuongThucThanhToan, tongSoVe, trangThaiThanhToan, SDT);


                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã số " + maHD);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi thực hiện tìm kiếm: " + ex.Message);
            }
        }
    }

}

