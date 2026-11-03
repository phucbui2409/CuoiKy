-- =============================================================
-- CƠ SỞ DỮ LIỆU: QUẢN LÝ BÁN HÀNG ONLINE
-- Hệ quản trị CSDL: Microsoft SQL Server / LocalDB
-- Đồ án môn học: Lập Trình Windows (.NET Framework)
-- =============================================================

CREATE DATABASE QuanLyBanHangOnline;
GO

USE QuanLyBanHangOnline;
GO

-- 1. BẢNG VAI TRÒ (ROLES)
CREATE TABLE VaiTro (
    MaVaiTro VARCHAR(20) PRIMARY KEY,
    TenVaiTro NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

-- 2. BẢNG CHỨC NĂNG (SYSTEM FUNCTIONS)
CREATE TABLE ChucNang (
    MaChucNang VARCHAR(50) PRIMARY KEY,
    TenChucNang NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

-- 3. BẢNG PHÂN QUYỀN (RBAC - ROLE-BASED ACCESS CONTROL)
CREATE TABLE PhanQuyen (
    MaVaiTro VARCHAR(20) NOT NULL,
    MaChucNang VARCHAR(50) NOT NULL,
    CoQuyen BIT NOT NULL DEFAULT 1,
    PRIMARY KEY (MaVaiTro, MaChucNang),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) ON DELETE CASCADE,
    FOREIGN KEY (MaChucNang) REFERENCES ChucNang(MaChucNang) ON DELETE CASCADE
);
GO

-- 4. BẢNG NGƯỜI DÙNG (USERS) - LƯU MẬT KHẨU SHA-256 KÈM SALT
CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash VARCHAR(128) NOT NULL,
    Salt VARCHAR(64) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20),
    MaVaiTro VARCHAR(20) NOT NULL,
    MaNV VARCHAR(10) NULL,
    TrangThai BIT NOT NULL DEFAULT 1, -- 1: Hoạt động, 0: Khóa
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);
GO

-- 5. BẢNG LOẠI HÀNG
CREATE TABLE LoaiHang (
    MaLoai VARCHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

-- 6. BẢNG NHÀ SẢN XUẤT / NƠI SẢN XUẤT
CREATE TABLE NhaSanXuat (
    MaNSX VARCHAR(10) PRIMARY KEY,
    TenNSX NVARCHAR(100) NOT NULL,
    QuocGia NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(20)
);
GO

-- 7. BẢNG HÀNG HÓA (MÃ HÀNG GỒM ĐÚNG 4 KÍ TỰ THEO YÊU CẦU ĐỀ BÀI)
CREATE TABLE HangHoa (
    MaHang VARCHAR(4) PRIMARY KEY,
    TenHang NVARCHAR(150) NOT NULL,
    MaLoai VARCHAR(10) NOT NULL,
    MaNSX VARCHAR(10) NOT NULL,
    MauSac NVARCHAR(50) NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL CHECK (GiaBan >= 0),
    NgayNhapKho DATETIME NOT NULL DEFAULT GETDATE(),
    SoLuong INT NOT NULL CHECK (SoLuong >= 0),
    FOREIGN KEY (MaLoai) REFERENCES LoaiHang(MaLoai),
    FOREIGN KEY (MaNSX) REFERENCES NhaSanXuat(MaNSX)
);
GO

-- 8. BẢNG KHÁCH HÀNG
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(20) NOT NULL,
    Email VARCHAR(100)
);
GO

-- 9. BẢNG NHÂN VIÊN (LIÊN KẾT VỚI VAI TRÒ / CHỨC VỤ ĐỂ PHÂN QUYỀN)
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATETIME,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(20),
    ChucVu NVARCHAR(50),
    MaVaiTro VARCHAR(20) NULL,
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);
GO

-- Khóa ngoại từ NguoiDung sang NhanVien (Mỗi tài khoản gắn với nhân sự)
ALTER TABLE NguoiDung ADD CONSTRAINT FK_NguoiDung_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);
GO

