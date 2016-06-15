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
    
    public partial class FormSuaChiTietMua : Form
    {
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        int Sopm;
        int STT;
        public FormSuaChiTietMua()
        {
            InitializeComponent();
        }
        public FormSuaChiTietMua(int sopm, int stt)
        {
            InitializeComponent();
            Sopm = sopm;
            STT = stt;
        }
        private void FormSuaChiTietMua_Load(object sender, EventArgs e)
        {
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            CTPhieuMua_DTO a = new CTPhieuMua_DTO();
            a = ct.Lay1ChiTiet(Sopm, STT);
            txtDonGiaMua.Text = a.DonGia.ToString();
            txtSoLuong.Text = a.SoLuong.ToString();
            //txtTongTien.Text = a.ThanhTien.ToString();
            SanPham_DTO b = ct.Lay1SP(a.MaSP);
            cbbKieuSP.SelectedValue = b.MaKieuSP;
            cbbLoaiSP.SelectedValue = b.MaLoaiSP;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CTPhieuMua_DTO a = new CTPhieuMua_DTO();
            if (txtDonGiaMua.Text == "" || txtSoLuong.Text == "" )
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            int masp = 0;
            int kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            int loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
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
                    masp = ct.KiemTraSP(kieusp, loaisp);
                }
                else return;
            }
            else masp = ct.KiemTraSP(kieusp, loaisp);
            CTPhieuMua_DTO ctpm = new CTPhieuMua_DTO();
            ctpm.STT = STT;
            ctpm.SoPhieuMua = Sopm;
            ctpm.MaSP = masp;
            ctpm.SoLuong = Int16.Parse(txtSoLuong.Text);
            ctpm.DonGia = Decimal.Parse(txtDonGiaMua.Text);
            ctpm.ThanhTien = ctpm.SoLuong*ctpm.DonGia;
            ct.CapNhapCTPhieuMH(ctpm);
            MessageBox.Show("Sửa thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
