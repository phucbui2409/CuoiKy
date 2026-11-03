namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmForgotPassword
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserPrompt;
        private System.Windows.Forms.TextBox txtUsernameOrEmail;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnSendOtp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpReset;
        private System.Windows.Forms.Label lblOtp;
        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnConfirmReset;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnCancel;
        private System.Windows.Forms.Label lblOtpNotice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUserPrompt = new System.Windows.Forms.Label();
            this.txtUsernameOrEmail = new System.Windows.Forms.TextBox();
            this.btnSendOtp = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpReset = new System.Windows.Forms.GroupBox();
            this.lblOtpNotice = new System.Windows.Forms.Label();
            this.btnConfirmReset = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.lblOtp = new System.Windows.Forms.Label();
            this.btnCancel = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.pnlTop.SuspendLayout();
            this.grpReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(520, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUÊN MẬT KHẨU / XÁC THỰC OTP QUA EMAIL";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserPrompt
            // 
            this.lblUserPrompt.AutoSize = true;
            this.lblUserPrompt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblUserPrompt.Location = new System.Drawing.Point(25, 75);
            this.lblUserPrompt.Name = "lblUserPrompt";
            this.lblUserPrompt.Size = new System.Drawing.Size(186, 17);
            this.lblUserPrompt.TabIndex = 1;
            this.lblUserPrompt.Text = "Tên đăng nhập hoặc Email:";
            // 
            // txtUsernameOrEmail
            // 
            this.txtUsernameOrEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsernameOrEmail.Location = new System.Drawing.Point(28, 98);
            this.txtUsernameOrEmail.Name = "txtUsernameOrEmail";
            this.txtUsernameOrEmail.Size = new System.Drawing.Size(315, 26);
            this.txtUsernameOrEmail.TabIndex = 2;
            // 
            // btnSendOtp
            // 
            this.btnSendOtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSendOtp.BorderRadius = 6;
            this.btnSendOtp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendOtp.FlatAppearance.BorderSize = 0;
            this.btnSendOtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOtp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendOtp.ForeColor = System.Drawing.Color.White;
            this.btnSendOtp.Location = new System.Drawing.Point(355, 96);
            this.btnSendOtp.Name = "btnSendOtp";
            this.btnSendOtp.Size = new System.Drawing.Size(135, 30);
            this.btnSendOtp.TabIndex = 3;
            this.btnSendOtp.Text = "📧 Gửi mã OTP";
            this.btnSendOtp.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStatus.Location = new System.Drawing.Point(25, 132);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(465, 35);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Nhập tài khoản hoặc email của bạn rồi bấm \"Gửi mã OTP\". Hệ thống sẽ gửi mã xác thực qua hòm thư Gmail.";
            // 
            // grpReset
            // 
            this.grpReset.Controls.Add(this.lblOtpNotice);
            this.grpReset.Controls.Add(this.btnConfirmReset);
            this.grpReset.Controls.Add(this.txtConfirmPass);
            this.grpReset.Controls.Add(this.lblConfirmPass);
            this.grpReset.Controls.Add(this.txtNewPass);
            this.grpReset.Controls.Add(this.lblNewPass);
            this.grpReset.Controls.Add(this.txtOtp);
            this.grpReset.Controls.Add(this.lblOtp);
            this.grpReset.Enabled = false;
            this.grpReset.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpReset.Location = new System.Drawing.Point(28, 175);
            this.grpReset.Name = "grpReset";
            this.grpReset.Size = new System.Drawing.Size(465, 230);
            this.grpReset.TabIndex = 5;
            this.grpReset.TabStop = false;
            this.grpReset.Text = "Xác thực & Thiết lập mật khẩu mới:";
            // 
            // lblOtpNotice
            // 
            this.lblOtpNotice.AutoSize = true;
            this.lblOtpNotice.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular);
            this.lblOtpNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOtpNotice.Location = new System.Drawing.Point(310, 35);
            this.lblOtpNotice.Name = "lblOtpNotice";
            this.lblOtpNotice.Size = new System.Drawing.Size(126, 15);
            this.lblOtpNotice.TabIndex = 2;
            this.lblOtpNotice.Text = "(Mã 6 số gồm số 0-9)";
            // 
            // btnConfirmReset
            // 
            this.btnConfirmReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnConfirmReset.BorderRadius = 6;
            this.btnConfirmReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmReset.FlatAppearance.BorderSize = 0;
            this.btnConfirmReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmReset.ForeColor = System.Drawing.Color.White;
            this.btnConfirmReset.Location = new System.Drawing.Point(155, 175);
            this.btnConfirmReset.Name = "btnConfirmReset";
            this.btnConfirmReset.Size = new System.Drawing.Size(195, 38);
            this.btnConfirmReset.TabIndex = 7;
            this.btnConfirmReset.Text = "✔ Đặt lại Mật khẩu";
            this.btnConfirmReset.UseVisualStyleBackColor = false;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtConfirmPass.Location = new System.Drawing.Point(155, 125);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(280, 26);
            this.txtConfirmPass.TabIndex = 6;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPass.Location = new System.Drawing.Point(20, 131);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(107, 15);
            this.lblConfirmPass.TabIndex = 5;
            this.lblConfirmPass.Text = "Nhập lại mật khẩu:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNewPass.Location = new System.Drawing.Point(155, 78);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(280, 26);
            this.txtNewPass.TabIndex = 4;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPass.Location = new System.Drawing.Point(20, 84);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(84, 15);
            this.lblNewPass.TabIndex = 3;
            this.lblNewPass.Text = "Mật khẩu mới:";
            // 
            // txtOtp
            // 
            this.txtOtp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtOtp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.txtOtp.Location = new System.Drawing.Point(155, 30);
            this.txtOtp.MaxLength = 6;
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(140, 29);
            this.txtOtp.TabIndex = 1;
            this.txtOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOtp
            // 
            this.lblOtp.AutoSize = true;
            this.lblOtp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOtp.Location = new System.Drawing.Point(20, 37);
            this.lblOtp.Name = "lblOtp";
            this.lblOtp.Size = new System.Drawing.Size(103, 15);
            this.lblOtp.TabIndex = 0;
            this.lblOtp.Text = "Mã xác thực OTP:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(190, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Quay lại Đăng nhập";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 475);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpReset);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSendOtp);
            this.Controls.Add(this.txtUsernameOrEmail);
            this.Controls.Add(this.lblUserPrompt);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu - Xác thực OTP";
            this.pnlTop.ResumeLayout(false);
            this.grpReset.ResumeLayout(false);
            this.grpReset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
