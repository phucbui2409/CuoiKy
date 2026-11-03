using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBanHangOnline.WinForms.DataContext;

namespace QuanLyBanHangOnline.WinForms.Repositories
{
    public class HangHoaViewModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MaNSX { get; set; }
        public string TenNSX { get; set; }
        public string MauSac { get; set; }
        public decimal GiaBan { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public int SoLuong { get; set; }
        public string TinhTrang => SoLuong > 0 ? "Còn hàng" : "Hết hàng";
    }

    public class HangHoaRepository
    {
        private static List<HangHoa> _offlineHangHoa = new List<HangHoa>
        {
            new HangHoa { MaHang = "HH01", TenHang = "Áo sơ mi nam công sở", MaLoai = "THOITRANG", MaNSX = "NSX01", MauSac = "Trắng", GiaBan = 350000, NgayNhapKho = DateTime.Now.AddDays(-30), SoLuong = 50 },
            new HangHoa { MaHang = "HH02", TenHang = "Quần tây nam cao cấp", MaLoai = "THOITRANG", MaNSX = "NSX01", MauSac = "Đen", GiaBan = 450000, NgayNhapKho = DateTime.Now.AddDays(-28), SoLuong = 40 },
            new HangHoa { MaHang = "HH03", TenHang = "Tai nghe Bluetooth buds", MaLoai = "DIENTU", MaNSX = "NSX02", MauSac = "Xanh rêu", GiaBan = 1890000, NgayNhapKho = DateTime.Now.AddDays(-20), SoLuong = 25 },
            new HangHoa { MaHang = "HH04", TenHang = "Điện thoại thông minh A55", MaLoai = "DIENTU", MaNSX = "NSX02", MauSac = "Xanh đen", GiaBan = 8990000, NgayNhapKho = DateTime.Now.AddDays(-15), SoLuong = 15 },
            new HangHoa { MaHang = "HH05", TenHang = "Nồi chiên không dầu 6L", MaLoai = "GPOADUNG", MaNSX = "NSX03", MauSac = "Đen bóng", GiaBan = 1550000, NgayNhapKho = DateTime.Now.AddDays(-10), SoLuong = 30 },
            new HangHoa { MaHang = "HH06", TenHang = "Bình giữ nhiệt Inox 304", MaLoai = "GPOADUNG", MaNSX = "NSX03", MauSac = "Bạc", GiaBan = 199000, NgayNhapKho = DateTime.Now.AddDays(-8), SoLuong = 80 },
            new HangHoa { MaHang = "HH07", TenHang = "Loa Bluetooth di động Sony", MaLoai = "DIENTU", MaNSX = "NSX04", MauSac = "Xanh dương", GiaBan = 1290000, NgayNhapKho = DateTime.Now.AddDays(-5), SoLuong = 20 },
            new HangHoa { MaHang = "HH08", TenHang = "Áo khoác gió thể thao nam", MaLoai = "THOITRANG", MaNSX = "NSX01", MauSac = "Xám ghi", GiaBan = 280000, NgayNhapKho = DateTime.Now.AddDays(-2), SoLuong = 4 }
        };

