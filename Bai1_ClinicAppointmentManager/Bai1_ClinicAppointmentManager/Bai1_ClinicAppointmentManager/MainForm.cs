using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ClinicAppointmentManager;

public class MainForm : Form
{
    private readonly BindingList<Appointment> _all = new();
    private BindingList<Appointment> _view = new();
    private readonly BindingSource _bs = new();
    private readonly ErrorProvider _err = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private Appointment _editing;
    private bool _loading;

    private readonly TextBox txtId = new(), txtName = new(), txtPhone = new(), txtSearch = new();
    private readonly TextBox txtReason = new() { Multiline = true, Height = 50 };
    private readonly DateTimePicker dtpDate = new() { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
    private readonly DateTimePicker dtpFilter = new() { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false, Width = 130 };
    private readonly ComboBox cboDoctor = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboStatus = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboFilterStatus = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 130 };
    private readonly DataGridView dgv = new();
    private readonly ToolStripStatusLabel lblCount = new();

    private static readonly string[] Doctors = { "BS. Trần Minh", "BS. Lê Thu Hà", "BS. Phạm Quốc Bảo", "BS. Nguyễn Lan Anh" };
    private static readonly string[] Statuses = { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" };

    public MainForm()
    {
        Text = "Clinic Appointment Manager";
        Size = new Size(1100, 720);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;

        cboDoctor.Items.AddRange(Doctors);
        cboStatus.Items.AddRange(Statuses);
        cboFilterStatus.Items.Add("Tất cả");
        cboFilterStatus.Items.AddRange(Statuses);
        cboFilterStatus.SelectedIndex = 0;

        BuildUi();
        SeedData();

        dgv.DataSource = _bs;
        ApplyFilter();
        if (_view.Count == 0) ClearForm();
    }

    // ---------------- UI ----------------
    private void BuildUi()
    {
        // Menu + Status
        var menu = new MenuStrip();
        var mFile = new ToolStripMenuItem("Tệp");
        mFile.DropDownItems.Add(new ToolStripMenuItem("Xuất danh sách ra CSV...", null, (s, e) => ExportCsv()));
        mFile.DropDownItems.Add(new ToolStripSeparator());
        mFile.DropDownItems.Add(new ToolStripMenuItem("Thoát", null, (s, e) => Close()));
        menu.Items.Add(mFile);
        MainMenuStrip = menu;

        var status = new StatusStrip();
        status.Items.Add(lblCount);

        // Root layout
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(8) };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        // Input group
        var grpInput = new GroupBox { Text = "Thông tin lịch hẹn", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, AutoSize = true, Padding = new Padding(4) };
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        AddField(t, "Mã lịch hẹn:", txtId, 0, 0);
        AddField(t, "Họ tên bệnh nhân:", txtName, 2, 0);
        AddField(t, "Số điện thoại:", txtPhone, 0, 1);
        AddField(t, "Ngày giờ hẹn:", dtpDate, 2, 1);
        AddField(t, "Bác sĩ:", cboDoctor, 0, 2);
        AddField(t, "Trạng thái:", cboStatus, 2, 2);
        AddField(t, "Lý do khám:", txtReason, 0, 3, 3);

        var btns = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        btns.Controls.Add(MakeButton("Mới", (s, e) => ClearForm()));
        btns.Controls.Add(MakeButton("Thêm", (s, e) => AddAppointment()));
        btns.Controls.Add(MakeButton("Cập nhật", (s, e) => UpdateAppointment()));
        btns.Controls.Add(MakeButton("Xóa", (s, e) => DeleteAppointment()));
        t.Controls.Add(btns, 0, 4);
        t.SetColumnSpan(btns, 4);
        grpInput.Controls.Add(t);

        // Filter group
        var grpFilter = new GroupBox { Text = "Tìm kiếm & lọc", Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
        var f = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(4) };
        txtSearch.Width = 220;
        f.Controls.Add(MakeLabel("Tên / SĐT:"));
        f.Controls.Add(txtSearch);
        f.Controls.Add(MakeLabel("Ngày hẹn:"));
        f.Controls.Add(dtpFilter);
        f.Controls.Add(MakeLabel("Trạng thái:"));
        f.Controls.Add(cboFilterStatus);
        f.Controls.Add(MakeButton("Xóa bộ lọc", (s, e) =>
        {
            txtSearch.Clear(); dtpFilter.Checked = false; cboFilterStatus.SelectedIndex = 0;
        }));
        grpFilter.Controls.Add(f);

        txtSearch.TextChanged += (s, e) => ApplyFilter();
        dtpFilter.ValueChanged += (s, e) => ApplyFilter();
        cboFilterStatus.SelectedIndexChanged += (s, e) => ApplyFilter();

        // Grid
        dgv.Dock = DockStyle.Fill;
        dgv.AutoGenerateColumns = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.Columns.Add(Col("Id", "Mã lịch hẹn", 12));
        dgv.Columns.Add(Col("PatientName", "Bệnh nhân", 20));
        dgv.Columns.Add(Col("Phone", "SĐT", 14));
        var cDate = Col("AppointmentDate", "Ngày giờ hẹn", 16);
        cDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        dgv.Columns.Add(cDate);
        dgv.Columns.Add(Col("Doctor", "Bác sĩ", 18));
        dgv.Columns.Add(Col("Reason", "Lý do khám", 24));
        dgv.Columns.Add(Col("Status", "Trạng thái", 12));
        dgv.SelectionChanged += (s, e) => LoadSelected();

        root.Controls.Add(grpInput, 0, 0);
        root.Controls.Add(grpFilter, 0, 1);
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

    private static Label MakeLabel(string text) =>
        new Label { Text = text, AutoSize = true, Margin = new Padding(8, 8, 3, 3) };

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
        _all.Add(new Appointment { Id = "LH001", PatientName = "Nguyễn Văn An", Phone = "0901234567", AppointmentDate = d.AddDays(1).AddHours(9), Doctor = Doctors[0], Reason = "Khám tổng quát", Status = "Chờ khám" });
        _all.Add(new Appointment { Id = "LH002", PatientName = "Trần Thị Bình", Phone = "0912345678", AppointmentDate = d.AddDays(1).AddHours(10), Doctor = Doctors[1], Reason = "Đau đầu kéo dài", Status = "Đang khám" });
        _all.Add(new Appointment { Id = "LH003", PatientName = "Lê Hoàng Cường", Phone = "0987654321", AppointmentDate = d.AddDays(2).AddHours(14), Doctor = Doctors[2], Reason = "Tái khám tim mạch", Status = "Chờ khám" });
        _all.Add(new Appointment { Id = "LH004", PatientName = "Phạm Thu Dung", Phone = "0933444555", AppointmentDate = d.AddDays(3).AddHours(8), Doctor = Doctors[3], Reason = "Khám da liễu", Status = "Đã hủy" });
    }

