using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class LoaiDichVu_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public List<LoaiDichVu_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in vbdq.LOAIDICHVUs
                           select new LoaiDichVu_DTO
                           {
                               MaLoaiDV = pbh.MaLoaiDV,
                               TenLoaiDV = pbh.TenLoaiDV,
                               DonGia = Decimal.Parse(pbh.DonGia.ToString())

                           });
            return MyQuery.ToList();
        }
        public String LayKhoaMoi()
        {
            var MyQuery = vbdq.LOAIDICHVUs.
                         OrderBy(o => o.MaLoaiDV).ToList().LastOrDefault();
            if (MyQuery != null)
                return MyQuery.MaLoaiDV.ToString();
            else
                return "0";
        }

        public void LoaiDichVu_Upd(LoaiDichVu_DTO a)
        {
            var obj = vbdq.LOAIDICHVUs.Single(x => x.MaLoaiDV == a.MaLoaiDV);
            obj.TenLoaiDV = a.TenLoaiDV;
            obj.DonGia = a.DonGia;

            vbdq.SubmitChanges();
        }
        public void LoaiDichVu_Add(LoaiDichVu_DTO a)
        {
            LOAIDICHVU b = new LOAIDICHVU();
            b.MaLoaiDV = a.MaLoaiDV;
            b.TenLoaiDV = a.TenLoaiDV;
            b.DonGia = a.DonGia;

            vbdq.LOAIDICHVUs.InsertOnSubmit(b);
            vbdq.SubmitChanges();
        }
        public bool LoaiDichVu_Del(String maloaidv)
        {
            var list = (from phieu in vbdq.CTPHIEUDICHVUs
                        where (phieu.MaLoaiDV == Int16.Parse(maloaidv))
                        select new CTPhieuDichVu_DTO
                        {
                            MaLoaiDV = phieu.MaLoaiDV

                        });
            if (list.ToList().Count != 0)
            {
                return false;
            }

            LOAIDICHVU tho = (from loai in vbdq.LOAIDICHVUs select loai).Single(n => n.MaLoaiDV.CompareTo(maloaidv) == 0);
            vbdq.LOAIDICHVUs.DeleteOnSubmit(tho);
            vbdq.SubmitChanges();
            return true;
        }

        public List<LoaiDichVu_DTO> Search(LoaiDichVu_DTO loaidv)
        {
            var list = (from loaidichvu in vbdq.LOAIDICHVUs
                        where (loaidichvu.MaLoaiDV == loaidv.MaLoaiDV || loaidv.MaLoaiDV == 0) &&
                             (loaidichvu.TenLoaiDV.Contains(loaidv.TenLoaiDV)) &&
                             (loaidichvu.DonGia == loaidv.DonGia || loaidv.DonGia == 0) 
                        select new LoaiDichVu_DTO
                        {
                            MaLoaiDV = loaidichvu.MaLoaiDV,
                            TenLoaiDV = loaidichvu.TenLoaiDV,
                            DonGia = Decimal.Parse(loaidichvu.DonGia.ToString())
                        });
            return list.ToList();

        }
    }
}
