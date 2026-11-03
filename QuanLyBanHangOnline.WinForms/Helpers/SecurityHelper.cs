using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    public static class SecurityHelper
    {
        // Sinh chuỗi muối (Salt) ngẫu nhiên
        public static string GenerateSalt(int size = 16)
        {
            byte[] saltBytes = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Băm mật khẩu bằng SHA-256 kết hợp Salt
        // Hash = SHA256(Password + Salt)
        public static string HashPassword(string password, string salt)
        {
            if (password == null) password = string.Empty;
            if (salt == null) salt = string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                string combined = password + salt;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Kiểm tra mật khẩu người dùng nhập có khớp với hash trong DB không
        public static bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)
        {
            string computedHash = HashPassword(inputPassword, storedSalt);
            return string.Equals(computedHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
