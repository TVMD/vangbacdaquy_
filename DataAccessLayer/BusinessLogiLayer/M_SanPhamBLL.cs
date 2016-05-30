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
    }
}
