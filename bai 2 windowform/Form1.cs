using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_2_windowform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboLoaiSuCo.Items.AddRange(new object[]
            {
                "Phần cứng",
                "Phần mềm",
                "Mạng",
                "Tài khoản"
            });

            cboLoaiSuCo.SelectedIndex = 0;

            // Mặc định ưu tiên Trung bình
            rdoTrungBinh.Checked = true;

            // Hiển thị ảnh theo kích thước PictureBox
            picAnhLoi.SizeMode =
                PictureBoxSizeMode.StretchImage;
        }

        // Nút Tải ảnh lỗi
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh chụp lỗi";
                ofd.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đọc ảnh vào bộ nhớ để tránh khóa tệp
                        using (var stream = new System.IO.FileStream(
                            ofd.FileName,
                            System.IO.FileMode.Open,
                            System.IO.FileAccess.Read))
                        using (var tempImage = System.Drawing.Image.FromStream(stream))
                        {
                            var newImage =
                                new System.Drawing.Bitmap(tempImage);

                            var oldImage = picAnhLoi.Image;
                            picAnhLoi.Image = newImage;
                            oldImage?.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Không thể mở ảnh này!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Nút Gửi yêu cầu
        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu.Text.Trim();
            string nguoiYeuCau = txtNguoiYeuCau.Text.Trim();

            if (maPhieu == "" || nguoiYeuCau == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập mã phiếu và người yêu cầu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string mucDoUuTien = "";

            if (rdoThap.Checked)
                mucDoUuTien = "Thấp";
            else if (rdoTrungBinh.Checked)
                mucDoUuTien = "Trung bình";
            else if (rdoKhanCap.Checked)
                mucDoUuTien = "Khẩn cấp";

            string loaiSuCo = cboLoaiSuCo.Text;

            StringBuilder thietBi = new StringBuilder();

            if (chkMayTinhBan.Checked)
                thietBi.Append("Máy tính bàn, ");

            if (chkLaptop.Checked)
                thietBi.Append("Laptop, ");

            if (chkMayIn.Checked)
                thietBi.Append("Máy in, ");

            if (chkDienThoai.Checked)
                thietBi.Append("Điện thoại, ");

            string danhSachThietBi = thietBi.ToString().TrimEnd(',', ' ');

            if (danhSachThietBi == "")
                danhSachThietBi = "Chưa chọn";

            string anhLoi = picAnhLoi.Image != null
                ? "Đã đính kèm ảnh"
                : "Không có ảnh";

            string thongTin =
                "===== PHIẾU TIẾP NHẬN SỰ CỐ IT =====\n\n" +
                "Mã phiếu: " + maPhieu + "\n" +
                "Người yêu cầu: " + nguoiYeuCau + "\n" +
                "Ngày ghi nhận: " +
                    dtpNgayGhiNhan.Value.ToString("dd/MM/yyyy") + "\n" +
                "Mức độ ưu tiên: " + mucDoUuTien + "\n" +
                "Loại sự cố: " + loaiSuCo + "\n" +
                "Thiết bị ảnh hưởng: " + danhSachThietBi + "\n" +
                "Ảnh lỗi: " + anhLoi;

            MessageBox.Show(
                thongTin,
                "Thông tin phiếu hỗ trợ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Nút Nhập lại
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();

            dtpNgayGhiNhan.Value = DateTime.Now;
            cboLoaiSuCo.SelectedIndex = 0;

            rdoTrungBinh.Checked = true;

            chkMayTinhBan.Checked = false;
            chkLaptop.Checked = false;
            chkMayIn.Checked = false;
            chkDienThoai.Checked = false;

            var oldImage = picAnhLoi.Image;
            picAnhLoi.Image = null;
            oldImage?.Dispose();

            txtMaPhieu.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
    }
}
