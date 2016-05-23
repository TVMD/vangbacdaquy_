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
    public partial class M_KhachHang : Form
    {
        M_KhachHangBLL kh = new M_KhachHangBLL();
        public M_KhachHang()
        {
            InitializeComponent();
        }

        private void loaddatagridview()
        {
            datagridviewKH.DataSource = kh.SelectTop(100);
            datagridviewKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            datagridviewKH.Columns["TenKh"].HeaderText = "Tên";
            datagridviewKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            datagridviewKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
            datagridviewKH.Columns["SDT"].HeaderText = "SDT";
            datagridviewKH.Columns["Quen"].HeaderText = "Loại";

            foreach (DataGridViewRow r in datagridviewKH.Rows)
            {
                r.Cells["Quen"].Value = 100;
            }
        }
        private void M_KhachHang_Load(object sender, EventArgs e)
        {
            loaddatagridview();
        }
    
    }
}
