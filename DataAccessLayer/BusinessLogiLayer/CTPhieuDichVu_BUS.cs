using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
using System.ComponentModel;

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
        public String LayKhoaMoi()
        {
            var MyQuery = vbdq.CTPHIEUDICHVUs.
                         OrderBy(o => o.STT).ToList().LastOrDefault();
            if (MyQuery != null)
                return MyQuery.STT.ToString();
            else
                return "0";
        }
        public String LayDonGiaLoaiDV(String maloaidv)
        {
            var MyQuery = vbdq.LOAIDICHVUs.Where(o => maloaidv.CompareTo(o.MaLoaiDV.ToString()) == 0).ToList().FirstOrDefault();
            if (MyQuery != null)
            {
                String dongia = MyQuery.DonGia.ToString();
                return dongia;
            }
            else return "";
            
        }
        public BindingList<LoaiDichVu_DTO> LayDSMaLoaiDV()
        {
            var MyQuery = (from pbh in vbdq.LOAIDICHVUs
                           select new LoaiDichVu_DTO
                           {
                               MaLoaiDV = pbh.MaLoaiDV,
                               TenLoaiDV = pbh.TenLoaiDV
                           });


            var r = new BindingList<LoaiDichVu_DTO>(MyQuery.ToList());
            return r;
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
