using System.Windows.Forms;

namespace TechMart
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Khai báo các control =====
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStripMenuItem mnuExit;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotal;

        private TableLayoutPanel tableLayoutPanelMain;

        // Cột trái - khung nhập liệu
        private GroupBox grpInput;
        private Label lblId, lblName, lblCategory, lblPrice, lblQuantity;
        private TextBox txtProductId, txtProductName, txtUnitPrice, txtQuantity;
        private ComboBox cboCategory;
        private PictureBox picAvatar;
        private Button btnChooseImage;
        private Button btnAdd, btnUpdate, btnDelete;

        // Cột phải - tìm kiếm + bảng dữ liệu
        private TableLayoutPanel tableLayoutPanelRight;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvProducts;

        // Thành phần không hiển thị
        private ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ---------- Form ----------
            this.Text = "TechMart Product Manager";
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.MinimumSize = new System.Drawing.Size(820, 560);
            this.StartPosition = FormStartPosition.CenterScreen;

            // ---------- MenuStrip ----------
            this.menuStrip = new MenuStrip();
            this.mnuFile = new ToolStripMenuItem("File");
            this.mnuExportCsv = new ToolStripMenuItem("Export CSV")
            {
                ShortcutKeys = Keys.Control | Keys.E
            };
            this.mnuExit = new ToolStripMenuItem("Exit")
            {
                ShortcutKeys = Keys.Control | Keys.X
            };
            this.mnuExportCsv.Click += this.mnuExportCsv_Click;
            this.mnuExit.Click += this.mnuExit_Click;
            this.mnuFile.DropDownItems.Add(this.mnuExportCsv);
            this.mnuFile.DropDownItems.Add(new ToolStripSeparator());
            this.mnuFile.DropDownItems.Add(this.mnuExit);
            this.menuStrip.Items.Add(this.mnuFile);
            this.menuStrip.Dock = DockStyle.Top;

            // ---------- StatusStrip ----------
            this.statusStrip = new StatusStrip();
            this.lblTotal = new ToolStripStatusLabel("Tổng số sản phẩm: 0");
            this.statusStrip.Items.Add(this.lblTotal);
            this.statusStrip.Dock = DockStyle.Bottom;

            // ---------- TableLayoutPanel chính (2 cột 35% - 65%) ----------
            this.tableLayoutPanelMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(8)
            };
            this.tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            this.tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ========== CỘT TRÁI: GroupBox nhập liệu ==========
            this.grpInput = new GroupBox
            {
                Text = "Thông tin sản phẩm",
                Dock = DockStyle.Fill
            };

            this.lblId = new Label { Text = "Mã SP:", Location = new System.Drawing.Point(12, 33), AutoSize = true };
            this.txtProductId = new TextBox { Location = new System.Drawing.Point(110, 30), Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            this.lblName = new Label { Text = "Tên SP:", Location = new System.Drawing.Point(12, 68), AutoSize = true };
            this.txtProductName = new TextBox { Location = new System.Drawing.Point(110, 65), Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            this.lblCategory = new Label { Text = "Danh mục:", Location = new System.Drawing.Point(12, 103), AutoSize = true };
            this.cboCategory = new ComboBox { Location = new System.Drawing.Point(110, 100), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            this.lblPrice = new Label { Text = "Đơn giá:", Location = new System.Drawing.Point(12, 138), AutoSize = true };
            this.txtUnitPrice = new TextBox { Location = new System.Drawing.Point(110, 135), Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            this.lblQuantity = new Label { Text = "Số lượng:", Location = new System.Drawing.Point(12, 173), AutoSize = true };
            this.txtQuantity = new TextBox { Location = new System.Drawing.Point(110, 170), Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            this.picAvatar = new PictureBox
            {
                Location = new System.Drawing.Point(12, 205),
                Size = new System.Drawing.Size(150, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.btnChooseImage = new Button
            {
                Text = "Chọn ảnh...",
                Location = new System.Drawing.Point(175, 205),
                Width = 110
            };
            this.btnChooseImage.Click += this.btnChooseImage_Click;

            this.btnAdd = new Button { Text = "Thêm mới", Location = new System.Drawing.Point(12, 345), Width = 90, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            this.btnUpdate = new Button { Text = "Cập nhật", Location = new System.Drawing.Point(110, 345), Width = 90, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            this.btnDelete = new Button { Text = "Xóa", Location = new System.Drawing.Point(208, 345), Width = 90, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            this.btnAdd.Click += this.btnAdd_Click;
            this.btnUpdate.Click += this.btnUpdate_Click;
            this.btnDelete.Click += this.btnDelete_Click;

            this.grpInput.Controls.AddRange(new Control[]
            {
                this.lblId, this.txtProductId,
                this.lblName, this.txtProductName,
                this.lblCategory, this.cboCategory,
                this.lblPrice, this.txtUnitPrice,
                this.lblQuantity, this.txtQuantity,
                this.picAvatar, this.btnChooseImage,
                this.btnAdd, this.btnUpdate, this.btnDelete
            });

            // ========== CỘT PHẢI: tìm kiếm + DataGridView ==========
            this.tableLayoutPanelRight = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            this.tableLayoutPanelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // ô tìm kiếm
            this.tableLayoutPanelRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // bảng

            this.pnlSearch = new Panel { Dock = DockStyle.Fill };
            this.lblSearch = new Label { Text = "Tìm kiếm:", Location = new System.Drawing.Point(3, 10), AutoSize = true };
            this.txtSearch = new TextBox
            {
                Location = new System.Drawing.Point(75, 7),
                Width = 300,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            this.txtSearch.TextChanged += this.txtSearch_TextChanged; // Live search
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);

            this.dgvProducts = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.dgvProducts.SelectionChanged += this.dgvProducts_SelectionChanged;

            // Tự định nghĩa các cột (AutoGenerateColumns = false)
            var colId = new DataGridViewTextBoxColumn { HeaderText = "Mã SP", DataPropertyName = "ProductId", FillWeight = 15 };
            var colName = new DataGridViewTextBoxColumn { HeaderText = "Tên SP", DataPropertyName = "ProductName", FillWeight = 30 };
            var colCat = new DataGridViewTextBoxColumn { HeaderText = "Danh mục", DataPropertyName = "Category", FillWeight = 20 };
            var colPrice = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "UnitPrice", FillWeight = 20 };
            colPrice.DefaultCellStyle.Format = "N0"; // format số có dấu phân cách
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var colQty = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "Quantity", FillWeight = 15 };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colCat, colPrice, colQty });

            this.tableLayoutPanelRight.Controls.Add(this.pnlSearch, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.dgvProducts, 0, 1);

            // Gắn 2 cột vào layout chính
            this.tableLayoutPanelMain.Controls.Add(this.grpInput, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelRight, 1, 0);

            // ---------- ErrorProvider ----------
            this.errorProvider = new ErrorProvider(this.components)
            {
                BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            };

            // ---------- Thêm control vào Form ----------
            // Thêm Fill trước, Top/Bottom sau để chúng chiếm cạnh trước, Fill lấy phần giữa.
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
        }
    }
}
