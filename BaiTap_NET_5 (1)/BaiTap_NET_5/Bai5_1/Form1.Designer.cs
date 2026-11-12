namespace Bai5_1
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
            this.components = new System.ComponentModel.Container();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.grpExtra = new System.Windows.Forms.GroupBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.lblGender = new System.Windows.Forms.Label();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.epCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpPersonal.SuspendLayout();
            this.grpExtra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCheck)).BeginInit();
            this.SuspendLayout();
            //
            // grpPersonal
            //
            this.grpPersonal.Controls.Add(this.lblUsername);
            this.grpPersonal.Controls.Add(this.txtUsername);
            this.grpPersonal.Controls.Add(this.lblPassword);
            this.grpPersonal.Controls.Add(this.txtPassword);
            this.grpPersonal.Controls.Add(this.lblConfirm);
            this.grpPersonal.Controls.Add(this.txtConfirm);
            this.grpPersonal.Location = new System.Drawing.Point(15, 15);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(420, 135);
            this.grpPersonal.TabIndex = 0;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Thông tin cá nhân";
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Tên đăng nhập:";
            //
            // txtUsername
            //
            this.txtUsername.Location = new System.Drawing.Point(140, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.ClearError_Changed);
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Mật khẩu:";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(140, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.ClearError_Changed);
            //
            // lblConfirm
            //
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(15, 100);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Text = "Xác nhận mật khẩu:";
            //
            // txtConfirm
            //
            this.txtConfirm.Location = new System.Drawing.Point(140, 97);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(240, 23);
            this.txtConfirm.TabIndex = 2;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.TextChanged += new System.EventHandler(this.ClearError_Changed);
            //
            // grpExtra
            //
            this.grpExtra.Controls.Add(this.lblBirth);
            this.grpExtra.Controls.Add(this.dtpBirth);
            this.grpExtra.Controls.Add(this.lblGender);
            this.grpExtra.Controls.Add(this.rdoMale);
            this.grpExtra.Controls.Add(this.rdoFemale);
            this.grpExtra.Controls.Add(this.chkTerms);
            this.grpExtra.Location = new System.Drawing.Point(15, 160);
            this.grpExtra.Name = "grpExtra";
            this.grpExtra.Size = new System.Drawing.Size(420, 150);
            this.grpExtra.TabIndex = 1;
            this.grpExtra.TabStop = false;
            this.grpExtra.Text = "Thông tin bổ sung";
            //
            // lblBirth
            //
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(15, 30);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Text = "Ngày sinh:";
            //
            // dtpBirth
            //
            this.dtpBirth.CustomFormat = "dd/MM/yyyy";
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirth.Location = new System.Drawing.Point(140, 27);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(140, 23);
            this.dtpBirth.TabIndex = 3;
            this.dtpBirth.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpBirth.ValueChanged += new System.EventHandler(this.ClearError_Changed);
            //
            // lblGender
            //
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(15, 68);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Giới tính:";
            //
            // rdoMale
            //
            this.rdoMale.AutoSize = true;
            this.rdoMale.Checked = true;
            this.rdoMale.Location = new System.Drawing.Point(140, 66);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.TabIndex = 4;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Nam";
            //
            // rdoFemale
            //
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(220, 66);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.TabIndex = 5;
            this.rdoFemale.Text = "Nữ";
            //
            // chkTerms
            //
            this.chkTerms.AutoSize = true;
            this.chkTerms.Location = new System.Drawing.Point(140, 105);
            this.chkTerms.Name = "chkTerms";
            this.chkTerms.TabIndex = 6;
            this.chkTerms.Text = "Tôi đồng ý với điều khoản dịch vụ";
            this.chkTerms.CheckedChanged += new System.EventHandler(this.ClearError_Changed);
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(110, 325);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 35);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(240, 325);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 35);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Làm Mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // epCheck
            //
            this.epCheck.ContainerControl = this;
            //
            // Form1
            //
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 380);
            this.Controls.Add(this.grpPersonal);
            this.Controls.Add(this.grpExtra);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.grpExtra.ResumeLayout(false);
            this.grpExtra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCheck)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.GroupBox grpExtra;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.CheckBox chkTerms;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ErrorProvider epCheck;
    }
}
