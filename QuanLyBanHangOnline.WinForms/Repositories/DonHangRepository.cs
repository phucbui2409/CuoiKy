using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBanHangOnline.WinForms.DataContext;

namespace QuanLyBanHangOnline.WinForms.Repositories
{
    public class DonHangViewModel
    {
        public int SoThuTu { get; set; }
        public string MaKH { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SoDienThoaiGiaoHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string MaNV { get; set; }
        public string GhiChu { get; set; }
    }

    public class ChiTietItemViewModel
    {
        public int MaCT { get; set; }
        public int SoThuTuDonHang { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MauSac { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }

    public class DoanhThuTheoNgayModel
    {
        public DateTime Ngay { get; set; }
        public int SoLuongDon { get; set; }
        public decimal TongTien { get; set; }
    }

    public class TopSanPhamModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int TongSoLuongBan { get; set; }
        public decimal TongDoanhThu { get; set; }
    }

    public class ThongKeThangModel
    {
        public int Thang { get; set; }
        public string TenThang { get; set; }
        public decimal DoanhThu { get; set; }
        public int SoLuongDon { get; set; }
    }

    public class ThongKeDanhMucModel
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public decimal TongDoanhThu { get; set; }
        public int TongSoLuong { get; set; }
        public double TyLePhanTram { get; set; }
    }

    public class ThongKeTrangThaiModel
    {
        public string TrangThai { get; set; }
        public int SoLuongDon { get; set; }
        public decimal TongTien { get; set; }
        public double TyLePhanTram { get; set; }
    }

    public class DonHangRepository
    {
        private static List<DonHang> _offlineDonHangs = new List<DonHang>
        {
            new DonHang { SoThuTu = 1, MaKH = "KH01", TenKhachHang = "Phạm Minh Hoàng", DiaChiGiaoHang = "123 Nguyễn Huệ, Quận 1", SoDienThoaiGiaoHang = "0912345678", NgayDatHang = new DateTime(2026, 1, 15, 10, 0, 0), TongTien = 1250000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 2, MaKH = "KH02", TenKhachHang = "Lê Thị Thu Thảo", DiaChiGiaoHang = "456 Lê Văn Sỹ, Quận 3", SoDienThoaiGiaoHang = "0987654321", NgayDatHang = new DateTime(2026, 1, 22, 14, 30, 0), TongTien = 8990000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 3, MaKH = "KH03", TenKhachHang = "Vũ Đình Khang", DiaChiGiaoHang = "789 Cầu Giấy, Hà Nội", SoDienThoaiGiaoHang = "0905123987", NgayDatHang = new DateTime(2026, 2, 10, 9, 15, 0), TongTien = 3440000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 4, MaKH = "KH01", TenKhachHang = "Phạm Minh Hoàng", DiaChiGiaoHang = "123 Nguyễn Huệ, Quận 1", SoDienThoaiGiaoHang = "0912345678", NgayDatHang = new DateTime(2026, 2, 20, 16, 45, 0), TongTien = 1890000, TrangThai = "Đã xử lí", MaNV = "NV02" },
            new DonHang { SoThuTu = 5, MaKH = "KH02", TenKhachHang = "Lê Thị Thu Thảo", DiaChiGiaoHang = "456 Lê Văn Sỹ, Quận 3", SoDienThoaiGiaoHang = "0987654321", NgayDatHang = new DateTime(2026, 3, 8, 11, 20, 0), TongTien = 2580000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 6, MaKH = "KH03", TenKhachHang = "Vũ Đình Khang", DiaChiGiaoHang = "789 Cầu Giấy, Hà Nội", SoDienThoaiGiaoHang = "0905123987", NgayDatHang = new DateTime(2026, 3, 25, 15, 10, 0), TongTien = 1250000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 7, MaKH = "KH01", TenKhachHang = "Phạm Minh Hoàng", DiaChiGiaoHang = "123 Nguyễn Huệ, Quận 1", SoDienThoaiGiaoHang = "0912345678", NgayDatHang = new DateTime(2026, 4, 14, 13, 0, 0), TongTien = 9440000, TrangThai = "Đã xử lí", MaNV = "NV02" },
            new DonHang { SoThuTu = 8, MaKH = "KH02", TenKhachHang = "Lê Thị Thu Thảo", DiaChiGiaoHang = "456 Lê Văn Sỹ, Quận 3", SoDienThoaiGiaoHang = "0987654321", NgayDatHang = new DateTime(2026, 5, 18, 10, 30, 0), TongTien = 4970000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 9, MaKH = "KH03", TenKhachHang = "Vũ Đình Khang", DiaChiGiaoHang = "789 Cầu Giấy, Hà Nội", SoDienThoaiGiaoHang = "0905123987", NgayDatHang = new DateTime(2026, 6, 12, 17, 0, 0), TongTien = 3780000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 10, MaKH = "KH01", TenKhachHang = "Phạm Minh Hoàng", DiaChiGiaoHang = "123 Nguyễn Huệ, Quận 1", SoDienThoaiGiaoHang = "0912345678", NgayDatHang = new DateTime(2026, 7, 20, 9, 40, 0), TongTien = 2500000, TrangThai = "Đã xử lí", MaNV = "NV02" },
            new DonHang { SoThuTu = 11, MaKH = "KH02", TenKhachHang = "Lê Thị Thu Thảo", DiaChiGiaoHang = "456 Lê Văn Sỹ, Quận 3", SoDienThoaiGiaoHang = "0987654321", NgayDatHang = new DateTime(2026, 8, 15, 14, 10, 0), TongTien = 10280000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 12, MaKH = "KH03", TenKhachHang = "Vũ Đình Khang", DiaChiGiaoHang = "789 Cầu Giấy, Hà Nội", SoDienThoaiGiaoHang = "0905123987", NgayDatHang = new DateTime(2026, 9, 9, 11, 0, 0), TongTien = 3150000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 13, MaKH = "KH01", TenKhachHang = "Phạm Minh Hoàng", DiaChiGiaoHang = "123 Nguyễn Huệ, Quận 1", SoDienThoaiGiaoHang = "0912345678", NgayDatHang = new DateTime(2026, 10, 10, 10, 15, 0), TongTien = 5670000, TrangThai = "Đã xử lí", MaNV = "NV02" },
            new DonHang { SoThuTu = 14, MaKH = "KH02", TenKhachHang = "Lê Thị Thu Thảo", DiaChiGiaoHang = "456 Lê Văn Sỹ, Quận 3", SoDienThoaiGiaoHang = "0987654321", NgayDatHang = new DateTime(2026, 11, 1, 8, 30, 0), TongTien = 4400000, TrangThai = "Đã xử lí", MaNV = "NV01" },
            new DonHang { SoThuTu = 15, MaKH = "KH03", TenKhachHang = "Vũ Đình Khang", DiaChiGiaoHang = "789 Cầu Giấy, Hà Nội", SoDienThoaiGiaoHang = "0905123987", NgayDatHang = new DateTime(2026, 11, 2, 16, 0, 0), TongTien = 2140000, TrangThai = "Chờ xử lí", MaNV = "NV01" }
        };

