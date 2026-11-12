using System;
using System.Windows.Forms;

namespace Bai5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== Nút Đăng Ký =====
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string gioiTinh = rdoMale.Checked ? "Nam" : "Nữ";
                MessageBox.Show(
                    "Đăng ký tài khoản thành công!\n\n" +
                    "Tên đăng nhập: " + txtUsername.Text.Trim() + "\n" +
                    "Ngày sinh: " + dtpBirth.Value.ToString("dd/MM/yyyy") + "\n" +
                    "Giới tính: " + gioiTinh,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===== Nút Làm Mới =====
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirm.Clear();
            dtpBirth.Value = new DateTime(2000, 1, 1);
            rdoMale.Checked = true;
            chkTerms.Checked = false;
            epCheck.Clear();            // xóa toàn bộ biểu tượng lỗi
            txtUsername.Focus();
        }

        // ===== Kiểm tra dữ liệu, gắn lỗi bằng ErrorProvider =====
        private bool ValidateForm()
        {
            bool hopLe = true;
            epCheck.Clear();

            // 1. Tên đăng nhập không được trống
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epCheck.SetError(txtUsername, "Tên đăng nhập không được để trống!");
                hopLe = false;
            }

            // 2. Mật khẩu không được trống
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                epCheck.SetError(txtPassword, "Mật khẩu không được để trống!");
                hopLe = false;
            }

            // 3. Xác nhận mật khẩu phải khớp
            if (txtConfirm.Text != txtPassword.Text)
            {
                epCheck.SetError(txtConfirm, "Mật khẩu xác nhận không khớp!");
                hopLe = false;
            }

            // 4. Tuổi >= 18
            if (TinhTuoi(dtpBirth.Value) < 18)
            {
                epCheck.SetError(dtpBirth, "Bạn phải từ 18 tuổi trở lên!");
                hopLe = false;
            }

            // 5. Phải đồng ý điều khoản
            if (!chkTerms.Checked)
            {
                epCheck.SetError(chkTerms, "Bạn phải đồng ý với điều khoản dịch vụ!");
                hopLe = false;
            }

            return hopLe;
        }

        private int TinhTuoi(DateTime ngaySinh)
        {
            DateTime today = DateTime.Today;
            int tuoi = today.Year - ngaySinh.Year;
            if (ngaySinh.Date > today.AddYears(-tuoi)) tuoi--;   // chưa tới sinh nhật năm nay
            return tuoi;
        }

        // ===== Xóa lỗi ngay khi người dùng sửa lại ô nhập =====
        private void ClearError_Changed(object sender, EventArgs e)
        {
            epCheck.SetError((Control)sender, "");
        }
    }
}
