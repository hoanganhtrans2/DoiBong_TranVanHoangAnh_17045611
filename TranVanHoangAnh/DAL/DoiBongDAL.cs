using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Threading.Tasks;

namespace DAL
{
  public  class DoiBongDAL
    {
        DBContextDataContext db;
        public DoiBongDAL()
        {
            db = new DBContextDataContext();
        }
        

        public List<eDoiBong> getAllDoiBong()
        {
            List<eDoiBong> ls = db.tblDoiBongs.Select(doib => new eDoiBong()
            {
                MaDoiBong = doib.IdDoiBong,
                TenDoiBong = doib.TenDoiBong
            }).ToList();
            return ls;
        }
    }
}
