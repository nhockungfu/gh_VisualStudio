using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaDinhWebService.DAO;
using System.Data;

namespace GiaDinhWebService.BUS
{
    public class BUS_Xu_ly_Khac
    {

        DAO_Toan_cuc ToanCuc = new DAO.DAO_Toan_cuc();

        public DataSet Tao_bang_Quan_ly_Chi()
        {
            return ToanCuc.Tao_bang_Quan_ly_Chi();
        }

        public DataSet Tao_bang_Quan_ly_Thu()
        {
            return ToanCuc.Tao_bang_Quan_ly_Thu();
        }

        public DataSet Tra_cuu_Thu_Chi(string Ten, string Ngay, string So_tien, string Loai_Thu_Chi)
        {
            return ToanCuc.Tra_cuu_Thu_Chi(Ten, Ngay, So_tien, Loai_Thu_Chi);
        }

        public List<int> Lay_Tat_ca_Cac_Nam()
        {
            return ToanCuc.Lay_Cac_Nam();
        }

        //xuất ra chuỗi thống kê tổng quát
        public List<int> Thong_ke_Tong_Quat(string Thang, string Nam)
        {
            return ToanCuc.Thong_ke_Tong_Quat(Thang,Nam);
        }

        public List<string> Lay_danh_Sach_Ten()
        {
            return ToanCuc.Lay_Danh_sach_Ten();
        }

        public byte[] Doc_Hinh(string Ma_so)
        {
            return ToanCuc.Doc_Hinh(Ma_so);
        }
    }
}