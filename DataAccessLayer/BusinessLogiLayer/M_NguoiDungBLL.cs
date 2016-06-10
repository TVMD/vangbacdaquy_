using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
using System.ComponentModel;

namespace BusinessLogiLayer
{
    public class M_NguoiDungBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();

        public BindingList<NguoiDung_DTO> SelectTop(int top)
        {

            var MyQuery = (from x in datacontext.NGUOIDUNGs
                           select new NguoiDung_DTO
                           {
                               UserName = x.USERNAME,
                               Pass = x.PASS,
                               Quyen =x.QUYEN
                           });
            if (top != 0)
            {
                var r = new BindingList<NguoiDung_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<NguoiDung_DTO>(MyQuery.ToList());
                return r;
            }

        }

        public void Insert(NguoiDung_DTO x)
        {
            NGUOIDUNG nguoidungmoi = new NGUOIDUNG()
            {
                QUYEN = x.Quyen,
                USERNAME =x.UserName,
                PASS = x.Pass
            };

            datacontext.NGUOIDUNGs.InsertOnSubmit(nguoidungmoi);
            datacontext.SubmitChanges();
        }

        public void Update(NguoiDung_DTO x)
        {
            datacontext = new VBDQDataContext();
            if (x.UserName == "super") return; // không cho sửa trùm cuối

            NGUOIDUNG p = datacontext.NGUOIDUNGs.Where(m => m.USERNAME == x.UserName).FirstOrDefault();
            if (p != null)
            {
                p.PASS = x.Pass;
                p.QUYEN = x.Quyen;
            }
            datacontext.SubmitChanges();
        }

        public void Delete(string username)
        {
            datacontext = new VBDQDataContext();
            if (username == "super") return; // không cho xóa trùm cuối

            NGUOIDUNG p = datacontext.NGUOIDUNGs.Where(m => m.USERNAME == username).FirstOrDefault();
            if (p != null)
            {
                datacontext.NGUOIDUNGs.DeleteOnSubmit(p);
            }
            datacontext.SubmitChanges();
        }

        public NguoiDung_DTO Get(string username)
        {
            NGUOIDUNG x = datacontext.NGUOIDUNGs.Where(m => m.USERNAME == username).FirstOrDefault();
            if (x != null) // có username, ss pass.
            {
                return new NguoiDung_DTO()
                {
                    Quyen = x.QUYEN,
                    Pass = x.PASS,
                    UserName = x.USERNAME
                };
            }
            else
                return null; // không tìm thấy
        }

        public Boolean KiemTra(string username,string pass)
        {
            NGUOIDUNG x = datacontext.NGUOIDUNGs.Where(m => m.USERNAME == username).FirstOrDefault();
            if (x != null) // có username, ss pass.
            {
                return x.PASS == pass;
            }
            else
                return false; // không tìm thấy
        }

    }
}
