namespace bai_1_windowform
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
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(171, 83);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(101, 16);
            this.lblDonGia.TabIndex = 0;
            this.lblDonGia.Text = "Đơn giá dịch vụ ";
            this.lblDonGia.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(290, 83);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(171, 111);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(99, 16);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng khách";
            this.lblSoLuong.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(290, 112);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 3;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(171, 148);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(64, 16);
            this.lblGiamGia.TabIndex = 4;
            this.lblGiamGia.Text = "Giảm giá ";
            this.lblGiamGia.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(248, 184);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(66, 16);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền ";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(290, 142);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(100, 22);
            this.txtGiamGia.TabIndex = 6;
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(182, 244);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(75, 23);
            this.btnTinhTien.TabIndex = 7;
            this.btnTinhTien.Text = "Tính tiền ";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(300, 244);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới ";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.lblDonGia);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnLamMoi;
    }
}

