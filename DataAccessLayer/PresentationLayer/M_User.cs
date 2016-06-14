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
    public partial class M_User : Form
    {
        private M_NguoiDungBLL NguoiDung = new M_NguoiDungBLL();

        public M_User()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void loaddatagridview(BindingList<NguoiDung_DTO> user)
        {
            datagridviewPQ.DataSource = user;
            datagridviewPQ.Columns["QUYEN"].HeaderText = "Quyền";
            datagridviewPQ.Columns["USERNAME"].HeaderText = "Tên người dùng";
            datagridviewPQ.Columns["PASS"].Visible = false;

            if (datagridviewPQ.Columns["USERNAME"].Width == datagridviewPQ.Columns["QUYEN"].Width)
                datagridviewPQ.Columns["USERNAME"].Width *= 2;
        }

        private void M_User_Load(object sender, EventArgs e)
        {
            var data = NguoiDung.SelectTop(0);
            loaddatagridview(data);
        }

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            M_UserEdit form = new M_UserEdit();
            form.Text = "THÊM NGƯỜI DÙNG";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loaddatagridview(this.NguoiDung.SelectTop(0));
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridviewPQ.SelectedRows)
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa ?\n" + item.Cells["USERNAME"].Value.ToString(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    NguoiDung.Delete(item.Cells["USERNAME"].Value.ToString());
                    datagridviewPQ.Rows.Remove(item);
                }
            }
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r = datagridviewPQ.SelectedRows[0];
                NguoiDung_DTO x = NguoiDung.Get(r.Cells["USERNAME"].Value.ToString());
              
                M_UserEdit form = new M_UserEdit(x);
                form.Text = "CHỈNH SỬA NGƯỜI DÙNG";

                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    loaddatagridview(this.NguoiDung.SelectTop(0));
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void datagridviewPQ_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripSửa_Click(sender, e);
        }

    }
}
