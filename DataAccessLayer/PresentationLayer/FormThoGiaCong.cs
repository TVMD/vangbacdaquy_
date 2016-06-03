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
        }
        ThoGiaCong_BUS ThoGiaCong_bus = new ThoGiaCong_BUS();
        private void FormThoGiaCong_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
        }

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
            try
            {
                txtMaTho.Text = dataGridView.Rows[e.RowIndex].Cells["MaTho"].Value.ToString();
                txtTenTho.Text = dataGridView.Rows[e.RowIndex].Cells["TenTho"].Value.ToString();
                txtDiaChi.Text = dataGridView.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtSodt.Text = dataGridView.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            } catch (NullReferenceException exc)
            {
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTho.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                ThoGiaCong_bus.ThoGiaCong_Del(txtMaTho.Text);
                dataGridView.DataSource = ThoGiaCong_bus.LayTatCa();
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

        
    }
}
