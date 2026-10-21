namespace Bai48_AsyncProgressBar
{
    partial class FormStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

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
            this.btnLoadData = new Button();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();

            // ProgressBar + Label phần trăm trên Form con
            this.progressBar1 = new ProgressBar();
            this.lblProgress = new Label();

            this.bindingSource1 = new BindingSource(this.components);

            this.contextMenuDGV = new ContextMenuStrip(this.components);
            this.ctxXoaDong = new ToolStripMenuItem();
            this.ctxLamMoi = new ToolStripMenuItem();
            this.ctxXemChiTiet = new ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.contextMenuDGV.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // ContextMenuStrip
            this.contextMenuDGV.Items.AddRange(new ToolStripItem[] {
                this.ctxXoaDong, this.ctxLamMoi, new ToolStripSeparator(), this.ctxXemChiTiet });
            this.ctxXoaDong.Text = "Xóa dòng";
            this.ctxLamMoi.Text = "Làm mới dữ liệu";
            this.ctxXemChiTiet.Text = "Xem chi tiết";

            // DataGridView
            this.dgvStudents.Location = new Point(12, 12);
            this.dgvStudents.Size = new Size(560, 230);
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = SystemColors.Window;
            this.dgvStudents.ContextMenuStrip = this.contextMenuDGV;

            // ProgressBar
            this.progressBar1.Location = new Point(12, 248);
            this.progressBar1.Size = new Size(480, 22);
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 0;
            this.progressBar1.Visible = false;

            this.lblProgress.Text = "0%";
            this.lblProgress.Location = new Point(500, 248);
            this.lblProgress.Size = new Size(50, 22);
            this.lblProgress.TextAlign = ContentAlignment.MiddleLeft;
            this.lblProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProgress.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblProgress.Visible = false;

            // Group Input
            this.grpInput.Text = "Thông tin Sinh viên";
            this.grpInput.Location = new Point(12, 278);
            this.grpInput.Size = new Size(400, 250);
            this.grpInput.Controls.Add(this.lblStudentId);
            this.grpInput.Controls.Add(this.txtStudentId);
            this.grpInput.Controls.Add(this.lblFullName);
            this.grpInput.Controls.Add(this.txtFullName);
            this.grpInput.Controls.Add(this.lblAge);
            this.grpInput.Controls.Add(this.txtAge);
            this.grpInput.Controls.Add(this.lblGender);
            this.grpInput.Controls.Add(this.cboGender);
            this.grpInput.Controls.Add(this.lblAvatar);
            this.grpInput.Controls.Add(this.picAvatar);
            this.grpInput.Controls.Add(this.btnChooseImage);

            this.lblStudentId.Text = "Mã SV:";
            this.lblStudentId.Location = new Point(15, 30);
            this.lblStudentId.Size = new Size(80, 23);
            this.lblStudentId.TextAlign = ContentAlignment.MiddleLeft;
            this.txtStudentId.Location = new Point(100, 30);
            this.txtStudentId.Size = new Size(280, 23);

            this.lblFullName.Text = "Họ tên:";
            this.lblFullName.Location = new Point(15, 65);
            this.lblFullName.Size = new Size(80, 23);
            this.lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            this.txtFullName.Location = new Point(100, 65);
            this.txtFullName.Size = new Size(280, 23);

            this.lblAge.Text = "Tuổi:";
            this.lblAge.Location = new Point(15, 100);
            this.lblAge.Size = new Size(80, 23);
            this.lblAge.TextAlign = ContentAlignment.MiddleLeft;
            this.txtAge.Location = new Point(100, 100);
            this.txtAge.Size = new Size(280, 23);

            this.lblGender.Text = "Giới tính:";
            this.lblGender.Location = new Point(15, 135);
            this.lblGender.Size = new Size(80, 23);
            this.lblGender.TextAlign = ContentAlignment.MiddleLeft;
            this.cboGender.Location = new Point(100, 135);
            this.cboGender.Size = new Size(280, 23);
            this.cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });

            this.lblAvatar.Text = "Avatar:";
            this.lblAvatar.Location = new Point(15, 175);
            this.lblAvatar.Size = new Size(80, 23);
            this.lblAvatar.TextAlign = ContentAlignment.MiddleLeft;
            this.picAvatar.Location = new Point(100, 175);
            this.picAvatar.Size = new Size(60, 60);
            this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.BackColor = Color.WhiteSmoke;

            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.Location = new Point(170, 175);
            this.btnChooseImage.Size = new Size(100, 30);

            // Group Actions
            this.grpActions.Text = "Chức năng";
            this.grpActions.Location = new Point(420, 278);
            this.grpActions.Size = new Size(152, 250);
            this.grpActions.Controls.Add(this.btnLoadData);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);

            this.btnLoadData.Text = "⏳ Nạp dữ liệu";
            this.btnLoadData.Location = new Point(12, 28);
            this.btnLoadData.Size = new Size(128, 40);
            this.btnLoadData.BackColor = Color.FromArgb(108, 117, 125);
            this.btnLoadData.ForeColor = Color.White;
            this.btnLoadData.FlatStyle = FlatStyle.Flat;
            this.btnLoadData.Cursor = Cursors.Hand;

            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new Point(12, 78);
            this.btnAdd.Size = new Size(128, 38);
            this.btnAdd.BackColor = Color.FromArgb(46, 139, 87);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Cursor = Cursors.Hand;

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new Point(12, 126);
            this.btnDelete.Size = new Size(128, 38);
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Cursor = Cursors.Hand;

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new Point(12, 174);
            this.btnUpdate.Size = new Size(128, 38);
            this.btnUpdate.BackColor = Color.FromArgb(0, 123, 255);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Cursor = Cursors.Hand;

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(585, 540);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpActions);
            this.Name = "FormStudent";
            this.Text = "Quản lý Sinh viên (Async)";

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.contextMenuDGV.ResumeLayout(false);
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
        private Button btnLoadData;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private ProgressBar progressBar1;
        private Label lblProgress;
        private BindingSource bindingSource1;
        private ContextMenuStrip contextMenuDGV;
        private ToolStripMenuItem ctxXoaDong;
        private ToolStripMenuItem ctxLamMoi;
        private ToolStripMenuItem ctxXemChiTiet;
    }
}
