# Bài 6.1 & 6.2 – WinForms 3-Tier (DTO – DAL – BUS – GUI) với SQL Server

Cả hai bài là project **.NET Framework 4.8 (WinForms)**, dùng `System.Data.SqlClient` có sẵn trong .NET Framework nên **không cần cài NuGet**.
Mở bằng **Visual Studio 2019/2022** (cần workload ".NET desktop development").

## Cách chạy
1. Mở **SSMS**, chạy file SQL: `Bai6_1_RetailSales/SalesDB.sql` và `Bai6_2_HRM/HRMDB.sql` (đã có dữ liệu mẫu).
2. Mở `RetailSales.sln` (hoặc `HRM.sln`) trong Visual Studio.
3. Sửa chuỗi kết nối trong `App.config` cho đúng máy của bạn:
   - `Data Source=.` (SQL Server mặc định)
   - `Data Source=.\SQLEXPRESS` (bản Express)
   - `Data Source=(localdb)\MSSQLLocalDB` (LocalDB)
4. Nhấn **F5** để chạy.

## Về "kéo thả"
Mỗi form có đủ cặp `frmX.cs` + `frmX.Designer.cs` theo đúng chuẩn Visual Studio.
Bấm đúp vào `frmX.cs` (hoặc chuột phải → *View Designer*) để mở giao diện thiết kế: bạn có thể kéo thả,
đổi vị trí/kích thước/Text của control trong Toolbox + Properties như bình thường. Nếu thêm nút mới,
bấm đúp vào nút để VS tạo handler `Click` trong `frmX.cs`.
**Lưu ý:** đừng đổi `Name` của control đang được code sử dụng (txtMaSP, dgvSanPham, btnThem...) nếu chưa sửa lại code.

## Cấu trúc (3-Tier)
```
DTO/  đối tượng truyền dữ liệu (SanPhamDTO, HoaDonDTO, ...)
DAL/  truy cập CSDL (DbHelper + *DAL) – toàn bộ dùng SqlParameter
BUS/  nghiệp vụ + kiểm tra dữ liệu (*BUS, ErrorHelper)
GUI/  các form WinForms
```
Luồng gọi: `GUI → BUS → DAL → SQL Server`. GUI không bao giờ gọi trực tiếp DAL.

## Bài 6.1 – đối chiếu yêu cầu
| Yêu cầu | Nằm ở đâu |
|---|---|
| CSDL 5 bảng + khóa ngoại/ràng buộc | `SalesDB.sql` |
| CRUD Sản phẩm / Khách hàng / Nhân viên | `frmSanPham`, `frmKhachHang`, `frmNhanVien` + BUS/DAL tương ứng |
| Tìm SP theo tên/mã vạch, `SqlParameter` + `%` | `SanPhamDAL.Search` (`"%" + keyword + "%"`) |
| Bán hàng: quét mã/chọn SP, giỏ hàng DataGridView, khách lẻ, tổng tiền, điểm | `frmBanHang` (ô *Quét mã vạch*: gõ/quét mã rồi Enter) |
| **SqlTransaction**: chèn HoaDon → ChiTiet → trừ tồn (thiếu hàng → Rollback + báo lỗi) → cộng điểm → Commit | `HoaDonDAL.LapHoaDon` |
| Điểm tích lũy `+= TongTien / 100000` | `HoaDonBUS.TinhDiem` |
| Doanh thu ngày/tháng bằng `ExecuteScalar` | `BaoCaoDAL.TongDoanhThu` |
| Top 5 bán chạy bằng `SqlDataReader` | `BaoCaoDAL.TopSanPham` |

## Bài 6.2 – đối chiếu yêu cầu
| Yêu cầu | Nằm ở đâu |
|---|---|
| CSDL 4 bảng | `HRMDB.sql` |
| CRUD nhân viên, chuyển phòng ban, tìm theo tên/phòng ban/CCCD (parameterized) | `frmNhanVien`, `NhanVienDAL.Search`, `ChuyenPhongBan` |
| Chấm công ngắt kết nối: `SqlDataAdapter` → `DataTable` → DataGridView, nhập trực tiếp trên lưới | `frmChamCong`, `ChamCongDAL.Load` |
| "Lưu chấm công": `SqlCommandBuilder` + `adapter.Update()` | `ChamCongDAL.Save` |
| Công thức lương `(LCB*HS/22)*Công + OT*50.000` | `LuongBUS.TinhThucLinh` |
| "Chốt lương tháng": **SqlTransaction** ghi BangLuong + khóa chấm công | `LuongDAL.ChotLuong` |
| Quản lý phòng ban (cho combobox / chuyển phòng ban) | `frmPhongBan` |

## Những chỗ đề bài mâu thuẫn / thiếu và cách xử lý
- **BangLuong** (6.2): đề ghi vừa `MaLuong` (Identity) vừa "Primary Key (MaNV, ThangNam)". Mình đặt `MaLuong` là PRIMARY KEY và thêm `UNIQUE (MaNV, ThangNam)` (mỗi người một dòng lương/tháng).
- **BangChamCong**: thêm `UNIQUE (MaNV, ThangNam)` và cột `DaKhoa BIT` để thực hiện yêu cầu "khóa dữ liệu chấm công".
- `SoNgayCong` kiểm tra `0..31` (đề chỉ ghi `<= 31`).
- **Số điện thoại / CCCD** là `UNIQUE` nên ứng dụng bắt buộc nhập (SQL Server chỉ cho phép 1 giá trị NULL trong cột UNIQUE).
- "Khách lẻ" = `HoaDon.MaKH` là NULL, không cộng điểm.
- Không xóa được sản phẩm/nhân viên/phòng ban đã phát sinh dữ liệu liên quan (ràng buộc khóa ngoại) – chương trình hiện thông báo thân thiện.
