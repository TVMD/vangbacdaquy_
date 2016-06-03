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
    public partial class FormBaoCaoTonKho : Form
    {
        BaoCao_bus bcbus = new BaoCao_bus();
        public FormBaoCaoTonKho()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void FormBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bcbus.LayBaoCaoTonKho();

            
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = bcbus.LayTatCa();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormXuatBaoCao form = new FormXuatBaoCao();
            DialogResult dr = form.ShowDialog();
        }
BaoCaoTonKho_DTO bctk = new BaoCaoTonKho_DTO();
        private void button2_Click(object sender, EventArgs e)
        {
            
            bctk.MaBaoCao = bcbus.LayMaBaoCao() + 1;
            bctk.NgayLap = DateTime.Now.ToString();
            bcbus.CapNhat(bctk);
            dataGridView1.DataSource = bcbus.LayBaoCaoTonKho();
        }

        
    }
}
