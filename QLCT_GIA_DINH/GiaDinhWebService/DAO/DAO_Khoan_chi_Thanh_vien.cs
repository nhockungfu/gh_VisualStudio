using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;

namespace GiaDinhWebService.DAO
{
    public class DAO_Khoan_chi_Thanh_vien : DAO_Toan_cuc
    {
        //Kỹ thuật <Khởi tạo trong kế thừa>
        public DAO_Khoan_chi_Thanh_vien() : base() { }


        //Tạo Node/Element mới
        protected XmlElement Tao_Node_Moi(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            //Khởi tạo node mới
            XmlElement KetQua = doc.CreateElement(Ten_node_Khoan_chi_Thanh_vien);

            //Set thuộc tính cho node đó
            KetQua.SetAttribute("ID", ID.ToString());
            KetQua.SetAttribute("Ngay", Ngay);
            KetQua.SetAttribute("So_tien", So_tien);
            KetQua.SetAttribute("ID_THANH_VIEN", ID_Thanh_vien);

            return KetQua;
        }


        //Thêm một khoản chi mới cho thành viên
        public void Them_moi(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            XmlElement Khoan_chi_Thanh_vien = Tao_Node_Moi(ID,Ngay,So_tien,ID_Thanh_vien);

            root.AppendChild(Khoan_chi_Thanh_vien);//Thêm 1 node vào trong root

            doc.Save(fileXML); //Lưu file XML
        }


        //Sửa thông tin khoản chi đã thêm
        public void Cap_nhat(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            //Thêm '@' đằng trước nếu đó là attribute
            //Thêm "and" nếu tìm kiếm 2 thuộc tính trở lên
            string xPath = "/{0}/{1}[@ID='{2}' and @ID_THANH_VIEN='{3}']";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_chi_Thanh_vien, ID, ID_Thanh_vien);

            XmlNode Khoan_chi_Cu = root.SelectSingleNode(xPath);//Lấy ra một node duy nhất

            if (Khoan_chi_Cu != null)
            {
                XmlElement Khoan_chi_Moi = Tao_Node_Moi(ID, Ngay, So_tien, ID_Thanh_vien);

                root.ReplaceChild(Khoan_chi_Moi, Khoan_chi_Cu); //Thay thế node cũ bằng node mới

                doc.Save(fileXML); //Nhớ lưu file lại
            }
        }


        //Xóa một khoản chi đã có
        public void Xoa(string ID, string ID_Thanh_vien)
        {
            string xPath = "/{0}/{1}[@ID='{2}' and @ID_THANH_VIEN='{3}']";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_chi_Thanh_vien, ID, ID_Thanh_vien);

            XmlNode Khoan_chi_Cu = root.SelectSingleNode(xPath);

            if (Khoan_chi_Cu != null)
            {
                root.RemoveChild(Khoan_chi_Cu); //Xóa node 

                doc.Save(fileXML); //Nhớ lưu
            }
        }


        //Xử lý khác 
        public List<XmlElement> Lay_Danh_Sach_Khoan_chi_Thanh_vien()
        {
            List<XmlElement> List_Khoan_chi_Thanh_vien = new List<XmlElement>();

            string xPath = "/{0}/{1}";

            xPath = string.Format(xPath, Ten_Root, Ten_node_Khoan_chi_Thanh_vien);

            foreach (XmlElement node in root.SelectNodes(xPath))
            {
                List_Khoan_chi_Thanh_vien.Add(node);
            }
            return List_Khoan_chi_Thanh_vien;
        }


        public int ID_Tu_Tang()
        {
            return Lay_ID_Cuoi_Cung(Lay_Danh_Sach_Khoan_chi_Thanh_vien()) + 1;
        }


        //public DataSet Lay_bang_Khoan_chi_Thanh_vien()
        //{
        //    DataSet dtSet = new DataSet();
        //    dtSet = Tao_Bang_Voi_Toan_bo_Du_lieu();

        //    DataTable dtTable = new DataTable();
        //    dtTable = dtSet.Tables[6];

        //    dtSet.Tables.Remove(dtTable);

        //    DataSet ketQua = new DataSet();
        //    ketQua.Tables.Add(dtTable);

        //    return ketQua;
        //}
    }
}