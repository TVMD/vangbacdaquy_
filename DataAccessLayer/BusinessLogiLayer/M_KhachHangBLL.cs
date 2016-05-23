using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class M_KhachHangBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        public List<KhachHang_DTO> SelectTop(int top)
        {

            var MyQuery = (from kh in datacontext.KHACHHANGs
                           select new KhachHang_DTO
                           {
                               MaKH = kh.MaKH,
                               TenKh = kh.TenKh,
                               NgaySinh = kh.NgaySinh.ToString(),
                               DiaChi = kh.DiaChi,
                               SDT = kh.SDT,
                               Quen = (int)kh.Quen
                           });
            return MyQuery.Take(top).ToList();

        }
    }
}

