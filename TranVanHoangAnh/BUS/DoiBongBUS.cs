using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BUS
{
  public  class DoiBongBUS
    {
        DoiBongDAL db;
        public DoiBongBUS()
        {
            db = new DoiBongDAL();
        }
        public List<eDoiBong> getAllDoiBong()
        {
            return db.getAllDoiBong();
        }
    }
}
