using System;

namespace AutoSpeed
{
    /// <summary>
    /// Lớp Ô tô - minh hoạ tính KẾ THỪA (Inheritance) và ĐA HÌNH (Polymorphism).
    /// Kế thừa toàn bộ field/property/method từ PhuongTien, bổ sung thuộc tính riêng
    /// và override lại 2 method.
    /// </summary>
    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                _dungTichDongCo = value;
            }
        }

        // Constructor: dùng ": base(...)" để gọi constructor lớp cha.
        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc,
                   int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        // Override: công thức giá lăn bánh của Ô tô.
        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                // Xe <= 9 chỗ: + 12% trước bạ + 30% tiêu thụ đặc biệt
                decimal truocBa = GiaGoc * 0.12m;
                decimal ttdb = GiaGoc * 0.30m;
                return GiaGoc + truocBa + ttdb;
            }
            else
            {
                // Xe > 9 chỗ: chỉ + 10% trước bạ
                decimal truocBa = GiaGoc * 0.10m;
                return GiaGoc + truocBa;
            }
        }

        // Override GetInfo: gọi lại base rồi nối thêm thông tin của Ô tô.
        public override string GetInfo()
        {
            return base.GetInfo() + $" | Số chỗ: {SoChoNgoi} | Dung tích ĐC: {DungTichDongCo}L";
        }
    }
}
