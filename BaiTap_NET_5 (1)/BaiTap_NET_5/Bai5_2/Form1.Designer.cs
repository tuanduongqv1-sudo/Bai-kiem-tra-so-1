namespace Bai5_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lstAvailableServices = new System.Windows.Forms.ListBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lstSelectedServices = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblCoupon = new System.Windows.Forms.Label();
            this.lblCouponHint = new System.Windows.Forms.Label();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.btnApplyCoupon = new System.Windows.Forms.Button();
            this.lblFinal = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.grpPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            //
            // lblCategory
            //
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(15, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Loại dịch vụ:";
            //
            // cboCategory
            //
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(110, 17);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(220, 23);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            //
            // lblAvailable
            //
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(15, 55);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Text = "Dịch vụ có thể chọn:";
            //
            // lstAvailableServices
            //
            this.lstAvailableServices.FormattingEnabled = true;
            this.lstAvailableServices.ItemHeight = 15;
            this.lstAvailableServices.Location = new System.Drawing.Point(15, 75);
            this.lstAvailableServices.Name = "lstAvailableServices";
            this.lstAvailableServices.Size = new System.Drawing.Size(250, 169);
            this.lstAvailableServices.TabIndex = 1;
            this.lstAvailableServices.DoubleClick += new System.EventHandler(this.lstAvailableServices_DoubleClick);
            //
            // lblSelected
            //
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(335, 55);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Text = "Dịch vụ đã chọn:";
            //
            // lstSelectedServices
            //
            this.lstSelectedServices.FormattingEnabled = true;
            this.lstSelectedServices.ItemHeight = 15;
            this.lstSelectedServices.Location = new System.Drawing.Point(335, 75);
            this.lstSelectedServices.Name = "lstSelectedServices";
            this.lstSelectedServices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedServices.Size = new System.Drawing.Size(250, 169);
            this.lstSelectedServices.TabIndex = 5;
            this.lstSelectedServices.DoubleClick += new System.EventHandler(this.lstSelectedServices_DoubleClick);
            //
            // btnSelect
            //
            this.btnSelect.Location = new System.Drawing.Point(275, 95);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(50, 30);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            //
            // btnRemove
            //
            this.btnRemove.Location = new System.Drawing.Point(275, 135);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(50, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnClearAll
            //
            this.btnClearAll.Location = new System.Drawing.Point(275, 175);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(50, 30);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "<<";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            //
            // grpPayment
            //
            this.grpPayment.Controls.Add(this.lblTotal);
            this.grpPayment.Controls.Add(this.txtTotal);
            this.grpPayment.Controls.Add(this.lblDiscount);
            this.grpPayment.Controls.Add(this.nudDiscount);
            this.grpPayment.Controls.Add(this.lblCoupon);
            this.grpPayment.Controls.Add(this.lblCouponHint);
            this.grpPayment.Controls.Add(this.txtCoupon);
            this.grpPayment.Controls.Add(this.btnApplyCoupon);
            this.grpPayment.Controls.Add(this.lblFinal);
            this.grpPayment.Controls.Add(this.txtFinal);
            this.grpPayment.Location = new System.Drawing.Point(15, 260);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(570, 140);
            this.grpPayment.TabIndex = 6;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Tính tiền";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Tổng tiền chưa giảm:";
            //
            // txtTotal
            //
            this.txtTotal.Location = new System.Drawing.Point(160, 27);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(140, 23);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblDiscount
            //
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(15, 65);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Text = "Tỷ lệ chiết khấu (%):";
            //
            // nudDiscount
            //
            this.nudDiscount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudDiscount.Location = new System.Drawing.Point(160, 62);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(80, 23);
            this.nudDiscount.TabIndex = 1;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            //
            // lblCoupon
            //
            this.lblCoupon.AutoSize = true;
            this.lblCoupon.Location = new System.Drawing.Point(330, 30);
            this.lblCoupon.Name = "lblCoupon";
            this.lblCoupon.Text = "Mã giảm giá:";
            //
            // lblCouponHint
            //
            this.lblCouponHint.AutoSize = true;
            this.lblCouponHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblCouponHint.Location = new System.Drawing.Point(330, 100);
            this.lblCouponHint.Name = "lblCouponHint";
            this.lblCouponHint.Text = "Mã thử: GIAM10, GIAM20, VIP30";
            //
            // txtCoupon
            //
            this.txtCoupon.Location = new System.Drawing.Point(415, 27);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(130, 23);
            this.txtCoupon.TabIndex = 2;
            //
            // btnApplyCoupon
            //
            this.btnApplyCoupon.Location = new System.Drawing.Point(415, 58);
            this.btnApplyCoupon.Name = "btnApplyCoupon";
            this.btnApplyCoupon.Size = new System.Drawing.Size(130, 28);
            this.btnApplyCoupon.TabIndex = 3;
            this.btnApplyCoupon.Text = "Áp dụng";
            this.btnApplyCoupon.UseVisualStyleBackColor = true;
            this.btnApplyCoupon.Click += new System.EventHandler(this.btnApplyCoupon_Click);
            //
            // lblFinal
            //
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinal.Location = new System.Drawing.Point(15, 102);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Text = "Thành tiền thanh toán:";
            //
            // txtFinal
            //
            this.txtFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtFinal.Location = new System.Drawing.Point(160, 99);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.ReadOnly = true;
            this.txtFinal.Size = new System.Drawing.Size(140, 23);
            this.txtFinal.TabIndex = 4;
            this.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 415);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lstAvailableServices);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lstSelectedServices);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.grpPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng tính tiền dịch vụ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.ListBox lstAvailableServices;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.ListBox lstSelectedServices;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lblCoupon;
        private System.Windows.Forms.Label lblCouponHint;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Button btnApplyCoupon;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.TextBox txtFinal;
    }
}
