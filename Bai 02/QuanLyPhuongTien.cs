using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSpeed
{
    /// <summary>
    /// Lớp quản lý một tập hợp phương tiện (List&lt;PhuongTien&gt;).
    /// Nhờ ĐA HÌNH, danh sách kiểu lớp cha PhuongTien có thể chứa cả OTo lẫn XeMay,
    /// và khi gọi TinhGiaLanBanh()/GetInfo() C# tự chọn đúng phiên bản của lớp con.
    /// </summary>
    public class QuanLyPhuongTien
    {
        private readonly List<PhuongTien> _danhSach = new List<PhuongTien>();

        // 1. Thêm phương tiện
        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt == null)
                throw new ArgumentNullException(nameof(pt), "Phương tiện không được null!");
            _danhSach.Add(pt);
        }

        // 2. In ra toàn bộ danh sách kèm giá lăn bánh
        public void DisplayAll()
        {
            if (_danhSach.Count == 0)
            {
                Console.WriteLine("(Danh sách rỗng)");
                return;
            }

            foreach (var pt in _danhSach)
            {
                // pt.GetInfo() và pt.TinhGiaLanBanh() gọi đúng lớp con nhờ đa hình.
                Console.WriteLine(pt.GetInfo());
                Console.WriteLine($"   => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
                Console.WriteLine(new string('-', 90));
            }
        }

        // 3. Tìm phương tiện có giá lăn bánh cao nhất (dùng đa hình)
        public PhuongTien? FindMaxGiaLanBanh()
        {
            if (_danhSach.Count == 0) return null;

            // Cách viết bằng LINQ cho gọn:
            return _danhSach
                .OrderByDescending(pt => pt.TinhGiaLanBanh())
                .First();

            // Cách viết bằng vòng lặp (tương đương):
            // PhuongTien max = _danhSach[0];
            // foreach (var pt in _danhSach)
            //     if (pt.TinhGiaLanBanh() > max.TinhGiaLanBanh()) max = pt;
            // return max;
        }

        // 4. Tìm theo tên hãng (không phân biệt hoa thường)
        public List<PhuongTien> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<PhuongTien>();

            return _danhSach
                .Where(pt => pt.TenHang.ToLower().Contains(keyword.Trim().ToLower()))
                .ToList();
        }
    }
}
