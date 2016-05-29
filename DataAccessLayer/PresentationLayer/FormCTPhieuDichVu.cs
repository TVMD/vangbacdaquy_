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
    public partial class FormCTPhieuDichVu : Form
    {
        CTPhieuDichVu_BUS ctphieudv_bus = new CTPhieuDichVu_BUS();
        String SoPhieu;
        public FormCTPhieuDichVu()
        {
            InitializeComponent();
        }
        public FormCTPhieuDichVu(String sophieu)
        {
            InitializeComponent();
            SoPhieu = sophieu;

        }

        private void FormCTPhieuDichVu_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd();
            DialogResult dr = form.ShowDialog();

            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
            phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
            phieudv.STT = Int16.Parse(txtSTT.Text);
            phieudv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
            phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
            phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);
            phieudv.NgayGiao = txtNgayGiao.Text;


            FormCTPhieuDichVu_AddUpd form = new FormCTPhieuDichVu_AddUpd(phieudv);
            DialogResult dr = form.ShowDialog();
            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ctphieudv_bus.CTPhieuDichVu_Del(txtSoPhieudv.Text, txtSTT.Text);
            dataGridView.DataSource = ctphieudv_bus.LayTatCa(SoPhieu);
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            txtSoPhieudv.Text = dataGridView.Rows[e.RowIndex].Cells["SoPhieuDichVu"].Value.ToString();
            txtSTT.Text = dataGridView.Rows[e.RowIndex].Cells["STT"].Value.ToString();
            txtMaLoaidv.Text = dataGridView.Rows[e.RowIndex].Cells["MaLoaiDV"].Value.ToString();
            txtDonGia.Text = dataGridView.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
            txtSoLuong.Text = dataGridView.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
            txtThanhTien.Text = dataGridView.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            txtTinhTrang.Text = dataGridView.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
            txtNgayGiao.Text = dataGridView.Rows[e.RowIndex].Cells["NgayGiao"].Value.ToString();


        }

    }
}
