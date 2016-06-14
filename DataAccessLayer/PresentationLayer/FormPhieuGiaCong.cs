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
        }

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
            txtNgayLap.Text = "2016/5/31...";
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
        Boolean KT_Ngay(String ng)
        {
            String[] ngay = ng.Split('/');
            switch (Int16.Parse(ngay[1]))
            {
                case 1 : case 3 : case 5 : case 7 : case 8 :case 10 : case 12 :
                    if (Int16.Parse(ngay[2]) <1 || Int16.Parse(ngay[2]) > 31)
                        return false;
                    break;
                case 4 : case 6 : case 9 : case 11 : 
                    if (Int16.Parse(ngay[2]) <1 || Int16.Parse(ngay[2]) > 30)
                        return false;
                    break;
                case 2 :
                    if ((Int16.Parse(ngay[0])%4 == 0 && Int16.Parse(ngay[0])% 100 != 0)|| (Int16.Parse(ngay[0])%400 == 0))
                    {
                        if (Int16.Parse(ngay[2]) <1 || Int16.Parse(ngay[2]) > 29)
                            return false;
                    } else if (Int16.Parse(ngay[2]) <1 || Int16.Parse(ngay[2]) > 28)
                            return false;
                    break;
            }
            return true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (KT_Ngay(txtNgayLap.Text))
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
            else MessageBox.Show("Nhập ngày sai. Vui lòng nhập theo dạng : 2016/5/31");
        }

        private void txtNgayLap_TextChanged(object sender, EventArgs e)
        {


            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormPhieuGiaCong_AddUpd form = new FormPhieuGiaCong_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = phieugc_bus.LayTatCa();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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

        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void toolStripButton4_Click(object sender, EventArgs e)
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

        private void btnXemChiTiet_Click(object sender, EventArgs e)
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
    }
}
