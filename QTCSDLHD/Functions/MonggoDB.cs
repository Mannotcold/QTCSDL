using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static void Connect(string collection1)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var collection = db.GetCollection<BsonDocument>("HoaDon");
                MessageBox.Show("Kết nối đến MongoDB thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("$Lỗi khi kết nối đến MongoDB: { ex.Message}");
            }
        }

//        public static void InsertData()
//        {
//            try
//            {
//                // Kết nối đến MongoDB
//                var dbClient = new MongoClient("mongodb://localhost:27017");
//                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");

//                // Lấy collection từ cơ sở dữ liệu
//                var empCollection = db.GetCollection<BsonDocument>("HoaDon");

//                // Tạo một document mới để thêm vào collection
//                var document = new BsonDocument
//{
//    { "HoaDon", new BsonDocument
//        {
//            { "MaHD", "HD002" },
//            { "NgayLap", "01/05/2024" },
//            { "TongGiaVe", 500000 },
//            { "PhuongThucThanhToan", "Chuyen khoan" },
//            { "TongSoVe", 2 },
//            { "TrangThaiThanhToan", "Da thanh toan" },
//            { "SDT", "0123456789" }
//        }
//    },
//    { "Ve", new BsonArray
//        {
//            new BsonDocument
//            {
//                { "MaVe", "ABC123" }
//            },
//            new BsonDocument
//            {
//                { "MaVe", "XYZ456" }
//            }
//        }
//    }
//};

//                // Thêm document vào collection
//                empCollection.InsertOne(document);

