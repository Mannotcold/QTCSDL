using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using System.Data;
using System.Windows.Forms;
using ServiceStack;

namespace QTCSDLHD.Functions
{
        public class ChiTietChuyenXe
        {
            public string mactcx { get; set; }
            public string machuyenxe { get; set; }
            public DateTime ngaydi { get; set; }
            public DateTime giodi { get; set; }
            public DateTime gioden { get; set; }
        }

        public class LichTrinh
        {
            public string malichtrinh { get; set; }
            public string mota { get; set; }
            public string mactcx { get; set; }
        }

        public class ChuyenXe
        {
            public string machuyenxe { get; set; }
            public string diemdi { get; set; }
            public string diemden { get; set; }
            public string loaixe { get; set; }
            public int giatien { get; set; }
        }

        public class DiaChi
        {
            public string madiachi { get; set; }
            public string tinh { get; set; }
            public string tendiachi { get; set; }
            public string address { get; set; }
        }

        public class CassandraDB
        {
            private Cluster cluster;
            private ISession session;

            public CassandraDB()
            {
                cluster = Cluster.Builder().AddContactPoints("127.0.0.1").WithPort(9042).Build();

                session = cluster.Connect();
                session.Execute($"USE QLDA");
            }

            public void Shutdown()
            {
                cluster.Shutdown();
                session.Dispose();
            }

            public RowSet ExecuteQuery(string cqlQuery)
            {
                return session.Execute(cqlQuery);
            }

            public List<DiaChi> getDiaChi()
            {
                var result = session.Execute("SELECT * FROM diachi");

                var diaChiList = new List<DiaChi>();

                foreach (var row in result)
                {
                    var diaChi = new DiaChi
                    {
                        madiachi = row.GetValue<string>("madiachi"),
                        tinh = row.GetValue<string>("tinh"),
                        tendiachi = row.GetValue<string>("tendiachi"),
                        address = row.GetValue<string>("address")
                    };
                    diaChiList.Add(diaChi);
                }
                return diaChiList;
            }

            public List<ChuyenXe> getChuyenXe(string diemden, string diemdi)
            {
                var result = session.Execute("SELECT * FROM chuyenxe WHERE diemdi = '" + diemdi + "' AND diemden = '" + diemden + "' ALLOW FILTERING;");

                var chuyenXeList = new List<ChuyenXe>();

                foreach (var row in result)
                {
                    var chuyenXe = new ChuyenXe
                    {
                        machuyenxe = row.GetValue<string>("machuyenxe"),
                        diemdi = row.GetValue<string>("diemdi"),
                        diemden = row.GetValue<string>("diemden"),
                        loaixe = row.GetValue<string>("loaixe"),
                        giatien = row.GetValue<int>("giatien")
                    };
                    chuyenXeList.Add(chuyenXe);
                }
                return chuyenXeList;
            }

            public List<object> getChiTietChuyenXe(string diemden, string diemdi, string ngaydi)
            {
                var result = session.Execute("SELECT * FROM chuyenxe WHERE diemdi = '" + diemdi + "' AND diemden = '" + diemden + "' ALLOW FILTERING;");

                List<object> chiTietList = new List<object>();

                foreach (var row in result)
                {
                    object MaChuyenXe = row["machuyenxe"].ToString();
                    var ChiTietResult = session.Execute("SELECT * FROM chitietchuyenxe WHERE ngaydi = '" + ngaydi + "' AND machuyenxe = '" + MaChuyenXe + "' ALLOW FILTERING;");

                    foreach (var chiTietRow in ChiTietResult)
                    {
                        chiTietList.Add(new
                        {
                            mactcx = chiTietRow["mactcx"].ToString(),
                            machuyenxe = MaChuyenXe,
                            diemdi = row["diemdi"].ToString(),
                            diemden = row["diemden"].ToString(),
                            loaixe = row["loaixe"].ToString(),
                            giatien = row["giatien"].ToString(),
                            ngaydi = chiTietRow["ngaydi"].ToString(),
                            giodi = chiTietRow["giodi"].ToString(),
                            gioden = chiTietRow["gioden"].ToString(),
                        });
                    }
                }
                return chiTietList;
            }

            public List<LichTrinh> getChiTietLichTrinh(string mactcx)
            {
                var result = session.Execute("SELECT * FROM lichtrinh WHERE mactcx = '" + mactcx + "' ALLOW FILTERING;");

                var listLichTrinh = new List<LichTrinh>();

                foreach (var row in result)
                {
                    var lichTrinh = new LichTrinh();
                    lichTrinh.mota = row["mota"].ToString();
                    listLichTrinh.Add(lichTrinh);
                }
                return listLichTrinh;

            }
        }

        public class TimChuyen
        {
            CassandraDB CassandraDB = new CassandraDB();
            public List<DiaChi> loadListDiaDiem()
            {
                return CassandraDB.getDiaChi();
            }
            public List<object> loadListChuyenXe(string diemden, string diemdi, string ngaydi)
            {
                return CassandraDB.getChiTietChuyenXe(diemden, diemdi, ngaydi);
            }
            public List<LichTrinh> loadListLichTrinh(string ct)
            {
                return CassandraDB.getChiTietLichTrinh(ct);
            }
        }
}
