namespace Bai_3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaVT = new System.Windows.Forms.Label();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.lblTenVT = new System.Windows.Forms.Label();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.cboDVT = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnXoaTatCa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.lblDonGia);
            this.groupBox1.Controls.Add(this.cboDVT);
            this.groupBox1.Controls.Add(this.lblDVT);
            this.groupBox1.Controls.Add(this.txtTenVT);
            this.groupBox1.Controls.Add(this.lblTenVT);
            this.groupBox1.Controls.Add(this.txtMaVT);
            this.groupBox1.Controls.Add(this.lblMaVT);
            this.groupBox1.Location = new System.Drawing.Point(72, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 622);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin vật tư ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblMaVT
            // 
            this.lblMaVT.AutoSize = true;
            this.lblMaVT.Location = new System.Drawing.Point(50, 50);
            this.lblMaVT.Name = "lblMaVT";
            this.lblMaVT.Size = new System.Drawing.Size(63, 16);
            this.lblMaVT.TabIndex = 0;
            this.lblMaVT.Text = "Mã vật tư ";
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(53, 84);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(100, 22);
            this.txtMaVT.TabIndex = 1;
            this.txtMaVT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblTenVT
            // 
            this.lblTenVT.AutoSize = true;
            this.lblTenVT.Location = new System.Drawing.Point(53, 123);
            this.lblTenVT.Name = "lblTenVT";
            this.lblTenVT.Size = new System.Drawing.Size(68, 16);
            this.lblTenVT.TabIndex = 2;
            this.lblTenVT.Text = "Tên vật tư ";
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(56, 163);
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.Size = new System.Drawing.Size(100, 22);
            this.txtTenVT.TabIndex = 3;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(56, 209);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(70, 16);
            this.lblDVT.TabIndex = 4;
            this.lblDVT.Text = "Đơn vị tính ";
            this.lblDVT.Click += new System.EventHandler(this.lblDVT_Click);
            // 
            // cboDVT
            // 
            this.cboDVT.FormattingEnabled = true;
            this.cboDVT.Location = new System.Drawing.Point(56, 244);
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.Size = new System.Drawing.Size(121, 24);
            this.cboDVT.TabIndex = 5;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(59, 288);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(53, 16);
            this.lblDonGia.TabIndex = 6;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(62, 324);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaTatCa);
            this.groupBox2.Controls.Add(this.btnXoaDong);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(411, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 467);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách vật tư ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(44, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(475, 262);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã VT";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên VT";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn vị tính ";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá ";
            this.columnHeader4.Width = 120;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(62, 398);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 36);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm mới ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(62, 452);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 36);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Cập nhật ";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(143, 358);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(94, 36);
            this.btnXoaDong.TabIndex = 2;
            this.btnXoaDong.Text = "Xóa dòng ";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnXoaTatCa
            // 
            this.btnXoaTatCa.Location = new System.Drawing.Point(268, 358);
            this.btnXoaTatCa.Name = "btnXoaTatCa";
            this.btnXoaTatCa.Size = new System.Drawing.Size(94, 36);
            this.btnXoaTatCa.TabIndex = 3;
            this.btnXoaTatCa.Text = "Xóa toàn bộ ";
            this.btnXoaTatCa.UseVisualStyleBackColor = true;
            this.btnXoaTatCa.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 821);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.ComboBox cboDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.Label lblTenVT;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.Label lblMaVT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoaTatCa;
        private System.Windows.Forms.Button btnXoaDong;
    }
}

