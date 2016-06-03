using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_PhieuBanHang form = new M_PhieuBanHang();
            form.ShowDialog();
        }

        private void nợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_PhieuNo form = new M_PhieuNo();
            form.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_KhachHang form = new M_KhachHang();
            form.ShowDialog();
        }

        private void bánHàngToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            bánHàngToolStripMenuItem.ShowDropDown();
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_PhieuBanHang form = new M_PhieuBanHang();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
