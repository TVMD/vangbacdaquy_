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
    public class M_CTPhieuBanBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        M_PhieuBanHangBLL PhieuBan = new M_PhieuBanHangBLL();
        M_SanPhamBLL SanPham = new M_SanPhamBLL();
        public BindingList<CTPhieuBan_DTO> SelectTop(int top)
        {

            var MyQuery = (from x in datacontext.CTPHIEUBANs
                           select new CTPhieuBan_DTO
                           {
                               SoPhieuBan = x.SoPhieuBan,
                               MaSP = x.MaSP,
                               SoLuong = x.SoLuong.GetValueOrDefault(),
                               DonGia=x.DonGia.GetValueOrDefault(),
                               ThanhTien=x.ThanhTien.GetValueOrDefault()
                           });
            if (top != 0)
            {
                var r = new BindingList<CTPhieuBan_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<CTPhieuBan_DTO>(MyQuery.ToList());
                return r;
            }

        }
        public BindingList<CTPhieuBan_DTO> SelectTop(int sophieu,int top)
        {

            var MyQuery = (from x in datacontext.CTPHIEUBANs.Where(p=> p.SoPhieuBan==sophieu)
                           select new CTPhieuBan_DTO
                           {
                               SoPhieuBan = x.SoPhieuBan,
                               MaSP = x.MaSP,
                               SoLuong = x.SoLuong.GetValueOrDefault(),
                               DonGia = x.DonGia.GetValueOrDefault(),
                               ThanhTien = x.ThanhTien.GetValueOrDefault()
                           });
            if (top != 0)
            {
                var r = new BindingList<CTPhieuBan_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<CTPhieuBan_DTO>(MyQuery.ToList());
                return r;
            }

        }
        public BindingList<CTPhieuBan_DTO> Search(int sophieu, int masp,
            int slmin, int slmax, decimal dongiamin,decimal dongiamax, decimal thanhtienmin,decimal thanhtienmax)
        {
            IEnumerable<MCT_PhieuBanHanh_SearchResult> ct;
            ct = datacontext.MCT_PhieuBanHanh_Search(sophieu,
                                 masp,
                                 slmin,slmax,
                                 dongiamin,dongiamax,
                                 thanhtienmin,thanhtienmax
                                 );
            var myquery = (from x in ct
                           select new CTPhieuBan_DTO
                           {
                               SoPhieuBan=x.SoPhieuBan,
                               MaSP=x.MaSP,
                               SoLuong=x.SoLuong.GetValueOrDefault(),
                               DonGia=x.DonGia.GetValueOrDefault(),
                               ThanhTien=x.ThanhTien.GetValueOrDefault()
                           });
            var r = new BindingList<CTPhieuBan_DTO>(myquery.ToList());
            return r;
        }

        public void Insert(int sophieu, int masp,
            int sl, decimal dongia,decimal thanhtien)
        {
            var r = datacontext.CTPHIEUBANs.Where(p => p.MaSP == masp && p.SoPhieuBan == sophieu).FirstOrDefault();
            if (r != null) // da ton tai thi cap nhat so luong // update
            {
                r.SoLuong += sl;
                r.ThanhTien += thanhtien;
                
                SanPham.Update(masp, sl); // cap nhat so luongton
                PhieuBan.UpdateTongTien(r.SoPhieuBan,thanhtien); // cap nhat tongtien

                datacontext.SubmitChanges();
            }
            else // them moi
            {
                CTPHIEUBAN ct = new CTPHIEUBAN();
                ct.SoPhieuBan = sophieu;
                ct.MaSP = masp;
                ct.SoLuong = sl;
                ct.DonGia = dongia;
                ct.ThanhTien = thanhtien;
                datacontext.CTPHIEUBANs.InsertOnSubmit(ct);
                
                datacontext.SubmitChanges();

                PhieuBan.UpdateTongTien(ct.SoPhieuBan, ct.ThanhTien.Value);    //cap nhat tong tien
                SanPham.Update(ct.MaSP, sl); // cap nhat so luong ton
            }
            
        }

        public void Update(int sophieu, int masp,
            int sl, decimal dongia, decimal thanhtien)
        {
            CTPHIEUBAN ct = datacontext.CTPHIEUBANs.Where(p => (p.SoPhieuBan == sophieu && p.MaSP ==masp)).FirstOrDefault();
            if (ct != null)
            {
                PhieuBan.UpdateTongTien(ct.SoPhieuBan, -ct.ThanhTien.Value);    //cap nhat tong tien
                SanPham.Update(ct.MaSP, -ct.SoLuong.Value); // cap nhat so luong ton
                
                ct.SoLuong = sl;
                ct.DonGia = dongia;
                ct.ThanhTien = thanhtien;

                PhieuBan.UpdateTongTien(ct.SoPhieuBan,thanhtien);    //cap nhat tong tien
                SanPham.Update(ct.MaSP, sl); // cap nhat so luong ton

                datacontext.SubmitChanges();
            }
        }
        public void Delete(int sophieu,int masp)
        {
            CTPHIEUBAN ct = datacontext.CTPHIEUBANs.Where(p => (p.SoPhieuBan == sophieu && p.MaSP == masp)).FirstOrDefault();
            if (ct != null)
            {
                PhieuBan.UpdateTongTien(ct.SoPhieuBan, -ct.ThanhTien.Value);    //cap nhat tong tien
                SanPham.Update(ct.MaSP, -ct.SoLuong.Value); // cap nhat so luong ton

                datacontext.CTPHIEUBANs.DeleteOnSubmit(ct);
                datacontext.SubmitChanges();
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
       
    }
}
