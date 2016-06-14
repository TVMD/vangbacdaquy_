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
            ControlBox = false;
        }
        public Form RefToMainForm { set; get; }
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
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            try
            {
                PhieuChi_DTO phieuchi = new PhieuChi_DTO();
                if (txtSoPhieuChi.Text.CompareTo("") != 0)
                    phieuchi.SoPhieuChi = Int16.Parse(txtSoPhieuChi.Text);
                else phieuchi.SoPhieuChi = 0;
                if (txtNgayChi.Text.CompareTo("") != 0)
                    phieuchi.NgayChi = txtNgayChi.Text;
                else phieuchi.NgayChi = " ";

                if (txtSoTienChi.Text.CompareTo("") != 0)
                    phieuchi.SoTienChi = Decimal.Parse(txtSoTienChi.Text);
                else phieuchi.SoTienChi = 0;
                if (txtNoiDung.Text.CompareTo("") != 0)
                    phieuchi.NoiDung = txtNoiDung.Text;
                else phieuchi.NoiDung = " ";

                dataGridView1.DataSource = phieuchi_bus.Search(phieuchi);
            }
            catch (FormatException ex) { }
            //catch (Exception ex2) { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            
            
        }


        private void txtSoPhieuChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtSoTienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

    }
}
