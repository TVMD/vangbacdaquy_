using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class ChiTietMuaHangBus
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<CTPhieuMua_DTO> LayChiTiet(int sopm)
        {

            var MyQuery = (from pm in DB.CTPHIEUMUAs
                           where pm.SoPhieuMua==sopm
                           select new CTPhieuMua_DTO
                           {
                               SoPhieuMua=pm.SoPhieuMua,
                                STT=pm.STT,
                               MaSP=pm.MaSP??default(int),
                               DonGia = pm.DonGia??default(decimal) ,
                               SoLuong = pm.SoLuong ?? default(int),
                               ThanhTien=pm.ThanhTien??default(decimal)
                           });

            //var MyQuery = (from pbh in DB.PHIEUMUAHANGs select new PHIEUMUAHANG {}
            //return DB.PHIEUMUAHANGs.ToList();
            return MyQuery.ToList();
        }
        public void ThemChiTietMua(CTPhieuMua_DTO a)
        {
            CTPHIEUMUA b = new CTPHIEUMUA();
            b.SoPhieuMua = a.SoPhieuMua;
            b.MaSP = a.MaSP;
            b.DonGia = a.DonGia;
            b.SoLuong = a.SoLuong;
            b.ThanhTien = a.ThanhTien;
            DB.CTPHIEUMUAs.InsertOnSubmit(b);
            DB.SubmitChanges();
            var obj = DB.PHIEUMUAHANGs.Single(x => x.SoPhieuMua == a.SoPhieuMua);
            //obj.TongTien = a.TongTien;
            obj.TongTien += b.ThanhTien;
            var c = DB.SANPHAMs.Single(x => x.MaSP == a.MaSP);
            c.SoLuongTon += a.SoLuong;
            DB.SubmitChanges();
        }
        public void CapNhapCTPhieuMH(CTPhieuMua_DTO a)
        {
            decimal tamp;
            int tam;
            var b = DB.CTPHIEUMUAs.Single(x => x.SoPhieuMua == a.SoPhieuMua && x.STT==a.STT );
            b.MaSP = a.MaSP;
            b.DonGia = a.DonGia;
            tam = (a.SoLuong - b.SoLuong) ?? default(int);
            b.SoLuong = a.SoLuong;
            tamp =a.ThanhTien- b.ThanhTien??default(decimal);
            b.ThanhTien = a.ThanhTien;
            DB.SubmitChanges();
            var obj = DB.PHIEUMUAHANGs.Single(x => x.SoPhieuMua == a.SoPhieuMua);
            //obj.TongTien = a.TongTien;
            obj.TongTien += tamp;
            var c = DB.SANPHAMs.Single(x => x.MaSP == a.MaSP);
            c.SoLuongTon +=tam;
            DB.SubmitChanges();
        }
        public void XoaCTMuaHang(int sopm,int stt)
        {
            var MyQuery = (from p in DB.CTPHIEUMUAs
                           where p.SoPhieuMua == sopm && p.STT==stt
                           select p).FirstOrDefault();
            var obj = DB.PHIEUMUAHANGs.Single(x => x.SoPhieuMua == sopm);
            obj.TongTien -= MyQuery.ThanhTien;
            var c = DB.SANPHAMs.Single(x => x.MaSP == MyQuery.MaSP);
            c.SoLuongTon -= MyQuery.SoLuong;
            DB.CTPHIEUMUAs.DeleteOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public List<KieuSP_DTO> LayKieuSP()
        {

            var MyQuery = (from pm in DB.KIEUSPs
                           select new KieuSP_DTO
                           {
                              MaKieuSP=pm.MaKieuSP,
                              TenKieuSP=pm.TenKieuSP
                           });

            return MyQuery.ToList();
        }
        public List<LoaiSP_DTO> LayLoaiSP()
        {

            var MyQuery = (from pm in DB.LOAISPs
                           select new LoaiSP_DTO
                           {
                               MaLoaiSP = pm.MaLoaiSP,
                               TenLoaiSP = pm.TenLoaiSP,
                               MaDonViTinh=pm.MaDonViTinh??default(int),
                               PhanTramLoiNhuan=(float)(pm.PhanTramLoiNhuan??default(float))
                           });

            return MyQuery.ToList();
        }
        public int KiemTraSP(int kieusp,int loaisp)
        {
            SANPHAM sp = new SANPHAM();
            sp = DB.SANPHAMs.Where(c => c.MaKieuSP == kieusp && c.MaLoaiSP == loaisp).FirstOrDefault();
            if (sp == null)
                return -1;
            return sp.MaSP;
        }
        public CTPhieuMua_DTO Lay1ChiTiet(int sopm, int stt)
        {
            var MyQuery = (from pm in DB.CTPHIEUMUAs
                           where pm.SoPhieuMua == sopm && pm.STT == stt
                           select new CTPhieuMua_DTO
                           {
                               SoPhieuMua=pm.SoPhieuMua,
                                STT=pm.STT,
                               MaSP=pm.MaSP??default(int),
                               DonGia = pm.DonGia??default(decimal) ,
                               SoLuong = pm.SoLuong ?? default(int),
                               ThanhTien=pm.ThanhTien??default(decimal)
                           });
            return MyQuery.FirstOrDefault();
        }
        public SanPham_DTO Lay1SP(int masp)
        {
            var MyQuery = (from sp in DB.SANPHAMs
                          where sp.MaSP == masp
                           select new SanPham_DTO
                          {
                              MaKieuSP =sp.MaKieuSP??default(int),
                              MaLoaiSP=sp.MaLoaiSP??default(int),
                              TrongLuong=(float)(sp.TrongLuong??default(double)),
                              DonGiaBan=sp.DonGiaBan??default(decimal),
                              SoLuongTon=sp.SoLuongTon??default(int)
                          });
            return MyQuery.FirstOrDefault();
        }
        public List<CTPhieuMua_DTO> Search(CTPhieuMua_DTO a,int loaisp,int kieusp)
        {
            var pmh = DB.CTPhieuMuaSearch(a.SoPhieuMua, a.STT, a.SoLuong, a.DonGia, a.ThanhTien,kieusp,loaisp);
            var MyQuery = (from mh in pmh
                           select new CTPhieuMua_DTO
                           {
                               SoPhieuMua = mh.SoPhieuMua,
                               STT = mh.STT,
                               SoLuong = mh.SoLuong ?? default(int),
                               DonGia = mh.DonGia ?? default(int),
                               ThanhTien = mh.ThanhTien??default(decimal),
                               MaSP = mh.MaSP ?? default(int)
                           });
            return MyQuery.ToList();
        }
    }
}
