using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace GiaDinhWebService.DAO
{
    public class DAO_Thanh_vien : DAO_Toan_cuc
    {
        
        public DAO_Thanh_vien() : base() { }


        //Tạo ra danh sách thông tin các thành viên
        public List<XmlElement> Lay_Danh_Sach_Thanh_vien()
        {
            List<XmlElement> thanhVien = new List<XmlElement>();

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Thanh_vien);

            foreach (XmlElement node in root.SelectNodes(xPath))
            {
                thanhVien.Add(node);
            }
            return thanhVien;
        }


        //Lấy tên thành viên
        public string Lay_Ten_Thanh_vien(string ID_Thanh_vien)
        {

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Thanh_vien);

            foreach (XmlElement element in root.SelectNodes(xPath))
            {
                if (element.GetAttribute("ID") == ID_Thanh_vien)
                {
                    return element.GetAttribute("Ho_ten");
                }
            }

            return string.Empty;
        }

        //Lấy ID thành viên
        public string Lay_ID_Thanh_vien(string Ten_Thanh_vien)
        {
            foreach (XmlElement element in Lay_Danh_Sach_Thanh_vien())
            {
                string ten = element.GetAttribute("Ho_ten");
                if (element.GetAttribute("Ho_ten").Contains(Ten_Thanh_vien.Trim()))
                {
                    //return element.GetAttribute("ID");
                    string id = element.GetAttribute("ID");
                    return id;
                }
            }

            return string.Empty;
        }


        public List<string> Lay_Ten_Tat_ca_Thanh_vien()
        {
            List<string> Danh_sach_Ten = new List<string>(new string[] { "", "", "", "" });

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Thanh_vien);

            List<XmlElement> element = new List<XmlElement>();

            foreach (XmlElement Nut in root.SelectNodes(xPath))
            {
                element.Add(Nut);
            }

            if(element.Count >= 1)
                Danh_sach_Ten[0] = element[0].GetAttribute("Ho_ten");
            if(element.Count >= 2)
                Danh_sach_Ten[1] = element[1].GetAttribute("Ho_ten");
            if(element.Count >= 3)
                Danh_sach_Ten[2] = element[2].GetAttribute("Ho_ten");
            if (element.Count >= 4)
                Danh_sach_Ten[3] = element[3].GetAttribute("Ho_ten");
            return Danh_sach_Ten;
        }

        public List<string> Lay_Ten_Va_Ngay_sinh(string Ten_Thanh_vien)
        {
            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Thanh_vien);

            List<XmlElement> element = new List<XmlElement>();

            List<string> ketQua = new List<string>();

            foreach (XmlElement Nut in root.SelectNodes(xPath))
            {
                string e_ten = Nut.GetAttribute("Ho_ten");
                if(e_ten.ToUpper().Contains(Ten_Thanh_vien.ToUpper()))
                {
                    ketQua.Add(Convert.ToDateTime(Nut.GetAttribute("Ngay_sinh")).ToShortDateString());
                    DAO_Gioi_tinh gioi_tinh = new DAO_Gioi_tinh();
                    ketQua.Add(gioi_tinh.Lay_Gioi_tinh(Convert.ToInt32(Nut.GetAttribute("ID_GIOI_TINH"))));
                }
            }

            return ketQua ;
        }

    }
}
