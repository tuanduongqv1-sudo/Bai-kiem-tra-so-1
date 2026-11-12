using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai5_3
{
    public partial class Form1 : Form
    {
        // Nguồn dữ liệu gốc trong bộ nhớ
        private readonly List<Product> products = new List<Product>();
        private string currentFilter = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Phụ kiện", "Gia dụng" });
            cboCategory.SelectedIndex = 0;

            // Dữ liệu mẫu
            products.Add(new Product("SP001", "iPhone 15", 22000000, 10, "Điện thoại"));
            products.Add(new Product("SP002", "Laptop Dell XPS", 35000000, 5, "Laptop"));
            products.Add(new Product("SP003", "Tai nghe Bluetooth", 850000, 40, "Phụ kiện"));
            products.Add(new Product("SP004", "Nồi chiên không dầu", 1900000, 15, "Gia dụng"));

            bsProducts.DataSource = products;
            dgvProducts.DataSource = bsProducts;
            RefreshGrid();
        }

        // Nạp lại DataGridView (có áp dụng bộ lọc tìm kiếm hiện tại)
        private void RefreshGrid()
        {
            var view = string.IsNullOrWhiteSpace(currentFilter)
                ? products.ToList()
                : products.Where(p => p.ProductName.IndexOf(currentFilter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            bsProducts.DataSource = view;
            bsProducts.ResetBindings(false);
        }

        // Đọc và kiểm tra dữ liệu từ các ô nhập liệu; trả về null nếu sai
        private Product ReadInput(bool kiemTraTrungMa, string maDangSua = null)
        {
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();

            if (id == "" || name == "")
            {
                MessageBox.Show("Mã SP và Tên SP không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            // Bỏ dấu chấm/phẩy ngăn cách hàng nghìn (22.000.000 hoặc 22,000,000) rồi mới đọc số
            string rawPrice = txtPrice.Text.Trim().Replace(".", "").Replace(",", "").Replace(" ", "");
            if (!decimal.TryParse(rawPrice, NumberStyles.Integer, CultureInfo.InvariantCulture, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return null;
            }
            if (kiemTraTrungMa && products.Any(p => p.ProductId.Equals(id, StringComparison.OrdinalIgnoreCase)
                                                    && !p.ProductId.Equals(maDangSua, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm '" + id + "' đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return null;
            }
            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQuantity.Focus();
                return null;
            }
            return new Product(id, name, price, (int)nudQuantity.Value, cboCategory.Text);
        }

        // ===== Thêm =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = ReadInput(true);
            if (p == null) return;
            products.Add(p);
            RefreshGrid();
            ClearInput();
        }

        // ===== Click vào dòng -> đẩy dữ liệu lên ô nhập =====
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Product p = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (p == null) return;
            txtId.Text = p.ProductId;
            txtName.Text = p.ProductName;
            txtPrice.Text = p.UnitPrice.ToString("0", CultureInfo.InvariantCulture);
            nudQuantity.Value = Math.Max(nudQuantity.Minimum, Math.Min(p.Quantity, nudQuantity.Maximum));
            cboCategory.Text = p.Category;
        }

        // ===== Sửa =====
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product selected = LaySanPhamDangChon();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Product p = ReadInput(true, selected.ProductId);
            if (p == null) return;

            selected.ProductId = p.ProductId;
            selected.ProductName = p.ProductName;
            selected.UnitPrice = p.UnitPrice;
            selected.Quantity = p.Quantity;
            selected.Category = p.Category;
            RefreshGrid();
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Xóa (có xác nhận) =====
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product selected = LaySanPhamDangChon();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm '" + selected.ProductName + "' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                products.Remove(selected);
                RefreshGrid();
                ClearInput();
            }
        }

        // ===== Tìm kiếm theo Tên SP =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentFilter = txtSearch.Text.Trim();
            RefreshGrid();
            if (currentFilter != "" && bsProducts.Count == 0)
                MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Product LaySanPhamDangChon()
        {
            if (dgvProducts.CurrentRow == null) return null;
            return dgvProducts.CurrentRow.DataBoundItem as Product;
        }

        private void ClearInput()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            nudQuantity.Value = 1;
            cboCategory.SelectedIndex = 0;
            txtId.Focus();
        }
    }
}
