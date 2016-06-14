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
    public class PhieuDichVu_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public List<PhieuDichVu_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in vbdq.PHIEUDICHVUs join p in vbdq.KHACHHANGs on pbh.MaKH equals p.MaKH
                           select new PhieuDichVu_DTO
                           {
                               SoPhieuDV = pbh.SoPhieuDV,
                               MaKH = pbh.MaKH,
                               TenKH = p.TenKh,
                               NgayDangKy = pbh.NgayDangKy.ToString(),
                               NgayGiao = pbh.NgayGiao.ToString(),
                               DiaChi = pbh.DiaChi,
                               TongTien = Decimal.Parse(pbh.TongTien.ToString()),
                               TinhTrang = Int32.Parse( pbh.TinhTrang.ToString())
                           });
            return MyQuery.ToList();
        }
        public String LayKhoaMoi()
        {
            var MyQuery = vbdq.PHIEUDICHVUs.
                         OrderBy(o => o.SoPhieuDV).ToList().LastOrDefault();
            if (MyQuery != null)
                return MyQuery.SoPhieuDV.ToString();
            else
                return "0";
        }
        public BindingList<KhachHang_DTO> LayDSMaKhachHang()
        {
            var MyQuery = (from pbh in vbdq.KHACHHANGs
                           select new KhachHang_DTO
                           {
                               MaKH = pbh.MaKH,
                               TenKh = pbh.TenKh
                           });


            var r = new BindingList<KhachHang_DTO>(MyQuery.ToList());
            return r;
        }

        public BindingList<KhachHang_DTO> LayDSTenKhachHang()
        {
            var MyQuery = (from pbh in vbdq.KHACHHANGs
                           select new KhachHang_DTO
                           {
                               MaKH = pbh.MaKH,
                               TenKh = pbh.TenKh
                           });


            var r = new BindingList<KhachHang_DTO>(MyQuery.ToList());
            return r;
        }

        public void CapNhatTongTien(int sophieudv, int stt, Decimal tien, int loai)
        {
            var obj = vbdq.PHIEUDICHVUs.Single(x => x.SoPhieuDV == sophieudv);
            var obj_ct = vbdq.CTPHIEUDICHVUs.Single(x => x.SoPhieuDV == sophieudv && x.STT == stt);
            if (loai == 1)                          //them ct
                obj.TongTien += obj_ct.ThanhTien;
            else if (loai == 2)                     //sua ct
                obj.TongTien = obj.TongTien + obj_ct.ThanhTien - tien;
            else obj.TongTien -= obj_ct.ThanhTien;  //xoa ct
            vbdq.SubmitChanges();
        }

        public void PhieuDichVu_Upd(PhieuDichVu_DTO pbh)
        {
            var obj = vbdq.PHIEUDICHVUs.Single(x => x.SoPhieuDV == pbh.SoPhieuDV);

            obj.MaKH = pbh.MaKH;
            obj.NgayDangKy = DateTime.Parse( pbh.NgayDangKy.ToString());
            obj.NgayGiao = DateTime.Parse(pbh.NgayGiao.ToString());
            obj.DiaChi = pbh.DiaChi;
            obj.TongTien = Decimal.Parse(pbh.TongTien.ToString());
            obj.TinhTrang = Int32.Parse(pbh.TinhTrang.ToString());

            vbdq.SubmitChanges();
        }
        public void PhieuDichVu_Add(PhieuDichVu_DTO pbh)
        {
            PHIEUDICHVU obj = new PHIEUDICHVU();
            obj.SoPhieuDV = pbh.SoPhieuDV;
            obj.MaKH = pbh.MaKH;
            obj.NgayDangKy = DateTime.Parse(pbh.NgayDangKy.ToString());
            obj.NgayGiao = DateTime.Parse(pbh.NgayGiao.ToString());
            obj.DiaChi = pbh.DiaChi;
            obj.TongTien = Decimal.Parse(pbh.TongTien.ToString());
            obj.TinhTrang = Int16.Parse(pbh.TinhTrang.ToString());

            vbdq.PHIEUDICHVUs.InsertOnSubmit(obj);
            vbdq.SubmitChanges();
        }
        public void PhieuDichVu_Del(String sophieudv)
        {
            PHIEUDICHVU phieudv = (from phieu in vbdq.PHIEUDICHVUs select phieu).Single(n => n.SoPhieuDV.CompareTo(sophieudv) == 0);

            var list = (from ctphieu in vbdq.CTPHIEUDICHVUs
                        where (ctphieu.SoPhieuDV == phieudv.SoPhieuDV)
                        select ctphieu);
            foreach (CTPHIEUDICHVU phieu in list)
            {
                vbdq.CTPHIEUDICHVUs.DeleteOnSubmit(phieu);
            }

            vbdq.PHIEUDICHVUs.DeleteOnSubmit(phieudv);
            vbdq.SubmitChanges();

        }
        public List<PhieuDichVu_DTO> Search(PhieuDichVu_DTO phieu)
        {
            var list = (from phieudv in vbdq.PHIEUDICHVUs join p in vbdq.KHACHHANGs on phieudv.MaKH equals p.MaKH
                        where (phieudv.SoPhieuDV == phieu.SoPhieuDV || phieu.SoPhieuDV == 0) &&
                             (phieudv.MaKH == phieu.MaKH || phieu.MaKH == 0) &&
                             (p.TenKh.Contains(phieu.TenKH)) &&
                             (phieudv.DiaChi.Contains(phieu.DiaChi)) &&
                             (phieudv.TongTien == phieu.TongTien || phieu.TongTien == 0) 
                        select new PhieuDichVu_DTO
                        {
                            SoPhieuDV = phieudv.SoPhieuDV,
                            MaKH = phieudv.MaKH,
                            TenKH = p.TenKh,
                            NgayDangKy = phieudv.NgayDangKy.ToString(),
                            NgayGiao = phieudv.NgayGiao.ToString(),
                            DiaChi = phieudv.DiaChi,
                            TongTien = Decimal.Parse(phieudv.TongTien.ToString()),
                            TinhTrang = Int32.Parse(phieudv.TinhTrang.ToString())

                        });
            return list.ToList();

        }
    }
}
