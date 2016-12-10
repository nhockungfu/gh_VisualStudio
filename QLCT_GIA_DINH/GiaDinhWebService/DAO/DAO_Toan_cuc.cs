using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;
using System.Web.Hosting;
using System.IO;

namespace GiaDinhWebService.DAO
{
    public class DAO_Toan_cuc
    {

        protected static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
        protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Project.Parent;

        protected static string Thu_muc_Du_lieu = Thu_muc_Solution.FullName + @"\DuLieu";
        protected static string Thu_muc_XML = Thu_muc_Du_lieu + @"\XML";
        protected static string Thu_muc_Hinh_anh = Thu_muc_Du_lieu + @"\AnhThanhVien";

        protected string fileXML;
        protected static XmlDocument doc;
        protected static XmlElement root;

        protected string Ten_Root = "CNXML_SV_QLGD_2_Cach_2";
        protected string Ten_node_Khoan_chi_Gia_dinh = "KHOAN_CHI_GIA_DINH";
        protected string Ten_node_Khoan_thu_Gia_dinh = "KHOAN_THU_GIA_DINH";
        protected string Ten_node_Khoan_chi_Thanh_vien = "KHOAN_CHI_THANH_VIEN";
        protected string Ten_node_Khoan_thu_Thanh_vien = "KHOAN_THU_THANH_VIEN";
        protected string Ten_node_Gioi_tinh = "GIOI_TINH";
        protected string Ten_node_Thanh_vien = "THANH_VIEN";
        protected string Ten_node_Gia_dinh = "GIA_DINH";

        protected const int THEM = 1;
        protected const int XOA = 2;
        protected const int CAP_NHAT = 3;


        //protected const string TEN_GIA_DINH = "Gia đình Hai Lúa";
        //protected const string TEN_THANH_VIEN_A = "Nguyễn thị bé Lớn";
        //protected const string TEN_THANH_VIEN_B = "Lê văn bé Nhỏ";
        //protected const string TEN_THANH_VIEN_C = "Lê thị bé Xíu";
        //protected const string TEN_THANH_VIEN_D = "Lê văn bé Bé";

        public DAO_Toan_cuc() //Nhớ để public
        {
            fileXML = Thu_muc_XML + @"\DuLieu.xml";

            doc = new XmlDocument();

            doc.Load(fileXML);

            root = doc.DocumentElement;
        }

        public List<string> Lay_Danh_sach_Ten()
        {
            DAO_Thanh_vien tv = new DAO.DAO_Thanh_vien();
            DAO_Gia_dinh gd = new DAO_Gia_dinh();

            List<string> ds_ten = tv.Lay_Ten_Tat_ca_Thanh_vien();
            string ten_gia_dinh = gd.Lay_Ten_Gia_dinh();

            ds_ten.Add(ten_gia_dinh);

            return ds_ten;
        }

        public DataSet Tao_Bang_Voi_Toan_bo_Du_lieu()
        {
            DataSet ketQua = new DataSet();

            ketQua.ReadXml(fileXML);

            return ketQua;
        }


        protected int Lay_ID_Cuoi_Cung(List<XmlElement> list)
        {
            string ketQua = list[list.Count - 1].GetAttribute("ID");
            return Convert.ToInt32(ketQua);
        }


        public DataSet Tao_bang_Quan_ly_Chi()
        {
            DAO_Khoan_chi_Gia_dinh mChiGiaDinh = new DAO.DAO_Khoan_chi_Gia_dinh();
            DAO_Khoan_chi_Thanh_vien mChiThanhVien = new DAO.DAO_Khoan_chi_Thanh_vien();
            DAO_Gia_dinh mGiaDinh = new DAO_Gia_dinh();
            DAO_Thanh_vien mThanhVien = new DAO_Thanh_vien();

            List<XmlElement> ds_Chi_Gia_dinh = mChiGiaDinh.Lay_Danh_Sach_Khoan_chi_Gia_dinh();
            List<XmlElement> ds_Chi_Thanh_vien = mChiThanhVien.Lay_Danh_Sach_Khoan_chi_Thanh_vien();

            DataTable table = new DataTable();
            table.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("Thanh_vien");
            table.Columns.Add("So_tien");
            table.Columns.Add("Ngay");
            table.Columns.Add("Loai_chi");

            foreach (XmlElement Nut in ds_Chi_Gia_dinh)
            {
                DataRow row = table.NewRow();

                row["ID"] = Nut.GetAttribute("ID");
                row["Thanh_vien"] = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                row["So_tien"] = Nut.GetAttribute("So_tien");
                row["Ngay"] = Nut.GetAttribute("Ngay");
                row["Loai_chi"] = "Chung";

                table.Rows.Add(row);
            }

            foreach (XmlElement Nut in ds_Chi_Thanh_vien)
            {
                DataRow row = table.NewRow();

                row["ID"] = Nut.GetAttribute("ID");
                row["Thanh_vien"] = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                row["So_tien"] = Nut.GetAttribute("So_tien");
                row["Ngay"] = Nut.GetAttribute("Ngay");
                row["Loai_chi"] = "Riêng";

                table.Rows.Add(row);
            }

            DataSet Du_lieu_Ket_qua = new DataSet();
            Du_lieu_Ket_qua.Tables.Add(table);

            return Du_lieu_Ket_qua;
        }

