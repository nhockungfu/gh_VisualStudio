using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;

namespace GiaDinhWebService.DAO
{
    public class DAO_Gioi_tinh : DAO_Toan_cuc
    {

        public DAO_Gioi_tinh() : base() { }


        public string Lay_Gioi_tinh(int ID)
        {
            string xPath = "/{0}/{1}[@ID='{2}']";
            xPath = string.Format(xPath, Ten_Root, Ten_node_Gioi_tinh, ID.ToString());

            XmlNode element = root.SelectSingleNode(xPath);

            return element.Attributes["Ten"].Value; //Chú ý: lấy thuộc tính từ xmlNode
        }


        public DataSet Lay_bang_Gioi_tinh()
        {
            DataSet dtSet = new DataSet();
            dtSet = Tao_Bang_Voi_Toan_bo_Du_lieu();

            DataTable dtTable = new DataTable();
            dtTable = dtSet.Tables[0];

            dtSet.Tables.Remove(dtTable);

            DataSet ketQua = new DataSet();
            ketQua.Tables.Add(dtTable);

            return ketQua;
        }
    }
}
