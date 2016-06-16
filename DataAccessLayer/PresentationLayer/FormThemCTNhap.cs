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
    public partial class FormThemCTNhap : Form
    {
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        PhieuNhap_BUS pn = new PhieuNhap_BUS();
        ChiTietPhieuNhap_BUS ctp = new ChiTietPhieuNhap_BUS();
        KieuSP_BUS k = new KieuSP_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        int Sopn;
        public FormThemCTNhap()
        {
            InitializeComponent();
        }
        public FormThemCTNhap(int sopn)
        {
            InitializeComponent();
            Sopn=sopn;
        }
        public FormChiTietPhieuNhap RefToMom { get; set; }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            int loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            int sopn = Int16.Parse(cbbSoPhieuNhap.Text);
            if (txtDonGia.Text == "" || txtSoLuong.Text == "" )
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            int masp = 0;
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
            CTPhieuNhap_DTO a = new CTPhieuNhap_DTO();
            a.SoPhieuNhap = sopn;
            a.SLNhap = Int16.Parse(txtSoLuong.Text);
            a.DonGia = Decimal.Parse(txtDonGia.Text);
            a.ThanhTien = a.DonGia * a.SLNhap;
            a.MaSP = masp;
            if(ctp.Check(sopn,masp))
            {
                ctp.ThemChiTietNhap(a);
                MessageBox.Show("Thêm thành công");
                RefToMom.load();
            }
            else
            {
                MessageBox.Show("Sản phẩm này đã được nhập trong phiếu này");
            }
            
        }

        private void FormThemCTNhap_Load(object sender, EventArgs e)
        {
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            cbbSoPhieuNhap.DataSource = pn.LayTatCa();
            cbbSoPhieuNhap.DisplayMember = "SoPhieuNhap";
            cbbSoPhieuNhap.ValueMember = "SoPhieuNhap";
            cbbSoPhieuNhap.SelectedValue=Sopn;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemCTNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
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

        private void cbbSoPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