//                MessageBox.Show("Thêm dữ liệu vào MongoDB thành công!");
//            }
//            catch (Exception ex)
//            {
//                // Xử lý lỗi nếu có
//                MessageBox.Show($"Lỗi khi thêm dữ liệu vào MongoDB: {ex.Message}");
//            }
//        }


        public static void SearchAndDisplay(string maHD, string ngayLap, DataGridView dgvResults)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var collection = db.GetCollection<BsonDocument>("HoaDon");
                
                var filter = Builders<BsonDocument>.Filter.Or(
           Builders<BsonDocument>.Filter.Eq("HoaDon.MaHD", maHD),
           Builders<BsonDocument>.Filter.Eq("HoaDon.NgayLap", ngayLap)
       );
                // Tạo filter để tìm kiếm theo mã hóa đơn
               

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

        public static void DisplayAllDocuments(DataGridView dgvResults)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var collection = db.GetCollection<BsonDocument>("HoaDon");
                


                // Thực hiện truy vấn để lấy tất cả các hóa đơn
                var results = collection.Find(new BsonDocument()).ToList();

                // Kiểm tra kết quả tìm kiếm
                if (results.Count > 0)
                {
                    // Hiển thị thông tin của tất cả các hóa đơn
                    dgvResults.Rows.Clear();
                    foreach (var result in results)
                    {
                        string maHoaDon = result["HoaDon"]["MaHD"].AsString;
                        string ngayLap = result["HoaDon"]["NgayLap"].AsString;
                        int tongGiaVe = result["HoaDon"]["TongGiaVe"].AsInt32;
                        string phuongThucThanhToan = result["HoaDon"]["PhuongThucThanhToan"].AsString;
                        int tongSoVe = result["HoaDon"]["TongSoVe"].AsInt32;
                        string trangThaiThanhToan = result["HoaDon"]["TrangThaiThanhToan"].AsString;
                        string sdt = result["HoaDon"]["SDT"].AsString;

                        dgvResults.Rows.Add(maHoaDon, ngayLap, tongGiaVe, phuongThucThanhToan, tongSoVe, trangThaiThanhToan, sdt);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi thực hiện tìm kiếm: " + ex.Message);
            }
        }


        public static void DisplayTicketsByInvoiceID(string maHD)
        {
            try
            {
                // Thực hiện kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
                var collection = db.GetCollection<BsonDocument>("HoaDon");
                

                // Thực hiện truy vấn để tìm kiếm hóa đơn với mã hóa đơn cụ thể
                var filter = Builders<BsonDocument>.Filter.Eq("HoaDon.MaHD", maHD);


                // Thực hiện tìm kiếm trong collection
                var result = collection.Find(filter).FirstOrDefault();

                // Kiểm tra kết quả tìm kiếm
                if (result != null)
                {
                    // Lấy mảng vé từ kết quả tìm kiếm
                    var tickets = result["Ve"].AsBsonArray;

                    // Tạo một chuỗi StringBuilder để lưu thông tin của từng vé
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Thông tin vé của hóa đơn có mã số {maHD}:");
                    foreach (var ticket in tickets)
                    {
                        string maVe = ticket["MaVe"].AsString;
                        sb.AppendLine($"- Mã vé: {maVe}");
                    }

                    // Hiển thị thông tin trên MessageBox
                    MessageBox.Show(sb.ToString());
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



        public void LoadMaGheToCheckedListBox(CheckedListBox checkedListBox, int maChuyenXe)
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
            var collection = db.GetCollection<BsonDocument>("ChuyenXe");
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Empty; // Filter mặc định

            // Chuyển đổi maChuyenXe sang BsonValue
            var maChuyenXeBson = BsonValue.Create(maChuyenXe);

            // Tạo filter để lấy thông tin về ghế theo maChuyenXe
            filter = Builders<BsonDocument>.Filter.Eq("chuyen_xe.thong_tin_chuyen_xe.MaChuyenXe", maChuyenXeBson);

            // Thực hiện truy vấn và lấy kết quả
            var result = collection.Find(filter).FirstOrDefault();

            // Kiểm tra xem kết quả có tồn tại không
            if (result != null)
            {
                // Lấy thông tin về ghế từ kết quả
                var thongTinGheArray = result["chuyen_xe"]["thong_tin_ghe"].AsBsonArray;

                // Xóa các mục hiện có trong CheckedListBox trước khi thêm mới
                checkedListBox.Items.Clear();

                // Thêm MaGhe vào CheckedListBox
                foreach (var ghe in thongTinGheArray)
                {
                    string tinhTrang = ghe["TinhTrang"].ToString();
                    if (tinhTrang != "Đã bán")
                    {
                        var maGhe = ghe["MaGhe"].ToString();
                        checkedListBox.Items.Add(maGhe);
                    }

                }
            }
            // Thiết lập CheckOnClick để ngăn người dùng chọn các MaGhe có TinhTrang là "Đã bán"
            checkedListBox.CheckOnClick = true;
        }

        public void LoadThongTinGheToDGV
            (DataGridView dgv, List<string[]> selectedGheInfoList, CheckedListBox checkedListBoxChonghe, int maChuyenXe)
        {
            //List<string[]> selectedGheInfoList = new List<string[]>();
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");
            var collection = db.GetCollection<BsonDocument>("ChuyenXe");
            var filterBuilder = Builders<BsonDocument>.Filter;
            //var filter = filterBuilder.Empty; // Filter mặc định

            // Duyệt qua tất cả các mục được chọn trong CheckedListBox và lấy thông tin từ MongoDB
            foreach (var selectedItem in checkedListBoxChonghe.SelectedItems)
            {
                int maGhe = Convert.ToInt32(selectedItem.ToString());

                // Tạo filter để lấy thông tin về ghế có mã là maGhe và có mã chuyến xe là maChuyenXe
                //var filterBuilder = Builders<BsonDocument>.Filter;
                var filter = filterBuilder.And(
                    filterBuilder.Eq("chuyen_xe.thong_tin_ghe.MaGhe", maGhe),
                    filterBuilder.Eq("chuyen_xe.thong_tin_chuyen_xe.MaChuyenXe", maChuyenXe)
                );

                // Thực hiện truy vấn và lưu kết quả vào danh sách
                var result = collection.Find(filter).FirstOrDefault();
                if (result != null)
                {
                    var chuyenXe = result["chuyen_xe"].AsBsonDocument;
                    var tt_chuyenXe = chuyenXe["thong_tin_chuyen_xe"].AsBsonDocument;
                    var ghe = chuyenXe["thong_tin_ghe"].AsBsonArray.FirstOrDefault(g => g["MaGhe"].AsInt32 == maGhe).AsBsonDocument;

                    // Thêm thông tin của ghế vào danh sách
                    selectedGheInfoList.Add(new string[] {
                    maChuyenXe.ToString(),
                    maGhe.ToString(),
                    ghe["TinhTrang"].AsString,
                    ghe["GiaVe"].AsInt32.ToString(),
                    ghe["HangGhe"].AsString,
                    ghe["Tang"].AsString,
                    tt_chuyenXe["DiemDi"].AsString, //DiemDon
                    tt_chuyenXe["DiemDen"].AsString //DiemTra
                    });
                }
            }

            // Hiển thị thông tin của các ghế đã chọn trong DataGridView
            dgv.Rows.Clear();
            foreach (var gheInfo in selectedGheInfoList)
            {
                dgv.Rows.Add(gheInfo);
            }

        }

        public static void InsertDataVe(string hoten, string sdt, string email, DataGridView dgv)
        {
            try
            {
                // Kết nối đến MongoDB
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("QTCSDLHD");

                // Lấy collection từ cơ sở dữ liệu
                var collection = db.GetCollection<BsonDocument>("Ve");
                var filterBuilder = Builders<BsonDocument>.Filter;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow) // Kiểm tra nếu không phải là dòng mới
                    {
                        string diemDon = row.Cells["DiemDon"].Value.ToString();
                        string diemTra = row.Cells["DiemTra"].Value.ToString();
                        int maGhe = Convert.ToInt32(row.Cells["MaGhe"].Value);
                        int maChuyenXe = Convert.ToInt32(row.Cells["MaChuyenXe"].Value);

                        // Tạo một document mới để thêm vào collection
                        var document = new BsonDocument
                        {
                        { "MaVe", 6 },
                        { "DiemDon", diemDon },
                        { "DiemTra", diemTra },
                        { "MaGhe", maGhe },
                        { "MaChuyenXe", maChuyenXe },
                        { "HoVaTen", hoten },
                        { "SDT", sdt },
                        { "Email", email }
                        };

                        // Thêm document vào collection
                        collection.InsertOne(document);

                        // Tạo filter để cập nhật trạng thái của ghế
                        var filterGhe = Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("thong_tin_ghe.MaGhe", maGhe),
                            Builders<BsonDocument>.Filter.Eq("thong_tin_chuyen_xe.MaChuyenXe", maChuyenXe)
                        );

                        // Xây dựng update để cập nhật trạng thái của ghế
                        var updateGhe = Builders<BsonDocument>.Update.Set("thong_tin_ghe.$.TinhTrang", "Đã bán");

                        // Thực hiện cập nhật trong collection ChuyenXe
                        var resultGhe = collection.UpdateOne(filterGhe, updateGhe);
                    }
                }


                MessageBox.Show("Thêm dữ liệu vào MongoDB thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi thêm dữ liệu vào MongoDB: {ex.Message}");
            }
        }

    }

}

