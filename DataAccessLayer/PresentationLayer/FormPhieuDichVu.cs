using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogiLayer;
using DTO;


namespace PresentationLayer
{
    public partial class FormPhieuDichVu : Form
    {
        PhieuDichVu_BUS phieudichvu_bus = new PhieuDichVu_BUS();
        public FormPhieuDichVu()
        {
            InitializeComponent();
        }

        private void FormPhieuDichVu_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = phieudichvu_bus.LayTatCa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormPhieuDichVu_AddUpd form = new FormPhieuDichVu_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = phieudichvu_bus.LayTatCa();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
                phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
                phieudv.MaKH = Int16.Parse(txtMaKhachHang.Text);
                phieudv.NgayDangKy = txtNgayDangKy.Text;
                phieudv.NgayGiao = txtNgayGiao.Text;
                phieudv.DiaChi = txtDiaChi.Text;
                phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
                phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);


                FormPhieuDichVu_AddUpd form = new FormPhieuDichVu_AddUpd(phieudv);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = phieudichvu_bus.LayTatCa();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                phieudichvu_bus.PhieuDichVu_Del(txtSoPhieudv.Text);
                dataGridView.DataSource = phieudichvu_bus.LayTatCa();
            }
        }
        void reset_form()
        {
            txtSoPhieudv.Text = "";
            txtMaKhachHang.Text = "";
            txtNgayDangKy.Text ="";
            txtNgayGiao.Text = "";
            txtDiaChi.Text = "";
            txtTongTien.Text = "";
            txtTinhTrang.Text = "";
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            try
            {
                txtSoPhieudv.Text = dataGridView.Rows[e.RowIndex].Cells["SoPhieuDV"].Value.ToString();
                txtMaKhachHang.Text = dataGridView.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                txtNgayDangKy.Text = dataGridView.Rows[e.RowIndex].Cells["NgayDangKy"].Value.ToString();
                txtNgayGiao.Text = dataGridView.Rows[e.RowIndex].Cells["NgayGiao"].Value.ToString();
                txtDiaChi.Text = dataGridView.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtTongTien.Text = dataGridView.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();
                txtTinhTrang.Text = dataGridView.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
            } catch(NullReferenceException exc)
            {

            }


        }

        private void btnChiTietPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xem chi tiết !");
            else
            {
                String sophieu = txtSoPhieudv.Text;
                FormCTPhieuDichVu form = new FormCTPhieuDichVu(sophieu);
                DialogResult dr = form.ShowDialog();
            }
        }
    }
}
