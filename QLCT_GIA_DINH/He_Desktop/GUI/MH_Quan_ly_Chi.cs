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
using System.Runtime.InteropServices;



namespace QLCT_GIA_DINH
{
    public partial class MH_Quan_ly_Chi : Form
    {

        protected GiaDinhServiceSoapClient Service = new GiaDinhServiceSoapClient();
        protected int dongHienTai = 0;
        protected string TEN_GIA_DINH;

        protected int co_them = 1;
        protected int co_xoa = 0;
        protected int co_sua = 0;


        public MH_Quan_ly_Chi()
        {
            InitializeComponent();
        }
        

        private void MH_Quan_ly_Chi_Load(object sender, EventArgs e)
        {
            Khoi_dong();
            cbLoaiChi_TextChanged(sender, e);
            Nap_Du_lieu_Len_DataGridView();
            Nap_Du_lieu_Ten_Thanh_vien();
            Nap_Du_lieu_Loai_Chi();
            Dinh_dang_Cho_Bang();
        }

        protected void Khoi_dong()
        {
            //khoa
            btSua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = false;

            string[] ds_ten = Service.Lay_danh_Sach_Ten();

            //khoi tao du lieu
            cbxLoaiChi.Text = "Chung";
            cbxTenThanhVien.Text = ds_ten[0];
            tbSoTien.Text = "";
            dtpNgay.Value = DateTime.Now;



            string[] ten_gia_dinh = Service.Lay_danh_Sach_Ten();
            TEN_GIA_DINH = ds_ten[4];
        }

        protected void Nap_Du_lieu_Ten_Thanh_vien()
        {
            string[] ds_ten = Service.Lay_danh_Sach_Ten();

            cbxTenThanhVien.Items.Add(ds_ten[0]);
            cbxTenThanhVien.Items.Add(ds_ten[1]);
            cbxTenThanhVien.Items.Add(ds_ten[2]);
            cbxTenThanhVien.Items.Add(ds_ten[3]);
        }

        protected void Nap_Du_lieu_Loai_Chi()
        {
            cbxLoaiChi.Items.Add("Chung");
            cbxLoaiChi.Items.Add("Riêng");
        }

        protected void Nap_Du_lieu_Len_DataGridView()
        {

            DataTable Bang_Du_lieu = new DataTable();

            Bang_Du_lieu = Service.Tao_bang_Quan_ly_Chi().Tables[0]; //tao bang du lieu

            dgvQuan_ly_Chi.DataSource = Bang_Du_lieu; //load du lieu

            dgvQuan_ly_Chi.Sort(dgvQuan_ly_Chi.Columns[3], ListSortDirection.Descending); //sap xep ngay giam 

            Hien_thi_Dong(dongHienTai); //focus dong hien tai

            cbxLoaiChi.Focus(); //focus vao combobox loai chi
        }

        protected void Dinh_dang_Cho_Bang()
        {

            dgvQuan_ly_Chi.Columns[0].Visible = false; //ẩn cột id

            dgvQuan_ly_Chi.ClearSelection();

            //định dạng màu cho RowsSelection
            dgvQuan_ly_Chi.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuan_ly_Chi.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuan_ly_Chi.Columns[2].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuan_ly_Chi.Columns[3].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuan_ly_Chi.Columns[4].DefaultCellStyle.SelectionBackColor = Color.Orange;

            //định dạng alignment cho header và column
            foreach (DataGridViewColumn col in dgvQuan_ly_Chi.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                dgvQuan_ly_Chi.Columns[col.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        protected string Chuyen_ve_Dung_Dinh_dang(object Chuoi_Thoi_gian)
        {
            DateTime Thoi_gian = Convert.ToDateTime(Chuoi_Thoi_gian);

            DateTime dt = new DateTime(Thoi_gian.Year, Thoi_gian.Month, Thoi_gian.Day, 0, 0, 0, DateTimeKind.Local);

            string chuoiDinhDang = dt.ToString("yyyy-MM-ddTHH:mm:ssK");

            return chuoiDinhDang;
        }

        protected void Hien_thi_Dong(int Chi_so_dong)
        {
            if(dgvQuan_ly_Chi.Rows.Count > Chi_so_dong + 1 )
                dgvQuan_ly_Chi.CurrentCell = dgvQuan_ly_Chi.Rows[Chi_so_dong].Cells[1];
            else
                dgvQuan_ly_Chi.CurrentCell = dgvQuan_ly_Chi.Rows[Chi_so_dong-1].Cells[1];

        }

        // QUAN LY CAC SU KIEN /////////////////////////////////////////////////////////////////////////////



        private void btThem_Click(object sender, EventArgs e)
        {
            if(cbxLoaiChi.Text != string.Empty
                && cbxTenThanhVien.Text != string.Empty
                && tbSoTien.Text != string.Empty)
            {
                try
                {
                    if (cbxLoaiChi.Text == "Chung")
                    {
                        string ID = Service.ID_Khoan_chi_Gia_dinh_Tu_tang().ToString();
                        string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);
                        string soTien = tbSoTien.Text;
                        string ID_Gia_dinh = "1";
                        Service.Them_Khoan_chi_Gia_dinh(ID, Ngay, soTien, ID_Gia_dinh);
                    }
                    else
                    {
                        string ID = Service.ID_Khoan_chi_Thanh_vien_Tu_tang().ToString();
                        string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);
                        string soTien = tbSoTien.Text;
                        string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(cbxTenThanhVien.Text);
                        Service.Them_Khoan_chi_Thanh_vien(ID, Ngay, soTien, ID_Thanh_vien);
                    }

                    Nap_Du_lieu_Len_DataGridView();
                    //dgvQuan_ly_Chi.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Data.ToString(), "Lỗi");
                }

            }
            else
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                Xoa_Thong_tin();
            }
            else
            {
                //không làm gì hết
            }
        }

