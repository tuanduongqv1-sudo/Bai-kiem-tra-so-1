using System.ComponentModel;
using System.Text;

namespace Bai48_AsyncProgressBar
{
    /// <summary>
    /// Form Quản lý Sinh viên - MDI Child với hỗ trợ Async/Await và ProgressBar.
    /// </summary>
    public partial class FormStudent : Form, IProgressNotifier
    {
        private BindingList<Student> studentList = new BindingList<Student>();

        public Action<string>? OnStatusChanged { get; set; }
        public Action<int>? OnProgressChanged { get; set; }

        public FormStudent()
        {
            InitializeComponent();
            SetupBindings();
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

            btnLoadData.Click += BtnLoadData_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnChooseImage.Click += BtnChooseImage_Click;

            ctxXoaDong.Click += (s, e) => BtnDelete_Click(s, e);
            ctxLamMoi.Click += async (s, e) => await LoadDataAsync();
            ctxXemChiTiet.Click += CtxXemChiTiet_Click;
        }

        // ==================== ASYNC/AWAIT - NẠP DỮ LIỆU BẤT ĐỒNG BỘ ====================

        /// <summary>
        /// Nút "Nạp dữ liệu" - gọi async method.
        /// </summary>
        private async void BtnLoadData_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        /// <summary>
        /// Nạp dữ liệu bất đồng bộ sử dụng async/await và IProgress&lt;int&gt;.
        /// UI không bị treo đơ trong quá trình nạp.
        /// </summary>
        private async Task LoadDataAsync()
        {
            // Khóa nút để tránh kích hoạt trùng lặp
            btnLoadData.Enabled = false;
            btnLoadData.Text = "Đang nạp...";
            progressBar1.Visible = true;
            lblProgress.Visible = true;
            progressBar1.Value = 0;
            lblProgress.Text = "0%";

            OnStatusChanged?.Invoke("Đang nạp dữ liệu sinh viên...");
            OnProgressChanged?.Invoke(0);

            try
            {
                // Sử dụng IProgress<int> để cập nhật tiến trình từ background thread về UI thread
                var progress = new Progress<int>(percent =>
                {
                    progressBar1.Value = percent;
                    lblProgress.Text = $"{percent}%";

                    // Cập nhật phần trăm lên StatusStrip của FormMain
                    OnProgressChanged?.Invoke(percent);
                });

                // Gọi phương thức async - UI vẫn responsive trong lúc chờ
                List<Student> loadedStudents = await DataService.LoadStudentsAsync(progress);

                // Xóa dữ liệu cũ và cập nhật binding
                studentList.Clear();

                // Cần clear bindings trước rồi gán lại sau khi add xong
                foreach (var student in loadedStudents)
                {
                    studentList.Add(student);
                }

                // Đặt header
                SetColumnHeaders();

                OnStatusChanged?.Invoke($"Đã nạp xong {loadedStudents.Count} sinh viên!");
                MessageBox.Show($"Nạp thành công {loadedStudents.Count} sinh viên!",
                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Lỗi nạp dữ liệu: {ex.Message}");
                MessageBox.Show($"Lỗi khi nạp dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở lại nút bấm dù thành công hay lỗi
                btnLoadData.Enabled = true;
                btnLoadData.Text = "⏳ Nạp dữ liệu";
                progressBar1.Visible = false;
                lblProgress.Visible = false;
                OnProgressChanged?.Invoke(0); // Ẩn progress trên StatusStrip
            }
        }

        private void SetColumnHeaders()
        {
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
                dgvStudents.Columns["FullName"].HeaderText = "Họ tên";
                dgvStudents.Columns["Age"].HeaderText = "Tuổi";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["AvatarPath"].HeaderText = "Đường dẫn ảnh";
            }
        }

        // ==================== CÁC NÚT CRUD ====================

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
            else { picAvatar.Image?.Dispose(); picAvatar.Image = null; }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            { MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            { MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            foreach (var s in studentList)
                if (s.StudentId == txtStudentId.Text.Trim())
                { MessageBox.Show("Mã SV đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            studentList.Add(new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Age = age,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam"
            });
            bindingSource1.MoveLast();
            OnStatusChanged?.Invoke($"Đã thêm sinh viên: {txtStudentId.Text.Trim()}");
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null) return;
            var student = (Student)bindingSource1.Current;
            if (MessageBox.Show($"Xóa sinh viên {student.StudentId}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string id = student.StudentId;
                bindingSource1.RemoveCurrent();
                OnStatusChanged?.Invoke($"Đã xóa sinh viên: {id}");
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null) return;
            bindingSource1.EndEdit();
            dgvStudents.Refresh();
            OnStatusChanged?.Invoke($"Đã cập nhật sinh viên: {txtStudentId.Text}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is not Student current) return;
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                current.AvatarPath = ofd.FileName;
                LoadAvatarForCurrentStudent();
                dgvStudents.Refresh();
            }
        }

        private void CtxXemChiTiet_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is Student s)
            {
                MessageBox.Show(
                    $"Mã SV: {s.StudentId}\nHọ tên: {s.FullName}\nTuổi: {s.Age}\nGiới tính: {s.Gender}\nAvatar: {(string.IsNullOrEmpty(s.AvatarPath) ? "(Chưa có)" : s.AvatarPath)}",
                    "Chi tiết Sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
