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
    public partial class FormSuaCTNhap : Form
    {
        int Sopn;
        int Masp;
        ChiTietPhieuNhap_BUS ct = new ChiTietPhieuNhap_BUS();
        public FormSuaCTNhap()
        {
            InitializeComponent();
        }
        public FormSuaCTNhap(int sopn,int masp)
        {
            InitializeComponent();
            Sopn = sopn;
            Masp = masp;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormSuaCTNhap_Load(object sender, EventArgs e)
        {

        }
        public FormChiTietPhieuNhap RefToMom { get; set; }
        private void Sửa_Click(object sender, EventArgs e)
        {
            CTPhieuNhap_DTO a = new CTPhieuNhap_DTO();
            a.MaSP = Masp;
            a.SoPhieuNhap = Sopn;
            if(txtDonGiaMua.Text==""||txtSoLuong.Text=="")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            a.DonGia = Int16.Parse(txtDonGiaMua.Text);
            a.SLNhap = Int16.Parse(txtSoLuong.Text);
            a.ThanhTien = a.DonGia * a.SLNhap;
            if (a.SLNhap == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }
            if (a.DonGia == 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0");
                return;
            }
            ct.CapNhapCTPhieuNhap(a);
            MessageBox.Show("Cập nhật thành công");
            RefToMom.load();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaCTNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtDonGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
