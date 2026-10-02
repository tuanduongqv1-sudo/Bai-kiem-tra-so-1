namespace TechMart.Models
{
    /// <summary>
    /// Model sản phẩm. Các tên property khớp với DataPropertyName của cột DataGridView
    /// để Data Binding tự hiển thị đúng cột.
    /// </summary>
    public class Product
    {
        public string ProductId { get; set; } = string.Empty;   // Mã SP
        public string ProductName { get; set; } = string.Empty; // Tên SP
        public string Category { get; set; } = string.Empty;    // Danh mục (lưu tên hiển thị)
        public decimal UnitPrice { get; set; }                  // Đơn giá
        public int Quantity { get; set; }                       // Số lượng
        public string ImagePath { get; set; } = string.Empty;   // Đường dẫn ảnh đại diện
    }
}
