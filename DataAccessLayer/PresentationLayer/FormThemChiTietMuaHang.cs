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
    public partial class FormThemChiTietMuaHang : Form
    {
        PhieuMuaHangDLL pmh = new PhieuMuaHangDLL();
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        int Sopm;
        public FormThemChiTietMuaHang()
        {
            InitializeComponent();
        }
        public FormThemChiTietMuaHang(int sopm)
        {
            InitializeComponent();
            Sopm = sopm;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormThemChiTietMuaHang_Load(object sender, EventArgs e)
        {
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            cbbSoPhieuMua.DataSource = pmh.LayTatCa();
            cbbSoPhieuMua.DisplayMember = "SoPhieuMua";
            cbbSoPhieuMua.ValueMember = "SoPhieuMua";
            if(Sopm!=0)
            cbbSoPhieuMua.SelectedValue = Sopm;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            int loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            int sopm = Int16.Parse(cbbSoPhieuMua.Text);
            if(txtDonGiaMua.Text==""||txtSoLuong.Text=="")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            int masp=0;
            if (ct.KiemTraSP(kieusp, loaisp) == -1)
                MessageBox.Show("chua co sp");
            else masp = ct.KiemTraSP(kieusp, loaisp);
            CTPhieuMua_DTO ctpm = new CTPhieuMua_DTO();
            ctpm.SoPhieuMua = sopm;
            ctpm.MaSP = masp;
            ctpm.SoLuong = Int16.Parse(txtSoLuong.Text);
            ctpm.DonGia = Int16.Parse(txtDonGiaMua.Text);
            ctpm.ThanhTien = ctpm.DonGia*ctpm.SoLuong;
            ct.ThemChiTietMua(ctpm);

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemChiTietMuaHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