-- 10. BẢNG ĐƠN HÀNG (SỐ THỨ TỰ TỰ ĐỘNG BẮT ĐẦU TỪ 1)
CREATE TABLE DonHang (
    SoThuTu INT IDENTITY(1,1) PRIMARY KEY,
    MaKH VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10) NULL,
    NgayDatHang DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chờ xử lí', -- 'Chờ xử lí', 'Đã xử lí', 'Đã hủy'
    TenKhachHang NVARCHAR(100) NOT NULL,
    DiaChiGiaoHang NVARCHAR(255) NOT NULL,
    SoDienThoaiGiaoHang VARCHAR(20) NOT NULL,
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

-- 11. BẢNG CHI TIẾT ĐƠN HÀNG (MỖI ĐƠN HÀNG CÓ THỂ CÓ NHIỀU MÃ HÀNG)
CREATE TABLE ChiTietDonHang (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    SoThuTuDonHang INT NOT NULL,
    MaHang VARCHAR(4) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (SoThuTuDonHang) REFERENCES DonHang(SoThuTu) ON DELETE CASCADE,
    FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);
GO

-- =============================================================
-- DỮ LIỆU MẪU (SEED DATA)
-- =============================================================

-- Vai trò
INSERT INTO VaiTro (MaVaiTro, TenVaiTro, MoTa) VALUES
('ADMIN', N'Quản trị hệ thống', N'Toàn quyền quản trị tất cả các chức năng'),
('QUANLY', N'Quản lý bán hàng', N'Quản lý hàng hóa, đơn hàng và xem báo cáo thống kê'),
('NHANVIEN', N'Nhân viên bán hàng', N'Đặt hàng, tra cứu hàng hóa và xử lý đơn hàng');
GO

-- Chức năng hệ thống
INSERT INTO ChucNang (MaChucNang, TenChucNang, MoTa) VALUES
('FN_DASHBOARD', N'Xem Dashboard', N'Xem tổng quan hệ thống'),
('FN_HANGHOA', N'Quản lý Hàng hóa', N'Xem, thêm, sửa, xóa hàng hóa'),
('FN_LOAIHANG', N'Quản lý Loại hàng', N'Xem, thêm, sửa, xóa loại hàng'),
('FN_NHASANXUAT', N'Quản lý Nhà sản xuất', N'Xem, thêm, sửa, xóa nơi sản xuất'),
('FN_KHACHHANG', N'Quản lý Khách hàng', N'Xem, thêm, sửa, xóa khách hàng'),
('FN_NHANVIEN', N'Quản lý Nhân viên', N'Xem, thêm, sửa, xóa nhân viên'),
('FN_DATHANG', N'Đặt hàng online', N'Lập đơn hàng mới cho khách'),
('FN_XULYDONHANG', N'Xử lý đơn hàng (FIFO)', N'Duyệt đơn hàng và xuất kho'),
('FN_TRACUU', N'Tra cứu hàng hóa', N'Tìm kiếm nâng cao thông tin sản phẩm'),
('FN_THONGKE', N'Thống kê doanh thu', N'Xem biểu đồ và báo cáo doanh thu theo thời gian'),
('FN_BAOCAO_DONHANG', N'Báo cáo Đơn hàng', N'Xem và in ấn báo cáo danh sách đơn hàng'),
('FN_BAOCAO_TONKHO', N'Báo cáo Tồn kho', N'Cảnh báo và xuất báo cáo tồn kho'),
('FN_USER_MANAGE', N'Quản lý Tài khoản', N'Quản lý người dùng hệ thống'),
('FN_ROLE_MANAGE', N'Quản lý Phân quyền', N'Quản lý vai trò và phân quyền chức năng');
GO

-- Phân quyền cho ADMIN (Toàn quyền)
INSERT INTO PhanQuyen (MaVaiTro, MaChucNang, CoQuyen)
SELECT 'ADMIN', MaChucNang, 1 FROM ChucNang;
GO

