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
    public class M_SanPhamBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        public BindingList<SanPham_DTO> SelectTop(int top)
        {

            var MyQuery = (from sp in datacontext.SANPHAMs
                           select new SanPham_DTO
                           {
                               MaSP=sp.MaSP,
                               MaLoaiSP=sp.MaLoaiSP.GetValueOrDefault(),
                               MaKieuSP=sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong=float.Parse(sp.TrongLuong.GetValueOrDefault().ToString()),
                               DonGiaBan=sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon=sp.SoLuongTon.GetValueOrDefault()

                           });
            if (top != 0)
            {
                var r = new BindingList<SanPham_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<SanPham_DTO>(MyQuery.ToList());
                return r;
            }

        }

        public decimal GetGia(int masp)
        {
            var MyQuery = (from sp in datacontext.SANPHAMs.Where(x=>x.MaSP==masp)
                           select new SanPham_DTO
                           {
                               MaSP = sp.MaSP,
                               MaLoaiSP = sp.MaLoaiSP.GetValueOrDefault(),
                               MaKieuSP = sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong = float.Parse(sp.TrongLuong.GetValueOrDefault().ToString()),
                               DonGiaBan = sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon = sp.SoLuongTon.GetValueOrDefault()

                           });
            return MyQuery.First().DonGiaBan;
        }

        public decimal GetSLTon(int masp)
        {
            var MyQuery = (from sp in datacontext.SANPHAMs.Where(x => x.MaSP == masp)
                           select new SanPham_DTO
                           {
                               MaSP = sp.MaSP,
                               MaLoaiSP = sp.MaLoaiSP.GetValueOrDefault(),
                               MaKieuSP = sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong = float.Parse(sp.TrongLuong.GetValueOrDefault().ToString()),
                               DonGiaBan = sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon = sp.SoLuongTon.GetValueOrDefault()

                           });
            return MyQuery.First().SoLuongTon;
        }

        public void Update(int masp, int soluongban)
        {
            SANPHAM p = datacontext.SANPHAMs.Where(x => x.MaSP == masp).FirstOrDefault();
            if (p != null)
            {
                p.SoLuongTon -= soluongban;
            }
            datacontext.SubmitChanges();
        }
        public List<SanPham_DTO> LaySP()
        {

            var MyQuery = (from sp in datacontext.SANPHAMs
                           join lo in datacontext.LOAISPs
                           on sp.MaLoaiSP equals lo.MaLoaiSP
                           join k in datacontext.KIEUSPs
                           on sp.MaKieuSP equals k.MaKieuSP
                           join dv in datacontext.DONVITINHs
                           on lo.MaDonViTinh equals dv.MaDonViTinh
                           select new SanPham_DTO
                           {
                               MaLoaiSP = sp.MaLoaiSP.GetValueOrDefault(),
                               TenLoaiSP = lo.TenLoaiSP,
                               MaSP=sp.MaSP,
                               MaKieuSP=sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong=(float)sp.TrongLuong.GetValueOrDefault(),
                               DonGiaBan=sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon=sp.SoLuongTon.GetValueOrDefault(),
                               TenKieuSP=k.TenKieuSP,
                               TenDonViTinh=dv.TenDonViTinh
                           });

            return MyQuery.ToList();
        }
        public void XoaSP(int masp)
        {
            var MyQuery = (from p in datacontext.SANPHAMs
                           where p.MaSP == masp
                           select p).FirstOrDefault();
            datacontext.SANPHAMs.DeleteOnSubmit(MyQuery);
            datacontext.SubmitChanges();
        }
        public SanPham_DTO Lay1LSP(int masp)
        {

            var MyQuery = (from sp in datacontext.SANPHAMs
                           join lo in datacontext.LOAISPs
                           on sp.MaLoaiSP equals lo.MaLoaiSP
                           join k in datacontext.KIEUSPs
                           on sp.MaKieuSP equals k.MaKieuSP
                           
                           join dv in datacontext.DONVITINHs
                           on lo.MaDonViTinh equals dv.MaDonViTinh
                           where sp.MaSP == masp
                           select new SanPham_DTO
                           {
                               MaLoaiSP = sp.MaLoaiSP.GetValueOrDefault(),
                               TenLoaiSP = lo.TenLoaiSP,
                               MaSP = sp.MaSP,
                               MaKieuSP = sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong = (float)sp.TrongLuong.GetValueOrDefault(),
                               DonGiaBan = sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon = sp.SoLuongTon.GetValueOrDefault(),
                               TenKieuSP = k.TenKieuSP,
                               TenDonViTinh=dv.TenDonViTinh
                           }).FirstOrDefault();

            return MyQuery;
        }
        public void ThemSP(SanPham_DTO a)
        {
            SANPHAM b = new SANPHAM();
            b.MaLoaiSP = a.MaLoaiSP;
            b.MaKieuSP = a.MaKieuSP;
            b.TrongLuong = a.TrongLuong;
            b.DonGiaBan = a.DonGiaBan;
            b.SoLuongTon = 0;
            datacontext.SANPHAMs.InsertOnSubmit(b);
            datacontext.SubmitChanges();
        }
        public void CapNhapSP(SanPham_DTO a)
        {
            var b = datacontext.SANPHAMs.Single(x => x.MaSP == a.MaSP);
            //b.TenKieuSP = a.TenKieuSP;
            b.MaLoaiSP = a.MaLoaiSP;
            b.MaKieuSP = a.MaKieuSP;
            b.TrongLuong = a.TrongLuong;
            b.DonGiaBan = a.DonGiaBan;
            //b.SoLuongTon = a.SoLuongTon;
            datacontext.SubmitChanges();
        }
        public int KiemTraSP(int kieusp, int loaisp)
        {
            //SANPHAM sp = new SANPHAM();
            var sp = datacontext.SANPHAMs.Where(c => c.MaKieuSP == kieusp && c.MaLoaiSP == loaisp);
            
            return sp.Count();
        }
        public List<SanPham_DTO> Search(SanPham_DTO a,int slmin,int slmax,int dongiamin,int dongiamax, int trongluongmin, int trongluongmax)
        {
            var pmh = datacontext.SanPham_Search(a.MaSP,a.MaLoaiSP,a.MaKieuSP,slmin, slmax, dongiamin, dongiamax,  trongluongmin,  trongluongmax);
            var MyQuery = (from sp in pmh
                           join lo in datacontext.LOAISPs
                           on sp.MaLoaiSP equals lo.MaLoaiSP
                           join k in datacontext.KIEUSPs
                           on sp.MaKieuSP equals k.MaKieuSP
                           join dv in datacontext.DONVITINHs
                           on lo.MaDonViTinh equals dv.MaDonViTinh
                           select new SanPham_DTO
                           {
                               MaLoaiSP = sp.MaLoaiSP.GetValueOrDefault(),
                               TenLoaiSP = lo.TenLoaiSP,
                               MaSP = sp.MaSP,
                               MaKieuSP = sp.MaKieuSP.GetValueOrDefault(),
                               TrongLuong = (float)sp.TrongLuong.GetValueOrDefault(),
                               DonGiaBan = sp.DonGiaBan.GetValueOrDefault(),
                               SoLuongTon = sp.SoLuongTon.GetValueOrDefault(),
                               TenKieuSP = k.TenKieuSP,
                               TenDonViTinh = dv.TenDonViTinh
                           });
           
            return MyQuery.ToList();
        }
    }
}
