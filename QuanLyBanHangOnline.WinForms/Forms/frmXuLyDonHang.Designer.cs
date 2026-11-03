namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmXuLyDonHang : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpOrders;
        private System.Windows.Forms.DataGridView dgvPendingOrders;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Button btnProcessFIFO;
        private System.Windows.Forms.Button btnProcessSelected;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPendingCount;

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
            this.grpOrders = new System.Windows.Forms.GroupBox();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.dgvPendingOrders = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnProcessFIFO = new System.Windows.Forms.Button();
            this.btnProcessSelected = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).BeginInit();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1060, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1060, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "XỬ LÝ ĐƠN HÀNG THEO NGUYÊN TẮC FIFO (ĐẶT TRƯỚC XỬ LÝ TRƯỚC)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpOrders
            // 
            this.grpOrders.Controls.Add(this.lblPendingCount);
            this.grpOrders.Controls.Add(this.dgvPendingOrders);
            this.grpOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpOrders.Location = new System.Drawing.Point(20, 75);
            this.grpOrders.Name = "grpOrders";
            this.grpOrders.Size = new System.Drawing.Size(1020, 260);
            this.grpOrders.TabIndex = 1;
            this.grpOrders.TabStop = false;
            this.grpOrders.Text = "Danh Sách Đơn Hàng Đang Chờ Xử Lý (Sắp Xếp Theo Thời Gian Đặt - FIFO)";
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblPendingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblPendingCount.Location = new System.Drawing.Point(680, 0);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(185, 17);
            this.lblPendingCount.TabIndex = 1;
            this.lblPendingCount.Text = "Đang chờ: 0 đơn cần xử lý";
            // 
            // dgvPendingOrders
            // 
            this.dgvPendingOrders.AllowUserToAddRows = false;
            this.dgvPendingOrders.AllowUserToDeleteRows = false;
            this.dgvPendingOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendingOrders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingOrders.Location = new System.Drawing.Point(15, 25);
            this.dgvPendingOrders.MultiSelect = false;
            this.dgvPendingOrders.Name = "dgvPendingOrders";
            this.dgvPendingOrders.ReadOnly = true;
            this.dgvPendingOrders.RowHeadersVisible = false;
            this.dgvPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingOrders.Size = new System.Drawing.Size(990, 220);
            this.dgvPendingOrders.TabIndex = 0;
            this.dgvPendingOrders.SelectionChanged += new System.EventHandler(this.dgvPendingOrders_SelectionChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.dgvOrderDetails);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetails.Location = new System.Drawing.Point(20, 350);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1020, 240);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Chi Tiết Các Mặt Hàng Trong Đơn Đang Chọn";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(15, 25);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersVisible = false;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(990, 200);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // btnProcessFIFO
            // 
            this.btnProcessFIFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnProcessFIFO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessFIFO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessFIFO.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnProcessFIFO.ForeColor = System.Drawing.Color.White;
            this.btnProcessFIFO.Location = new System.Drawing.Point(20, 608);
            this.btnProcessFIFO.Name = "btnProcessFIFO";
            this.btnProcessFIFO.Size = new System.Drawing.Size(320, 44);
            this.btnProcessFIFO.TabIndex = 3;
            this.btnProcessFIFO.Text = "⚡ XỬ LÝ ĐƠN ĐẶT ĐẦU TIÊN (FIFO)";
            this.btnProcessFIFO.UseVisualStyleBackColor = false;
            this.btnProcessFIFO.Click += new System.EventHandler(this.btnProcessFIFO_Click);
            // 
            // btnProcessSelected
            // 
            this.btnProcessSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnProcessSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessSelected.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessSelected.ForeColor = System.Drawing.Color.White;
            this.btnProcessSelected.Location = new System.Drawing.Point(360, 608);
            this.btnProcessSelected.Name = "btnProcessSelected";
            this.btnProcessSelected.Size = new System.Drawing.Size(210, 44);
            this.btnProcessSelected.TabIndex = 4;
            this.btnProcessSelected.Text = "Duyệt Đơn Đang Chọn";
            this.btnProcessSelected.UseVisualStyleBackColor = false;
            this.btnProcessSelected.Click += new System.EventHandler(this.btnProcessSelected_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnCancelOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(590, 608);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(150, 44);
            this.btnCancelOrder.TabIndex = 5;
            this.btnCancelOrder.Text = "Hủy Đơn";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(760, 608);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 44);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(910, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 44);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmXuLyDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 675);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnProcessSelected);
            this.Controls.Add(this.btnProcessFIFO);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpOrders);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmXuLyDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử lý đơn hàng FIFO";
            this.Load += new System.EventHandler(this.frmXuLyDonHang_Load);
            this.panelTop.ResumeLayout(false);
            this.grpOrders.ResumeLayout(false);
            this.grpOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).EndInit();
            this.grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
