using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBanHangOnline.WinForms.DataContext;

namespace QuanLyBanHangOnline.WinForms.Repositories
{
    public class PermissionItemViewModel
    {
        public string MaChucNang { get; set; }
        public string TenChucNang { get; set; }
        public string MoTa { get; set; }
        public bool CoQuyen { get; set; }
    }

    public class PhanQuyenRepository
    {
        public List<VaiTro> GetAllRoles()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.VaiTros.OrderBy(r => r.MaVaiTro).ToList();
                }
            }
            catch
            {
                return new List<VaiTro>
                {
                    new VaiTro { MaVaiTro = "ADMIN", TenVaiTro = "Quản trị hệ thống", MoTa = "Toàn quyền quản trị" },
                    new VaiTro { MaVaiTro = "QUANLY", TenVaiTro = "Quản lý bán hàng", MoTa = "Quản lý hàng hóa, đơn hàng" },
                    new VaiTro { MaVaiTro = "NHANVIEN", TenVaiTro = "Nhân viên bán hàng", MoTa = "Bán hàng và xử lý đơn" }
                };
            }
        }

        public List<ChucNang> GetAllFunctions()
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    return db.ChucNangs.OrderBy(c => c.MaChucNang).ToList();
                }
            }
            catch
            {
                return new List<ChucNang>
                {
                    new ChucNang { MaChucNang = "FN_DASHBOARD", TenChucNang = "Xem Dashboard", MoTa = "Tổng quan" },
                    new ChucNang { MaChucNang = "FN_HANGHOA", TenChucNang = "Quản lý Hàng hóa", MoTa = "Hàng hóa" },
                    new ChucNang { MaChucNang = "FN_LOAIHANG", TenChucNang = "Quản lý Loại hàng", MoTa = "Loại hàng" },
                    new ChucNang { MaChucNang = "FN_NHASANXUAT", TenChucNang = "Quản lý Nhà SX", MoTa = "Nhà SX" },
                    new ChucNang { MaChucNang = "FN_KHACHHANG", TenChucNang = "Quản lý Khách hàng", MoTa = "Khách hàng" },
                    new ChucNang { MaChucNang = "FN_NHANVIEN", TenChucNang = "Quản lý Nhân viên", MoTa = "Nhân viên" },
                    new ChucNang { MaChucNang = "FN_DATHANG", TenChucNang = "Đặt hàng online", MoTa = "Tạo đơn hàng" },
                    new ChucNang { MaChucNang = "FN_XULYDONHANG", TenChucNang = "Xử lý đơn (FIFO)", MoTa = "Duyệt đơn hàng" },
                    new ChucNang { MaChucNang = "FN_TRACUU", TenChucNang = "Tra cứu hàng hóa", MoTa = "Tìm kiếm" },
                    new ChucNang { MaChucNang = "FN_THONGKE", TenChucNang = "Thống kê Doanh thu", MoTa = "Thống kê" },
                    new ChucNang { MaChucNang = "FN_BAOCAO_DONHANG", TenChucNang = "Báo cáo Đơn hàng", MoTa = "In ấn báo cáo" },
                    new ChucNang { MaChucNang = "FN_BAOCAO_TONKHO", TenChucNang = "Báo cáo Tồn kho", MoTa = "Cảnh báo tồn kho" },
                    new ChucNang { MaChucNang = "FN_USER_MANAGE", TenChucNang = "Quản lý Tài khoản", MoTa = "Người dùng" },
                    new ChucNang { MaChucNang = "FN_ROLE_MANAGE", TenChucNang = "Quản lý Phân quyền", MoTa = "Phân quyền" }
                };
            }
        }

        public List<PermissionItemViewModel> GetPermissionsMatrix(string maVaiTro)
        {
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    // LINQ Left Join giữa ChucNang và PhanQuyen
                    var query = from c in db.ChucNangs
                                join p in db.PhanQuyens.Where(x => x.MaVaiTro == maVaiTro)
                                on c.MaChucNang equals p.MaChucNang into pGroup
                                from p in pGroup.DefaultIfEmpty()
                                orderby c.MaChucNang
                                select new PermissionItemViewModel
                                {
                                    MaChucNang = c.MaChucNang,
                                    TenChucNang = c.TenChucNang,
                                    MoTa = c.MoTa,
                                    CoQuyen = p != null && p.CoQuyen
                                };
                    return query.ToList();
                }
            }
            catch
            {
                var list = GetAllFunctions();
                return list.Select(f => new PermissionItemViewModel
                {
                    MaChucNang = f.MaChucNang,
                    TenChucNang = f.TenChucNang,
                    MoTa = f.MoTa,
                    CoQuyen = maVaiTro == "ADMIN" || f.MaChucNang.StartsWith("FN_DAT") || f.MaChucNang.StartsWith("FN_TRA")
                }).ToList();
            }
        }

        public List<string> GetAllowedFunctionCodes(string maVaiTro)
        {
            if (maVaiTro == "ADMIN")
            {
                return GetAllFunctions().Select(f => f.MaChucNang).ToList();
            }

            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    // LINQ Query Where CoQuyen == true
                    return (from p in db.PhanQuyens
                            where p.MaVaiTro == maVaiTro && p.CoQuyen
                            select p.MaChucNang).ToList();
                }
            }
            catch
            {
                if (maVaiTro == "QUANLY")
                {
                    return new List<string> {
                        "FN_DASHBOARD", "FN_HANGHOA", "FN_LOAIHANG", "FN_NHASANXUAT", "FN_KHACHHANG", "FN_NHANVIEN",
                        "FN_DATHANG", "FN_XULYDONHANG", "FN_TRACUU", "FN_THONGKE", "FN_BAOCAO_DONHANG", "FN_BAOCAO_TONKHO"
                    };
                }
                else if (maVaiTro == "NHANVIEN")
                {
                    return new List<string> {
                        "FN_DASHBOARD", "FN_KHACHHANG", "FN_DATHANG", "FN_XULYDONHANG", "FN_TRACUU", "FN_BAOCAO_DONHANG"
                    };
                }
                return new List<string> { "FN_DASHBOARD", "FN_DATHANG", "FN_TRACUU", "FN_XULYDONHANG" };
            }
        }

        public bool SavePermissions(string maVaiTro, Dictionary<string, bool> permissionStates, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = DbContextHelper.GetContext())
                {
                    foreach (var kvp in permissionStates)
                    {
                        string maChucNang = kvp.Key;
                        bool coQuyen = kvp.Value;

                        var existing = db.PhanQuyens.FirstOrDefault(p => p.MaVaiTro == maVaiTro && p.MaChucNang == maChucNang);
                        if (existing != null)
                        {
                            existing.CoQuyen = coQuyen;
                        }
                        else
                        {
                            db.PhanQuyens.InsertOnSubmit(new PhanQuyen
                            {
                                MaVaiTro = maVaiTro,
                                MaChucNang = maChucNang,
                                CoQuyen = coQuyen
                            });
                        }
                    }
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
