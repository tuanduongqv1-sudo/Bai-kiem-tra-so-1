namespace Bai48_AsyncProgressBar
{
    /// <summary>
    /// Lớp giả lập nạp dữ liệu bất đồng bộ từ CSDL/File.
    /// Sử dụng Task.Run() + Task.Delay để giả lập thời gian tải.
    /// </summary>
    public static class DataService
    {
        /// <summary>
        /// Nạp danh sách sinh viên bất đồng bộ (async Task&lt;List&lt;Student&gt;&gt;).
        /// Sử dụng IProgress&lt;int&gt; để báo cáo tiến trình từ background thread về UI thread.
        /// </summary>
        public static async Task<List<Student>> LoadStudentsAsync(IProgress<int>? progress = null)
        {
            var students = new List<Student>();
            int total = 20; // Giả lập nạp 20 sinh viên

            return await Task.Run(async () =>
            {
                for (int i = 1; i <= total; i++)
                {
                    // Giả lập thời gian nạp dữ liệu từ CSDL/File
                    await Task.Delay(150);

                    students.Add(new Student
                    {
                        StudentId = $"SV{i:D3}",
                        FullName = $"Sinh viên {i}",
                        Age = 18 + (i % 7),
                        Gender = (i % 2 == 0) ? "Nữ" : "Nam",
                        AvatarPath = ""
                    });

                    // Báo cáo tiến trình (%) về UI thread qua IProgress<int>
                    int percent = (int)((double)i / total * 100);
                    progress?.Report(percent);
                }

                return students;
            });
        }

        /// <summary>
        /// Nạp danh sách sản phẩm bất đồng bộ (async Task&lt;List&lt;Product&gt;&gt;).
        /// </summary>
        public static async Task<List<Product>> LoadProductsAsync(IProgress<int>? progress = null)
        {
            var products = new List<Product>();
            int total = 15; // Giả lập nạp 15 sản phẩm

            return await Task.Run(async () =>
            {
                string[] names = {
                    "Laptop Dell", "Chuột Logitech", "Bàn phím cơ", "Màn hình LG",
                    "Tai nghe Sony", "USB Kingston", "Ổ cứng SSD", "RAM 16GB",
                    "Webcam HD", "Loa Bluetooth", "Máy in Canon", "Router WiFi",
                    "Sạc dự phòng", "Cáp HDMI", "Card đồ họa"
                };

                for (int i = 0; i < total; i++)
                {
                    // Giả lập thời gian nạp dữ liệu
                    await Task.Delay(200);

                    products.Add(new Product
                    {
                        ProductId = $"SP{(i + 1):D3}",
                        ProductName = names[i],
                        Price = (i + 1) * 250000m,
                        Quantity = (i + 1) * 5
                    });

                    int percent = (int)((double)(i + 1) / total * 100);
                    progress?.Report(percent);
                }

                return products;
            });
        }
    }
}
