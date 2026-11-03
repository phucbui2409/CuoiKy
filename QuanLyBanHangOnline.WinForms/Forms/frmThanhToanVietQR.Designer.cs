namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmThanhToanVietQR
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblGuide;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnRefreshQR;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnSaveQR;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnConfirmPaid;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnClose;

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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnRefreshQR = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblGuide = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnSaveQR = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnConfirmPaid = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnClose = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(780, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(780, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THANH TOÁN CHUYỂN KHOẢN QUA MÃ VIETQR (NAPAS 247)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.btnRefreshQR);
            this.pnlLeft.Controls.Add(this.txtMemo);
            this.pnlLeft.Controls.Add(this.lblMemo);
            this.pnlLeft.Controls.Add(this.lblAmountValue);
            this.pnlLeft.Controls.Add(this.lblAmount);
            this.pnlLeft.Controls.Add(this.txtAccountName);
            this.pnlLeft.Controls.Add(this.lblAccountName);
            this.pnlLeft.Controls.Add(this.txtAccountNo);
            this.pnlLeft.Controls.Add(this.lblAccountNo);
            this.pnlLeft.Controls.Add(this.cboBank);
            this.pnlLeft.Controls.Add(this.lblBank);
            this.pnlLeft.Controls.Add(this.lblOrderInfo);
            this.pnlLeft.Location = new System.Drawing.Point(20, 75);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(390, 420);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnRefreshQR
            // 
            this.btnRefreshQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnRefreshQR.BorderRadius = 6;
            this.btnRefreshQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshQR.FlatAppearance.BorderSize = 0;
            this.btnRefreshQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshQR.ForeColor = System.Drawing.Color.White;
            this.btnRefreshQR.Location = new System.Drawing.Point(20, 365);
            this.btnRefreshQR.Name = "btnRefreshQR";
            this.btnRefreshQR.Size = new System.Drawing.Size(350, 35);
            this.btnRefreshQR.TabIndex = 11;
            this.btnRefreshQR.Text = "🔄 Tạo Lại Mã VietQR";
            this.btnRefreshQR.UseVisualStyleBackColor = false;
            this.btnRefreshQR.Click += new System.EventHandler(this.btnRefreshQR_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMemo.Location = new System.Drawing.Point(20, 325);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(350, 29);
            this.txtMemo.TabIndex = 10;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMemo.Location = new System.Drawing.Point(20, 302);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(161, 20);
            this.lblMemo.TabIndex = 9;
            this.lblMemo.Text = "Nội dung chuyển tiền:";
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.AutoSize = true;
            this.lblAmountValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblAmountValue.Location = new System.Drawing.Point(20, 265);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(89, 32);
            this.lblAmountValue.TabIndex = 8;
            this.lblAmountValue.Text = "0 VND";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAmount.Location = new System.Drawing.Point(20, 242);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(166, 20);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "Số tiền cần thanh toán:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.txtAccountName.Location = new System.Drawing.Point(20, 205);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(350, 29);
            this.txtAccountName.TabIndex = 6;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAccountName.Location = new System.Drawing.Point(20, 182);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(130, 20);
            this.lblAccountName.TabIndex = 5;
            this.lblAccountName.Text = "Tên chủ tài khoản:";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtAccountNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtAccountNo.Location = new System.Drawing.Point(20, 145);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(350, 30);
            this.txtAccountNo.TabIndex = 4;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccountNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAccountNo.Location = new System.Drawing.Point(20, 122);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(99, 20);
            this.lblAccountNo.TabIndex = 3;
            this.lblAccountNo.Text = "Số tài khoản:";
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(20, 85);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(350, 29);
            this.cboBank.TabIndex = 2;
            this.cboBank.SelectedIndexChanged += new System.EventHandler(this.cboBank_SelectedIndexChanged);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblBank.Location = new System.Drawing.Point(20, 62);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(161, 20);
            this.lblBank.TabIndex = 1;
            this.lblBank.Text = "Ngân hàng thụ hưởng:";
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.AutoSize = true;
            this.lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblOrderInfo.Location = new System.Drawing.Point(18, 18);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(220, 25);
            this.lblOrderInfo.TabIndex = 0;
            this.lblOrderInfo.Text = "ĐƠN HÀNG #1001";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lblGuide);
            this.pnlRight.Controls.Add(this.picQR);
            this.pnlRight.Location = new System.Drawing.Point(430, 75);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(330, 420);
            this.pnlRight.TabIndex = 2;
            // 
            // lblGuide
            // 
            this.lblGuide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGuide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGuide.Location = new System.Drawing.Point(15, 335);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(300, 70);
            this.lblGuide.TabIndex = 1;
            this.lblGuide.Text = "Mở ứng dụng Ngân hàng (App Banking) bất kỳ hoặc Ví điện tử, chọn Quét mã QR để ch" +
    "uyển tiền chính xác số tiền.";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(15, 15);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(300, 310);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnSaveQR.BorderRadius = 6;
            this.btnSaveQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveQR.FlatAppearance.BorderSize = 0;
            this.btnSaveQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveQR.ForeColor = System.Drawing.Color.White;
            this.btnSaveQR.Location = new System.Drawing.Point(20, 510);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(180, 40);
            this.btnSaveQR.TabIndex = 3;
            this.btnSaveQR.Text = "💾 Lưu Ảnh Mã QR";
            this.btnSaveQR.UseVisualStyleBackColor = false;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // btnConfirmPaid
            // 
            this.btnConfirmPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnConfirmPaid.BorderRadius = 6;
            this.btnConfirmPaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPaid.FlatAppearance.BorderSize = 0;
            this.btnConfirmPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPaid.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPaid.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPaid.Location = new System.Drawing.Point(430, 510);
            this.btnConfirmPaid.Name = "btnConfirmPaid";
            this.btnConfirmPaid.Size = new System.Drawing.Size(210, 40);
            this.btnConfirmPaid.TabIndex = 4;
            this.btnConfirmPaid.Text = "✅ Xác Nhận Đã Nhận Tiền";
            this.btnConfirmPaid.UseVisualStyleBackColor = false;
            this.btnConfirmPaid.Click += new System.EventHandler(this.btnConfirmPaid_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnClose.BorderRadius = 6;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(650, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmThanhToanVietQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 570);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirmPaid);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmThanhToanVietQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán VietQR Napas 247";
            this.Load += new System.EventHandler(this.frmThanhToanVietQR_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
