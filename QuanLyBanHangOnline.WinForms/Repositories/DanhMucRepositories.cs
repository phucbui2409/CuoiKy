using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBanHangOnline.WinForms.DataContext;

namespace QuanLyBanHangOnline.WinForms.Repositories
{
    public class LoaiHangRepository
    {
        private static List<LoaiHang> _offline = new List<LoaiHang>
        {
            new LoaiHang { MaLoai = "THOITRANG", TenLoai = "Thời trang", MoTa = "Quần áo, phụ kiện" },
            new LoaiHang { MaLoai = "DIENTU", TenLoai = "Điện tử & Công nghệ", MoTa = "Thiết bị điện tử, điện thoại" },
            new LoaiHang { MaLoai = "GPOADUNG", TenLoai = "Đồ gia dụng", MoTa = "Đồ dùng sinh hoạt" }
        };

        public List<LoaiHang> GetAll()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.LoaiHangs.OrderBy(l => l.MaLoai).ToList();
                }
            }
            catch { return _offline.ToList(); }
        }

        public bool Add(LoaiHang item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    if (db.LoaiHangs.Any(x => x.MaLoai == item.MaLoai))
                    {
                        error = "Mã loại hàng đã tồn tại!";
                        return false;
                    }
                    db.LoaiHangs.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                if (_offline.Any(x => x.MaLoai == item.MaLoai)) { error = "Mã loại đã tồn tại!"; return false; }
                _offline.Add(item);
                return true;
            }
        }

        public bool Update(LoaiHang item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.LoaiHangs.FirstOrDefault(x => x.MaLoai == item.MaLoai);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    existing.TenLoai = item.TenLoai;
                    existing.MoTa = item.MoTa;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaLoai == item.MaLoai);
                if (existing != null) { existing.TenLoai = item.TenLoai; existing.MoTa = item.MoTa; return true; }
                error = "Không tìm thấy!";
                return false;
            }
        }

        public bool Delete(string maLoai, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.LoaiHangs.FirstOrDefault(x => x.MaLoai == maLoai);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    if (db.HangHoas.Any(h => h.MaLoai == maLoai)) { error = "Không thể xóa loại hàng đang có hàng hóa liên kết!"; return false; }
                    db.LoaiHangs.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaLoai == maLoai);
                if (existing != null) { _offline.Remove(existing); return true; }
                error = "Không tìm thấy!";
                return false;
            }
        }
    }

    public class NhaSanXuatRepository
    {
        private static List<NhaSanXuat> _offline = new List<NhaSanXuat>
        {
            new NhaSanXuat { MaNSX = "NSX01", TenNSX = "May Mặc An Phước", QuocGia = "Việt Nam", DiaChi = "Quận 1, TP.HCM", SoDienThoai = "02838221144" },
            new NhaSanXuat { MaNSX = "NSX02", TenNSX = "Samsung Electronics", QuocGia = "Hàn Quốc", DiaChi = "TP. Thủ Đức", SoDienThoai = "02837360000" },
            new NhaSanXuat { MaNSX = "NSX03", TenNSX = "Gia Dụng Sunhouse", QuocGia = "Việt Nam", DiaChi = "Thanh Trì, Hà Nội", SoDienThoai = "02437366688" },
            new NhaSanXuat { MaNSX = "NSX04", TenNSX = "Sony Corporation", QuocGia = "Nhật Bản", DiaChi = "Tokyo, Japan", SoDienThoai = "02838220099" }
        };

        public List<NhaSanXuat> GetAll()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.NhaSanXuats.OrderBy(n => n.MaNSX).ToList();
                }
            }
            catch { return _offline.ToList(); }
        }

        public bool Add(NhaSanXuat item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    if (db.NhaSanXuats.Any(x => x.MaNSX == item.MaNSX)) { error = "Mã NSX đã tồn tại!"; return false; }
                    db.NhaSanXuats.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                if (_offline.Any(x => x.MaNSX == item.MaNSX)) { error = "Mã NSX đã tồn tại!"; return false; }
                _offline.Add(item);
                return true;
            }
        }

        public bool Update(NhaSanXuat item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.NhaSanXuats.FirstOrDefault(x => x.MaNSX == item.MaNSX);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    existing.TenNSX = item.TenNSX;
                    existing.QuocGia = item.QuocGia;
                    existing.DiaChi = item.DiaChi;
                    existing.SoDienThoai = item.SoDienThoai;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaNSX == item.MaNSX);
                if (existing != null)
                {
                    existing.TenNSX = item.TenNSX; existing.QuocGia = item.QuocGia;
                    existing.DiaChi = item.DiaChi; existing.SoDienThoai = item.SoDienThoai;
                    return true;
                }
                error = "Không tìm thấy!";
                return false;
            }
        }

        public bool Delete(string maNSX, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.NhaSanXuats.FirstOrDefault(x => x.MaNSX == maNSX);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    if (db.HangHoas.Any(h => h.MaNSX == maNSX)) { error = "Không thể xóa NSX đang có hàng hóa liên kết!"; return false; }
                    db.NhaSanXuats.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaNSX == maNSX);
                if (existing != null) { _offline.Remove(existing); return true; }
                error = "Không tìm thấy!";
                return false;
            }
        }
    }

    public class KhachHangRepository
    {
        private static List<KhachHang> _offline = new List<KhachHang>
        {
            new KhachHang { MaKH = "KH01", HoTen = "Phạm Minh Hoàng", DiaChi = "123 Nguyễn Huệ, Quận 1, TP.HCM", SoDienThoai = "0912345678", Email = "hoang.pm@gmail.com" },
            new KhachHang { MaKH = "KH02", HoTen = "Lê Thị Thu Thảo", DiaChi = "456 Lê Văn Sỹ, Quận 3, TP.HCM", SoDienThoai = "0987654321", Email = "thao.le@gmail.com" },
            new KhachHang { MaKH = "KH03", HoTen = "Vũ Đình Khang", DiaChi = "789 Cầu Giấy, Hà Nội", SoDienThoai = "0905123987", Email = "khang.vu@gmail.com" }
        };

        public List<KhachHang> GetAll()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.KhachHangs.OrderBy(k => k.MaKH).ToList();
                }
            }
            catch { return _offline.ToList(); }
        }

        public bool Add(KhachHang item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    if (db.KhachHangs.Any(x => x.MaKH == item.MaKH)) { error = "Mã KH đã tồn tại!"; return false; }
                    db.KhachHangs.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                if (_offline.Any(x => x.MaKH == item.MaKH)) { error = "Mã KH đã tồn tại!"; return false; }
                _offline.Add(item);
                return true;
            }
        }

        public bool Update(KhachHang item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.KhachHangs.FirstOrDefault(x => x.MaKH == item.MaKH);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    existing.HoTen = item.HoTen;
                    existing.DiaChi = item.DiaChi;
                    existing.SoDienThoai = item.SoDienThoai;
                    existing.Email = item.Email;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaKH == item.MaKH);
                if (existing != null)
                {
                    existing.HoTen = item.HoTen; existing.DiaChi = item.DiaChi;
                    existing.SoDienThoai = item.SoDienThoai; existing.Email = item.Email;
                    return true;
                }
                error = "Không tìm thấy!";
                return false;
            }
        }

        public bool Delete(string maKH, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    if (db.DonHangs.Any(d => d.MaKH == maKH)) { error = "Khách hàng này đã có đơn hàng trong hệ thống!"; return false; }
                    db.KhachHangs.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaKH == maKH);
                if (existing != null) { _offline.Remove(existing); return true; }
                error = "Không tìm thấy!";
                return false;
            }
        }
    }

    public class NhanVienRepository
    {
        private static List<NhanVien> _offline = new List<NhanVien>
        {
            new NhanVien { MaNV = "NV00", HoTen = "Quản Trị Viên Hệ Thống", GioiTinh = "Nam", NgaySinh = new DateTime(1990, 1, 1), DiaChi = "Trụ sở chính", SoDienThoai = "0901112233", ChucVu = "Quản trị viên hệ thống", MaVaiTro = "ADMIN" },
            new NhanVien { MaNV = "NV01", HoTen = "Trần Thị Bích Ngọc", GioiTinh = "Nữ", NgaySinh = new DateTime(1998, 5, 15), DiaChi = "Tân Bình, TP.HCM", SoDienThoai = "0903334455", ChucVu = "Nhân viên bán hàng", MaVaiTro = "NHANVIEN" },
            new NhanVien { MaNV = "NV02", HoTen = "Nguyễn Văn Quản Lý", GioiTinh = "Nam", NgaySinh = new DateTime(1992, 8, 20), DiaChi = "Bình Thạnh, TP.HCM", SoDienThoai = "0902223344", ChucVu = "Trưởng phòng kinh doanh", MaVaiTro = "QUANLY" }
        };

        public List<NhanVien> GetAll()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.NhanViens.OrderBy(n => n.MaNV).ToList();
                }
            }
            catch { return _offline.ToList(); }
        }

        public bool Add(NhanVien item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    if (db.NhanViens.Any(x => x.MaNV == item.MaNV)) { error = "Mã NV đã tồn tại!"; return false; }
                    db.NhanViens.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                if (_offline.Any(x => x.MaNV == item.MaNV)) { error = "Mã NV đã tồn tại!"; return false; }
                _offline.Add(item);
                return true;
            }
        }

        public bool Update(NhanVien item, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.NhanViens.FirstOrDefault(x => x.MaNV == item.MaNV);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    existing.HoTen = item.HoTen;
                    existing.GioiTinh = item.GioiTinh;
                    existing.NgaySinh = item.NgaySinh;
                    existing.DiaChi = item.DiaChi;
                    existing.SoDienThoai = item.SoDienThoai;
                    existing.ChucVu = item.ChucVu;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaNV == item.MaNV);
                if (existing != null)
                {
                    existing.HoTen = item.HoTen; existing.GioiTinh = item.GioiTinh;
                    existing.NgaySinh = item.NgaySinh; existing.DiaChi = item.DiaChi;
                    existing.SoDienThoai = item.SoDienThoai; existing.ChucVu = item.ChucVu;
                    return true;
                }
                error = "Không tìm thấy!";
                return false;
            }
        }

        public bool Delete(string maNV, out string error)
        {
            error = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    var existing = db.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
                    if (existing == null) { error = "Không tìm thấy!"; return false; }
                    db.NhanViens.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                var existing = _offline.FirstOrDefault(x => x.MaNV == maNV);
                if (existing != null) { _offline.Remove(existing); return true; }
                error = "Không tìm thấy!";
                return false;
            }
        }
    }
}
