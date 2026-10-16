using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Bai_KT2_2
{
    public partial class Form1 : Form
    {
        private BindingList<Product> productList;
        private BindingSource bindingSource;
        private ErrorProvider errorProvider;
        private int idCounter = 1;
        private string currentImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            this.Text = "frmInventoryManager";

            errorProvider = new ErrorProvider();
            productList = new BindingList<Product>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = productList;

            productList.ListChanged += ProductList_ListChanged;

            InitCategories();
            InitDataGridView();
            InitTimer();

            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            dgvInventory.CellClick += DgvInventory_CellClick;

            // MenuStrip & ToolStrip events
            openFileToolStripMenuItem.Click += ImportCsvToolStripMenuItem_Click;
            saveReportToolStripMenuItem.Click += ExportCsvToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += (s, e) => this.Close();
            importCSVToolStripMenuItem.Click += ImportCsvToolStripMenuItem_Click;
            exportCSVToolStripMenuItem.Click += ExportCsvToolStripMenuItem_Click;
        }

        private void InitCategories()
        {
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện" });
            cboCategory.SelectedIndex = -1;
        }

        private void InitDataGridView()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.ReadOnly = true;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 };
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên sản phẩm", Width = 140 };
            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại", Width = 100 };
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", Width = 100 };
            colPrice.DefaultCellStyle.Format = "N0";
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 80 };
            DataGridViewTextBoxColumn colImage = new DataGridViewTextBoxColumn { DataPropertyName = "ImagePath", HeaderText = "Đường dẫn ảnh", Width = 150 };

            dgvInventory.Columns.Clear();
            dgvInventory.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colCategory, colPrice, colQuantity, colImage });
            dgvInventory.DataSource = bindingSource;
        }

        private void InitTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtProductId.ReadOnly = true;
            txtProductId.Text = "PRD" + idCounter.ToString("D3");
            UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            int totalQty = 0;
            decimal totalVal = 0;
            foreach (var p in productList)
            {
                totalQty += p.Quantity;
                totalVal += p.Price * p.Quantity;
            }
            lblTotalQuantity.Text = $"Tổng số lượng: {totalQty}";
            lblTotalPrice.Text = $"Tổng giá trị kho: {totalVal:N0} VNĐ";
        }

        private void ProductList_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picProductImage.Image = Image.FromFile(currentImagePath);
                    picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }
            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại sản phẩm!");
                isValid = false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ >= 0!");
                isValid = false;
            }
            return isValid;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            Product p = new Product
            {
                ProductId = txtProductId.Text,
                ProductName = txtProductName.Text.Trim(),
                Category = cboCategory.SelectedItem.ToString(),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value,
                ImagePath = currentImagePath
            };

            productList.Add(p);
            idCounter++;
            ClearInputs();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateData()) return;

            Product selected = bindingSource.Current as Product;
            if (selected != null)
            {
                selected.ProductName = txtProductName.Text.Trim();
                selected.Category = cboCategory.SelectedItem.ToString();
                selected.Price = decimal.Parse(txtPrice.Text);
                selected.Quantity = (int)numQuantity.Value;
                selected.ImagePath = currentImagePath;

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Product selected = bindingSource.Current as Product;
                if (selected != null)
                {
                    productList.Remove(selected);
                    ClearInputs();
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvInventory.ClearSelection();
        }

        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product selected = bindingSource.Current as Product;
                if (selected != null)
                {
                    txtProductId.Text = selected.ProductId;
                    txtProductName.Text = selected.ProductName;
                    cboCategory.SelectedItem = selected.Category;
                    txtPrice.Text = selected.Price.ToString();
                    numQuantity.Value = selected.Quantity;
                    currentImagePath = selected.ImagePath;

                    if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    {
                        picProductImage.Image = Image.FromFile(currentImagePath);
                        picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picProductImage.Image = null;
                    }
                }
            }
        }

        private void ExportCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "InventoryReport.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("ProductId,ProductName,Category,Price,Quantity,ImagePath");
                            foreach (var p in productList)
                            {
                                sw.WriteLine($"{p.ProductId},{p.ProductName},{p.Category},{p.Price},{p.Quantity},{p.ImagePath}");
                            }
                        }
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV file (*.csv)|*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        productList.Clear();
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split(',');
                            if (parts.Length >= 6)
                            {
                                productList.Add(new Product
                                {
                                    ProductId = parts[0],
                                    ProductName = parts[1],
                                    Category = parts[2],
                                    Price = decimal.Parse(parts[3]),
                                    Quantity = int.Parse(parts[4]),
                                    ImagePath = parts[5]
                                });
                            }
                        }
                        MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ClearInputs()
        {
            txtProductId.Text = "PRD" + idCounter.ToString("D3");
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            picProductImage.Image = null;
            currentImagePath = string.Empty;
            errorProvider.Clear();
        }

        // CÁC HÀM SỰ KIỆN PHÒNG HỜ ĐỂ TRÁNH MẤT DESIGNER
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void systemToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void txtProductId_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtProductName_TextChanged(object sender, EventArgs e) { }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtPrice_TextChanged(object sender, EventArgs e) { }
        private void numQuantity_ValueChanged(object sender, EventArgs e) { }
        private void picProductImage_Click(object sender, EventArgs e) { }
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotalQuantity_Click(object sender, EventArgs e) { }
        private void lblTotalPrice_Click(object sender, EventArgs e) { }
        private void lblTime_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e) { }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}