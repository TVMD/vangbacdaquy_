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
        }

        private void FormPhieuGiaCong_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = phieugc_bus.LayTatCa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormPhieuGiaCong_AddUpd form = new FormPhieuGiaCong_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = phieugc_bus.LayTatCa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieugc.Text.CompareTo("") == 0)
                MessageBox.Show("Vui lòng chọn dòng dữ liệu muốn Xóa !");
            else
            {
                phieugc_bus.PhieuGiaCong_Del(txtSoPhieugc.Text);
                dataGridView.DataSource = phieugc_bus.LayTatCa();
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
    }
}
