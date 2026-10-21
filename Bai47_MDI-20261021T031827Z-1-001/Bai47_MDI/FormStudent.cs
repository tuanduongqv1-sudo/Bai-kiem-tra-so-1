using System.ComponentModel;
using System.Text;

namespace Bai47_MDI
{
    /// <summary>
    /// Form Quản lý Sinh viên - MDI Child.
    /// Implement IStatusNotifier để giao tiếp với FormMain (MDI Parent).
    /// </summary>
    public partial class FormStudent : Form, IStatusNotifier
    {
        private BindingList<Student> studentList = new BindingList<Student>();

        /// <summary>
        /// Callback truyền thông điệp lên StatusStrip của FormMain.
        /// </summary>
        public Action<string>? OnStatusChanged { get; set; }

        public FormStudent()
        {
            InitializeComponent();
            SetupBindings();
            LoadSampleData();
        }

        private void SetupBindings()
        {
            bindingSource1.DataSource = studentList;

            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.DataSource = bindingSource1;

            txtStudentId.DataBindings.Add("Text", bindingSource1, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource1, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource1, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("SelectedItem", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);

            bindingSource1.CurrentChanged += (s, e) => LoadAvatarForCurrentStudent();

            // Buttons
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnExportCSV.Click += BtnExportCSV_Click;
            btnChooseImage.Click += BtnChooseImage_Click;

            // Context Menu
            ctxXoaDong.Click += CtxXoaDong_Click;
            ctxLamMoi.Click += CtxLamMoi_Click;
            ctxXemChiTiet.Click += CtxXemChiTiet_Click;
        }

        private void LoadSampleData()
        {
            studentList.Add(new Student { StudentId = "SV001", FullName = "Nguyễn Văn A", Age = 20, Gender = "Nam" });
            studentList.Add(new Student { StudentId = "SV002", FullName = "Trần Thị B", Age = 21, Gender = "Nữ" });
            studentList.Add(new Student { StudentId = "SV003", FullName = "Lê Văn C", Age = 22, Gender = "Nam" });

            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
                dgvStudents.Columns["FullName"].HeaderText = "Họ tên";
                dgvStudents.Columns["Age"].HeaderText = "Tuổi";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["AvatarPath"].HeaderText = "Đường dẫn ảnh";
            }
        }

        private void LoadAvatarForCurrentStudent()
        {
            if (bindingSource1.Current is Student current &&
                !string.IsNullOrEmpty(current.AvatarPath) && File.Exists(current.AvatarPath))
            {
                try
                {
                    using var stream = new FileStream(current.AvatarPath, FileMode.Open, FileAccess.Read);
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = Image.FromStream(stream);
                }
                catch { picAvatar.Image?.Dispose(); picAvatar.Image = null; }
            }
            else
            {
                picAvatar.Image?.Dispose();
                picAvatar.Image = null;
            }
        }

        // ==================== NÚT CHỨC NĂNG ====================

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            { MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            { MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            foreach (var s in studentList)
            {
                if (s.StudentId == txtStudentId.Text.Trim())
                { MessageBox.Show("Mã SV đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            studentList.Add(new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Age = age,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam"
            });

            bindingSource1.MoveLast();

            // Gửi thông báo lên FormMain
            OnStatusChanged?.Invoke($"Đã thêm sinh viên: {txtStudentId.Text.Trim()}");

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("Không có sinh viên nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var student = (Student)bindingSource1.Current;
            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {student.StudentId}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string id = student.StudentId;
                bindingSource1.RemoveCurrent();

                // Gửi thông báo lên FormMain
                OnStatusChanged?.Invoke($"Đã xóa sinh viên: {id}");
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("Không có sinh viên nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!int.TryParse(txtAge.Text, out _))
            { MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            bindingSource1.EndEdit();
            dgvStudents.Refresh();

            OnStatusChanged?.Invoke($"Đã cập nhật sinh viên: {txtStudentId.Text}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is not Student current)
            { MessageBox.Show("Vui lòng chọn sinh viên trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh Avatar";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                current.AvatarPath = ofd.FileName;
                LoadAvatarForCurrentStudent();
                dgvStudents.Refresh();
            }
        }

        private void BtnExportCSV_Click(object? sender, EventArgs e)
        {
            if (studentList.Count == 0)
            { MessageBox.Show("Danh sách rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = "DanhSachSinhVien.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var writer = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true));
                    writer.WriteLine("Mã SV,Họ tên,Tuổi,Giới tính,Đường dẫn ảnh");
                    foreach (var s in studentList)
                        writer.WriteLine($"{Esc(s.StudentId)},{Esc(s.FullName)},{s.Age},{Esc(s.Gender)},{Esc(s.AvatarPath)}");

                    OnStatusChanged?.Invoke($"Đã xuất CSV: {sfd.FileName}");
                    MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private string Esc(string f) =>
            string.IsNullOrEmpty(f) ? "" :
            (f.Contains(',') || f.Contains('"') || f.Contains('\n')) ? "\"" + f.Replace("\"", "\"\"") + "\"" : f;

        // ==================== CONTEXT MENU ====================

        /// <summary>
        /// Menu ngữ cảnh: Xóa dòng đang chọn.
        /// </summary>
        private void CtxXoaDong_Click(object? sender, EventArgs e)
        {
            BtnDelete_Click(sender, e);
        }

        /// <summary>
        /// Menu ngữ cảnh: Làm mới dữ liệu (xóa hết rồi nạp lại mẫu).
        /// </summary>
        private void CtxLamMoi_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn làm mới toàn bộ dữ liệu?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                studentList.Clear();
                LoadSampleData();
                OnStatusChanged?.Invoke("Đã làm mới dữ liệu sinh viên");
            }
        }

        /// <summary>
        /// Menu ngữ cảnh: Xem chi tiết sinh viên đang chọn.
        /// </summary>
        private void CtxXemChiTiet_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is Student s)
            {
                string detail = $"Mã SV: {s.StudentId}\n" +
                                $"Họ tên: {s.FullName}\n" +
                                $"Tuổi: {s.Age}\n" +
                                $"Giới tính: {s.Gender}\n" +
                                $"Avatar: {(string.IsNullOrEmpty(s.AvatarPath) ? "(Chưa có)" : s.AvatarPath)}";

                MessageBox.Show(detail, "Chi tiết Sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
