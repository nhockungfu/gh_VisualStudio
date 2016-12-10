namespace QLCT_GIA_DINH
{
    partial class MH_Quan_ly_Chi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MH_Quan_ly_Chi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSoTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLoaiChi = new System.Windows.Forms.ComboBox();
            this.cbxTenThanhVien = new System.Windows.Forms.ComboBox();
            this.tbTenGiaDinh = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvQuan_ly_Chi = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuan_ly_Chi)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTen.Location = new System.Drawing.Point(7, 67);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(128, 19);
            this.lbTen.TabIndex = 0;
            this.lbTen.Text = "Tên thành viên:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(357, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số tiền:";
            // 
            // tbSoTien
            // 
            this.tbSoTien.Location = new System.Drawing.Point(424, 18);
            this.tbSoTien.Name = "tbSoTien";
            this.tbSoTien.Size = new System.Drawing.Size(178, 26);
            this.tbSoTien.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(357, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(424, 61);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(133, 26);
            this.dtpNgay.TabIndex = 4;
            this.dtpNgay.Value = new System.DateTime(2016, 11, 13, 15, 6, 0, 0);
            // 
            // btSua
            // 
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSua.Location = new System.Drawing.Point(241, 129);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(71, 32);
            this.btSua.TabIndex = 7;
            this.btSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btXoa.Location = new System.Drawing.Point(126, 129);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(71, 32);
            this.btXoa.TabIndex = 6;
            this.btXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThem
            // 
            this.btThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btThem.Location = new System.Drawing.Point(11, 129);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(71, 32);
            this.btThem.TabIndex = 5;
            this.btThem.Text = "ADD";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại chi:";
            // 
            // cbxLoaiChi
            // 
            this.cbxLoaiChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLoaiChi.FormattingEnabled = true;
            this.cbxLoaiChi.Location = new System.Drawing.Point(145, 18);
            this.cbxLoaiChi.Name = "cbxLoaiChi";
            this.cbxLoaiChi.Size = new System.Drawing.Size(121, 26);
            this.cbxLoaiChi.TabIndex = 1;
            this.cbxLoaiChi.TextChanged += new System.EventHandler(this.cbLoaiChi_TextChanged);
            // 
            // cbxTenThanhVien
            // 
            this.cbxTenThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTenThanhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTenThanhVien.FormattingEnabled = true;
            this.cbxTenThanhVien.Location = new System.Drawing.Point(145, 64);
            this.cbxTenThanhVien.Name = "cbxTenThanhVien";
            this.cbxTenThanhVien.Size = new System.Drawing.Size(179, 26);
            this.cbxTenThanhVien.TabIndex = 2;
            // 
            // tbTenGiaDinh
            // 
            this.tbTenGiaDinh.Location = new System.Drawing.Point(145, 64);
            this.tbTenGiaDinh.Name = "tbTenGiaDinh";
            this.tbTenGiaDinh.Size = new System.Drawing.Size(179, 26);
            this.tbTenGiaDinh.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbTenGiaDinh);
            this.panel1.Controls.Add(this.cbxTenThanhVien);
            this.panel1.Controls.Add(this.lbTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxLoaiChi);
            this.panel1.Controls.Add(this.tbSoTien);
            this.panel1.Controls.Add(this.dtpNgay);
            this.panel1.Location = new System.Drawing.Point(12, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 106);
            this.panel1.TabIndex = 11;
            // 
            // dgvQuan_ly_Chi
            // 
            this.dgvQuan_ly_Chi.AllowUserToAddRows = false;
            this.dgvQuan_ly_Chi.AllowUserToDeleteRows = false;
            this.dgvQuan_ly_Chi.AllowUserToResizeColumns = false;
            this.dgvQuan_ly_Chi.AllowUserToResizeRows = false;
            this.dgvQuan_ly_Chi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuan_ly_Chi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuan_ly_Chi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuan_ly_Chi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuan_ly_Chi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvQuan_ly_Chi.Location = new System.Drawing.Point(6, 6);
            this.dgvQuan_ly_Chi.MultiSelect = false;
            this.dgvQuan_ly_Chi.Name = "dgvQuan_ly_Chi";
            this.dgvQuan_ly_Chi.ReadOnly = true;
            this.dgvQuan_ly_Chi.RowHeadersVisible = false;
            this.dgvQuan_ly_Chi.RowTemplate.Height = 30;
            this.dgvQuan_ly_Chi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuan_ly_Chi.Size = new System.Drawing.Size(967, 319);
            this.dgvQuan_ly_Chi.TabIndex = 8;
            this.dgvQuan_ly_Chi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuan_ly_Chi_CellClick);
            this.dgvQuan_ly_Chi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuan_ly_Chi_CellDoubleClick);
            this.dgvQuan_ly_Chi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvQuan_ly_Chi_KeyDown);
            this.dgvQuan_ly_Chi.MouseLeave += new System.EventHandler(this.dgvQuan_ly_Chi_MouseLeave);
            // 
            // Column0
            // 
            this.Column0.DataPropertyName = "ID";
            this.Column0.HeaderText = "ID";
            this.Column0.Name = "Column0";
            this.Column0.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Thanh_vien";
            this.Column1.HeaderText = "Tên thành viên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "So_tien";
            this.Column2.HeaderText = "Số tiền";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Ngay";
            this.Column3.HeaderText = "Ngày";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Loai_chi";
            this.Column4.HeaderText = "Loại chi";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
            this.panel3.Controls.Add(this.dgvQuan_ly_Chi);
            this.panel3.Location = new System.Drawing.Point(12, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 332);
            this.panel3.TabIndex = 13;
            // 
            // MH_Quan_ly_Chi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1005, 521);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btSua);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MH_Quan_ly_Chi";
            this.Text = "MÀN HÌNH QUẢN LÝ CHI";
            this.Load += new System.EventHandler(this.MH_Quan_ly_Chi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuan_ly_Chi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLoaiChi;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.ComboBox cbxTenThanhVien;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.TextBox tbTenGiaDinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvQuan_ly_Chi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel panel3;
    }
}