        public DataSet Tao_bang_Quan_ly_Thu()
        {
            DAO_Khoan_thu_Gia_dinh mThuGiaDinh = new DAO.DAO_Khoan_thu_Gia_dinh();
            DAO_Khoan_thu_Thanh_vien mThuThanhVien = new DAO.DAO_Khoan_thu_Thanh_vien();
            DAO_Gia_dinh mGiaDinh = new DAO_Gia_dinh();
            DAO_Thanh_vien mThanhVien = new DAO_Thanh_vien();

            List<XmlElement> ds_Thu_Gia_dinh = mThuGiaDinh.Lay_Danh_Sach_Khoan_thu_Gia_dinh();
            List<XmlElement> ds_Thu_Thanh_vien = mThuThanhVien.Lay_Danh_Sach_Khoan_thu_Thanh_vien();

            DataTable table = new DataTable();
            table.Clear();
            table.Columns.Add("ID");
            table.Columns.Add("Thanh_vien");
            table.Columns.Add("So_tien");
            table.Columns.Add("Ngay");
            table.Columns.Add("Loai_Thu");

            foreach (XmlElement Nut in ds_Thu_Gia_dinh)
            {
                DataRow row = table.NewRow();

                row["ID"] = Nut.GetAttribute("ID");
                row["Thanh_vien"] = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                row["So_tien"] = Nut.GetAttribute("So_tien");
                row["Ngay"] = Nut.GetAttribute("Ngay");
                row["Loai_thu"] = "Chung";

                table.Rows.Add(row);
            }

            foreach (XmlElement Nut in ds_Thu_Thanh_vien)
            {
                DataRow row = table.NewRow();

                row["ID"] = Nut.GetAttribute("ID");
                row["Thanh_vien"] = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                row["So_tien"] = Nut.GetAttribute("So_tien");
                row["Ngay"] = Nut.GetAttribute("Ngay");
                row["Loai_thu"] = "Riêng";

                table.Rows.Add(row);
            }

            DataSet Du_lieu_Ket_qua = new DataSet();
            Du_lieu_Ket_qua.Tables.Add(table);

            return Du_lieu_Ket_qua;
        }

        //public DataSet Tao_bang_Tra_cuu_Chi_tieu()
        //{
        //    DAO_Khoan_thu_Gia_dinh mThuGiaDinh = new DAO.DAO_Khoan_thu_Gia_dinh();
        //    DAO_Khoan_thu_Thanh_vien mThuThanhVien = new DAO.DAO_Khoan_thu_Thanh_vien();
        //    DAO_Khoan_chi_Gia_dinh mChiGiaDinh = new DAO.DAO_Khoan_chi_Gia_dinh();
        //    DAO_Khoan_chi_Thanh_vien mChiThanhVien = new DAO.DAO_Khoan_chi_Thanh_vien();
        //    DAO_Gia_dinh mGiaDinh = new DAO_Gia_dinh();
        //    DAO_Thanh_vien mThanhVien = new DAO_Thanh_vien();

        //    List<XmlElement> ds_Thu_Gia_dinh = mThuGiaDinh.Lay_Danh_Sach_Khoan_thu_Gia_dinh();
        //    List<XmlElement> ds_Thu_Thanh_vien = mThuThanhVien.Lay_Danh_Sach_Khoan_thu_Thanh_vien();
        //    List<XmlElement> ds_Chi_Gia_dinh = mChiGiaDinh.Lay_Danh_Sach_Khoan_chi_Gia_dinh();
        //    List<XmlElement> ds_Chi_Thanh_vien = mChiThanhVien.Lay_Danh_Sach_Khoan_chi_Thanh_vien();

        //    DataTable table = new DataTable();
        //    table.Clear();
        //    table.Columns.Add("ID");
        //    table.Columns.Add("Thanh_vien");
        //    table.Columns.Add("Hinh_thuc");
        //    table.Columns.Add("Loai_Thu_Chi");
        //    table.Columns.Add("Ngay");
        //    table.Columns.Add("So_tien");

        //    foreach (XmlElement Nut in ds_Thu_Gia_dinh)
        //    {
        //        DataRow row = table.NewRow();

