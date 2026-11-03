using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;

namespace QuanLyBanHangOnline.WinForms
{
    static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng Windows Forms.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Nếu mở từ shortcut cấu hình với tham số --config
            if (args != null && args.Length > 0 && args[0].Equals("--config", StringComparison.OrdinalIgnoreCase))
            {
                Application.Run(new frmConnectionConfig());
                return;
            }

            // 2. Tự động kiểm tra và khởi tạo CSDL lần đầu (Auto-Database Initializer)
            // Nếu phát hiện CSDL QuanLyBanHangOnline chưa tồn tại trên máy chủ SQL, tự động chạy script tạo DB
            DatabaseInitializer.AutoInitializeDatabase(out _);

            // 3. Khởi chạy màn hình đăng nhập
            Application.Run(new frmLogin());
        }
    }
}
