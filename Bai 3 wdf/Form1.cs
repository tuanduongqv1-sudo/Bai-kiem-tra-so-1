using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho ComboBox nếu có items
            if (cboDVT.Items.Count > 0)
                cboDVT.SelectedIndex = 0;
        }

        // 1. Nút "Thêm mới" (Giả sử button1 là nút Thêm)
        private void button1_Click(object sender, EventArgs e)
        {
            string maVT = txtMaVT.Text.Trim();
            string tenVT = txtTenVT.Text.Trim();
            string dvt = cboDVT.Text;
            string donGia = txtDonGia.Text.Trim();

            // Kiểm tra dữ liệu cơ bản
            if (string.IsNullOrEmpty(maVT) || string.IsNullOrEmpty(tenVT) || string.IsNullOrEmpty(donGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate: Không cho phép thêm nếu Mã VT đã tồn tại trong ListView
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text.Equals(maVT, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Mã vật tư '{maVT}' đã tồn tại trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Thêm dữ liệu vào ListView
            ListViewItem lvi = new ListViewItem(maVT);
            lvi.SubItems.Add(tenVT);
            lvi.SubItems.Add(dvt);
            lvi.SubItems.Add(donGia);

            listView1.Items.Add(lvi);

            // Xóa trắng form sau khi thêm
            ClearInputs();
        }

        // 2. Sự kiện khi chọn 1 dòng trong ListView -> Đẩy dữ liệu ngược lại các ô nhập
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                txtMaVT.Text = lvi.SubItems[0].Text;
                txtTenVT.Text = lvi.SubItems[1].Text;
                cboDVT.Text = lvi.SubItems[2].Text;
                txtDonGia.Text = lvi.SubItems[3].Text;

                // Khóa ô Mã VT khi đang chọn để tránh sửa mã trực tiếp gây lỗi logic
                txtMaVT.Enabled = false;
            }
            else
            {
                txtMaVT.Enabled = true;
            }
        }

        // 3. Nút "Cập nhật" (Sửa thông tin dòng đang chọn)
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];

                // Cập nhật giá trị mới từ ô nhập liệu
                lvi.SubItems[1].Text = txtTenVT.Text.Trim();
                lvi.SubItems[2].Text = cboDVT.Text;
                lvi.SubItems[3].Text = txtDonGia.Text.Trim();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Nút "Xóa dòng" (Có xác nhận Yes/No)
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Nút "Xóa toàn bộ"
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ danh sách không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    listView1.Items.Clear();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm hỗ trợ làm sạch các ô nhập liệu
        private void ClearInputs()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonGia.Clear();
            if (cboDVT.Items.Count > 0)
                cboDVT.SelectedIndex = 0;
            txtMaVT.Enabled = true; // Mở lại khóa Mã VT
            txtMaVT.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void lblDVT_Click(object sender, EventArgs e)
        {

        }
    }
}