        // Lấy tất cả hàng hóa kèm tên loại và tên nhà sản xuất (LINQ Join)
        public List<HangHoaViewModel> GetAll()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var query = from h in db.HangHoas
                                join l in db.LoaiHangs on h.MaLoai equals l.MaLoai into lGroup
                                from l in lGroup.DefaultIfEmpty()
                                join nsx in db.NhaSanXuats on h.MaNSX equals nsx.MaNSX into nsxGroup
                                from nsx in nsxGroup.DefaultIfEmpty()
                                orderby h.MaHang
                                select new HangHoaViewModel
                                {
                                    MaHang = h.MaHang,
                                    TenHang = h.TenHang,
                                    MaLoai = h.MaLoai,
                                    TenLoai = l != null ? l.TenLoai : h.MaLoai,
                                    MaNSX = h.MaNSX,
                                    TenNSX = nsx != null ? nsx.TenNSX : h.MaNSX,
                                    MauSac = h.MauSac,
                                    GiaBan = h.GiaBan,
                                    NgayNhapKho = h.NgayNhapKho,
                                    SoLuong = h.SoLuong
                                };
                    return query.ToList();
                }
            }
            catch
            {
                return _offlineHangHoa.Select(h => new HangHoaViewModel
                {
                    MaHang = h.MaHang,
                    TenHang = h.TenHang,
                    MaLoai = h.MaLoai,
                    TenLoai = h.MaLoai,
                    MaNSX = h.MaNSX,
                    TenNSX = h.MaNSX,
                    MauSac = h.MauSac,
                    GiaBan = h.GiaBan,
                    NgayNhapKho = h.NgayNhapKho,
                    SoLuong = h.SoLuong
                }).ToList();
            }
        }

        // Tìm kiếm nâng cao đa tiêu chí bằng LINQ query & lambda
        public List<HangHoaViewModel> TraCuu(string keyword, string maLoai, string maNSX, decimal? giaTu, decimal? giaDen, string tinhTrang)
        {
            var list = GetAll();

            // LINQ Where
            var query = list.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(h => h.TenHang.ToLower().Contains(kw) || h.MaHang.ToLower().Contains(kw) || h.MauSac.ToLower().Contains(kw));
            }

            if (!string.IsNullOrWhiteSpace(maLoai) && maLoai != "ALL")
            {
                query = query.Where(h => h.MaLoai == maLoai);
            }

            if (!string.IsNullOrWhiteSpace(maNSX) && maNSX != "ALL")
            {
                query = query.Where(h => h.MaNSX == maNSX);
            }

            if (giaTu.HasValue)
            {
                query = query.Where(h => h.GiaBan >= giaTu.Value);
            }

            if (giaDen.HasValue)
            {
                query = query.Where(h => h.GiaBan <= giaDen.Value);
            }

            if (tinhTrang == "CONHANG")
            {
                query = query.Where(h => h.SoLuong > 0);
            }
            else if (tinhTrang == "HETHANG")
            {
                query = query.Where(h => h.SoLuong <= 0);
            }

            // LINQ OrderBy
            return query.OrderBy(h => h.TenHang).ToList();
        }

        // Lấy danh sách hàng sắp hết tồn kho (LINQ Where, OrderBy, Take, Skip)
        public List<HangHoaViewModel> GetLowStock(int threshold = 5, int skip = 0, int take = 10)
        {
            var all = GetAll();
            return all.Where(h => h.SoLuong <= threshold)
                      .OrderBy(h => h.SoLuong)
                      .Skip(skip)
                      .Take(take)
                      .ToList();
        }

        // Lấy chi tiết 1 hàng hóa
        public HangHoa GetById(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang)) return null;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.HangHoas.FirstOrDefault(h => h.MaHang == maHang.Trim());
                }
            }
            catch
            {
                return _offlineHangHoa.FirstOrDefault(h => h.MaHang == maHang.Trim());
            }
        }

        // Thêm hàng hóa: Validate mã 4 ký tự và không trùng
        public bool Add(HangHoa hh, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (hh == null)
            {
                errorMessage = "Dữ liệu hàng hóa rỗng!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hh.MaHang) || hh.MaHang.Trim().Length != 4)
            {
                errorMessage = "Mã hàng phải gồm đúng 4 ký tự!";
                return false;
            }

            hh.MaHang = hh.MaHang.Trim().ToUpper();

            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    if (db.HangHoas.Any(h => h.MaHang == hh.MaHang))
                    {
                        errorMessage = $"Mã hàng '{hh.MaHang}' đã tồn tại trong hệ thống!";
                        return false;
                    }

                    db.HangHoas.InsertOnSubmit(hh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                if (_offlineHangHoa.Any(h => h.MaHang == hh.MaHang))
                {
                    errorMessage = $"Mã hàng '{hh.MaHang}' đã tồn tại trong hệ thống!";
                    return false;
                }
                _offlineHangHoa.Add(hh);
                return true;
            }
        }

        // Sửa hàng hóa
        public bool Update(HangHoa hh, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.HangHoas.FirstOrDefault(h => h.MaHang == hh.MaHang);
                    if (existing == null)
                    {
                        errorMessage = "Không tìm thấy hàng hóa!";
                        return false;
                    }

                    existing.TenHang = hh.TenHang;
                    existing.MaLoai = hh.MaLoai;
                    existing.MaNSX = hh.MaNSX;
                    existing.MauSac = hh.MauSac;
                    existing.GiaBan = hh.GiaBan;
                    existing.NgayNhapKho = hh.NgayNhapKho;
                    existing.SoLuong = hh.SoLuong;

                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offlineHangHoa.FirstOrDefault(h => h.MaHang == hh.MaHang);
                if (existing != null)
                {
                    existing.TenHang = hh.TenHang;
                    existing.MaLoai = hh.MaLoai;
                    existing.MaNSX = hh.MaNSX;
                    existing.MauSac = hh.MauSac;
                    existing.GiaBan = hh.GiaBan;
                    existing.NgayNhapKho = hh.NgayNhapKho;
                    existing.SoLuong = hh.SoLuong;
                    return true;
                }
                errorMessage = "Không tìm thấy hàng hóa!";
                return false;
            }
        }

        // Xóa hàng hóa
        public bool Delete(string maHang, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var hh = db.HangHoas.FirstOrDefault(h => h.MaHang == maHang);
                    if (hh == null)
                    {
                        errorMessage = "Không tìm thấy hàng hóa!";
                        return false;
                    }

                    // Kiểm tra xem hàng này đã có trong đơn hàng chưa
                    if (db.ChiTietDonHangs.Any(ct => ct.MaHang == maHang))
                    {
                        errorMessage = "Hàng hóa này đã phát sinh đơn hàng, không thể xóa trực tiếp!";
                        return false;
                    }

                    db.HangHoas.DeleteOnSubmit(hh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var hh = _offlineHangHoa.FirstOrDefault(h => h.MaHang == maHang);
                if (hh != null)
                {
                    _offlineHangHoa.Remove(hh);
                    return true;
                }
                errorMessage = "Không tìm thấy hàng hóa!";
                return false;
            }
        }
    }
}
