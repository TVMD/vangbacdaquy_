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
    public partial class FormCTPhieuDichVu : Form
    {
        CTPhieuDichVu_BUS ctphieudv_bus = new CTPhieuDichVu_BUS();
        PhieuDichVu_BUS phieudv_bus = new PhieuDichVu_BUS();
        String SoPhieu;
        public FormCTPhieuDichVu()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public FormCTPhieuDichVu(String sophieu)
        {
            InitializeComponent();
            SoPhieu = sophieu;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void FormCTPhieuDichVu_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd(SoPhieu);
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
                phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
                phieudv.STT = Int16.Parse(txtSTT.Text);
                phieudv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
                phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
                phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
                phieudv.TinhTrang = getIDTinhTrang(txtTinhTrang.Text);
                phieudv.NgayGiao = txtNgayGiao.Text;


                FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd(phieudv);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Chi Tiết Phiếu Gia Công " + txtSTT.Text + " ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    phieudv_bus.CapNhatTongTien(Int16.Parse(txtSoPhieudv.Text), Int16.Parse(txtSTT.Text), 0, 3);
                    ctphieudv_bus.CTPhieuDichVu_Del(txtSoPhieudv.Text, txtSTT.Text);

                    dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                
            }
        }
        void reset_form()
        {
            txtSoPhieudv.Text = "";
            txtSTT.Text = "";
            txtMaLoaidv.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            txtTinhTrang.Text = "";
            txtNgayGiao.Text = "";
        }
        String getTinhTrang(String vl)
        {
            if (vl.CompareTo("0")==0)
                return "Chưa gia công";
            else return "Đang gia công";
        }
        int getIDTinhTrang(String vl)
        {
            if (vl.CompareTo("Chưa gia công") == 0)
                return 0;
            else return 1;
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            try
            {
                txtSoPhieudv.Text = dataGridView.Rows[e.RowIndex].Cells["SoPhieuDichVu"].Value.ToString();
                txtSTT.Text = dataGridView.Rows[e.RowIndex].Cells["STT"].Value.ToString();
                txtMaLoaidv.Text = dataGridView.Rows[e.RowIndex].Cells["MaLoaiDV"].Value.ToString();
                txtTenLoaiDV.Text = dataGridView.Rows[e.RowIndex].Cells["TenLoaiDV"].Value.ToString();
                txtDonGia.Text = dataGridView.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = dataGridView.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                txtThanhTien.Text = dataGridView.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
                txtTinhTrang.Text = getTinhTrang(dataGridView.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString());
                txtNgayGiao.Text = dataGridView.Rows[e.RowIndex].Cells["NgayGiao"].Value.ToString();
            }
            catch (NullReferenceException exc) { }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd(SoPhieu);
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Chi Tiết Phiếu Gia Công " + txtSTT.Text + " ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    phieudv_bus.CapNhatTongTien(Int16.Parse(txtSoPhieudv.Text), Int16.Parse(txtSTT.Text), 0, 3);
                    ctphieudv_bus.CTPhieuDichVu_Del(txtSoPhieudv.Text, txtSTT.Text);

                    dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtSoPhieudv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
                phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
                phieudv.STT = Int16.Parse(txtSTT.Text);
                phieudv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
                phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
                phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
                phieudv.TinhTrang = getIDTinhTrang(txtTinhTrang.Text);
                phieudv.NgayGiao = txtNgayGiao.Text;


                FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd(phieudv);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
            }
        }

    }
}
