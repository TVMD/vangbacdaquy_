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
//using DataAccessLayer;
using DTO;
namespace PresentationLayer
{
    public partial class FormThemPhieuMuaHang : Form
    {
        PhieuMuaHangDLL mh = new PhieuMuaHangDLL();
        public FormThemPhieuMuaHang()
        {
            InitializeComponent();
        }

        private void chbKH_CheckedChanged(object sender, EventArgs e)
        {
            if(chbKH.Checked)
            {
                cbbKH.Visible = true;
                lbKH.Visible = true;
            }
            else 
            {
                cbbKH.Visible = false;
                lbKH.Visible = false;
            }
        }

        private void FormThemPhieuBanHang_Load(object sender, EventArgs e)
        {
            cbbKH.Visible = false;
            lbKH.Visible = false;
            cbbKH.DataSource = mh.LayKH();
            cbbKH.DisplayMember = "TenKh";
            cbbKH.ValueMember = "MaKh";
            dtNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtNgayThanhToan.CustomFormat = "dd-MM-yyyy";
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd-MM-yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhieuMuaHang_DTO a = new PhieuMuaHang_DTO();
            //PHIEUMUAHANG a = new PHIEUMUAHANG();
            //a.SoPhieuMua = Int16.Parse(txtSoPhieuThu.Text);
            //a.TongTien = Int16.Parse(txtTongTien.Text);
            if(DateTime.Compare(dtNgayMua.Value,dtNgayThanhToan.Value)>1)
            {
                MessageBox.Show("Ngày mua phải sớm hơn ngày thanh toán");
                return;
            }
            a.MaKH = Int16.Parse(cbbKH.SelectedValue.ToString());
            a.NgayMua = dtNgayMua.Value.ToShortDateString();
            a.NgayThanhToan = dtNgayThanhToan.Value.ToShortDateString();
            //txtSoPhieuThu.Text = cbbKH.SelectedValue.ToString();
            mh.ThemPhieuMuaHang(a);
            
            }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhieuBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
