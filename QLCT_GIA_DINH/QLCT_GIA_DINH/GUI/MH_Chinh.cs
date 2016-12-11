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


namespace QLCT_GIA_DINH
{
    public partial class MH_Chinh : Form
    {

        GiaDinhServiceSoapClient Service = new GiaDinhServiceSoapClient();

        protected int[] Danh_Sach_Cac_Nam;
        protected int Thang_Dang_Chon;
        protected int Nam_Dang_Chon;
        protected int Chi_so_Chay_Nam = 0;

        public MH_Chinh()
        {
            InitializeComponent();
        }

        private void MH_Chinh_Load(object sender, EventArgs e)
        {
            Danh_Sach_Cac_Nam = Service.Lay_Tat_ca_Cac_Nam();//lấy ra danh sách các năm trong csdl

            Hien_thi_Thong_ke_Nam();//hiện các năm lên bảng điều khiển
            Hien_Ten_Thanh_vien_Gia_dinh();

            string temp = btNamThuNhat.Text.Substring(15, 4);

            Xuat_Thong_Ke_Tung_Thang(Nam_Dang_Chon); //hiện thống kê từng tháng 1->12

            btNamThuNhat_Click(sender, e); //lần đầu tiên chạy sẽ click vào năm gần nhất -
            btThangMot_Click(sender, e); //và tháng 1

        }

        protected void Hien_Ten_Thanh_vien_Gia_dinh()
        {
            string[] ds_ten = Service.Lay_danh_Sach_Ten();

            lbTenThanhVienA.Text = ds_ten[0];
            lbTenThanhVienB.Text = ds_ten[1];
            lbTenThanhVienC.Text = ds_ten[2];
            lbTenThanhVienD.Text = ds_ten[3];
            lbTenGiaDinh.Text = ds_ten[4];
        }

        //ref: là truyền tham biến | dùng thống kê cập nhật tổng thu, tổng chi và chênh lệch
        protected void Thong_ke_Theo_Thang(ref int Tong_Thu, ref int Tong_Chi, ref int Tong_Chenh_lech, int mThang, int mNam)
        {
            string Thang = mThang.ToString();
            string Nam = mNam.ToString();
            int[] Thong_ke = Service.Thong_ke_Tong_Quat(Thang, Nam);

            for (int i = 0; i < Thong_ke.Length; i += 3) //Thong_ke.Length = 15
            {
                Tong_Thu += Thong_ke[i];
                Tong_Chi = Thong_ke[i + 1];
                Tong_Chenh_lech = Thong_ke[i + 2];
            }
        }

        //Xử lý khi chọn tháng | xuất thống kê các thành viên và gia đình
        public void Chon_Thang(int Thang_Hien_tai, int Nam_Hien_tai)
        {
            string Thang = Thang_Hien_tai.ToString();
            string Nam = Nam_Hien_tai.ToString();

            int[] Thong_ke = Service.Thong_ke_Tong_Quat(Thang, Nam);

            string temp_thu;
            string temp_chi;
            string temp_chenh_lech;

            for (int i = 0; i < Thong_ke.Length; i += 3) //Thong_ke.Length = 15
            {
                temp_thu = Thong_ke[i].ToString();
                temp_chi = Thong_ke[i + 1].ToString();
                temp_chenh_lech = Thong_ke[i + 2].ToString();

                string Chuoi_Thong_ke = temp_thu + "\n" + temp_chi + "\n" + temp_chenh_lech;

                if (i == 0)
                    lbThongKeA.Text = Chuoi_Thong_ke;
                if (i == 3)
                    lbThongKeB.Text = Chuoi_Thong_ke;
                if (i == 6)
                    lbThongKeC.Text = Chuoi_Thong_ke;
                if (i == 9)
                    lbThongKeD.Text = Chuoi_Thong_ke;
                if (i == 12)
                    lbThongKeChung.Text = Chuoi_Thong_ke;
            }


        }

