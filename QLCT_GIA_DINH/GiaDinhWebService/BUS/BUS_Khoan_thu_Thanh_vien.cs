using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaDinhWebService.DAO;

namespace GiaDinhWebService.BUS
{
    public class BUS_Khoan_thu_Thanh_vien
    {

        protected DAO_Khoan_thu_Thanh_vien dao = new DAO_Khoan_thu_Thanh_vien();

        public void Them_moi(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            dao.Them_moi(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        public void Cap_nhat(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            dao.Cap_nhat(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        public void Xoa(string ID, string ID_Thanh_vien)
        {
            dao.Xoa(ID, ID_Thanh_vien);
        }

        public int ID_Tu_Tang()
        {
            return dao.ID_Tu_Tang();
        }
    }
}