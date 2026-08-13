 PHÁT HIỆN VÀ NGĂN CHẶN KỸ THUẬT GIẤU TIN TRONG ẢNH
---
📌 Thông tin đề tài
- **Tên đề tài:** Phát hiện và ngăn chặn kỹ thuật giấu tin trong ảnh
- **Họ và tên sinh viên:** Vũ Thị Huế
- **Mã sinh viên:** 231A010805

---

## 📝 Giới thiệu đề tài
Đồ án tập trung nghiên cứu, thử nghiệm và đánh giá các kỹ thuật:
1. **Giấu tin trong ảnh (Steganography):** Nhúng thông tin ẩn vào các định dạng ảnh (BMP, PNG, JPEG...) bằng các thuật toán phổ biến (như LSB, PVD, DCT,...).
2. **Phát hiện giấu tin (Steganalysis):** Phân tích và phát hiện sự tồn tại của dữ liệu ẩn trong bức ảnh bằng các phương pháp thống kê, phân tích tần suất hoặc mô hình học máy.
3. **Ngăn chặn giấu tin (Steganography Prevention):** Áp dụng các biện pháp xử lý ảnh (thêm nhiễu, nén ảnh, lọc tần số...) nhằm phá hỏng hoặc gỡ bỏ thông tin ẩn mà vẫn bảo đảm chất lượng thị giác của ảnh gốc.

---

## 📁 Cấu trúc thư mục dự án

```text
.
├── configs/                # Chứa các file cấu hình tham số thử nghiệm
├── data/                   # Tập dữ liệu ảnh (ảnh gốc, ảnh đã giấu tin, ảnh test)
├── references/             # Tài liệu tham khảo
│   └── link_nguon.md       # Tổng hợp liên kết, bài báo khoa học tham khảo
├── report/                 # Báo cáo đồ án
│   └── 231A010805_VuThiHue_DeTai38.docx  # File báo cáo chi tiết
├── results/                # Kết quả đánh giá và thử nghiệm
│   ├── screenshots/        # Ảnh chụp màn hình quá trình thực thi/giao diện
│   ├── results.csv         # Bảng tổng hợp số liệu đánh giá (PSNR, SSIM, accuracy...)
│   └── run_log.txt         # Log ghi lại lịch sử chạy thử nghiệm
├── slides/                 # Slide thuyết trình báo cáo đề tài
├── src/                    # Mã nguồn chính của dự án
│   ├── Form1.Designer.cs   
│   └── Form1.cs            
└── README.md               # File thông tin dự án
