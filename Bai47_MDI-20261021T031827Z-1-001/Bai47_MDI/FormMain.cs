namespace Bai47_MDI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            WireEvents();
            timerClock.Start();
        }

        /// <summary>
        /// Gắn sự kiện cho tất cả Menu, ToolStrip, Timer.
        /// </summary>
        private void WireEvents()
        {
            // Menu Hệ thống
            mnuDangXuat.Click += MnuDangXuat_Click;
            mnuThoat.Click += MnuThoat_Click;

            // Menu Danh mục
            mnuQuanLySinhVien.Click += (s, e) => OpenChildForm<FormStudent>();
            mnuQuanLySanPham.Click += (s, e) => OpenChildForm<FormProduct>();

            // Menu Cửa sổ
            mnuCascade.Click += (s, e) => LayoutMdi(MdiLayout.Cascade);
            mnuTileHorizontal.Click += (s, e) => LayoutMdi(MdiLayout.TileHorizontal);
            mnuTileVertical.Click += (s, e) => LayoutMdi(MdiLayout.TileVertical);

            // ToolStrip
            tsbSinhVien.Click += (s, e) => OpenChildForm<FormStudent>();
            tsbSanPham.Click += (s, e) => OpenChildForm<FormProduct>();
            tsbDangXuat.Click += MnuDangXuat_Click;
            tsbThoat.Click += MnuThoat_Click;

            // Timer cập nhật đồng hồ
            timerClock.Tick += TimerClock_Tick;
        }

        /// <summary>
        /// Mở Form con (MDI Child). Nếu đã mở thì Activate, không mở lặp lại.
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            // Kiểm tra Form đã mở chưa
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    child.Activate();
                    return;
                }
            }

            // Chưa mở → tạo mới
            T form = new T();
            form.MdiParent = this;

            // Nếu Form con implement IStatusNotifier, gắn callback
            if (form is IStatusNotifier notifier)
            {
                notifier.OnStatusChanged = UpdateStatusBar;
            }

            form.Show();
        }

        /// <summary>
        /// Cập nhật thông báo trên StatusStrip (được gọi từ Form con).
        /// </summary>
        public void UpdateStatusBar(string message)
        {
            tslThongBao.Text = message;
        }

        /// <summary>
        /// Đăng xuất: Đóng tất cả Form con.
        /// </summary>
        private void MnuDangXuat_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng tất cả form con
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }

                tslUser.Text = "Người dùng: (Chưa đăng nhập)";
                UpdateStatusBar("Đã đăng xuất");
            }
        }

        /// <summary>
        /// Thoát ứng dụng.
        /// </summary>
        private void MnuThoat_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Cập nhật đồng hồ trên StatusStrip mỗi giây.
        /// </summary>
        private void TimerClock_Tick(object? sender, EventArgs e)
        {
            tslTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
    }
}
