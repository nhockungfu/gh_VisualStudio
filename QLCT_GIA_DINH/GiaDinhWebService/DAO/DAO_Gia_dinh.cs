using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;

namespace GiaDinhWebService.DAO
{
    public class DAO_Gia_dinh : DAO_Toan_cuc
    {

        public DAO_Gia_dinh() : base() { }

        public List<XmlElement> Lay_Danh_Sach_Gia_dinh()
        {
            List<XmlElement> List_Gia_dinh = new List<XmlElement>();

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Gia_dinh);

            foreach (XmlElement node in root.SelectNodes(xPath))
            {
                List_Gia_dinh.Add(node);
            }
            return List_Gia_dinh;
        }

        public int ID_Tu_Tang()
        {
            return Lay_ID_Cuoi_Cung(Lay_Danh_Sach_Gia_dinh()) + 1;
        }

        //Lấy ID gia đình
        public string Lay_ID_Gia_dinh(string Ten_Gia_dinh)
        {
            foreach (XmlElement element in Lay_Danh_Sach_Gia_dinh())
            {
                if (element.GetAttribute("Ten").Contains(Ten_Gia_dinh.Trim()))
                {
                    return element.GetAttribute("ID");
                }
            }

            return string.Empty;
        }

        //Lấy ID gia đình
        public string Lay_Ten_Gia_dinh(string ID = "")
        {
            foreach (XmlElement element in Lay_Danh_Sach_Gia_dinh())
            {
                if(ID != "")
                {
                    if (element.GetAttribute("ID").Contains(ID))
                    {
                        return element.GetAttribute("Ten");
                    }
                }
                else
                    return element.GetAttribute("Ten");

            }

            return string.Empty;
        }

        public DataSet Lay_bang_Gia_dinh()
        {
            DataSet dtSet = new DataSet();
            dtSet = Tao_Bang_Voi_Toan_bo_Du_lieu();

            DataTable dtTable = new DataTable();
            dtTable = dtSet.Tables[1];

            dtSet.Tables.Remove(dtTable);

            DataSet ketQua = new DataSet();
            ketQua.Tables.Add(dtTable);

            return ketQua;
        }
    }
}
