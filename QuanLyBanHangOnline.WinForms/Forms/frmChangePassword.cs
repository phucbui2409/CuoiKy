using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmChangePassword : System.Windows.Forms.Form
    {
        private readonly NguoiDungRepository _userRepo = new NguoiDungRepository();

        public frmChangePassword()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            char pChar = chkShowPass.Checked ? '\0' : '●';
            txtOldPass.PasswordChar = pChar;
            txtNewPass.PasswordChar = pChar;
            txtConfirmPass.PasswordChar = pChar;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Phiên làm việc đã hết hạn. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrEmpty(oldPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có tối thiểu 6 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không trùng khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPass.Focus();
                return;
            }

            bool success = _userRepo.ChangePassword(SessionManager.CurrentUser.MaND, oldPass, newPass, out string err);
            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công! Mật khẩu mới đã được mã hóa an toàn.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
