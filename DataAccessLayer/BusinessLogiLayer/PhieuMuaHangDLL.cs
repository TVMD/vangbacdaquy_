using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using DTO;


namespace BusinessLogiLayer
{
    public class PhieuMH_KH
    {
        public int SoPhieuMua { get; set; }
        public int MaKH { get; set; }
        public string NgayMua { get; set; }
        public string NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public  PhieuMH_KH() { }
        //public PhieuMH_KH(int soPhieuMua, int maKH,string ngayMua,string ngayThanhToan,string tongTien, string tenKH) {
        //    SoPhieuMua = soPhieuMua;
        //    MaKH=maKH;
        //    NgayMua = ngayMua;
        //    NgayThanhToan = ngayThanhToan;
        //    TongTien = tongTien;
        //    TenKH = tenKH;
        //}
    }
    public class PhieuMuaHangDLL
    {
        VBDQDataContext DB = new VBDQDataContext();
        
        public List<KhachHang_DTO> LayKH()
        {

            var MyQuery = (from kh in DB.KHACHHANGs
                           select new KhachHang_DTO
                           {
                               MaKH=kh.MaKH,
                               NgaySinh=kh.NgaySinh.ToString(),
                               DiaChi=kh.DiaChi,
                               SDT=kh.SDT,
                               TenKh = kh.TenKh,
                           });
            
            //var MyQuery = (from pbh in DB.PHIEUMUAHANGs select new PHIEUMUAHANG {}
            //return DB.PHIEUMUAHANGs.ToList();
            return MyQuery.ToList();
        }
        public KhachHang_DTO Lay1KH(int makh)
        {
            var MyQuery = (from kh in DB.KHACHHANGs
                           where kh.MaKH==makh
                           select new KhachHang_DTO
                           {
                               MaKH = kh.MaKH,
                               NgaySinh = kh.NgaySinh.ToString(),
                               DiaChi = kh.DiaChi,
                               SDT = kh.SDT,
                               TenKh = kh.TenKh,
                           });
            return MyQuery.FirstOrDefault();
        }
        public PhieuMuaHang_DTO LayPhieuThu(int sopm)
        {
            var MyQuery = (from pbh in DB.PHIEUMUAHANGs where pbh.SoPhieuMua==sopm
                           select new PhieuMuaHang_DTO
                           {
                               SoPhieuMua = pbh.SoPhieuMua,
                               MaKH = pbh.MaKH,
                               NgayMua = pbh.NgayMua.Value.ToShortDateString(),
                               NgayThanhToan = pbh.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = Decimal.Parse(pbh.TongTien.ToString())
                           });
            return MyQuery.FirstOrDefault();
        }
        public List<PhieuMH_KH> LayTatCa()
        {
            var MyQuery = (from pbh in DB.PHIEUMUAHANGs
                           join kh in DB.KHACHHANGs
                          on pbh.MaKH equals kh.MaKH
                           select new PhieuMH_KH
                           {
                               SoPhieuMua = pbh.SoPhieuMua,
                               MaKH = pbh.MaKH,
                               NgayMua = pbh.NgayMua.Value.ToShortDateString(),
                               NgayThanhToan = pbh.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = Decimal.Parse(pbh.TongTien.ToString()),
                               TenKH=kh.TenKh,
                               DiaChi=kh.DiaChi
                           });
            return MyQuery.ToList();
        }
        public void CapNhapPhieuMH(PhieuMuaHang_DTO a)
        {
            var obj = DB.PHIEUMUAHANGs.Single(x => x.SoPhieuMua == a.SoPhieuMua);
            //obj.TongTien = a.TongTien;
            int tamp = obj.MaKH;
            obj.MaKH = a.MaKH;
            if(tamp!=a.MaKH)
            {
                KHACHHANG kh = DB.KHACHHANGs.Where(p => p.MaKH == a.MaKH).FirstOrDefault();
                if (kh != null)
                {
                    kh.Quen += 1;
                }
                KHACHHANG k = DB.KHACHHANGs.Where(p => p.MaKH == tamp).FirstOrDefault();
                if (k != null)
                {
                    k.Quen -= 1;
                }
            }
            obj.NgayThanhToan = DateTime.Parse(a.NgayThanhToan);
            obj.NgayMua = DateTime.Parse(a.NgayMua);
            DB.SubmitChanges();
        }
        public void ThemPhieuMuaHang(PhieuMuaHang_DTO a)
        {
            PHIEUMUAHANG b = new PHIEUMUAHANG();
            //b.SoPhieuMua = a.SoPhieuMua;
            b.TongTien = a.TongTien;
            b.MaKH = a.MaKH;
            KHACHHANG kh = DB.KHACHHANGs.Where(p => p.MaKH == a.MaKH).FirstOrDefault();
            if (kh != null)
            {
                kh.Quen += 1;
            }
            b.NgayMua = DateTime.Parse(a.NgayMua);
            b.NgayThanhToan = DateTime.Parse(a.NgayThanhToan);
            DB.PHIEUMUAHANGs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
        public List<PhieuMH_KH> Search(PhieuMuaHang_DTO a, string diachi, string tenkh)
        {
            var pmh = DB.PhieuMuaSearch(a.SoPhieuMua, a.MaKH, a.NgayMua, a.NgayThanhToan,diachi, a.TongTien,tenkh);
            var MyQuery = (from mh in pmh
                           select new PhieuMH_KH
                           {
                               SoPhieuMua = mh.SoPhieuMua,
                               MaKH = mh.MaKH,
                               NgayMua = mh.NgayMua.Value.ToShortDateString(),
                               NgayThanhToan = mh.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = Decimal.Parse(mh.TongTien.ToString()),
                               TenKH = mh.TenKh,
                               DiaChi = mh.DiaChi
                           });
            return MyQuery.ToList();
        }
        public void XoaPhieuMuaHang(int sopm)
        {
            var MyQuery = (from p in DB.PHIEUMUAHANGs
                           where p.SoPhieuMua == sopm
                           select p);
            var Myquery = (from p in DB.CTPHIEUMUAs
                           where p.SoPhieuMua == sopm
                           select p);
            DB.CTPHIEUMUAs.DeleteAllOnSubmit(Myquery);
            DB.PHIEUMUAHANGs.DeleteAllOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
    }
}