-- Phân quyền cho QUANLY
INSERT INTO PhanQuyen (MaVaiTro, MaChucNang, CoQuyen) VALUES
('QUANLY', 'FN_DASHBOARD', 1),
('QUANLY', 'FN_HANGHOA', 1),
('QUANLY', 'FN_LOAIHANG', 1),
('QUANLY', 'FN_NHASANXUAT', 1),
('QUANLY', 'FN_KHACHHANG', 1),
('QUANLY', 'FN_NHANVIEN', 1),
('QUANLY', 'FN_DATHANG', 1),
('QUANLY', 'FN_XULYDONHANG', 1),
('QUANLY', 'FN_TRACUU', 1),
('QUANLY', 'FN_THONGKE', 1),
('QUANLY', 'FN_BAOCAO_DONHANG', 1),
('QUANLY', 'FN_BAOCAO_TONKHO', 1),
('QUANLY', 'FN_USER_MANAGE', 0),
('QUANLY', 'FN_ROLE_MANAGE', 0);
GO

-- Phân quyền cho NHANVIEN
INSERT INTO PhanQuyen (MaVaiTro, MaChucNang, CoQuyen) VALUES
('NHANVIEN', 'FN_DASHBOARD', 1),
('NHANVIEN', 'FN_HANGHOA', 0),
('NHANVIEN', 'FN_LOAIHANG', 0),
('NHANVIEN', 'FN_NHASANXUAT', 0),
('NHANVIEN', 'FN_KHACHHANG', 1),
('NHANVIEN', 'FN_NHANVIEN', 0),
('NHANVIEN', 'FN_DATHANG', 1),
('NHANVIEN', 'FN_XULYDONHANG', 1),
('NHANVIEN', 'FN_TRACUU', 1),
('NHANVIEN', 'FN_THONGKE', 0),
('NHANVIEN', 'FN_BAOCAO_DONHANG', 1),
('NHANVIEN', 'FN_BAOCAO_TONKHO', 0),
('NHANVIEN', 'FN_USER_MANAGE', 0),
('NHANVIEN', 'FN_ROLE_MANAGE', 0);
GO

-- Nhân viên (Gắn vai trò / chức vụ phân quyền)
INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu, MaVaiTro) VALUES
('NV00', N'Quản Trị Viên Hệ Thống', N'Nam', '1990-01-01', N'Trụ sở chính', '0901112233', N'Quản trị viên hệ thống', 'ADMIN'),
('NV01', N'Trần Thị Bích Ngọc', N'Nữ', '1998-05-15', N'12 Hoàng Hoa Thám, Tân Bình', '0903334455', N'Nhân viên bán hàng', 'NHANVIEN'),
('NV02', N'Nguyễn Văn Quản Lý', N'Nam', '1992-08-20', N'88 Điện Biên Phủ, Bình Thạnh', '0902223344', N'Trưởng phòng kinh doanh', 'QUANLY');
GO

-- Mật khẩu ban đầu: 'admin123' cho tài khoản admin, '123456' cho các tài khoản khác
-- Mã hóa SHA-256 kết hợp Salt:
-- Hash(Password + Salt)
-- Salt mẫu: 's4lt_k3y_r4nd0m_2026'
-- admin123 + s4lt_k3y_r4nd0m_2026 => SHA256: f53b55d3522dea6477b9d281c9f1cf36352dc4a260e86463c79eff9b37bae8f8
-- 123456 + s4lt_k3y_r4nd0m_2026   => SHA256: 8dac0c99166edd5529a7295d1b8f8822fea1541fee63ea8df0ee40adf4005569

