namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmInHoaDonReport
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectOrder;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSendEmailInvoice;
        private System.Windows.Forms.Button btnClose;

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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectOrder = new System.Windows.Forms.Label();
            this.cboOrders = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSendEmailInvoice = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.btnSendEmailInvoice);
            this.pnlHeader.Controls.Add(this.btnLoad);
            this.pnlHeader.Controls.Add(this.cboOrders);
            this.pnlHeader.Controls.Add(this.lblSelectOrder);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1034, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "IN HÓA ĐƠN & XUẤT KHO";
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.AutoSize = true;
            this.lblSelectOrder.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectOrder.ForeColor = System.Drawing.Color.White;
            this.lblSelectOrder.Location = new System.Drawing.Point(285, 20);
            this.lblSelectOrder.Name = "lblSelectOrder";
            this.lblSelectOrder.Size = new System.Drawing.Size(100, 21);
            this.lblSelectOrder.TabIndex = 1;
            this.lblSelectOrder.Text = "Chọn đơn hàng:";
            // 
            // cboOrders
            // 
            this.cboOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrders.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboOrders.FormattingEnabled = true;
            this.cboOrders.Location = new System.Drawing.Point(390, 16);
            this.cboOrders.Name = "cboOrders";
            this.cboOrders.Size = new System.Drawing.Size(240, 29);
            this.cboOrders.TabIndex = 2;
            this.cboOrders.SelectedIndexChanged += new System.EventHandler(this.cboOrders_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))));
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(640, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 32);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Tải lại";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSendEmailInvoice
            // 
            this.btnSendEmailInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSendEmailInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendEmailInvoice.FlatAppearance.BorderSize = 0;
            this.btnSendEmailInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmailInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendEmailInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSendEmailInvoice.Location = new System.Drawing.Point(725, 14);
            this.btnSendEmailInvoice.Name = "btnSendEmailInvoice";
            this.btnSendEmailInvoice.Size = new System.Drawing.Size(185, 32);
            this.btnSendEmailInvoice.TabIndex = 4;
            this.btnSendEmailInvoice.Text = "📧 Gửi Email Hóa Đơn PDF";
            this.btnSendEmailInvoice.UseVisualStyleBackColor = false;
            this.btnSendEmailInvoice.Click += new System.EventHandler(this.btnSendEmailInvoice_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(920, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1034, 651);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmInHoaDonReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmInHoaDonReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Hóa Đơn & Phiếu Xuất Kho - Microsoft ReportViewer";
            this.Load += new System.EventHandler(this.frmInHoaDonReport_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
