using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmLogin : System.Windows.Forms.Form
    {
        private int _failedAttempts = 0;
        private const int MAX_ATTEMPTS = 3;
        private readonly NguoiDungRepository _userRepo = new NguoiDungRepository();
        private readonly PhanQuyenRepository _roleRepo = new PhanQuyenRepository();

        public frmLogin()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối CSDL và tự động nhắc cấu hình nếu đổi máy chạy demo
            KiemTraKetNoiVaGoiYConfig();
        }

        private void KiemTraKetNoiVaGoiYConfig()
        {
            if (!DbContextHelper.IsDatabaseAvailable)
            {
                var ask = MessageBox.Show(
                    "Hệ thống phát hiện hiện tại KHÔNG THỂ kết nối đến Cơ Sở Dữ Liệu SQL Server theo cấu hình trong App.config.\n\n" +
                    "• Có thể do bạn vừa ĐỔI MÁY CHẠY DEMO hoặc máy chưa khởi động dịch vụ SQL Server.\n\n" +
                    "Bạn có muốn mở màn hình 'Cấu hình kết nối SQL (App.config)' để thiết lập lại máy chủ không?",
                    "Cảnh báo kết nối CSDL (Đổi máy demo)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (ask == DialogResult.Yes)
                {
                    using (var fConfig = new frmConnectionConfig())
                    {
                        if (fConfig.ShowDialog(this) == DialogResult.OK)
                        {
                            DbContextHelper.ReloadConfiguration();
                        }
                    }
                }
            }
        }

        private void lnkConfigConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var fConfig = new frmConnectionConfig())
            {
                if (fConfig.ShowDialog(this) == DialogResult.OK)
                {
                    DbContextHelper.ReloadConfiguration();
                }
            }
        }

        private void toggleShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = toggleShowPassword.Checked ? '\0' : '●';
        }

        private void lblShowPassword_Click(object sender, EventArgs e)
        {
            toggleShowPassword.Checked = !toggleShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ThucHienDangNhap();
        }

        private void ThucHienDangNhap()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var sessionUser = _userRepo.Authenticate(username, password, out string errorMessage);

            if (sessionUser != null)
            {
                // Lấy danh sách quyền chức năng cho vai trò của user
                var allowedFunctions = _roleRepo.GetAllowedFunctionCodes(sessionUser.MaVaiTro);
                SessionManager.SetSession(sessionUser, allowedFunctions);

                MessageBox.Show($"Đăng nhập thành công!\nXin chào {sessionUser.HoTen} ({sessionUser.TenVaiTro})",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var fMain = new frmMain();
                fMain.FormClosed += (s, args) => this.Close();
                fMain.Show();
            }
            else
            {
                _failedAttempts++;
                int remaining = MAX_ATTEMPTS - _failedAttempts;

                if (_failedAttempts >= MAX_ATTEMPTS)
                {
                    MessageBox.Show("Bạn đã nhập sai thông tin đăng nhập quá 3 lần liên tiếp!\nHệ thống sẽ tự động thoát.",
                                    "Khóa truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"{errorMessage}\nBạn còn {remaining} lần thử lại.",
                                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    lblAttempts.Text = $"Đã nhập sai {_failedAttempts}/{MAX_ATTEMPTS} lần.";
                    lblAttempts.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var forgotForm = new frmForgotPassword())
            {
                if (forgotForm.ShowDialog() == DialogResult.OK)
                {
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }
}
