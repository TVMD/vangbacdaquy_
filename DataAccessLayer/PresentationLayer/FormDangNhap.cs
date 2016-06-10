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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private static FormDangNhap _instance;

        public static FormDangNhap Instance()
        {
            if (_instance == null)
                _instance = new FormDangNhap();
            return _instance;
        }
        public Form RefToMainForm { get; set; }
    }
}
