using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GiaDinhWebService.BUS;
using System.Data;


namespace GiaDinhWebService
{
    /// <summary>
    /// Summary description for GiaDinhService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GiaDinhService : System.Web.Services.WebService
    {

        #region "Biến cục bộ"

        protected BUS_Khoan_chi_Gia_dinh Khoan_chi_Gia_dinh = new BUS_Khoan_chi_Gia_dinh();
        protected BUS_Khoan_thu_Gia_dinh khoan_thu_Gia_dinh = new BUS_Khoan_thu_Gia_dinh();
        protected BUS_Khoan_chi_Thanh_vien Khoan_chi_Thanh_vien = new BUS_Khoan_chi_Thanh_vien();
        protected BUS_Khoan_thu_Thanh_vien Khoan_thu_Thanh_vien = new BUS_Khoan_thu_Thanh_vien();
        protected BUS_Gia_dinh Gia_dinh = new BUS_Gia_dinh();
        protected BUS_Thanh_vien Thanh_vien = new BUS_Thanh_vien();

        #endregion



        #region "Hàm nội bộ / Hàm phụ trợ"

        #endregion"



        #region "Hàm xử lý chính cho KHOẢN CHI GIA ĐÌNH"

        [WebMethod]
        public void Them_Khoan_chi_Gia_dinh(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            Khoan_chi_Gia_dinh.Them_moi(ID,Ngay,So_tien,ID_Gia_dinh);
        }

        [WebMethod]
        public void Xoa_Khoan_chi_Gia_dinh(string ID, string ID_Gia_dinh)
        {
            Khoan_chi_Gia_dinh.Xoa(ID, ID_Gia_dinh);
        }

        [WebMethod]
        public void Cap_nhat_Khoan_chi_Gia_dinh(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            Khoan_chi_Gia_dinh.Cap_nhat(ID, Ngay, So_tien, ID_Gia_dinh);
        }

        [WebMethod]
        public int ID_Khoan_chi_Gia_dinh_Tu_tang()
        {
            return Khoan_chi_Gia_dinh.ID_Tu_Tang();
        }

        #endregion"



        #region "Hàm xử lý chính cho KHOẢN THU GIA ĐÌNH"

        [WebMethod]
        public void Them_Khoan_thu_Gia_dinh(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            khoan_thu_Gia_dinh.Them_moi(ID, Ngay, So_tien, ID_Gia_dinh);
        }

        [WebMethod]
        public void Xoa_Khoan_thu_Gia_dinh(string ID, string ID_Gia_dinh)
        {
            khoan_thu_Gia_dinh.Xoa(ID, ID_Gia_dinh);
        }

        [WebMethod]
        public void Cap_nhat_Khoan_thu_Gia_dinh(string ID, string Ngay, string So_tien, string ID_Gia_dinh)
        {
            khoan_thu_Gia_dinh.Cap_nhat(ID, Ngay, So_tien, ID_Gia_dinh);
        }

        [WebMethod]
        public int ID_Khoan_thu_Gia_dinh_Tu_tang()
        {
            return khoan_thu_Gia_dinh.ID_Tu_Tang();
        }

        #endregion



        #region "Hàm xử lý chính cho KHOẢN CHI THÀNH VIÊN"

        [WebMethod]
        public void Them_Khoan_chi_Thanh_vien(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            Khoan_chi_Thanh_vien.Them_moi(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        [WebMethod]
        public void Xoa_Khoan_chi_Thanh_vien(string ID, string ID_Thanh_vien)
        {
            Khoan_chi_Thanh_vien.Xoa(ID, ID_Thanh_vien);
        }

        [WebMethod]
        public void Cap_nhat_Khoan_chi_Thanh_vien(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            Khoan_chi_Thanh_vien.Cap_nhat(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        [WebMethod]
        public int ID_Khoan_chi_Thanh_vien_Tu_tang()
        {
            return Khoan_chi_Thanh_vien.ID_Tu_Tang();
        }

        #endregion



        #region "Hàm xử lý chính cho KHOẢN THU THÀNH VIÊN"

        [WebMethod]
        public void Them_Khoan_thu_Thanh_vien(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            Khoan_thu_Thanh_vien.Them_moi(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        [WebMethod]
        public void Xoa_Khoan_thu_Thanh_vien(string ID, string ID_Thanh_vien)
        {
            Khoan_thu_Thanh_vien.Xoa(ID, ID_Thanh_vien);
        }

        [WebMethod]
        public void Cap_nhat_Khoan_thu_Thanh_vien(string ID, string Ngay, string So_tien, string ID_Thanh_vien)
        {
            Khoan_thu_Thanh_vien.Cap_nhat(ID, Ngay, So_tien, ID_Thanh_vien);
        }

        [WebMethod]
        public int ID_Khoan_thu_Thanh_vien()
        {
            return Khoan_thu_Thanh_vien.ID_Tu_Tang();
        }

        #endregion



        #region "Ham xu ly GIA DINH"


        #endregion



        #region "Hàm xử lý chính cho THÀNH VIÊN"

        [WebMethod]
        public string Lay_Ten_Thanh_vien(string ID)
        {
            return Thanh_vien.Lay_Ten_Thanh_vien(ID);
        }

        [WebMethod]
        public string Lay_ID_Thanh_vien(string Ten_Thanh_vien)
        {
            return Thanh_vien.Lay_ID_Thanh_vien(Ten_Thanh_vien);
        }

        [WebMethod]
        public List<string> Lay_Ten_Tat_ca_Thanh_vien()
        {
            return Thanh_vien.Lay_Ten_Tat_ca_Thanh_vien();
        }

        [WebMethod]
        public List<string> Lay_Ten_Va_Ngay_sinh(string Ten_Thanh_vien)
        {
            return Thanh_vien.Lay_Ten_Va_Ngay_sinh(Ten_Thanh_vien);
        }

        #endregion



        #region "Hàm xử lý khác"

        [WebMethod]
        public DataSet Tao_bang_Quan_ly_Chi()
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Tao_bang_Quan_ly_Chi();
        }

        [WebMethod]
        public DataSet Tao_bang_Quan_ly_Thu()
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Tao_bang_Quan_ly_Thu();
        }

        [WebMethod]
        public DataSet Tra_cuu_Thu_Chi(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Tra_cuu_Thu_Chi(Ten,Ngay,So_tien,Loai_Thu_Chi);
        }

        [WebMethod]
        public List<int> Lay_Tat_ca_Cac_Nam()
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Lay_Tat_ca_Cac_Nam();
        }

        [WebMethod]
        public List<int> Thong_ke_Tong_Quat(string Thang, string Nam)
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Thong_ke_Tong_Quat(Thang,Nam);
        }

        [WebMethod]
        public List<string> Lay_danh_Sach_Ten()
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Lay_danh_Sach_Ten();
        }

        [WebMethod]
        public byte[] Lay_Anh(string Ten_Hinh_anh)
        {
            BUS_Xu_ly_Khac xuLy = new BUS_Xu_ly_Khac();
            return xuLy.Doc_Hinh(Ten_Hinh_anh);
        }

        #endregion



        #region "Hàm xử lý chính cho GIA ĐÌNH"

        [WebMethod]
        public int ID_Gia_dinh_Tu_tang()
        {
            return Gia_dinh.ID_Tu_Tang();
        }

        [WebMethod]
        public string Lay_ID_Gia_dinh(string Ten_Gia_dinh)
        {
            return Gia_dinh.Lay_ID_Gia_dinh(Ten_Gia_dinh);
        }

        #endregion


    }
}