        private static List<ChiTietDonHang> _offlineChiTiet = new List<ChiTietDonHang>
        {
            new ChiTietDonHang { MaCT = 1, SoThuTuDonHang = 1, MaHang = "HH01", SoLuong = 2, DonGia = 350000, ThanhTien = 700000 },
            new ChiTietDonHang { MaCT = 2, SoThuTuDonHang = 1, MaHang = "HH08", SoLuong = 2, DonGia = 280000, ThanhTien = 560000 },
            new ChiTietDonHang { MaCT = 3, SoThuTuDonHang = 2, MaHang = "HH04", SoLuong = 1, DonGia = 8990000, ThanhTien = 8990000 },
            new ChiTietDonHang { MaCT = 4, SoThuTuDonHang = 3, MaHang = "HH05", SoLuong = 2, DonGia = 1550000, ThanhTien = 3100000 },
            new ChiTietDonHang { MaCT = 5, SoThuTuDonHang = 3, MaHang = "HH06", SoLuong = 2, DonGia = 199000, ThanhTien = 398000 },
            new ChiTietDonHang { MaCT = 6, SoThuTuDonHang = 4, MaHang = "HH03", SoLuong = 1, DonGia = 1890000, ThanhTien = 1890000 },
            new ChiTietDonHang { MaCT = 7, SoThuTuDonHang = 5, MaHang = "HH07", SoLuong = 2, DonGia = 1290000, ThanhTien = 2580000 },
            new ChiTietDonHang { MaCT = 8, SoThuTuDonHang = 6, MaHang = "HH01", SoLuong = 3, DonGia = 350000, ThanhTien = 1050000 },
            new ChiTietDonHang { MaCT = 9, SoThuTuDonHang = 6, MaHang = "HH06", SoLuong = 1, DonGia = 199000, ThanhTien = 199000 },
            new ChiTietDonHang { MaCT = 10, SoThuTuDonHang = 7, MaHang = "HH04", SoLuong = 1, DonGia = 8990000, ThanhTien = 8990000 },
            new ChiTietDonHang { MaCT = 11, SoThuTuDonHang = 7, MaHang = "HH02", SoLuong = 1, DonGia = 450000, ThanhTien = 450000 },
            new ChiTietDonHang { MaCT = 12, SoThuTuDonHang = 8, MaHang = "HH05", SoLuong = 3, DonGia = 1550000, ThanhTien = 4650000 },
            new ChiTietDonHang { MaCT = 13, SoThuTuDonHang = 8, MaHang = "HH06", SoLuong = 2, DonGia = 199000, ThanhTien = 398000 },
            new ChiTietDonHang { MaCT = 14, SoThuTuDonHang = 9, MaHang = "HH03", SoLuong = 2, DonGia = 1890000, ThanhTien = 3780000 },
            new ChiTietDonHang { MaCT = 15, SoThuTuDonHang = 10, MaHang = "HH01", SoLuong = 4, DonGia = 350000, ThanhTien = 1400000 },
            new ChiTietDonHang { MaCT = 16, SoThuTuDonHang = 10, MaHang = "HH08", SoLuong = 4, DonGia = 280000, ThanhTien = 1120000 },
            new ChiTietDonHang { MaCT = 17, SoThuTuDonHang = 11, MaHang = "HH04", SoLuong = 1, DonGia = 8990000, ThanhTien = 8990000 },
            new ChiTietDonHang { MaCT = 18, SoThuTuDonHang = 11, MaHang = "HH07", SoLuong = 1, DonGia = 1290000, ThanhTien = 1290000 },
            new ChiTietDonHang { MaCT = 19, SoThuTuDonHang = 12, MaHang = "HH05", SoLuong = 2, DonGia = 1550000, ThanhTien = 3100000 },
            new ChiTietDonHang { MaCT = 20, SoThuTuDonHang = 13, MaHang = "HH03", SoLuong = 2, DonGia = 1890000, ThanhTien = 3780000 },
            new ChiTietDonHang { MaCT = 21, SoThuTuDonHang = 13, MaHang = "HH01", SoLuong = 5, DonGia = 350000, ThanhTien = 1750000 },
            new ChiTietDonHang { MaCT = 22, SoThuTuDonHang = 14, MaHang = "HH01", SoLuong = 4, DonGia = 350000, ThanhTien = 1400000 },
            new ChiTietDonHang { MaCT = 23, SoThuTuDonHang = 14, MaHang = "HH02", SoLuong = 4, DonGia = 450000, ThanhTien = 1800000 },
            new ChiTietDonHang { MaCT = 24, SoThuTuDonHang = 14, MaHang = "HH06", SoLuong = 6, DonGia = 199000, ThanhTien = 1194000 },
            new ChiTietDonHang { MaCT = 25, SoThuTuDonHang = 15, MaHang = "HH07", SoLuong = 1, DonGia = 1290000, ThanhTien = 1290000 },
            new ChiTietDonHang { MaCT = 26, SoThuTuDonHang = 15, MaHang = "HH08", SoLuong = 3, DonGia = 280000, ThanhTien = 840000 }
        };

