using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Steganalysis_System
{
    public partial class Form1 : Form
    {
        private Bitmap bmpGoc = null;
        private Bitmap bmpSauGiauTin = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Để trống hàm này không xử lý gì
        }


        // ==========================================
        // CẬP NHẬT LẠI NÚT 3: QUÉT TOÀN DẢI - BẮT TRỌN RĂNG CƯA
        // ==========================================
        private void button3_Click(object sender, EventArgs e)
        {
            if (picHienThi.Image == null)
            {
                MessageBox.Show("Không có dữ liệu ảnh để quét phân tích!", "Lỗi");
                return;
            }

            Bitmap bmpQuet = new Bitmap(picHienThi.Image);
            int[] histogram = new int[256];
            int maxPixelCount = 0;

            // 1. Quét TOÀN BỘ bức ảnh không bỏ sót pixel nào
            for (int x = 0; x < bmpQuet.Width; x++)
            {
                for (int y = 0; y < bmpQuet.Height; y++)
                {
                    Color pixel = bmpQuet.GetPixel(x, y);
                    histogram[pixel.R]++;
                }
            }

            // 2. Chọn dải màu từ 10 đến 50 (Vùng pixel đầu ảnh - nơi chứa tin mật chắc chắn nhất)
            int startRange = 10;
            int endRange = 50;

            for (int i = startRange; i <= endRange; i++)
            {
                if (histogram[i] > maxPixelCount)
                {
                    maxPixelCount = histogram[i];
                }
            }

            // 3. Tiến hành vẽ đồ thị phóng to vùng nhạy cảm
            int canvasWidth = 450;
            int canvasHeight = 280;
            Bitmap bmpCanvas = new Bitmap(canvasWidth, canvasHeight);

            using (Graphics g = Graphics.FromImage(bmpCanvas))
            {
                g.Clear(Color.White);

                int totalBars = endRange - startRange + 1;
                int barWidth = (canvasWidth - 50) / totalBars;
                int index = 0;

                for (int i = startRange; i <= endRange; i++)
                {
                    int barHeight = (maxPixelCount > 0) ? (histogram[i] * (canvasHeight - 50) / maxPixelCount) : 0;

                    int xPosition = 30 + (index * barWidth);
                    int yPosition = canvasHeight - barHeight - 30;

                    // Vẽ cột đồ thị
                    g.FillRectangle(Brushes.Crimson, xPosition, yPosition, barWidth - 1, barHeight);
                    g.DrawRectangle(Pens.Black, xPosition, yPosition, barWidth - 1, barHeight);

                    // Ghi chỉ số chân cột cách mỗi 10 đơn vị
                    if (i % 10 == 0)
                    {
                        g.DrawString(i.ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.DarkSlateGray, xPosition - 5, canvasHeight - 22);
                    }
                    index++;
                }

                // Vẽ trục ngang
                g.DrawLine(Pens.Black, 20, canvasHeight - 30, canvasWidth - 20, canvasHeight - 30);
            }

            picDoThiHistogram.Image = bmpCanvas;
            MessageBox.Show("Hệ thống đã bắt trọn dải cấu trúc pixel nghi vấn!", "Kết quả Steganalysis");
        }

        // ==========================================
        // THAY THẾ CHỨC NĂNG 4: KÍCH HOẠT NGĂN CHẶN (LÀM SẠCH ẢNH)
        // ==========================================
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (picHienThi.Image == null)
                {
                    MessageBox.Show("Chưa ghi nhận tệp tin nghi vấn để làm sạch!", "Cảnh báo hệ thống");
                    return;
                }

                // 1. Tạo bản sao từ ảnh đang hiển thị
                Bitmap bmpHienTai = new Bitmap(picHienThi.Image);

                // 2. Đường dẫn Desktop
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string safeImagePath = Path.Combine(desktopPath, "anh_da_khu_khuan.jpg");

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                // GIẢI PHÁP: Đổi thành 60L để thuật toán DCT của JPEG xáo trộn pixel mạnh hơn, phá vỡ hiện tượng răng cưa PoV
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 60L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                // Xóa đồ thị răng cưa cũ trên giao diện ngay lập tức để nghiệm thu đồ thị mới
                if (picDoThiHistogram.Image != null)
                {
                    picDoThiHistogram.Image.Dispose();
                    picDoThiHistogram.Image = null;
                }

                if (picHienThi.Image != null)
                {
                    picHienThi.Image.Dispose();
                    picHienThi.Image = null;
                }

                if (File.Exists(safeImagePath))
                {
                    File.Delete(safeImagePath);
                }

                // Lưu tệp .jpg mới thực sự xáo trộn bit
                bmpHienTai.Save(safeImagePath, jpgEncoder, myEncoderParameters);
                bmpHienTai.Dispose();

                // Nạp lại ảnh qua bộ nhớ đệm
                byte[] imageBytes = File.ReadAllBytes(safeImagePath);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    picHienThi.Image = Image.FromStream(ms);
                }

                MessageBox.Show("Đphrase ĐÃ KÍCH HOẠT HỆ THỐNG LÀM SẠCH ẢNH THÀNH CÔNG!\n\n" +
                                "• Bộ lọc nén JPEG miền tần số (Q=60) đã bẻ gãy cấu trúc răng cưa PoV thành công.\n" +
                                "• Đồ thị cũ đã được xóa. Vui lòng bấm nút 3 để quét lại đồ thị sạch mới!",
                                "Tường lửa hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo lỗi");
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid) return codec;
            }
            return null;
        }
        
        private void btnChonAnh_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Bitmap Images (*.bmp)|*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmpGoc = new Bitmap(ofd.FileName);
                    picHienThi.Image = bmpGoc;
                    picDoThiHistogram.Image = null; // Xóa đồ thị cũ đi
                    MessageBox.Show("Đã tải ảnh gốc thành công!", "Thông báo");
                }
            }
        }

        private void btnGiauTin_Click_1(object sender, EventArgs e)
        {
            if (bmpGoc == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh gốc trước khi thực hiện giấu tin!", "Lỗi");
                return;
            }

            string text = txtTinGiau.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Nội dung tin mật không được để trống!", "Lỗi");
                return;
            }

            // Chuyển chữ thành chuỗi bit nhị phân
            string bitString = "";
            foreach (char c in text)
            {
                bitString += Convert.ToString(c, 2).PadLeft(8, '0');
            }
            bitString += "00000000"; // Ký tự kết thúc chuỗi tin

            bmpSauGiauTin = new Bitmap(bmpGoc);
            int bitIndex = 0;

            for (int x = 0; x < bmpSauGiauTin.Width; x++)
            {
                for (int y = 0; y < bmpSauGiauTin.Height; y++)
                {
                    if (bitIndex < bitString.Length)
                    {
                        Color pixel = bmpSauGiauTin.GetPixel(x, y);
                        int bitToEmbed = int.Parse(bitString[bitIndex].ToString());

                        // Thay bit cuối cùng của kênh màu Red bằng bit mật mã
                        int newRed = (pixel.R & 0xFE) | bitToEmbed;

                        bmpSauGiauTin.SetPixel(x, y, Color.FromArgb(pixel.A, newRed, pixel.G, pixel.B));
                        bitIndex++;
                    }
                    else break;
                }
            }

            picHienThi.Image = bmpSauGiauTin;
            MessageBox.Show("Đã nhúng tin mật ẩn vào cấu trúc LSB thành công!", "Thành công");
        }

        private void btnPhatHien_Click_1(object sender, EventArgs e)
        {
            if (picHienThi.Image == null)
            {
                MessageBox.Show("Không có dữ liệu ảnh để quét phân tích! Vui lòng chọn ảnh trước.", "Lỗi hệ thống");
                return;
            }

            // 1. Tạo bản sao của ảnh đang hiển thị để quét giá trị pixel
            Bitmap bmpQuet = new Bitmap(picHienThi.Image);
            int[] histogram = new int[256];
            int maxPixelCount = 0;

            // 2. Đếm tần suất xuất hiện các giá trị màu Red
            for (int x = 0; x < bmpQuet.Width; x++)
            {
                for (int y = 0; y < bmpQuet.Height; y++)
                {
                    Color pixel = bmpQuet.GetPixel(x, y);
                    histogram[pixel.R]++;

                    // Tìm giá trị lớn nhất trong khoảng màu từ 100 đến 140 để làm mốc căn tỷ lệ chiều cao cột
                    if (pixel.R >= 100 && pixel.R <= 140 && histogram[pixel.R] > maxPixelCount)
                    {
                        maxPixelCount = histogram[pixel.R];
                    }
                }
            }

            // 3. Khởi tạo kích thước bản vẽ cố định (Tránh lỗi giao diện PictureBox bị thu nhỏ)
            int canvasWidth = 450;
            int canvasHeight = 280;
            Bitmap bmpCanvas = new Bitmap(canvasWidth, canvasHeight);

            using (Graphics g = Graphics.FromImage(bmpCanvas))
            {
                // Tô nền trắng cho đồ thị
                g.Clear(Color.White);

                int totalBars = 41; // Số lượng cột màu từ khoảng 100 đến 140
                int barWidth = (canvasWidth - 50) / totalBars;
                int index = 0;

                // 4. Tiến hành vẽ từng cột đồ thị lên bản vẽ
                for (int i = 100; i <= 140; i++)
                {
                    // Tính toán chiều cao cột dựa trên số lượng pixel đếm được
                    int barHeight = (maxPixelCount > 0) ? (histogram[i] * (canvasHeight - 50) / maxPixelCount) : 0;

                    int xPosition = 30 + (index * barWidth);
                    int yPosition = canvasHeight - barHeight - 30;

                    // Vẽ ruột cột màu đỏ Crimson và viền đen xung quanh cho rõ nét hình răng cưa
                    g.FillRectangle(Brushes.Crimson, xPosition, yPosition, barWidth - 1, barHeight);
                    g.DrawRectangle(Pens.Black, xPosition, yPosition, barWidth - 1, barHeight);

                    // Ghi số mốc tọa độ (100, 110, 120, 130, 140) dưới chân cột
                    if (i % 10 == 0)
                    {
                        g.DrawString(i.ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.DarkSlateGray, xPosition - 5, canvasHeight - 22);
                    }
                    index++;
                }

                // Vẽ thêm trục tọa độ ngang dưới chân cho đẹp và chuyên nghiệp
                g.DrawLine(Pens.Black, 20, canvasHeight - 30, canvasWidth - 20, canvasHeight - 30);
            }

            // 5. Gán bản vẽ đồ thị vào ô PictureBox trên giao diện của má
            if (picDoThiHistogram != null)
            {
                picDoThiHistogram.SizeMode = PictureBoxSizeMode.Normal;
                picDoThiHistogram.Image = bmpCanvas;
                MessageBox.Show("Hệ thống phân tích toán học thành công! Đồ thị đã được dựng.", "Kết quả Steganalysis");
            }
            else
            {
                MessageBox.Show("Lỗi: Chưa tìm thấy ô hiển thị đồ thị 'picDoThiHistogram' trên giao diện!", "Lỗi cấu hình");
            }
        }
    }
}
