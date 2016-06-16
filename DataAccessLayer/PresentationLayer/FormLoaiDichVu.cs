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
    public partial class FormLoaiDichVu : Form
    {
        LoaiDichVu_BUS loaidichvu_bus = new LoaiDichVu_BUS();
        public FormLoaiDichVu()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void FormLoaiDichVu_Load(object sender, EventArgs e)
        {
            TextBox_readonly_false();
            dataGridView.DataSource = loaidichvu_bus.LayTatCa();
            dataGridView.Columns["MaLoaiDV"].HeaderText = "Mã loại DV";
            dataGridView.Columns["TenLoaiDV"].HeaderText = "Tên loại DV";
            dataGridView.Columns["DonGia"].HeaderText = "Đơn giá";

        }
        void reset_form()
        {
            txtMaLoaidv.Text = "";
            txtTenLoaidv.Text = "";
            txtDonGia.Text = "";
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            reset_form();
            TextBox_readonly_true();
            try
            {

                txtMaLoaidv.Text = dataGridView.CurrentRow.Cells["MaLoaiDV"].Value.ToString();
                txtTenLoaidv.Text = dataGridView.CurrentRow.Cells["TenLoaiDV"].Value.ToString();
                txtDonGia.Text = dataGridView.CurrentRow.Cells["DonGia"].Value.ToString();
            } catch (NullReferenceException exc)
            {

            }


        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormLoaiDichVu_AddUpd form = new FormLoaiDichVu_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = loaidichvu_bus.LayTatCa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoaidv.Text.CompareTo("") == 0 || txtMaLoaidv.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Loại Gia Công " + txtMaLoaidv.Text + "?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool kq = loaidichvu_bus.LoaiDichVu_Del(txtMaLoaidv.Text);
                    if (!kq)
                    {
                        MessageBox.Show("Xóa không thành công. Vui lòng xóa các phiếu ct dịch vụ có chứa Dịch vụ bạn muốn xóa trước !");
                    }
                    dataGridView.DataSource = loaidichvu_bus.LayTatCa();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLoaidv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                LoaiDichVu_DTO loaidv = new LoaiDichVu_DTO();
                loaidv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                loaidv.TenLoaiDV = txtTenLoaidv.Text;
                loaidv.DonGia = Decimal.Parse(txtDonGia.Text);


                FormLoaiDichVu_AddUpd form = new FormLoaiDichVu_AddUpd(loaidv);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = loaidichvu_bus.LayTatCa();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox_readonly_true()
        {
            txtMaLoaidv.ReadOnly = true;
            txtTenLoaidv.ReadOnly = true;
            txtDonGia.ReadOnly = true;

        }
        private void TextBox_readonly_false()
        {
            txtMaLoaidv.ReadOnly = false;
            txtTenLoaidv.ReadOnly= false;
            txtDonGia.ReadOnly = false;
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
                LoaiDichVu_DTO tho = new LoaiDichVu_DTO();
                if (txtMaLoaidv.Text.CompareTo("") != 0)
                    tho.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                else tho.MaLoaiDV = 0;
                tho.TenLoaiDV = txtTenLoaidv.Text;
                if (txtDonGia.Text.CompareTo("") != 0)
                    tho.DonGia = Decimal.Parse(txtDonGia.Text);
                else tho.DonGia = 0;
                
                dataGridView.DataSource = loaidichvu_bus.Search(tho);
            }
            catch (FormatException ex) { }
            catch (Exception ex2) { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormLoaiDichVu_AddUpd form = new FormLoaiDichVu_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = loaidichvu_bus.LayTatCa();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtMaLoaidv.Text.CompareTo("") == 0 || txtMaLoaidv.ReadOnly == false)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa mục Loại Gia Công " + txtMaLoaidv.Text + "?", "Bạn có chắc chắn xóa không ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    loaidichvu_bus.LoaiDichVu_Del(txtMaLoaidv.Text);
                    dataGridView.DataSource = loaidichvu_bus.LayTatCa();
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtMaLoaidv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                LoaiDichVu_DTO loaidv = new LoaiDichVu_DTO();
                loaidv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                loaidv.TenLoaiDV = txtTenLoaidv.Text;
                loaidv.DonGia = Decimal.Parse(txtDonGia.Text);


                FormLoaiDichVu_AddUpd form = new FormLoaiDichVu_AddUpd(loaidv);
                DialogResult dr = form.ShowDialog();
                dataGridView.DataSource = loaidichvu_bus.LayTatCa();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiDichVu_DTO tho = new LoaiDichVu_DTO();
                if (txtMaLoaidv.Text.CompareTo("") != 0)
                    tho.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
                else tho.MaLoaiDV = 0;
                tho.TenLoaiDV = txtTenLoaidv.Text;
                if (txtDonGia.Text.CompareTo("") != 0)
                    tho.DonGia = Decimal.Parse(txtDonGia.Text);
                else tho.DonGia = 0;

                dataGridView.DataSource = loaidichvu_bus.Search(tho);
            }
            catch (FormatException ex) { }
            catch (Exception ex2) { }
        }

        private void txtMaLoaidv_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMaLoaidv_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
