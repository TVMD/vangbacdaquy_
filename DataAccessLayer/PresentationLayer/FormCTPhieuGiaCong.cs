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
    public partial class FormCTPhieuGiaCong : Form
    {
        String sophieugc;
        CTPhieuGiaCong_BUS ctphieugc_bus = new CTPhieuGiaCong_BUS();
        public FormCTPhieuGiaCong()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public FormCTPhieuGiaCong(String sophieugc)
        {
            InitializeComponent();
            this.sophieugc = sophieugc;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void FormCTPhieuGiaCong_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
            dataGridView.Columns["SoPhieuDV"].HeaderText = "Số phiếu dv";
            dataGridView.Columns["STT"].HeaderText = "Stt";
            dataGridView.Columns["DonGia"].HeaderText = "Đơn giá";
            dataGridView.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dataGridView.Columns["MaTho"].HeaderText = "Mã thợ";

        }
        void reset_form()
        {
            txtSoPhieugc.Text = "";
            txtSoPhieudv.Text = "";
            txtSTT.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            txtMaTho.Text = "";
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            try
            {
                txtSoPhieugc.Text = sophieugc;
                txtSoPhieudv.Text = dataGridView.CurrentRow.Cells["SoPhieuDV"].Value.ToString();
                txtSTT.Text = dataGridView.CurrentRow.Cells["STT"].Value.ToString();
                txtDonGia.Text = dataGridView.CurrentRow.Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = dataGridView.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtThanhTien.Text = dataGridView.CurrentRow.Cells["ThanhTien"].Value.ToString();
                txtMaTho.Text = dataGridView.CurrentRow.Cells["MaTho"].Value.ToString();
            }
            catch (NullReferenceException exc) { }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormCTPhieuGiaCong_AddUpd form = new FormCTPhieuGiaCong_AddUpd(sophieugc);
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Chi Tiết Phiếu Gia Công " + txtSoPhieugc.Text + " ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ctphieugc_bus.CapNhatTongTien(Int16.Parse(txtSoPhieugc.Text), Int16.Parse(txtSoPhieudv.Text), Int16.Parse(txtSTT.Text), 0, 3);
                    ctphieugc_bus.CTPhieuGiaCong_Del(txtSoPhieugc.Text, txtSoPhieudv.Text, txtSTT.Text);

                    dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                CTGiaCong_DTO phieugc = new CTGiaCong_DTO();
                phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
                phieugc.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
                phieugc.STT = Int16.Parse(txtSTT.Text);
                phieugc.DonGia = Decimal.Parse(txtDonGia.Text);
                phieugc.SoLuong = Int16.Parse(txtSoLuong.Text);
                phieugc.ThanhTien = Decimal.Parse(txtThanhTien.Text);
                phieugc.MaTho = Int32.Parse(txtMaTho.Text);

                FormCTPhieuGiaCong_AddUpd form = new FormCTPhieuGiaCong_AddUpd(phieugc);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormCTPhieuGiaCong_AddUpd form = new FormCTPhieuGiaCong_AddUpd(sophieugc);
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Chi Tiết Phiếu Gia Công " + txtSoPhieugc.Text + " ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ctphieugc_bus.CapNhatTongTien(Int16.Parse(txtSoPhieugc.Text), Int16.Parse(txtSoPhieudv.Text), Int16.Parse(txtSTT.Text), 0, 3);
                    ctphieugc_bus.CTPhieuGiaCong_Del(txtSoPhieugc.Text, txtSoPhieudv.Text, txtSTT.Text);

                    dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                CTGiaCong_DTO phieugc = new CTGiaCong_DTO();
                phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
                phieugc.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
                phieugc.STT = Int16.Parse(txtSTT.Text);
                phieugc.DonGia = Decimal.Parse(txtDonGia.Text);
                phieugc.SoLuong = Int16.Parse(txtSoLuong.Text);
                phieugc.ThanhTien = Decimal.Parse(txtThanhTien.Text);
                phieugc.MaTho = Int32.Parse(txtMaTho.Text);

                FormCTPhieuGiaCong_AddUpd form = new FormCTPhieuGiaCong_AddUpd(phieugc);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ctphieugc_bus.LayTatCa(sophieugc);
            }
        }

    }
}