    private void ApplyFilter(string selectId = null)
    {
        string kw = txtSearch.Text.Trim();
        string st = cboFilterStatus.SelectedItem as string ?? "Tất cả";
        var q = _all.Where(a =>
                (kw == "" || a.PatientName.Contains(kw, StringComparison.OrdinalIgnoreCase) || a.Phone.Contains(kw))
                && (!dtpFilter.Checked || a.AppointmentDate.Date == dtpFilter.Value.Date)
                && (st == "Tất cả" || a.Status == st))
            .ToList();

        _loading = true;
        _view = new BindingList<Appointment>(q);
        _bs.DataSource = _view;
        _loading = false;
        UpdateStatus();

        if (_view.Count == 0) { ClearForm(); return; }

        selectId ??= _editing?.Id;
        if (selectId == null) { dgv.ClearSelection(); return; } // đang ở chế độ nhập mới

        int idx = Math.Max(0, _view.ToList().FindIndex(x => x.Id == selectId));
        _bs.Position = idx;
        dgv.ClearSelection();
        dgv.Rows[idx].Selected = true;
        LoadSelected();
    }

    private void UpdateStatus() =>
        lblCount.Text = $"Số lịch hẹn: {_view.Count} (tổng cộng {_all.Count})";

    private void LoadSelected()
    {
        if (_loading || dgv.SelectedRows.Count == 0) return;
        if (dgv.SelectedRows[0].DataBoundItem is not Appointment a) return;
        _editing = a;
        txtId.Text = a.Id; txtId.ReadOnly = true;
        txtName.Text = a.PatientName;
        txtPhone.Text = a.Phone;
        dtpDate.Value = a.AppointmentDate;
        cboDoctor.SelectedItem = a.Doctor;
        cboStatus.SelectedItem = a.Status;
        txtReason.Text = a.Reason;
        _err.Clear();
    }

