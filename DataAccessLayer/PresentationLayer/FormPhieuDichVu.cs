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
            TextBox_readonly_false();
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
            if (txtSoPhieudv.Text.CompareTo("") == 0 || txtSoPhieudv.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Phiếu Dịch Vụ " + txtSoPhieudv.Text + " và bao gồm cả các Chi Tiết Phiếu Dịch Vụ ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    phieudichvu_bus.PhieuDichVu_Del(txtSoPhieudv.Text);
                    dataGridView.DataSource = phieudichvu_bus.LayTatCa();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                
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
            TextBox_readonly_true();
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

        private void TextBox_readonly_true()
        {
            txtSoPhieudv.ReadOnly = true;
            txtMaKhachHang.ReadOnly = true;
            //txtNgayDangKy.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            //txtNgayGiao.ReadOnly = true;
            txtTongTien.ReadOnly = true;
        }
        private void TextBox_readonly_false()
        {
            txtSoPhieudv.ReadOnly = false;
            txtMaKhachHang.ReadOnly = false;
            //txtNgayDangKy.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            //txtNgayGiao.ReadOnly = false;
            txtTongTien.ReadOnly = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset_form();
            TextBox_readonly_false();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
                if (txtSoPhieudv.Text.CompareTo("") != 0)
                    phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
                else phieudv.SoPhieuDV = 0;
                if (txtMaKhachHang.Text.CompareTo("") != 0)
                    phieudv.MaKH = Int16.Parse(txtMaKhachHang.Text);
                else phieudv.MaKH = 0;
                //phieudv.MaKH = txtTenTho.Text; //ngay dk
                                                //ngay giao
                phieudv.DiaChi = txtDiaChi.Text;
                if (txtTongTien.Text.CompareTo("") != 0)
                    phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
                else phieudv.TongTien = 0;
                //tinh trang 

                dataGridView.DataSource = phieudichvu_bus.Search(phieudv);
            }
            catch (FormatException ex) { }
            catch (Exception ex2) { }
        }
    }
}
