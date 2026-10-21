namespace Bai46_QuanLySinhVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ===== Controls =====
            this.dgvStudents = new DataGridView();
            this.grpInput = new GroupBox();
            this.lblStudentId = new Label();
            this.txtStudentId = new TextBox();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblAge = new Label();
            this.txtAge = new TextBox();
            this.lblGender = new Label();
            this.cboGender = new ComboBox();
            this.lblAvatar = new Label();
            this.picAvatar = new PictureBox();
            this.btnChooseImage = new Button();
            this.grpActions = new GroupBox();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.btnExportCSV = new Button();
            this.bindingSource1 = new BindingSource(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.grpInput.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // ===== DataGridView =====
            this.dgvStudents.Location = new Point(12, 12);
            this.dgvStudents.Size = new Size(560, 280);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = SystemColors.Window;
            this.dgvStudents.RowHeadersWidth = 30;

            // ===== Group Input =====
            this.grpInput.Text = "Thông tin Sinh viên";
            this.grpInput.Location = new Point(12, 300);
            this.grpInput.Size = new Size(400, 260);
            this.grpInput.Controls.Add(this.lblStudentId);
            this.grpInput.Controls.Add(this.txtStudentId);
            this.grpInput.Controls.Add(this.lblFullName);
            this.grpInput.Controls.Add(this.txtFullName);
            this.grpInput.Controls.Add(this.lblAge);
            this.grpInput.Controls.Add(this.txtAge);
            this.grpInput.Controls.Add(this.lblGender);
            this.grpInput.Controls.Add(this.cboGender);

            // Mã SV
            this.lblStudentId.Text = "Mã SV:";
            this.lblStudentId.Location = new Point(15, 30);
            this.lblStudentId.Size = new Size(80, 23);
            this.lblStudentId.TextAlign = ContentAlignment.MiddleLeft;

            this.txtStudentId.Location = new Point(100, 30);
            this.txtStudentId.Size = new Size(280, 23);
            this.txtStudentId.Name = "txtStudentId";

            // Họ tên
            this.lblFullName.Text = "Họ tên:";
            this.lblFullName.Location = new Point(15, 65);
            this.lblFullName.Size = new Size(80, 23);
            this.lblFullName.TextAlign = ContentAlignment.MiddleLeft;

            this.txtFullName.Location = new Point(100, 65);
            this.txtFullName.Size = new Size(280, 23);
            this.txtFullName.Name = "txtFullName";

            // Tuổi
            this.lblAge.Text = "Tuổi:";
            this.lblAge.Location = new Point(15, 100);
            this.lblAge.Size = new Size(80, 23);
            this.lblAge.TextAlign = ContentAlignment.MiddleLeft;

            this.txtAge.Location = new Point(100, 100);
            this.txtAge.Size = new Size(280, 23);
            this.txtAge.Name = "txtAge";

            // Giới tính
            this.lblGender.Text = "Giới tính:";
            this.lblGender.Location = new Point(15, 135);
            this.lblGender.Size = new Size(80, 23);
            this.lblGender.TextAlign = ContentAlignment.MiddleLeft;

            this.cboGender.Location = new Point(100, 135);
            this.cboGender.Size = new Size(280, 23);
            this.cboGender.Name = "cboGender";
            this.cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });

            // ===== Avatar Section (inside grpInput) =====
            this.lblAvatar.Text = "Avatar:";
            this.lblAvatar.Location = new Point(15, 175);
            this.lblAvatar.Size = new Size(80, 23);
            this.lblAvatar.TextAlign = ContentAlignment.MiddleLeft;
            this.grpInput.Controls.Add(this.lblAvatar);

            this.picAvatar.Location = new Point(100, 175);
            this.picAvatar.Size = new Size(70, 70);
            this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.BackColor = Color.WhiteSmoke;
            this.grpInput.Controls.Add(this.picAvatar);

            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.Location = new Point(180, 175);
            this.btnChooseImage.Size = new Size(100, 30);
            this.btnChooseImage.Name = "btnChooseImage";
            this.grpInput.Controls.Add(this.btnChooseImage);

            // ===== Group Actions =====
            this.grpActions.Text = "Chức năng";
            this.grpActions.Location = new Point(420, 300);
            this.grpActions.Size = new Size(152, 260);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);
            this.grpActions.Controls.Add(this.btnExportCSV);

            // Thêm
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new Point(15, 30);
            this.btnAdd.Size = new Size(120, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.BackColor = Color.FromArgb(46, 139, 87);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Cursor = Cursors.Hand;

            // Xóa
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new Point(15, 80);
            this.btnDelete.Size = new Size(120, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Cursor = Cursors.Hand;

            // Cập nhật
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new Point(15, 130);
            this.btnUpdate.Size = new Size(120, 40);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.BackColor = Color.FromArgb(0, 123, 255);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Cursor = Cursors.Hand;

            // Xuất CSV
            this.btnExportCSV.Text = "Xuất CSV";
            this.btnExportCSV.Location = new Point(15, 180);
            this.btnExportCSV.Size = new Size(120, 40);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.BackColor = Color.FromArgb(255, 165, 0);
            this.btnExportCSV.ForeColor = Color.White;
            this.btnExportCSV.FlatStyle = FlatStyle.Flat;
            this.btnExportCSV.Cursor = Cursors.Hand;

            // ===== Form =====
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 572);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpActions);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bài 4.6 - Quản lý Sinh viên (BindingSource & File)";

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStudents;
        private GroupBox grpInput;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblAvatar;
        private PictureBox picAvatar;
        private Button btnChooseImage;
        private GroupBox grpActions;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnExportCSV;
        private BindingSource bindingSource1;
    }
}
