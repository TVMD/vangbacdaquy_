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
        LoaiSP_BUS lo = new LoaiSP_BUS();
        KieuSP_BUS k = new KieuSP_BUS();
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
        public FormChiTietMuaHang RefToMom { get; set; }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //public FormChiTietMuaHang RefToMom { get; set; }
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
            {
                DialogResult dr = MessageBox.Show("Sản phẩm này chưa được lưu trong cơ sở dữ liệu, bạn có muốn thêm sản phẩm mới không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    FormThemSP them = new FormThemSP();
                    them.ShowDialog();
                    if (them.DialogResult == DialogResult.Cancel)
                    {
                        cbbKieuSP.DataSource = ct.LayKieuSP();
                        cbbKieuSP.DisplayMember = "TenKieuSP";
                        cbbKieuSP.ValueMember = "MaKieuSP";
                        cbbLoaiSP.DataSource = ct.LayLoaiSP();
                        cbbLoaiSP.DisplayMember = "TenLoaiSP";
                        cbbLoaiSP.ValueMember = "MaLoaiSP";
                    }
                    if (ct.KiemTraSP(kieusp, loaisp) == -1) return;
                    masp = ct.KiemTraSP(kieusp, loaisp);
                }
                else return;
            }
            else masp = ct.KiemTraSP(kieusp, loaisp);
            CTPhieuMua_DTO ctpm = new CTPhieuMua_DTO();
            ctpm.SoPhieuMua = sopm;
            ctpm.MaSP = masp;
            ctpm.SoLuong = Int16.Parse(txtSoLuong.Text);
            ctpm.DonGia = Int16.Parse(txtDonGiaMua.Text);
            ctpm.ThanhTien = ctpm.DonGia*ctpm.SoLuong;
            if (ctpm.SoLuong == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }
            if (ctpm.DonGia == 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0");
                return;
            }
            ct.ThemChiTietMua(ctpm);
            MessageBox.Show("Thêm thành công");
            RefToMom.load();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemChiTietMuaHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDonGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ;
        }

        private void btnAddLoaiSP_Click(object sender, EventArgs e)
        {
            FormThemLoaiSP them = new FormThemLoaiSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
            {
                cbbLoaiSP.DataSource = lo.LayLoaiSP();
                cbbLoaiSP.DisplayMember = "TenLoaiSP";
                cbbLoaiSP.ValueMember = "MaLoaiSP";
            }
        }

        private void btnAddKieuSP_Click(object sender, EventArgs e)
        {
            FormThemKieuSP them = new FormThemKieuSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
            {
                cbbKieuSP.DataSource = k.LayKieuSP();
                cbbKieuSP.DisplayMember = "TenKieuSP";
                cbbKieuSP.ValueMember = "MaKieuSP";
            }
        }

        private void cbbSoPhieuMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
