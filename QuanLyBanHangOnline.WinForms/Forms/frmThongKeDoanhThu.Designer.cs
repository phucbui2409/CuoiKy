namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmThongKeDoanhThu : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpDateFilter;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblTotalOrdersTitle;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.GroupBox grpDailyRevenue;
        private System.Windows.Forms.DataGridView dgvDailyRevenue;
        private System.Windows.Forms.GroupBox grpTopProducts;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

                #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpDateFilter = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblTotalOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.grpDailyRevenue = new System.Windows.Forms.GroupBox();
            this.dgvDailyRevenue = new System.Windows.Forms.DataGridView();
            this.grpTopProducts = new System.Windows.Forms.GroupBox();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpDateFilter.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.grpDailyRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyRevenue)).BeginInit();
            this.grpTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1080, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ DOANH THU & TOP SẢN PHẨM BÁN CHẠY (LINQ)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDateFilter
            // 
            this.grpDateFilter.Controls.Add(this.btnFilter);
            this.grpDateFilter.Controls.Add(this.dtpToDate);
            this.grpDateFilter.Controls.Add(this.lblToDate);
            this.grpDateFilter.Controls.Add(this.dtpFromDate);
            this.grpDateFilter.Controls.Add(this.lblFromDate);
            this.grpDateFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDateFilter.Location = new System.Drawing.Point(20, 75);
            this.grpDateFilter.Name = "grpDateFilter";
            this.grpDateFilter.Size = new System.Drawing.Size(580, 80);
            this.grpDateFilter.TabIndex = 1;
            this.grpDateFilter.TabStop = false;
            this.grpDateFilter.Text = "Chọn Khoảng Thời Gian";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(455, 25);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(110, 38);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "📊 Thống Kê";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(305, 30);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(130, 24);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblToDate.Location = new System.Drawing.Point(230, 33);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(66, 17);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(85, 30);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(130, 24);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFromDate.Location = new System.Drawing.Point(15, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(58, 17);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblTotalOrdersValue);
            this.pnlSummary.Controls.Add(this.lblTotalOrdersTitle);
            this.pnlSummary.Controls.Add(this.lblTotalRevenueValue);
            this.pnlSummary.Controls.Add(this.lblTotalRevenueTitle);
            this.pnlSummary.Location = new System.Drawing.Point(620, 75);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(440, 80);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.AutoSize = true;
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(260, 38);
            this.lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(63, 25);
            this.lblTotalOrdersValue.TabIndex = 3;
            this.lblTotalOrdersValue.Text = "0 đơn";
            // 
            // lblTotalOrdersTitle
            // 
            this.lblTotalOrdersTitle.AutoSize = true;
            this.lblTotalOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(260, 12);
            this.lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            this.lblTotalOrdersTitle.Size = new System.Drawing.Size(95, 19);
            this.lblTotalOrdersTitle.TabIndex = 2;
            this.lblTotalOrdersTitle.Text = "Tổng số đơn:";
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.AutoSize = true;
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(15, 38);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(73, 25);
            this.lblTotalRevenueValue.TabIndex = 1;
            this.lblTotalRevenueValue.Text = "0 VNĐ";
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(120, 19);
            this.lblTotalRevenueTitle.TabIndex = 0;
            this.lblTotalRevenueTitle.Text = "Tổng Doanh Thu:";
            // 
            // grpDailyRevenue
            // 
            this.grpDailyRevenue.Controls.Add(this.dgvDailyRevenue);
            this.grpDailyRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDailyRevenue.Location = new System.Drawing.Point(20, 170);
            this.grpDailyRevenue.Name = "grpDailyRevenue";
            this.grpDailyRevenue.Size = new System.Drawing.Size(510, 435);
            this.grpDailyRevenue.TabIndex = 3;
            this.grpDailyRevenue.TabStop = false;
            this.grpDailyRevenue.Text = "Doanh Thu Theo Từng Ngày (LINQ GroupBy & Sum)";
            // 
            // dgvDailyRevenue
            // 
            this.dgvDailyRevenue.AllowUserToAddRows = false;
            this.dgvDailyRevenue.AllowUserToDeleteRows = false;
            this.dgvDailyRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailyRevenue.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDailyRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyRevenue.Location = new System.Drawing.Point(15, 25);
            this.dgvDailyRevenue.MultiSelect = false;
            this.dgvDailyRevenue.Name = "dgvDailyRevenue";
            this.dgvDailyRevenue.ReadOnly = true;
            this.dgvDailyRevenue.RowHeadersVisible = false;
            this.dgvDailyRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailyRevenue.Size = new System.Drawing.Size(480, 395);
            this.dgvDailyRevenue.TabIndex = 0;
            // 
            // grpTopProducts
            // 
            this.grpTopProducts.Controls.Add(this.dgvTopProducts);
            this.grpTopProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTopProducts.Location = new System.Drawing.Point(550, 170);
            this.grpTopProducts.Name = "grpTopProducts";
            this.grpTopProducts.Size = new System.Drawing.Size(510, 435);
            this.grpTopProducts.TabIndex = 4;
            this.grpTopProducts.TabStop = false;
            this.grpTopProducts.Text = "Top 5 Sản Phẩm Bán Chạy Nhất (LINQ Take & OrderByDesc)";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Location = new System.Drawing.Point(15, 25);
            this.dgvTopProducts.MultiSelect = false;
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersVisible = false;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(480, 395);
            this.dgvTopProducts.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(920, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 42);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 680);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpTopProducts);
            this.Controls.Add(this.grpDailyRevenue);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.grpDateFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmThongKeDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            this.panelTop.ResumeLayout(false);
            this.grpDateFilter.ResumeLayout(false);
            this.grpDateFilter.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.grpDailyRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyRevenue)).EndInit();
            this.grpTopProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
