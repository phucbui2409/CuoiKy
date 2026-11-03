# HỆ THỐNG QUẢN LÝ BÁN HÀNG ONLINE (.NET FRAMEWORK 4.8)

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/Platform-Windows%20Forms-0078D4?logo=windows)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![Language](https://img.shields.io/badge/Language-C%23-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/Database-SQL%20Server%20%2F%20LocalDB-CC292B?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

> **Môn học:** Lập Trình Windows  
> **Sinh viên thực hiện:** Bùi Thiện Phúc (`phucbui2409`)  
> **Đồ án cuối kỳ:** Xây dựng Ứng dụng Quản lý Bán hàng Online hoàn chỉnh với C# WinForms, LINQ to SQL, kiến trúc Repository Pattern, bảo mật mã hóa mật khẩu SHA-256 + Salt, phân quyền RBAC đa cấp bậc và bộ cài đặt Setup Wizard tự động.

---

## 🌟 TÍNH NĂNG NỔI BẬT & CÔNG NGHỆ HIỆN ĐẠI

| Nhóm tính năng | Công nghệ / Thư viện | Mô tả chi tiết |
|---|---|---|
| **Biểu đồ Thống kê Dashboard** | `System.Windows.Forms.DataVisualization.Charting` | Trực quan hóa doanh thu: **Column Chart** (Top 5 sản phẩm bán chạy), **Line Chart** (Doanh thu 12 tháng), **Pie Chart** (Tỷ lệ danh mục hàng hóa & trạng thái đơn). |
| **Xuất / Nhập Excel** | `EPPlus (OpenXML .xlsx)` | Xuất danh sách đơn hàng, doanh thu và nhập danh mục hàng hóa từ file Excel trực tiếp vào cơ sở dữ liệu. |
| **Quét Barcode qua Webcam** | `AForge.Video.DirectShow` & `ZXing.Net` | Nhận diện mã vạch sản phẩm thời gian thực bằng Webcam máy tính, tự động tra cứu và thêm vào giỏ hàng. |
| **Mã QR Thanh Toán (VietQR)** | Chuẩn EMVCo / Napas 247 | Sinh mã QR động chuẩn ngân hàng theo STT hóa đơn và tổng tiền thực tế để khách quét chuyển khoản. |
| **Gửi Email Tự Động** | `System.Net.Mail (Gmail SMTP)` | Gửi mã OTP xác thực khôi phục mật khẩu và gửi kèm hóa đơn điện tử cho khách hàng. |
| **Dark / Light Mode** | `UIThemeManager` độc quyền | Hỗ trợ chuyển đổi Theme Sáng / Tối toàn ứng dụng linh hoạt trên thanh Menu chính. |
| **Đóng Gói & Cài Đặt** | `Inno Setup 6 Compiler` | Tạo file `Setup_QuanLyBanHangOnline_v1.0.exe` chuyên nghiệp kèm tự động đính kèm CSDL, tạo Shortcut Desktop và Start Menu. |

---

## 🗂️ CẤU TRÚC THƯ MỤC DỰ ÁN

```
CuoiKy/
│
├── QuanLyBanHangOnline.sln              <-- File Solution mở bằng Visual Studio 2019/2022
├── nuget.exe                            <-- Công cụ khôi phục gói thư viện NuGet
│
├── Database/
│   ├── QuanLyBanHangOnline.sql           <-- Script tạo bảng, quan hệ FK, phân quyền RBAC & dữ liệu mẫu (UTF-8)
│   └── seed_2026_orders.sql              <-- Dữ liệu mẫu bổ sung cho các năm 2026
│
├── Installer/                            <-- Dự án đóng gói bộ cài đặt Setup Wizard
│   ├── Setup_QuanLyBanHangOnline.iss     <-- Kịch bản biên dịch Inno Setup 6
│   ├── build_installer.bat               <-- Batch script biên dịch 1-click
│   ├── app.ico                           <-- Icon ứng dụng
│   ├── License.txt                       <-- Giấy phép bản quyền
│   ├── HUONG_DAN_CAI_DAT.md              <-- Hướng dẫn cài đặt chi tiết
│   └── Output/
│       └── Setup_QuanLyBanHangOnline_v1.0.exe <-- Bộ cài đặt hoàn chỉnh sẵn sàng sử dụng
│
├── packages/                             <-- Thư viện phụ thuộc (AForge, ZXing, EPPlus, ReportViewer, SqlServerTypes)
│
└── QuanLyBanHangOnline.WinForms/         <-- ỨNG DỤNG WINDOWS FORMS CHÍNH
    ├── App.config                        <-- Cấu hình chuỗi kết nối SQL Server
    ├── packages.config                   <-- Quản lý dependencies NuGet
    ├── DataContext/
    │   ├── QuanLyBanHang.dbml            <-- Sơ đồ LINQ to SQL DataContext
    │   └── DbContextHelper.cs            <-- Quản lý kết nối & cơ chế Fallback Offline thông minh
    ├── Helpers/
    │   ├── SecurityHelper.cs             <-- Mã hóa SHA-256 kết hợp Salt ngẫu nhiên
    │   ├── SessionManager.cs             <-- Quản lý phiên làm việc & kiểm tra quyền RBAC
    │   ├── DatabaseInitializer.cs        <-- Tự động khởi tạo CSDL lần đầu (Zero-Config First Run)
    │   ├── ConfigHelper.cs               <-- Cấu hình kết nối SQL động (Đổi máy demo)
    │   ├── ExcelHelper.cs                <-- Tiện ích xuất/nhập Excel qua EPPlus
    │   ├── VietQRHelper.cs               <-- Tiện ích tạo mã QR chuyển khoản Napas 247
    │   └── EmailHelper.cs                <-- Gửi Email OTP & Hóa đơn qua SMTP
    ├── Repositories/
    │   ├── IRepository.cs                <-- Interface chuẩn Repository Pattern
    │   ├── HangHoaRepository.cs          <-- Nghiệp vụ Hàng hóa, tồn kho, LINQ tra cứu
    │   ├── DonHangRepository.cs          <-- Lập đơn hàng, xử lý FIFO, thống kê LINQ GroupBy
    │   ├── NguoiDungRepository.cs        <-- Xác thực hash mật khẩu, phân vai trò
    │   ├── PhanQuyenRepository.cs        <-- Ma trận phân quyền chức năng
    │   └── DanhMucRepositories.cs        <-- Quản lý Loại hàng, NSX, Khách hàng, Nhân viên
    ├── UIExtension/
    │   └── UIThemeManager.cs             <-- Quản lý Dark/Light Theme & bảng màu hiện đại
    ├── Reports/
    │   ├── rptHoaDonXuatKho.rdlc         <-- Mẫu phiếu in hóa đơn bán hàng
    │   └── rptBaoCaoDoanhThu.rdlc        <-- Mẫu phiếu in báo cáo doanh thu
    └── Forms/                            <-- HỆ THỐNG 18+ FORMS CHUYÊN NGHIỆP:
        ├── frmLogin.cs                   <-- Đăng nhập (ẩn MK, giới hạn 3 lần sai, phím ESC, SHA-256)
        ├── frmMain.cs                    <-- Màn hình chính Dashboard, StatusStrip, kiểm tra quyền RBAC
        ├── frmChangePassword.cs          <-- Đổi mật khẩu cá nhân
        ├── frmForgotPassword.cs          <-- Quên mật khẩu qua mã OTP gửi về Email
        ├── frmUserManagement.cs          <-- Quản lý tài khoản người dùng & phân vai trò
        ├── frmRoleManagement.cs          <-- Quản lý ma trận phân quyền chức năng RBAC
        ├── frmHangHoa.cs                 <-- Quản lý Hàng hóa & Xuất/Nhập Excel
        ├── frmLoaiHang.cs                <-- Quản lý Loại hàng hóa
        ├── frmNhaSanXuat.cs              <-- Quản lý Nơi sản xuất / Nhà sản xuất
        ├── frmKhachHang.cs               <-- Quản lý danh mục Khách hàng
        ├── frmNhanVien.cs                <-- Quản lý danh mục Nhân viên
        ├── frmDatHang.cs                 <-- Đặt hàng online, quét Barcode webcam, tạo VietQR
        ├── frmScanBarcode.cs             <-- Cửa sổ quét mã vạch qua Webcam
        ├── frmThanhToanVietQR.cs         <-- Cửa sổ hiển thị mã QR VietQR thanh toán
        ├── frmXuLyDonHang.cs             <-- Xử lý đơn hàng FIFO (Đặt trước xử lý trước)
        ├── frmTraCuuHangHoa.cs           <-- Tra cứu sản phẩm đa tiêu chí bằng LINQ
        ├── frmChartDashboard.cs          <-- Biểu đồ trực quan hóa dữ liệu thống kê
        ├── frmThongKeDoanhThu.cs         <-- Thống kê doanh thu theo ngày/tháng
        ├── frmBaoCaoDonHang.cs           <-- Báo cáo chi tiết đơn hàng & In ấn (PrintDocument)
        ├── frmBaoCaoTonKho.cs            <-- Báo cáo tồn kho & cảnh báo hàng sắp hết
        └── frmConnectionConfig.cs        <-- Cửa sổ cấu hình kết nối CSDL linh hoạt khi đổi máy
```

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### Cách 1: Cài đặt nhanh bằng Setup Wizard (Khuyến nghị cho giảng viên)
1. Tải về hoặc mở thư mục `Installer\Output\`.
2. Chạy file `Setup_QuanLyBanHangOnline_v1.0.exe`.
3. Làm theo trình hướng dẫn cài đặt Setup Wizard (tự động tạo Shortcut ra Màn hình chính).
4. Mở ứng dụng từ Desktop và trải nghiệm ngay!

### Cách 2: Mở & Chạy trực tiếp từ Visual Studio (Dành cho nhà phát triển)
1. Mở file `QuanLyBanHangOnline.sln` bằng **Visual Studio 2019 / 2022**.
2. **Khởi tạo CSDL SQL Server:**
   - Mở file `Database\QuanLyBanHangOnline.sql` trong SQL Server Management Studio (hoặc Visual Studio Server Explorer) và nhấn **Execute (F5)**.
   - *Lưu ý:* Ứng dụng có sẵn tính năng **Zero-Configuration First Run** và **Fallback Offline**, nếu chưa tạo CSDL, ứng dụng sẽ tự động khởi tạo hoặc chuyển sang chế độ mẫu mà không bị dừng đột ngột.
3. Nhấn **F5** (hoặc nút **Start**) trong Visual Studio để biên dịch và chạy ứng dụng.

---

## 🔑 TÀI KHOẢN ĐĂNG NHẬP MẪU

Tất cả mật khẩu đều được băm bằng thuật toán **SHA-256 kết hợp Salt** (không lưu bản rõ trong CSDL):

| Tên đăng nhập | Mật khẩu | Vai trò (Role) | Quyền hạn trong hệ thống |
|---|---|---|---|
| `admin` | `admin123` | **ADMIN** | Toàn quyền quản trị hệ thống, quản lý tài khoản & phân quyền RBAC. |
| `quanly` | `123456` | **QUANLY** | Quản lý danh mục hàng hóa, duyệt đơn hàng FIFO, xem Dashboard biểu đồ và báo cáo. |
| `nhanvien` | `123456` | **NHANVIEN** | Nghiệp vụ bán hàng: Đặt hàng online, quét Barcode, thanh toán VietQR, tra cứu hàng. |

---

## 🛠️ YÊU CẦU HỆ THỐNG
- **Hệ điều hành:** Windows 10 / Windows 11 (32-bit hoặc 64-bit).
- **Runtime:** .NET Framework 4.8 hoặc cao hơn (tích hợp sẵn trên Windows 10/11).
- **Cơ sở dữ liệu:** Microsoft SQL Server (LocalDB, Express hoặc Standard).
- **Thiết bị ngoại vi (tùy chọn):** Webcam (cho tính năng quét Barcode).

---

## 📜 BẢN QUYỀN
Đồ án thuộc bản quyền môn học Lập Trình Windows - Khoa Công Nghệ Thông Tin.  
Phát triển bởi **Bùi Thiện Phúc** ([@phucbui2409](https://github.com/phucbui2409)).
