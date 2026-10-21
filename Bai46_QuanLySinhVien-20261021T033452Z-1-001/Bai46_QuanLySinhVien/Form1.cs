using System.ComponentModel;
using System.Text;

namespace Bai46_QuanLySinhVien
{
    public partial class Form1 : Form
    {
        // Danh sách sinh viên sử dụng BindingList để hỗ trợ Data Binding hai chiều
        private BindingList<Student> studentList = new BindingList<Student>();

        public Form1()
        {
            InitializeComponent();
            SetupBindings();
            LoadSampleData();
        }

        /// <summary>
        /// Cấu hình BindingSource liên kết 2 chiều giữa BindingList, DataGridView và các Control nhập liệu.
        /// </summary>
        private void SetupBindings()
        {
            // Gán DataSource cho BindingSource
            bindingSource1.DataSource = studentList;

            // Cấu hình DataGridView - phải set AutoGenerateColumns TRƯỚC khi gán DataSource
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.DataSource = bindingSource1;

            // Data Binding hai chiều cho các TextBox và ComboBox
            txtStudentId.DataBindings.Add("Text", bindingSource1, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource1, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource1, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("SelectedItem", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);

            // Sự kiện khi thay đổi dòng được chọn → cập nhật PictureBox
            bindingSource1.CurrentChanged += BindingSource1_CurrentChanged;

            // Sự kiện các nút chức năng
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnExportCSV.Click += BtnExportCSV_Click;
            btnChooseImage.Click += BtnChooseImage_Click;
        }

        /// <summary>
        /// Nạp một số dữ liệu mẫu để test.
        /// </summary>
        private void LoadSampleData()
        {
            studentList.Add(new Student { StudentId = "SV001", FullName = "Nguyễn Văn A", Age = 20, Gender = "Nam", AvatarPath = "" });
            studentList.Add(new Student { StudentId = "SV002", FullName = "Trần Thị B", Age = 21, Gender = "Nữ", AvatarPath = "" });
            studentList.Add(new Student { StudentId = "SV003", FullName = "Lê Văn C", Age = 22, Gender = "Nam", AvatarPath = "" });

            // Đặt header cho DataGridView
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
                dgvStudents.Columns["FullName"].HeaderText = "Họ tên";
                dgvStudents.Columns["Age"].HeaderText = "Tuổi";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["AvatarPath"].HeaderText = "Đường dẫn ảnh";
            }
        }

        /// <summary>
        /// Khi chọn dòng khác trên DataGridView, PictureBox tự động nạp ảnh từ AvatarPath.
        /// </summary>
        private void BindingSource1_CurrentChanged(object? sender, EventArgs e)
        {
            LoadAvatarForCurrentStudent();
        }

        /// <summary>
        /// Nạp ảnh avatar cho sinh viên đang được chọn.
        /// </summary>
        private void LoadAvatarForCurrentStudent()
        {
            if (bindingSource1.Current is Student currentStudent)
            {
                if (!string.IsNullOrEmpty(currentStudent.AvatarPath) && File.Exists(currentStudent.AvatarPath))
                {
                    try
                    {
                        // Dùng stream để không lock file
                        using (var stream = new FileStream(currentStudent.AvatarPath, FileMode.Open, FileAccess.Read))
                        {
                            picAvatar.Image?.Dispose();
                            picAvatar.Image = Image.FromStream(stream);
                        }
                    }
                    catch
                    {
                        picAvatar.Image?.Dispose();
                        picAvatar.Image = null;
                    }
                }
                else
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = null;
                }
            }
        }

        /// <summary>
        /// Nút Thêm: Thêm một sinh viên mới vào danh sách.
        /// </summary>
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            // Kiểm tra trùng mã SV
            foreach (var s in studentList)
            {
                if (s.StudentId == txtStudentId.Text.Trim())
                {
                    MessageBox.Show("Mã SV đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Thêm sinh viên mới
            var newStudent = new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Age = age,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                AvatarPath = ""
            };

            studentList.Add(newStudent);

            // Di chuyển đến dòng vừa thêm
            bindingSource1.MoveLast();

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Nút Xóa: Xóa sinh viên đang được chọn.
        /// </summary>
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("Không có sinh viên nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
                MessageBox.Show("Đã xóa sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Nút Cập nhật: Vì sử dụng Data Binding hai chiều, dữ liệu đã tự động cập nhật.
        /// Nút này chỉ cần kết thúc chỉnh sửa và refresh lại DataGridView.
        /// </summary>
        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("Không có sinh viên nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate tuổi
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            // Kết thúc chỉnh sửa hiện tại
            bindingSource1.EndEdit();

            // Refresh DataGridView
            dgvStudents.Refresh();

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Nút Chọn ảnh: Mở OpenFileDialog để chọn file ảnh (.jpg, .png, .bmp),
        /// gán đường dẫn vào sinh viên đang chọn và hiển thị lên PictureBox.
        /// </summary>
        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is not Student currentStudent)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh Avatar";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Gán đường dẫn vào sinh viên đang chọn
                    currentStudent.AvatarPath = ofd.FileName;

                    // Hiển thị ảnh lên PictureBox
                    LoadAvatarForCurrentStudent();

                    // Refresh DataGridView để cập nhật cột AvatarPath
                    dgvStudents.Refresh();
                }
            }
        }

        /// <summary>
        /// Nút Xuất CSV: Sử dụng SaveFileDialog để chọn nơi lưu file .csv.
        /// Ghi toàn bộ danh sách sinh viên ra file CSV (UTF-8, phân cách bằng dấu phẩy).
        /// </summary>
        private void BtnExportCSV_Click(object? sender, EventArgs e)
        {
            if (studentList.Count == 0)
            {
                MessageBox.Show("Danh sách sinh viên rỗng, không có gì để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sinh viên ra file CSV";
                sfd.Filter = "CSV Files|*.csv|All Files|*.*";
                sfd.FilterIndex = 1;
                sfd.DefaultExt = "csv";
                sfd.FileName = "DanhSachSinhVien.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Sử dụng UTF-8 with BOM để hỗ trợ tiếng Việt khi mở bằng Excel
                        using (StreamWriter writer = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                        {
                            // Ghi header
                            writer.WriteLine("Mã SV,Họ tên,Tuổi,Giới tính,Đường dẫn ảnh");

                            // Ghi từng sinh viên
                            foreach (var student in studentList)
                            {
                                // Escape các trường có chứa dấu phẩy hoặc dấu ngoặc kép
                                string line = string.Format("{0},{1},{2},{3},{4}",
                                    EscapeCsvField(student.StudentId),
                                    EscapeCsvField(student.FullName),
                                    student.Age,
                                    EscapeCsvField(student.Gender),
                                    EscapeCsvField(student.AvatarPath));

                                writer.WriteLine(line);
                            }
                        }

                        MessageBox.Show($"Xuất CSV thành công!\nĐường dẫn: {sfd.FileName}", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất CSV: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Escape một trường CSV: nếu chứa dấu phẩy, dấu ngoặc kép hoặc xuống dòng thì bọc trong dấu ngoặc kép.
        /// </summary>
        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";

            if (field.Contains(',') || field.Contains('"') || field.Contains('\n'))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }

            return field;
        }
    }
}
