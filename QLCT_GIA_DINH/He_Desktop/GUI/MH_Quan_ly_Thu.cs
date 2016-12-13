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
    public partial class MH_Quan_ly_Thu : Form
    {

        protected GiaDinhServiceSoapClient Service = new GiaDinhServiceSoapClient();
        protected int dongHienTai = 0;
        protected const string TEN_GIA_DINH = "Gia đình Hai Lúa";

        protected int co_them = 1;
        protected int co_xoa = 0;
        protected int co_sua = 0;



        public MH_Quan_ly_Thu()
        {
            InitializeComponent();
        }

        private void MH_Quan_ly_Thu_Load(object sender, EventArgs e)
        {
            Khoi_dong();
            Nap_Du_lieu_Len_DataGridView();
            Nap_Du_lieu_Ten_Thanh_vien();
            Nap_Du_lieu_Loai_Thu();
            Dinh_dang_Cho_Bang();
        }


        protected void Nap_Du_lieu_Ten_Thanh_vien()
        {
            string[] ds_ten = Service.Lay_danh_Sach_Ten();

            cbxTenThanhVien.Items.Add(ds_ten[0]);
            cbxTenThanhVien.Items.Add(ds_ten[1]);
            cbxTenThanhVien.Items.Add(ds_ten[2]);
            cbxTenThanhVien.Items.Add(ds_ten[3]);
        }

        protected void Nap_Du_lieu_Loai_Thu()
        {
            cbxLoaiThu.Items.Add("Chung");
            cbxLoaiThu.Items.Add("Riêng");
        }

        protected void Khoi_dong()
        {
            //khoa
            btSua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = false;

            string[] ds_ten = Service.Lay_danh_Sach_Ten();

            //an
            tbTenGiaDinh.Hide();

            //khoi tao du lieu
            cbxLoaiThu.Text = "Chung";
            cbxTenThanhVien.Text = ds_ten[0];
            tbSoTien.Text = "";
            dtpNgay.Value = DateTime.Now;
        }


        protected void Nap_Du_lieu_Len_DataGridView()
        {

            DataTable Bang_Du_lieu = new DataTable();

            Bang_Du_lieu = Service.Tao_bang_Quan_ly_Thu().Tables[0]; //tao bang du lieu

            dgvQuanLyThu.DataSource = Bang_Du_lieu; //load du lieu

            dgvQuanLyThu.Sort(dgvQuanLyThu.Columns[3], ListSortDirection.Descending); //sap xep ngay giam 

            Hien_thi_Dong(dongHienTai); //focus dong hien tai

            cbxLoaiThu.Focus(); //focus vao combobox loai chi
        }

        protected void Dinh_dang_Cho_Bang()
        {

            dgvQuanLyThu.Columns[0].Visible = false; //ẩn cột id

            dgvQuanLyThu.ClearSelection();

            //định dạng màu cho RowsSelection
            dgvQuanLyThu.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuanLyThu.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuanLyThu.Columns[2].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuanLyThu.Columns[3].DefaultCellStyle.SelectionBackColor = Color.Orange;
            dgvQuanLyThu.Columns[4].DefaultCellStyle.SelectionBackColor = Color.Orange;

            //định dạng alignment cho header và column
            foreach (DataGridViewColumn col in dgvQuanLyThu.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                dgvQuanLyThu.Columns[col.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            if (dgvQuanLyThu.Rows.Count > Chi_so_dong + 1)
                dgvQuanLyThu.CurrentCell = dgvQuanLyThu.Rows[Chi_so_dong].Cells[1];
            else
                dgvQuanLyThu.CurrentCell = dgvQuanLyThu.Rows[Chi_so_dong - 1].Cells[1];
        }

        private void dgvQuanLyThu_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void cbxLoaiThu_TextChanged(object sender, EventArgs e)
        {
            if (cbxLoaiThu.Text == "Chung")
            {
                lbTen.Text = "Tên gia đình:";
                cbxTenThanhVien.Hide();
                tbTenGiaDinh.Show();
                tbTenGiaDinh.Enabled = false;
                tbTenGiaDinh.Text = TEN_GIA_DINH;
            }

            if (cbxLoaiThu.Text == "Riêng")
            {
                lbTen.Text = "Tên thành viên:";
                cbxTenThanhVien.Show();
                tbTenGiaDinh.Hide();
                cbxTenThanhVien.Text = "Nguyễn thị bé Lớn";
                cbxTenThanhVien.Enabled = true;
            }
        }

        private void dgvQuanLyThu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxLoaiThu.Focus();

            int iRow = dgvQuanLyThu.CurrentCell.RowIndex;

            object ten = dgvQuanLyThu.Rows[iRow].Cells[1].Value;
            object soTien = dgvQuanLyThu.Rows[iRow].Cells[2].Value;
            object ngay = dgvQuanLyThu.Rows[iRow].Cells[3].Value;
            object loai = dgvQuanLyThu.Rows[iRow].Cells[4].Value;

            cbxTenThanhVien.Text = ten.ToString();
            tbSoTien.Text = soTien.ToString();
            dtpNgay.Value = Convert.ToDateTime(ngay);

            if (loai.ToString() == "Chung")
            {
                cbxLoaiThu.Text = "Chung";
            }
            else
            {
                cbxLoaiThu.Text = "Riêng";
            }

            btSua.Enabled = true;
            btXoa.Enabled = false;
            btThem.Enabled = false;

            co_them = 0;
            co_sua = 1;
            co_xoa = 0;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (cbxLoaiThu.Text != string.Empty
                && cbxTenThanhVien.Text != string.Empty
                && tbSoTien.Text != string.Empty)
            {
                try
                {
                    if (cbxLoaiThu.Text == "Chung")
                    {
                        string ID = Service.ID_Khoan_chi_Gia_dinh_Tu_tang().ToString();
                        string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);
                        string soTien = tbSoTien.Text;
                        string ID_Gia_dinh = "1";
                        Service.Them_Khoan_thu_Gia_dinh(ID, Ngay, soTien, ID_Gia_dinh);
                    }
                    else
                    {
                        string ID = Service.ID_Khoan_chi_Thanh_vien_Tu_tang().ToString();
                        string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);
                        string soTien = tbSoTien.Text;
                        string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(cbxTenThanhVien.Text);
                        Service.Them_Khoan_thu_Thanh_vien(ID, Ngay, soTien, ID_Thanh_vien);
                    }

                    Nap_Du_lieu_Len_DataGridView();
                    //dgvQuanLyThu.ClearSelection();
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

            if (result == DialogResult.Yes)
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
            int iRow = dgvQuanLyThu.CurrentCell.RowIndex;
            string ID = dgvQuanLyThu.Rows[iRow].Cells[0].Value.ToString();
            string loai = dgvQuanLyThu.Rows[iRow].Cells[4].Value.ToString();


            if (loai == "Chung")
            {
                string ID_Gia_dinh = "1";
                Service.Xoa_Khoan_thu_Gia_dinh(ID, ID_Gia_dinh);
            }
            else
            {
                string Ten_Thanh_vien = dgvQuanLyThu.Rows[iRow].Cells[1].Value.ToString();
                string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(Ten_Thanh_vien);
                Service.Xoa_Khoan_thu_Thanh_vien(ID, ID_Thanh_vien);
            }

            Nap_Du_lieu_Len_DataGridView(); //nạp lại dữ liệu
            dgvQuanLyThu.Update();

            tbSoTien.Text = string.Empty;
            dtpNgay.Value = DateTime.Now;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int iRow = dgvQuanLyThu.CurrentCell.RowIndex;

            string Ngay = Chuyen_ve_Dung_Dinh_dang(dtpNgay.Value);

            string So_tien = tbSoTien.Text;

            string loai = dgvQuanLyThu.Rows[iRow].Cells[4].Value.ToString();

            string ID = dgvQuanLyThu.Rows[iRow].Cells[0].Value.ToString();

            if (loai == "Chung")
            {
                string ID_Gia_dinh = "1";
                Service.Cap_nhat_Khoan_thu_Gia_dinh(ID, Ngay, So_tien, ID_Gia_dinh);
            }
            else
            {
                string Ten_Thanh_vien = cbxTenThanhVien.Text.Trim();
                string ID_Thanh_vien = Service.Lay_ID_Thanh_vien(Ten_Thanh_vien);
                Service.Cap_nhat_Khoan_thu_Thanh_vien(ID, Ngay, So_tien, ID_Thanh_vien);
            }

            Nap_Du_lieu_Len_DataGridView(); //nạp lại dữ liệu

            dgvQuanLyThu.Update();
        }
    }
}
