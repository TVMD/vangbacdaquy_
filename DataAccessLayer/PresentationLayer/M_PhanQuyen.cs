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
    public partial class M_PhanQuyen : Form
    {
        M_PhanQuyenBLL PhanQuyen = new M_PhanQuyenBLL();
        
        public M_PhanQuyen()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        public string sploadgrid(string x)
        {
            try
            {
                switch (int.Parse(x))
                {
                    case 0: return "Không";
                    case 1: return "Thêm";
                    case 2: return "Xóa, Sửa";
                    case 3: return "Toàn quyền";
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }
        private void loaddatagridview(BindingList<PhanQuyen_DTO> pq)
        {
            datagridviewPQ.DataSource = pq;
            datagridviewPQ.Columns["QUYEN"].HeaderText = "Quyền";
            datagridviewPQ.Columns["PHIEUMUA"].HeaderText = "Mua";
            datagridviewPQ.Columns["PHIEUBAN"].HeaderText = "Bán";
            datagridviewPQ.Columns["DICHVU"].HeaderText = "Dịch vụ";
            datagridviewPQ.Columns["QUANLY"].HeaderText = "Quản lý chung";
            datagridviewPQ.Columns["THUKHO"].HeaderText = "Thủ kho";

            DataTable dt = new DataTable();
            dt.TableName = "PhanQuyen";
            dt.Columns.Add("Quyen");
            dt.Columns.Add("PhieuMua");
            dt.Columns.Add("PhieuBan");
            dt.Columns.Add("DichVu");
            dt.Columns.Add("QuanLy");
            dt.Columns.Add("ThuKho");
            foreach (DataGridViewRow r in datagridviewPQ.Rows)
            {
                dt.Rows.Add(new Object[] { r.Cells["QUYEN"].Value.ToString(), 
                    sploadgrid(r.Cells["PHIEUMUA"].Value.ToString()),
                    sploadgrid(r.Cells["PHIEUBAN"].Value.ToString()),
                    sploadgrid(r.Cells["DICHVU"].Value.ToString()),
                    sploadgrid(r.Cells["QUANLY"].Value.ToString()),
                    sploadgrid(r.Cells["THUKHO"].Value.ToString())
                });
            }

            datagridviewPQ.DataSource = dt;
        }

        private void M_PhanQuyen_Load(object sender, EventArgs e)
        {
            var data = PhanQuyen.SelectTop(0);
            loaddatagridview(data);
        }

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            M_PhanQuyenEdit form = new M_PhanQuyenEdit();
            form.Text = "THÊM QUYỀN";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loaddatagridview(this.PhanQuyen.SelectTop(0));
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridviewPQ.SelectedRows)
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PhanQuyen.Delete(item.Cells["Quyen"].Value.ToString());
                    datagridviewPQ.Rows.Remove(item);
                }
            } 
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r = datagridviewPQ.SelectedRows[0];
                PhanQuyen_DTO x = (new M_PhanQuyenBLL()).Get(r.Cells["Quyen"].Value.ToString());
                M_PhanQuyenEdit form = new M_PhanQuyenEdit(x);
                form.Text = "CHỈNH SỬA QUYỀN";

                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    loaddatagridview(this.PhanQuyen.SelectTop(0));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString() + "\nNếu chưa chọn dòng nào hãy chọn 1 dòng");
            }
        }

        private void datagridviewPQ_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripSửa_Click(sender,e);
        }
    }
}