        //xuất thống kê các tháng lên màn hình
        public List<int> Xuat_Thong_Ke_Tung_Thang(int Theo_Nam)
        {
            List<int> Thong_Ke_Nam = new List<int>(new int[] { 0, 0, 0 });

            for (int i = 0; i < 12; i++)
            {
                int Tong_Thu = 0;
                int Tong_Chi = 0;
                int Tong_Chenh_lech = 0;

                //Thong_ke_Theo_Thang(ref Tong_Thu, ref Tong_Chi, ref Tong_Chenh_lech, i + 1, Theo_Nam);

                int[] Thong_ke = Service.Thong_ke_Tong_Quat((i+1).ToString(), Theo_Nam.ToString());

                for (int k  = 0; k < Thong_ke.Length; k += 3) //Thong_ke.Length = 15
                {
                    Tong_Thu += Thong_ke[k];
                    Tong_Chi += Thong_ke[k + 1];
                    Tong_Chenh_lech += Thong_ke[k + 2];
                }

                Thong_Ke_Nam[0] += Tong_Thu;
                Thong_Ke_Nam[1] += Tong_Chi;
                Thong_Ke_Nam[2] += Tong_Thu - Tong_Chi;

                string Chuoi_Thong_ke = "                 Tháng " + (i+1) + "\n+" + Tong_Thu + "\n-" + Tong_Chi + "\n=" + Tong_Chenh_lech;

                if (i + 1 == 1)
                    btThangMot.Text = Chuoi_Thong_ke;
                if (i + 1 == 2)
                    btThangHai.Text = Chuoi_Thong_ke;
                if (i + 1 == 3)
                    btThangBa.Text = Chuoi_Thong_ke;
                if (i + 1 == 4)
                    btThangTu.Text = Chuoi_Thong_ke;
                if (i + 1 == 5)
                    btThangNam.Text = Chuoi_Thong_ke;
                if (i + 1 == 6)
                    btThangSau.Text = Chuoi_Thong_ke;
                if (i + 1 == 7)
                    btThangBay.Text = Chuoi_Thong_ke;
                if (i + 1 == 8)
                    btThangTam.Text = Chuoi_Thong_ke;
                if (i + 1 == 9)
                    btThangChin.Text = Chuoi_Thong_ke;
                if (i + 1 == 10)
                    btThangMuoi.Text = Chuoi_Thong_ke;
                if (i + 1 == 11)
                    btThangMuoiMot.Text = Chuoi_Thong_ke;
                if (i + 1 == 12)
                    btThangMuoiHai.Text = Chuoi_Thong_ke;
            }

            return Thong_Ke_Nam;
        }