    private void ClearForm()
    {
        _editing = null;
        txtId.ReadOnly = false;
        txtId.Clear(); txtName.Clear(); txtPhone.Clear(); txtReason.Clear();
        var n = DateTime.Now.AddHours(1);
        dtpDate.Value = new DateTime(n.Year, n.Month, n.Day, n.Hour, 0, 0);
        cboDoctor.SelectedIndex = -1;
        cboStatus.SelectedIndex = 0;
        _err.Clear();
        dgv.ClearSelection();
        txtId.Focus();
    }

    // ---------------- CRUD ----------------
    private static bool Confirm(string msg) =>
        MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void AddAppointment()
    {
        if (_editing != null) { MessageBox.Show("Bạn đang chọn một lịch hẹn. Nhấn \"Mới\" để nhập lịch hẹn mới.", "Thông báo"); return; }
        if (!ValidateForm(true)) return;
        if (!Confirm("Thêm lịch hẹn mới?")) return;
        var a = new Appointment();
        CopyToModel(a);
        _all.Add(a);
        _editing = null;
        ApplyFilter(a.Id);
    }

    private void UpdateAppointment()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một lịch hẹn trong danh sách.", "Thông báo"); return; }
        if (!ValidateForm(false)) return;
        if (!Confirm("Cập nhật lịch hẹn này?")) return;
        CopyToModel(_editing);
        ApplyFilter(_editing.Id);
    }

    private void DeleteAppointment()
    {
        if (_editing == null) { MessageBox.Show("Hãy chọn một lịch hẹn trong danh sách.", "Thông báo"); return; }
        if (!Confirm($"Xóa lịch hẹn {_editing.Id}?")) return;
        _all.Remove(_editing);
        _editing = null;
        ApplyFilter();
        if (_view.Count > 0 && _editing == null) { ClearForm(); }
    }

    private void CopyToModel(Appointment a)
    {
        a.Id = txtId.Text.Trim();
        a.PatientName = txtName.Text.Trim();
        a.Phone = txtPhone.Text.Trim();
        var v = dtpDate.Value;
        a.AppointmentDate = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0);
        a.Doctor = (string)cboDoctor.SelectedItem;
        a.Status = (string)cboStatus.SelectedItem;
        a.Reason = txtReason.Text.Trim();
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
        Check(txtId, id != "", "Mã lịch hẹn là bắt buộc.");
        if (isNew && id != "")
            Check(txtId, !_all.Any(a => a.Id.Equals(id, StringComparison.OrdinalIgnoreCase)), "Mã lịch hẹn đã tồn tại.");

        Check(txtName, txtName.Text.Trim() != "", "Họ tên bệnh nhân là bắt buộc.");
        Check(txtPhone, Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9,10}$"),
            "Số điện thoại phải gồm 10-11 chữ số và bắt đầu bằng 0.");

        var v = dtpDate.Value;
        var picked = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0);
        bool dateChanged = isNew || _editing == null || picked != _editing.AppointmentDate;
        Check(dtpDate, !dateChanged || picked >= DateTime.Now, "Ngày hẹn không được nằm trong quá khứ.");

        Check(cboDoctor, cboDoctor.SelectedIndex >= 0, "Hãy chọn bác sĩ.");
        Check(cboStatus, cboStatus.SelectedIndex >= 0, "Hãy chọn trạng thái.");
        Check(txtReason, txtReason.Text.Trim() != "", "Lý do khám là bắt buộc.");
        return ok;
    }

    // ---------------- Export ----------------
    private static string Esc(string s) => "\"" + (s ?? "").Replace("\"", "\"\"") + "\"";

    private void ExportCsv()
    {
        using var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "lich_hen.csv" };
        if (sfd.ShowDialog() != DialogResult.OK) return;
        var sb = new StringBuilder();
        sb.AppendLine("Mã lịch hẹn,Họ tên,SĐT,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");
        foreach (var a in _view)
            sb.AppendLine(string.Join(",", new[] { a.Id, a.PatientName, a.Phone, a.AppointmentDate.ToString("dd/MM/yyyy HH:mm"), a.Doctor, a.Reason, a.Status }.Select(Esc)));
        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
        MessageBox.Show($"Đã xuất {_view.Count} lịch hẹn.", "Xuất CSV");
    }
}
