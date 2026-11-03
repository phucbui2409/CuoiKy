namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmScanBarcode
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.ComboBox cboCamera;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnStartCamera;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnStopCamera;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpManual;
        private System.Windows.Forms.TextBox txtManualCode;
        private System.Windows.Forms.Label lblManualPrompt;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnConfirmManual;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnBrowseImage;
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lblCamera = new System.Windows.Forms.Label();
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.btnStartCamera = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnStopCamera = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpManual = new System.Windows.Forms.GroupBox();
            this.lblManualPrompt = new System.Windows.Forms.Label();
            this.txtManualCode = new System.Windows.Forms.TextBox();
            this.btnConfirmManual = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnBrowseImage = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnClose = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.pnlTop.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.grpManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(680, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(680, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUÉT MÃ VẠCH (BARCODE) / QR CODE SẢN PHẨM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlControl.Controls.Add(this.lblCamera);
            this.pnlControl.Controls.Add(this.cboCamera);
            this.pnlControl.Controls.Add(this.btnStartCamera);
            this.pnlControl.Controls.Add(this.btnStopCamera);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 50);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(680, 50);
            this.pnlControl.TabIndex = 1;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCamera.Location = new System.Drawing.Point(16, 16);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(65, 17);
            this.lblCamera.TabIndex = 0;
            this.lblCamera.Text = "Webcam:";
            // 
            // cboCamera
            // 
            this.cboCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamera.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(87, 12);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(270, 25);
            this.cboCamera.TabIndex = 1;
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnStartCamera.BorderRadius = 6;
            this.btnStartCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartCamera.FlatAppearance.BorderSize = 0;
            this.btnStartCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartCamera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStartCamera.ForeColor = System.Drawing.Color.White;
            this.btnStartCamera.Location = new System.Drawing.Point(370, 10);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(130, 29);
            this.btnStartCamera.TabIndex = 2;
            this.btnStartCamera.Text = "▶ Bắt đầu Camera";
            this.btnStartCamera.UseVisualStyleBackColor = false;
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnStopCamera.BorderRadius = 6;
            this.btnStopCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopCamera.FlatAppearance.BorderSize = 0;
            this.btnStopCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopCamera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStopCamera.ForeColor = System.Drawing.Color.White;
            this.btnStopCamera.Location = new System.Drawing.Point(510, 10);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Size = new System.Drawing.Size(120, 29);
            this.btnStopCamera.TabIndex = 3;
            this.btnStopCamera.Text = "⏹ Dừng Camera";
            this.btnStopCamera.UseVisualStyleBackColor = false;
            // 
            // picCamera
            // 
            this.picCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.picCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamera.Location = new System.Drawing.Point(20, 115);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(640, 320);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera.TabIndex = 2;
            this.picCamera.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 442);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(640, 32);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "🔍 Hãy đưa mã vạch sản phẩm (Barcode hoặc QR) vào trước ống kính Webcam";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpManual
            // 
            this.grpManual.Controls.Add(this.btnBrowseImage);
            this.grpManual.Controls.Add(this.btnConfirmManual);
            this.grpManual.Controls.Add(this.txtManualCode);
            this.grpManual.Controls.Add(this.lblManualPrompt);
            this.grpManual.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpManual.Location = new System.Drawing.Point(20, 482);
            this.grpManual.Name = "grpManual";
            this.grpManual.Size = new System.Drawing.Size(640, 80);
            this.grpManual.TabIndex = 4;
            this.grpManual.TabStop = false;
            this.grpManual.Text = "Tùy chọn phụ (Không có webcam hoặc dùng file ảnh):";
            // 
            // lblManualPrompt
            // 
            this.lblManualPrompt.AutoSize = true;
            this.lblManualPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblManualPrompt.Location = new System.Drawing.Point(12, 34);
            this.lblManualPrompt.Name = "lblManualPrompt";
            this.lblManualPrompt.Size = new System.Drawing.Size(107, 15);
            this.lblManualPrompt.TabIndex = 0;
            this.lblManualPrompt.Text = "Nhập mã barcode:";
            // 
            // txtManualCode
            // 
            this.txtManualCode.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtManualCode.Location = new System.Drawing.Point(125, 29);
            this.txtManualCode.Name = "txtManualCode";
            this.txtManualCode.Size = new System.Drawing.Size(160, 26);
            this.txtManualCode.TabIndex = 1;
            // 
            // btnConfirmManual
            // 
            this.btnConfirmManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnConfirmManual.BorderRadius = 6;
            this.btnConfirmManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmManual.FlatAppearance.BorderSize = 0;
            this.btnConfirmManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmManual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirmManual.ForeColor = System.Drawing.Color.White;
            this.btnConfirmManual.Location = new System.Drawing.Point(295, 27);
            this.btnConfirmManual.Name = "btnConfirmManual";
            this.btnConfirmManual.Size = new System.Drawing.Size(140, 30);
            this.btnConfirmManual.TabIndex = 2;
            this.btnConfirmManual.Text = "✔ Xác nhận mã tay";
            this.btnConfirmManual.UseVisualStyleBackColor = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBrowseImage.BorderRadius = 6;
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.White;
            this.btnBrowseImage.Location = new System.Drawing.Point(450, 27);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(175, 30);
            this.btnBrowseImage.TabIndex = 3;
            this.btnBrowseImage.Text = "📁 Chọn file ảnh Barcode";
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClose.BorderRadius = 6;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(260, 572);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmScanBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 620);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpManual);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quét mã Barcode / QR Code";
            this.pnlTop.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.grpManual.ResumeLayout(false);
            this.grpManual.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
