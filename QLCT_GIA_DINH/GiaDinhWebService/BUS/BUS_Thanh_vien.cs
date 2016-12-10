using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaDinhWebService.DAO;

namespace GiaDinhWebService.BUS
{
    public class BUS_Thanh_vien
    {

        protected DAO_Thanh_vien dao = new DAO_Thanh_vien();

        public string Lay_Ten_Thanh_vien(string ID_Thanh_vien)
        {
            return dao.Lay_Ten_Thanh_vien(ID_Thanh_vien);
        }

        public string Lay_ID_Thanh_vien(string Ten_Thanh_vien)
        {
            return dao.Lay_ID_Thanh_vien(Ten_Thanh_vien);
        }

        public List<string> Lay_Ten_Tat_ca_Thanh_vien()
        {
            return dao.Lay_Ten_Tat_ca_Thanh_vien();
        }

        public List<string> Lay_Ten_Va_Ngay_sinh(string Ten_Thanh_vien)
        {
            return dao.Lay_Ten_Va_Ngay_sinh(Ten_Thanh_vien);
        }

    }
}