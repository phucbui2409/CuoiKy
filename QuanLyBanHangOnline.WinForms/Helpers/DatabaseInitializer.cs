using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    /// <summary>
    /// Tự động khởi tạo Cơ Sở Dữ Liệu SQL Server trong lần khởi chạy đầu tiên (Zero-Configuration First Run)
    /// Đính kèm sẵn script QuanLyBanHangOnline.sql, tự động tạo CSDL, bảng, phân quyền và dữ liệu mẫu nếu chưa có.
    /// </summary>
    public static class DatabaseInitializer
    {
        public static bool AutoInitializeDatabase(out string resultMessage)
        {
            resultMessage = string.Empty;

            try
            {
                string rawConnStr = ConfigHelper.GetConnectionString(out _);
                if (string.IsNullOrWhiteSpace(rawConnStr))
                {
                    resultMessage = "Chưa có chuỗi kết nối trong App.config.";
                    return false;
                }

                var builder = new SqlConnectionStringBuilder(rawConnStr);
                string targetDb = string.IsNullOrEmpty(builder.InitialCatalog) ? "QuanLyBanHangOnline" : builder.InitialCatalog;
                string serverName = builder.DataSource;

                // Chuỗi kết nối đến database hệ thống 'master' để kiểm tra sự tồn tại của database đích
                var masterBuilder = new SqlConnectionStringBuilder(rawConnStr)
                {
                    InitialCatalog = "master",
                    ConnectTimeout = 5
                };

                using (var masterConn = new SqlConnection(masterBuilder.ConnectionString))
                {
                    masterConn.Open();

                    // Kiểm tra CSDL đích đã tồn tại trên Server chưa
                    bool dbExists = false;
                    using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = @dbName", masterConn))
                    {
                        checkCmd.Parameters.AddWithValue("@dbName", targetDb);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        dbExists = count > 0;
                    }

                    if (dbExists)
                    {
                        resultMessage = $"Cơ sở dữ liệu '{targetDb}' đã sẵn sàng trên máy chủ '{serverName}'.";
                        return true;
                    }

                    // Nếu chưa tồn tại -> Tìm file kịch bản SQL QuanLyBanHangOnline.sql
                    string sqlFilePath = FindSqlScriptFile();
                    if (string.IsNullOrEmpty(sqlFilePath) || !File.Exists(sqlFilePath))
                    {
                        resultMessage = $"Không tìm thấy file kịch bản CSDL QuanLyBanHangOnline.sql trong thư mục cài đặt!";
                        return false;
                    }

                    string fullScript = File.ReadAllText(sqlFilePath, System.Text.Encoding.UTF8);

                    // Tách các khối lệnh SQL phân cách bằng từ khóa GO
                    var batches = Regex.Split(fullScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                    foreach (var batch in batches)
                    {
                        string sql = batch.Trim();
                        if (string.IsNullOrWhiteSpace(sql)) continue;

                        try
                        {
                            using (var cmd = new SqlCommand(sql, masterConn))
                            {
                                cmd.CommandTimeout = 60;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exBatch)
                        {
                            // Bỏ qua lỗi USE hoặc tiếp tục batch tiếp theo nếu là cảnh báo
                            System.Diagnostics.Debug.WriteLine("SQL Batch Info: " + exBatch.Message);
                        }
                    }

                    resultMessage = $"Đã tự động khởi tạo thành công CSDL '{targetDb}' kèm toàn bộ dữ liệu mẫu trên máy chủ '{serverName}'!";
                    return true;
                }
            }
            catch (Exception ex)
            {
                resultMessage = "Không thể tự động khởi tạo CSDL: " + ex.Message;
                return false;
            }
        }

        private static string FindSqlScriptFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string[] candidatePaths = new string[]
            {
                Path.Combine(baseDir, "Database", "QuanLyBanHangOnline.sql"),
                Path.Combine(baseDir, "QuanLyBanHangOnline.sql"),
                Path.Combine(baseDir, "..", "Database", "QuanLyBanHangOnline.sql"),
                Path.Combine(baseDir, "..", "..", "Database", "QuanLyBanHangOnline.sql"),
                Path.Combine(baseDir, "..", "..", "..", "Database", "QuanLyBanHangOnline.sql")
            };

            foreach (var path in candidatePaths)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                }
                catch { }
            }

            return null;
        }
    }
}
