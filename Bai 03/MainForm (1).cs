using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechMart.Models;

namespace TechMart
{
    public partial class MainForm : Form
    {
        // masterList: nguồn dữ liệu gốc (chứa TẤT CẢ sản phẩm)
        private readonly List<Product> _masterList = new List<Product>();

        // displayList: danh sách đang hiển thị trên Grid (có thể bị lọc bởi ô tìm kiếm)
        private readonly BindingList<Product> _displayList = new BindingList<Product>();

        // BindingSource: trung gian giữa dữ liệu và DataGridView (yêu cầu của đề)
        private readonly BindingSource _bindingSource = new BindingSource();

        // Sản phẩm đang được chọn trên Grid (để Cập nhật / Xóa)
        private Product? _selected;

        public MainForm()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
        }

        /// <summary>Thiết lập ComboBox danh mục và Data Binding ban đầu.</summary>
        private void KhoiTaoDuLieu()
        {
            // Nạp danh mục cho ComboBox + gán DisplayMember / ValueMember
            var danhMucs = new List<DanhMuc>
            {
                new DanhMuc(1, "Điện thoại"),
                new DanhMuc(2, "Laptop"),
                new DanhMuc(3, "Phụ kiện")
            };
            cboCategory.DataSource = danhMucs;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            // Nối BindingSource -> DataGridView
            _bindingSource.DataSource = _displayList;
            dgvProducts.DataSource = _bindingSource;

            // Vài dòng dữ liệu mẫu cho dễ test
            _masterList.Add(new Product { ProductId = "SP001", ProductName = "iPhone 15", Category = "Điện thoại", UnitPrice = 22000000, Quantity = 10 });
            _masterList.Add(new Product { ProductId = "SP002", ProductName = "Laptop Dell XPS", Category = "Laptop", UnitPrice = 30000000, Quantity = 5 });

            LamMoiGrid();
        }

        // =============== VALIDATION ===============
        /// <summary>Kiểm tra dữ liệu nhập; hiện ErrorProvider nếu sai. Trả về true nếu hợp lệ.</summary>
        private bool KiemTraHopLe(out decimal donGia, out int soLuong)
        {
            bool hopLe = true;
            donGia = 0;
            soLuong = 0;

            // Xóa lỗi cũ
            errorProvider.SetError(txtProductName, "");
            errorProvider.SetError(txtUnitPrice, "");
            errorProvider.SetError(txtQuantity, "");

            // Tên SP không được trống
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                hopLe = false;
            }

            // Đơn giá > 0
            if (!decimal.TryParse(txtUnitPrice.Text, out donGia) || donGia <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số và lớn hơn 0!");
                hopLe = false;
            }

            // Số lượng >= 0
            if (!int.TryParse(txtQuantity.Text, out soLuong) || soLuong < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0!");
                hopLe = false;
            }

            return hopLe;
        }

        // =============== THÊM MỚI ===============
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!KiemTraHopLe(out decimal donGia, out int soLuong))
                return;

            var sp = new Product
            {
                ProductId = string.IsNullOrWhiteSpace(txtProductId.Text) ? "SP" + (_masterList.Count + 1).ToString("000") : txtProductId.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Category = cboCategory.Text,
                UnitPrice = donGia,
                Quantity = soLuong,
                ImagePath = picAvatar.Tag?.ToString() ?? string.Empty
            };

            _masterList.Add(sp);
            LamMoiGrid();
            XoaForm();
        }

        // =============== CẬP NHẬT ===============
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm trên bảng để cập nhật.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!KiemTraHopLe(out decimal donGia, out int soLuong))
                return;

            // Sửa trực tiếp trên đối tượng trong masterList
            _selected.ProductName = txtProductName.Text.Trim();
            _selected.Category = cboCategory.Text;
            _selected.UnitPrice = donGia;
            _selected.Quantity = soLuong;
            _selected.ImagePath = picAvatar.Tag?.ToString() ?? _selected.ImagePath;

            LamMoiGrid();
            XoaForm();
        }

        // =============== XÓA ===============
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm trên bảng để xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tl = MessageBox.Show($"Bạn có chắc muốn xóa \"{_selected.ProductName}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (tl == DialogResult.Yes)
            {
                _masterList.Remove(_selected);
                LamMoiGrid();
                XoaForm();
            }
        }

        // =============== CLICK CHỌN DÒNG -> NẠP NGƯỢC LÊN FORM ===============
        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product sp)
            {
                _selected = sp;
                txtProductId.Text = sp.ProductId;
                txtProductName.Text = sp.ProductName;
                txtUnitPrice.Text = sp.UnitPrice.ToString(CultureInfo.InvariantCulture);
                txtQuantity.Text = sp.Quantity.ToString();
                cboCategory.Text = sp.Category;

                // Nạp lại ảnh nếu còn file
                picAvatar.Tag = sp.ImagePath;
                if (!string.IsNullOrEmpty(sp.ImagePath) && File.Exists(sp.ImagePath))
                    picAvatar.Image = Image.FromFile(sp.ImagePath);
                else
                    picAvatar.Image = null;
            }
        }

        // =============== CHỌN ẢNH ===============
        private void btnChooseImage_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh sản phẩm",
                Filter = "Tệp ảnh (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(ofd.FileName);
                picAvatar.Tag = ofd.FileName; // lưu đường dẫn để ghi vào Product
            }
        }

        // =============== LIVE SEARCH ===============
        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            LamMoiGrid();
        }

        // =============== EXPORT CSV ===============
        private void mnuExportCsv_Click(object? sender, EventArgs e)
        {
            if (_masterList.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = "DanhSachSanPham.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            sb.AppendLine("Mã SP,Tên SP,Danh mục,Đơn giá,Số lượng");
            foreach (var sp in _masterList)
            {
                // Bọc tên trong dấu "" phòng khi có dấu phẩy
                sb.AppendLine($"{sp.ProductId},\"{sp.ProductName}\",{sp.Category},{sp.UnitPrice},{sp.Quantity}");
            }

            // Encoding UTF-8 có BOM để Excel đọc đúng tiếng Việt
            File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Xuất CSV thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuExit_Click(object? sender, EventArgs e) => this.Close();

        // =============== HÀM TIỆN ÍCH ===============
        /// <summary>Dựng lại danh sách hiển thị từ masterList, áp dụng bộ lọc tìm kiếm + cập nhật status.</summary>
        private void LamMoiGrid()
        {
            string tuKhoa = txtSearch.Text.Trim().ToLower();

            IEnumerable<Product> ketQua = _masterList;
            if (!string.IsNullOrEmpty(tuKhoa))
                ketQua = _masterList.Where(p => p.ProductName.ToLower().Contains(tuKhoa));

            _displayList.Clear();
            foreach (var sp in ketQua)
                _displayList.Add(sp);

            _bindingSource.ResetBindings(false);
            lblTotal.Text = $"Tổng số sản phẩm: {_masterList.Count}";
        }

        /// <summary>Xóa trắng các ô nhập và bỏ chọn.</summary>
        private void XoaForm()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            picAvatar.Image = null;
            picAvatar.Tag = null;
            _selected = null;

            errorProvider.SetError(txtProductName, "");
            errorProvider.SetError(txtUnitPrice, "");
            errorProvider.SetError(txtQuantity, "");
        }
    }
}
