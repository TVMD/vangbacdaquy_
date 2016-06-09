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
    public partial class FormPhieuChi : Form
    {
        public FormPhieuChi()
        {
            InitializeComponent();
        }
        PhieuChi_bus phieuchi_bus = new PhieuChi_bus();
        private void FormPhieuChi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = phieuchi_bus.LayTatCa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormPhieuChi_Them form = new FormPhieuChi_Them();
            
            DialogResult dr = form.ShowDialog();
           // txtNgayChi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = phieuchi_bus.LayTatCa();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoPhieuChi.Text = dataGridView1.Rows[e.RowIndex].Cells["SoPhieuChi"].Value.ToString();
            txtNoiDung.Text = dataGridView1.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
            txtNgayChi.Text = dataGridView1.Rows[e.RowIndex].Cells["NgayChi"].Value.ToString();
            txtSoTienChi.Text = dataGridView1.Rows[e.RowIndex].Cells["SoTienChi"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieuChi.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Sửa !");
            else
            {
                phieuchi_bus.PhieuChi_del(txtSoPhieuChi.Text);
                dataGridView1.DataSource = phieuchi_bus.LayTatCa();
            }
            txtNgayChi.Text = "";
            txtNoiDung.Text = "";
            txtSoPhieuChi.Text = "";
            txtSoTienChi.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoPhieuChi.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                PhieuChi_DTO phieuchi = new PhieuChi_DTO();
                phieuchi.SoPhieuChi = Int16.Parse(txtSoPhieuChi.Text);
                phieuchi.NoiDung = txtNoiDung.Text;
                phieuchi.NgayChi = txtNgayChi.Text;
                phieuchi.SoTienChi = Decimal.Parse(txtSoTienChi.Text);

                FormPhieuChi_Them form = new FormPhieuChi_Them(phieuchi);
                DialogResult dr = form.ShowDialog();
                dataGridView1.DataSource = phieuchi_bus.LayTatCa();
                txtNgayChi.Text = "";
                txtNoiDung.Text = "";
                txtSoPhieuChi.Text = "";
                txtSoTienChi.Text = "";
            }
        }

    }
}
