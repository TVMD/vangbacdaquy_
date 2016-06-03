using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogiLayer
{
    public class CTPhieuGiaCong_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public List<CTGiaCong_DTO> LayTatCa(String sophieugc)
        {
            var MyQuery = (from pbh in vbdq.CTGIACONGs
                           where pbh.SoPhieuGiaCong.CompareTo(sophieugc) == 0
                           select new CTGiaCong_DTO                           
                           {
                               SoPhieuGiaCong = pbh.SoPhieuGiaCong,
                               SoPhieuDV = pbh.SoPhieuDV,
                               STT = pbh.STT,
                               SoLuong = Int32.Parse(pbh.SoLuong.ToString()),
                               DonGia = Decimal.Parse(pbh.DonGia.ToString()),
                               ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString()),
                               MaTho = pbh.MaTho
                           });
            return MyQuery.ToList();
        }
        
        public List<CTPhieuDichVu_DTO> LayDSDichVuChuaGiaCong()
        {
            var MyQuery = (from pbh in vbdq.CTPHIEUDICHVUs
                           where pbh.TinhTrang == 0
                           select new CTPhieuDichVu_DTO
                           {
                               SoPhieuDichVu = pbh.SoPhieuDV,
                               STT = pbh.STT,
                               MaLoaiDV = pbh.MaLoaiDV,
                               DonGia = Decimal.Parse(pbh.DonGia.ToString()),
                               SoLuong = Int32.Parse(pbh.SoLuong.ToString()),
                               ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString()),
                               NgayGiao = pbh.NgayGiao.ToString(),
                               TinhTrang = Int32.Parse(pbh.TinhTrang.ToString())
                           });
            return MyQuery.ToList();
        }
        public BindingList<ThoGiaCong_DTO> LayDSMaTho()
        {
            var MyQuery = (from pbh in vbdq.THOGIACONGs
                           select new ThoGiaCong_DTO
                           {
                               MaTho = pbh.MaTho,
                               TenTho = pbh.TenTho
                           });

            
                var r = new BindingList<ThoGiaCong_DTO>(MyQuery.ToList());
                return r;            
        }
        public void CapNhatTongTien(int sophieugc, int sophieudv, int stt, Decimal tien, int loai)
        {
            var obj = vbdq.PHIEUGIACONGs.Single(x => x.SoPhieuGiaCong == sophieugc);
            var obj_ct = vbdq.CTGIACONGs.Single(x => x.SoPhieuGiaCong == sophieugc && x.SoPhieuDV == sophieudv && x.STT == stt);
            if (loai == 1)                          //them ct
                obj.TongTien += obj_ct.ThanhTien;
            else if (loai == 2)                     //sua ct
                obj.TongTien = obj_ct.ThanhTien + obj.TongTien - tien;
            else obj.TongTien -= obj_ct.ThanhTien;  //xoa ct
            vbdq.SubmitChanges();
        }

        public void CTPhieuGiaCong_Upd(CTGiaCong_DTO pbh)
        {
            var obj = vbdq.CTGIACONGs.Single(x => x.SoPhieuGiaCong == pbh.SoPhieuGiaCong && x.SoPhieuDV == pbh.SoPhieuDV && x.STT == pbh.STT);

            obj.SoLuong = pbh.SoLuong;
            obj.DonGia = pbh.DonGia;
            obj.ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString());
            obj.MaTho = pbh.MaTho;

            vbdq.SubmitChanges();
        }
        public void CTPhieuGiaCong_Add(CTGiaCong_DTO pbh)
        {
            CTGIACONG obj = new CTGIACONG();
            obj.SoPhieuGiaCong = pbh.SoPhieuGiaCong;
            obj.SoPhieuDV = pbh.SoPhieuDV;
            obj.STT = pbh.STT;
            obj.SoLuong = pbh.SoLuong;
            obj.DonGia = pbh.DonGia;
            obj.ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString());
            obj.MaTho = pbh.MaTho;

            vbdq.CTGIACONGs.InsertOnSubmit(obj);

            //update tinh trang cho phieu dv
            var phieudv = vbdq.CTPHIEUDICHVUs.Single(x => x.STT == pbh.STT && x.SoPhieuDV == pbh.SoPhieuDV);
            phieudv.TinhTrang = 1;

            vbdq.SubmitChanges();
        }
        public void CTPhieuGiaCong_Del(String sophieugc, String sophieudv, String stt)
        {
            CTGIACONG phieugc = (from phieu in vbdq.CTGIACONGs select phieu).Single(n => 
                                                    n.SoPhieuDV.CompareTo(sophieudv) == 0 && 
                                                    n.SoPhieuGiaCong.CompareTo(sophieugc) == 0 && 
                                                    n.STT.CompareTo(stt) == 0);
            vbdq.CTGIACONGs.DeleteOnSubmit(phieugc);
            vbdq.SubmitChanges();

        }
    }
}
