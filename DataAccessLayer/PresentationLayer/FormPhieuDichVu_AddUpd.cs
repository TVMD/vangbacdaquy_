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
            comboBox_MaKhachHang.DataSource = phiedichvu_bus.LayDSMaKhachHang();
            comboBox_MaKhachHang.ValueMember = "MaKH";
            comboBox_MaKhachHang.DisplayMember = "TenKH";
           // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //comboBox_TenKH.SelectedValue = comboBox_MaKhachHang.SelectedValue;
            //
            int khoamoi = Int16.Parse(phiedichvu_bus.LayKhoaMoi()) + 1;
            txtSoPhieudv.Text = khoamoi.ToString();

            btnCapNhat.Enabled = false;

            //
            comboBox_TinhTrang.DisplayMember = "Text";
            comboBox_TinhTrang.ValueMember = "Value";
            var items = new[] { 
                                new { Text = "Chưa giao", Value = 0 }, 
                                new { Text = "Đã giao", Value = 1 }
                            };
            comboBox_TinhTrang.DataSource = items;

        }
        public FormPhieuDichVu_AddUpd(PhieuDichVu_DTO phieudv)
        {
            InitializeComponent();
            comboBox_MaKhachHang.DataSource = phiedichvu_bus.LayDSMaKhachHang();
            comboBox_MaKhachHang.ValueMember = "MaKH";
            comboBox_MaKhachHang.DisplayMember = "TenKH";
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //
            txtSoPhieudv.Text = phieudv.SoPhieuDV.ToString();
            comboBox_MaKhachHang.SelectedValue = phieudv.MaKH;
            dtPicker_NgayDangKy.Value = DateTime.Parse(phieudv.NgayDangKy);
            dtPicker_NgayGiao.Value = DateTime.Parse(phieudv.NgayGiao);
            txtDiaChi.Text = phieudv.DiaChi;
            txtTongTien.Text = phieudv.TongTien.ToString();
            comboBox_TinhTrang.SelectedValue = phieudv.TinhTrang.ToString();

            btnThem.Enabled = false;

            //
            comboBox_TinhTrang.DisplayMember = "Text";
            comboBox_TinhTrang.ValueMember = "Value";
            var items = new[] { 
                                new { Text = "Chưa duyệt", Value = 0 }, 
                                new { Text = "Đã duyệt", Value = 1 }
                            };
            comboBox_TinhTrang.DataSource = items;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
                PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
                phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
                phieudv.MaKH = Int16.Parse(comboBox_MaKhachHang.SelectedValue.ToString());
                phieudv.NgayDangKy = dtPicker_NgayDangKy.Value.ToShortDateString();
                phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();
                phieudv.DiaChi = txtDiaChi.Text;
                phieudv.TongTien = 0;
                phieudv.TinhTrang = Int32.Parse(comboBox_TinhTrang.SelectedValue.ToString());

                phiedichvu_bus.PhieuDichVu_Add(phieudv);
                this.Close();
            


            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            PhieuDichVu_DTO phieudv = new PhieuDichVu_DTO();
            phieudv.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
            phieudv.MaKH = Int16.Parse(comboBox_MaKhachHang.SelectedValue.ToString());
            phieudv.NgayDangKy = dtPicker_NgayDangKy.Value.ToShortDateString();
            phieudv.NgayGiao = dtPicker_NgayGiao.Value.ToShortDateString();
            phieudv.DiaChi = txtDiaChi.Text;
            phieudv.TongTien = Decimal.Parse(txtTongTien.Text);
            phieudv.TinhTrang = Int32.Parse(comboBox_TinhTrang.SelectedValue.ToString());

            phiedichvu_bus.PhieuDichVu_Upd(phieudv);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPhieuDichVu_AddUpd_Load(object sender, EventArgs e)
        {
            //comboBox_MaKhachHang.DataSource = phiedichvu_bus.LayDSMaKhachHang();
            //comboBox_MaKhachHang.ValueMember = "MaKH";
            //comboBox_MaKhachHang.DisplayMember = "MaKH";
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            M_KhachHangEdit them = new M_KhachHangEdit();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.OK)
            {
                comboBox_MaKhachHang.DataSource = phiedichvu_bus.LayDSMaKhachHang();
                comboBox_MaKhachHang.DisplayMember = "TenKh";
                comboBox_MaKhachHang.ValueMember = "MaKh";
            }
        }

        private void comboBox_MaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
