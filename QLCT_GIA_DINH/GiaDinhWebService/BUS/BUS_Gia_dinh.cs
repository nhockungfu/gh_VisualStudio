using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaDinhWebService.DAO;
using System.Data;


namespace GiaDinhWebService.BUS
{
    public class BUS_Gia_dinh
    {

        protected DAO_Gia_dinh dao = new DAO_Gia_dinh();

        public int ID_Tu_Tang()
        {
            return dao.ID_Tu_Tang();
        }

        public string Lay_ID_Gia_dinh(string Ten_Gia_dinh)
        {
            return dao.Lay_ID_Gia_dinh(Ten_Gia_dinh);
        }

        public DataSet Lay_bang_Gia_dinh()
        {
            return dao.Lay_bang_Gia_dinh();
        }


    }
}