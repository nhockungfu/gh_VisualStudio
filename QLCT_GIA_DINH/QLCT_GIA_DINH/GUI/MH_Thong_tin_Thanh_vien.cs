using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCT_GIA_DINH.GD_Service;
using System.IO;

namespace QLCT_GIA_DINH
{
    public partial class MH_Thong_tin_Thanh_vien : Form
    {
        static GiaDinhServiceSoapClient Service = new GiaDinhServiceSoapClient();
        static string[] danh_sach_ten = Service.Lay_danh_Sach_Ten();



        public MH_Thong_tin_Thanh_vien()
        {
            InitializeComponent();
        }

        private void MH_Thong_tin_Thanh_vien_Load(object sender, EventArgs e)
        {
            Load_Hinh();
            Load_Thong_tin();
        }

        protected Bitmap Xuat_Hinh(byte[] Nhi_phan)
        {
            if (Nhi_phan.Length > 100)
            {
                MemoryStream Luong = new MemoryStream(Nhi_phan);
                Bitmap Hinh = (Bitmap)Bitmap.FromStream(Luong);
                return Hinh;
            }
            else
            {
                return null;
            }
        }

        protected void Load_Hinh()
        {

            //load hình A
            byte[] Nhi_phan_Hinh_A = Service.Lay_Anh(danh_sach_ten[0]);

            if (Nhi_phan_Hinh_A.Length > 100)
                picDauTien.Image = Xuat_Hinh(Nhi_phan_Hinh_A);

            //load hình B
            byte[] Nhi_phan_Hinh_B = Service.Lay_Anh(danh_sach_ten[1]);

            if (Nhi_phan_Hinh_B.Length > 100)
                picThuHai.Image = Xuat_Hinh(Nhi_phan_Hinh_B);

            //load hình C
            byte[] Nhi_phan_Hinh_C = Service.Lay_Anh(danh_sach_ten[2]);

            if (Nhi_phan_Hinh_C.Length > 100)
                picThuBa.Image = Xuat_Hinh(Nhi_phan_Hinh_C);

            //load hình D
            byte[] Nhi_phan_Hinh_D = Service.Lay_Anh(danh_sach_ten[3]);

            if (Nhi_phan_Hinh_D.Length > 100)
                picThuTu.Image = Xuat_Hinh(Nhi_phan_Hinh_D);

        }


        protected void Load_Thong_tin()
        {
            lbHoTenA.Text = "Họ tên: " + danh_sach_ten[0];
            lbHoTenB.Text = "Họ tên: " + danh_sach_ten[1];
            lbHoTenC.Text = "Họ tên: " + danh_sach_ten[2];
            lbHoTenD.Text = "Họ tên: " + danh_sach_ten[3];


            string[] Thong_tin_A = Service.Lay_Ten_Va_Ngay_sinh(danh_sach_ten[0]);
            string[] Thong_tin_B = Service.Lay_Ten_Va_Ngay_sinh(danh_sach_ten[1]);
            string[] Thong_tin_C = Service.Lay_Ten_Va_Ngay_sinh(danh_sach_ten[2]);
            string[] Thong_tin_D = Service.Lay_Ten_Va_Ngay_sinh(danh_sach_ten[3]);

            lbNgaySinhA.Text = "Ngày sinh: " + Thong_tin_A[0];
            lbNgaySinhB.Text = "Ngày sinh: " + Thong_tin_B[0];
            lbNgaySinhC.Text = "Ngày sinh: " + Thong_tin_C[0];
            lbNgaySinhD.Text = "Ngày sinh: " + Thong_tin_D[0];

            lbGioiTinhA.Text = "Giới tính: " + Thong_tin_A[1];
            lbGioiTinhB.Text = "Giới tính: " + Thong_tin_B[1];
            lbGioiTinhC.Text = "Giới tính: " + Thong_tin_C[1];
            lbGioiTinhD.Text = "Giới tính: " + Thong_tin_D[1];
        }



    }
}
