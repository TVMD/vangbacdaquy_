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
    public partial class FormChiTietMuaHang : Form
    {
        PhieuMuaHangDLL pmh = new PhieuMuaHangDLL();
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        int Sopm;
        public FormChiTietMuaHang()
        {
            InitializeComponent();
        }
        public FormChiTietMuaHang(int sopm)
        {
            InitializeComponent();
            Sopm = sopm;
        }

        private void FormChiTietMuaHang_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            cbbSoPhieuMua.DataSource = pmh.LayTatCa();
            cbbSoPhieuMua.DisplayMember = "SoPhieuMua";
            cbbSoPhieuMua.ValueMember = "SoPhieuMua";
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            if(Sopm!=0)
            cbbSoPhieuMua.SelectedValue = Sopm;
            int sopm = Int16.Parse(cbbSoPhieuMua.Text);
            dataGridView1.DataSource = ct.LayChiTiet(sopm);
            dataGridView1.Columns["MaSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["DonGia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].DisplayIndex = 2;
            dataGridView1.Columns["TenLoaiSP"].DisplayIndex = 3;
            dataGridView1.Columns["SoPhieuMua"].Visible = false;
            dtNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtNgayThanhToan.CustomFormat = "dd-MM-yyyy";
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd-MM-yyyy";
        }

        private void cbbSoPhieuMua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoPhieuMua.Text != "" && cbbSoPhieuMua.SelectedIndex != -1 && cbbSoPhieuMua.SelectedIndex != 0 || cbbSoPhieuMua.Text == "1")
            {
                int sopt = Int16.Parse(cbbSoPhieuMua.Text);
                PhieuMuaHang_DTO mh = pmh.LayPhieuThu(sopt);
                txtTongTien.Text = mh.TongTien.ToString();
                DateTime ngaymua = DateTime.Parse(mh.NgayMua);
                DateTime ngaytt = DateTime.Parse(mh.NgayThanhToan);
                dtNgayMua.Value = ngaymua;
                dtNgayThanhToan.Value = ngaytt;
                txtKhachHang.Text = pmh.Lay1KH(mh.MaKH).TenKh;
                dataGridView1.DataSource = ct.LayChiTiet(sopt);
                dataGridView1.Columns["MaSP"].Visible = false;
                dataGridView1.Columns["MaKieuSP"].Visible = false;
                dataGridView1.Columns["MaLoaiSP"].Visible = false;
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn giá";
                dataGridView1.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
                dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
                dataGridView1.Columns["TenKieuSP"].DisplayIndex = 2;
                dataGridView1.Columns["TenLoaiSP"].DisplayIndex = 3;
                dataGridView1.Columns["SoPhieuMua"].Visible = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemChiTietMuaHang them = new FormThemChiTietMuaHang(Int16.Parse(cbbSoPhieuMua.Text));
            them.RefToMom=this;
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("Bạn cần chọn một dòng để sửa");
                return;
            }
            int stt=Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())  ;
            int sopm=Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())  ;
            FormSuaChiTietMua sua = new FormSuaChiTietMua(sopm, stt);
            sua.RefToMom = this;
            sua.ShowDialog();
            if (sua.DialogResult == DialogResult.Cancel)
                load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = Int16.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
            int b = Int16.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());
            txtSoPhieuMua.Text =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbbKieuSP.SelectedValue = a; //
            cbbLoaiSP.SelectedValue = b; //
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaMua.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCtTongTien.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Bạn cần chọn 1 dòng để xóa");
                return;
            }
            int stt = Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            int sopm = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            ct.XoaCTMuaHang(sopm, stt);
            load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CTPhieuMua_DTO a = new CTPhieuMua_DTO();
            //a.SoPhieuMua = Int16.Parse(cbbSoPhieuMua.SelectedValue.ToString());
            int kieusp=-1;
            int loaisp=-1;
            a.STT = -1;
            if (txtSoPhieuMua.Text == "")
                a.SoPhieuMua = -1;
            else a.SoPhieuMua = Int16.Parse(txtSoPhieuMua.Text);
            if (txtSoLuong.Text == "")
                a.SoLuong = -1;
            else a.SoLuong = Int16.Parse(txtSoLuong.Text);
            if (txtCtTongTien.Text == "")
                a.ThanhTien = -1;
            else a.ThanhTien = Int16.Parse(txtCtTongTien.Text);
            if (txtDonGiaMua.Text == "")
                a.DonGia = -1;
            else a.DonGia = Int16.Parse(txtDonGiaMua.Text);
            if (cbbKieuSP.Text != "")
                kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            if(cbbLoaiSP.Text!="")
                loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            dataGridView1.DataSource = ct.Search(a,kieusp,loaisp);
            dataGridView1.Columns["MaSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["DonGia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].DisplayIndex = 2;
            dataGridView1.Columns["TenLoaiSP"].DisplayIndex = 3;
            dataGridView1.Columns["SoPhieuMua"].Visible = false;
                
        }

        private void FormChiTietMuaHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtDonGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = "";
            txtSoPhieuMua.Text = "";
            txtCtTongTien.Text = "";
            txtDonGiaMua.Text = "";
            cbbKieuSP.SelectedValue = 0;
            cbbLoaiSP.SelectedValue = 0;
        }

        private void txtSoPhieuMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
