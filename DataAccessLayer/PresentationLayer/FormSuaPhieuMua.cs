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
    public partial class FormSuaPhieuMua : Form
    {
        int Sopm;
        PhieuMuaHangDLL mh = new PhieuMuaHangDLL();
        public FormSuaPhieuMua()
        {
            InitializeComponent();
        }
        public FormSuaPhieuMua(int sopm)
        {
            InitializeComponent();
            Sopm = sopm;
        }

        private void FormSuaPhieuMua_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            cbbKH.DataSource = mh.LayKH();
            cbbKH.DisplayMember = "TenKh";
            cbbKH.ValueMember = "MaKh";
            cbbSoPhieuMua.DataSource = mh.LayTatCa();
            cbbSoPhieuMua.DisplayMember = "SoPhieuMua";
            cbbSoPhieuMua.ValueMember = "SoPhieuMua";
            if (Sopm != 0)
                cbbSoPhieuMua.SelectedValue = Sopm;
            //cbbKH.Visible = false;
            //lbKH.Visible = false;
            
            dtNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtNgayThanhToan.CustomFormat = "dd-MM-yyyy";
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd-MM-yyyy";
        }

        private void cbbSoPhieuMua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoPhieuMua.Text != "" && cbbSoPhieuMua.SelectedIndex != -1 && cbbSoPhieuMua.SelectedIndex != 0||cbbSoPhieuMua.Text=="1")
            {
                int sopt = Int16.Parse(cbbSoPhieuMua.Text);
                PhieuMuaHang_DTO pmh = mh.LayPhieuThu(sopt);
                //txtTongTien.Text = pmh.TongTien.ToString();
                DateTime ngaymua = DateTime.Parse(pmh.NgayMua);
                DateTime ngaytt = DateTime.Parse(pmh.NgayThanhToan);
                dtNgayMua.Value = ngaymua;
                dtNgayThanhToan.Value = ngaytt;
                cbbKH.SelectedValue = pmh.MaKH;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PhieuMuaHang_DTO a = new PhieuMuaHang_DTO();
            //PHIEUMUAHANG a = new PHIEUMUAHANG();
            if (DateTime.Compare(dtNgayMua.Value, dtNgayThanhToan.Value) > 1)
            {
                MessageBox.Show("Ngày mua phải sớm hơn ngày thanh toán");
                return;
            }
            a.SoPhieuMua = Int16.Parse(cbbSoPhieuMua.SelectedValue.ToString());
            //a.TongTien = Decimal.Parse(txtTongTien.Text);
            a.MaKH = Int16.Parse(cbbKH.SelectedValue.ToString());
            a.NgayMua = dtNgayMua.Value.ToShortDateString();
            a.NgayThanhToan = dtNgayThanhToan.Value.ToShortDateString();
            mh.CapNhapPhieuMH(a);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaPhieuMua_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dtNgayMua_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