        protected void Hien_thi_Thong_ke_Nam(int chiSo = 0)
        {

            List<int> Thong_Ke_Nam1;
            List<int> Thong_Ke_Nam2;
            List<int> Thong_Ke_Nam3;

            int soLuongPhanTu = Danh_Sach_Cac_Nam.Length;

            if (soLuongPhanTu - (chiSo + 1) >= 0) //hiện năm thứ nhất
            {
                btNamThuNhat.Show();
                btNamThuNhat.Text = "               " + Danh_Sach_Cac_Nam[chiSo].ToString();
                Thong_Ke_Nam1 = Xuat_Thong_Ke_Tung_Thang(Convert.ToInt32(btNamThuNhat.Text.Substring(15,4)));
                btNamThuNhat.Text = btNamThuNhat.Text + "\n+" + Thong_Ke_Nam1[0] + "\n-" + Thong_Ke_Nam1[1] + "\n=" + Thong_Ke_Nam1[2];
            }
            else return;

            if ((soLuongPhanTu - (chiSo + 2)) >= 0) //hiện năm thứ hai
            {
                btNamThuHai.Show();
                btNamThuHai.Text = "               " + Danh_Sach_Cac_Nam[chiSo + 1].ToString();
                Thong_Ke_Nam2 = Xuat_Thong_Ke_Tung_Thang(Convert.ToInt32(btNamThuHai.Text.Substring(15,4)));
                btNamThuHai.Text = btNamThuHai.Text + "\n+" + Thong_Ke_Nam2[0] + "\n-" + Thong_Ke_Nam2[1] + "\n=" + Thong_Ke_Nam2[2];
            }
            else btNamThuHai.Hide();

            if ((soLuongPhanTu - (chiSo + 3)) >= 0) //hiện năm thứ ba
            {
                btNamThuBa.Show();
                btNamThuBa.Text = "               " + Danh_Sach_Cac_Nam[chiSo + 2].ToString();
                Thong_Ke_Nam3 = Xuat_Thong_Ke_Tung_Thang(Convert.ToInt32(btNamThuBa.Text.Substring(15, 4)));
                btNamThuBa.Text = btNamThuBa.Text + "\n+" + Thong_Ke_Nam3[0] + "\n-" + Thong_Ke_Nam3[1] + "\n=" + Thong_Ke_Nam3[2];
            }
            else btNamThuBa.Hide();

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////XỬ LÝ///////EVENT ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void picToRight_Click(object sender, EventArgs e)
        {
            if (Chi_so_Chay_Nam < Danh_Sach_Cac_Nam.Length - 3)
            {
                Chi_so_Chay_Nam += 3;
                Hien_thi_Thong_ke_Nam(Chi_so_Chay_Nam);
            }
        }

        private void picToLeft_Click(object sender, EventArgs e)
        {
            if (Chi_so_Chay_Nam >= 3)
            {
                Chi_so_Chay_Nam -= 3;
                Hien_thi_Thong_ke_Nam(Chi_so_Chay_Nam);
            }
        }

        ///////////////////////////////XỬ LÝ CHỌN Năm///////////////////////////////////////////////

        private void btNamThuNhat_Click(object sender, EventArgs e)
        {
            Nam_Dang_Chon = Convert.ToInt32(btNamThuNhat.Text.Substring(15, 4));
            Thang_Dang_Chon = 1;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            Xuat_Thong_Ke_Tung_Thang(Nam_Dang_Chon);
            lbNamDangChon.Text = Nam_Dang_Chon.ToString();
            btThangMot_Click(sender, e);
        }

        private void btNamThuHai_Click(object sender, EventArgs e)
        {
            Nam_Dang_Chon = Convert.ToInt32(btNamThuHai.Text.Substring(15, 4));
            Thang_Dang_Chon = 1;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            Xuat_Thong_Ke_Tung_Thang(Nam_Dang_Chon);
            lbNamDangChon.Text = Nam_Dang_Chon.ToString();
            btThangMot_Click(sender, e);
        }

        private void btNamThuBa_Click(object sender, EventArgs e)
        {
            Nam_Dang_Chon = Convert.ToInt32(btNamThuBa.Text.Substring(15, 4));
            Thang_Dang_Chon = 1;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            Xuat_Thong_Ke_Tung_Thang(Nam_Dang_Chon);
            lbNamDangChon.Text = Nam_Dang_Chon.ToString();
            btThangMot_Click(sender, e);
        }

        //////////////////////////////XỬ LÝ CHỌN THÁNG///////////////////////////////////////////////

        private void btThangMot_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 1;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangHai_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 2;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangBa_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 3;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangTu_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 4;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangNam_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 5;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangSau_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 6;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangBay_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 7;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangTam_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 8;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangChin_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 9;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangMuoi_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 10;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangMuoiMot_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 11;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void btThangMuoiHai_Click(object sender, EventArgs e)
        {
            Thang_Dang_Chon = 12;
            Chon_Thang(Thang_Dang_Chon, Nam_Dang_Chon);
            lbThangDangChon.Text = "Tháng "+Thang_Dang_Chon.ToString() + ", năm " + Nam_Dang_Chon.ToString();
        }

        private void lbNamThuNhat_Click(object sender, EventArgs e)
        {
            btNamThuNhat_Click(sender, e);
        }

        private void lbNamThuHai_Click(object sender, EventArgs e)
        {
            btNamThuHai_Click(sender, e);
        }

        private void lbNamThuBa_Click(object sender, EventArgs e)
        {
            btNamThuBa_Click(sender, e);
        }

        private void btTraCuu_Click(object sender, EventArgs e)
        {
            MH_Tra_cuu_Thu_Chi Form_Tra_cuu = new MH_Tra_cuu_Thu_Chi();
            Form_Tra_cuu.ShowDialog(this);
        }

        private void btQuanLyThu_Click(object sender, EventArgs e)
        {
            MH_Quan_ly_Thu Form_Quan_ly_Thu = new QLCT_GIA_DINH.MH_Quan_ly_Thu();
            Form_Quan_ly_Thu.ShowDialog(this);
        }

        private void btQuanLyChi_Click(object sender, EventArgs e)
        {
            MH_Quan_ly_Chi Form_Quan_ly_Chi = new QLCT_GIA_DINH.MH_Quan_ly_Chi();
            Form_Quan_ly_Chi.ShowDialog(this);
        }

        private void btThanhVien_Click(object sender, EventArgs e)
        {
            MH_Thong_tin_Thanh_vien Form_Thong_tin = new QLCT_GIA_DINH.MH_Thong_tin_Thanh_vien();
            Form_Thong_tin.ShowDialog(this);
        }
    }
}
