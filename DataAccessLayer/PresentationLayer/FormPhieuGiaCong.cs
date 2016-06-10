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
    public partial class FormPhieuGiaCong : Form
    {
        PhieuGiaCong_BUS phieugc_bus = new PhieuGiaCong_BUS();
        public FormPhieuGiaCong()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void FormPhieuGiaCong_Load(object sender, EventArgs e)
        {
            TextBox_readonly_false();
            dataGridView.DataSource = phieugc_bus.LayTatCa();
            txtNgayLap.Text = "2016/5/31...";
            ControlBox = false;
        }
        public Form RefToMainForm { set; get; }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormPhieuGiaCong_AddUpd form = new FormPhieuGiaCong_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = phieugc_bus.LayTatCa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0 || txtSoPhieugc.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Phiếu Gia Công " + txtSoPhieugc.Text + " và bao gồm cả các Chi Tiết Phiếu Gia Công ?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    phieugc_bus.PhieuGiaCong_Del(txtSoPhieugc.Text);
                    dataGridView.DataSource = phieugc_bus.LayTatCa();
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
                PhieuGiaCong_DTO phieugc = new PhieuGiaCong_DTO();
                phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
                phieugc.NgayLap = txtNgayLap.Text;
                phieugc.TongTien = Decimal.Parse(txtTongTien.Text);

                FormPhieuGiaCong_AddUpd form = new FormPhieuGiaCong_AddUpd(phieugc);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = phieugc_bus.LayTatCa();
            }
        }
        void reset_form()
        {
            txtSoPhieugc.Text = "";
            txtNgayLap.Text = "";
            txtTongTien.Text = "";
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            TextBox_readonly_true();
            try
            {
                txtSoPhieugc.Text = dataGridView.Rows[e.RowIndex].Cells["SoPhieuGiaCong"].Value.ToString();
                txtNgayLap.Text = dataGridView.Rows[e.RowIndex].Cells["NgayLap"].Value.ToString();
                txtTongTien.Text = dataGridView.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();
            }
            catch (NullReferenceException exc) { }

        }

        private void btnChiTietPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xem chi tiết !");
            else
            {
                String sophieu = txtSoPhieugc.Text;
                FormCTPhieuGiaCong form = new FormCTPhieuGiaCong(sophieu);
                DialogResult dr = form.ShowDialog();
            }
        }
        private void TextBox_readonly_true()
        {
            txtSoPhieugc.ReadOnly = true;
            txtNgayLap.ReadOnly = true;
            
            txtTongTien.ReadOnly = true;
        }
        private void TextBox_readonly_false()
        {
            
            txtSoPhieugc.ReadOnly = false;            
            txtNgayLap.ReadOnly = false;

            
            //txtNgayLap.ForeColor = Color.Gray;

            txtTongTien.ReadOnly = false;
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset_form();
            TextBox_readonly_false();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TextBox_readonly_false();
            try
            {
                PhieuGiaCong_DTO phieudv = new PhieuGiaCong_DTO();
                if (txtSoPhieugc.Text.CompareTo("") != 0)
                    phieudv.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
                else phieudv.SoPhieuGiaCong = 0;
                if (txtNgayLap.Text.CompareTo("") != 0)
                    phieudv.NgayLap = txtNgayLap.Text;
                else phieudv.NgayLap = " ";

                if (txtTongTien.Text.CompareTo("") != 0)
                    phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
                else phieudv.TongTien = 0;

                dataGridView.DataSource = phieugc_bus.Search(phieudv);
            }
            catch (FormatException ex) { }
            //catch (Exception ex2) { }
        }

        private void txtNgayLap_TextChanged(object sender, EventArgs e)
        {


            

        }
    }
}
