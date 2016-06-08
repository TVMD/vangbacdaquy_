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
    public partial class FormChiTietPhieuNhap : Form
    {
        int Sopn;
        ChiTietPhieuNhap_BUS ctpn = new ChiTietPhieuNhap_BUS();
        PhieuNhap_BUS pn = new PhieuNhap_BUS();
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        public FormChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public FormChiTietPhieuNhap(int sopn)
        {
            InitializeComponent();
            Sopn = sopn;
        }

        private void FormChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            cbbSoPhieuNhap.DataSource = pn.LayTatCa();
            cbbSoPhieuNhap.DisplayMember = "SoPhieuNhap";
            cbbSoPhieuNhap.ValueMember = "SoPhieuNhap";
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            if (Sopn != 0)
                cbbSoPhieuNhap.SelectedValue = Sopn;
            dataGridView1.DataSource = ctpn.LayChiTiet(Int16.Parse(cbbSoPhieuNhap.Text));
            dataGridView1.Columns["SoPhieuNhap"].HeaderText = "Số phiếu nhập";
            dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["SLNhap"].HeaderText = "Số lượng nhập";
            dataGridView1.Columns["DonGia"].HeaderText = "Đơn giả";
            dataGridView1.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dataGridView1.Columns["MaSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].DisplayIndex = 2;
            dataGridView1.Columns["TenLoaiSP"].DisplayIndex = 3;
            dtNgayLAp.Format = DateTimePickerFormat.Custom;
            dtNgayLAp.CustomFormat = "dd-MM-yyyy";
        }

        private void cbbSoPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoPhieuNhap.Text != "" && cbbSoPhieuNhap.SelectedIndex != -1 && cbbSoPhieuNhap.Text != "DTO.PhieuNhap_DTO" )
            {
                int sopn = Int16.Parse(cbbSoPhieuNhap.Text);
                PhieuNhap_DTO a = new PhieuNhap_DTO();
                a = pn.LayPhieuNhap(sopn);
                dtNgayLAp.Value = DateTime.Parse(a.NgayLap);
                txtTongTien.Text = a.TongTien.ToString();
                dataGridView1.DataSource = ctpn.LayChiTiet(Int16.Parse(cbbSoPhieuNhap.Text));
                dataGridView1.Columns["SoPhieuNhap"].HeaderText = "Số phiếu nhập";
                dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns["SLNhap"].HeaderText = "Số lượng nhập";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn giả";
                dataGridView1.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemCTNhap them = new FormThemCTNhap();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Bạn cần chọn một dòng để cập nhật");
                return;
            }
            int sopn = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int masp = Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            FormSuaCTNhap sua = new FormSuaCTNhap(sopn, masp);
            sua.ShowDialog();
            if (sua.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            CTPhieuNhap_DTO a = new CTPhieuNhap_DTO();
            //a.SoPhieuMua = Int16.Parse(cbbSoPhieuMua.SelectedValue.ToString());
            int kieusp = -1;
            int loaisp = -1;
            if (txtSoPhieuNhap.Text == "")
                a.SoPhieuNhap = -1;
            else a.SoPhieuNhap = Int16.Parse(txtSoPhieuNhap.Text);
            if (txtSoLuong.Text == "")
                a.SLNhap = -1;
            else a.SLNhap = Int16.Parse(txtSoLuong.Text);
            if (txtCTTongTien.Text == "")
                a.ThanhTien = -1;
            else a.ThanhTien = Int16.Parse(txtCTTongTien.Text);
            if (txtDonGia.Text == "")
                a.DonGia = -1;
            else a.DonGia = Int16.Parse(txtDonGia.Text);
            if (cbbKieuSP.Text != "")
                kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            if (cbbLoaiSP.Text != "")
                loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            dataGridView1.DataSource = ctpn.Search(a, kieusp, loaisp);
            dataGridView1.Columns["SoPhieuNhap"].HeaderText = "Số phiếu nhập";
            dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["SLNhap"].HeaderText = "Số lượng nhập";
            dataGridView1.Columns["DonGia"].HeaderText = "Đơn giả";
            dataGridView1.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dataGridView1.Columns["MaSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].DisplayIndex = 2;
            dataGridView1.Columns["TenLoaiSP"].DisplayIndex = 3;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int sopn = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int masp = Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            ctpn.XoaCTNhap(sopn, masp);
            load();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCTTongTien.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtSoPhieuNhap.Text = "";
            cbbKieuSP.SelectedValue = 0;
            cbbLoaiSP.SelectedValue = 0;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtCTTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a=Int16.Parse( dataGridView1.CurrentRow.Cells[7].Value.ToString());
            int b=Int16.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
            txtCTTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDonGia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSoPhieuNhap.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbbKieuSP.SelectedValue =a;
            cbbLoaiSP.SelectedValue = b;
        }
    }
}
