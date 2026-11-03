USE QuanLyBanHangOnline;
GO
UPDATE DonHang SET TrangThai = N'Đã xử lí' WHERE SoThuTu <= 1015;
UPDATE DonHang SET TrangThai = N'Chờ xử lí' WHERE SoThuTu >= 1016;
GO
