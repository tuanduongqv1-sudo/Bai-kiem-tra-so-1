using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace RepairServiceTracker;

public class MainForm : Form
{
    private readonly List<RepairOrder> _all = new();
    private BindingList<RepairOrder> _view = new();
    private readonly BindingSource _bs = new();
    private readonly ErrorProvider _err = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private RepairOrder _editing;
    private bool _loading;
    private string _imagePath = "";

    private readonly TextBox txtId = new(), txtCustomer = new(), txtPhone = new(), txtCost = new(), txtSearch = new();
    private readonly TextBox txtProblem = new() { Multiline = true, Height = 50 };
    private readonly ComboBox cboDevice = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboStatus = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboFilter = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
    private readonly DateTimePicker dtpReceived = new() { Format = DateTimePickerFormat.Short };
    private readonly PictureBox pic = new() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle };
    private readonly DataGridView dgv = new();
    private readonly ToolStripStatusLabel lblStatus = new();

    private static readonly string[] Devices = { "Điện thoại", "Laptop", "Máy tính bảng", "Tivi", "Máy in", "Khác" };
    private static readonly string[] Statuses = { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" };

    public MainForm()
    {
        Text = "Repair Service Tracker";
        Size = new Size(1200, 760);
        MinimumSize = new Size(1000, 640);
        StartPosition = FormStartPosition.CenterScreen;

        cboDevice.Items.AddRange(Devices);
        cboStatus.Items.AddRange(Statuses);
        cboFilter.Items.Add("Tất cả");
        cboFilter.Items.AddRange(Statuses);
        cboFilter.SelectedIndex = 0;

        BuildUi();
        SeedData();
        dgv.DataSource = _bs;
        ApplyFilter();
        if (_view.Count == 0) ClearForm();
    }

    // ---------------- UI ----------------
    private void BuildUi()
    {
        // Menu
        var menu = new MenuStrip();
        var mFile = new ToolStripMenuItem("Tệp");
        mFile.DropDownItems.Add(new ToolStripMenuItem("Xuất danh sách ra CSV...", null, (s, e) => ExportCsv()));
        mFile.DropDownItems.Add(new ToolStripSeparator());
        mFile.DropDownItems.Add(new ToolStripMenuItem("Thoát", null, (s, e) => Close()));
        menu.Items.Add(mFile);
        MainMenuStrip = menu;

        var status = new StatusStrip();
        status.Items.Add(lblStatus);

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(8) };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        // Top: thông tin đơn (trái) + ảnh (phải)
        var top = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, AutoSize = true };
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270));

        var grp = new GroupBox { Text = "Thông tin đơn", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, AutoSize = true, Padding = new Padding(4) };
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        AddField(t, "Mã đơn:", txtId, 0, 0);
        AddField(t, "Tên khách hàng:", txtCustomer, 2, 0);
        AddField(t, "Số điện thoại:", txtPhone, 0, 1);
        AddField(t, "Loại thiết bị:", cboDevice, 2, 1);
        AddField(t, "Ngày tiếp nhận:", dtpReceived, 0, 2);
        AddField(t, "Trạng thái:", cboStatus, 2, 2);
        AddField(t, "Chi phí dự kiến (VNĐ):", txtCost, 0, 3);
        AddField(t, "Mô tả lỗi:", txtProblem, 0, 4, 3);

        var btns = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        btns.Controls.Add(MakeButton("Mới", (s, e) => ClearForm()));
        btns.Controls.Add(MakeButton("Thêm", (s, e) => AddOrder()));
        btns.Controls.Add(MakeButton("Cập nhật", (s, e) => UpdateOrder()));
        btns.Controls.Add(MakeButton("Xóa", (s, e) => DeleteOrder()));
        t.Controls.Add(btns, 0, 5);
        t.SetColumnSpan(btns, 4);
        grp.Controls.Add(t);

        var grpPic = new GroupBox { Text = "Ảnh thiết bị", Dock = DockStyle.Fill, MinimumSize = new Size(0, 240) };
        var picBtns = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
        picBtns.Controls.Add(MakeButton("Chọn ảnh...", (s, e) => ChooseImage()));
        picBtns.Controls.Add(MakeButton("Bỏ ảnh", (s, e) => { _imagePath = ""; ShowImage(""); }));
        grpPic.Controls.Add(pic);
        grpPic.Controls.Add(picBtns);

        top.Controls.Add(grp, 0, 0);
        top.Controls.Add(grpPic, 1, 0);

        // Filter
        var grpF = new GroupBox { Text = "Tìm kiếm & lọc", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var f = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(4) };
        txtSearch.Width = 240;
        f.Controls.Add(MakeLabel("Mã đơn / Khách / SĐT:"));
        f.Controls.Add(txtSearch);
        f.Controls.Add(MakeLabel("Trạng thái:"));
        f.Controls.Add(cboFilter);
        f.Controls.Add(MakeButton("Xóa bộ lọc", (s, e) => { txtSearch.Clear(); cboFilter.SelectedIndex = 0; }));
        grpF.Controls.Add(f);
        txtSearch.TextChanged += (s, e) => ApplyFilter();
        cboFilter.SelectedIndexChanged += (s, e) => ApplyFilter();

        // Grid
        dgv.Dock = DockStyle.Fill;
        dgv.AutoGenerateColumns = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.Columns.Add(Col("Id", "Mã đơn", 9));
        dgv.Columns.Add(Col("CustomerName", "Khách hàng", 16));
        dgv.Columns.Add(Col("Phone", "SĐT", 12));
        dgv.Columns.Add(Col("DeviceType", "Loại thiết bị", 12));
        dgv.Columns.Add(Col("Problem", "Mô tả lỗi", 22));
        var cDate = Col("ReceivedDate", "Ngày tiếp nhận", 12);
        cDate.DefaultCellStyle.Format = "dd/MM/yyyy";
        dgv.Columns.Add(cDate);
        var cCost = Col("EstimatedCost", "Chi phí dự kiến", 13);
        cCost.DefaultCellStyle.Format = "N0";
        cCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgv.Columns.Add(cCost);
        dgv.Columns.Add(Col("Status", "Trạng thái", 12));
        dgv.SelectionChanged += (s, e) => LoadSelected();

        root.Controls.Add(top, 0, 0);
        root.Controls.Add(grpF, 0, 1);
        root.Controls.Add(dgv, 0, 2);
        Controls.Add(root);
        Controls.Add(status);
        Controls.Add(menu);
    }

    private static void AddField(TableLayoutPanel t, string label, Control c, int col, int row, int span = 1)
    {
        t.Controls.Add(new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 6, 8, 3) }, col, row);
        c.Dock = DockStyle.Fill;
        t.Controls.Add(c, col + 1, row);
        if (span > 1) t.SetColumnSpan(c, span);
    }

    private static Label MakeLabel(string text) => new() { Text = text, AutoSize = true, Margin = new Padding(8, 8, 3, 3) };

    private static Button MakeButton(string text, EventHandler click)
    {
        var b = new Button { Text = text, AutoSize = true, MinimumSize = new Size(90, 30) };
        b.Click += click;
        return b;
    }

    private static DataGridViewTextBoxColumn Col(string prop, string header, float weight) =>
        new() { DataPropertyName = prop, HeaderText = header, FillWeight = weight };

    // ---------------- Data ----------------
    private void SeedData()
    {
        var d = DateTime.Today;
        _all.Add(new RepairOrder { Id = "SC001", CustomerName = "Nguyễn Văn An", Phone = "0901234567", DeviceType = "Điện thoại", Problem = "Vỡ màn hình", ReceivedDate = d.AddDays(-3), EstimatedCost = 1200000, Status = "Đang sửa" });
        _all.Add(new RepairOrder { Id = "SC002", CustomerName = "Trần Thị Bình", Phone = "0912345678", DeviceType = "Laptop", Problem = "Không lên nguồn", ReceivedDate = d.AddDays(-2), EstimatedCost = 850000, Status = "Chờ linh kiện" });
        _all.Add(new RepairOrder { Id = "SC003", CustomerName = "Lê Hoàng Cường", Phone = "0987654321", DeviceType = "Tivi", Problem = "Mất hình", ReceivedDate = d.AddDays(-7), EstimatedCost = 2000000, Status = "Hoàn tất" });
        _all.Add(new RepairOrder { Id = "SC004", CustomerName = "Phạm Thu Dung", Phone = "0933444555", DeviceType = "Máy tính bảng", Problem = "Pin chai", ReceivedDate = d, EstimatedCost = 450000, Status = "Mới tiếp nhận" });
    }

    private void ApplyFilter(string selectId = null)
    {
        string kw = txtSearch.Text.Trim();
        string st = cboFilter.SelectedItem as string ?? "Tất cả";
        var q = _all.Where(o =>
                (kw == "" || o.Id.Contains(kw, StringComparison.OrdinalIgnoreCase)
                          || o.CustomerName.Contains(kw, StringComparison.OrdinalIgnoreCase)
                          || o.Phone.Contains(kw))
                && (st == "Tất cả" || o.Status == st))
            .ToList();

        _loading = true;
        _view = new BindingList<RepairOrder>(q);
        _bs.DataSource = _view;
        _loading = false;
        UpdateStatusStrip();

        if (_view.Count == 0) { ClearForm(); return; }
        selectId ??= _editing?.Id;
        if (selectId == null) { dgv.ClearSelection(); return; }

        int idx = Math.Max(0, _view.ToList().FindIndex(x => x.Id == selectId));
        _bs.Position = idx;
        dgv.ClearSelection();
        dgv.Rows[idx].Selected = true;
        LoadSelected();
    }

    private void UpdateStatusStrip()
    {
        decimal total = _view.Where(o => o.IsOpen).Sum(o => o.EstimatedCost);
        lblStatus.Text = $"Số đơn (theo bộ lọc): {_view.Count}   |   Tổng chi phí dự kiến đơn chưa hoàn tất: {total:N0} VNĐ";
    }

    private void LoadSelected()
    {
        if (_loading || dgv.SelectedRows.Count == 0) return;
        if (dgv.SelectedRows[0].DataBoundItem is not RepairOrder o) return;
        _editing = o;
        txtId.Text = o.Id; txtId.ReadOnly = true;
        txtCustomer.Text = o.CustomerName;
        txtPhone.Text = o.Phone;
        cboDevice.SelectedItem = o.DeviceType;
        txtProblem.Text = o.Problem;
        dtpReceived.Value = o.ReceivedDate;
        txtCost.Text = o.EstimatedCost.ToString("0");
        cboStatus.SelectedItem = o.Status;
        _imagePath = o.ImagePath ?? "";
        ShowImage(_imagePath);
        _err.Clear();
    }

    private void ClearForm()
    {
        _editing = null;
        txtId.ReadOnly = false;
        txtId.Clear(); txtCustomer.Clear(); txtPhone.Clear(); txtProblem.Clear(); txtCost.Text = "0";
        cboDevice.SelectedIndex = -1;
        cboStatus.SelectedIndex = 0;
        dtpReceived.Value = DateTime.Today;
        _imagePath = "";
        ShowImage("");
        _err.Clear();
        dgv.ClearSelection();
        txtId.Focus();
    }

    // ---------------- Ảnh ----------------
    private void ChooseImage()
    {
        using var ofd = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif", Title = "Chọn ảnh thiết bị" };
        if (ofd.ShowDialog() != DialogResult.OK) return;
        _imagePath = ofd.FileName;
        ShowImage(_imagePath);
    }

    private void ShowImage(string path)
    {
        var old = pic.Image;
        pic.Image = null;
        old?.Dispose();
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;
        try
        {
            // Đọc vào bộ nhớ để không khóa file ảnh
            var ms = new MemoryStream(File.ReadAllBytes(path));
            pic.Image = Image.FromStream(ms);
        }
        catch
        {
            MessageBox.Show("Không đọc được file ảnh.", "Lỗi");
        }
    }

    // ---------------- CRUD ----------------
    private static bool Confirm(string msg) =>
        MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void AddOrder()
    {
        if (_editing != null) { MessageBox.Show("Bạn đang chọn một đơn. Nhấn \"Mới\" để nhập đơn mới.", "Thông báo"); return; }
        if (!ValidateForm(true, out decimal cost)) return;
        if (!Confirm("Thêm đơn sửa chữa mới?")) return;
        var o = new RepairOrder();
        CopyToModel(o, cost);
        _all.Add(o);
        ApplyFilter(o.Id);
    }

    private void UpdateOrder()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một đơn trong danh sách.", "Thông báo"); return; }
        if (!ValidateForm(false, out decimal cost)) return;
        if (!Confirm("Cập nhật đơn này?")) return;
        CopyToModel(_editing, cost);
        ApplyFilter(_editing.Id);
    }

    private void DeleteOrder()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một đơn trong danh sách.", "Thông báo"); return; }
        if (!Confirm($"Xóa đơn {_editing.Id}?")) return;
        _all.Remove(_editing);
        _editing = null;
        ApplyFilter();
        ClearForm();
    }

    private void CopyToModel(RepairOrder o, decimal cost)
    {
        o.Id = txtId.Text.Trim();
        o.CustomerName = txtCustomer.Text.Trim();
        o.Phone = txtPhone.Text.Trim();
        o.DeviceType = (string)cboDevice.SelectedItem;
        o.Problem = txtProblem.Text.Trim();
        o.ReceivedDate = dtpReceived.Value.Date;
        o.EstimatedCost = cost;
        o.Status = (string)cboStatus.SelectedItem;
        o.ImagePath = _imagePath;
    }

    // ---------------- Validation ----------------
    private bool ValidateForm(bool isNew, out decimal cost)
    {
        _err.Clear();
        bool ok = true;
        void Check(Control c, bool valid, string msg)
        {
            if (!valid) { _err.SetError(c, msg); ok = false; }
        }

        string id = txtId.Text.Trim();
        Check(txtId, id != "", "Mã đơn là bắt buộc.");
        if (isNew && id != "")
            Check(txtId, !_all.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)), "Mã đơn đã tồn tại.");

        Check(txtCustomer, txtCustomer.Text.Trim() != "", "Tên khách hàng không được để trống.");
        Check(txtPhone, txtPhone.Text.Trim() != "", "Số điện thoại không được để trống.");
        Check(cboDevice, cboDevice.SelectedIndex >= 0, "Hãy chọn loại thiết bị.");
        Check(cboStatus, cboStatus.SelectedIndex >= 0, "Hãy chọn trạng thái.");
        Check(txtProblem, txtProblem.Text.Trim() != "", "Mô tả lỗi là bắt buộc.");

        // Chi phí: bỏ dấu phân cách nghìn rồi parse; phải là số không âm
        string raw = txtCost.Text.Trim().Replace(",", "").Replace(".", "").Replace(" ", "");
        bool parsed = decimal.TryParse(raw, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out cost);
        if (!parsed) Check(txtCost, false, "Chi phí dự kiến phải là số.");
        else Check(txtCost, cost >= 0, "Chi phí dự kiến không được âm.");
        return ok;
    }

    // ---------------- Export ----------------
    private static string Esc(string s) => "\"" + (s ?? "").Replace("\"", "\"\"") + "\"";

    private void ExportCsv()
    {
        using var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "don_sua_chua.csv" };
        if (sfd.ShowDialog() != DialogResult.OK) return;
        var sb = new StringBuilder();
        sb.AppendLine("Mã đơn,Khách hàng,SĐT,Loại thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái");
        foreach (var o in _view)
            sb.AppendLine(string.Join(",", new[]
            {
                o.Id, o.CustomerName, o.Phone, o.DeviceType, o.Problem,
                o.ReceivedDate.ToString("dd/MM/yyyy"), o.EstimatedCost.ToString("0"), o.Status
            }.Select(Esc)));
        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
        MessageBox.Show($"Đã xuất {_view.Count} đơn.", "Xuất CSV");
    }
}
