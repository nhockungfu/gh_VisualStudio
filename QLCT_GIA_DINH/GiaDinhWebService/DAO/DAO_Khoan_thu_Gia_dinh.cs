using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace GiaDinhWebService.DAO
{
    public class DAO_Khoan_thu_Gia_dinh : DAO_Toan_cuc
    {
        public DAO_Khoan_thu_Gia_dinh() : base() { }


        //Tạo Node/Element mới
        protected XmlElement Tao_Node_Moi(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            //Khởi tạo node mới
            XmlElement KetQua = doc.CreateElement(Ten_node_Khoan_thu_Gia_dinh);

            //Set thuộc tính cho node đó
            KetQua.SetAttribute("ID", ID);
            KetQua.SetAttribute("Ngay", Ngay);
            KetQua.SetAttribute("So_tien", So_tien);
            KetQua.SetAttribute("ID_GIA_DINH", ID_Gia_dinh);

            return KetQua;
        }


        //Thêm một khoản thu mới cho gia đình
        public void Them_moi(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            XmlElement thuGiaDinh = Tao_Node_Moi(ID, Ngay, So_tien, ID_Gia_dinh);

            root.AppendChild(thuGiaDinh);//Thêm 1 element vào trong root

            doc.Save(fileXML); //Lưu file XML
        }


        //Sửa thông tin khoản chi đã thêm
        public void Cap_nhat(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            //Thêm '@' đằng trước nếu đó là attribute
            //Thêm "and" nếu tìm kiếm 2 thuộc tính trở lên
            string xPath = "/{0}/{1}[@ID='{2}' and @ID_GIA_DINH='{3}']";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_thu_Gia_dinh, ID, ID_Gia_dinh);

            XmlNode Khoan_thu_Cu = root.SelectSingleNode(xPath);//Lấy ra một node duy nhất

            if (Khoan_thu_Cu != null)
            {
                XmlElement Khoan_thu_Moi = Tao_Node_Moi(ID, Ngay, So_tien, ID_Gia_dinh);

                root.ReplaceChild(Khoan_thu_Moi, Khoan_thu_Cu); //Thay thế node cũ bằng node mới

                doc.Save(fileXML); //Nhớ lưu file lại
            }
        }


        //Xóa một khoản chi đã có
        public void Xoa(string ID, string ID_Gia_dinh)
        {
            string xPath = "/{0}/{1}[@ID='{2}' and @ID_GIA_DINH='{3}']";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_thu_Gia_dinh, ID, ID_Gia_dinh);

            XmlNode Khoan_chi_Cu = root.SelectSingleNode(xPath);

            if (Khoan_chi_Cu != null)
            {
                root.RemoveChild(Khoan_chi_Cu); //Xóa node
                doc.Save(fileXML); //Nhớ lưu
            }
        }


        //Xử lý khác 
        public List<XmlElement> Lay_Danh_Sach_Khoan_thu_Gia_dinh()
        {
            List<XmlElement> list_Khoan_thu_Gia_dinh = new List<XmlElement>();

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_thu_Gia_dinh);

            foreach (XmlElement node in root.SelectNodes(xPath))
            {
                list_Khoan_thu_Gia_dinh.Add(node);
            }
            return list_Khoan_thu_Gia_dinh;
        }


        public int ID_Tu_Tang()
        {
            return Lay_ID_Cuoi_Cung(Lay_Danh_Sach_Khoan_thu_Gia_dinh()) + 1;
        }
    }
}
