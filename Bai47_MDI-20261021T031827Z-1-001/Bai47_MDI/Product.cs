using System.ComponentModel;

namespace Bai47_MDI
{
    /// <summary>
    /// Đối tượng Product cho form Quản lý Sản phẩm.
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        private string _productId = string.Empty;
        private string _productName = string.Empty;
        private decimal _price;
        private int _quantity;

        public string ProductId
        {
            get => _productId;
            set { _productId = value; OnPropertyChanged(nameof(ProductId)); }
        }

        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
