namespace TechMart.Models
{
    /// <summary>
    /// Danh mục để nạp vào ComboBox.
    /// Dùng DisplayMember = "Name" (hiện ra cho người dùng)
    /// và ValueMember = "Id" (giá trị bên trong).
    /// </summary>
    public class DanhMuc
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DanhMuc(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
