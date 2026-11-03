namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmChartDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label lblCriterion;
        private System.Windows.Forms.ComboBox cboCriterion;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnFilter;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnPrintReport;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnExportExcel;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnClose;
        private System.Windows.Forms.Panel pnlKpi;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblTotalRevenue;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblTotalOrders;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblAvgOrder;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView pnlCard4;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblTotalProductsSold;
        
        // TabControl & Pages
        private System.Windows.Forms.TabControl tabCharts;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabLineChart;
        private System.Windows.Forms.TabPage tabColumnChart;
        private System.Windows.Forms.TabPage tabPieChart;
        private System.Windows.Forms.TabPage tabDetailsGrid;

        // Tab 1 Controls (Overview 3 Charts)
        private System.Windows.Forms.TableLayoutPanel tblOverview;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOverviewLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOverviewColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOverviewPie;

        // Tab 2 Controls (Detail Line Chart)
        private System.Windows.Forms.Panel pnlLineTop;
        private System.Windows.Forms.RadioButton radSpline;
        private System.Windows.Forms.RadioButton radLine;
        private System.Windows.Forms.Label lblLineDesc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDetailLine;

        // Tab 3 Controls (Detail Column Chart)
        private System.Windows.Forms.Panel pnlColumnTop;
        private System.Windows.Forms.RadioButton radColumn;
        private System.Windows.Forms.RadioButton radBar;
        private System.Windows.Forms.Label lblColumnDesc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDetailColumn;

        // Tab 4 Controls (Detail Pie Chart)
        private System.Windows.Forms.Panel pnlPieTop;
        private System.Windows.Forms.RadioButton radCategory;
        private System.Windows.Forms.RadioButton radStatus;
        private System.Windows.Forms.CheckBox chkDoughnut;
        private System.Windows.Forms.Label lblPieDesc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDetailPie;

        // Tab 5 Controls (Grid)
        private System.Windows.Forms.Panel pnlGridTop;
        private System.Windows.Forms.Label lblGridTitle;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernDataGridView dgvDetails;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea caOverLine = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legOverLine = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serOverLine = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titOverLine = new System.Windows.Forms.DataVisualization.Charting.Title();

            System.Windows.Forms.DataVisualization.Charting.ChartArea caOverCol = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legOverCol = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serOverCol = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titOverCol = new System.Windows.Forms.DataVisualization.Charting.Title();

            System.Windows.Forms.DataVisualization.Charting.ChartArea caOverPie = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legOverPie = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serOverPie = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titOverPie = new System.Windows.Forms.DataVisualization.Charting.Title();

            System.Windows.Forms.DataVisualization.Charting.ChartArea caDetLine = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legDetLine = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serDetLine = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titDetLine = new System.Windows.Forms.DataVisualization.Charting.Title();

            System.Windows.Forms.DataVisualization.Charting.ChartArea caDetCol = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legDetCol = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serDetCol = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titDetCol = new System.Windows.Forms.DataVisualization.Charting.Title();

            System.Windows.Forms.DataVisualization.Charting.ChartArea caDetPie = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legDetPie = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series serDetPie = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title titDetPie = new System.Windows.Forms.DataVisualization.Charting.Title();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.lblCriterion = new System.Windows.Forms.Label();
            this.cboCriterion = new System.Windows.Forms.ComboBox();
            this.btnFilter = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnPrintReport = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnExportExcel = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnClose = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();

            this.pnlKpi = new System.Windows.Forms.Panel();
            this.pnlCard1 = new QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.pnlCard2 = new QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.pnlCard3 = new QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblAvgOrder = new System.Windows.Forms.Label();
            this.pnlCard4 = new QuanLyBanHangOnline.WinForms.UIExtension.ModernCardView();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblTotalProductsSold = new System.Windows.Forms.Label();

            this.tabCharts = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.tabLineChart = new System.Windows.Forms.TabPage();
            this.tabColumnChart = new System.Windows.Forms.TabPage();
            this.tabPieChart = new System.Windows.Forms.TabPage();
            this.tabDetailsGrid = new System.Windows.Forms.TabPage();

            this.tblOverview = new System.Windows.Forms.TableLayoutPanel();
            this.chartOverviewLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOverviewColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOverviewPie = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlLineTop = new System.Windows.Forms.Panel();
            this.radSpline = new System.Windows.Forms.RadioButton();
            this.radLine = new System.Windows.Forms.RadioButton();
            this.lblLineDesc = new System.Windows.Forms.Label();
            this.chartDetailLine = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlColumnTop = new System.Windows.Forms.Panel();
            this.radColumn = new System.Windows.Forms.RadioButton();
            this.radBar = new System.Windows.Forms.RadioButton();
            this.lblColumnDesc = new System.Windows.Forms.Label();
            this.chartDetailColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlPieTop = new System.Windows.Forms.Panel();
            this.radCategory = new System.Windows.Forms.RadioButton();
            this.radStatus = new System.Windows.Forms.RadioButton();
            this.chkDoughnut = new System.Windows.Forms.CheckBox();
            this.lblPieDesc = new System.Windows.Forms.Label();
            this.chartDetailPie = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlGridTop = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvDetails = new QuanLyBanHangOnline.WinForms.UIExtension.ModernDataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabLineChart.SuspendLayout();
            this.tabColumnChart.SuspendLayout();
            this.tabPieChart.SuspendLayout();
            this.tabDetailsGrid.SuspendLayout();
            this.tblOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewPie)).BeginInit();
            this.pnlLineTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailLine)).BeginInit();
            this.pnlColumnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailColumn)).BeginInit();
            this.pnlPieTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailPie)).BeginInit();
            this.pnlGridTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnExportExcel);
            this.pnlTop.Controls.Add(this.btnPrintReport);
            this.pnlTop.Controls.Add(this.btnFilter);
            this.pnlTop.Controls.Add(this.cboCriterion);
            this.pnlTop.Controls.Add(this.lblCriterion);
            this.pnlTop.Controls.Add(this.cboMonth);
            this.pnlTop.Controls.Add(this.lblMonth);
            this.pnlTop.Controls.Add(this.cboYear);
            this.pnlTop.Controls.Add(this.lblYear);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1280, 85);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG BIỂU ĐỒ THỐNG KÊ DOANH THU & DASHBOARD";

            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.Color.White;
            this.lblYear.Location = new System.Drawing.Point(16, 51);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(46, 20);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Năm:";

            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(68, 47);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(90, 28);
            this.cboYear.TabIndex = 2;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.FilterControls_Changed);

            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonth.ForeColor = System.Drawing.Color.White;
            this.lblMonth.Location = new System.Drawing.Point(170, 51);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(56, 20);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Tháng:";

            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(232, 47);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(140, 28);
            this.cboMonth.TabIndex = 4;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.FilterControls_Changed);

            // 
            // lblCriterion
            // 
            this.lblCriterion.AutoSize = true;
            this.lblCriterion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCriterion.ForeColor = System.Drawing.Color.White;
            this.lblCriterion.Location = new System.Drawing.Point(385, 51);
            this.lblCriterion.Name = "lblCriterion";
            this.lblCriterion.Size = new System.Drawing.Size(84, 20);
            this.lblCriterion.TabIndex = 5;
            this.lblCriterion.Text = "Trạng thái:";

            // 
            // cboCriterion
            // 
            this.cboCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCriterion.FormattingEnabled = true;
            this.cboCriterion.Items.AddRange(new object[] {
            "Tất cả đơn hàng",
            "Đã xử lí (Thành công)",
            "Chờ xử lí (Tồn đọng)",
            "Đã hủy"});
            this.cboCriterion.Location = new System.Drawing.Point(475, 47);
            this.cboCriterion.Name = "cboCriterion";
            this.cboCriterion.Size = new System.Drawing.Size(175, 28);
            this.cboCriterion.TabIndex = 6;
            this.cboCriterion.SelectedIndexChanged += new System.EventHandler(this.FilterControls_Changed);

            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))));
            this.btnFilter.BorderRadius = 6;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(665, 44);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(115, 34);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "🔄 Thống Kê";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(151)))), ((int)(((byte)(149)))));
            this.btnPrintReport.BorderRadius = 6;
            this.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Location = new System.Drawing.Point(790, 44);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(155, 34);
            this.btnPrintReport.TabIndex = 8;
            this.btnPrintReport.Text = "🖨️ In Báo Cáo (RDLC)";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);

            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.btnExportExcel.BorderRadius = 6;
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(955, 44);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(140, 34);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "📊 Xuất File CSV";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.btnClose.BorderRadius = 6;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1170, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 34);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "✕ Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlKpi.Controls.Add(this.pnlCard4);
            this.pnlKpi.Controls.Add(this.pnlCard3);
            this.pnlKpi.Controls.Add(this.pnlCard2);
            this.pnlKpi.Controls.Add(this.pnlCard1);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Location = new System.Drawing.Point(0, 85);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpi.Size = new System.Drawing.Size(1280, 95);
            this.pnlKpi.TabIndex = 1;

            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.BorderRadius = 10;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblTotalRevenue);
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Location = new System.Drawing.Point(14, 8);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(295, 78);
            this.pnlCard1.TabIndex = 0;

            // 
            // lblCard1Title
            // 
            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblCard1Title.Location = new System.Drawing.Point(12, 10);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Size = new System.Drawing.Size(200, 20);
            this.lblCard1Title.TabIndex = 0;
            this.lblCard1Title.Text = "💰 TỔNG DOANH THU (SUM)";

            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(10, 36);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(83, 31);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 VND";

            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.BorderRadius = 10;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblTotalOrders);
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Location = new System.Drawing.Point(325, 8);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(295, 78);
            this.pnlCard2.TabIndex = 1;

            // 
            // lblCard2Title
            // 
            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblCard2Title.Location = new System.Drawing.Point(12, 10);
            this.lblCard2Title.Name = "lblCard2Title";
            this.lblCard2Title.Size = new System.Drawing.Size(197, 20);
            this.lblCard2Title.TabIndex = 0;
            this.lblCard2Title.Text = "📦 TỔNG SỐ ĐƠN (COUNT)";

            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.lblTotalOrders.Location = new System.Drawing.Point(10, 36);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(84, 31);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0 Đơn";

            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.BorderRadius = 10;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblAvgOrder);
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Location = new System.Drawing.Point(636, 8);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(295, 78);
            this.pnlCard3.TabIndex = 2;

            // 
            // lblCard3Title
            // 
            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCard3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblCard3Title.Location = new System.Drawing.Point(12, 10);
            this.lblCard3Title.Name = "lblCard3Title";
            this.lblCard3Title.Size = new System.Drawing.Size(225, 20);
            this.lblCard3Title.TabIndex = 0;
            this.lblCard3Title.Text = "💳 GIÁ TRỊ ĐƠN TB (AVERAGE)";

            // 
            // lblAvgOrder
            // 
            this.lblAvgOrder.AutoSize = true;
            this.lblAvgOrder.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblAvgOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(101)))));
            this.lblAvgOrder.Location = new System.Drawing.Point(10, 36);
            this.lblAvgOrder.Name = "lblAvgOrder";
            this.lblAvgOrder.Size = new System.Drawing.Size(83, 31);
            this.lblAvgOrder.TabIndex = 1;
            this.lblAvgOrder.Text = "0 VND";

            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.White;
            this.pnlCard4.BorderRadius = 10;
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblTotalProductsSold);
            this.pnlCard4.Controls.Add(this.lblCard4Title);
            this.pnlCard4.Location = new System.Drawing.Point(947, 8);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(315, 78);
            this.pnlCard4.TabIndex = 3;

            // 
            // lblCard4Title
            // 
            this.lblCard4Title.AutoSize = true;
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCard4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblCard4Title.Location = new System.Drawing.Point(12, 10);
            this.lblCard4Title.Name = "lblCard4Title";
            this.lblCard4Title.Size = new System.Drawing.Size(228, 20);
            this.lblCard4Title.TabIndex = 0;
            this.lblCard4Title.Text = "🏷️ SẢN PHẨM ĐÃ BÁN (SUM)";

            // 
            // lblTotalProductsSold
            // 
            this.lblTotalProductsSold.AutoSize = true;
            this.lblTotalProductsSold.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductsSold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(70)))), ((int)(((byte)(193)))));
            this.lblTotalProductsSold.Location = new System.Drawing.Point(10, 36);
            this.lblTotalProductsSold.Name = "lblTotalProductsSold";
            this.lblTotalProductsSold.Size = new System.Drawing.Size(107, 31);
            this.lblTotalProductsSold.TabIndex = 1;
            this.lblTotalProductsSold.Text = "0 Cái/Món";

            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.tabOverview);
            this.tabCharts.Controls.Add(this.tabLineChart);
            this.tabCharts.Controls.Add(this.tabColumnChart);
            this.tabCharts.Controls.Add(this.tabPieChart);
            this.tabCharts.Controls.Add(this.tabDetailsGrid);
            this.tabCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCharts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.tabCharts.ItemSize = new System.Drawing.Size(230, 35);
            this.tabCharts.Location = new System.Drawing.Point(0, 180);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.SelectedIndex = 0;
            this.tabCharts.Size = new System.Drawing.Size(1280, 580);
            this.tabCharts.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCharts.TabIndex = 2;

            // 
            // tabOverview
            // 
            this.tabOverview.BackColor = System.Drawing.Color.White;
            this.tabOverview.Controls.Add(this.tblOverview);
            this.tabOverview.Location = new System.Drawing.Point(4, 39);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(8);
            this.tabOverview.Size = new System.Drawing.Size(1272, 537);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "📊 Tổng Quan 3 Biểu Đồ";

            // 
            // tblOverview
            // 
            this.tblOverview.ColumnCount = 3;
            this.tblOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tblOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tblOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblOverview.Controls.Add(this.chartOverviewLine, 0, 0);
            this.tblOverview.Controls.Add(this.chartOverviewColumn, 1, 0);
            this.tblOverview.Controls.Add(this.chartOverviewPie, 2, 0);
            this.tblOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOverview.Location = new System.Drawing.Point(8, 8);
            this.tblOverview.Name = "tblOverview";
            this.tblOverview.RowCount = 1;
            this.tblOverview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOverview.Size = new System.Drawing.Size(1256, 521);
            this.tblOverview.TabIndex = 0;

            // 
            // chartOverviewLine
            // 
            caOverLine.Name = "ChartAreaOverLine";
            this.chartOverviewLine.ChartAreas.Add(caOverLine);
            this.chartOverviewLine.Dock = System.Windows.Forms.DockStyle.Fill;
            legOverLine.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legOverLine.Font = new System.Drawing.Font("Segoe UI", 8F);
            legOverLine.Name = "LegendOverLine";
            this.chartOverviewLine.Legends.Add(legOverLine);
            this.chartOverviewLine.Location = new System.Drawing.Point(3, 3);
            this.chartOverviewLine.Name = "chartOverviewLine";
            serOverLine.ChartArea = "ChartAreaOverLine";
            serOverLine.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            serOverLine.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            serOverLine.Legend = "LegendOverLine";
            serOverLine.Name = "DoanhThu12Thang";
            this.chartOverviewLine.Series.Add(serOverLine);
            this.chartOverviewLine.Size = new System.Drawing.Size(471, 515);
            this.chartOverviewLine.TabIndex = 0;
            titOverLine.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            titOverLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titOverLine.Name = "TitleOverLine";
            titOverLine.Text = "1. DOANH THU 12 THÁNG (LINE)";
            this.chartOverviewLine.Titles.Add(titOverLine);

            // 
            // chartOverviewColumn
            // 
            caOverCol.Name = "ChartAreaOverCol";
            this.chartOverviewColumn.ChartAreas.Add(caOverCol);
            this.chartOverviewColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            legOverCol.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legOverCol.Font = new System.Drawing.Font("Segoe UI", 8F);
            legOverCol.Name = "LegendOverCol";
            this.chartOverviewColumn.Legends.Add(legOverCol);
            this.chartOverviewColumn.Location = new System.Drawing.Point(480, 3);
            this.chartOverviewColumn.Name = "chartOverviewColumn";
            serOverCol.ChartArea = "ChartAreaOverCol";
            serOverCol.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            serOverCol.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            serOverCol.Legend = "LegendOverCol";
            serOverCol.Name = "Top5BanChay";
            this.chartOverviewColumn.Series.Add(serOverCol);
            this.chartOverviewColumn.Size = new System.Drawing.Size(395, 515);
            this.chartOverviewColumn.TabIndex = 1;
            titOverCol.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            titOverCol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titOverCol.Name = "TitleOverCol";
            titOverCol.Text = "2. TOP 5 SẢN PHẨM BÁN CHẠY (COLUMN)";
            this.chartOverviewColumn.Titles.Add(titOverCol);

            // 
            // chartOverviewPie
            // 
            caOverPie.Name = "ChartAreaOverPie";
            this.chartOverviewPie.ChartAreas.Add(caOverPie);
            this.chartOverviewPie.Dock = System.Windows.Forms.DockStyle.Fill;
            legOverPie.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legOverPie.Font = new System.Drawing.Font("Segoe UI", 8F);
            legOverPie.Name = "LegendOverPie";
            this.chartOverviewPie.Legends.Add(legOverPie);
            this.chartOverviewPie.Location = new System.Drawing.Point(881, 3);
            this.chartOverviewPie.Name = "chartOverviewPie";
            serOverPie.ChartArea = "ChartAreaOverPie";
            serOverPie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            serOverPie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            serOverPie.Legend = "LegendOverPie";
            serOverPie.Name = "TyLeDanhMuc";
            this.chartOverviewPie.Series.Add(serOverPie);
            this.chartOverviewPie.Size = new System.Drawing.Size(372, 515);
            this.chartOverviewPie.TabIndex = 2;
            titOverPie.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            titOverPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titOverPie.Name = "TitleOverPie";
            titOverPie.Text = "3. TỶ LỆ THEO DANH MỤC (PIE)";
            this.chartOverviewPie.Titles.Add(titOverPie);

            // 
            // tabLineChart
            // 
            this.tabLineChart.BackColor = System.Drawing.Color.White;
            this.tabLineChart.Controls.Add(this.chartDetailLine);
            this.tabLineChart.Controls.Add(this.pnlLineTop);
            this.tabLineChart.Location = new System.Drawing.Point(4, 39);
            this.tabLineChart.Name = "tabLineChart";
            this.tabLineChart.Padding = new System.Windows.Forms.Padding(8);
            this.tabLineChart.Size = new System.Drawing.Size(1272, 537);
            this.tabLineChart.TabIndex = 1;
            this.tabLineChart.Text = "📈 Doanh Thu 12 Tháng (Line)";

            // 
            // pnlLineTop
            // 
            this.pnlLineTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlLineTop.Controls.Add(this.radSpline);
            this.pnlLineTop.Controls.Add(this.radLine);
            this.pnlLineTop.Controls.Add(this.lblLineDesc);
            this.pnlLineTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineTop.Location = new System.Drawing.Point(8, 8);
            this.pnlLineTop.Name = "pnlLineTop";
            this.pnlLineTop.Size = new System.Drawing.Size(1256, 40);
            this.pnlLineTop.TabIndex = 0;

            // 
            // lblLineDesc
            // 
            this.lblLineDesc.AutoSize = true;
            this.lblLineDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLineDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblLineDesc.Location = new System.Drawing.Point(12, 10);
            this.lblLineDesc.Name = "lblLineDesc";
            this.lblLineDesc.Size = new System.Drawing.Size(430, 20);
            this.lblLineDesc.TabIndex = 0;
            this.lblLineDesc.Text = "Đường xu hướng doanh thu từ Tháng 1 đến Tháng 12 trong năm:";

            // 
            // radSpline
            // 
            this.radSpline.AutoSize = true;
            this.radSpline.Checked = true;
            this.radSpline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radSpline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radSpline.Location = new System.Drawing.Point(470, 8);
            this.radSpline.Name = "radSpline";
            this.radSpline.Size = new System.Drawing.Size(142, 24);
            this.radSpline.TabIndex = 1;
            this.radSpline.TabStop = true;
            this.radSpline.Text = "Đường cong Spline";
            this.radSpline.UseVisualStyleBackColor = true;
            this.radSpline.CheckedChanged += new System.EventHandler(this.LineChartType_CheckedChanged);

            // 
            // radLine
            // 
            this.radLine.AutoSize = true;
            this.radLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radLine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radLine.Location = new System.Drawing.Point(620, 8);
            this.radLine.Name = "radLine";
            this.radLine.Size = new System.Drawing.Size(130, 24);
            this.radLine.TabIndex = 2;
            this.radLine.Text = "Đường thẳng Line";
            this.radLine.UseVisualStyleBackColor = true;
            this.radLine.CheckedChanged += new System.EventHandler(this.LineChartType_CheckedChanged);

            // 
            // chartDetailLine
            // 
            caDetLine.Name = "ChartAreaDetLine";
            this.chartDetailLine.ChartAreas.Add(caDetLine);
            this.chartDetailLine.Dock = System.Windows.Forms.DockStyle.Fill;
            legDetLine.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legDetLine.Font = new System.Drawing.Font("Segoe UI", 9F);
            legDetLine.Name = "LegendDetLine";
            this.chartDetailLine.Legends.Add(legDetLine);
            this.chartDetailLine.Location = new System.Drawing.Point(8, 48);
            this.chartDetailLine.Name = "chartDetailLine";
            serDetLine.ChartArea = "ChartAreaDetLine";
            serDetLine.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            serDetLine.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            serDetLine.Legend = "LegendDetLine";
            serDetLine.Name = "DoanhThuChiTiet";
            this.chartDetailLine.Series.Add(serDetLine);
            this.chartDetailLine.Size = new System.Drawing.Size(1256, 481);
            this.chartDetailLine.TabIndex = 1;
            titDetLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            titDetLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titDetLine.Name = "TitleDetLine";
            titDetLine.Text = "BIỂU ĐỒ DOANH THU 12 THÁNG TRONG NĂM (VND)";
            this.chartDetailLine.Titles.Add(titDetLine);

            // 
            // tabColumnChart
            // 
            this.tabColumnChart.BackColor = System.Drawing.Color.White;
            this.tabColumnChart.Controls.Add(this.chartDetailColumn);
            this.tabColumnChart.Controls.Add(this.pnlColumnTop);
            this.tabColumnChart.Location = new System.Drawing.Point(4, 39);
            this.tabColumnChart.Name = "tabColumnChart";
            this.tabColumnChart.Padding = new System.Windows.Forms.Padding(8);
            this.tabColumnChart.Size = new System.Drawing.Size(1272, 537);
            this.tabColumnChart.TabIndex = 2;
            this.tabColumnChart.Text = "📊 Top 5 Bán Chạy (Column)";

            // 
            // pnlColumnTop
            // 
            this.pnlColumnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlColumnTop.Controls.Add(this.radColumn);
            this.pnlColumnTop.Controls.Add(this.radBar);
            this.pnlColumnTop.Controls.Add(this.lblColumnDesc);
            this.pnlColumnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumnTop.Location = new System.Drawing.Point(8, 8);
            this.pnlColumnTop.Name = "pnlColumnTop";
            this.pnlColumnTop.Size = new System.Drawing.Size(1256, 40);
            this.pnlColumnTop.TabIndex = 0;

            // 
            // lblColumnDesc
            // 
            this.lblColumnDesc.AutoSize = true;
            this.lblColumnDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblColumnDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblColumnDesc.Location = new System.Drawing.Point(12, 10);
            this.lblColumnDesc.Name = "lblColumnDesc";
            this.lblColumnDesc.Size = new System.Drawing.Size(355, 20);
            this.lblColumnDesc.TabIndex = 0;
            this.lblColumnDesc.Text = "Xếp hạng Top 5 mặt hàng có lượng tiêu thụ cao nhất:";

            // 
            // radColumn
            // 
            this.radColumn.AutoSize = true;
            this.radColumn.Checked = true;
            this.radColumn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radColumn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radColumn.Location = new System.Drawing.Point(400, 8);
            this.radColumn.Name = "radColumn";
            this.radColumn.Size = new System.Drawing.Size(149, 24);
            this.radColumn.TabIndex = 1;
            this.radColumn.TabStop = true;
            this.radColumn.Text = "Cột đứng (Column)";
            this.radColumn.UseVisualStyleBackColor = true;
            this.radColumn.CheckedChanged += new System.EventHandler(this.ColumnChartType_CheckedChanged);

            // 
            // radBar
            // 
            this.radBar.AutoSize = true;
            this.radBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radBar.Location = new System.Drawing.Point(565, 8);
            this.radBar.Name = "radBar";
            this.radBar.Size = new System.Drawing.Size(143, 24);
            this.radBar.TabIndex = 2;
            this.radBar.Text = "Thanh ngang (Bar)";
            this.radBar.UseVisualStyleBackColor = true;
            this.radBar.CheckedChanged += new System.EventHandler(this.ColumnChartType_CheckedChanged);

            // 
            // chartDetailColumn
            // 
            caDetCol.Name = "ChartAreaDetCol";
            this.chartDetailColumn.ChartAreas.Add(caDetCol);
            this.chartDetailColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            legDetCol.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legDetCol.Font = new System.Drawing.Font("Segoe UI", 9F);
            legDetCol.Name = "LegendDetCol";
            this.chartDetailColumn.Legends.Add(legDetCol);
            this.chartDetailColumn.Location = new System.Drawing.Point(8, 48);
            this.chartDetailColumn.Name = "chartDetailColumn";
            serDetCol.ChartArea = "ChartAreaDetCol";
            serDetCol.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            serDetCol.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            serDetCol.Legend = "LegendDetCol";
            serDetCol.Name = "Top5ChiTiet";
            this.chartDetailColumn.Series.Add(serDetCol);
            this.chartDetailColumn.Size = new System.Drawing.Size(1256, 481);
            this.chartDetailColumn.TabIndex = 1;
            titDetCol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            titDetCol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titDetCol.Name = "TitleDetCol";
            titDetCol.Text = "TOP 5 SẢN PHẨM BÁN CHẠY NHẤT (SỐ LƯỢNG TIÊU THỤ)";
            this.chartDetailColumn.Titles.Add(titDetCol);

            // 
            // tabPieChart
            // 
            this.tabPieChart.BackColor = System.Drawing.Color.White;
            this.tabPieChart.Controls.Add(this.chartDetailPie);
            this.tabPieChart.Controls.Add(this.pnlPieTop);
            this.tabPieChart.Location = new System.Drawing.Point(4, 39);
            this.tabPieChart.Name = "tabPieChart";
            this.tabPieChart.Padding = new System.Windows.Forms.Padding(8);
            this.tabPieChart.Size = new System.Drawing.Size(1272, 537);
            this.tabPieChart.TabIndex = 3;
            this.tabPieChart.Text = "🍩 Tỷ Lệ Danh Mục (Pie)";

            // 
            // pnlPieTop
            // 
            this.pnlPieTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlPieTop.Controls.Add(this.chkDoughnut);
            this.pnlPieTop.Controls.Add(this.radStatus);
            this.pnlPieTop.Controls.Add(this.radCategory);
            this.pnlPieTop.Controls.Add(this.lblPieDesc);
            this.pnlPieTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPieTop.Location = new System.Drawing.Point(8, 8);
            this.pnlPieTop.Name = "pnlPieTop";
            this.pnlPieTop.Size = new System.Drawing.Size(1256, 40);
            this.pnlPieTop.TabIndex = 0;

            // 
            // lblPieDesc
            // 
            this.lblPieDesc.AutoSize = true;
            this.lblPieDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPieDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPieDesc.Location = new System.Drawing.Point(12, 10);
            this.lblPieDesc.Name = "lblPieDesc";
            this.lblPieDesc.Size = new System.Drawing.Size(161, 20);
            this.lblPieDesc.TabIndex = 0;
            this.lblPieDesc.Text = "Cơ cấu tỷ lệ doanh thu:";

            // 
            // radCategory
            // 
            this.radCategory.AutoSize = true;
            this.radCategory.Checked = true;
            this.radCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radCategory.Location = new System.Drawing.Point(190, 8);
            this.radCategory.Name = "radCategory";
            this.radCategory.Size = new System.Drawing.Size(193, 24);
            this.radCategory.TabIndex = 1;
            this.radCategory.TabStop = true;
            this.radCategory.Text = "Theo Danh mục hàng hóa";
            this.radCategory.UseVisualStyleBackColor = true;
            this.radCategory.CheckedChanged += new System.EventHandler(this.PieCriteria_CheckedChanged);

            // 
            // radStatus
            // 
            this.radStatus.AutoSize = true;
            this.radStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.radStatus.Location = new System.Drawing.Point(400, 8);
            this.radStatus.Name = "radStatus";
            this.radStatus.Size = new System.Drawing.Size(183, 24);
            this.radStatus.TabIndex = 2;
            this.radStatus.Text = "Theo Trạng thái đơn hàng";
            this.radStatus.UseVisualStyleBackColor = true;
            this.radStatus.CheckedChanged += new System.EventHandler(this.PieCriteria_CheckedChanged);

            // 
            // chkDoughnut
            // 
            this.chkDoughnut.AutoSize = true;
            this.chkDoughnut.Checked = true;
            this.chkDoughnut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoughnut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDoughnut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkDoughnut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))));
            this.chkDoughnut.Location = new System.Drawing.Point(620, 8);
            this.chkDoughnut.Name = "chkDoughnut";
            this.chkDoughnut.Size = new System.Drawing.Size(193, 24);
            this.chkDoughnut.TabIndex = 3;
            this.chkDoughnut.Text = "Kiểu vành khuyên Doughnut";
            this.chkDoughnut.UseVisualStyleBackColor = true;
            this.chkDoughnut.CheckedChanged += new System.EventHandler(this.chkDoughnut_CheckedChanged);

            // 
            // chartDetailPie
            // 
            caDetPie.Name = "ChartAreaDetPie";
            this.chartDetailPie.ChartAreas.Add(caDetPie);
            this.chartDetailPie.Dock = System.Windows.Forms.DockStyle.Fill;
            legDetPie.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            legDetPie.Font = new System.Drawing.Font("Segoe UI", 9F);
            legDetPie.Name = "LegendDetPie";
            this.chartDetailPie.Legends.Add(legDetPie);
            this.chartDetailPie.Location = new System.Drawing.Point(8, 48);
            this.chartDetailPie.Name = "chartDetailPie";
            serDetPie.ChartArea = "ChartAreaDetPie";
            serDetPie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            serDetPie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            serDetPie.Legend = "LegendDetPie";
            serDetPie.Name = "TyLeChiTiet";
            this.chartDetailPie.Series.Add(serDetPie);
            this.chartDetailPie.Size = new System.Drawing.Size(1256, 481);
            this.chartDetailPie.TabIndex = 1;
            titDetPie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            titDetPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            titDetPie.Name = "TitleDetPie";
            titDetPie.Text = "TỶ TRỌNG DOANH THU THEO DANH MỤC HÀNG HÓA (%)";
            this.chartDetailPie.Titles.Add(titDetPie);

            // 
            // tabDetailsGrid
            // 
            this.tabDetailsGrid.BackColor = System.Drawing.Color.White;
            this.tabDetailsGrid.Controls.Add(this.dgvDetails);
            this.tabDetailsGrid.Controls.Add(this.pnlGridTop);
            this.tabDetailsGrid.Location = new System.Drawing.Point(4, 39);
            this.tabDetailsGrid.Name = "tabDetailsGrid";
            this.tabDetailsGrid.Padding = new System.Windows.Forms.Padding(8);
            this.tabDetailsGrid.Size = new System.Drawing.Size(1272, 537);
            this.tabDetailsGrid.TabIndex = 4;
            this.tabDetailsGrid.Text = "📋 Bảng Dữ Liệu Đơn Hàng";

            // 
            // pnlGridTop
            // 
            this.pnlGridTop.Controls.Add(this.lblGridTitle);
            this.pnlGridTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTop.Location = new System.Drawing.Point(8, 8);
            this.pnlGridTop.Name = "pnlGridTop";
            this.pnlGridTop.Size = new System.Drawing.Size(1256, 36);
            this.pnlGridTop.TabIndex = 0;

            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblGridTitle.Location = new System.Drawing.Point(4, 6);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(370, 25);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "DANH SÁCH CÁC ĐƠN HÀNG THỐNG KÊ:";

            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(8, 44);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 51;
            this.dgvDetails.RowTemplate.Height = 28;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1256, 485);
            this.dgvDetails.TabIndex = 1;

            // 
            // frmChartDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.tabCharts);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmChartDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Thống Kê & Biểu Đồ Doanh Thu (Chart Dashboard)";
            this.Load += new System.EventHandler(this.frmChartDashboard_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.tabCharts.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabLineChart.ResumeLayout(false);
            this.tabColumnChart.ResumeLayout(false);
            this.tabPieChart.ResumeLayout(false);
            this.tabDetailsGrid.ResumeLayout(false);
            this.tblOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverviewPie)).EndInit();
            this.pnlLineTop.ResumeLayout(false);
            this.pnlLineTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailLine)).EndInit();
            this.pnlColumnTop.ResumeLayout(false);
            this.pnlColumnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailColumn)).EndInit();
            this.pnlPieTop.ResumeLayout(false);
            this.pnlPieTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDetailPie)).EndInit();
            this.pnlGridTop.ResumeLayout(false);
            this.pnlGridTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
