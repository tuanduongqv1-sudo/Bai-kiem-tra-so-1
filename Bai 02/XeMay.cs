using System;

namespace AutoSpeed
{
    /// <summary>
    /// Lớp Xe máy - kế thừa PhuongTien, có công thức tính giá riêng theo dung tích xy-lanh.
    /// </summary>
    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh; // đơn vị: cc

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xy-lanh phải lớn hơn 0!");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            // < 175cc: trước bạ 2% ; >= 175cc: trước bạ 5%
            decimal tiLeTruocBa = DungTichXylanh < 175 ? 0.02m : 0.05m;
            return GiaGoc + (GiaGoc * tiLeTruocBa);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Dung tích xy-lanh: {DungTichXylanh}cc";
        }
    }
}