INSERT INTO NguoiDung (TenDangNhap, MatKhauHash, Salt, HoTen, Email, SoDienThoai, MaVaiTro, MaNV, TrangThai) VALUES
('admin', 'f53b55d3522dea6477b9d281c9f1cf36352dc4a260e86463c79eff9b37bae8f8', 's4lt_k3y_r4nd0m_2026', N'Quản Trị Viên Hệ Thống', 'admin@shoponline.vn', '0901112233', 'ADMIN', 'NV00', 1),
('quanly', '8dac0c99166edd5529a7295d1b8f8822fea1541fee63ea8df0ee40adf4005569', 's4lt_k3y_r4nd0m_2026', N'Nguyễn Văn Quản Lý', 'quanly@shoponline.vn', '0902223344', 'QUANLY', 'NV02', 1),
('nhanvien', '8dac0c99166edd5529a7295d1b8f8822fea1541fee63ea8df0ee40adf4005569', 's4lt_k3y_r4nd0m_2026', N'Trần Thị Bích Ngọc', 'ngoc.tran@shoponline.vn', '0903334455', 'NHANVIEN', 'NV01', 1);
GO

-- Loại hàng
INSERT INTO LoaiHang (MaLoai, TenLoai, MoTa) VALUES
('THOITRANG', N'Thời trang', N'Quần áo, phụ kiện thời trang nam nữ'),
('DIENTU', N'Điện tử & Công nghệ', N'Thiết bị điện tử, điện thoại, phụ kiện'),
('GPOADUNG', N'Đồ gia dụng', N'Đồ dùng sinh hoạt và nội thất gia đình');
GO

-- Nhà sản xuất / Nơi sản xuất
INSERT INTO NhaSanXuat (MaNSX, TenNSX, QuocGia, DiaChi, SoDienThoai) VALUES
('NSX01', N'May Mặc An Phước', N'Việt Nam', N'100 Hai Bà Trưng, Quận 1, TP.HCM', '02838221144'),
('NSX02', N'Samsung Electronics', N'Hàn Quốc', N'Khu Công Nghệ Cao, TP. Thủ Đức', '02837360000'),
('NSX03', N'Gia Dụng Sunhouse', N'Việt Nam', N'KCN Ngọc Hồi, Thanh Trì, Hà Nội', '02437366688'),
('NSX04', N'Sony Corporation', N'Nhật Bản', N'Tokyo, Japan', '02838220099');
GO

-- Hàng hóa (Mã hàng đúng 4 ký tự)
INSERT INTO HangHoa (MaHang, TenHang, MaLoai, MaNSX, MauSac, GiaBan, NgayNhapKho, SoLuong) VALUES
('HH01', N'Áo sơ mi nam công sở', 'THOITRANG', 'NSX01', N'Trắng', 350000, '2024-10-01', 50),
('HH02', N'Quần tây nam cao cấp', 'THOITRANG', 'NSX01', N'Đen', 450000, '2024-10-02', 40),
('HH03', N'Tai nghe Bluetooth Galaxy Buds', 'DIENTU', 'NSX02', N'Xanh rêu', 1890000, '2024-10-05', 25),
('HH04', N'Điện thoại Galaxy A55 5G', 'DIENTU', 'NSX02', N'Xanh đen', 8990000, '2024-10-10', 15),
('HH05', N'Nồi chiên không dầu Sunhouse 6L', 'GPOADUNG', 'NSX03', N'Đen bóng', 1550000, '2024-10-12', 30),
('HH06', N'Bình giữ nhiệt Inox 304', 'GPOADUNG', 'NSX03', N'Bạc', 199000, '2024-10-15', 80),
('HH07', N'Loa Bluetooth Sony SRS-XB13', 'DIENTU', 'NSX04', N'Xanh dương', 1290000, '2024-10-18', 20),
('HH08', N'Áo khoác gió thể thao nam', 'THOITRANG', 'NSX01', N'Xám ghi', 280000, '2024-10-20', 35);
GO

