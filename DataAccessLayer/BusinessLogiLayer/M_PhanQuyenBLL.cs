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
    public class M_PhanQuyenBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();

        public BindingList<PhanQuyen_DTO> SelectTop(int top)
        {

            var MyQuery = (from x in datacontext.PHANQUYENs
                           select new PhanQuyen_DTO
                           {
                               Quyen=x.QUYEN,
                               PhieuBan = x.PHIEUBAN.Value,
                               PhieuMua=x.PHIEUMUA.Value,
                               DichVu = x.DICHVU.Value,
                               QuanLy=x.QUANLY.Value,
                               ThuKho=x.THUKHO.Value,

                           });
            if (top != 0)
            {
                var r = new BindingList<PhanQuyen_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<PhanQuyen_DTO>(MyQuery.ToList());
                return r;
            }

        }

        public void Insert(PhanQuyen_DTO x)
        {
            PHANQUYEN phanquyenmoi = new PHANQUYEN(){
                QUYEN =x.Quyen,
                PHIEUMUA=x.PhieuMua,
                PHIEUBAN=x.PhieuBan,
                DICHVU=x.DichVu,
                QUANLY=x.QuanLy,
                THUKHO=x.ThuKho
            };
           
            datacontext.PHANQUYENs.InsertOnSubmit(phanquyenmoi);
            datacontext.SubmitChanges();
        }

        public void Update(PhanQuyen_DTO x)
        {
            datacontext = new VBDQDataContext();
            PHANQUYEN p = datacontext.PHANQUYENs.Where(m => m.QUYEN == x.Quyen).FirstOrDefault();
            if (p != null)
            {
                p.PHIEUMUA=x.PhieuMua;
                p.PHIEUBAN=x.PhieuBan;
                p.DICHVU=x.DichVu;
                p.QUANLY=x.QuanLy;
                p.THUKHO = x.ThuKho;
            }
            datacontext.SubmitChanges();
        }

        public void Delete(string quyen)
        {
            datacontext = new VBDQDataContext();
            PHANQUYEN p = datacontext.PHANQUYENs.Where(m => m.QUYEN == quyen).FirstOrDefault();
            if (p != null)
            {
                datacontext.PHANQUYENs.DeleteOnSubmit(p);
            }
            datacontext.SubmitChanges();
        }

        public PhanQuyen_DTO Get(string quyen)
        {
            PHANQUYEN x = datacontext.PHANQUYENs.Where(m => m.QUYEN == quyen).FirstOrDefault();
            if (x != null)
            {
                return new PhanQuyen_DTO()
                {
                    Quyen = x.QUYEN,
                    PhieuBan = x.PHIEUBAN.Value,
                    PhieuMua = x.PHIEUMUA.Value,
                    DichVu = x.DICHVU.Value,
                    QuanLy = x.QUANLY.Value,
                    ThuKho = x.THUKHO.Value,
                };
            }
            else
                return new PhanQuyen_DTO();
        }

        public Boolean KiemTra(string quyen)
        {
            PHANQUYEN x = datacontext.PHANQUYENs.Where(m => m.QUYEN == quyen).FirstOrDefault();
            if (x != null)
                return false;
            else
                return true;
        }
    }
}
