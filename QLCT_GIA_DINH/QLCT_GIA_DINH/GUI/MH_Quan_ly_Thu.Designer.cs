namespace QLCT_GIA_DINH
{
    partial class MH_Quan_ly_Thu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MH_Quan_ly_Thu));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btSua = new System.Windows.Forms.Button();
            this.dgvQuanLyThu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.tbSoTien = new System.Windows.Forms.TextBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.cbxLoaiThu = new System.Windows.Forms.ComboBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.cbxTenThanhVien = new System.Windows.Forms.ComboBox();
            this.tbTenGiaDinh = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyThu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại thu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(380, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(380, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày:";
            // 
            // btSua
            // 
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.Location = new System.Drawing.Point(212, 139);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(71, 33);
            this.btSua.TabIndex = 7;
            this.btSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // dgvQuanLyThu
            // 
            this.dgvQuanLyThu.AllowUserToAddRows = false;
            this.dgvQuanLyThu.AllowUserToDeleteRows = false;
            this.dgvQuanLyThu.AllowUserToResizeColumns = false;
            this.dgvQuanLyThu.AllowUserToResizeRows = false;
            this.dgvQuanLyThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanLyThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvQuanLyThu.Location = new System.Drawing.Point(9, 7);
            this.dgvQuanLyThu.Name = "dgvQuanLyThu";
            this.dgvQuanLyThu.ReadOnly = true;
            this.dgvQuanLyThu.RowHeadersVisible = false;
            this.dgvQuanLyThu.RowTemplate.Height = 30;
            this.dgvQuanLyThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuanLyThu.Size = new System.Drawing.Size(925, 279);
            this.dgvQuanLyThu.TabIndex = 8;
            this.dgvQuanLyThu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyThu_CellClick);
            this.dgvQuanLyThu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyThu_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Thanh_vien";
            this.Column2.HeaderText = "Tên thành viên";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "So_tien";
            this.Column3.HeaderText = "Số tiền";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Ngay";
            this.Column4.HeaderText = "Ngày";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Loai_thu";
            this.Column5.HeaderText = "Loại thu";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btThem
            // 
            this.btThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btThem.Location = new System.Drawing.Point(10, 139);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(71, 33);
            this.btThem.TabIndex = 5;
            this.btThem.Text = "ADD";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.Location = new System.Drawing.Point(111, 139);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(71, 33);
            this.btXoa.TabIndex = 6;
            this.btXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // tbSoTien
            // 
            this.tbSoTien.Location = new System.Drawing.Point(466, 18);
            this.tbSoTien.Name = "tbSoTien";
            this.tbSoTien.Size = new System.Drawing.Size(181, 26);
            this.tbSoTien.TabIndex = 3;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(466, 65);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(130, 26);
            this.dtpNgay.TabIndex = 4;
            this.dtpNgay.Value = new System.DateTime(2016, 11, 13, 0, 0, 0, 0);
            // 
            // cbxLoaiThu
            // 
            this.cbxLoaiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLoaiThu.FormattingEnabled = true;
            this.cbxLoaiThu.Location = new System.Drawing.Point(146, 19);
            this.cbxLoaiThu.Name = "cbxLoaiThu";
            this.cbxLoaiThu.Size = new System.Drawing.Size(121, 26);
            this.cbxLoaiThu.TabIndex = 1;
            this.cbxLoaiThu.TextChanged += new System.EventHandler(this.cbxLoaiThu_TextChanged);
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTen.Location = new System.Drawing.Point(12, 69);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(128, 19);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên thành viên:";
            // 
            // cbxTenThanhVien
            // 
            this.cbxTenThanhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTenThanhVien.FormattingEnabled = true;
            this.cbxTenThanhVien.Location = new System.Drawing.Point(146, 66);
            this.cbxTenThanhVien.Name = "cbxTenThanhVien";
            this.cbxTenThanhVien.Size = new System.Drawing.Size(182, 26);
            this.cbxTenThanhVien.TabIndex = 2;
            // 
            // tbTenGiaDinh
            // 
            this.tbTenGiaDinh.Location = new System.Drawing.Point(145, 66);
            this.tbTenGiaDinh.Name = "tbTenGiaDinh";
            this.tbTenGiaDinh.Size = new System.Drawing.Size(182, 26);
            this.tbTenGiaDinh.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxTenThanhVien);
            this.panel1.Controls.Add(this.tbTenGiaDinh);
            this.panel1.Controls.Add(this.cbxLoaiThu);
            this.panel1.Controls.Add(this.lbTen);
            this.panel1.Controls.Add(this.tbSoTien);
            this.panel1.Controls.Add(this.dtpNgay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 121);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.dgvQuanLyThu);
            this.panel2.Location = new System.Drawing.Point(10, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 291);
            this.panel2.TabIndex = 11;
            // 
            // MH_Quan_ly_Thu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 481);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btXoa);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MH_Quan_ly_Thu";
            this.Text = "MÀN HÌNH QUẢN LÝ THU";
            this.Load += new System.EventHandler(this.MH_Quan_ly_Thu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.DataGridView dgvQuanLyThu;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.TextBox tbSoTien;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox cbxLoaiThu;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.ComboBox cbxTenThanhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox tbTenGiaDinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}