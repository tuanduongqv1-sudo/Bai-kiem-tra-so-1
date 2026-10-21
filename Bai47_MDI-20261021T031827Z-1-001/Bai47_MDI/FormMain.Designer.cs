namespace Bai47_MDI
{
    partial class FormMain
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

            // ===== MenuStrip =====
            this.menuStrip = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDangXuat = new ToolStripMenuItem();
            this.mnuThoat = new ToolStripMenuItem();
            this.mnuDanhMuc = new ToolStripMenuItem();
            this.mnuQuanLySinhVien = new ToolStripMenuItem();
            this.mnuQuanLySanPham = new ToolStripMenuItem();
            this.mnuCuaSo = new ToolStripMenuItem();
            this.mnuCascade = new ToolStripMenuItem();
            this.mnuTileHorizontal = new ToolStripMenuItem();
            this.mnuTileVertical = new ToolStripMenuItem();

            // ===== ToolStrip =====
            this.toolStrip = new ToolStrip();
            this.tsbSinhVien = new ToolStripButton();
            this.tsbSanPham = new ToolStripButton();
            this.tsbSeparator1 = new ToolStripSeparator();
            this.tsbDangXuat = new ToolStripButton();
            this.tsbThoat = new ToolStripButton();

            // ===== StatusStrip =====
            this.statusStrip = new StatusStrip();
            this.tslUser = new ToolStripStatusLabel();
            this.tslSpring = new ToolStripStatusLabel();
            this.tslThongBao = new ToolStripStatusLabel();
            this.tslSeparator = new ToolStripStatusLabel();
            this.tslTime = new ToolStripStatusLabel();

            // ===== Timer for clock =====
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // ---------- MenuStrip ----------
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuCuaSo });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.mnuCuaSo;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(900, 24);

            // Menu Hệ thống
            this.mnuHeThong.Text = "Hệ thống";
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuDangXuat, new ToolStripSeparator(), this.mnuThoat });

            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.ShortcutKeys = Keys.Control | Keys.L;
            this.mnuDangXuat.Image = null;

            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;

            // Menu Danh mục
            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuQuanLySinhVien, this.mnuQuanLySanPham });

            this.mnuQuanLySinhVien.Text = "Quản lý Sinh viên";
            this.mnuQuanLySinhVien.ShortcutKeys = Keys.Control | Keys.S;

            this.mnuQuanLySanPham.Text = "Quản lý Sản phẩm";
            this.mnuQuanLySanPham.ShortcutKeys = Keys.Control | Keys.P;

            // Menu Cửa sổ
            this.mnuCuaSo.Text = "Cửa sổ";
            this.mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuCascade, this.mnuTileHorizontal, this.mnuTileVertical });

            this.mnuCascade.Text = "Cascade";
            this.mnuTileHorizontal.Text = "Tile Horizontal";
            this.mnuTileVertical.Text = "Tile Vertical";

            // ---------- ToolStrip ----------
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
                this.tsbSinhVien, this.tsbSanPham, this.tsbSeparator1,
                this.tsbDangXuat, this.tsbThoat });
            this.toolStrip.Location = new Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(900, 25);
            this.toolStrip.ImageScalingSize = new Size(16, 16);

            this.tsbSinhVien.Text = "📋 Sinh viên";
            this.tsbSinhVien.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.tsbSinhVien.ToolTipText = "Mở Quản lý Sinh viên";

            this.tsbSanPham.Text = "📦 Sản phẩm";
            this.tsbSanPham.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.tsbSanPham.ToolTipText = "Mở Quản lý Sản phẩm";

            this.tsbDangXuat.Text = "🔓 Đăng xuất";
            this.tsbDangXuat.DisplayStyle = ToolStripItemDisplayStyle.Text;

            this.tsbThoat.Text = "❌ Thoát";
            this.tsbThoat.DisplayStyle = ToolStripItemDisplayStyle.Text;

            // ---------- StatusStrip ----------
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.tslUser, this.tslSpring, this.tslThongBao, this.tslSeparator, this.tslTime });
            this.statusStrip.Location = new Point(0, 528);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(900, 22);

            this.tslUser.Text = "Người dùng: Admin";
            this.tslUser.BorderSides = ToolStripStatusLabelBorderSides.Right;

            this.tslSpring.Spring = true;
            this.tslSpring.Text = "";

            this.tslThongBao.Text = "Sẵn sàng";
            this.tslThongBao.Name = "tslThongBao";
            this.tslThongBao.BorderSides = ToolStripStatusLabelBorderSides.Right;

            this.tslSeparator.Text = "";
            this.tslSeparator.Size = new Size(10, 17);

            this.tslTime.Text = "00:00:00";
            this.tslTime.Name = "tslTime";

            // ---------- Timer ----------
            this.timerClock.Interval = 1000;
            this.timerClock.Enabled = true;

            // ---------- FormMain ----------
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bài 4.7 - Ứng dụng MDI Quản lý đa cửa sổ";
            this.WindowState = FormWindowState.Maximized;

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuQuanLySinhVien;
        private ToolStripMenuItem mnuQuanLySanPham;
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileHorizontal;
        private ToolStripMenuItem mnuTileVertical;

        private ToolStrip toolStrip;
        private ToolStripButton tsbSinhVien;
        private ToolStripButton tsbSanPham;
        private ToolStripSeparator tsbSeparator1;
        private ToolStripButton tsbDangXuat;
        private ToolStripButton tsbThoat;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel tslUser;
        private ToolStripStatusLabel tslSpring;
        private ToolStripStatusLabel tslThongBao;
        private ToolStripStatusLabel tslSeparator;
        private ToolStripStatusLabel tslTime;

        private System.Windows.Forms.Timer timerClock;
    }
}
