namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmXemBaoCaoDoanhThuReport
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

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
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1034, 711);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmXemBaoCaoDoanhThuReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmXemBaoCaoDoanhThuReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Doanh Thu Bán Hàng - Microsoft ReportViewer";
            this.Load += new System.EventHandler(this.frmXemBaoCaoDoanhThuReport_Load);
            this.ResumeLayout(false);

        }
    }
}