        //        row["ID"] = Nut.GetAttribute("ID");
        //        row["Thanh_vien"] = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
        //        row["Hinh_thuc"] = "Thu";
        //        row["Loai_Thu_Chi"] = "Chung";
        //        row["Ngay"] = Nut.GetAttribute("Ngay");
        //        row["So_tien"] = Nut.GetAttribute("So_tien");

        //        table.Rows.Add(row);
        //    }

        //    foreach (XmlElement Nut in ds_Thu_Thanh_vien)
        //    {
        //        DataRow row = table.NewRow();

        //        row["ID"] = Nut.GetAttribute("ID");
        //        row["Thanh_vien"] = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
        //        row["Hinh_thuc"] = "Thu";
        //        row["Loai_Thu_Chi"] = "Riêng";
        //        row["Ngay"] = Nut.GetAttribute("Ngay");
        //        row["So_tien"] = Nut.GetAttribute("So_tien");

        //        table.Rows.Add(row);
        //    }

        //    foreach (XmlElement Nut in ds_Chi_Gia_dinh)
        //    {
        //        DataRow row = table.NewRow();

        //        row["ID"] = Nut.GetAttribute("ID");
        //        row["Thanh_vien"] = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
        //        row["Hinh_thuc"] = "Chi";
        //        row["Loai_Thu_Chi"] = "Chung";
        //        row["Ngay"] = Nut.GetAttribute("Ngay");
        //        row["So_tien"] = Nut.GetAttribute("So_tien");

        //        table.Rows.Add(row);
        //    }

        //    foreach (XmlElement Nut in ds_Chi_Thanh_vien)
        //    {
        //        DataRow row = table.NewRow();

        //        row["ID"] = Nut.GetAttribute("ID");
        //        row["Thanh_vien"] = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
        //        row["Hinh_thuc"] = "Chi";
        //        row["Loai_Thu_Chi"] = "Riêng";
        //        row["Ngay"] = Nut.GetAttribute("Ngay");
        //        row["So_tien"] = Nut.GetAttribute("So_tien");

        //        table.Rows.Add(row);
        //    }

        //    DataSet Du_lieu_Ket_qua = new DataSet();
        //    Du_lieu_Ket_qua.Tables.Add(table);

        //    return Du_lieu_Ket_qua;
        //}


        ///----////////////////////////////////////////TẠO DANH SÁCH PHỤ TRA CỨU/////////////////////////////////////////////////////////////

        //lọc danh sách các khoản thu của thành viên theo tên
        protected List<XmlElement> Tao_Danh_Sach_Khoan_Thu_Thanh_vien_Theo_Ten(string Ten_Tra_cuu)
        {
            DAO_Khoan_thu_Thanh_vien mThuThanhVien = new DAO.DAO_Khoan_thu_Thanh_vien();
            DAO_Thanh_vien mThanhVien = new DAO_Thanh_vien();

            List<XmlElement> ds_Thu_Thanh_vien = mThuThanhVien.Lay_Danh_Sach_Khoan_thu_Thanh_vien();

            List<XmlElement> DS_Thu_Thanh_vien = new List<XmlElement>();

            foreach (XmlElement Nut in ds_Thu_Thanh_vien)
            {
                string Ten = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                if (Ten.ToUpper().Contains(Ten_Tra_cuu.Trim().ToUpper()))
                {
                    DS_Thu_Thanh_vien.Add(Nut);
                }
            }

            return DS_Thu_Thanh_vien;
        }

        //lọc danh sách các khoản chi của thành viên theo tên
        protected List<XmlElement> Tao_Danh_Sach_Khoan_Chi_Thanh_vien_Theo_Ten(string Ten_Tra_cuu)
        {
            DAO_Khoan_chi_Thanh_vien mChiThanhVien = new DAO.DAO_Khoan_chi_Thanh_vien();
            DAO_Thanh_vien mThanhVien = new DAO_Thanh_vien();

            List<XmlElement> ds_Chi_Thanh_vien = mChiThanhVien.Lay_Danh_Sach_Khoan_chi_Thanh_vien();

            List<XmlElement> DS_Chi_Thanh_vien = new List<XmlElement>();

            foreach (XmlElement Nut in ds_Chi_Thanh_vien)
            {
                string Ten = mThanhVien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                if (Ten.ToUpper().Contains(Ten_Tra_cuu.Trim().ToUpper()))
                {
                    DS_Chi_Thanh_vien.Add(Nut);
                }
            }

            return DS_Chi_Thanh_vien;
        }

