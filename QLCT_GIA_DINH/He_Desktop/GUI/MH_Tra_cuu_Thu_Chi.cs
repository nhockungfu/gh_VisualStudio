using QLCT_GIA_DINH.GD_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_GIA_DINH
{
    public partial class MH_Tra_cuu_Thu_Chi : Form
    {
        protected static GiaDinhServiceSoapClient Service = new GiaDinhServiceSoapClient();
        protected string[] danh_sach_ten = Service.Lay_danh_Sach_Ten();

        //tên mặc định cho gia đình
        protected const string TEN_GIA_DINH = "Gia đình Hai Lúa";
        protected const string TEN_THANH_VIEN_A = "Nguyễn thị bé Lớn";
        protected const string TEN_THANH_VIEN_B = "Lê văn bé Nhỏ";
        protected const string TEN_THANH_VIEN_C = "Lê thị bé Xíu";
        protected const string TEN_THANH_VIEN_D = "Lê văn bé Bé";

        //các biến cờ hiệu
        protected bool co_gia_dinh = true;
        protected bool co_thanh_vien_a = false;
        protected bool co_thanh_vien_b = false;
        protected bool co_thanh_vien_c = false;
        protected bool co_thanh_vien_d = false;

        //loại thu chi
        protected const string LOAI_CHUNG = "Chung";
        protected const string LOAI_RIENG= "Riêng";


        protected Color panel_nen = Color.FromArgb(51, 115, 153);
        protected Color panel_sang = Color.FromArgb(250, 197, 28);


        public MH_Tra_cuu_Thu_Chi()
        {
            InitializeComponent();
        }

        private void MH_Tra_cuu_Thu_Chi_Load(object sender, EventArgs e)
        {
            tbNgay.Text = string.Empty;
            tbSoTien.Text = string.Empty;
            imgChung_Click(sender, e);
            Load_Hinh();
        }



        protected void Nap_Du_lieu_Len_DataGridView(string Ten,string Loai_Thu_Chi)
        {

            string So_tien = tbSoTien.Text; //lay so tien

            string Ngay = tbNgay.Text;

            if (Ngay != string.Empty)
                Ngay = Chuyen_ve_Dung_Dinh_dang(tbNgay); // lay ngay da chuyen dinh dang

            dgvTraCuu.DataSource = Service.Tra_cuu_Thu_Chi(Ten, Ngay, So_tien, Loai_Thu_Chi).Tables[0]; //load bang tra cuu

            //dgvTraCuu.Update();

            dgvTraCuu.Sort(dgvTraCuu.Columns[4], ListSortDirection.Descending); //sap xep ngay giam 

            Dinh_dang_Cho_Bang(); //dinh dang cho dataGridView
        }


        protected void Dinh_dang_Cho_Bang()
        {

            dgvTraCuu.Columns[0].Visible = false; //ẩn cột id

            dgvTraCuu.ClearSelection();

            //định dạng màu cho RowsSelection
            dgvTraCuu.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvTraCuu.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvTraCuu.Columns[2].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvTraCuu.Columns[3].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvTraCuu.Columns[4].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvTraCuu.Columns[5].DefaultCellStyle.SelectionBackColor = Color.Orange;

            //định dạng alignment cho header và column
            foreach (DataGridViewColumn col in dgvTraCuu.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel); 
                dgvTraCuu.Columns[col.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }


        protected string Chuyen_ve_Dung_Dinh_dang(object Chuoi_Thoi_gian)
        {
            DateTime Thoi_gian = Convert.ToDateTime(Chuoi_Thoi_gian);

            DateTime dt = new DateTime(Thoi_gian.Year, Thoi_gian.Month, Thoi_gian.Day, 0, 0, 0, DateTimeKind.Local);

            string chuoiDinhDang = dt.ToString("yyyy-MM-ddTHH:mm:ssK");

            return chuoiDinhDang;
        }

        public void Tra_cuu()
        {
            if (pnA.BackColor == panel_sang)
            {
                Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_A, LOAI_RIENG);
            }

            if (pnB.BackColor == panel_sang)
            {
                Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_B, LOAI_RIENG);
            }

            if (pnC.BackColor == panel_sang)
            {
                Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_C, LOAI_RIENG);
            }

            if (pnD.BackColor == panel_sang)
            {
                Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_D, LOAI_RIENG);
            }

            if (pnChung.BackColor == panel_sang)
            {
                Nap_Du_lieu_Len_DataGridView(TEN_GIA_DINH, LOAI_CHUNG);
            }
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
                imgA.Image = Xuat_Hinh(Nhi_phan_Hinh_A);

            //load hình B
            byte[] Nhi_phan_Hinh_B = Service.Lay_Anh(danh_sach_ten[1]);

            if (Nhi_phan_Hinh_B.Length > 100)
                imgB.Image = Xuat_Hinh(Nhi_phan_Hinh_B);

            //load hình C
            byte[] Nhi_phan_Hinh_C = Service.Lay_Anh(danh_sach_ten[2]);

            if (Nhi_phan_Hinh_C.Length > 100)
                imgC.Image = Xuat_Hinh(Nhi_phan_Hinh_C);

            //load hình D
            byte[] Nhi_phan_Hinh_D = Service.Lay_Anh(danh_sach_ten[3]);

            if (Nhi_phan_Hinh_D.Length > 100)
                imgD.Image = Xuat_Hinh(Nhi_phan_Hinh_D);

        }
        //====////////////////////////////////////////////////////////////////////////////////////////////////

        private void imgA_Click(object sender, EventArgs e)
        {
            Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_A,LOAI_RIENG);
            pnA.BackColor = panel_sang;
            pnB.BackColor = panel_nen;
            pnC.BackColor = panel_nen;
            pnD.BackColor = panel_nen;
            pnChung.BackColor = panel_nen;
            
        }

        private void imgB_Click(object sender, EventArgs e)
        {
            Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_B, LOAI_RIENG);
            pnA.BackColor = panel_nen;
            pnB.BackColor = panel_sang;
            pnC.BackColor = panel_nen;
            pnD.BackColor = panel_nen;
            pnChung.BackColor = panel_nen;
        }

        private void imgC_Click(object sender, EventArgs e)
        {
            Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_C, LOAI_RIENG);
            pnA.BackColor = panel_nen;
            pnB.BackColor = panel_nen;
            pnC.BackColor = panel_sang;
            pnD.BackColor = panel_nen;
            pnChung.BackColor = panel_nen;
        }

        private void imgD_Click(object sender, EventArgs e)
        {
            Nap_Du_lieu_Len_DataGridView(TEN_THANH_VIEN_D, LOAI_RIENG);
            pnA.BackColor = panel_nen;
            pnB.BackColor = panel_nen;
            pnC.BackColor = panel_nen;
            pnD.BackColor = panel_sang;
            pnChung.BackColor = panel_nen;
        }

        private void imgChung_Click(object sender, EventArgs e)
        {
            co_gia_dinh = true;

            Nap_Du_lieu_Len_DataGridView(TEN_GIA_DINH, LOAI_CHUNG);
            pnA.BackColor = panel_nen;
            pnB.BackColor = panel_nen;
            pnC.BackColor = panel_nen;
            pnD.BackColor = panel_nen;
            pnChung.BackColor = panel_sang;
        }

        private void tbSoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Tra_cuu();
        }

        private void tbNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Tra_cuu();
        }

        private void btTraCuu_Click(object sender, EventArgs e)
        {
                Tra_cuu();
        }
    }
}
