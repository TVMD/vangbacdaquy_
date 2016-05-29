using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class CTPhieuDichVu_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public List<CTPhieuDichVu_DTO> LayTatCa(String SoPhieuDV)
        {
            var MyQuery = (from pbh in vbdq.CTPHIEUDICHVUs
                           where pbh.SoPhieuDV.CompareTo(SoPhieuDV) == 0
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

        public void CTPhieuDichVu_Upd(CTPhieuDichVu_DTO pbh)
        {
            var obj = vbdq.CTPHIEUDICHVUs.Single(x => x.SoPhieuDV == pbh.SoPhieuDichVu && x.STT == pbh.STT);

            obj.MaLoaiDV = pbh.MaLoaiDV;
            obj.DonGia = Decimal.Parse(pbh.DonGia.ToString());
            obj.SoLuong = pbh.SoLuong;
            obj.ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString());
            obj.TinhTrang = Int32.Parse(pbh.TinhTrang.ToString());
            obj.NgayGiao = DateTime.Parse(pbh.NgayGiao.ToString());

            vbdq.SubmitChanges();
        }
        public void CTPhieuDichVu_Add(CTPhieuDichVu_DTO pbh)
        {
            CTPHIEUDICHVU obj = new CTPHIEUDICHVU();
            obj.SoPhieuDV = pbh.SoPhieuDichVu;
            obj.STT = pbh.STT;
            obj.MaLoaiDV = pbh.MaLoaiDV;
            obj.DonGia = Decimal.Parse(pbh.DonGia.ToString());
            obj.SoLuong = pbh.SoLuong;
            obj.ThanhTien = Decimal.Parse(pbh.ThanhTien.ToString());
            obj.TinhTrang = Int32.Parse(pbh.TinhTrang.ToString());
            obj.NgayGiao = DateTime.Parse(pbh.NgayGiao.ToString());

            vbdq.CTPHIEUDICHVUs.InsertOnSubmit(obj);
            vbdq.SubmitChanges();
        }
        public void CTPhieuDichVu_Del(String sophieudv, String stt)
        {
            CTPHIEUDICHVU ctphieudv = (from ctphieu in vbdq.CTPHIEUDICHVUs select ctphieu).Single(n => n.SoPhieuDV.CompareTo(sophieudv) == 0 && n.STT.CompareTo(stt) == 0);
            vbdq.CTPHIEUDICHVUs.DeleteOnSubmit(ctphieudv);
            vbdq.SubmitChanges();

        }

    }
}