        //lọc danh sách các khoản chi chung theo tên
        protected List<XmlElement> Tao_Danh_Sach_Khoan_Chi_Gia_dinh_Theo_Ten(string Ten_Tra_cuu)
        {
            DAO_Khoan_chi_Gia_dinh mChiGiaDinh = new DAO.DAO_Khoan_chi_Gia_dinh();
            DAO_Gia_dinh mGiaDinh = new DAO_Gia_dinh();

            List<XmlElement> ds_Chi_Gia_dinh = mChiGiaDinh.Lay_Danh_Sach_Khoan_chi_Gia_dinh();

            List<XmlElement> ds_ket_qua = new List<XmlElement>();

            foreach (XmlElement Nut in ds_Chi_Gia_dinh)
            {
                string Ten = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                if (Ten.ToUpper().Contains(Ten_Tra_cuu.Trim().ToUpper()))
                {
                    ds_ket_qua.Add(Nut);
                }
            }

            return ds_ket_qua;
        }

        //lọc danh sách các khoản thu chung theo tên
        protected List<XmlElement> Tao_Danh_Sach_Khoan_Thu_Gia_dinh_Theo_Ten(string Ten_Tra_cuu)
        {
            DAO_Khoan_thu_Gia_dinh mThuGiaDinh = new DAO.DAO_Khoan_thu_Gia_dinh();
            DAO_Gia_dinh mGiaDinh = new DAO_Gia_dinh();

            List<XmlElement> ds_Thu_Gia_dinh = mThuGiaDinh.Lay_Danh_Sach_Khoan_thu_Gia_dinh();

            List<XmlElement> DS_Thu_Gia_dinh = new List<XmlElement>();

            foreach (XmlElement Nut in ds_Thu_Gia_dinh)
            {
                string Ten = mGiaDinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                if (Ten.ToUpper().Contains(Ten_Tra_cuu.Trim().ToUpper()))
                {
                    DS_Thu_Gia_dinh.Add(Nut);
                }
            }

            return DS_Thu_Gia_dinh;
        }

        //lọc danh sách theo ngày dựa vào danh sách đã có
        protected List<XmlElement> Tra_cuu_Theo_Ngay(List<XmlElement> List_Element, string Ngay_Tra_cuu)
        {
            List<XmlElement> ketQua = new List<XmlElement>();

            if (Ngay_Tra_cuu != string.Empty)
            {
                foreach (XmlElement Nut in List_Element)
                {
                    if (Nut.GetAttribute("Ngay").Contains(Ngay_Tra_cuu.Trim()))
                    {
                        ketQua.Add(Nut);
                    }
                }
            }
            else
            {
                ketQua = List_Element;
            }

            return ketQua;
        }

        //lọc danh sách theo số tiền dựa vào danh sách đã có
        protected List<XmlElement> Tra_cuu_Theo_So_tien(List<XmlElement> List_Element, string So_tien_Tra_cuu)
        {
            List<XmlElement> ketQua = new List<XmlElement>();

            if(So_tien_Tra_cuu !=string.Empty)
            {
                foreach (XmlElement Nut in List_Element)
                {
                    int so_tien_trong_bang = Convert.ToInt32(Nut.GetAttribute("So_tien"));
                    int so_tien = Convert.ToInt32(So_tien_Tra_cuu);

                    if (so_tien_trong_bang == so_tien)
                    {
                        ketQua.Add(Nut);
                    }
                }
            }
            else
            {
                ketQua = List_Element;
            }
            return ketQua;
        }


        //----/////////////////////////////////////// BẮT ĐẦU TRA CỨU//////////////////////////////////////

        //danh sách tra cứu các khoản thu của thành viên (theo Tên/Ngày/Số tiền)
        protected List<XmlElement> Tra_cuu_Khoan_Thu_Thanh_vien(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            List<XmlElement> ds_thu = Tao_Danh_Sach_Khoan_Thu_Thanh_vien_Theo_Ten(Ten);
            List<XmlElement> tra_cuu_theo_ngay = Tra_cuu_Theo_Ngay(ds_thu, Ngay);
            List<XmlElement> tra_cuu_theo_so_tien = Tra_cuu_Theo_So_tien(tra_cuu_theo_ngay, So_tien);
            return tra_cuu_theo_so_tien;
        }

        //danh sách tra cứu các khoản chi của thành viên (theo Tên/Ngày/Số tiền)
        protected List<XmlElement> Tra_cuu_Khoan_Chi_Thanh_vien(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            List<XmlElement> ds_thu_chi = Tao_Danh_Sach_Khoan_Chi_Thanh_vien_Theo_Ten(Ten);
            List<XmlElement> tra_cuu_theo_ngay = Tra_cuu_Theo_Ngay(ds_thu_chi, Ngay);
            List<XmlElement> tra_cuu_theo_so_tien = Tra_cuu_Theo_So_tien(tra_cuu_theo_ngay, So_tien);
            return tra_cuu_theo_so_tien;
        }

