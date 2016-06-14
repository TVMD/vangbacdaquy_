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
    public partial class M_DangNhap : Form
    {
        private int nhapsai = 0;
        public M_DangNhap()
        {
            InitializeComponent();
        }

        private void M_DangNhap_Load(object sender, EventArgs e)
        {
            txtpass.MaxLength = 13;
            txtusername.MaxLength = 19;
            txtpass.PasswordChar = '*';
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            NguoiDung_DTO x = (new M_NguoiDungBLL()).Get(txtusername.Text);
            if (x!= null){
                if (MD5Encode.GetMd5Hash(txtpass.Text) == x.Pass)
                {
                    MainForm mainform = new MainForm(x);
                    this.Visible = false;
                    if (mainform.ShowDialog() == DialogResult.OK)
                        this.Close();
                    else // đăng xuất ra
                    {
                        this.Visible = true;
                    }
                    return;
                }
            }

            nhapsai++;
            if (nhapsai > 5)
            {
                MessageBox.Show("Phát hiện nghi vấn hack !","Thông báo");
                this.Close();
            }
                
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác, vui lòng nhập lại");
            txtusername.Focus();

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonDangNhap_Click(sender, e);
            }
        }
    }
}
