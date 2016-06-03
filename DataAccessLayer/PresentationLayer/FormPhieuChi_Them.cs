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
    public partial class FormPhieuChi_Them : Form
    {
        FormPhieuChi pc = new FormPhieuChi();
        PhieuChi_bus phieuchi_bus = new PhieuChi_bus();
        public FormPhieuChi_Them()
        {
            InitializeComponent();
            txtNgayChi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSoPhieuChi.Text = (phieuchi_bus.LayMaPhieuChi() + 1).ToString() ;
        }
         public FormPhieuChi_Them(PhieuChi_DTO phieuchi)
        {
            InitializeComponent();
            txtSoPhieuChi.Text = phieuchi.SoPhieuChi.ToString();
            txtNoiDung.Text = phieuchi.NoiDung;
            txtNgayChi.Text = phieuchi.NgayChi;
            txtSoTienChi.Text = phieuchi.SoTienChi.ToString();
            

        }

         private void btnThem_Click(object sender, EventArgs e)
         {
             if (txtNoiDung.Text.CompareTo("") == 0 || txtSoTienChi.Text.CompareTo("") == 0)
                 MessageBox.Show("Bạn chưa điền đầy đử thông tin !");
             
             else
             {
                 PhieuChi_DTO a = new PhieuChi_DTO();
                 a.SoPhieuChi = Int16.Parse(txtSoPhieuChi.Text);
                 a.NoiDung = txtNoiDung.Text;
                 a.NgayChi = txtNgayChi.Text;
                 a.SoTienChi = Decimal.Parse(txtSoTienChi.Text);

                 phieuchi_bus.PhieuChi_them(a);
                 this.Close();
             }
         }

         private void btnCapNhat_Click(object sender, EventArgs e)
         {
             PhieuChi_DTO phieuchi = new PhieuChi_DTO();
             phieuchi.SoPhieuChi = Int16.Parse(txtSoPhieuChi.Text);
             phieuchi.NoiDung = txtNoiDung.Text;
             phieuchi.NgayChi = txtNgayChi.Text;
             phieuchi.SoTienChi = Decimal.Parse(txtSoTienChi.Text);

             phieuchi_bus.PhieuChi_Upd(phieuchi);
             this.Close();
             
         }

         private void btnThoat_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         

         private void txtSoTienChi_TextChanged(object sender, EventArgs e)
         {
             Decimal number;
             if (txtSoTienChi.Text.CompareTo("") != 0)
                 if (Decimal.TryParse(txtSoTienChi.Text, out number) == false)
                {
                    MessageBox.Show("Nhập sai - Bạn chỉ có thể nhập số!");
                     return;
                 }
         }

         private void txtNgayChi_TextChanged(object sender, EventArgs e)
         {

         }
    }
}
