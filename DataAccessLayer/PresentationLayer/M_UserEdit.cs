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
    public partial class M_UserEdit : Form
    {
        private M_NguoiDungBLL NguoiDung = new M_NguoiDungBLL();
        private NguoiDung_DTO nguoidungdto;
        private string NewPass;
        private int Edit; //0 add, 1 edit , 2 thằng bt đổi mk
        public M_UserEdit()
        {
            Edit = 0;
            InitializeComponent();
            txtUser.Enabled = true;
        }

        public M_UserEdit(NguoiDung_DTO x)
        {
            Edit = 1;
            InitializeComponent();
            txtUser.Enabled = false;
            nguoidungdto = x;
        }

        public M_UserEdit(NguoiDung_DTO x,int nob) // cho ng bt đổi mật khẩu của nó xài khởi tạo này. truyền đại số chi vô cũng dc, k xài
        {
            Edit = 2;
            InitializeComponent();
            txtUser.Enabled = false;
            comboBoxQuyen.Enabled = false;
            nguoidungdto = x;
        }

        private void M_UserEdit_Load(object sender, EventArgs e)
        {
            comboBoxQuyen.DataSource = (new M_PhanQuyenBLL()).SelectTop(0);
            comboBoxQuyen.ValueMember = comboBoxQuyen.DisplayMember = "QUYEN";

            labelnewpass.Visible = false;
            txtnewpass.Visible = false;

            txtpass.PasswordChar = '*';
            txtpass.MaxLength = 13;
            txtnewpass.PasswordChar = '*';
            txtnewpass.MaxLength = 13;
            txtUser.MaxLength = 19;

            if (Edit == 1)
            {
                txtUser.Text = nguoidungdto.UserName;
                comboBoxQuyen.Text = nguoidungdto.Quyen;
                txtpass.Text = "";
            }
            if (Edit == 2)
            {
                txtUser.Text = nguoidungdto.UserName;
                comboBoxQuyen.Text = nguoidungdto.Quyen;
                txtpass.Text = "";

                labelnewpass.Visible = true;
                txtnewpass.Visible = true;
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Edit == 0) //add
                {
                    NguoiDung.Insert(new NguoiDung_DTO()
                    {
                        UserName = txtUser.Text,
                        Pass = MD5Encode.GetMd5Hash(txtpass.Text),
                        Quyen = comboBoxQuyen.Text
                    });
                }
                if (Edit == 1) //edit
                {
                    NguoiDung.Update(new NguoiDung_DTO()
                    {
                        UserName = txtUser.Text,
                        Pass = MD5Encode.GetMd5Hash(txtpass.Text),
                        Quyen = comboBoxQuyen.Text
                    });
                }

                if (Edit == 2) //mk
                {
                    if(!NguoiDung.KiemTra(txtUser.Text,MD5Encode.GetMd5Hash(txtpass.Text)))
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
                        return;
                    }
                    NguoiDung.Update(new NguoiDung_DTO()
                    {
                        UserName = txtUser.Text,
                        Pass = MD5Encode.GetMd5Hash(txtnewpass.Text),
                        Quyen = comboBoxQuyen.Text
                    });
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
