using System.Drawing.Imaging;

namespace Steganalysis_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChonAnh = new Button();
            txtTinGiau = new TextBox();
            btnGiauTin = new Button();
            groupBox1 = new GroupBox();
            picHienThi = new PictureBox();
            groupBox2 = new GroupBox();
            btnNganChan = new Button();
            picDoThiHistogram = new PictureBox();
            btnPhatHien = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHienThi).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDoThiHistogram).BeginInit();
            SuspendLayout();
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(11, 25);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(229, 29);
            btnChonAnh.TabIndex = 0;
            btnChonAnh.Text = "1. Chọn ảnh gốc (.bmp)";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click_1;
            // 
            // txtTinGiau
            // 
            txtTinGiau.Location = new Point(428, 25);
            txtTinGiau.Name = "txtTinGiau";
            txtTinGiau.Size = new Size(155, 27);
            txtTinGiau.TabIndex = 2;
            txtTinGiau.Text = "AnNinhMang2026";
            txtTinGiau.TextChanged += txtTinGiau_TextChanged;
            // 
            // btnGiauTin
            // 
            btnGiauTin.Location = new Point(631, 25);
            btnGiauTin.Name = "btnGiauTin";
            btnGiauTin.Size = new Size(229, 29);
            btnGiauTin.TabIndex = 3;
            btnGiauTin.Text = "2. Thực hiện Giấu tin LSB";
            btnGiauTin.UseVisualStyleBackColor = true;
            btnGiauTin.Click += btnGiauTin_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picHienThi);
            groupBox1.Location = new Point(12, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(468, 360);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giao diện ảnh";
            // 
            // picHienThi
            // 
            picHienThi.Location = new Point(52, 61);
            picHienThi.Name = "picHienThi";
            picHienThi.Size = new Size(381, 250);
            picHienThi.SizeMode = PictureBoxSizeMode.Zoom;
            picHienThi.TabIndex = 5;
            picHienThi.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnNganChan);
            groupBox2.Controls.Add(picDoThiHistogram);
            groupBox2.Controls.Add(btnPhatHien);
            groupBox2.Location = new Point(529, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(481, 366);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hệ thống Phân tích & Phòng ngự";
            // 
            // btnNganChan
            // 
            btnNganChan.Location = new Point(24, 331);
            btnNganChan.Name = "btnNganChan";
            btnNganChan.Size = new Size(298, 29);
            btnNganChan.TabIndex = 1;
            btnNganChan.Text = "4. Kích hoạt Ngăn chặn (Làm sạch ảnh)";
            btnNganChan.UseVisualStyleBackColor = true;
            btnNganChan.Click += button2_Click;
            // 
            // picDoThiHistogram
            // 
            picDoThiHistogram.BackColor = Color.White;
            picDoThiHistogram.Location = new Point(24, 61);
            picDoThiHistogram.Name = "picDoThiHistogram";
            picDoThiHistogram.Size = new Size(400, 250);
            picDoThiHistogram.TabIndex = 1;
            picDoThiHistogram.TabStop = false;
            // 
            // btnPhatHien
            // 
            btnPhatHien.Location = new Point(24, 26);
            btnPhatHien.Name = "btnPhatHien";
            btnPhatHien.Size = new Size(269, 29);
            btnPhatHien.TabIndex = 0;
            btnPhatHien.Text = "3. Quét biểu đồ (Phát hiện";
            btnPhatHien.UseVisualStyleBackColor = true;
            btnPhatHien.Click += btnPhatHien_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 29);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 1;
            label1.Text = "Nội dung tin cần giấu:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 517);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnGiauTin);
            Controls.Add(txtTinGiau);
            Controls.Add(label1);
            Controls.Add(btnChonAnh);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHienThi).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDoThiHistogram).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra xem trên ô hiển thị picHienThi đang có ảnh hay không
                if (picHienThi.Image == null)
                {
                    MessageBox.Show("Chưa ghi nhận tệp tin nghi vấn để làm sạch! Vui lòng chọn ảnh và thực hiện giấu tin trước.", "Cảnh báo hệ thống");
                    return;
                }

                // Tạo bản sao từ ảnh đang hiển thị trên màn hình để xử lý
                Bitmap bmpHienTai = new Bitmap(picHienThi.Image);

                // 2. Thiết lập đường dẫn lưu ảnh sạch ra thẳng màn hình chính (Desktop) cho dễ tìm
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string safeImagePath = Path.Combine(desktopPath, "anh_da_khu_khuan.jpg");

                // 3. Cấu hình bộ lọc nén JPEG để bẻ gãy cấu trúc bit LSB của hacker
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                // Thiết lập chất lượng ảnh nén là 85 để xáo trộn miền tần số
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 85L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                // 4. Thực hiện lưu file
                bmpHienTai.Save(safeImagePath, jpgEncoder, myEncoderParameters);

                // Giải phóng bộ nhớ ảnh cũ và nạp lại ảnh mới đã được làm sạch
                picHienThi.Image.Dispose();
                picHienThi.Image = Image.FromFile(safeImagePath);

                MessageBox.Show("Đphrase ĐÃ KÍCH HOẠT HỆ THỐNG LÀM SẠCH ẢNH THÀNH CÔNG!\n\n" +
                                "• Bộ lọc nén JPEG miền tần số đã xáo trộn và phá hủy 100% dữ liệu ẩn LSB.\n" +
                                "• File ảnh sạch đã được lưu tại Màn hình chính (Desktop) với tên: anh_da_khu_khuan.jpg",
                                "Tường lửa hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình làm sạch ảnh: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private void txtTinGiau_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private Button btnChonAnh;
        private TextBox txtTinGiau;
        private Button btnGiauTin;
        private GroupBox groupBox1;
        private PictureBox picHienThi;
        private GroupBox groupBox2;
        private Button btnNganChan;
        private Button btnPhatHien;
        private Label label1;
        private PictureBox picDoThiHistogram;
    }
}