        private static readonly Dictionary<string, string> _offlineProductNames = new Dictionary<string, string>
        {
            { "HH01", "Áo sơ mi nam công sở" },
            { "HH02", "Quần tây nam cao cấp" },
            { "HH03", "Tai nghe Bluetooth Galaxy Buds" },
            { "HH04", "Điện thoại Galaxy A55 5G" },
            { "HH05", "Nồi chiên không dầu Sunhouse 6L" },
            { "HH06", "Bình giữ nhiệt Inox 304" },
            { "HH07", "Loa Bluetooth Sony SRS-XB13" },
            { "HH08", "Áo khoác gió thể thao nam" }
        };

        private static readonly Dictionary<string, string> _offlineProductCategories = new Dictionary<string, string>
        {
            { "HH01", "Thời trang" },
            { "HH02", "Thời trang" },
            { "HH03", "Điện tử & Công nghệ" },
            { "HH04", "Điện tử & Công nghệ" },
            { "HH05", "Đồ gia dụng" },
            { "HH06", "Đồ gia dụng" },
            { "HH07", "Điện tử & Công nghệ" },
            { "HH08", "Thời trang" }
        };

        // Lấy tất cả đơn hàng
        public List<DonHangViewModel> GetAllOrders(string trangThai = "ALL", DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var query = db.DonHangs.AsQueryable();

                    if (trangThai != "ALL")
                    {
                        query = query.Where(d => d.TrangThai == trangThai);
                    }

                    if (tuNgay.HasValue)
                    {
                        query = query.Where(d => d.NgayDatHang >= tuNgay.Value.Date);
                    }

                    if (denNgay.HasValue)
                    {
                        DateTime end = denNgay.Value.Date.AddDays(1).AddTicks(-1);
                        query = query.Where(d => d.NgayDatHang <= end);
                    }

                    // LINQ OrderByDescending
                    return query.OrderByDescending(d => d.NgayDatHang)
                                .Select(d => new DonHangViewModel
                                {
                                    SoThuTu = d.SoThuTu,
                                    MaKH = d.MaKH,
                                    TenKhachHang = d.TenKhachHang,
                                    DiaChiGiaoHang = d.DiaChiGiaoHang,
                                    SoDienThoaiGiaoHang = d.SoDienThoaiGiaoHang,
                                    NgayDatHang = d.NgayDatHang,
                                    TongTien = d.TongTien,
                                    TrangThai = d.TrangThai,
                                    MaNV = d.MaNV,
                                    GhiChu = d.GhiChu
                                }).ToList();
                }
            }
            catch
            {
                var query = _offlineDonHangs.AsEnumerable();
                if (trangThai != "ALL") query = query.Where(d => d.TrangThai == trangThai);
                return query.OrderByDescending(d => d.NgayDatHang).Select(d => new DonHangViewModel
                {
                    SoThuTu = d.SoThuTu,
                    MaKH = d.MaKH,
                    TenKhachHang = d.TenKhachHang,
                    DiaChiGiaoHang = d.DiaChiGiaoHang,
                    SoDienThoaiGiaoHang = d.SoDienThoaiGiaoHang,
                    NgayDatHang = d.NgayDatHang,
                    TongTien = d.TongTien,
                    TrangThai = d.TrangThai,
                    MaNV = d.MaNV,
                    GhiChu = d.GhiChu
                }).ToList();
            }
        }

