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
                               NgaySinh = kh.NgaySinh.Value.ToShortDateString() ,
                               DiaChi = kh.DiaChi,
                               SDT = kh.SDT,
                               Quen = (int)kh.Quen
                           });
            return MyQuery.Take(top).ToList();
        }
        public List<KhachHang_DTO> Search(int makhachhang, string tenkhachhang,
            string ngaysinh, string diachi, string sdt, int quen, int top)
        {
            IEnumerable<MKhachHang_SearchResult> khachhang;
            khachhang = datacontext.MKhachHang_Search(makhachhang,
                                 tenkhachhang,
                                 DateTime.Parse(ngaysinh),
                                 diachi,
                                 sdt,
                                 quen);
            var myquery = (from x in khachhang
                           select new KhachHang_DTO
                               {
                                   MaKH = x.MaKH,
                                   TenKh = x.TenKH,
                                   NgaySinh = x.NgaySinh.Value.ToShortDateString(),
                                   DiaChi = x.DiaChi,
                                   SDT = x.SDT,
                                   Quen = (int)x.Quen
                               });
            return myquery.ToList();
        }
    }

}