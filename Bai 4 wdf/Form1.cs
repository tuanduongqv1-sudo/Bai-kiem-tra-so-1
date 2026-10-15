
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4_wdf
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel pnlViTri;
        private FlowLayoutPanel pnlChucNang;
        private ComboBox cboKhungGio;
        private Label lblSoLuong;
        private Label lblTamTinh;
        private Button btnXacNhan;
        private Button btnHuyTatCa;

        private const decimal GIA_SANG = 100000m;
        private const decimal GIA_TOI = 150000m;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Xóa các điều khiển có sẵn trên Form,
            // tránh bị lặp giao diện khi tạo bằng code.
            this.Controls.Clear();

            // Thiết lập Form
            this.Text = "Bài 4 - Quản lý đặt vị trí";
            this.Size = new Size(850, 700);
            this.MinimumSize = new Size(750, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Tạo bố cục chính: tiêu đề, sơ đồ, chức năng
            TableLayoutPanel pnlChinh = new TableLayoutPanel();
            pnlChinh.Dock = DockStyle.Fill;
            pnlChinh.ColumnCount = 1;
            pnlChinh.RowCount = 3;
            pnlChinh.Padding = new Padding(10);
            pnlChinh.BackColor = Color.WhiteSmoke;

            pnlChinh.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 60));
            pnlChinh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 65));
            pnlChinh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 35));

            this.Controls.Add(pnlChinh);

            // 1. Tiêu đề
            Label lblTieuDe = new Label();
            lblTieuDe.Text = "SƠ ĐỒ CHỌN VỊ TRÍ";
            lblTieuDe.Font = new Font(
                "Arial", 17, FontStyle.Bold);
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.ForeColor = Color.DarkSlateBlue;

            pnlChinh.Controls.Add(lblTieuDe, 0, 0);

            // 2. Sơ đồ ma trận 4 hàng x 5 cột
            pnlViTri = new TableLayoutPanel();
            pnlViTri.RowCount = 4;
            pnlViTri.ColumnCount = 5;
            pnlViTri.Dock = DockStyle.Fill;
            pnlViTri.Padding = new Padding(10);
            pnlViTri.BackColor = Color.WhiteSmoke;

            for (int i = 0; i < 4; i++)
            {
                pnlViTri.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 25));
            }

            for (int j = 0; j < 5; j++)
            {
                pnlViTri.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 20));
            }

            // Sinh tự động 20 Button
            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();

                btn.Name = "btnViTri" + (i + 1);
                btn.Text = "Vị trí " + (i + 1);
                btn.Dock = DockStyle.Fill;
                btn.Margin = new Padding(5);
                btn.Font = new Font(
                    "Arial", 10, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;

                // 0: Trống, 1: Đang chọn, 2: Đã đặt/khóa
                btn.Tag = 0;
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;

                // Gán chung một sự kiện Click
                btn.Click += ViTri_Click;

                // Tạo 3 vị trí đỏ để minh họa
                if (i == 2 || i == 7 || i == 13)
                {
                    btn.Tag = 2;
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                }

                pnlViTri.Controls.Add(
                    btn, i % 5, i / 5);
            }

            pnlChinh.Controls.Add(pnlViTri, 0, 1);

            // 3. Khu vực chức năng
            pnlChucNang = new FlowLayoutPanel();
            pnlChucNang.Dock = DockStyle.Fill;
            pnlChucNang.Padding = new Padding(15, 5, 15, 5);
            pnlChucNang.FlowDirection = FlowDirection.TopDown;
            pnlChucNang.WrapContents = false;
            pnlChucNang.AutoScroll = true;
            pnlChucNang.BackColor = Color.WhiteSmoke;

            pnlChinh.Controls.Add(pnlChucNang, 0, 2);

            // Chọn khung giờ
            Label lblKhungGio = new Label();
            lblKhungGio.Text = "Chọn khung giờ:";
            lblKhungGio.AutoSize = true;
            lblKhungGio.Font = new Font("Arial", 10);

            cboKhungGio = new ComboBox();
            cboKhungGio.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cboKhungGio.Width = 260;
            cboKhungGio.Font = new Font("Arial", 10);

            cboKhungGio.Items.Add("Sáng - 100.000đ");
            cboKhungGio.Items.Add("Tối - 150.000đ");
            cboKhungGio.SelectedIndex = 0;

            // Hiển thị số vị trí
            lblSoLuong = new Label();
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Arial", 10);
            lblSoLuong.Text = "Số vị trí đang chọn: 0";

            // Hiển thị tạm tính
            lblTamTinh = new Label();
            lblTamTinh.AutoSize = true;
            lblTamTinh.Font = new Font(
                "Arial", 11, FontStyle.Bold);
            lblTamTinh.Text = "Tạm tính tiền: 0đ";

            // Nút xác nhận đặt
            btnXacNhan = new Button();
            btnXacNhan.Text = "Xác nhận đặt";
            btnXacNhan.Size = new Size(260, 35);
            btnXacNhan.BackColor = Color.SeaGreen;
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Click += BtnXacNhan_Click;

            // Nút hủy chọn tất cả
            btnHuyTatCa = new Button();
            btnHuyTatCa.Text = "Hủy chọn tất cả";
            btnHuyTatCa.Size = new Size(260, 35);
            btnHuyTatCa.Click += BtnHuyTatCa_Click;

            pnlChucNang.Controls.Add(lblKhungGio);
            pnlChucNang.Controls.Add(cboKhungGio);
            pnlChucNang.Controls.Add(lblSoLuong);
            pnlChucNang.Controls.Add(lblTamTinh);
            pnlChucNang.Controls.Add(btnXacNhan);
            pnlChucNang.Controls.Add(btnHuyTatCa);

            // Đổi khung giờ thì cập nhật tiền
            cboKhungGio.SelectedIndexChanged +=
                CboKhungGio_SelectedIndexChanged;

            CapNhatThongKe();
        }

        // Xử lý Click dùng chung cho 20 vị trí
        private void ViTri_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            int trangThai = (int)btn.Tag;

            // Vị trí đã đặt hoặc bị khóa
            if (trangThai == 2)
            {
                MessageBox.Show(
                    "Vị trí này đã được đặt hoặc bị khóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Chọn vị trí trống
            if (trangThai == 0)
            {
                btn.Tag = 1;
                btn.BackColor = Color.LimeGreen;
                btn.ForeColor = Color.White;
            }
            // Bỏ chọn vị trí
            else
            {
                btn.Tag = 0;
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
            }

            CapNhatThongKe();
        }

        // Lấy giá tiền theo khung giờ
        private decimal LayDonGia()
        {
            if (cboKhungGio.SelectedIndex == 1)
                return GIA_TOI;

            return GIA_SANG;
        }

        // Đếm số vị trí đang chọn
        private int DemViTriDangChon()
        {
            int soLuong = 0;

            foreach (Control control in pnlViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && (int)btn.Tag == 1)
                {
                    soLuong++;
                }
            }

            return soLuong;
        }

        // Cập nhật số lượng và tạm tính tiền
        private void CapNhatThongKe()
        {
            int soLuong = DemViTriDangChon();
            decimal tongTien = soLuong * LayDonGia();

            lblSoLuong.Text =
                "Số vị trí đang chọn: " + soLuong;

            lblTamTinh.Text =
                "Tạm tính tiền: " + tongTien.ToString("N0") + "đ";
        }

        // Cập nhật tiền khi đổi khung giờ
        private void CboKhungGio_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            CapNhatThongKe();
        }

        // Xác nhận đặt vị trí
        private void BtnXacNhan_Click(
            object sender, EventArgs e)
        {
            int soLuong = DemViTriDangChon();

            if (soLuong == 0)
            {
                MessageBox.Show(
                    "Bạn chưa chọn vị trí nào!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = soLuong * LayDonGia();

            DialogResult ketQua = MessageBox.Show(
                "Số vị trí: " + soLuong +
                "\nKhung giờ: " + cboKhungGio.Text +
                "\nTổng tiền: " + tongTien.ToString("N0") + "đ" +
                "\n\nBạn có chắc chắn muốn đặt không?",
                "Xác nhận đặt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            // Chuyển vị trí đang chọn thành đã đặt
            foreach (Control control in pnlViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && (int)btn.Tag == 1)
                {
                    btn.Tag = 2;
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                }
            }

            CapNhatThongKe();

            MessageBox.Show(
                "Đặt vị trí thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Hủy chọn tất cả vị trí đang chọn
        private void BtnHuyTatCa_Click(
            object sender, EventArgs e)
        {
            foreach (Control control in pnlViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && (int)btn.Tag == 1)
                {
                    btn.Tag = 0;
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }

            CapNhatThongKe();
        }
    }
}
