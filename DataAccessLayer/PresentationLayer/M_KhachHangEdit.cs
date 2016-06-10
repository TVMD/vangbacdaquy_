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
    public partial class M_KhachHangEdit : Form
    {
        private KhachHang_DTO khachhang;
        private M_KhachHangBLL khachhangbll = new M_KhachHangBLL();
        private int EditorAdd; // 0: edit  // 1: add
        public M_KhachHangEdit() // add
        {
            InitializeComponent();
            EditorAdd = 1;
            txtMaKhachHang.ReadOnly = true;
            txtMaKhachHang.Text = khachhangbll.GetMaKH().ToString();
        }
        public M_KhachHangEdit(KhachHang_DTO kh) // edit
        {
            khachhang = kh;
            InitializeComponent();
            EditorAdd = 0;
            txtMaKhachHang.ReadOnly = true;
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (EditorAdd == 0) //edit
            {
                khachhangbll.Update(int.Parse(txtMaKhachHang.Text), txtTenKhachHang.Text,
            dateTimePickerNgaySinh.Text, txtDiaChi.Text, txtSDT.Text);
                khachhangbll.Save();
            }
            if (EditorAdd == 1)
            {
                khachhangbll.Insert(int.Parse(txtMaKhachHang.Text), txtTenKhachHang.Text,
            dateTimePickerNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, 0);
                khachhangbll.Save();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void M_KhachHangEdit_Load(object sender, EventArgs e)
        {
            if (EditorAdd == 0) //edit
            {
                txtMaKhachHang.Text = khachhang.MaKH.ToString();
                txtTenKhachHang.Text = khachhang.TenKh;
                txtDiaChi.Text = khachhang.DiaChi;
                dateTimePickerNgaySinh.Text = khachhang.NgaySinh;
                txtSDT.Text = khachhang.SDT;
            }
        }

        private void M_KhachHangEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
        }

        private void txtMaKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (EditorAdd == 0) //edit
            {
                khachhangbll.Update(int.Parse(txtMaKhachHang.Text), txtTenKhachHang.Text,
            dateTimePickerNgaySinh.Text, txtDiaChi.Text, txtSDT.Text);
                khachhangbll.Save();
            }
            if (EditorAdd == 1)
            {
                khachhangbll.Insert(int.Parse(txtMaKhachHang.Text), txtTenKhachHang.Text,
            dateTimePickerNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, 0);
                khachhangbll.Save();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
