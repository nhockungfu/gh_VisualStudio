using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaDinhWebService.DAO;

namespace GiaDinhWebService.BUS
{
    public class BUS_Khoan_thu_Gia_dinh
    {
        //Tao doi tuong khoan thu gia dinh
        protected DAO_Khoan_thu_Gia_dinh dao = new DAO_Khoan_thu_Gia_dinh();

        public void Them_moi(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            dao.Them_moi(ID, Ngay, So_tien, ID_Gia_dinh);
        }

        public void Cap_nhat(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            dao.Cap_nhat(ID, Ngay, So_tien, ID_Gia_dinh);
        }

        public void Xoa(string ID, string ID_Gia_dinh)
        {
            dao.Xoa(ID, ID_Gia_dinh);
        }

        public int ID_Tu_Tang()
        {
            return dao.ID_Tu_Tang();
        }
    }
}