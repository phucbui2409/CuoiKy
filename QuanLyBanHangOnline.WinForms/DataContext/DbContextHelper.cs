using System;
using System.Data.SqlClient;
using QuanLyBanHangOnline.WinForms.Helpers;

namespace QuanLyBanHangOnline.WinForms.DataContext
{
    public static class DbContextHelper
    {
        private static string _connectionString;
        private static bool? _isDbAvailable = null;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigHelper.GetConnectionString(out _);
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                _isDbAvailable = null;
            }
        }

        public static void ReloadConfiguration()
        {
            _connectionString = null;
            _isDbAvailable = null;
        }

        // Kiểm tra nhanh kết nối CSDL và lưu cache để loại bỏ hoàn toàn delay
        public static bool IsDatabaseAvailable
        {
            get
            {
                if (!_isDbAvailable.HasValue)
                {
                    _isDbAvailable = CheckQuickConnection();
                }
                return _isDbAvailable.Value;
            }
            set => _isDbAvailable = value;
        }

        private static bool CheckQuickConnection()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static QuanLyBanHangDataContext GetContext()
        {
            if (!IsDatabaseAvailable)
            {
                throw new InvalidOperationException("Không thể kết nối đến SQL Server. Ứng dụng tự động kích hoạt chế độ dự phòng phản hồi tức thì.");
            }
            return new QuanLyBanHangDataContext(ConnectionString);
        }

        public static bool TestConnection(out string errorMessage)
        {
            return TestConnectionWith(ConnectionString, out errorMessage, out _);
        }

        public static bool TestConnectionWith(string connStr, out string errorMessage, out string serverVersion)
        {
            errorMessage = string.Empty;
            serverVersion = string.Empty;
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    serverVersion = conn.ServerVersion;
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
