using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class CauThuDAL
    {
        DBContextDataContext db;
        public CauThuDAL()
        {
            db = new DBContextDataContext();
        }

        public List<eCauThu> getAlCauThu()
        {
            List<eCauThu> ls = db.tblCauThus.Select(cc => new eCauThu()
            {
                MaCauThu = cc.MaCauThu,
                TenCauThu = cc.TenCauThu,
                SoDienThoai = cc.SoDienThoai,
                Email = cc.Email,
                MaDoiBong = cc.IdDoiBong
            }).ToList<eCauThu>();

            return ls;
        }
        public List<eCauThu> getAlCauThuTheoMaDoiBong(string id)
        {
            List<eCauThu> ls = db.tblCauThus.Where(x=>x.IdDoiBong==id).Select(cc => new eCauThu()
            {
                MaCauThu = cc.MaCauThu,
                TenCauThu = cc.TenCauThu,
                SoDienThoai = cc.SoDienThoai,
                Email = cc.Email,
                MaDoiBong = cc.IdDoiBong
            }).ToList<eCauThu>();

            return ls;
        }
        public int themThanhVien(eCauThu ct)
        {
            tblCauThu temp = db.tblCauThus.Where(x => x.MaCauThu == ct.MaCauThu).FirstOrDefault();
            if (temp != null) return 0;
            tblCauThu newct = new tblCauThu();
            newct.MaCauThu = ct.MaCauThu;
            newct.TenCauThu = ct.TenCauThu;
            newct.SoDienThoai = ct.SoDienThoai;
            newct.Email = ct.Email;
            newct.IdDoiBong = ct.MaDoiBong;
            db.tblCauThus.InsertOnSubmit(newct);
            db.SubmitChanges();
            return 1;

        }
        public bool XoaCauThu(string ma)
        {
            tblCauThu temp = db.tblCauThus.Where(x => x.MaCauThu == ma).FirstOrDefault();
            try
            {
                db.tblCauThus.DeleteOnSubmit(temp);
            }
            catch (Exception e)
            {

                throw  new Exception("Lỗi không xóa được " + e.Message);
              
            }
            return true;
        }
        public bool suaThongTinCauThu(eCauThu ct)
        {
            tblCauThu nct = db.tblCauThus.Where(x => x.MaCauThu == ct.MaCauThu).FirstOrDefault();
            nct.TenCauThu = ct.TenCauThu;
            nct.SoDienThoai = ct.SoDienThoai;
            nct.Email = ct.Email;
            nct.IdDoiBong = ct.MaDoiBong;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Lỗi không sửa được " + e.Message);
            }
            return true;
        }
    }
}