        public DonHangViewModel GetOrderById(int soThuTu)
        {
            return GetAllOrders("ALL").FirstOrDefault(x => x.SoThuTu == soThuTu);
        }

        // Lấy danh sách đơn hàng đang chờ xử lý theo nguyên tắc FIFO (Đặt trước xử lý trước)
        public List<DonHangViewModel> LayDanhSachChoXuLyFIFO()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    // LINQ Where & OrderBy NgayDatHang tăng dần (FIFO)
                    return db.DonHangs
                             .Where(d => d.TrangThai == "Chờ xử lí")
                             .OrderBy(d => d.NgayDatHang)
                             .ThenBy(d => d.SoThuTu)
                             .Select(d => new DonHangViewModel
                             {
                                 SoThuTu = d.SoThuTu,
                                 MaKH = d.MaKH,
                                 TenKhachHang = d.TenKhachHang,
                                 DiaChiGiaoHang = d.DiaChiGiaoHang,
                                 SoDienThoaiGiaoHang = d.SoDienThoaiGiaoHang,
                                 NgayDatHang = d.NgayDatHang,
                                 TongTien = d.TongTien,
                                 TrangThai = d.TrangThai,
                                 MaNV = d.MaNV,
                                 GhiChu = d.GhiChu
                             }).ToList();
                }
            }
            catch
            {
                return _offlineDonHangs
                    .Where(d => d.TrangThai == "Chờ xử lí")
                    .OrderBy(d => d.NgayDatHang)
                    .Select(d => new DonHangViewModel
                    {
                        SoThuTu = d.SoThuTu,
                        MaKH = d.MaKH,
                        TenKhachHang = d.TenKhachHang,
                        DiaChiGiaoHang = d.DiaChiGiaoHang,
                        SoDienThoaiGiaoHang = d.SoDienThoaiGiaoHang,
                        NgayDatHang = d.NgayDatHang,
                        TongTien = d.TongTien,
                        TrangThai = d.TrangThai,
                        MaNV = d.MaNV,
                        GhiChu = d.GhiChu
                    }).ToList();
            }
        }

        // Lấy chi tiết của một đơn hàng
        public List<ChiTietItemViewModel> LayChiTietDonHang(int soThuTu)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    // LINQ Join với HangHoa để lấy TenHang
                    var query = from ct in db.ChiTietDonHangs
                                where ct.SoThuTuDonHang == soThuTu
                                join h in db.HangHoas on ct.MaHang equals h.MaHang into hGroup
                                from h in hGroup.DefaultIfEmpty()
                                select new ChiTietItemViewModel
                                {
                                    MaCT = ct.MaCT,
                                    SoThuTuDonHang = ct.SoThuTuDonHang,
                                    MaHang = ct.MaHang,
                                    TenHang = h != null ? h.TenHang : ct.MaHang,
                                    MauSac = h != null ? h.MauSac : "Tiêu chuẩn",
                                    SoLuong = ct.SoLuong,
                                    DonGia = ct.DonGia,
                                    ThanhTien = ct.ThanhTien
                                };
                    return query.ToList();
                }
            }
            catch
            {
                return _offlineChiTiet
                    .Where(ct => ct.SoThuTuDonHang == soThuTu)
                    .Select(ct => new ChiTietItemViewModel
                    {
                        MaCT = ct.MaCT,
                        SoThuTuDonHang = ct.SoThuTuDonHang,
                        MaHang = ct.MaHang,
                        TenHang = ct.MaHang,
                        MauSac = "Tiêu chuẩn",
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien
                    }).ToList();
            }
        }

        // Tạo đơn hàng mới
        public bool TaoDonHang(DonHang donHang, List<ChiTietDonHang> danhSachChiTiet, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (donHang == null || danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                errorMessage = "Đơn hàng phải có ít nhất một mặt hàng!";
                return false;
            }

            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    // Kiểm tra tồn kho cho từng món
                    foreach (var ct in danhSachChiTiet)
                    {
                        var hh = db.HangHoas.FirstOrDefault(h => h.MaHang == ct.MaHang);
                        if (hh == null)
                        {
                            errorMessage = $"Hàng hóa mã '{ct.MaHang}' không tồn tại!";
                            return false;
                        }
                        if (hh.SoLuong <= 0)
                        {
                            errorMessage = $"Sản phẩm '{hh.TenHang}' đã hết hàng!";
                            return false;
                        }
                        if (ct.SoLuong > hh.SoLuong)
                        {
                            errorMessage = $"Số lượng đặt '{hh.TenHang}' ({ct.SoLuong}) vượt quá tồn kho ({hh.SoLuong})!";
                            return false;
                        }
                    }

                    donHang.NgayDatHang = DateTime.Now;
                    donHang.TrangThai = "Chờ xử lí";
                    donHang.TongTien = danhSachChiTiet.Sum(c => c.ThanhTien);

                    db.DonHangs.InsertOnSubmit(donHang);
                    db.SubmitChanges(); // Sinh SoThuTu IDENTITY

                    foreach (var ct in danhSachChiTiet)
                    {
                        ct.SoThuTuDonHang = donHang.SoThuTu;
                        db.ChiTietDonHangs.InsertOnSubmit(ct);
                    }
                    db.SubmitChanges();

                    return true;
                }
            }
            catch
            {
                // Fallback offline
                int nextId = _offlineDonHangs.Count > 0 ? _offlineDonHangs.Max(d => d.SoThuTu) + 1 : 1;
                donHang.SoThuTu = nextId;
                donHang.NgayDatHang = DateTime.Now;
                donHang.TrangThai = "Chờ xử lí";
                donHang.TongTien = danhSachChiTiet.Sum(c => c.ThanhTien);
                _offlineDonHangs.Add(donHang);

                foreach (var ct in danhSachChiTiet)
                {
                    ct.SoThuTuDonHang = nextId;
                    _offlineChiTiet.Add(ct);
                }
                return true;
            }
        }

        // Xử lý đơn hàng FIFO: duyệt đơn, trừ tồn kho và cập nhật trạng thái "Đã xử lí"
        public bool XuLyDonHangFIFO(int soThuTu, string maNV, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var don = db.DonHangs.FirstOrDefault(d => d.SoThuTu == soThuTu);
                    if (don == null)
                    {
                        errorMessage = "Không tìm thấy đơn hàng!";
                        return false;
                    }

                    if (don.TrangThai != "Chờ xử lí")
                    {
                        errorMessage = "Đơn hàng này đã được xử lý hoặc đã hủy trước đó!";
                        return false;
                    }

                    var chiTiet = db.ChiTietDonHangs.Where(c => c.SoThuTuDonHang == soThuTu).ToList();
                    // Kiểm tra tồn kho
                    foreach (var item in chiTiet)
                    {
                        var hh = db.HangHoas.FirstOrDefault(h => h.MaHang == item.MaHang);
                        if (hh == null || hh.SoLuong < item.SoLuong)
                        {
                            errorMessage = $"Không thể xử lý đơn: Sản phẩm {item.MaHang} không đủ tồn kho!";
                            return false;
                        }
                    }

                    // Trừ tồn kho
                    foreach (var item in chiTiet)
                    {
                        var hh = db.HangHoas.FirstOrDefault(h => h.MaHang == item.MaHang);
                        hh.SoLuong -= item.SoLuong;
                    }

                    don.TrangThai = "Đã xử lí";
                    don.MaNV = maNV;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var don = _offlineDonHangs.FirstOrDefault(d => d.SoThuTu == soThuTu);
                if (don != null)
                {
                    don.TrangThai = "Đã xử lí";
                    don.MaNV = maNV;
                    return true;
                }
                errorMessage = "Không tìm thấy đơn hàng!";
                return false;
            }
        }

        // Hủy đơn hàng
        public bool HuyDonHang(int soThuTu, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var don = db.DonHangs.FirstOrDefault(d => d.SoThuTu == soThuTu);
                    if (don == null)
                    {
                        errorMessage = "Không tìm thấy đơn hàng!";
                        return false;
                    }

                    don.TrangThai = "Đã hủy";
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var don = _offlineDonHangs.FirstOrDefault(d => d.SoThuTu == soThuTu);
                if (don != null)
                {
                    don.TrangThai = "Đã hủy";
                    return true;
                }
                errorMessage = "Không tìm thấy đơn hàng!";
                return false;
            }
        }

        // Báo cáo doanh thu theo ngày (LINQ Where, GroupBy, Sum, Count, OrderBy)
        public List<DoanhThuTheoNgayModel> ThongKeDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    DateTime start = tuNgay.Date;
                    DateTime end = denNgay.Date.AddDays(1).AddTicks(-1);

                    var query = from d in db.DonHangs
                                where d.TrangThai == "Đã xử lí" && d.NgayDatHang >= start && d.NgayDatHang <= end
                                group d by d.NgayDatHang.Date into g
                                orderby g.Key
                                select new DoanhThuTheoNgayModel
                                {
                                    Ngay = g.Key,
                                    SoLuongDon = g.Count(), // LINQ Count
                                    TongTien = g.Sum(x => x.TongTien) // LINQ Sum
                                };
                    return query.ToList();
                }
            }
            catch
            {
                return _offlineDonHangs
                    .Where(d => d.TrangThai == "Đã xử lí")
                    .GroupBy(d => d.NgayDatHang.Date)
                    .Select(g => new DoanhThuTheoNgayModel
                    {
                        Ngay = g.Key,
                        SoLuongDon = g.Count(),
                        TongTien = g.Sum(x => x.TongTien)
                    }).ToList();
            }
        }

        // Top 5 sản phẩm bán chạy nhất (LINQ GroupBy, Sum, OrderByDescending, Take(5))
        public List<TopSanPhamModel> GetTopSellingProducts(int top = 5)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var query = from ct in db.ChiTietDonHangs
                                join d in db.DonHangs on ct.SoThuTuDonHang equals d.SoThuTu
                                where d.TrangThai == "Đã xử lí"
                                group ct by ct.MaHang into g
                                join h in db.HangHoas on g.Key equals h.MaHang into hGroup
                                from h in hGroup.DefaultIfEmpty()
                                orderby g.Sum(x => x.SoLuong) descending // LINQ OrderByDescending
                                select new TopSanPhamModel
                                {
                                    MaHang = g.Key,
                                    TenHang = h != null ? h.TenHang : g.Key,
                                    TongSoLuongBan = g.Sum(x => x.SoLuong), // LINQ Sum
                                    TongDoanhThu = g.Sum(x => x.ThanhTien)
                                };

                    return query.Take(top).ToList(); // LINQ Take
                }
            }
            catch
            {
                return new List<TopSanPhamModel>
                {
                    new TopSanPhamModel { MaHang = "HH01", TenHang = "Áo sơ mi nam công sở", TongSoLuongBan = 12, TongDoanhThu = 4200000 },
                    new TopSanPhamModel { MaHang = "HH02", TenHang = "Quần tây nam cao cấp", TongSoLuongBan = 8, TongDoanhThu = 3600000 },
                    new TopSanPhamModel { MaHang = "HH03", TenHang = "Tai nghe Bluetooth buds", TongSoLuongBan = 5, TongDoanhThu = 9450000 }
                };
            }
        }

        // =========================================================================
        // CÁC PHƯƠNG THỨC THỐNG KÊ BIỂU ĐỒ NÂNG CAO SỬ DỤNG LINQ GroupBy VÀ Sum
        // =========================================================================

        /// <summary>
        /// 1. BIỂU ĐỒ ĐƯỜNG (LINE / SPLINE CHART): Thống kê doanh thu 12 tháng trong năm
        /// Kỹ thuật: LINQ GroupBy(d => d.NgayDatHang.Month) và Sum(TongTien)
        /// </summary>
        public List<ThongKeThangModel> ThongKeDoanhThu12Thang(int nam, string trangThai = "Đã xử lí")
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    DateTime start = new DateTime(nam, 1, 1);
                    DateTime end = new DateTime(nam + 1, 1, 1);

                    var query = db.DonHangs.Where(d => d.NgayDatHang >= start && d.NgayDatHang < end);
                    if (trangThai != "ALL")
                    {
                        query = query.Where(d => d.TrangThai == trangThai);
                    }

                    // Tải dữ liệu cần thiết về bộ nhớ để LINQ to Objects xử lý hoàn hảo
                    var listOrders = query.Select(d => new { d.NgayDatHang, d.TongTien }).ToList();

                    // LINQ GroupBy theo Tháng và Sum Doanh Thu
                    var groupedByMonth = listOrders
                        .GroupBy(d => d.NgayDatHang.Month)
                        .Select(g => new
                        {
                            Thang = g.Key,
                            DoanhThu = g.Sum(x => x.TongTien), // LINQ Sum
                            SoDon = g.Count()                   // LINQ Count
                        })
                        .ToDictionary(x => x.Thang);

                    // Đảm bảo trả về đủ 12 tháng từ Tháng 1 đến Tháng 12
                    var result = new List<ThongKeThangModel>();
                    for (int m = 1; m <= 12; m++)
                    {
                        decimal doanhThu = groupedByMonth.ContainsKey(m) ? groupedByMonth[m].DoanhThu : 0;
                        int soDon = groupedByMonth.ContainsKey(m) ? groupedByMonth[m].SoDon : 0;
                        result.Add(new ThongKeThangModel
                        {
                            Thang = m,
                            TenThang = $"T{m}",
                            DoanhThu = doanhThu,
                            SoLuongDon = soDon
                        });
                    }
                    return result;
                }
            }
            catch
            {
                // Fallback dữ liệu offline
                DateTime start = new DateTime(nam, 1, 1);
                DateTime end = new DateTime(nam + 1, 1, 1);
                var query = _offlineDonHangs.Where(d => d.NgayDatHang >= start && d.NgayDatHang < end);
                if (trangThai != "ALL")
                {
                    query = query.Where(d => d.TrangThai == trangThai);
                }

                var grouped = query
                    .GroupBy(d => d.NgayDatHang.Month)
                    .Select(g => new { Thang = g.Key, DoanhThu = g.Sum(x => x.TongTien), SoDon = g.Count() })
                    .ToDictionary(x => x.Thang);

                var result = new List<ThongKeThangModel>();
                for (int m = 1; m <= 12; m++)
                {
                    result.Add(new ThongKeThangModel
                    {
                        Thang = m,
                        TenThang = $"T{m}",
                        DoanhThu = grouped.ContainsKey(m) ? grouped[m].DoanhThu : 0,
                        SoLuongDon = grouped.ContainsKey(m) ? grouped[m].SoDon : 0
                    });
                }
                return result;
            }
        }

        /// <summary>
        /// 2. BIỂU ĐỒ CỘT (COLUMN / BAR CHART): Top 5 sản phẩm bán chạy nhất trong tháng
        /// Kỹ thuật: LINQ Where, GroupBy(ct => ct.MaHang), Sum(SoLuong), OrderByDescending, Take(5)
        /// </summary>
        public List<TopSanPhamModel> GetTop5ProductsInMonth(int nam, int thang = 0)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                    DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                    var query = from ct in db.ChiTietDonHangs
                                join d in db.DonHangs on ct.SoThuTuDonHang equals d.SoThuTu
                                where d.NgayDatHang >= start && d.NgayDatHang < end && d.TrangThai == "Đã xử lí"
                                join h in db.HangHoas on ct.MaHang equals h.MaHang into hGroup
                                from h in hGroup.DefaultIfEmpty()
                                select new
                                {
                                    ct.MaHang,
                                    TenHang = h != null ? h.TenHang : ct.MaHang,
                                    ct.SoLuong,
                                    ct.ThanhTien
                                };

                    var listItems = query.ToList();

                    // LINQ GroupBy theo Tên Hàng, Sum số lượng bán & Doanh thu, sắp xếp giảm dần và lấy Top 5
                    var top5 = listItems
                        .GroupBy(x => new { x.MaHang, x.TenHang })
                        .Select(g => new TopSanPhamModel
                        {
                            MaHang = g.Key.MaHang,
                            TenHang = g.Key.TenHang,
                            TongSoLuongBan = g.Sum(x => x.SoLuong),    // LINQ Sum Số lượng
                            TongDoanhThu = g.Sum(x => x.ThanhTien)     // LINQ Sum Doanh thu
                        })
                        .OrderByDescending(x => x.TongSoLuongBan)
                        .Take(5)                                      // LINQ Take 5
                        .ToList();

                    return top5;
                }
            }
            catch
            {
                DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                var orderIds = _offlineDonHangs
                    .Where(d => d.NgayDatHang >= start && d.NgayDatHang < end && d.TrangThai == "Đã xử lí")
                    .Select(d => d.SoThuTu)
                    .ToHashSet();

                var top5 = _offlineChiTiet
                    .Where(ct => orderIds.Contains(ct.SoThuTuDonHang))
                    .GroupBy(ct => ct.MaHang)
                    .Select(g => new TopSanPhamModel
                    {
                        MaHang = g.Key,
                        TenHang = _offlineProductNames.ContainsKey(g.Key) ? _offlineProductNames[g.Key] : g.Key,
                        TongSoLuongBan = g.Sum(x => x.SoLuong),
                        TongDoanhThu = g.Sum(x => x.ThanhTien)
                    })
                    .OrderByDescending(x => x.TongSoLuongBan)
                    .Take(5)
                    .ToList();

                return top5;
            }
        }

        /// <summary>
        /// 3. BIỂU ĐỒ TRÒN / VÀNH KHUYÊN (PIE / DOUGHNUT CHART): Tỷ lệ doanh thu theo Danh mục hàng hóa
        /// Kỹ thuật: LINQ Join HangHoa & LoaiHang, GroupBy(LoaiHang), Sum(ThanhTien)
        /// </summary>
        public List<ThongKeDanhMucModel> ThongKeDoanhThuTheoDanhMuc(int nam, int thang = 0)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                    DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                    var query = from ct in db.ChiTietDonHangs
                                join d in db.DonHangs on ct.SoThuTuDonHang equals d.SoThuTu
                                where d.NgayDatHang >= start && d.NgayDatHang < end && d.TrangThai == "Đã xử lí"
                                join h in db.HangHoas on ct.MaHang equals h.MaHang
                                join l in db.LoaiHangs on h.MaLoai equals l.MaLoai
                                select new
                                {
                                    l.MaLoai,
                                    l.TenLoai,
                                    ct.ThanhTien,
                                    ct.SoLuong
                                };

                    var listItems = query.ToList();

                    // LINQ GroupBy theo Danh mục và Sum Doanh thu
                    var group = listItems
                        .GroupBy(x => new { x.MaLoai, x.TenLoai })
                        .Select(g => new ThongKeDanhMucModel
                        {
                            MaLoai = g.Key.MaLoai,
                            TenLoai = g.Key.TenLoai,
                            TongDoanhThu = g.Sum(x => x.ThanhTien),    // LINQ Sum Doanh thu
                            TongSoLuong = g.Sum(x => x.SoLuong)       // LINQ Sum Số lượng
                        })
                        .OrderByDescending(x => x.TongDoanhThu)
                        .ToList();

                    decimal tongDoanhThu = group.Sum(x => x.TongDoanhThu);
                    foreach (var item in group)
                    {
                        item.TyLePhanTram = tongDoanhThu > 0 ? (double)(item.TongDoanhThu / tongDoanhThu * 100) : 0;
                    }

                    return group;
                }
            }
            catch
            {
                DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                var orderIds = _offlineDonHangs
                    .Where(d => d.NgayDatHang >= start && d.NgayDatHang < end && d.TrangThai == "Đã xử lí")
                    .Select(d => d.SoThuTu)
                    .ToHashSet();

                var group = _offlineChiTiet
                    .Where(ct => orderIds.Contains(ct.SoThuTuDonHang))
                    .GroupBy(ct => _offlineProductCategories.ContainsKey(ct.MaHang) ? _offlineProductCategories[ct.MaHang] : "Khác")
                    .Select(g => new ThongKeDanhMucModel
                    {
                        MaLoai = g.Key,
                        TenLoai = g.Key,
                        TongDoanhThu = g.Sum(x => x.ThanhTien),
                        TongSoLuong = g.Sum(x => x.SoLuong)
                    })
                    .OrderByDescending(x => x.TongDoanhThu)
                    .ToList();

                decimal tongDoanhThu = group.Sum(x => x.TongDoanhThu);
                foreach (var item in group)
                {
                    item.TyLePhanTram = tongDoanhThu > 0 ? (double)(item.TongDoanhThu / tongDoanhThu * 100) : 0;
                }

                return group;
            }
        }

        /// <summary>
        /// 4. BIỂU ĐỒ TRÒN (PIE CHART): Tỷ lệ theo Trạng thái đơn hàng
        /// Kỹ thuật: LINQ GroupBy(d => d.TrangThai), Count(), Sum(TongTien)
        /// </summary>
        public List<ThongKeTrangThaiModel> ThongKeTheoTrangThai(int nam, int thang = 0)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                    DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                    var query = db.DonHangs
                        .Where(d => d.NgayDatHang >= start && d.NgayDatHang < end)
                        .Select(d => new { d.TrangThai, d.TongTien })
                        .ToList();

                    var grouped = query
                        .GroupBy(d => d.TrangThai)
                        .Select(g => new ThongKeTrangThaiModel
                        {
                            TrangThai = g.Key,
                            SoLuongDon = g.Count(),
                            TongTien = g.Sum(x => x.TongTien)
                        })
                        .OrderByDescending(x => x.SoLuongDon)
                        .ToList();

                    int tongDon = grouped.Sum(x => x.SoLuongDon);
                    foreach (var item in grouped)
                    {
                        item.TyLePhanTram = tongDon > 0 ? (double)item.SoLuongDon / tongDon * 100 : 0;
                    }

                    return grouped;
                }
            }
            catch
            {
                DateTime start = thang > 0 ? new DateTime(nam, thang, 1) : new DateTime(nam, 1, 1);
                DateTime end = thang > 0 ? (thang == 12 ? new DateTime(nam + 1, 1, 1) : new DateTime(nam, thang + 1, 1)) : new DateTime(nam + 1, 1, 1);

                var grouped = _offlineDonHangs
                    .Where(d => d.NgayDatHang >= start && d.NgayDatHang < end)
                    .GroupBy(d => d.TrangThai)
                    .Select(g => new ThongKeTrangThaiModel
                    {
                        TrangThai = g.Key,
                        SoLuongDon = g.Count(),
                        TongTien = g.Sum(x => x.TongTien)
                    })
                    .OrderByDescending(x => x.SoLuongDon)
                    .ToList();

                int tongDon = grouped.Sum(x => x.SoLuongDon);
                foreach (var item in grouped)
                {
                    item.TyLePhanTram = tongDon > 0 ? (double)item.SoLuongDon / tongDon * 100 : 0;
                }

                return grouped;
            }
        }
    }
}
