namespace Bai5_2
{
    /// <summary>Dịch vụ y tế: tên + đơn giá.</summary>
    public class Service
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Service(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // ListBox hiển thị kết quả của ToString()
        public override string ToString()
        {
            return Name + " - " + Price.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }
    }
}
