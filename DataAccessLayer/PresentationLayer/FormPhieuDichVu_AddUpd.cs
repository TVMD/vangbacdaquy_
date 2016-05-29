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
    public partial class FormPhieuDichVu_AddUpd : Form
    {
        PhieuDichVu_BUS phiedichvu_bus = new PhieuDichVu_BUS();
        public FormPhieuDichVu_AddUpd()
        {
            InitializeComponent();
        }
        public FormPhieuDichVu_AddUpd(PhieuDichVu_DTO phieudv)
        {
            InitializeComponent();
            txtSoPhieudv.Text = phieudv.SoPhieuDV.ToString();
            txtMaKhachHang.Text = phieudv.MaKH.ToString();
            dtPicker_NgayDangKy.Value = DateTime.Parse(phieudv.NgayDangKy);
            dtPicker_NgayGiao.Value = DateTime.Parse(phieudv.NgayGiao);
            txtDiaChi.Text = phieudv.DiaChi;
            txtTongTien.Text = phieudv.TongTien.ToString();
            txtTinhTrang.Text = phieudv.TinhTrang.ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
            phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
            phieudv.MaKH = Int16.Parse(txtMaKhachHang.Text);
            phieudv.NgayDangKy = dtPicker_NgayDangKy.Value.ToShortDateString();
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();
            phieudv.DiaChi = txtDiaChi.Text;
            phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
            phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);


            phiedichvu_bus.PhieuDichVu_Add(phieudv);
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
            phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
            phieudv.MaKH = Int16.Parse(txtMaKhachHang.Text);
            phieudv.NgayDangKy = dtPicker_NgayDangKy.Value.ToShortDateString();
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();
            phieudv.DiaChi = txtDiaChi.Text;
            phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
            phieudv.TinhTrang = Int32.Parse(txtTinhTrang.Text);

            phiedichvu_bus.PhieuDichVu_Upd(phieudv);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
