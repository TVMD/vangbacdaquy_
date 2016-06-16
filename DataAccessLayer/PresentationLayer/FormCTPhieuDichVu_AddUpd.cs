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
        PhieuDichVu_BUS phieudv_bus = new PhieuDichVu_BUS();
        String sophieu;
        public FormCTPhieuDichVu_AddUpd(String sophieu)
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            comboBox_MaLoaiDichVu.DataSource = ctphieudv_bus.LayDSMaLoaiDV();
            comboBox_MaLoaiDichVu.ValueMember = "MaLoaiDV";
            comboBox_MaLoaiDichVu.DisplayMember = "TenLoaiDV";
            //
            comboBox_TinhTrang.DisplayMember = "Text";
            comboBox_TinhTrang.ValueMember = "Value";

            var items = new[] { 
                                new { Text = "Chưa gia công", Value = 0 }, 
                                new { Text = "Đang gia công", Value = 1 }
                            };
            comboBox_TinhTrang.DataSource = items;
            //
            //
            //
            this.sophieu = sophieu;
            txtSoPhieudv.Text = this.sophieu;
            int khoamoi = Int16.Parse(ctphieudv_bus.LayKhoaMoi()) + 1;
            txtSTT.Text = khoamoi.ToString();
            //
            //lay don gia ban dau
            //
            //txtDonGia.Text = ctphieudv_bus.LayDonGiaLoaiDV(comboBox_MaLoaiDichVu.SelectedValue.ToString());

            btnCapNhat.Enabled = false;
        }
        public FormCTPhieuDichVu_AddUpd(CTPhieuDichVu_DTO phieudv)
        {
            InitializeComponent();
            comboBox_MaLoaiDichVu.DataSource = ctphieudv_bus.LayDSMaLoaiDV();
            comboBox_MaLoaiDichVu.ValueMember = "MaLoaiDV";
            comboBox_MaLoaiDichVu.DisplayMember = "TenLoaiDV";
            //
            comboBox_TinhTrang.DisplayMember = "Text";
            comboBox_TinhTrang.ValueMember = "Value";
            var items = new[] { 
                                new { Text = "Chưa gia công", Value = 0 }, 
                                new { Text = "Đang gia công", Value = 1 }
                                };
            comboBox_TinhTrang.DataSource = items;
            //
            //
            //
            txtSoPhieudv.Text = phieudv.SoPhieuDichVu.ToString();
            txtSTT.Text = phieudv.STT.ToString();
            comboBox_MaLoaiDichVu.SelectedValue =  phieudv.MaLoaiDV;
            txtDonGia.Text = phieudv.DonGia.ToString();
            txtSoLuong.Text = phieudv.SoLuong.ToString();
            txtThanhTien.Text = phieudv.ThanhTien.ToString();
            comboBox_TinhTrang.SelectedValue = phieudv.TinhTrang;
            dtPicker_NgayGiao.Value = DateTime.Parse(phieudv.NgayGiao);

            btnThem.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
            phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
            phieudv.STT = Int16.Parse(txtSTT.Text);
            phieudv.MaLoaiDV = Int16.Parse(comboBox_MaLoaiDichVu.SelectedValue.ToString());
            phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
            phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);

            phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieudv.TinhTrang = Int32.Parse(comboBox_TinhTrang.SelectedValue.ToString());
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();

            ctphieudv_bus.CTPhieuDichVu_Add(phieudv);
            phieudv_bus.CapNhatTongTien(phieudv.SoPhieuDichVu, phieudv.STT, 0, 1);
            this.Close();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CTPhieuDichVu_DTO phieudv = new CTPhieuDichVu_DTO();
            Decimal TienTrcCapNhat;
            phieudv.SoPhieuDichVu = Int16.Parse(txtSoPhieudv.Text);
            phieudv.STT = Int16.Parse(txtSTT.Text);
            phieudv.MaLoaiDV = Int16.Parse(comboBox_MaLoaiDichVu.SelectedValue.ToString());
            phieudv.DonGia = Decimal.Parse(txtDonGia.Text);
            phieudv.SoLuong = Int16.Parse(txtSoLuong.Text);
            TienTrcCapNhat = phieudv.ThanhTien;
            phieudv.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieudv.TinhTrang = Int32.Parse(comboBox_TinhTrang.SelectedValue.ToString());
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();


            ctphieudv_bus.CTPhieuDichVu_Upd(phieudv);
            phieudv_bus.CapNhatTongTien(phieudv.SoPhieuDichVu, phieudv.STT, TienTrcCapNhat, 2);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_MaLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = ctphieudv_bus.LayDonGiaLoaiDV(comboBox_MaLoaiDichVu.SelectedValue.ToString());
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (txtSoLuong.Text.CompareTo("")!=0)

                if (Int32.TryParse(txtSoLuong.Text, out number) == true)
                {
                    Decimal tien = Decimal.Parse(txtDonGia.Text) * Int32.Parse(txtSoLuong.Text);
                    txtThanhTien.Text = tien.ToString();
                }
                else MessageBox.Show("Nhập sai số lượng - Chỉ nhập số!");
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.CompareTo("") != 0)
            {
                Decimal tien = Decimal.Parse(txtDonGia.Text) * Int16.Parse(txtSoLuong.Text);
                txtThanhTien.Text = tien.ToString();
            }
        }

        private void FormCTPhieuDichVu_AddUpd_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