-- Khách hàng
INSERT INTO KhachHang (MaKH, HoTen, DiaChi, SoDienThoai, Email) VALUES
('KH01', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Quận 1, TP.HCM', '0912345678', 'hoang.pm@gmail.com'),
('KH02', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Quận 3, TP.HCM', '0987654321', 'thao.le@gmail.com'),
('KH03', N'Vũ Đình Khang', N'789 Cầu Giấy, Hà Nội', '0905123987', 'khang.vu@gmail.com');
GO


-- Đơn hàng mẫu
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu) VALUES
('KH01', 'NV01', '2024-10-25 09:30:00', 800000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Quận 1, TP.HCM', '0912345678', N'Giao giờ hành chính'),
('KH02', 'NV01', '2024-10-26 14:15:00', 1890000, N'Chờ xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Quận 3, TP.HCM', '0987654321', N'Gọi trước khi giao'),
('KH03', NULL, '2024-10-27 10:00:00', 1749000, N'Chờ xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, Hà Nội', '0905123987', N'Giao hỏa tốc');
GO

-- Chi tiết đơn hàng mẫu
INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien) VALUES
(1, 'HH01', 1, 350000, 350000),
(1, 'HH02', 1, 450000, 450000),
(2, 'HH03', 1, 1890000, 1890000),
(3, 'HH05', 1, 1550000, 1550000),
(3, 'HH06', 1, 199000, 199000);
GO

-- Đơn hàng và chi tiết mẫu năm 2026 cho Biểu đồ Thống kê (12 Tháng, Top 5 SP, Doanh thu Danh mục)
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH01', 'NV01', '2026-01-15 10:00:00', 1250000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Đơn đầu năm'),
('KH02', 'NV01', '2026-01-22 14:30:00', 8990000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Mua điện thoại'),
('KH03', 'NV01', '2026-02-10 09:15:00', 3440000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Quà Tết'),
('KH01', 'NV02', '2026-02-20 16:45:00', 1890000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Tai nghe'),
('KH02', 'NV01', '2026-03-08 11:20:00', 2580000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Quà 8/3'),
('KH03', 'NV01', '2026-03-25 15:10:00', 1250000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Áo thời trang'),
('KH01', 'NV02', '2026-04-14 13:00:00', 9440000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Điện thoại + quần tây'),
('KH02', 'NV01', '2026-05-18 10:30:00', 4970000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Đồ gia dụng'),
('KH03', 'NV01', '2026-06-12 17:00:00', 3780000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Tai nghe x2'),
('KH01', 'NV02', '2026-07-20 09:40:00', 2500000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Thời trang hè'),
('KH02', 'NV01', '2026-08-15 14:10:00', 10280000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Điện thoại + Loa'),
('KH03', 'NV01', '2026-09-09 11:00:00', 3150000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Nồi chiên + bình nước'),
('KH01', 'NV02', '2026-10-10 10:15:00', 5670000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Tai nghe + Áo'),
('KH02', 'NV01', '2026-11-01 08:30:00', 4400000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Thời trang + Gia dụng'),
('KH03', 'NV01', '2026-11-02 16:00:00', 2140000, N'Chờ xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Đơn mới đặt');
GO

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(4, 'HH01', 2, 350000, 700000),
(4, 'HH08', 2, 280000, 560000),
(5, 'HH04', 1, 8990000, 8990000),
(6, 'HH05', 2, 1550000, 3100000),
(6, 'HH06', 2, 199000, 398000),
(7, 'HH03', 1, 1890000, 1890000),
(8, 'HH07', 2, 1290000, 2580000),
(9, 'HH01', 3, 350000, 1050000),
(9, 'HH06', 1, 199000, 199000),
(10, 'HH04', 1, 8990000, 8990000),
(10, 'HH02', 1, 450000, 450000),
(11, 'HH05', 3, 1550000, 4650000),
(11, 'HH06', 2, 199000, 398000),
(12, 'HH03', 2, 1890000, 3780000),
(13, 'HH01', 4, 350000, 1400000),
(13, 'HH08', 4, 280000, 1120000),
(14, 'HH04', 1, 8990000, 8990000),
(14, 'HH07', 1, 1290000, 1290000),
(15, 'HH05', 2, 1550000, 3100000),
(16, 'HH03', 2, 1890000, 3780000),
(16, 'HH01', 5, 350000, 1750000),
(17, 'HH01', 4, 350000, 1400000),
(17, 'HH02', 4, 450000, 1800000),
(17, 'HH06', 6, 199000, 1194000),
(18, 'HH07', 1, 1290000, 1290000),
(18, 'HH08', 3, 280000, 840000);
GO