        protected List<XmlElement> Tra_cuu_Khoan_Thu_Gia_dinh(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            List<XmlElement> ds_dau_thu_theo_ten = Tao_Danh_Sach_Khoan_Thu_Gia_dinh_Theo_Ten(Ten);
            List<XmlElement> tra_cuu_theo_ngay = Tra_cuu_Theo_Ngay(ds_dau_thu_theo_ten, Ngay);
            List<XmlElement> tra_cuu_theo_so_tien = Tra_cuu_Theo_So_tien(tra_cuu_theo_ngay, So_tien);
            return tra_cuu_theo_so_tien;
        }

        protected List<XmlElement> Tra_cuu_Khoan_Chi_Gia_dinh(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            List<XmlElement> ds_dau_thu_chi_theo_ten = Tao_Danh_Sach_Khoan_Chi_Gia_dinh_Theo_Ten(Ten);
            List<XmlElement> tra_cuu_theo_ngay = Tra_cuu_Theo_Ngay(ds_dau_thu_chi_theo_ten, Ngay);
            List<XmlElement> tra_cuu_theo_so_tien = Tra_cuu_Theo_So_tien(tra_cuu_theo_ngay, So_tien);
            return tra_cuu_theo_so_tien;
        }

        public DataSet Tra_cuu_Thu_Chi(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            DAO_Gia_dinh m_gia_dinh = new DAO_Gia_dinh();
            DAO_Thanh_vien m_thanh_vien = new DAO_Thanh_vien();


            DataTable table = new DataTable();
            table.Clear();

            table.Columns.Add("ID");
            table.Columns.Add("Ten");
            table.Columns.Add("Hinh_thuc");
            table.Columns.Add("Loai_Chi_tieu");
            table.Columns.Add("Ngay");
            table.Columns.Add("So_tien");


            List<XmlElement> ds_tra_cuu_theo_ten = new List<XmlElement>();

            if(Loai_Thu_Chi == "Riêng")
            {
                List<XmlElement> danh_sach_chi_thanh_vien = Tra_cuu_Khoan_Chi_Thanh_vien(Ten, Ngay, So_tien, Loai_Thu_Chi);

                foreach (XmlElement Nut in danh_sach_chi_thanh_vien)
                {
                    DataRow row = table.NewRow();

                    row["ID"] = Nut.GetAttribute("ID");
                    row["Ten"] =m_thanh_vien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                    row["Hinh_thuc"] = "Chi";
                    row["Loai_Chi_tieu"] = "Riêng";
                    row["Ngay"] = Nut.GetAttribute("Ngay");
                    row["So_tien"] = Nut.GetAttribute("So_tien");

                    table.Rows.Add(row);
                }

                List<XmlElement> danh_sach_thu_thanh_vien = Tra_cuu_Khoan_Thu_Thanh_vien(Ten, Ngay, So_tien, Loai_Thu_Chi);

                foreach (XmlElement Nut in danh_sach_thu_thanh_vien)
                {
                    DataRow row = table.NewRow();

                    row["ID"] = Nut.GetAttribute("ID");
                    row["Ten"] = m_thanh_vien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                    row["Hinh_thuc"] = "Thu";
                    row["Loai_Chi_tieu"] = "Riêng";
                    row["Ngay"] = Nut.GetAttribute("Ngay");
                    row["So_tien"] = Nut.GetAttribute("So_tien");

                    table.Rows.Add(row);
                }
            }
            else
            {
                List<XmlElement> danh_sach_thu_gia_dinh = Tra_cuu_Khoan_Thu_Gia_dinh(Ten, Ngay, So_tien, Loai_Thu_Chi);

                foreach (XmlElement Nut in danh_sach_thu_gia_dinh)
                {
                    DataRow row = table.NewRow();

                    row["ID"] = Nut.GetAttribute("ID");
                    row["Ten"] = m_gia_dinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                    row["Hinh_thuc"] = "Thu";
                    row["Loai_Chi_tieu"] = "Chung";
                    row["Ngay"] = Nut.GetAttribute("Ngay");
                    row["So_tien"] = Nut.GetAttribute("So_tien");

                    table.Rows.Add(row);
                }

                List<XmlElement> danh_sach_chi_gia_dinh = Tra_cuu_Khoan_Chi_Gia_dinh(Ten, Ngay, So_tien, Loai_Thu_Chi);

                foreach (XmlElement Nut in danh_sach_chi_gia_dinh)
                {
                    DataRow row = table.NewRow();

                    row["ID"] = Nut.GetAttribute("ID");
                    row["Ten"] = m_gia_dinh.Lay_Ten_Gia_dinh(Nut.GetAttribute("ID_GIA_DINH"));
                    row["Hinh_thuc"] = "Chi";
                    row["Loai_Chi_tieu"] = "Chung";
                    row["Ngay"] = Nut.GetAttribute("Ngay");
                    row["So_tien"] = Nut.GetAttribute("So_tien");

                    table.Rows.Add(row);
                }
            }

            DataSet Du_lieu_Ket_qua = new DataSet();
            Du_lieu_Ket_qua.Tables.Add(table);

            return Du_lieu_Ket_qua;
        }

