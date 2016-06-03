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
    public class M_KhachHangBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        public KhachHang_DTO GetById(int makh)
        {
            var myquery = (from kh in datacontext.KHACHHANGs.Where(p=>p.MaKH==makh)
                           select new KhachHang_DTO
                           {
                               MaKH = kh.MaKH,
                               TenKh = kh.TenKh,
                               NgaySinh = kh.NgaySinh.Value.ToShortDateString(),
                               DiaChi = kh.DiaChi,
                               SDT = kh.SDT,
                               Quen = (int)kh.Quen
                           });
            return myquery.FirstOrDefault();
        }
        public BindingList<KhachHang_DTO> SelectTop(int top)
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
            if (top != 0)
            {
                var r = new BindingList<KhachHang_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<KhachHang_DTO>(MyQuery.ToList());
                return r;
            }
            
        }
        public BindingList<KhachHang_DTO> Search(int makhachhang, string tenkhachhang,
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
            var r = new BindingList<KhachHang_DTO>(myquery.Take(top).ToList());
            return r;
        }

        public void Insert(int makhachhang, string tenkhachhang,
            string ngaysinh, string diachi, string sdt, int quen)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = makhachhang;
            kh.TenKh = tenkhachhang;
            kh.DiaChi = diachi;
            kh.NgaySinh = DateTime.Parse(ngaysinh);
            kh.SDT = sdt;
            kh.Quen = quen;
            datacontext.KHACHHANGs.InsertOnSubmit(kh);     
        }

        public void Update(int makhachhang, string tenkhachhang,
            string ngaysinh, string diachi, string sdt)
        {
            KHACHHANG kh = datacontext.KHACHHANGs.Where(p => p.MaKH == makhachhang).FirstOrDefault();
            if (kh != null)
            {
                kh.TenKh = tenkhachhang;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.DiaChi = diachi;
                kh.SDT = sdt;
            }
        }
        public void Delete(int makhachhang)
        {
            KHACHHANG kh = datacontext.KHACHHANGs.Where(p => p.MaKH == makhachhang).FirstOrDefault();
            if (kh != null)
            {
                datacontext.KHACHHANGs.DeleteOnSubmit(kh);
            }
        }
        public void Save()
        {
            try
            {
                datacontext.SubmitChanges();
            }
            catch (Exception e)
            {
                
            }
        }
        public int GetMaKH()
        {
            int result = 0;
            var x = (from row in datacontext.KHACHHANGs
                     group row by true into r
                     select new
                     {
                         max = r.Max(z => z.MaKH)
                     }
                      );
            result = x.ToArray()[0].max + 1;
            return result;
        }
    }

}