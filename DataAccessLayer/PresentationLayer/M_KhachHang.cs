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
    public partial class M_KhachHang : Form
    {
        int mod = 0;
        M_KhachHangBLL kh = new M_KhachHangBLL();
        int TSQuen = int.Parse((new M_ThamSoBLL()).Get("Quen"));

        public M_KhachHang()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void loaddatagridview(BindingList<KhachHang_DTO> khs)
        {
            datagridviewKH.DataSource = khs;
            datagridviewKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            datagridviewKH.Columns["TenKh"].HeaderText = "Tên";
            datagridviewKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            datagridviewKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
            datagridviewKH.Columns["SDT"].HeaderText = "SDT";
            datagridviewKH.Columns["Quen"].Visible = false;
            
            if (mod==0)
            {
                //datagridviewKH.Columns["TenKh"].Width *= 2;
                //datagridviewKH.Columns["DiaChi"].Width *= 2;
                //datagridviewKH.Columns["MaKH"].Width -= datagridviewKH.Columns["MaKH"].Width / 4;

                DataGridViewColumn columnloai = new DataGridViewColumn();
                columnloai.HeaderText = "Loại";
                columnloai.Name = "Loai";
                columnloai.CellTemplate = datagridviewKH.Columns["NgaySinh"].CellTemplate;
                datagridviewKH.Columns.Add(columnloai);
                mod = 1;
            }
            foreach (DataGridViewRow r in datagridviewKH.Rows)
            {
                if (int.Parse(r.Cells["Quen"].Value.ToString()) >= TSQuen)
                {
                    r.Cells["Loai"].Value = "Khách Quen";
                }
                else
                    r.Cells["Loai"].Value = "Vãn lai";

            }         
        }
        public Form RefToMainForm { set; get; }
        private void M_KhachHang_Load(object sender, EventArgs e)
        {
            var khs = kh.SelectTop(0);
            loaddatagridview(khs);
            ControlBox = false;
            DataTable dt = new DataTable ();
            dt.TableName = "LoaiKH";
            dt.Columns.Add("Quen");
            dt.Columns.Add("HienThi");
            dt.Rows.Add(new Object[] { -1, "Tất cả" });
            dt.Rows.Add(new Object[] {TSQuen-1,"Vãn lai"});
            dt.Rows.Add(new Object[] {TSQuen,"Khách quen"});
            comboBoxLoai.DataSource = dt;
            comboBoxLoai.ValueMember = "Quen";
            comboBoxLoai.DisplayMember="HienThi";
        }

        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            BindingList<KhachHang_DTO> khs;
            try
            {
                this.dateTimePickerNgaySinh.CustomFormat = "yyyy/mm/dd";
                int makh = txtMaKhachHang.Text==""? 0 : int.Parse(txtMaKhachHang.Text);
                int quen = int.Parse(comboBoxLoai.SelectedValue.ToString());
                khs = kh.Search(
                                   makh,
                                   txtTenKhachHang.Text,
                                   dateTimePickerNgaySinh.Text,
                                   txtDiaChi.Text,
                                   txtSDT.Text,
                                   quen,TSQuen,
                                   100);
                loaddatagridview(khs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+dateTimePickerNgaySinh.Text);
            }

            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dateTimePickerNgaySinh.Text = DateTime.Now.ToShortDateString();
            
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            kh.Save();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridviewKH.SelectedRows)
            {
                if(kh.isNo((int)item.Cells["MaKH"].Value)){
                    MessageBox.Show("Khách này đã thực hiện giao dịch, không thể xóa. Hãy xóa các phiếu bán,phiếu dịch vụ phiếu nợ... của khách trước khi xóa khách này.(Không khuyến khích xóa.)");
                }
                else
                {
                    kh.Delete((int)item.Cells["MaKH"].Value);
                    datagridviewKH.Rows.Remove(item);
                }
            }       
        }

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            M_KhachHangEdit form = new M_KhachHangEdit();
            form.Text = "THÊM THÔNG TIN KHÁCH HÀNG";
            
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loaddatagridview(this.kh.SelectTop(0));
            }
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r = datagridviewKH.SelectedRows[0];
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.MaKH = (int)r.Cells["MaKH"].Value;
                kh.TenKh = r.Cells["TenKh"].Value.ToString();
                kh.DiaChi = r.Cells["DiaChi"].Value.ToString();
                kh.SDT = r.Cells["SDT"].Value.ToString();
                kh.NgaySinh = r.Cells["NgaySinh"].Value.ToString();

                M_KhachHangEdit form = new M_KhachHangEdit(kh);
                form.Text = "CHỈNH SỬA THÔNG TIN KHÁCH HÀNG";

                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    loaddatagridview(this.kh.SelectTop(0));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString() + "\nNếu chưa chọn dòng nào hãy chọn 1 dòng");
            }
        }

        private void comboBoxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(comboBoxLoai.SelectedValue.ToString());
            }
            catch (Exception except)
            {
                return;
            }
            toolStripTimkiem_Click(sender, e);
        }

        private void datagridviewKH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripSửa_Click(sender,e);
        }

        private void datagridviewKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow r = datagridviewKH.SelectedRows[0];
            txtMaKhachHang.Text = r.Cells["MaKH"].Value.ToString();
            txtTenKhachHang.Text = r.Cells["TenKh"].Value.ToString();
            txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = r.Cells["SDT"].Value.ToString();
            dateTimePickerNgaySinh.Text = r.Cells["NgaySinh"].Value.ToString();
            //comboBoxLoai.Text = r.Cells["Loai"].Value.ToString();
        }

        private void txtMaKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtTenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }    
    }
}
