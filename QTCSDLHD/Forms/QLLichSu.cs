﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTCSDLHD;

namespace QTCSDLHD
{
    public partial class QLLichSu : Form
    {
        public QLLichSu()
        {
            InitializeComponent();
        }


        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            MonggoDB.Connect("LichSu");
            MonggoDB.InsertData();
        }
    }
}
