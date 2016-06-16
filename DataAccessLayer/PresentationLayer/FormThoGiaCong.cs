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
    public partial class FormThoGiaCong : Form
    {
        public FormThoGiaCong()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        ThoGiaCong_BUS ThoGiaCong_bus = new ThoGiaCong_BUS();
        private void FormThoGiaCong_Load(object sender, EventArgs e)
        {
            TextBox_readonly_false();
            dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
            dataGridView.Columns["MaTho"].HeaderText = "Mã thợ";
            dataGridView.Columns["TenTho"].HeaderText = "Tên thợ";
            dataGridView.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView.Columns["SDT"].HeaderText = "Số điện thoại";
            ControlBox = false;
        }
        public Form RefToMainForm { set; get; }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThoGiaCong_AddUpd form = new FormThoGiaCong_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
        }
        void reset_form()
        {
            txtMaTho.Text = "";
            txtTenTho.Text = "";
            txtDiaChi.Text = "";
            txtSodt.Text = "";
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            TextBox_readonly_true();
            try
            {
                txtMaTho.Text = dataGridView.CurrentRow.Cells["MaTho"].Value.ToString();
                txtTenTho.Text = dataGridView.CurrentRow.Cells["TenTho"].Value.ToString();
                txtDiaChi.Text = dataGridView.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtSodt.Text = dataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            } catch (NullReferenceException exc)
            {
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTho.Text.CompareTo("") == 0 || txtMaTho.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Thợ Gia Công " + txtMaTho.Text + "?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool kq = ThoGiaCong_bus.ThoGiaCong_Del(txtMaTho.Text);
                    if (!kq)
                    {
                        MessageBox.Show("Xóa không thành công. Vui lòng xóa các phiếu ct gia công có chứa Thợ bạn muốn xóa trước !");
                    }
                    dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTho.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
                tho.MaTho = Int16.Parse(txtMaTho.Text);
                tho.TenTho = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                tho.SDT = txtSodt.Text;

                FormThoGiaCong_AddUpd form = new FormThoGiaCong_AddUpd(tho);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
            }

        }

        private void TextBox_readonly_true()
        {
            txtMaTho.ReadOnly = true;
            txtTenTho.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSodt.ReadOnly = true;
        }
        private void TextBox_readonly_false()
        {
            txtMaTho.ReadOnly = false;
            txtTenTho.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtSodt.ReadOnly = false;
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
                ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
                if (txtMaTho.Text.CompareTo("") != 0)
                    tho.MaTho = Int16.Parse(txtMaTho.Text);
                else tho.MaTho = 0;
                tho.TenTho = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                tho.SDT = txtSodt.Text;
                dataGridView.DataSource = ThoGiaCong_bus.Search(tho);
            }
            catch (FormatException ex) { }
            catch (Exception ex2) { }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormThoGiaCong_AddUpd form = new FormThoGiaCong_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtMaTho.Text.CompareTo("") == 0 || txtMaTho.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Thợ Gia Công " + txtMaTho.Text + "?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ThoGiaCong_bus.ThoGiaCong_Del(txtMaTho.Text);
                    dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtMaTho.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
                tho.MaTho = Int16.Parse(txtMaTho.Text);
                tho.TenTho = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                tho.SDT = txtSodt.Text;

                FormThoGiaCong_AddUpd form = new FormThoGiaCong_AddUpd(tho);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
                if (txtMaTho.Text.CompareTo("") != 0)
                    tho.MaTho = Int16.Parse(txtMaTho.Text);
                else tho.MaTho = 0;
                tho.TenTho = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                tho.SDT = txtSodt.Text;
                dataGridView.DataSource = ThoGiaCong_bus.Search(tho);
            }
            catch (FormatException ex) { }
            catch (Exception ex2) { }
        }

        private void txtMaTho_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtSodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        
    }
}
