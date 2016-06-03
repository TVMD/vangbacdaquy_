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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int sopn = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int masp = Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            ctpn.XoaCTNhap(sopn, masp);
            load();
        }
    }
}