        protected void Xoa_Thong_tin()
        {
            int iRow = dgvQuan_ly_Chi.CurrentCell.RowIndex;
            string ID = dgvQuan_ly_Chi.Rows[iRow].Cells[0].Value.ToString();
            string loai = dgvQuan_ly_Chi.Rows[iRow].Cells[4].Value.ToString();


            if (loai == "Chung")
            {
                string ID_Gia_dinh = "1";
                Service.Xoa_Khoan_chi_Gia_dinh(ID, ID_Gia_dinh);
            }
            else
            {
                string Ten_Thanh_vien = dgvQuan_ly_Chi.Rows[iRow].Cells[1].Value.ToString();
                string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(Ten_Thanh_vien);
                Service.Xoa_Khoan_chi_Thanh_vien(ID, ID_Thanh_vien);
            }

            Nap_Du_lieu_Len_DataGridView(); //nạp lại dữ liệu
            dgvQuan_ly_Chi.Update();


            tbSoTien.Text = string.Empty;
            dtpNgay.Value = DateTime.Now;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int iRow = dgvQuan_ly_Chi.CurrentCell.RowIndex;

            string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);

            string So_tien = tbSoTien.Text;

            string loai = dgvQuan_ly_Chi.Rows[iRow].Cells[4].Value.ToString();

            string ID = dgvQuan_ly_Chi.Rows[iRow].Cells[0].Value.ToString();

            if (loai == "Chung")
            {
                string ID_Gia_dinh = "1";
                Service.Cap_nhat_Khoan_chi_Gia_dinh(ID, Ngay, So_tien, ID_Gia_dinh);
            }
            else
            {
                string Ten_Thanh_vien = cbxTenThanhVien.Text.Trim();
                string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(Ten_Thanh_vien);
                Service.Cap_nhat_Khoan_chi_Thanh_vien(ID, Ngay, So_tien, ID_Thanh_vien);
            }

            Nap_Du_lieu_Len_DataGridView(); //nạp lại dữ liệu

            dgvQuan_ly_Chi.Update();

        }

        private void dgvQuan_ly_Chi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxLoaiChi.Focus();

            int iRow = dgvQuan_ly_Chi.CurrentCell.RowIndex;

            object ten= dgvQuan_ly_Chi.Rows[iRow].Cells[1].Value;
            object soTien = dgvQuan_ly_Chi.Rows[iRow].Cells[2].Value;
            object ngay = dgvQuan_ly_Chi.Rows[iRow].Cells[3].Value;
            object loai = dgvQuan_ly_Chi.Rows[iRow].Cells[4].Value;

            cbxTenThanhVien.Text = ten.ToString();
            tbSoTien.Text = soTien.ToString();
            dtpNgay.Value = Convert.ToDateTime(ngay);

            if (loai.ToString() == "Chung")
            {
                cbxLoaiChi.Text = "Chung";
            }
            else
            {
                cbxLoaiChi.Text = "Riêng";
            }

            btSua.Enabled = true;
            btXoa.Enabled = false;
            btThem.Enabled = false;

            co_them = 0;
            co_sua = 1;
            co_xoa = 0;
        }


        private void dgvQuan_ly_Chi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHienTai = e.RowIndex; //lay chi so dong hien tai

            tbSoTien.Text = string.Empty;
            dtpNgay.Value = DateTime.Now;

            btSua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;

            co_xoa = 1;
            co_them = 0;
            co_sua = 0;
        }

        private void cbLoaiChi_TextChanged(object sender, EventArgs e)
        {
            if (cbxLoaiChi.Text == "Chung")
            {
                lbTen.Text = "Tên gia đình:";
                cbxTenThanhVien.Hide();
                tbTenGiaDinh.Show();
                tbTenGiaDinh.Enabled = false;
                tbTenGiaDinh.Text = TEN_GIA_DINH;
            }

            if (cbxLoaiChi.Text == "Riêng")
            {
                lbTen.Text = "Tên thành viên:";
                cbxTenThanhVien.Show();
                tbTenGiaDinh.Hide();
                cbxTenThanhVien.Text = "Nguyễn thị bé Lớn";
                cbxTenThanhVien.Enabled = true;
            }
        }

        private void dgvQuan_ly_Chi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (co_xoa == 1)
                    btXoa_Click(sender, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (co_sua == 1)
                    btSua_Click(sender, e);
                else
                {
                    if (co_them == 1)
                        btThem_Click(sender, e);
                }


            }
        }

        private void dgvQuan_ly_Chi_MouseLeave(object sender, EventArgs e)
        {
            if(co_sua == 1)
            {
                co_them = 0;
            }
            else
            {
                co_them = 1;
            }
        }
    }
}
