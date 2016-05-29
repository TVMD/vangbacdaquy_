using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogiLayer;

namespace PresentationLayer
{
    public partial class FormCTPhieuDichVu_AddUpd : Form
    {
        CTPhieuDichVu_BUS ctphieudv_bus = new CTPhieuDichVu_BUS();
        public FormCTPhieuDichVu_AddUpd()
        {
            InitializeComponent();
        }
        public FormCTPhieuDichVu_AddUpd(CTPhieuDichVu_DTO phieudv)
        {
            InitializeComponent();
            txtSoPhieudv.Text = phieudv.SoPhieuDichVu.ToString();
            txtSTT.Text = phieudv.STT.ToString();
            txtMaLoaidv.Text =  phieudv.MaLoaiDV.ToString();
            txtDonGia.Text = phieudv.DonGia.ToString();
            txtSoLuong.Text = phieudv.SoLuong.ToString();
            txtThanhTien.Text = phieudv.ThanhTien.ToString();
            txtTinhTrang.Text = phieudv.TinhTrang.ToString();
            dtPicker_NgayGiao.Value = DateTime.Parse(phieudv.NgayGiao);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
            phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
            phieudv.STT = Int16.Parse(txtSTT.Text);
            phieudv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
            phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
            phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();


            ctphieudv_bus.CTPhieuDichVu_Add(phieudv);
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
            phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
            phieudv.STT = Int16.Parse(txtSTT.Text);
            phieudv.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
            phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
            phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();


            ctphieudv_bus.CTPhieuDichVu_Upd(phieudv);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
