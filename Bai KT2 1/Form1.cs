using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_KT2__1
{
    // 1. ĐẶT CLASS FORM1 LÊN ĐẦU TIÊN
    public partial class Form1 : Form
    {
        private BindingList<Device> deviceList;
        private BindingSource bindingSource;
        private ErrorProvider errorProvider;
        private int idCounter = 1;

        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            deviceList = new BindingList<Device>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = deviceList;

            InitCategories();
            InitDataGridView();

            this.Load += Form1_Load;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            dgvDevices.CellClick += DgvDevices_CellClick;
        }

        private void InitCategories()
        {
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.Add("Điện thoại");
            cboCategory.Items.Add("Laptop");
            cboCategory.Items.Add("Máy tính bảng");
            cboCategory.Items.Add("Phụ kiện");
            cboCategory.SelectedIndex = -1;
        }

        private void InitDataGridView()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.ReadOnly = true;
            dgvDevices.MultiSelect = false;
            dgvDevices.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "DeviceId";
            colId.HeaderText = "Mã thiết bị";
            colId.Width = 100;

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "DeviceName";
            colName.HeaderText = "Tên thiết bị";
            colName.Width = 150;

            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn();
            colCategory.DataPropertyName = "Category";
            colCategory.HeaderText = "Loại thiết bị";
            colCategory.Width = 120;

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Đơn giá";
            colPrice.Width = 100;
            colPrice.DefaultCellStyle.Format = "N0";

            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Số lượng tồn";
            colQuantity.Width = 100;

            dgvDevices.Columns.Clear();
            dgvDevices.Columns.Add(colId);
            dgvDevices.Columns.Add(colName);
            dgvDevices.Columns.Add(colCategory);
            dgvDevices.Columns.Add(colPrice);
            dgvDevices.Columns.Add(colQuantity);

            dgvDevices.DataSource = bindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Text = "DEV" + idCounter.ToString("D3");
        }

        private bool ValidateData()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            Device newDevice = new Device
            {
                DeviceId = txtDeviceId.Text,
                DeviceName = txtDeviceName.Text.Trim(),
                Category = cboCategory.SelectedItem.ToString(),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value
            };

            deviceList.Add(newDevice);
            idCounter++;
            ClearInputs();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật trên lưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateData()) return;

            Device selectedDevice = bindingSource.Current as Device;
            if (selectedDevice != null)
            {
                selectedDevice.DeviceName = txtDeviceName.Text.Trim();
                selectedDevice.Category = cboCategory.SelectedItem.ToString();
                selectedDevice.Price = decimal.Parse(txtPrice.Text);
                selectedDevice.Quantity = (int)numQuantity.Value;

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa trên lưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Device selectedDevice = bindingSource.Current as Device;
                if (selectedDevice != null)
                {
                    deviceList.Remove(selectedDevice);
                    ClearInputs();
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvDevices.ClearSelection();
        }

        private void DgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Device selectedDevice = bindingSource.Current as Device;
                if (selectedDevice != null)
                {
                    txtDeviceId.Text = selectedDevice.DeviceId;
                    txtDeviceName.Text = selectedDevice.DeviceName;
                    cboCategory.SelectedItem = selectedDevice.Category;
                    txtPrice.Text = selectedDevice.Price.ToString();
                    numQuantity.Value = selectedDevice.Quantity;
                }
            }
        }

        private void ClearInputs()
        {
            txtDeviceId.Text = "DEV" + idCounter.ToString("D3");
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtPrince_TextChanged(object sender, EventArgs e) { }
        private void numQuantiy_ValueChanged(object sender, EventArgs e) { }
    }

    // 2. ĐẶT CLASS DEVICE XUỐNG DƯỚI CÙNG
    public class Device
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}