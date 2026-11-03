using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmForgotPassword : Form
    {
        private readonly NguoiDungRepository _userRepo = new NguoiDungRepository();
        private string _currentOtp = string.Empty;
        private DateTime _otpExpireTime = DateTime.MinValue;
        private int _targetMaND = 0;
        private string _targetUsername = string.Empty;
        private string _targetEmail = string.Empty;

        public frmForgotPassword()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            btnSendOtp.Click += BtnSendOtp_Click;
            btnConfirmReset.Click += BtnConfirmReset_Click;
            btnCancel.Click += (s, e) => this.Close();

            txtUsernameOrEmail.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnSendOtp_Click(s, e);
                }
            };
        }

        private void BtnSendOtp_Click(object sender, EventArgs e)
        {
            string keyword = txtUsernameOrEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập hoặc Địa chỉ Email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsernameOrEmail.Focus();
                return;
            }

            // Tìm kiếm tài khoản
            bool found = _userRepo.FindUserForPasswordReset(keyword, out _targetMaND, out _targetUsername, out _targetEmail, out string errFind);
            if (!found)
            {
                MessageBox.Show(errFind, "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sinh mã OTP 6 số
            _currentOtp = EmailHelper.GenerateOtp(6);
            _otpExpireTime = DateTime.Now.AddMinutes(5); // Có hiệu lực 5 phút

            btnSendOtp.Enabled = false;
            btnSendOtp.Text = "Đang gửi...";
            this.Cursor = Cursors.WaitCursor;

            // Gửi email qua Gmail SMTP
            bool sent = EmailHelper.SendOtpEmail(_targetEmail, _targetUsername, _currentOtp, out string sendErr);
            this.Cursor = Cursors.Default;
            btnSendOtp.Enabled = true;
            btnSendOtp.Text = "📧 Gửi lại OTP";

            // Che bớt email để bảo mật thông tin
            string maskedEmail = MaskEmail(_targetEmail);

            if (sent)
            {
                lblStatus.Text = $"✔ Đã gửi mã OTP đến: {maskedEmail} (Hiệu lực trong 5 phút).\nNếu không thấy trong Hộp thư đến, vui lòng kiểm tra thư mục Spam/Rác.";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
                grpReset.Enabled = true;
                txtOtp.Focus();

                MessageBox.Show($"Mã xác thực OTP đã được gửi đến email:\n{maskedEmail}\n\n(Demo: Mã OTP của bạn là: {_currentOtp})",
                    "Đã gửi mã OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu chưa cấu hình mật khẩu ứng dụng Gmail, hiển thị chế độ mô phỏng an toàn
                lblStatus.Text = $"Mô phỏng gửi OTP đến: {maskedEmail} (Chi tiết: {sendErr})";
                lblStatus.ForeColor = Color.FromArgb(234, 88, 12);
                grpReset.Enabled = true;
                txtOtp.Focus();

                MessageBox.Show($"Hệ thống kích hoạt chế độ Demo OTP (do máy chạy demo chưa cấu hình Gmail App Password):\n\nMã OTP của bạn là: {_currentOtp}\nEmail nhận: {maskedEmail}",
                    "Mã xác thực OTP (Demo)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnConfirmReset_Click(object sender, EventArgs e)
        {
            string inputOtp = txtOtp.Text.Trim();
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(inputOtp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP đã nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtp.Focus();
                return;
            }

            if (DateTime.Now > _otpExpireTime)
            {
                MessageBox.Show("Mã OTP đã hết hiệu lực (quá 5 phút)! Vui lòng bấm 'Gửi lại OTP'.", "Hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inputOtp != _currentOtp)
            {
                MessageBox.Show("Mã OTP không chính xác! Vui lòng kiểm tra lại.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOtp.SelectAll();
                txtOtp.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có tối thiểu 6 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPass.Focus();
                return;
            }

            // Tiến hành cập nhật mật khẩu vào CSDL
            bool updated = _userRepo.ResetPassword(_targetMaND, newPass, out string updateErr);
            if (updated)
            {
                MessageBox.Show($"Đặt lại mật khẩu cho tài khoản '{_targetUsername}' thành công!\nBạn có thể đăng nhập bằng mật khẩu mới ngay bây giờ.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật mật khẩu: " + updateErr, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return email;

            int atIndex = email.IndexOf('@');
            string userPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex);

            if (userPart.Length <= 3)
                return userPart.Substring(0, 1) + "***" + domainPart;

            return userPart.Substring(0, 3) + "***" + domainPart;
        }
    }
}
