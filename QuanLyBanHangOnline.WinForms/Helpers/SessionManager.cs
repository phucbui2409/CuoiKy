using System.Collections.Generic;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    public class UserSessionInfo
    {
        public int MaND { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }
    }

    public static class SessionManager
    {
        public static UserSessionInfo CurrentUser { get; set; }
        public static HashSet<string> Permissions { get; set; } = new HashSet<string>();

        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetSession(UserSessionInfo user, IEnumerable<string> allowedFunctions)
        {
            CurrentUser = user;
            Permissions = new HashSet<string>(allowedFunctions ?? new string[0]);
        }

        public static void ClearSession()
        {
            CurrentUser = null;
            Permissions.Clear();
        }

        public static bool HasPermission(string functionCode)
        {
            if (CurrentUser == null) return false;
            // Admin có quyền truy cập tất cả
            if (CurrentUser.MaVaiTro == "ADMIN") return true;

            return Permissions.Contains(functionCode);
        }
    }
}