        //---/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //hàm phụ cho hàm Lay_Cac_Nam()
        protected List<int> Lay_Cac_Nam_Tu_Danh_Sach(List<int> list, List<XmlElement> danh_sach)
        {
            List<int> ds_nam = list;

            foreach (XmlElement nut in danh_sach)
            {
                DateTime Ngay = Convert.ToDateTime(nut.GetAttribute("Ngay"));

                if (ds_nam.Count == 0)
                    ds_nam.Add(Ngay.Year);
                else
                {
                    bool da_co = false;
                    foreach (int nam in ds_nam)
                    {
                        if (Ngay.Year == nam)
                        {
                            da_co = true;
                            break;
                        }
                    }
                    if (da_co == false)
                        ds_nam.Add(Ngay.Year);
                }
            }

            return ds_nam;
        }

        //lấy những năm đã có trong dữ liệu
        public List<int> Lay_Cac_Nam()
        {
            DAO_Khoan_thu_Gia_dinh mThuGiaDinh = new DAO.DAO_Khoan_thu_Gia_dinh();
            DAO_Khoan_thu_Thanh_vien mThuThanhVien = new DAO.DAO_Khoan_thu_Thanh_vien();
            DAO_Khoan_chi_Gia_dinh mChiGiaDinh = new DAO.DAO_Khoan_chi_Gia_dinh();
            DAO_Khoan_chi_Thanh_vien mChiThanhVien = new DAO.DAO_Khoan_chi_Thanh_vien();

            List<XmlElement> ds_Chi_Gia_dinh = mChiGiaDinh.Lay_Danh_Sach_Khoan_chi_Gia_dinh();
            List<XmlElement> ds_Chi_Thanh_vien = mChiThanhVien.Lay_Danh_Sach_Khoan_chi_Thanh_vien();
            List<XmlElement> ds_Thu_Gia_dinh = mThuGiaDinh.Lay_Danh_Sach_Khoan_thu_Gia_dinh();
            List<XmlElement> ds_Thu_Thanh_vien = mThuThanhVien.Lay_Danh_Sach_Khoan_thu_Thanh_vien();

            List<int> ds_nam = new List<int>();

            ds_nam = Lay_Cac_Nam_Tu_Danh_Sach(ds_nam, ds_Chi_Gia_dinh);
            ds_nam = Lay_Cac_Nam_Tu_Danh_Sach(ds_nam, ds_Chi_Thanh_vien);
            ds_nam = Lay_Cac_Nam_Tu_Danh_Sach(ds_nam, ds_Thu_Gia_dinh);
            ds_nam = Lay_Cac_Nam_Tu_Danh_Sach(ds_nam, ds_Thu_Thanh_vien);

            ds_nam.Sort(); //sắp xếp tăng
            ds_nam.Reverse(); ; //đổi lại
            return ds_nam;
        }

        //---/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        // thu->chi->chênh lệch
        public List<int> Thong_ke_Theo_Loai_Va_Ten(string Loai_Chung_Rieng, string Ten_Thanh_vien, string Thang, string Nam, string Ngay = "", string So_tien = "")
        {
            int tong_thu = 0;
            int tong_chi = 0;
            int tong_chenh_lech = 0;

            DataTable Bang_Thu_Chi = new DataTable();
            Bang_Thu_Chi = Tra_cuu_Thu_Chi(Ten_Thanh_vien, Ngay, So_tien, Loai_Chung_Rieng).Tables[0];

            for (int i = 0; i < Bang_Thu_Chi.Rows.Count; i++)
            {
                DataRow dongHienTai = Bang_Thu_Chi.Rows[i];

                bool dk_ten = dongHienTai["Ten"].ToString().ToUpper() == Ten_Thanh_vien.ToUpper().Trim();
                DateTime thoi_gian = Convert.ToDateTime(dongHienTai["Ngay"]);
                bool dk_thang = thoi_gian.Month.ToString() == Thang;
                bool dk_nam = thoi_gian.Year.ToString() == Nam;

                if (dk_ten && dk_thang && dk_nam)
                {
                    string hinh_thuc = dongHienTai["Hinh_thuc"].ToString(); //loại (thu | chi)
                    if(hinh_thuc == "Thu")
                    {
                        tong_thu += Convert.ToInt32(dongHienTai["So_tien"]);
                    }
                    else //hinh_thuc == "Chi"
                    {
                        tong_chi += Convert.ToInt32(dongHienTai["So_tien"]);
                    }
                }
            }

            tong_chenh_lech = tong_thu - tong_chi;

            List<int> ketQua = new List<int>();
            ketQua.Add(tong_thu);
            ketQua.Add(tong_chi);
            ketQua.Add(tong_chenh_lech);

            return ketQua;
        }

