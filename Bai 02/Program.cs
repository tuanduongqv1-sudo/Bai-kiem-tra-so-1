using System;
using System.Text;

namespace AutoSpeed
{
    internal class Program
    {
        static void Main()
        {
            // Cho Console hiển thị được tiếng Việt có dấu
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("========== HE THONG QUAN LY PHUONG TIEN - AUTOSPEED ==========\n");

            // ---------- TC01: Validation năm sản xuất ----------
            Console.WriteLine(">> TC01 - Kiểm tra validation Năm sản xuất (tạo Ô tô năm 1850):");
            try
            {
                var xeLoi = new OTo("PT099", "Ford", 1850, 500_000_000m, 7, 2.0);
                Console.WriteLine("   [SAI] Hệ thống lẽ ra phải chặn mà vẫn tạo được!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"   [ĐẠT] Đã ném ArgumentException: \"{ex.Message}\" -> không tạo được đối tượng.");
            }
            Console.WriteLine();

            // ---------- Tạo dữ liệu hợp lệ để test tiếp ----------
            var oto5Cho = new OTo("PT001", "Toyota", 2023, 1_000_000_000m, 5, 2.5);   // dùng cho TC02, TC05
            var xeMay150 = new XeMay("PT002", "Honda", 2024, 50_000_000m, 150);        // dùng cho TC03
            var oto16Cho = new OTo("PT003", "Ford", 2022, 900_000_000m, 16, 2.0);     // > 9 chỗ

            // ---------- TC02: Giá lăn bánh ô tô 5 chỗ ----------
            Console.WriteLine(">> TC02 - Giá lăn bánh Ô tô 5 chỗ (giá gốc 1 tỷ):");
            decimal giaOto = oto5Cho.TinhGiaLanBanh();
            Console.WriteLine($"   Kết quả: {giaOto:N0} VNĐ (kỳ vọng 1.420.000.000) -> {(giaOto == 1_420_000_000m ? "ĐẠT" : "SAI")}");
            Console.WriteLine();

            // ---------- TC03: Giá lăn bánh xe máy 150cc ----------
            Console.WriteLine(">> TC03 - Giá lăn bánh Xe máy 150cc (giá gốc 50 triệu):");
            decimal giaXe = xeMay150.TinhGiaLanBanh();
            Console.WriteLine($"   Kết quả: {giaXe:N0} VNĐ (kỳ vọng 51.000.000) -> {(giaXe == 51_000_000m ? "ĐẠT" : "SAI")}");
            Console.WriteLine();

            // ---------- Nạp vào bộ quản lý ----------
            var ql = new QuanLyPhuongTien();
            ql.AddPhuongTien(oto5Cho);
            ql.AddPhuongTien(xeMay150);
            ql.AddPhuongTien(oto16Cho);

            // ---------- TC04: Đa hình trong List<PhuongTien> ----------
            Console.WriteLine(">> TC04 - Đa hình: duyệt List<PhuongTien>, mỗi phần tử tự tính đúng công thức:");
            ql.DisplayAll();
            Console.WriteLine();

            // ---------- TC05: Tìm giá lăn bánh lớn nhất ----------
            Console.WriteLine(">> TC05 - Tìm phương tiện có giá lăn bánh CAO NHẤT:");
            PhuongTien? max = ql.FindMaxGiaLanBanh();
            if (max != null)
            {
                bool dat = max is OTo && max.MaPT == "PT001";
                Console.WriteLine($"   {max.GetInfo()}");
                Console.WriteLine($"   => Giá lăn bánh cao nhất: {max.TinhGiaLanBanh():N0} VNĐ -> {(dat ? "ĐẠT (đúng Ô tô 5 chỗ 1.42 tỷ)" : "SAI")}");
            }
            Console.WriteLine();

            // ---------- Demo thêm: tìm theo tên hãng ----------
            Console.WriteLine(">> Demo SearchByName(\"ford\"):");
            foreach (var pt in ql.SearchByName("ford"))
                Console.WriteLine($"   - {pt.GetInfo()}");

            Console.WriteLine("\n========== KẾT THÚC ==========");
        }
    }
}
