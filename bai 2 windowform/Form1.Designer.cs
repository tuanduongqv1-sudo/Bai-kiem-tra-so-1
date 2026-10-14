namespace Bai_2_windowform
{
    partial class Form1
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
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblNguoiYeucau = new System.Windows.Forms.Label();
            this.lblNgayGhiNhan = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtNguoiYeuCau = new System.Windows.Forms.TextBox();
            this.rdoThap = new System.Windows.Forms.RadioButton();
            this.rdoTrungBinh = new System.Windows.Forms.RadioButton();
            this.grpUuTien = new System.Windows.Forms.GroupBox();
            this.dtpNgayGhiNhan = new System.Windows.Forms.DateTimePicker();
            this.rdoKhanCap = new System.Windows.Forms.RadioButton();
            this.lblLoaiSuCo = new System.Windows.Forms.Label();
            this.lblThietBi = new System.Windows.Forms.Label();
            this.cboLoaiSuCo = new System.Windows.Forms.ComboBox();
            this.chkMayTinhBan = new System.Windows.Forms.CheckBox();
            this.chkLaptop = new System.Windows.Forms.CheckBox();
            this.chkMayIn = new System.Windows.Forms.CheckBox();
            this.chkDienThoai = new System.Windows.Forms.CheckBox();
            this.picAnhLoi = new System.Windows.Forms.PictureBox();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.grpUuTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(171, 90);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(65, 16);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "Mã phiếu ";
            // 
            // lblNguoiYeucau
            // 
            this.lblNguoiYeucau.AutoSize = true;
            this.lblNguoiYeucau.Location = new System.Drawing.Point(171, 130);
            this.lblNguoiYeucau.Name = "lblNguoiYeucau";
            this.lblNguoiYeucau.Size = new System.Drawing.Size(96, 16);
            this.lblNguoiYeucau.TabIndex = 1;
            this.lblNguoiYeucau.Text = "Người yêu cầu ";
            // 
            // lblNgayGhiNhan
            // 
            this.lblNgayGhiNhan.AutoSize = true;
            this.lblNgayGhiNhan.Location = new System.Drawing.Point(171, 186);
            this.lblNgayGhiNhan.Name = "lblNgayGhiNhan";
            this.lblNgayGhiNhan.Size = new System.Drawing.Size(96, 16);
            this.lblNgayGhiNhan.TabIndex = 2;
            this.lblNgayGhiNhan.Text = "Ngày ghi nhận ";
            this.lblNgayGhiNhan.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(343, 87);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(100, 22);
            this.txtMaPhieu.TabIndex = 3;
            // 
            // txtNguoiYeuCau
            // 
            this.txtNguoiYeuCau.Location = new System.Drawing.Point(343, 130);
            this.txtNguoiYeuCau.Name = "txtNguoiYeuCau";
            this.txtNguoiYeuCau.Size = new System.Drawing.Size(100, 22);
            this.txtNguoiYeuCau.TabIndex = 4;
            // 
            // rdoThap
            // 
            this.rdoThap.AutoSize = true;
            this.rdoThap.Location = new System.Drawing.Point(20, 35);
            this.rdoThap.Name = "rdoThap";
            this.rdoThap.Size = new System.Drawing.Size(63, 20);
            this.rdoThap.TabIndex = 5;
            this.rdoThap.TabStop = true;
            this.rdoThap.Text = "Thấp ";
            this.rdoThap.UseVisualStyleBackColor = true;
            this.rdoThap.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoTrungBinh
            // 
            this.rdoTrungBinh.AutoSize = true;
            this.rdoTrungBinh.Location = new System.Drawing.Point(153, 35);
            this.rdoTrungBinh.Name = "rdoTrungBinh";
            this.rdoTrungBinh.Size = new System.Drawing.Size(91, 20);
            this.rdoTrungBinh.TabIndex = 6;
            this.rdoTrungBinh.TabStop = true;
            this.rdoTrungBinh.Text = "Trung bình";
            this.rdoTrungBinh.UseVisualStyleBackColor = true;
            // 
            // grpUuTien
            // 
            this.grpUuTien.Controls.Add(this.rdoKhanCap);
            this.grpUuTien.Controls.Add(this.rdoThap);
            this.grpUuTien.Controls.Add(this.rdoTrungBinh);
            this.grpUuTien.Location = new System.Drawing.Point(174, 230);
            this.grpUuTien.Name = "grpUuTien";
            this.grpUuTien.Size = new System.Drawing.Size(422, 75);
            this.grpUuTien.TabIndex = 8;
            this.grpUuTien.TabStop = false;
            this.grpUuTien.Text = "Mức độ ưu tiên ";
            // 
            // dtpNgayGhiNhan
            // 
            this.dtpNgayGhiNhan.Location = new System.Drawing.Point(343, 180);
            this.dtpNgayGhiNhan.Name = "dtpNgayGhiNhan";
            this.dtpNgayGhiNhan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayGhiNhan.TabIndex = 9;
            this.dtpNgayGhiNhan.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rdoKhanCap
            // 
            this.rdoKhanCap.AutoSize = true;
            this.rdoKhanCap.Location = new System.Drawing.Point(294, 35);
            this.rdoKhanCap.Name = "rdoKhanCap";
            this.rdoKhanCap.Size = new System.Drawing.Size(87, 20);
            this.rdoKhanCap.TabIndex = 7;
            this.rdoKhanCap.TabStop = true;
            this.rdoKhanCap.Text = "Khẩn cấp ";
            this.rdoKhanCap.UseVisualStyleBackColor = true;
            // 
            // lblLoaiSuCo
            // 
            this.lblLoaiSuCo.AutoSize = true;
            this.lblLoaiSuCo.Location = new System.Drawing.Point(171, 343);
            this.lblLoaiSuCo.Name = "lblLoaiSuCo";
            this.lblLoaiSuCo.Size = new System.Drawing.Size(71, 16);
            this.lblLoaiSuCo.TabIndex = 10;
            this.lblLoaiSuCo.Text = "Loại sự cố ";
            // 
            // lblThietBi
            // 
            this.lblThietBi.AutoSize = true;
            this.lblThietBi.Location = new System.Drawing.Point(169, 410);
            this.lblThietBi.Name = "lblThietBi";
            this.lblThietBi.Size = new System.Drawing.Size(119, 16);
            this.lblThietBi.TabIndex = 11;
            this.lblThietBi.Text = "Thiết bị ảnh hưởng ";
            // 
            // cboLoaiSuCo
            // 
            this.cboLoaiSuCo.FormattingEnabled = true;
            this.cboLoaiSuCo.Location = new System.Drawing.Point(167, 377);
            this.cboLoaiSuCo.Name = "cboLoaiSuCo";
            this.cboLoaiSuCo.Size = new System.Drawing.Size(121, 24);
            this.cboLoaiSuCo.TabIndex = 16;
            // 
            // chkMayTinhBan
            // 
            this.chkMayTinhBan.AutoSize = true;
            this.chkMayTinhBan.Location = new System.Drawing.Point(172, 442);
            this.chkMayTinhBan.Name = "chkMayTinhBan";
            this.chkMayTinhBan.Size = new System.Drawing.Size(104, 20);
            this.chkMayTinhBan.TabIndex = 17;
            this.chkMayTinhBan.Text = "Máy tính bàn";
            this.chkMayTinhBan.UseVisualStyleBackColor = true;
            // 
            // chkLaptop
            // 
            this.chkLaptop.AutoSize = true;
            this.chkLaptop.Location = new System.Drawing.Point(343, 442);
            this.chkLaptop.Name = "chkLaptop";
            this.chkLaptop.Size = new System.Drawing.Size(71, 20);
            this.chkLaptop.TabIndex = 18;
            this.chkLaptop.Text = "Laptop";
            this.chkLaptop.UseVisualStyleBackColor = true;
            // 
            // chkMayIn
            // 
            this.chkMayIn.AutoSize = true;
            this.chkMayIn.Location = new System.Drawing.Point(174, 478);
            this.chkMayIn.Name = "chkMayIn";
            this.chkMayIn.Size = new System.Drawing.Size(71, 20);
            this.chkMayIn.TabIndex = 19;
            this.chkMayIn.Text = "Máy in ";
            this.chkMayIn.UseVisualStyleBackColor = true;
            // 
            // chkDienThoai
            // 
            this.chkDienThoai.AutoSize = true;
            this.chkDienThoai.Location = new System.Drawing.Point(339, 478);
            this.chkDienThoai.Name = "chkDienThoai";
            this.chkDienThoai.Size = new System.Drawing.Size(91, 20);
            this.chkDienThoai.TabIndex = 20;
            this.chkDienThoai.Text = "Điện thoại ";
            this.chkDienThoai.UseVisualStyleBackColor = true;
            // 
            // picAnhLoi
            // 
            this.picAnhLoi.Location = new System.Drawing.Point(148, 555);
            this.picAnhLoi.Name = "picAnhLoi";
            this.picAnhLoi.Size = new System.Drawing.Size(380, 83);
            this.picAnhLoi.TabIndex = 21;
            this.picAnhLoi.TabStop = false;
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Location = new System.Drawing.Point(203, 730);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(120, 23);
            this.btnTaiAnh.TabIndex = 22;
            this.btnTaiAnh.Text = "Tải ảnh lỗi";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            this.btnTaiAnh.Click += new System.EventHandler(this.btnTaiAnh_Click);
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(277, 685);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(120, 23);
            this.btnGuiYeuCau.TabIndex = 23;
            this.btnGuiYeuCau.Text = "Gửi Yêu Cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(356, 730);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(120, 23);
            this.btnNhapLai.TabIndex = 24;
            this.btnNhapLai.Text = "Nhập lại ";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 830);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.btnTaiAnh);
            this.Controls.Add(this.picAnhLoi);
            this.Controls.Add(this.chkDienThoai);
            this.Controls.Add(this.chkMayIn);
            this.Controls.Add(this.chkLaptop);
            this.Controls.Add(this.chkMayTinhBan);
            this.Controls.Add(this.cboLoaiSuCo);
            this.Controls.Add(this.lblThietBi);
            this.Controls.Add(this.lblLoaiSuCo);
            this.Controls.Add(this.dtpNgayGhiNhan);
            this.Controls.Add(this.grpUuTien);
            this.Controls.Add(this.txtNguoiYeuCau);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.lblNgayGhiNhan);
            this.Controls.Add(this.lblNguoiYeucau);
            this.Controls.Add(this.lblMaPhieu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpUuTien.ResumeLayout(false);
            this.grpUuTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label lblNguoiYeucau;
        private System.Windows.Forms.Label lblNgayGhiNhan;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtNguoiYeuCau;
        private System.Windows.Forms.RadioButton rdoThap;
        private System.Windows.Forms.RadioButton rdoTrungBinh;
        private System.Windows.Forms.GroupBox grpUuTien;
        private System.Windows.Forms.DateTimePicker dtpNgayGhiNhan;
        private System.Windows.Forms.RadioButton rdoKhanCap;
        private System.Windows.Forms.Label lblLoaiSuCo;
        private System.Windows.Forms.Label lblThietBi;
        private System.Windows.Forms.ComboBox cboLoaiSuCo;
        private System.Windows.Forms.CheckBox chkMayTinhBan;
        private System.Windows.Forms.CheckBox chkLaptop;
        private System.Windows.Forms.CheckBox chkMayIn;
        private System.Windows.Forms.CheckBox chkDienThoai;
        private System.Windows.Forms.PictureBox picAnhLoi;
        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnNhapLai;
    }
}

