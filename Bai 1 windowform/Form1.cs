using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_1_windowform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtDonGia.TabIndex = 0;
            txtSoLuong.TabIndex = 1;
            txtGiamGia.TabIndex = 2;
            btnTinhTien.TabIndex = 3;
            btnLamMoi.TabIndex = 4;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            decimal donGia, soLuong, giamGia;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                !decimal.TryParse(txtDonGia.Text, out donGia) ||
                donGia < 0)
            {
                MessageBox.Show(
                    "Vui lòng nhập đơn giá hợp lệ!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDonGia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                !decimal.TryParse(txtSoLuong.Text, out soLuong) ||
                soLuong < 0 ||
                soLuong != decimal.Truncate(soLuong))
            {
                MessageBox.Show(
                    "Vui lòng nhập số lượng khách là số nguyên không âm!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoLuong.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGiamGia.Text) ||
                !decimal.TryParse(txtGiamGia.Text, out giamGia) ||
                giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show(
                    "Giảm giá phải nằm trong khoảng từ 0 đến 100%!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiamGia.Focus();
                return;
            }

            // Tính tổng tiền
            decimal tongTien = donGia * soLuong
                               * (100 - giamGia) / 100;

            lblTongTien.Text = "Tổng tiền: "
                + tongTien.ToString("N0")
                + " VNĐ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            txtDonGia.Focus();
        }
    }
}
       
