﻿using System;
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
    
    public partial class FormSuaChiTietMua : Form
    {
        ChiTietMuaHangBus ct = new ChiTietMuaHangBus();
        KieuSP_BUS k = new KieuSP_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        int Sopm;
        int STT;
        public FormSuaChiTietMua()
        {
            InitializeComponent();
        }
        public FormSuaChiTietMua(int sopm, int stt)
        {
            InitializeComponent();
            Sopm = sopm;
            STT = stt;
        }
        public FormChiTietMuaHang RefToMom { get; set; }
        private void FormSuaChiTietMua_Load(object sender, EventArgs e)
        {
            cbbKieuSP.DataSource = ct.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = ct.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            CTPhieuMua_DTO a = new CTPhieuMua_DTO();
            a = ct.Lay1ChiTiet(Sopm, STT);
            txtDonGiaMua.Text = a.DonGia.ToString();
            txtSoLuong.Text = a.SoLuong.ToString();
            //txtTongTien.Text = a.ThanhTien.ToString();
            SanPham_DTO b = ct.Lay1SP(a.MaSP);
            cbbKieuSP.SelectedValue = b.MaKieuSP;
            cbbLoaiSP.SelectedValue = b.MaLoaiSP;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CTPhieuMua_DTO a = new CTPhieuMua_DTO();
            if (txtDonGiaMua.Text == "" || txtSoLuong.Text == "" )
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            int masp = 0;
            int kieusp = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            int loaisp = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            if (ct.KiemTraSP(kieusp, loaisp) == -1)
            {
                DialogResult dr = MessageBox.Show("Sản phẩm này chưa được lưu trong cơ sở dữ liệu, bạn có muốn thêm sản phẩm mới không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    FormThemSP them = new FormThemSP();
                    them.ShowDialog();
                    if (them.DialogResult == DialogResult.Cancel)
                    {
                        cbbKieuSP.DataSource = ct.LayKieuSP();
                        cbbKieuSP.DisplayMember = "TenKieuSP";
                        cbbKieuSP.ValueMember = "MaKieuSP";
                        cbbLoaiSP.DataSource = ct.LayLoaiSP();
                        cbbLoaiSP.DisplayMember = "TenLoaiSP";
                        cbbLoaiSP.ValueMember = "MaLoaiSP";
                    }
                    if (ct.KiemTraSP(kieusp, loaisp) == -1) return;
                    masp = ct.KiemTraSP(kieusp, loaisp);
                }
                else return;
            }
            else masp = ct.KiemTraSP(kieusp, loaisp);
            CTPhieuMua_DTO ctpm = new CTPhieuMua_DTO();
            ctpm.STT = STT;
            ctpm.SoPhieuMua = Sopm;
            ctpm.MaSP = masp;
            ctpm.SoLuong = Int16.Parse(txtSoLuong.Text);
            ctpm.DonGia = Decimal.Parse(txtDonGiaMua.Text);
            if(ctpm.SoLuong==0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }
            if (ctpm.DonGia == 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0");
                return;
            }
            ctpm.ThanhTien = ctpm.SoLuong*ctpm.DonGia;
            ct.CapNhapCTPhieuMH(ctpm);
            MessageBox.Show("Sửa thành công");
            RefToMom.load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLoaiSP_Click(object sender, EventArgs e)
        {
            FormThemLoaiSP them = new FormThemLoaiSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
            {
                cbbLoaiSP.DataSource = lo.LayLoaiSP();
                cbbLoaiSP.DisplayMember = "TenLoaiSP";
                cbbLoaiSP.ValueMember = "MaLoaiSP";
            }
        }

        private void btnAddKieuSP_Click(object sender, EventArgs e)
        {
            FormThemKieuSP them = new FormThemKieuSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
            {
                cbbKieuSP.DataSource = k.LayKieuSP();
                cbbKieuSP.DisplayMember = "TenKieuSP";
                cbbKieuSP.ValueMember = "MaKieuSP";
            }
        }

        private void txtDonGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
