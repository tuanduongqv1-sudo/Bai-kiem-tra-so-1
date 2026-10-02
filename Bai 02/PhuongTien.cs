using System;

namespace AutoSpeed
{
    /// <summary>
    /// Lớp cha TRỪU TƯỢNG cho mọi phương tiện.
    /// - Tính ĐÓNG GÓI (Encapsulation): field để private, mọi thao tác đọc/ghi
    ///   phải đi qua Property để kiểm tra dữ liệu (validation).
    /// - Tính TRỪU TƯỢNG (Abstraction): có abstract method TinhGiaLanBanh()
    ///   buộc lớp con phải tự định nghĩa.
    /// </summary>
    public abstract class PhuongTien
    {
        // ====== PRIVATE FIELDS (ẩn dữ liệu bên trong) ======
        private string _maPT = "PT000";
        private string _tenHang = string.Empty;
        private int _namSanXuat;
        private decimal _giaGoc;

        // ====== PROPERTIES (gắn validation để bảo vệ dữ liệu) ======

        // Mã PT: không để trống, tự cắt khoảng trắng thừa, mặc định "PT000".
        public string MaPT
        {
            get => _maPT;
            set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value.Trim();
        }

        // Tên hãng: bắt buộc có giá trị.
        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");
                _tenHang = value.Trim();
            }
        }

        // Năm sản xuất: 1900 <= năm <= năm hiện tại.
        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");
                _namSanXuat = value;
            }
        }

        // Giá gốc: phải > 0.
        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                _giaGoc = value;
            }
        }

        // ====== CONSTRUCTOR ======
        // Gọi qua Property (không gán thẳng field) để validation chạy ngay lúc khởi tạo.
        protected PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        // ====== ABSTRACT METHOD ======
        // Mỗi loại phương tiện có công thức tính giá lăn bánh riêng -> bắt buộc override.
        public abstract decimal TinhGiaLanBanh();

        // ====== VIRTUAL METHOD ======
        // Trả về thông tin cơ bản; lớp con có thể override để bổ sung.
        public virtual string GetInfo()
        {
            return $"Mã: {MaPT,-6} | Hãng: {TenHang,-10} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc,18:N0} VNĐ";
        }
    }
}
