using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai5_2
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo vn = CultureInfo.GetCultureInfo("vi-VN");

        // Dữ liệu mẫu: loại dịch vụ -> danh sách dịch vụ
        private readonly Dictionary<string, List<Service>> data = new Dictionary<string, List<Service>>
        {
            ["Khám bệnh"] = new List<Service>
            {
                new Service("Khám tổng quát", 150000),
                new Service("Khám nội", 120000),
                new Service("Khám tai mũi họng", 130000),
                new Service("Khám da liễu", 140000)
            },
            ["Xét nghiệm"] = new List<Service>
            {
                new Service("Xét nghiệm máu", 200000),
                new Service("Xét nghiệm nước tiểu", 100000),
                new Service("Xét nghiệm đường huyết", 80000),
                new Service("Xét nghiệm mỡ máu", 180000)
            },
            ["Chụp X-Quang"] = new List<Service>
            {
                new Service("X-Quang phổi", 250000),
                new Service("X-Quang xương khớp", 300000),
                new Service("X-Quang răng", 150000),
                new Service("X-Quang cột sống", 350000)
            },
            ["Vắc-xin"] = new List<Service>
            {
                new Service("Vắc-xin cúm", 350000),
                new Service("Vắc-xin viêm gan B", 280000),
                new Service("Vắc-xin uốn ván", 220000),
                new Service("Vắc-xin phế cầu", 900000)
            }
        };

        // Mã giảm giá -> % chiết khấu
        private readonly Dictionary<string, int> coupons = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            ["GIAM10"] = 10,
            ["GIAM20"] = 20,
            ["VIP30"] = 30
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.Items.AddRange(data.Keys.ToArray());
            cboCategory.SelectedIndex = 0;      // kích hoạt SelectedIndexChanged
            CapNhatTien();
        }

        // 1. Đổi loại dịch vụ -> nạp danh sách tương ứng
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();
            if (cboCategory.SelectedItem == null) return;
            foreach (Service s in data[cboCategory.SelectedItem.ToString()])
                lstAvailableServices.Items.Add(s);
        }

        // 2. Nút > : chuyển dịch vụ đang chọn sang danh sách đã chọn
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ChuyenDichVuDangChon();
        }

        // 2. Double click vào item bên trái
        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            ChuyenDichVuDangChon();
        }

        private void ChuyenDichVuDangChon()
        {
            Service s = lstAvailableServices.SelectedItem as Service;
            if (s == null)
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lstSelectedServices.Items.Contains(s))
            {
                MessageBox.Show("Dịch vụ này đã được chọn rồi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lstSelectedServices.Items.Add(s);
            CapNhatTien();      // 3. tự động tính lại
        }

        // Nút < : bỏ các dịch vụ đang chọn bên phải
        private void btnRemove_Click(object sender, EventArgs e)
        {
            XoaDichVuDangChon();
        }

        private void lstSelectedServices_DoubleClick(object sender, EventArgs e)
        {
            XoaDichVuDangChon();
        }

        private void XoaDichVuDangChon()
        {
            if (lstSelectedServices.SelectedItems.Count == 0) return;
            var ds = lstSelectedServices.SelectedItems.Cast<object>().ToList();
            foreach (object o in ds) lstSelectedServices.Items.Remove(o);
            CapNhatTien();
        }

        // Nút << : xóa tất cả
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();
            CapNhatTien();
        }

        // Áp dụng mã giảm giá
        private void btnApplyCoupon_Click(object sender, EventArgs e)
        {
            string code = txtCoupon.Text.Trim();
            if (coupons.TryGetValue(code, out int percent))
            {
                nudDiscount.Value = percent;        // sẽ kích hoạt tính lại
                MessageBox.Show("Áp dụng mã thành công: giảm " + percent + "%", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã giảm giá không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTien();
        }

        // 3. Tính tổng tiền, chiết khấu, thành tiền
        private void CapNhatTien()
        {
            decimal tong = lstSelectedServices.Items.Cast<Service>().Sum(s => s.Price);
            decimal giam = tong * nudDiscount.Value / 100m;
            decimal thanhTien = tong - giam;

            txtTotal.Text = tong.ToString("N0", vn) + " đ";
            txtFinal.Text = thanhTien.ToString("N0", vn) + " đ";
        }
    }
}
