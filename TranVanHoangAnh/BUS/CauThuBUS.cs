using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BUS
{
    public class CauThuBUS
    {
        CauThuDAL ct;
        public CauThuBUS()
        {
            ct = new CauThuDAL();
        }

        public List<eCauThu> getAllCauThu()
        {
            return ct.getAlCauThu();
        }
        public int themThanhVien(eCauThu nct)
        {
            return ct.themThanhVien(nct);
        }
        public bool XoaCauThu(string ma)
        {
            return ct.XoaCauThu(ma);
        }
        public bool suaThongTinCauThu(eCauThu nct)
        {
            return ct.suaThongTinCauThu(nct);
        }
        public List<eCauThu> getAlCauThuTheoMaDoiBong(string id)
        {
            return ct.getAlCauThuTheoMaDoiBong(id);
        }
    }
}
