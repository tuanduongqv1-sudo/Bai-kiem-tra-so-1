namespace Bai48_AsyncProgressBar
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            WireEvents();
            timerClock.Start();
        }

        private void WireEvents()
        {
            mnuDangXuat.Click += MnuDangXuat_Click;
            mnuThoat.Click += MnuThoat_Click;
            mnuQuanLySinhVien.Click += (s, e) => OpenChildForm<FormStudent>();
            mnuQuanLySanPham.Click += (s, e) => OpenChildForm<FormProduct>();
            mnuCascade.Click += (s, e) => LayoutMdi(MdiLayout.Cascade);
            mnuTileHorizontal.Click += (s, e) => LayoutMdi(MdiLayout.TileHorizontal);
            mnuTileVertical.Click += (s, e) => LayoutMdi(MdiLayout.TileVertical);

            tsbSinhVien.Click += (s, e) => OpenChildForm<FormStudent>();
            tsbSanPham.Click += (s, e) => OpenChildForm<FormProduct>();
            tsbDangXuat.Click += MnuDangXuat_Click;
            tsbThoat.Click += MnuThoat_Click;

            timerClock.Tick += (s, e) => tslTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        /// <summary>
        /// Mở Form con MDI Child. Nếu đã mở thì Activate, không mở lặp lại.
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    child.Activate();
                    return;
                }
            }

            T form = new T();
            form.MdiParent = this;

            if (form is IProgressNotifier notifier)
            {
                notifier.OnStatusChanged = UpdateStatusBar;
                notifier.OnProgressChanged = UpdateProgressBar;
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
        /// Cập nhật phần trăm tiến trình trên StatusStrip (được gọi từ Form con).
        /// </summary>
        public void UpdateProgressBar(int percent)
        {
            if (percent <= 0)
            {
                // Ẩn progress bar
                tspProgressBar.Visible = false;
                tslPercent.Visible = false;
            }
            else if (percent >= 100)
            {
                tspProgressBar.Value = 100;
                tslPercent.Text = "100%";
                // Ẩn sau 1 giây
                Task.Delay(1000).ContinueWith(_ =>
                {
                    if (!this.IsDisposed)
                    {
                        this.Invoke(() =>
                        {
                            tspProgressBar.Visible = false;
                            tslPercent.Visible = false;
                            tspProgressBar.Value = 0;
                        });
                    }
                });
            }
            else
            {
                tspProgressBar.Visible = true;
                tslPercent.Visible = true;
                tspProgressBar.Value = percent;
                tslPercent.Text = $"{percent}%";
            }
        }

        private void MnuDangXuat_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)
                    child.Close();
                tslUser.Text = "Người dùng: (Chưa đăng nhập)";
                UpdateStatusBar("Đã đăng xuất");
            }
        }

        private void MnuThoat_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
