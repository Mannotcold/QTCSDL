using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTCSDLHD.Functions;

namespace QTCSDLHD
{
    public partial class ChiTietChuyenXe : Form
    {
        string mactcx;
        TimChuyen control;
        public ChiTietChuyenXe(string mact)
        {
            InitializeComponent();
            this.mactcx = mact;
            control = new TimChuyen();
            loadListLichTrinh();        
        }

        private void loadListLichTrinh()
        {
            List<LichTrinh> list = control.loadListLichTrinh(this.mactcx);

            list.Sort((x, y) => x.mota.CompareTo(y.mota));

            dataGridViewLichTrinh.DataSource = list;

        }
    }
}
