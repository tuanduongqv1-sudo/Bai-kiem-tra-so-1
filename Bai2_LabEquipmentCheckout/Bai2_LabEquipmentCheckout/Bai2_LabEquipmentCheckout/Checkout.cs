namespace LabEquipmentCheckout;

public class Checkout
{
    public string Id { get; set; } = "";
    public string StudentId { get; set; } = "";
    public string StudentName { get; set; } = "";
    public string Equipment { get; set; } = "";
    public int Quantity { get; set; } = 1;
    public DateTime BorrowDate { get; set; } = DateTime.Today;
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(7);
    public DateTime? ReturnDate { get; set; }

    // Tình trạng được TỰ ĐỘNG tính: đã trả / quá hạn (chưa trả và hạn < hôm nay) / đang mượn
    public string Status =>
        ReturnDate.HasValue ? "Đã trả" :
        DueDate.Date < DateTime.Today ? "Quá hạn" : "Đang mượn";

    public bool IsOverdue => Status == "Quá hạn";
}
