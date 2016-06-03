using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogiLayer;

namespace PresentationLayer
{
    public partial class FormThemDVTinh : Form
    {
        DonViTinh_BUS dv = new DonViTinh_BUS();
        int MaDV;
        public FormThemDVTinh()
        {
            InitializeComponent();
        }
        public FormThemDVTinh(int madv)
        {
            InitializeComponent();
            MaDV = madv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDV.Text == "")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            DonViTinh_DTO a = new DonViTinh_DTO();
            a.TenDonViTinh = txtTenDV.Text;
            dv.ThemDVTinh(a);            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemDVTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(txtMaDV.Text!="")
            {
                DonViTinh_DTO a = new DonViTinh_DTO();
                a.MaDonViTinh = MaDV;
                a.TenDonViTinh = txtTenDV.Text;
                dv.CapNhapDVTinh(a);     
            }
        }

        private void FormThemDVTinh_Load(object sender, EventArgs e)
        {
            if (MaDV != 0)
            {
                txtMaDV.Text = MaDV.ToString();
                txtTenDV.Text = dv.Lay1DV(MaDV).TenDonViTinh;
            }
        }
    }
}
