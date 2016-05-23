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
        public string TongTien { get; set; }
        public string TenKH { get; set; }
        public  PhieuMH_KH() { }
        public PhieuMH_KH(int soPhieuMua, int maKH,string ngayMua,string ngayThanhToan,string tongTien, string tenKH) {
            SoPhieuMua = soPhieuMua;
            MaKH=maKH;
            NgayMua = ngayMua;
            NgayThanhToan = ngayThanhToan;
            TongTien = tongTien;
            TenKH = tenKH;
        }
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
        public string LayTenKH(int makh)
        {
            return DB.KHACHHANGs.Where(kh => kh.MaKH == makh).FirstOrDefault().TenKh;
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
        public List<PhieuMuaHang_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in DB.PHIEUMUAHANGs
                           select new PhieuMuaHang_DTO
                           {
                               SoPhieuMua = pbh.SoPhieuMua,
                               MaKH = pbh.MaKH,
                               NgayMua = pbh.NgayMua.Value.ToShortDateString(),
                               NgayThanhToan = pbh.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = Decimal.Parse(pbh.TongTien.ToString())
                           });
            return MyQuery.ToList();
        }
        public void CapNhapPhieuMH(PhieuMuaHang_DTO a)
        {
            var obj = DB.PHIEUMUAHANGs.Single(x => x.SoPhieuMua == a.SoPhieuMua);
            obj.TongTien = a.TongTien;
            obj.MaKH = a.MaKH;
            obj.NgayThanhToan = DateTime.Parse(a.NgayThanhToan);
            obj.NgayMua = DateTime.Parse(a.NgayMua);
            DB.SubmitChanges();
        }
        public void ThemPhieuMuaHang(PhieuMuaHang_DTO a)
        {
            PHIEUMUAHANG b = new PHIEUMUAHANG();
            b.SoPhieuMua = a.SoPhieuMua;
            b.TongTien = a.TongTien;
            b.MaKH = a.MaKH;
            b.NgayMua = DateTime.Parse(a.NgayMua);
            b.NgayThanhToan = DateTime.Parse(a.NgayThanhToan);
            DB.PHIEUMUAHANGs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
    }
}
