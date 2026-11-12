using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bai5_4
{
    public partial class Form1 : Form
    {
        // Chỉ số ảnh trong ImageList
        private const int ICON_COMPANY = 0, ICON_DEPT = 1, ICON_GROUP = 2, ICON_EMP = 3;

        private readonly List<Employee> employees = new List<Employee>
        {
            new Employee("NV001", "Nguyễn Văn An",   "Trưởng nhóm",    new DateTime(2019, 3, 15),  "Phòng Kỹ thuật",  "Nhóm Phát triển"),
            new Employee("NV002", "Trần Thị Bình",   "Lập trình viên", new DateTime(2021, 7, 1),   "Phòng Kỹ thuật",  "Nhóm Phát triển"),
            new Employee("NV003", "Lê Minh Cường",   "Lập trình viên", new DateTime(2022, 1, 10),  "Phòng Kỹ thuật",  "Nhóm Phát triển"),
            new Employee("NV004", "Phạm Thu Dung",   "Kiểm thử viên",  new DateTime(2020, 9, 20),  "Phòng Kỹ thuật",  "Nhóm Kiểm thử"),
            new Employee("NV005", "Hoàng Quốc Em",   "Trưởng nhóm",    new DateTime(2018, 5, 5),   "Phòng Kỹ thuật",  "Nhóm Kiểm thử"),
            new Employee("NV006", "Vũ Thị Phượng",   "Chuyên viên",    new DateTime(2020, 2, 18),  "Phòng Nhân sự",   "Nhóm Tuyển dụng"),
            new Employee("NV007", "Đặng Văn Giang",  "Trưởng nhóm",    new DateTime(2017, 11, 30), "Phòng Nhân sự",   "Nhóm Tuyển dụng"),
            new Employee("NV008", "Bùi Thanh Hà",    "Chuyên viên",    new DateTime(2023, 4, 3),   "Phòng Nhân sự",   "Nhóm Đào tạo"),
            new Employee("NV009", "Ngô Đức Huy",     "Trưởng phòng",   new DateTime(2016, 8, 22),  "Phòng Kinh doanh","Nhóm Miền Bắc"),
            new Employee("NV010", "Đỗ Mai Lan",      "Nhân viên KD",   new DateTime(2022, 6, 12),  "Phòng Kinh doanh","Nhóm Miền Bắc"),
            new Employee("NV011", "Lý Hoàng Nam",    "Nhân viên KD",   new DateTime(2021, 12, 1),  "Phòng Kinh doanh","Nhóm Miền Nam"),
            new Employee("NV012", "Mai Thị Oanh",    "Nhân viên KD",   new DateTime(2024, 1, 15),  "Phòng Kinh doanh","Nhóm Miền Nam"),
        };

        public Form1()
        {
            InitializeComponent();
            TaoImageList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp các chế độ xem vào ComboBox
            cboView.Items.AddRange(new object[] { "Details", "SmallIcon", "LargeIcon", "Tile", "List" });
            cboView.SelectedIndex = 0;

            XayDungCay();
            tvDepartments.ExpandAll();
            tvDepartments.SelectedNode = tvDepartments.Nodes[0];   // chọn gốc -> hiện toàn bộ nhân viên
        }

        // ===== Tạo biểu tượng cho ImageList (có thể thay bằng icon .ico/.png qua Designer) =====
        private void TaoImageList()
        {
            Color[] mau = { Color.SteelBlue, Color.Goldenrod, Color.SeaGreen, Color.IndianRed };
            for (int i = 0; i < 4; i++)
            {
                imgSmall.Images.Add(VeIcon(16, mau[i], i));
                imgLarge.Images.Add(VeIcon(32, mau[i], i));
            }
        }

        private Bitmap VeIcon(int size, Color color, int kind)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush b = new SolidBrush(color))
            using (Brush w = new SolidBrush(Color.White))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int m = size / 8;
                switch (kind)
                {
                    case ICON_COMPANY:   // tòa nhà
                        g.FillRectangle(b, m * 2, m, size - m * 4, size - m * 2);
                        for (int r = 0; r < 3; r++)
                            for (int c = 0; c < 2; c++)
                                g.FillRectangle(w, m * 3 + c * m * 2, m * 2 + r * m * 2, m, m);
                        break;
                    case ICON_DEPT:      // thư mục
                        g.FillRectangle(b, m, m * 2, size / 2 - m, m * 2);
                        g.FillRectangle(b, m, m * 3, size - m * 2, size - m * 5);
                        break;
                    case ICON_GROUP:     // nhóm người
                        g.FillEllipse(b, m, m * 2, m * 3, m * 3);
                        g.FillEllipse(b, size - m * 4, m * 2, m * 3, m * 3);
                        g.FillEllipse(b, size / 2 - m * 2, m, m * 4, m * 4);
                        g.FillEllipse(b, m, size / 2, size - m * 2, size / 2 - m);
                        break;
                    default:             // một người
                        g.FillEllipse(b, size / 2 - m * 2, m, m * 4, m * 4);
                        g.FillEllipse(b, m * 2, size / 2, size - m * 4, size / 2 - m);
                        break;
                }
            }
            return bmp;
        }

        // 1. Xây dựng cây: Công ty -> Phòng ban -> Nhóm
        private void XayDungCay()
        {
            tvDepartments.Nodes.Clear();

            TreeNode root = new TreeNode("Công ty ABC", ICON_COMPANY, ICON_COMPANY)
            {
                Tag = new NodeInfo { Level = 0 }
            };

            foreach (var dept in employees.Select(x => x.Department).Distinct())
            {
                TreeNode nDept = new TreeNode(dept, ICON_DEPT, ICON_DEPT)
                {
                    Tag = new NodeInfo { Level = 1, Department = dept }
                };
                foreach (var grp in employees.Where(x => x.Department == dept).Select(x => x.Group).Distinct())
                {
                    nDept.Nodes.Add(new TreeNode(grp, ICON_GROUP, ICON_GROUP)
                    {
                        Tag = new NodeInfo { Level = 2, Department = dept, Group = grp }
                    });
                }
                root.Nodes.Add(nDept);
            }
            tvDepartments.Nodes.Add(root);
        }

        // 2. Chọn Node -> lọc nhân viên và nạp vào ListView
        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeInfo info = e.Node.Tag as NodeInfo;
            if (info == null) return;

            IEnumerable<Employee> ds = employees;
            if (info.Level == 1) ds = employees.Where(x => x.Department == info.Department);
            else if (info.Level == 2) ds = employees.Where(x => x.Department == info.Department && x.Group == info.Group);

            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();
            foreach (Employee emp in ds)
            {
                ListViewItem item = new ListViewItem(emp.Id) { ImageIndex = ICON_EMP };
                item.SubItems.Add(emp.FullName);
                item.SubItems.Add(emp.Position);
                item.SubItems.Add(emp.StartDate.ToString("dd/MM/yyyy"));
                lsvEmployees.Items.Add(item);
            }
            lsvEmployees.EndUpdate();

            lblStatus.Text = "Đang xem: " + e.Node.Text + " — " + lsvEmployees.Items.Count + " nhân viên";
        }

        // Đổi chế độ xem của ListView
        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboView.SelectedItem.ToString())
            {
                case "Details":   lsvEmployees.View = View.Details; break;
                case "SmallIcon": lsvEmployees.View = View.SmallIcon; break;
                case "LargeIcon": lsvEmployees.View = View.LargeIcon; break;
                case "Tile":      lsvEmployees.View = View.Tile; break;
                case "List":      lsvEmployees.View = View.List; break;
            }
        }
    }
}
