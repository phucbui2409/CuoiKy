USE QuanLyBanHangOnline;
GO

-- Thêm các đơn hàng mẫu trải dài các tháng trong năm 2026 để kiểm tra biểu đồ
-- Tháng 1/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH01', 'NV01', '2026-01-15 10:00:00', 1250000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Đơn đầu năm'),
('KH02', 'NV01', '2026-01-22 14:30:00', 8990000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Mua điện thoại');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY() - 1, 'HH01', 2, 350000, 700000),
(SCOPE_IDENTITY() - 1, 'HH08', 2, 280000, 560000),
(SCOPE_IDENTITY(), 'HH04', 1, 8990000, 8990000);

-- Tháng 2/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH03', 'NV01', '2026-02-10 09:15:00', 3440000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Quà Tết'),
('KH01', 'NV02', '2026-02-20 16:45:00', 1890000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Tai nghe');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY() - 1, 'HH05', 2, 1550000, 3100000),
(SCOPE_IDENTITY() - 1, 'HH06', 2, 199000, 398000),
(SCOPE_IDENTITY(), 'HH03', 1, 1890000, 1890000);

-- Tháng 3/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH02', 'NV01', '2026-03-08 11:20:00', 2580000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Quà 8/3'),
('KH03', 'NV01', '2026-03-25 15:10:00', 1250000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Áo thời trang');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY() - 1, 'HH07', 2, 1290000, 2580000),
(SCOPE_IDENTITY(), 'HH01', 3, 350000, 1050000),
(SCOPE_IDENTITY(), 'HH06', 1, 199000, 199000);

-- Tháng 4/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH01', 'NV02', '2026-04-14 13:00:00', 9440000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Điện thoại + quần tây');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH04', 1, 8990000, 8990000),
(SCOPE_IDENTITY(), 'HH02', 1, 450000, 450000);

-- Tháng 5/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH02', 'NV01', '2026-05-18 10:30:00', 4970000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Đồ gia dụng');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH05', 3, 1550000, 4650000),
(SCOPE_IDENTITY(), 'HH06', 2, 199000, 398000);

-- Tháng 6/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH03', 'NV01', '2026-06-12 17:00:00', 3780000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Tai nghe x2');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH03', 2, 1890000, 3780000);

-- Tháng 7/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH01', 'NV02', '2026-07-20 09:40:00', 2500000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Thời trang hè');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH01', 4, 350000, 1400000),
(SCOPE_IDENTITY(), 'HH08', 4, 280000, 1120000);

-- Tháng 8/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH02', 'NV01', '2026-08-15 14:10:00', 10280000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Điện thoại + Loa');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH04', 1, 8990000, 8990000),
(SCOPE_IDENTITY(), 'HH07', 1, 1290000, 1290000);

-- Tháng 9/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH03', 'NV01', '2026-09-09 11:00:00', 3150000, N'Đã xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Nồi chiên + bình nước');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH05', 2, 1550000, 3100000);

-- Tháng 10/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH01', 'NV02', '2026-10-10 10:15:00', 5670000, N'Đã xử lí', N'Phạm Minh Hoàng', N'123 Nguyễn Huệ, Q1', '0912345678', N'Tai nghe + Áo');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY(), 'HH03', 2, 1890000, 3780000),
(SCOPE_IDENTITY(), 'HH01', 5, 350000, 1750000);

-- Tháng 11/2026
INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, TrangThai, TenKhachHang, DiaChiGiaoHang, SoDienThoaiGiaoHang, GhiChu)
VALUES 
('KH02', 'NV01', '2026-11-01 08:30:00', 4400000, N'Đã xử lí', N'Lê Thị Thu Thảo', N'456 Lê Văn Sỹ, Q3', '0987654321', N'Thời trang + Gia dụng'),
('KH03', 'NV01', '2026-11-02 16:00:00', 2140000, N'Chờ xử lí', N'Vũ Đình Khang', N'789 Cầu Giấy, HN', '0905123987', N'Đơn mới đặt');

INSERT INTO ChiTietDonHang (SoThuTuDonHang, MaHang, SoLuong, DonGia, ThanhTien)
VALUES 
(SCOPE_IDENTITY() - 1, 'HH01', 4, 350000, 1400000),
(SCOPE_IDENTITY() - 1, 'HH02', 4, 450000, 1800000),
(SCOPE_IDENTITY() - 1, 'HH06', 6, 199000, 1194000),
(SCOPE_IDENTITY(), 'HH07', 1, 1290000, 1290000),
(SCOPE_IDENTITY(), 'HH08', 3, 280000, 840000);
GO
