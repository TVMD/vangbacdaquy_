using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class ChiTietPhieuNhap_BUS
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<CTPhieuNhap_DTO> LayChiTiet(int sopn)
        {

            var MyQuery = (from pm in DB.CTPHIEUNHAPs
                           join sp in DB.SANPHAMs 
                           on pm.MaSP equals sp.MaSP                           
                           where pm.SoPhieuNhap == sopn
                           select new CTPhieuNhap_DTO
                           {
                               SoPhieuNhap=sopn,
                               MaSP=pm.MaSP,
                               SLNhap=pm.SLNhap??default(int),
                               DonGia=pm.DonGia??default(decimal),
                               ThanhTien = pm.ThanhTien ?? default(decimal),
                               TenKieuSP=sp.KIEUSP.TenKieuSP,
                               TenLoaiSP=sp.LOAISP.TenLoaiSP,
                               MaKieuSP = sp.MaKieuSP ?? default(int),
                               MaLoaiSP = sp.MaLoaiSP ?? default(int)
                           });

            //var MyQuery = (from pbh in DB.PHIEUMUAHANGs select new PHIEUMUAHANG {}
            //return DB.PHIEUMUAHANGs.ToList();
            return MyQuery.ToList();
        }
        public void ThemChiTietNhap(CTPhieuNhap_DTO a)
        {
            CTPHIEUNHAP b = new CTPHIEUNHAP();
            b.ThanhTien = a.ThanhTien;
            b.SoPhieuNhap = a.SoPhieuNhap;
            b.SLNhap = a.SLNhap;
            b.MaSP = a.MaSP;
            b.DonGia = a.DonGia;
            DB.CTPHIEUNHAPs.InsertOnSubmit(b);
            var obj = DB.PHIEUNHAPs.Single(x => x.SoPhieuNhap == a.SoPhieuNhap);
            obj.TongTien += a.ThanhTien;
            var c = DB.SANPHAMs.Single(x => x.MaSP == a.MaSP);
            c.SoLuongTon += a.SLNhap;
            //obj.NgayLap = DateTime.Parse(a.NgayLap);
            //DB.SubmitChanges();
            DB.SubmitChanges();
        }
        public void CapNhapCTPhieuNhap(CTPhieuNhap_DTO a)
        {
            decimal tamp;
            int tam;
            var b = DB.CTPHIEUNHAPs.Single(x => x.SoPhieuNhap == a.SoPhieuNhap && x.MaSP == a.MaSP);
            b.MaSP = a.MaSP;
            b.DonGia = a.DonGia;
            tam = (a.SLNhap - b.SLNhap) ?? default(int);
            b.SLNhap = a.SLNhap;
            tamp = (a.ThanhTien - b.ThanhTien)??default(decimal);
            b.ThanhTien = a.ThanhTien;
            b.SoPhieuNhap = a.SoPhieuNhap;
            var obj = DB.PHIEUNHAPs.Single(x => x.SoPhieuNhap == a.SoPhieuNhap);
            obj.TongTien += tamp;
            var c = DB.SANPHAMs.Single(x => x.MaSP == a.MaSP);
            c.SoLuongTon += tam;
            DB.SubmitChanges();
        }
        public void XoaCTNhap(int sopm, int masp)
        {
            var MyQuery = (from p in DB.CTPHIEUNHAPs
                           where p.SoPhieuNhap == sopm && p.MaSP == masp
                           select p).FirstOrDefault();
            var obj = DB.PHIEUNHAPs.Single(x => x.SoPhieuNhap == sopm);
            obj.TongTien -= MyQuery.ThanhTien;
            var c = DB.SANPHAMs.Single(x => x.MaSP == MyQuery.MaSP);
            c.SoLuongTon -= MyQuery.SLNhap;
            DB.CTPHIEUNHAPs.DeleteOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public List<CTPhieuNhap_DTO> Search(CTPhieuNhap_DTO a, int kieusp, int loaisp)
        {
            var pmh = DB.CTPhieuNhapSearch(a.SoPhieuNhap, a.SLNhap, a.DonGia, a.ThanhTien, kieusp, loaisp);
            var MyQuery = (from pm in pmh
                           select new CTPhieuNhap_DTO
                           {
                               SoPhieuNhap = pm.SoPhieuNhap,
                               MaSP = pm.MaSP,
                               SLNhap = pm.SLNhap ?? default(int),
                               DonGia = pm.DonGia ?? default(decimal),
                               ThanhTien = pm.ThanhTien ?? default(decimal),
                               TenKieuSP = pm.TenKieuSP,
                               TenLoaiSP = pm.TenLoaiSP,
                               MaKieuSP = pm.MaKieuSP ?? default(int),
                               MaLoaiSP = pm.MaLoaiSP ?? default(int)
                           });
            return MyQuery.ToList();
        }
    }
}
