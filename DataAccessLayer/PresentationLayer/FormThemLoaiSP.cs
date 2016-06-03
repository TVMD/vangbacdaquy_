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
    public partial class FormThemLoaiSP : Form
    {
        DonViTinh_BUS dv = new DonViTinh_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        int MaLoaiSP;
        public FormThemLoaiSP()
        {
            InitializeComponent();
        }
        public FormThemLoaiSP(int maloaisp)
        {
            InitializeComponent();
            MaLoaiSP = maloaisp;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSP.Text == ""||txtPhantramloinhuan.Text=="")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            LoaiSP_DTO a = new LoaiSP_DTO();
            a.TenLoaiSP = txtTenLoaiSP.Text;
            a.MaDonViTinh=Int16.Parse(cbbDV.SelectedValue.ToString());
            a.PhanTramLoiNhuan = float.Parse(txtPhantramloinhuan.Text);
            lo.ThemLoaiSP(a);
        }

        private void FormThemLoaiSP_Load(object sender, EventArgs e)
        {
            cbbDV.DataSource = dv.LayDVTinh();
            cbbDV.DisplayMember = "TenDonViTinh";
            cbbDV.ValueMember = "MaDonViTinh";
            if(MaLoaiSP!=0)
            {
                txtMaLoaiSP.Text = MaLoaiSP.ToString();
                txtTenLoaiSP.Text = lo.Lay1LSP(MaLoaiSP).TenLoaiSP;
                cbbDV.SelectedValue = lo.Lay1LSP(MaLoaiSP).MaDonViTinh;
                txtPhantramloinhuan.Text = lo.Lay1LSP(MaLoaiSP).PhanTramLoiNhuan.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSP.Text != "")
            {
                LoaiSP_DTO a = new LoaiSP_DTO();
                a.TenLoaiSP = txtTenLoaiSP.Text;
                a.MaDonViTinh = Int16.Parse(cbbDV.SelectedValue.ToString());
                a.PhanTramLoiNhuan = float.Parse(txtPhantramloinhuan.Text);
                a.MaLoaiSP = MaLoaiSP;
                lo.CapNhapLoaiSP(a);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemLoaiSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
