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
        
        

        private void FormBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bcbus.LayBaoCaoTonKho();

            
          
        }
        public int mabaocao;
         
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
                mabaocao = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaBaoCao"].Value.ToString());
                dataGridView2.DataSource = bcbus.LayCTBaoCao(mabaocao);
    
          
        }

       
    BaoCaoTonKho_DTO bctk = new BaoCaoTonKho_DTO();
    CTBaoCao_DTO ct = new CTBaoCao_DTO();

        private void btnLapBaoCao_Click(object sender, EventArgs e)
        { 
            int tam;
            if(dataGridView1.RowCount == 0) tam =  1;           
            else tam = bcbus.LayMaBaoCao() + 1;
            bctk.MaBaoCao = tam; 
            bctk.NgayLap = DateTime.Now.ToString();
            bcbus.CapNhat(bctk);

           DateTime ngay1 =DateTime.Parse( dateTimePicker1.Value.ToString("yyyy/MM/dd"));
           DateTime ngay2 = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy/MM/dd"));
         //  textBox1.Text = ngay1.ToShortDateString();
            bcbus.InsertCTBaoCao(tam, ngay1, ngay2 );
            dataGridView1.DataSource = bcbus.LayBaoCaoTonKho();

          //  dataGridView1.ClearSelection();
           // int nRowIndex = dataGridView1.Rows.Count - 1;

          //  dataGridView1.Rows[nRowIndex].Selected = true;
          //  dataGridView1.Rows[nRowIndex].Cells[0].Selected = true;
           // dataGridView1.
           // dataGridView1_CellClick()

        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            LayMaBaoCao mbc = new LayMaBaoCao();
            mbc.mabaocao = mabaocao;
            FormXuatBaoCao form = new FormXuatBaoCao(mbc);
            DialogResult dr = form.ShowDialog();
        }

        
    }
    public class LayMaBaoCao
    {
        public int mabaocao { set; get; }
      
    }
}
