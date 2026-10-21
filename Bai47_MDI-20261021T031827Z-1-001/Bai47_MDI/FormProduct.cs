using System.ComponentModel;

namespace Bai47_MDI
{
    /// <summary>
    /// Form Quản lý Sản phẩm - MDI Child.
    /// Implement IStatusNotifier để giao tiếp với FormMain.
    /// </summary>
    public partial class FormProduct : Form, IStatusNotifier
    {
        private BindingList<Product> productList = new BindingList<Product>();

        public Action<string>? OnStatusChanged { get; set; }

        public FormProduct()
        {
            InitializeComponent();
            SetupBindings();
            LoadSampleData();
        }

        private void SetupBindings()
        {
            bindingSource1.DataSource = productList;

            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = bindingSource1;

            txtProductId.DataBindings.Add("Text", bindingSource1, "ProductId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtProductName.DataBindings.Add("Text", bindingSource1, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice.DataBindings.Add("Text", bindingSource1, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            txtQuantity.DataBindings.Add("Text", bindingSource1, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;

            ctxXoaDong.Click += (s, e) => BtnDelete_Click(s, e);
            ctxLamMoi.Click += CtxLamMoi_Click;
            ctxXemChiTiet.Click += CtxXemChiTiet_Click;
        }

        private void LoadSampleData()
        {
            productList.Add(new Product { ProductId = "SP001", ProductName = "Laptop Dell", Price = 15000000, Quantity = 10 });
            productList.Add(new Product { ProductId = "SP002", ProductName = "Chuột Logitech", Price = 350000, Quantity = 50 });
            productList.Add(new Product { ProductId = "SP003", ProductName = "Bàn phím cơ", Price = 1200000, Quantity = 30 });

            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
                dgvProducts.Columns["ProductName"].HeaderText = "Tên SP";
                dgvProducts.Columns["Price"].HeaderText = "Đơn giá";
                dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            { MessageBox.Show("Vui lòng nhập Mã SP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { MessageBox.Show("Vui lòng nhập Tên SP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            { MessageBox.Show("Đơn giá phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            { MessageBox.Show("Số lượng phải là số nguyên >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            foreach (var p in productList)
            {
                if (p.ProductId == txtProductId.Text.Trim())
                { MessageBox.Show("Mã SP đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            productList.Add(new Product
            {
                ProductId = txtProductId.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = price,
                Quantity = qty
            });

            bindingSource1.MoveLast();
            OnStatusChanged?.Invoke($"Đã thêm sản phẩm: {txtProductId.Text.Trim()}");
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("Không có sản phẩm nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var product = (Product)bindingSource1.Current;
            if (MessageBox.Show($"Xóa sản phẩm {product.ProductId}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string id = product.ProductId;
                bindingSource1.RemoveCurrent();
                OnStatusChanged?.Invoke($"Đã xóa sản phẩm: {id}");
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("Không có sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            bindingSource1.EndEdit();
            dgvProducts.Refresh();
            OnStatusChanged?.Invoke($"Đã cập nhật sản phẩm: {txtProductId.Text}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CtxLamMoi_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Làm mới toàn bộ dữ liệu?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                productList.Clear();
                LoadSampleData();
                OnStatusChanged?.Invoke("Đã làm mới dữ liệu sản phẩm");
            }
        }

        private void CtxXemChiTiet_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is Product p)
            {
                string detail = $"Mã SP: {p.ProductId}\n" +
                                $"Tên SP: {p.ProductName}\n" +
                                $"Đơn giá: {p.Price:N0} VNĐ\n" +
                                $"Số lượng: {p.Quantity}";
                MessageBox.Show(detail, "Chi tiết Sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
