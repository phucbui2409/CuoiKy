# HƯỚNG DẪN ĐÓNG GÓI & CÀI ĐẶT ỨNG DỤNG QUẢN LÝ BÁN HÀNG ONLINE

## 1. Giới Thiệu Bộ Cài Đặt (Setup Wizard)
Bộ cài đặt được đóng gói chuyên nghiệp bằng công nghệ **Inno Setup 6**, tạo ra **1 tệp tin thực thi duy nhất**:
- **Đường dẫn tệp**: `Installer\Output\Setup_QuanLyBanHangOnline_v1.0.exe`
- **Dung lượng**: ~6.4 MB (Chuẩn nén cao cấp LZMA2)
- **Tương thích**: Windows 10, Windows 11 (32-bit & 64-bit)

---

## 2. Các Tính Năng Nổi Bật Của Bộ Cài Đặt

### 1) Trình Hướng Dẫn Cài Đặt Hoàn Chỉnh (Setup Wizard)
- Giao diện Wizard chuẩn mực: Màn hình Chào mừng (Welcome), Điều khoản & Thông tin đồ án (License/Info), Chọn thư mục cài đặt (`C:\Program Files (x86)\QuanLyBanHangOnline`), Chọn thư mục Start Menu, Tùy chọn tạo Shortcut trên Desktop, Tiến trình cài đặt mượt mà và Màn hình Hoàn tất với checkbox *Khởi chạy ứng dụng ngay*.
- Tự động tích hợp trình gỡ cài đặt sạch sẽ (`unins000.exe`), đăng ký trong **Windows Settings / Control Panel (Apps & Features)**.

### 2) Tự Động Kiểm Tra Thư Viện Phụ Thuộc (Prerequisites Check)
Trước khi cài đặt, kịch bản Pascal script tự động kiểm tra:
- **Microsoft .NET Framework 4.8**: Đọc Registry `HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full` (Release >= 528040). Nếu chưa có, hiển thị cảnh báo và cung cấp link tải chính thức từ Microsoft.
- **Microsoft SQL Server / LocalDB**: Kiểm tra Registry và dịch vụ SQL Server. Nếu chưa phát hiện máy chủ SQL, hiển thị thông báo hướng dẫn và nhắc nhở người dùng về chế độ dự phòng phản hồi tức thì (Offline Fallback).

### 3) Đính Kèm File SQL & Tự Động Khởi Tạo CSDL Lần Đầu (Auto-Database Initializer)
- Toàn bộ thư mục `Database\` chứa `QuanLyBanHangOnline.sql` và `seed_2026_orders.sql` được đính kèm sẵn trong thư mục cài đặt (`{app}\Database`).
- Trong mã nguồn C# (`Program.cs` và `DatabaseInitializer.cs`), ứng dụng được trang bị cơ chế **Zero-Configuration First Run**:
  - Khi mở ứng dụng lần đầu tiên, hệ thống tự động kết nối kiểm tra CSDL `QuanLyBanHangOnline`.
  - Nếu CSDL chưa tồn tại trên máy chủ SQL, ứng dụng **tự động chạy script SQL để tạo Database, bảng, phân quyền và dữ liệu mẫu đầy đủ** mà không cần mở SSMS chạy tay.
  - Người dùng hoặc thầy cô chấm thi chỉ cần bấm mở app là sử dụng được ngay lập tức!

### 4) Tạo Shortcut Đầy Đủ Trên Desktop & Start Menu
Bộ cài đặt tự động tạo các lối tắt:
- **Desktop Shortcut**: `Quản Lý Bán Hàng Online.lnk` (Icon biểu tượng túi mua sắm & biểu đồ đẹp mắt).
- **Start Menu Folder**:
  - `Quản Lý Bán Hàng Online`: Mở ứng dụng chính.
  - `⚙️ Cấu hình kết nối SQL (App.config)`: Mở thẳng form cấu hình máy chủ kết nối nếu đổi máy demo.
  - `📁 Thư mục kịch bản CSDL (Database)`: Mở nhanh thư mục chứa file SQL để tiện tra cứu hoặc nộp bài.
  - `🗑️ Gỡ cài đặt Quản Lý Bán Hàng Online`: Gỡ bỏ phần mềm sạch sẽ khỏi máy tính.

---

## 3. Cách Biên Dịch Lại Bộ Cài Đặt (Nếu Cần)
Nếu bạn có bất kỳ chỉnh sửa nào về code trong tương lai và muốn đóng gói lại file Setup mới:
1. Mở Visual Studio và chọn **Build / Rebuild Solution**.
2. Vào thư mục `Installer\`, nhấp đúp chuột vào file:
   ```cmd
   build_installer.bat
   ```
3. File cài đặt mới sẽ được tạo tự động tại `Installer\Output\Setup_QuanLyBanHangOnline_v1.0.exe`.

---

## 4. Tài Khoản Đăng Nhập Mặc Định
- **Quản trị viên (ADMIN)**: `admin` / Mật khẩu: `admin123`
- **Quản lý (QUANLY)**: `quanly` / Mật khẩu: `123456`
- **Nhân viên (NHANVIEN)**: `nhanvien` / Mật khẩu: `123456`
