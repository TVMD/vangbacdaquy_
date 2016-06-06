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
        
        public BindingList<PhieuBanHang_DTO> Search(int sophieu)
        {
            var myquery = (from x in datacontext.PHIEUBANHANGs.Where(p => p.SoPhieuBan == sophieu)
                   select new PhieuBanHang_DTO
                           {
                               SoPhieuBan = x.SoPhieuBan,
                               MaKH = x.MaKH.GetValueOrDefault(),
                               NgayBan = x.NgayBan.Value.ToShortDateString(),
                               NgayThanhToan = x.NgayThanhToan.Value.ToShortDateString(),
                               TongTien = x.TongTien.GetValueOrDefault(),
                               SoTienTra = x.SoTienTra.GetValueOrDefault()
                           });
            return new BindingList<PhieuBanHang_DTO>(myquery.ToList());
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
            this.Save();
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
            }
            this.Save();
        }
        
        public void Delete(int sophieu)// xóa tất cả chi tiết sau đó xóa phiếu bán
        {
            // xoa chi tiet truoc :: nha'
            var chitiet = datacontext.CTPHIEUBANs.Where(x => x.SoPhieuBan == sophieu);
            foreach (var item in chitiet.ToList())
            {
                //trc khi xóa phải trả số lượng tồn lại
                SANPHAM sp = datacontext.SANPHAMs.Where(x => x.MaSP == item.MaSP).FirstOrDefault();
                sp.SoLuongTon += item.SoLuong;
                //giờ thì xóa chi tiết
                datacontext.CTPHIEUBANs.DeleteOnSubmit(item);
                datacontext.SubmitChanges();
            }

            // giờ thì xóa phiếu bán 
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                datacontext.PHIEUBANHANGs.DeleteOnSubmit(p);
            }
            this.Save();
        }
        
        public void Save()
        {
            try
            {
                datacontext.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        
        public int GetSoPhieu()
        {
            int result = 0;
            try
            {
                var x = (from row in datacontext.PHIEUBANHANGs
                         group row by true into r
                         select new
                         {
                             max = r.Max(z => z.SoPhieuBan)
                         }
                      );
                result = x.ToArray()[0].max + 1;
            }
            catch (Exception) { result = 1; }
            return result;
        }
        
        public void UpdateTongTien(int sophieu, decimal thanhtien)
        {
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                p.TongTien += thanhtien;
            }
            this.Save();
        }
        
        public decimal GetTongTien(int sophieu)
        {
            this.Save();
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                return p.TongTien.Value;
            }
            else return - 1;
        }

        public string GetTenKH(int sophieu)
        {
            String r = "";
            PHIEUBANHANG p = datacontext.PHIEUBANHANGs.Where(x => x.SoPhieuBan == sophieu).FirstOrDefault();
            if (p != null)
            {
                KHACHHANG kh = datacontext.KHACHHANGs.Where(xy => xy.MaKH == p.MaKH).FirstOrDefault();
                r = kh.TenKh;
            }

            return r;
        }
    }

}
