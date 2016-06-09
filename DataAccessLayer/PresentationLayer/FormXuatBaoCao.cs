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
  
    public partial class FormXuatBaoCao : Form
    {
        BaoCao_bus bcbus = new BaoCao_bus();
        private LayMaBaoCao mbc;
        public FormXuatBaoCao()
        {
            InitializeComponent();
        }
        public FormXuatBaoCao(LayMaBaoCao mbc)
        {

            InitializeComponent();
           int a = mbc.mabaocao;
           CTBaoCao_DTOBindingSource.DataSource = bcbus.LayCTBaoCao(a);
         //   string a = bcbus
           BaoCaoTonKho_DTOBindingSource.DataSource = bcbus.LayMaNgayBC(a);
           this.reportViewer1.RefreshReport();
           //this.reportViewer2.RefreshReport();
        }
        private void FormXuatBaoCao_Load(object sender, EventArgs e)
        {
          //  CTBaoCao_DTOBindingSource.DataSource = bcbus.LayCTBaoCao(a);
            
           // this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }
    }
}
