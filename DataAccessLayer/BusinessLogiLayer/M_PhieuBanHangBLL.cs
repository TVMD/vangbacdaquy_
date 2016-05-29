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
    public class M_PhieuBanHangBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        public BindingList<PhieuBanHang_DTO> SelectTop(int top)
        {

            var MyQuery = (from p in datacontext.PHIEUBANHANGs join kh in datacontext.KHACHHANGs on p.MaKH equals kh.MaKH
                           select new PhieuBanHang_DTO
                           {
                               SoPhieuBan=p.SoPhieuBan,
                               MaKH=p.MaKH.GetValueOrDefault(),
                               TenKh=kh.TenKh,
                               NgayBan= p.NgayBan.GetValueOrDefault().ToShortDateString(),
                               NgayThanhToan = p.NgayThanhToan.GetValueOrDefault().ToShortDateString(),
                               TongTien = p.TongTien.GetValueOrDefault(),
                               SoTienTra = p.SoTienTra.GetValueOrDefault()
                           });
          
            if (top != 0)
            {
                var r = new BindingList<PhieuBanHang_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<PhieuBanHang_DTO>(MyQuery.ToList());
                return r;
            }

        }
        public BindingList<PhieuBanHang_DTO> SelectTop(int sophieu,int top)
        {

            var MyQuery = (from p in datacontext.PHIEUBANHANGs
                           join kh in datacontext.KHACHHANGs on p.MaKH equals kh.MaKH 
                           where(p.SoPhieuBan == sophieu)
                           select new PhieuBanHang_DTO
                           {
                               SoPhieuBan = p.SoPhieuBan,
                               MaKH = p.MaKH.GetValueOrDefault(),
                               TenKh= kh.TenKh,
                               NgayBan = p.NgayBan.GetValueOrDefault().ToShortDateString(),
                               NgayThanhToan = p.NgayThanhToan.GetValueOrDefault().ToShortDateString(),
                               TongTien = p.TongTien.GetValueOrDefault(),
                               SoTienTra = p.SoTienTra.GetValueOrDefault()
                           });
           
            if (top != 0)
            {
                var r = new BindingList<PhieuBanHang_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<PhieuBanHang_DTO>(MyQuery.ToList());
                return r;
            }

        }
        public BindingList<PhieuBanHang_DTO> Search(int sophieu,int makh,string tenkh, string ngayban,
            string ngaythanhtoan,decimal tongtienmin,decimal tongtienmax,decimal sotientramin,decimal sotientramax)
        {
            IEnumerable<MPhieuBanHang_SearchResult> phieuban;
            phieuban = datacontext.MPhieuBanHang_Search(sophieu,makh,
                                tenkh,
                                DateTime.Parse(ngayban),
                                DateTime.Parse(ngaythanhtoan),
                                tongtienmin,tongtienmax,
                                sotientramin,sotientramax
                                );
            var myquery = (from x in phieuban
                           select new PhieuBanHang_DTO
                           {
                               SoPhieuBan = x.SoPhieuBan,
                               MaKH = x.MaKH.GetValueOrDefault(),
                               TenKh=x.TenKh,
                               NgayBan = x.NgayBan.Value.ToShortDateString(),
                               NgayThanhToan = x.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = x.TongTien.GetValueOrDefault(),
                               SoTienTra = x.SoTienTra.GetValueOrDefault()
                           });
            var r = new BindingList<PhieuBanHang_DTO>(myquery.ToList());
            return r;
        }

        public void Insert(int makh, string ngayban,
            string ngaythanhtoan, decimal tongtien, decimal sotientra)
        {
            PHIEUBANHANG p = new PHIEUBANHANG();
            p.SoPhieuBan = GetSoPhieu();
            p.MaKH = makh;
            p.NgayBan = DateTime.Parse(ngayban);
            p.NgayThanhToan = DateTime.Parse(ngaythanhtoan);
            p.TongTien = tongtien;
            p.SoTienTra = sotientra;
            datacontext.PHIEUBANHANGs.InsertOnSubmit(p);
        }

        public void Update(int sophieu,int makh, string ngayban,
            string ngaythanhtoan, decimal tongtien, decimal sotientra)
        {
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                p.MaKH = makh;
                p.NgayBan = DateTime.Parse(ngayban);
                p.NgayThanhToan = DateTime.Parse(ngaythanhtoan);
                p.TongTien = tongtien;
                p.SoTienTra = sotientra;
                datacontext.PHIEUBANHANGs.InsertOnSubmit(p);
            }
        }
        public void Delete(int sophieu)
        {
            // xoa chi tiet truoc :: nha'
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                datacontext.PHIEUBANHANGs.DeleteOnSubmit(p);
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
        public int GetSoPhieu()
        {
            int result = 0;
            var x = (from row in datacontext.PHIEUBANHANGs
                     group row by true into r
                     select new
                     {
                         max = r.Max(z => z.SoPhieuBan)
                     }
                      );
            result = x.ToArray()[0].max + 1;
            return result;
        }
    }
}