        //xuất ra chuỗi thống kê tổng quát
        //public List<int> xxxxxThong_ke_Tong_Quat(string Thang, string Nam)
        //{
        //    List<int> thong_ke_nhan_vien_A = Thong_ke_Theo_Loai_Va_Ten("Riêng", TEN_THANH_VIEN_A, Thang, Nam);
        //    List<int> thong_ke_nhan_vien_B = Thong_ke_Theo_Loai_Va_Ten("Riêng", TEN_THANH_VIEN_B, Thang, Nam);
        //    List<int> thong_ke_nhan_vien_C = Thong_ke_Theo_Loai_Va_Ten("Riêng", TEN_THANH_VIEN_C, Thang, Nam);
        //    List<int> thong_ke_nhan_vien_D = Thong_ke_Theo_Loai_Va_Ten("Riêng", TEN_THANH_VIEN_D, Thang, Nam);
        //    List<int> thong_ke_Gia_dinh = Thong_ke_Theo_Loai_Va_Ten("Chung", TEN_GIA_DINH, Thang, Nam);

        //    List<int> ketQuaThongKe = new List<int>();

        //    //thống kê nhân viên A
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_A[0]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_A[1]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_A[2]);

        //    //thống kê nhân viên B
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_B[0]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_B[1]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_B[2]);

        //    //thống kê nhân viên C
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_C[0]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_C[1]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_C[2]);

        //    //thống kê nhân viên D
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_D[0]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_D[1]);
        //    ketQuaThongKe.Add(thong_ke_nhan_vien_D[2]);

        //    //thống kê GIA ĐÌNH
        //    ketQuaThongKe.Add(thong_ke_Gia_dinh[0]);
        //    ketQuaThongKe.Add(thong_ke_Gia_dinh[1]);
        //    ketQuaThongKe.Add(thong_ke_Gia_dinh[2]);

        //    return ketQuaThongKe;
        //}

        //xuất ra chuỗi thống kê tổng quát

        public List<int> Thong_ke_Tong_Quat(string Thang, string Nam)
        {
            List<string> ds_ten = Lay_Danh_sach_Ten();

            List<int> thong_ke_nhan_vien_A = new List<int>(new int[] { 0, 0, 0, 0 });
            List<int> thong_ke_nhan_vien_B = new List<int>(new int[] { 0, 0, 0, 0 });
            List<int> thong_ke_nhan_vien_C = new List<int>(new int[] { 0, 0, 0, 0 });
            List<int> thong_ke_nhan_vien_D = new List<int>(new int[] { 0, 0, 0, 0 });
            List<int> thong_ke_Gia_dinh = new List<int>(new int[] { 0, 0, 0, 0 });


            DAO_Khoan_thu_Thanh_vien DS_Thu_Thanh_vien = new DAO.DAO_Khoan_thu_Thanh_vien();
            DAO_Khoan_chi_Thanh_vien DS_Chi_Thanh_vien = new DAO.DAO_Khoan_chi_Thanh_vien();
            DAO_Khoan_thu_Gia_dinh DS_Thu_Gia_dinh = new DAO.DAO_Khoan_thu_Gia_dinh();
            DAO_Khoan_chi_Gia_dinh DS_Chi_Gia_dinh = new DAO.DAO_Khoan_chi_Gia_dinh();
            DAO_Thanh_vien Doi_tuong_Thanh_vien = new DAO_Thanh_vien();
            DAO_Gia_dinh Doi_tuong_Gia_dinh = new DAO_Gia_dinh();

            List<XmlElement> Thanh_vien_Thu = DS_Thu_Thanh_vien.Lay_Danh_Sach_Khoan_thu_Thanh_vien();

            foreach (XmlElement Nut in Thanh_vien_Thu)
            {
                DateTime thoi_gian = Convert.ToDateTime(Nut.GetAttribute("Ngay"));
                string _Thang = thoi_gian.Month.ToString();
                string _Nam = thoi_gian.Year.ToString();
                if(_Thang == Thang && _Nam == Nam)
                {
                    string Ten = Doi_tuong_Thanh_vien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                    int So_tien = Convert.ToInt32(Nut.GetAttribute("So_tien"));

                    if (Ten == ds_ten[0])
                        thong_ke_nhan_vien_A[0] += So_tien;
                    if (Ten == ds_ten[1])
                        thong_ke_nhan_vien_B[0] += So_tien;
                    if (Ten == ds_ten[2])
                        thong_ke_nhan_vien_C[0] += So_tien;
                    if (Ten == ds_ten[3])
                        thong_ke_nhan_vien_D[0] += So_tien;
                }

            }

            List<XmlElement> Thanh_vien_Chi = DS_Chi_Thanh_vien.Lay_Danh_Sach_Khoan_chi_Thanh_vien();

            foreach (XmlElement Nut in Thanh_vien_Chi)
            {
                DateTime thoi_gian = Convert.ToDateTime(Nut.GetAttribute("Ngay"));
                string _Thang = thoi_gian.Month.ToString();
                string _Nam = thoi_gian.Year.ToString();
                if (_Thang == Thang && _Nam == Nam)
                {
                    string Ten = Doi_tuong_Thanh_vien.Lay_Ten_Thanh_vien(Nut.GetAttribute("ID_THANH_VIEN"));
                    int So_tien = Convert.ToInt32(Nut.GetAttribute("So_tien"));

                    if (Ten == ds_ten[0])
                        thong_ke_nhan_vien_A[1] += So_tien;
                    if (Ten == ds_ten[1])
                        thong_ke_nhan_vien_B[1] += So_tien;
                    if (Ten == ds_ten[2])
                        thong_ke_nhan_vien_C[1] += So_tien;
                    if (Ten == ds_ten[3])
                        thong_ke_nhan_vien_D[1] += So_tien;
                }


            }

            List<XmlElement> Gia_dinh_Thu = DS_Thu_Gia_dinh.Lay_Danh_Sach_Khoan_thu_Gia_dinh();

            foreach (XmlElement Nut in Gia_dinh_Thu)
            {
                DateTime thoi_gian = Convert.ToDateTime(Nut.GetAttribute("Ngay"));
                string _Thang = thoi_gian.Month.ToString();
                string _Nam = thoi_gian.Year.ToString();
                if (_Thang == Thang && _Nam == Nam)
                {
                    int So_tien = Convert.ToInt32(Nut.GetAttribute("So_tien"));
                    thong_ke_Gia_dinh[0] += So_tien;
                }
            }

            List<XmlElement> Gia_dinh_Chi = DS_Chi_Gia_dinh.Lay_Danh_Sach_Khoan_chi_Gia_dinh();

            foreach (XmlElement Nut in Gia_dinh_Chi)
            {
                DateTime thoi_gian = Convert.ToDateTime(Nut.GetAttribute("Ngay"));
                string _Thang = thoi_gian.Month.ToString();
                string _Nam = thoi_gian.Year.ToString();
                if (_Thang == Thang && _Nam == Nam)
                {
                    int So_tien = Convert.ToInt32(Nut.GetAttribute("So_tien"));
                    thong_ke_Gia_dinh[1] += So_tien;
                }
            }

            thong_ke_Gia_dinh[2] = thong_ke_Gia_dinh[0] - thong_ke_Gia_dinh[1];
            thong_ke_nhan_vien_A[2] = thong_ke_nhan_vien_A[0] - thong_ke_nhan_vien_A[1];
            thong_ke_nhan_vien_B[2] = thong_ke_nhan_vien_B[0] - thong_ke_nhan_vien_B[1];
            thong_ke_nhan_vien_C[2] = thong_ke_nhan_vien_C[0] - thong_ke_nhan_vien_C[1];
            thong_ke_nhan_vien_D[2] = thong_ke_nhan_vien_D[0] - thong_ke_nhan_vien_D[1];


            List<int> ketQuaThongKe = new List<int>();

            //thống kê nhân viên A
            ketQuaThongKe.Add(thong_ke_nhan_vien_A[0]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_A[1]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_A[2]);

            //thống kê nhân viên B
            ketQuaThongKe.Add(thong_ke_nhan_vien_B[0]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_B[1]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_B[2]);

            //thống kê nhân viên C
            ketQuaThongKe.Add(thong_ke_nhan_vien_C[0]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_C[1]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_C[2]);

            //thống kê nhân viên D
            ketQuaThongKe.Add(thong_ke_nhan_vien_D[0]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_D[1]);
            ketQuaThongKe.Add(thong_ke_nhan_vien_D[2]);

            //thống kê GIA ĐÌNH
            ketQuaThongKe.Add(thong_ke_Gia_dinh[0]);
            ketQuaThongKe.Add(thong_ke_Gia_dinh[1]);
            ketQuaThongKe.Add(thong_ke_Gia_dinh[2]);

            return ketQuaThongKe;
        }


        public byte[] Doc_Hinh(string Ma_so)
        {
            byte[] Kq = new byte[] { };
            string Duong_dan_Hinh = Thu_muc_Hinh_anh + @"\" + Ma_so + ".png";
            try
            {
                Kq = File.ReadAllBytes(Duong_dan_Hinh);
            }
            catch
            {
                Kq = new byte[] { };
            }
            return Kq;
        }

    }
}
