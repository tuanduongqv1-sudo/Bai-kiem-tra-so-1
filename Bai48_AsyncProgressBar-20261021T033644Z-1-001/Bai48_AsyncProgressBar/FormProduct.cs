using System.ComponentModel;

namespace Bai48_AsyncProgressBar
{
    /// <summary>
    /// Form Quản lý Sản phẩm - MDI Child với hỗ trợ Async/Await và ProgressBar.
    /// </summary>
    public partial class FormProduct : Form, IProgressNotifier
    {
        private BindingList<Product> productList = new BindingList<Product>();

        public Action<string>? OnStatusChanged { get; set; }
        public Action<int>? OnProgressChanged { get; set; }

        public FormProduct()
        {
            InitializeComponent();
            SetupBindings();
        }

        private void SetupBindings()
        {
            bindingSource1.DataSource = productList;
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = bindingSource1;

            txtProductId.DataBindings.Add("Text", bindingSource1, "ProductId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtProductName.DataBindings.Add("Text", bindingSource1, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice.DataBindings.Add("Text", bindingSource1, "Price", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N0");
            txtQuantity.DataBindings.Add("Text", bindingSource1, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);

            btnLoadData.Click += BtnLoadData_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;

            ctxXoaDong.Click += (s, e) => BtnDelete_Click(s, e);
            ctxLamMoi.Click += async (s, e) => await LoadDataAsync();
            ctxXemChiTiet.Click += CtxXemChiTiet_Click;
        }

        // ==================== ASYNC/AWAIT - NẠP DỮ LIỆU BẤT ĐỒNG BỘ ====================

        private async void BtnLoadData_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            btnLoadData.Enabled = false;
            btnLoadData.Text = "Đang nạp...";
            progressBar1.Visible = true;
            lblProgress.Visible = true;
            progressBar1.Value = 0;
            lblProgress.Text = "0%";

            OnStatusChanged?.Invoke("Đang nạp dữ liệu sản phẩm...");
            OnProgressChanged?.Invoke(0);

            try
            {
                var progress = new Progress<int>(percent =>
                {
                    progressBar1.Value = percent;
                    lblProgress.Text = $"{percent}%";
                    OnProgressChanged?.Invoke(percent);
                });

                List<Product> loadedProducts = await DataService.LoadProductsAsync(progress);

                productList.Clear();
                foreach (var product in loadedProducts)
                {
                    productList.Add(product);
                }

                SetColumnHeaders();
                OnStatusChanged?.Invoke($"Đã nạp xong {loadedProducts.Count} sản phẩm!");
                MessageBox.Show($"Nạp thành công {loadedProducts.Count} sản phẩm!",
                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Lỗi nạp dữ liệu: {ex.Message}");
                MessageBox.Show($"Lỗi khi nạp dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadData.Enabled = true;
                btnLoadData.Text = "⏳ Nạp dữ liệu";
                progressBar1.Visible = false;
                lblProgress.Visible = false;
                OnProgressChanged?.Invoke(0);
            }
        }

        private void SetColumnHeaders()
        {
            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
                dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvProducts.Columns["Price"].HeaderText = "Đơn giá";
                dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";
                
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProducts.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // ==================== CRUD ====================

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            { MessageBox.Show("Vui lòng nhập Mã SP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { MessageBox.Show("Vui lòng nhập Tên SP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            { MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            { MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            foreach (var p in productList)
                if (p.ProductId == txtProductId.Text.Trim())
                { MessageBox.Show("Mã SP đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            productList.Add(new Product
            {
                ProductId = txtProductId.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = price,
                Quantity = quantity
            });
            bindingSource1.MoveLast();
            OnStatusChanged?.Invoke($"Đã thêm sản phẩm: {txtProductId.Text.Trim()}");
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current == null) return;
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
            if (bindingSource1.Current == null) return;
            bindingSource1.EndEdit();
            dgvProducts.Refresh();
            OnStatusChanged?.Invoke($"Đã cập nhật sản phẩm: {txtProductId.Text}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CtxXemChiTiet_Click(object? sender, EventArgs e)
        {
            if (bindingSource1.Current is Product p)
            {
                MessageBox.Show(
                    $"Mã SP: {p.ProductId}\nTên SP: {p.ProductName}\nĐơn giá: {p.Price:N0} VNĐ\nSố lượng: {p.Quantity}",
                    "Chi tiết Sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
