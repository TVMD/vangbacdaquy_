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

namespace PresentationLayer
{
    public partial class Form_ThamSoEdit : Form
    {
        ThamSo_BUS thamsobus = new ThamSo_BUS();
        public Form_ThamSoEdit()
        {
            InitializeComponent();
        }

        private void Form_ThamSoEdit_Load(object sender, EventArgs e)
        {
            txtNoToiDa.Text = thamsobus.LayNoToiDa();
            txtQuen.Text = thamsobus.LayQuen();
            btnLuu.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(txtNoToiDa.Text, out number) == true && Int32.TryParse(txtQuen.Text, out number))
            {
                thamsobus.SaveThamSo(txtNoToiDa.Text, txtQuen.Text);
                btnLuu.Enabled = false;
                MessageBox.Show("Lưu thành công!");
            }
            else MessageBox.Show("Nhập sai. Vui lòng chỉ nhập số!");
            
        }

        private void txtNoToiDa_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void txtQuen_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }
    }
}
