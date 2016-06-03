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
        }

        private void FormLoaiDichVu_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = loaidichvu_bus.LayTatCa();

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
            try
            {

                txtMaLoaidv.Text = dataGridView.Rows[e.RowIndex].Cells["MaLoaiDV"].Value.ToString();
                txtTenLoaidv.Text = dataGridView.Rows[e.RowIndex].Cells["TenLoaiDV"].Value.ToString();
                txtDonGia.Text = dataGridView.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
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
            if (txtMaLoaidv.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                loaidichvu_bus.LoaiDichVu_Del(txtMaLoaidv.Text);
                dataGridView.DataSource = loaidichvu_bus.LayTatCa();
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

    }
}
