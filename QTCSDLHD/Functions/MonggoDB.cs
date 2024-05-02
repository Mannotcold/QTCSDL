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
                var empCollection = db.GetCollection<BsonDocument>("LichSu");

                // Tạo một document mới để thêm vào collection
                var document = new BsonDocument
{
    { "lich_su_mua_ve", new BsonDocument
        {
            { "thong_tin_chuyen_xe", new BsonDocument
                {
                    { "tuyen_duong", "Diem_di - Diem_den" },
                    { "ngay_di", "dd/MM/yyyy" }
                }
            },
            { "thong_tin_ve", new BsonDocument
                {
                    { "ma_ve", "ABC123" },
                    { "thong_tin_hoa_don", new BsonDocument
                        {
                            { "tong_so_ve", 2 },
                            { "so_tien", 500000 },
                            { "phuong_thuc_thanh_toan", "Chuyen khoan" },
                            { "trang_thai", "Da thanh toan" }
                        }
                    }
                }
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


        // Hàm tìm kiếm với 4 loại điều kiện và hiển thị kết quả trên DataGridView
        public void SearchAndDisplayOnDGV(DataGridView dgv, string maVe = null, DateTime? thoiGian = null, string tuyenDuong = null, string trangThai = null)
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
            var collection = db.GetCollection<BsonDocument>("LichSu"); // Thay "Ten_Collection" bằng tên collection của bạn
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Empty; // Filter mặc định

            // Thêm điều kiện tìm kiếm vào filter nếu giá trị được cung cấp
            if (!string.IsNullOrEmpty(maVe))
            {
                filter &= filterBuilder.Eq("ma_ve", maVe);
            }
            if (thoiGian.HasValue)
            {
                filter &= filterBuilder.Eq("ngay_di", thoiGian);
            }
            if (!string.IsNullOrEmpty(tuyenDuong))
            {
                filter &= filterBuilder.Eq("tuyen_duong", tuyenDuong);
            }
            if (!string.IsNullOrEmpty(trangThai))
            {
                filter &= filterBuilder.Eq("trang_thai", trangThai);
            }

            // Thực hiện truy vấn và lấy kết quả
            var results = collection.Find(filter).ToList();

            // Hiển thị kết quả trên DataGridView
            dgv.Rows.Clear();
            foreach (var result in results)
            {
                // Chuyển đổi BsonDocument sang Dictionary để dễ dàng truy cập
                var documentDictionary = result.ToDictionary();

                // Thêm dòng mới vào DataGridView và gán giá trị từ Dictionary
                dgv.Rows.Add(documentDictionary.Values.ToArray());
            }
        }
    }

}

