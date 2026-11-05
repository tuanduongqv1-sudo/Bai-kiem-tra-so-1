using System.ComponentModel;
using System.Text;

namespace LabEquipmentCheckout;

public class MainForm : Form
{
    private readonly List<Checkout> _all = new();
    private BindingList<Checkout> _view = new();
    private readonly BindingSource _bs = new();
    private readonly ErrorProvider _err = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private Checkout _editing;
    private bool _loading;

    private readonly TextBox txtId = new(), txtStudentId = new(), txtStudentName = new(), txtSearch = new();
    private readonly TextBox txtStatus = new() { ReadOnly = true };
    private readonly ComboBox cboEquipment = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboFilter = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 130 };
    private readonly NumericUpDown nudQty = new() { Minimum = 0, Maximum = 1000, Value = 1 };
    private readonly DateTimePicker dtpBorrow = new() { Format = DateTimePickerFormat.Short };
    private readonly DateTimePicker dtpDue = new() { Format = DateTimePickerFormat.Short };
    private readonly DateTimePicker dtpReturn = new() { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
    private readonly DataGridView dgv = new();
    private readonly ToolStripStatusLabel lblStatus = new();

    private static readonly string[] Equipments =
        { "Kính hiển vi", "Oscilloscope", "Đồng hồ vạn năng", "Bộ nguồn DC", "Máy hàn", "Bo mạch Arduino", "Cân điện tử" };
    private static readonly string[] Filters = { "Tất cả", "Đang mượn", "Quá hạn", "Đã trả" };

    public MainForm()
    {
        Text = "Lab Equipment Checkout";
        Size = new Size(1150, 720);
        MinimumSize = new Size(950, 600);
        StartPosition = FormStartPosition.CenterScreen;

        cboEquipment.Items.AddRange(Equipments);
        cboFilter.Items.AddRange(Filters);
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
        var status = new StatusStrip();
        status.Items.Add(lblStatus);

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(8) };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        // Input area
        var grp = new GroupBox { Text = "Phiếu mượn", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, AutoSize = true, Padding = new Padding(4) };
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        AddField(t, "Mã phiếu:", txtId, 0, 0);
        AddField(t, "Mã sinh viên:", txtStudentId, 2, 0);
        AddField(t, "Họ tên sinh viên:", txtStudentName, 0, 1);
        AddField(t, "Thiết bị:", cboEquipment, 2, 1);
        AddField(t, "Số lượng:", nudQty, 0, 2);
        AddField(t, "Ngày mượn:", dtpBorrow, 2, 2);
        AddField(t, "Hạn trả:", dtpDue, 0, 3);
        AddField(t, "Ngày trả thực tế:", dtpReturn, 2, 3);
        AddField(t, "Tình trạng:", txtStatus, 0, 4);

        var btns = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        btns.Controls.Add(MakeButton("Mới", (s, e) => ClearForm()));
        btns.Controls.Add(MakeButton("Thêm", (s, e) => AddCheckout()));
        btns.Controls.Add(MakeButton("Cập nhật", (s, e) => UpdateCheckout()));
        btns.Controls.Add(MakeButton("Xóa", (s, e) => DeleteCheckout()));
        btns.Controls.Add(MakeButton("Đánh dấu đã trả", (s, e) => MarkReturned()));
        btns.Controls.Add(MakeButton("Xuất CSV...", (s, e) => ExportCsv()));
        t.Controls.Add(btns, 0, 5);
        t.SetColumnSpan(btns, 4);
        grp.Controls.Add(t);

        // Filter area
        var grpF = new GroupBox { Text = "Tìm kiếm & lọc", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var f = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(4) };
        txtSearch.Width = 240;
        f.Controls.Add(MakeLabel("Mã SV / Tên thiết bị:"));
        f.Controls.Add(txtSearch);
        f.Controls.Add(MakeLabel("Tình trạng:"));
        f.Controls.Add(cboFilter);
        f.Controls.Add(MakeButton("Xóa bộ lọc", (s, e) => { txtSearch.Clear(); cboFilter.SelectedIndex = 0; }));
        grpF.Controls.Add(f);
        txtSearch.TextChanged += (s, e) => ApplyFilter();
        cboFilter.SelectedIndexChanged += (s, e) => ApplyFilter();

        // Grid (cột cấu hình thủ công)
        dgv.Dock = DockStyle.Fill;
        dgv.AutoGenerateColumns = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.Columns.Add(Col("Id", "Mã phiếu", 10));
        dgv.Columns.Add(Col("StudentId", "Mã SV", 10));
        dgv.Columns.Add(Col("StudentName", "Họ tên", 18));
        dgv.Columns.Add(Col("Equipment", "Thiết bị", 18));
        dgv.Columns.Add(Col("Quantity", "SL", 5));
        dgv.Columns.Add(DateCol("BorrowDate", "Ngày mượn"));
        dgv.Columns.Add(DateCol("DueDate", "Hạn trả"));
        dgv.Columns.Add(DateCol("ReturnDate", "Ngày trả"));
        dgv.Columns.Add(Col("Status", "Tình trạng", 10));
        dgv.SelectionChanged += (s, e) => LoadSelected();
        dgv.RowPrePaint += (s, e) =>
        {
            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].DataBoundItem is Checkout c)
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = c.IsOverdue ? Color.Firebrick : Color.Black;
        };

        root.Controls.Add(grp, 0, 0);
        root.Controls.Add(grpF, 0, 1);
        root.Controls.Add(dgv, 0, 2);
        Controls.Add(root);
        Controls.Add(status);
    }

    private static void AddField(TableLayoutPanel t, string label, Control c, int col, int row)
    {
        t.Controls.Add(new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 6, 8, 3) }, col, row);
        c.Dock = DockStyle.Fill;
        t.Controls.Add(c, col + 1, row);
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

    private static DataGridViewTextBoxColumn DateCol(string prop, string header)
    {
        var c = Col(prop, header, 11);
        c.DefaultCellStyle.Format = "dd/MM/yyyy";
        return c;
    }

    // ---------------- Data ----------------
    private void SeedData()
    {
        var d = DateTime.Today;
        _all.Add(new Checkout { Id = "PM001", StudentId = "SV001", StudentName = "Nguyễn Văn An", Equipment = Equipments[0], Quantity = 1, BorrowDate = d.AddDays(-10), DueDate = d.AddDays(-3) });
        _all.Add(new Checkout { Id = "PM002", StudentId = "SV002", StudentName = "Trần Thị Bình", Equipment = Equipments[1], Quantity = 2, BorrowDate = d.AddDays(-2), DueDate = d.AddDays(5) });
        _all.Add(new Checkout { Id = "PM003", StudentId = "SV003", StudentName = "Lê Hoàng Cường", Equipment = Equipments[2], Quantity = 3, BorrowDate = d.AddDays(-8), DueDate = d.AddDays(-1), ReturnDate = d.AddDays(-2) });
        _all.Add(new Checkout { Id = "PM004", StudentId = "SV004", StudentName = "Phạm Thu Dung", Equipment = Equipments[5], Quantity = 1, BorrowDate = d, DueDate = d.AddDays(7) });
    }

    private void ApplyFilter(string selectId = null)
    {
        string kw = txtSearch.Text.Trim();
        string st = cboFilter.SelectedItem as string ?? "Tất cả";
        var q = _all.Where(c =>
                (kw == "" || c.StudentId.Contains(kw, StringComparison.OrdinalIgnoreCase)
                          || c.Equipment.Contains(kw, StringComparison.OrdinalIgnoreCase))
                && (st == "Tất cả" || c.Status == st))
            .ToList();

        _loading = true;
        _view = new BindingList<Checkout>(q);
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

    private void UpdateStatusStrip() =>
        lblStatus.Text = $"Tổng số phiếu: {_view.Count}   |   Phiếu quá hạn: {_view.Count(c => c.IsOverdue)}";

    private void LoadSelected()
    {
        if (_loading || dgv.SelectedRows.Count == 0) return;
        if (dgv.SelectedRows[0].DataBoundItem is not Checkout c) return;
        _editing = c;
        txtId.Text = c.Id; txtId.ReadOnly = true;
        txtStudentId.Text = c.StudentId;
        txtStudentName.Text = c.StudentName;
        cboEquipment.SelectedItem = c.Equipment;
        nudQty.Value = Math.Clamp(c.Quantity, (int)nudQty.Minimum, (int)nudQty.Maximum);
        dtpBorrow.Value = c.BorrowDate;
        dtpDue.Value = c.DueDate;
        if (c.ReturnDate.HasValue) { dtpReturn.Checked = true; dtpReturn.Value = c.ReturnDate.Value; }
        else { dtpReturn.Checked = false; }
        txtStatus.Text = c.Status;
        _err.Clear();
    }

    private void ClearForm()
    {
        _editing = null;
        txtId.ReadOnly = false;
        txtId.Clear(); txtStudentId.Clear(); txtStudentName.Clear(); txtStatus.Clear();
        cboEquipment.SelectedIndex = -1;
        nudQty.Value = 1;
        dtpBorrow.Value = DateTime.Today;
        dtpDue.Value = DateTime.Today.AddDays(7);
        dtpReturn.Checked = false;
        _err.Clear();
        dgv.ClearSelection();
        txtId.Focus();
    }

    // ---------------- CRUD ----------------
    private static bool Confirm(string msg) =>
        MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void AddCheckout()
    {
        if (_editing != null) { MessageBox.Show("Bạn đang chọn một phiếu. Nhấn \"Mới\" để nhập phiếu mới.", "Thông báo"); return; }
        if (!ValidateForm(true)) return;
        if (!Confirm("Thêm phiếu mượn mới?")) return;
        var c = new Checkout();
        CopyToModel(c);
        _all.Add(c);
        ApplyFilter(c.Id);
    }

    private void UpdateCheckout()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một phiếu trong danh sách.", "Thông báo"); return; }
        if (!ValidateForm(false)) return;
        if (!Confirm("Cập nhật phiếu mượn này?")) return;
        CopyToModel(_editing);
        ApplyFilter(_editing.Id);
    }

    private void DeleteCheckout()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một phiếu trong danh sách.", "Thông báo"); return; }
        if (!Confirm($"Xóa phiếu {_editing.Id}?")) return;
        _all.Remove(_editing);
        _editing = null;
        ApplyFilter();
        ClearForm();
    }

    private void MarkReturned()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một phiếu trong danh sách.", "Thông báo"); return; }
        if (_editing.ReturnDate.HasValue) { MessageBox.Show("Phiếu này đã được trả.", "Thông báo"); return; }
        if (DateTime.Today < _editing.BorrowDate.Date)
        {
            MessageBox.Show("Ngày trả thực tế không được trước ngày mượn.", "Lỗi");
            return;
        }
        if (!Confirm($"Đánh dấu phiếu {_editing.Id} đã trả (ngày {DateTime.Today:dd/MM/yyyy})?")) return;
        _editing.ReturnDate = DateTime.Today;   // cập nhật ngày trả thực tế
        ApplyFilter(_editing.Id);               // tình trạng + StatusStrip được tính lại
    }

    private void CopyToModel(Checkout c)
    {
        c.Id = txtId.Text.Trim();
        c.StudentId = txtStudentId.Text.Trim();
        c.StudentName = txtStudentName.Text.Trim();
        c.Equipment = (string)cboEquipment.SelectedItem;
        c.Quantity = (int)nudQty.Value;
        c.BorrowDate = dtpBorrow.Value.Date;
        c.DueDate = dtpDue.Value.Date;
        c.ReturnDate = dtpReturn.Checked ? dtpReturn.Value.Date : null;
    }

    // ---------------- Validation ----------------
    private bool ValidateForm(bool isNew)
    {
        _err.Clear();
        bool ok = true;
        void Check(Control c, bool valid, string msg)
        {
            if (!valid) { _err.SetError(c, msg); ok = false; }
        }

        string id = txtId.Text.Trim();
        Check(txtId, id != "", "Mã phiếu là bắt buộc.");
        if (isNew && id != "")
            Check(txtId, !_all.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)), "Mã phiếu đã tồn tại.");

        Check(txtStudentId, txtStudentId.Text.Trim() != "", "Mã sinh viên không được để trống.");
        Check(txtStudentName, txtStudentName.Text.Trim() != "", "Họ tên sinh viên không được để trống.");
        Check(cboEquipment, cboEquipment.SelectedIndex >= 0, "Hãy chọn thiết bị.");
        Check(nudQty, nudQty.Value > 0, "Số lượng phải lớn hơn 0.");
        Check(dtpDue, dtpDue.Value.Date >= dtpBorrow.Value.Date, "Hạn trả không được trước ngày mượn.");
        if (dtpReturn.Checked)
            Check(dtpReturn, dtpReturn.Value.Date >= dtpBorrow.Value.Date, "Ngày trả thực tế không được trước ngày mượn.");
        return ok;
    }

    // ---------------- Export ----------------
    private static string Esc(string s) => "\"" + (s ?? "").Replace("\"", "\"\"") + "\"";

    private void ExportCsv()
    {
        using var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "phieu_muon.csv" };
        if (sfd.ShowDialog() != DialogResult.OK) return;
        var sb = new StringBuilder();
        sb.AppendLine("Mã phiếu,Mã SV,Họ tên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả,Tình trạng");
        foreach (var c in _view)
            sb.AppendLine(string.Join(",", new[]
            {
                c.Id, c.StudentId, c.StudentName, c.Equipment, c.Quantity.ToString(),
                c.BorrowDate.ToString("dd/MM/yyyy"), c.DueDate.ToString("dd/MM/yyyy"),
                c.ReturnDate?.ToString("dd/MM/yyyy") ?? "", c.Status
            }.Select(Esc)));
        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
        MessageBox.Show($"Đã xuất {_view.Count} phiếu.", "Xuất CSV");
    }
}
