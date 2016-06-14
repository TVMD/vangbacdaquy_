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
    public partial class M_PhanQuyenEdit : Form
    {
        private int edit; //0 add, 1 edit
        private PhanQuyen_DTO PhanQuyen;
        public M_PhanQuyenEdit()
        {
            edit = 0;
            InitializeComponent();
            txtQuyen.Enabled = true;
        }

        public M_PhanQuyenEdit(PhanQuyen_DTO pq)
        {
            edit = 1;
            InitializeComponent();
            txtQuyen.Enabled = false;
            PhanQuyen = pq;
        }

        private void M_PhanQuyenEdit_Load(object sender, EventArgs e)
        {
            if (edit == 1) //edit
            {
                txtQuyen.Text = PhanQuyen.Quyen;
                checkBoxbanthemban.Checked = PhanQuyen.PhieuBan == 1 || PhanQuyen.PhieuBan==3;
                checkBoxxoaban.Checked = PhanQuyen.PhieuBan == 2 || PhanQuyen.PhieuBan == 3;

                checkBoxthemmua.Checked = PhanQuyen.PhieuMua == 1 || PhanQuyen.PhieuMua == 3;
                checkBoxxoamua.Checked = PhanQuyen.PhieuMua == 2 || PhanQuyen.PhieuMua == 3;

                checkBoxthemdv.Checked = PhanQuyen.DichVu == 1 || PhanQuyen.DichVu == 3;
                checkBoxxoadv.Checked = PhanQuyen.DichVu == 2 || PhanQuyen.DichVu == 3;

                checkBoxthemqly.Checked = PhanQuyen.QuanLy == 1 || PhanQuyen.QuanLy == 3;
                checkBoxxoaql.Checked = PhanQuyen.QuanLy == 2 || PhanQuyen.QuanLy == 3;

                checkBoxthemkho.Checked = PhanQuyen.ThuKho == 1 || PhanQuyen.ThuKho == 3;
                checkBoxxoakho.Checked = PhanQuyen.ThuKho == 2 || PhanQuyen.ThuKho == 3;
            }
        }


        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (txtQuyen.Text == "") return;
            try
            {
                PhanQuyen_DTO x = new PhanQuyen_DTO()
                {
                    Quyen = txtQuyen.Text,
                    PhieuBan = !checkBoxbanthemban.Checked && !checkBoxxoaban.Checked ? 0
                        : checkBoxbanthemban.Checked && !checkBoxxoaban.Checked ? 1
                        : !checkBoxbanthemban.Checked && checkBoxxoaban.Checked ? 2
                        : 3,

                    PhieuMua = !checkBoxthemmua.Checked && !checkBoxxoamua.Checked ? 0
                        : checkBoxthemmua.Checked && !checkBoxxoamua.Checked ? 1
                        : !checkBoxthemmua.Checked && checkBoxxoamua.Checked ? 2
                        : 3,
                    DichVu = !checkBoxthemdv.Checked && !checkBoxxoadv.Checked ? 0
                        : checkBoxthemdv.Checked && !checkBoxxoadv.Checked ? 1
                        : !checkBoxthemdv.Checked && checkBoxxoadv.Checked ? 2
                        : 3,
                    QuanLy = !checkBoxthemqly.Checked && !checkBoxxoaql.Checked ? 0
                        : checkBoxthemqly.Checked && !checkBoxxoaql.Checked ? 1
                        : !checkBoxthemqly.Checked && checkBoxxoaql.Checked ? 2
                        : 3,
                    ThuKho = !checkBoxthemkho.Checked && !checkBoxxoakho.Checked ? 0
                        : checkBoxthemkho.Checked && !checkBoxxoakho.Checked ? 1
                        : !checkBoxthemkho.Checked && checkBoxxoakho.Checked ? 2
                        : 3
                };
                if (edit == 0) //insert
                {
                    M_PhanQuyenBLL pq = new M_PhanQuyenBLL();
                    if (pq.KiemTra(x.Quyen))
                    {
                        pq.Insert(x);
                    }
                    else
                    {
                        MessageBox.Show("Quyền đã tồn tại, vui lòng nhập lại");
                        return;
                    }
                }
                if (edit == 1)//edit
                {
                    (new M_PhanQuyenBLL()).Update(x);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
