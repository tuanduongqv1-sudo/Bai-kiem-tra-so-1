Câu 1 — Value Types và Reference Types

Trong C#, kiểu dữ liệu được chia thành hai nhóm dựa trên cơ chế lưu trữ và cách truyền giá trị. Kiểu giá trị (Value Type) bao gồm các kiểu số nguyên thủy như int, double, bool, char, cùng với struct và enum. Kiểu tham chiếu (Reference Type) bao gồm class, interface, delegate, mảng và string.

Về cơ chế lưu trữ, biến thuộc kiểu giá trị lưu trực tiếp dữ liệu của nó, và nếu là biến cục bộ thì được cấp phát trên vùng nhớ Stack. Ngược lại, với kiểu tham chiếu, đối tượng thực sự được cấp phát trên vùng nhớ Heap, còn biến chỉ nắm giữ một địa chỉ (tham chiếu) trỏ tới đối tượng đó trên Heap.

Hệ quả quan trọng nhất nằm ở thao tác gán và truyền tham số. Khi gán một biến kiểu giá trị cho biến khác, toàn bộ nội dung được sao chép, tạo thành hai vùng dữ liệu độc lập; thay đổi biến này không ảnh hưởng biến kia. Khi gán một biến kiểu tham chiếu, chỉ có địa chỉ được sao chép, nên hai biến cùng trỏ tới một đối tượng duy nhất; thay đổi qua biến này sẽ thấy được qua biến kia.

Ngoài ra, kiểu giá trị có giá trị mặc định (0, false…) và không thể mang giá trị null trừ khi khai báo dạng nullable; còn kiểu tham chiếu có thể nhận null. Về giải phóng bộ nhớ, dữ liệu trên Stack tự thu hồi khi ra khỏi phạm vi, trong khi đối tượng trên Heap do bộ thu gom rác (Garbage Collector) quản lý.

Cần lưu ý rằng khẳng định "kiểu giá trị luôn nằm trên Stack" chỉ đúng với biến cục bộ. Nếu một kiểu giá trị là thành phần (field) của một đối tượng kiểu tham chiếu thì nó nằm cùng đối tượng đó trên Heap; và khi một kiểu giá trị bị đóng hộp (boxing) vào kiểu object, nó cũng được đưa lên Heap.

Câu 2 — Init-only Properties

Thuộc tính thông thường với bộ truy cập set cho phép gán lại giá trị ở bất kỳ thời điểm nào trong vòng đời của đối tượng, khiến đối tượng trở nên khả biến (mutable). Trong khi đó, thuộc tính init-only (được giới thiệu từ C# 9) chỉ cho phép gán giá trị trong giai đoạn khởi tạo đối tượng, nghĩa là bên trong constructor hoặc thông qua cú pháp khởi tạo đối tượng (object initializer). Sau khi đối tượng đã được khởi tạo xong, thuộc tính init-only trở thành chỉ đọc, và mọi nỗ lực gán lại sẽ bị báo lỗi ngay tại thời điểm biên dịch.

Điểm khác biệt về bản chất là init-only tạo ra tính bất biến (immutability) một cách có kiểm soát: đối tượng được thiết lập trạng thái một lần duy nhất rồi giữ nguyên, nhưng vẫn giữ được cú pháp khởi tạo gọn gàng. So với giải pháp dùng thuộc tính chỉ có get (buộc phải gán qua constructor và không dùng được cú pháp khởi tạo bằng dấu ngoặc nhọn), init-only linh hoạt hơn vì vừa đảm bảo bất biến vừa cho phép gán qua object initializer.

Về trường hợp sử dụng thực tế, init-only phù hợp với những đối tượng mà trạng thái không nên thay đổi sau khi tạo, chẳng hạn các đối tượng truyền dữ liệu (DTO), đối tượng cấu hình, hoặc các value object trong thiết kế theo miền nghiệp vụ. Tính bất biến này cũng giúp đối tượng an toàn hơn khi được chia sẻ giữa nhiều luồng. Đây chính là lý do kiểu record trong C# 9 mặc định sử dụng init cho các thuộc tính của nó.

Câu 3 — Phương thức virtual và override trong Đa hình

Hai từ khóa virtual và override hoạt động thành một cặp để hiện thực tính đa hình. Từ khóa virtual được khai báo ở phương thức của lớp cha, mang ý nghĩa cho phép lớp con ghi đè lại phương thức đó; tuy vậy phương thức virtual vẫn có thân hàm, tức là có sẵn một cài đặt mặc định. Từ khóa override được khai báo ở lớp con, mang ý nghĩa lớp con thực sự cung cấp một cài đặt mới thay thế cho phương thức virtual của lớp cha. Để override hợp lệ, chữ ký của phương thức ở lớp con (tên, danh sách tham số, kiểu trả về) phải trùng khớp với phương thức virtual ở lớp cha.

Cơ chế đa hình thể hiện ở chỗ: khi một đối tượng của lớp con được tham chiếu thông qua biến kiểu lớp cha, lời gọi phương thức sẽ được quyết định dựa trên kiểu thực tế của đối tượng tại thời điểm chạy chứ không dựa trên kiểu khai báo của biến. Nhờ đó, cùng một lời gọi nhưng chương trình tự động thực thi đúng phiên bản của lớp con. Cơ chế này được gọi là liên kết động (dynamic dispatch).

Một số điểm cần phân biệt thêm: nếu phương thức ở lớp cha không được khai báo virtual thì lớp con không thể override. Khi đó, nếu lớp con định nghĩa lại phương thức cùng tên bằng từ khóa new thì đó là hiện tượng che giấu phương thức (method hiding), và việc gọi phiên bản nào sẽ phụ thuộc vào kiểu khai báo của biến, làm mất tính đa hình. Bên cạnh đó, từ khóa abstract cũng cho phép ghi đè giống virtual, nhưng phương thức abstract không có thân hàm và bắt buộc lớp con phải override.

Câu 4 — Vì sao thành phần static không truy xuất được qua instance

Nguyên nhân cốt lõi là ở chỗ thành phần static thuộc về bản thân lớp (kiểu dữ liệu) chứ không thuộc về bất kỳ đối tượng cụ thể nào. Chỉ tồn tại duy nhất một bản của thành phần static, được dùng chung cho toàn bộ chương trình, và nó được nạp vào bộ nhớ ngay khi lớp được tải lần đầu, tức là tồn tại độc lập và có trước cả việc có tạo ra đối tượng hay không. Trái lại, thành phần thuộc về đối tượng (instance member) thì mỗi lần dùng toán tử new sẽ sinh ra một bản riêng gắn liền với từng đối tượng.

Vì thành phần static gắn với lớp chứ không nằm bên trong từng đối tượng, nên về mặt khái niệm đối tượng không hề chứa thành phần static để có thể truy xuất thông qua nó. Do đó C# quy định bắt buộc phải truy xuất thành phần static thông qua tên lớp. Nếu cố gắng truy xuất qua một đối tượng, trình biên dịch sẽ báo lỗi (mã lỗi CS0176).

Về mặt thiết kế, quy định này nhằm phản ánh đúng bản chất và tránh gây hiểu nhầm cho người đọc mã nguồn: nếu cho phép gọi thành phần static qua đối tượng, người đọc dễ lầm tưởng đó là dữ liệu riêng của đối tượng, trong khi thực chất nó là dữ liệu dùng chung của cả lớp. Việc buộc gọi qua tên lớp giúp mã nguồn thể hiện rõ ràng rằng đây là thành phần cấp lớp.