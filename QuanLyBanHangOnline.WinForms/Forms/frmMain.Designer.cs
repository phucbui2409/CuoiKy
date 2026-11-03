namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmMain : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectionConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnuLoaiHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhaSanXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuBusiness;
        private System.Windows.Forms.ToolStripMenuItem mnuDatHang;
        private System.Windows.Forms.ToolStripMenuItem mnuXuLyDonHang;
        private System.Windows.Forms.ToolStripMenuItem mnuTraCuu;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoDonHang;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoTonKho;
        private System.Windows.Forms.ToolStripMenuItem mnuChartDashboard;
        private System.Windows.Forms.ToolStripMenuItem mnuInHoaDonReport;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministration;
        private System.Windows.Forms.ToolStripMenuItem mnuUserManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuRoleManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuThemeToggle;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnToggleTheme;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRole;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label lblWelcome;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickDatHang;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickXuLyDon;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickHangHoa;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickTraCuu;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickThongKe;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnQuickBaoCao;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnectionConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoaiHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhaSanXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXuLyDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraCuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChartDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInHoaDonReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRoleManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThemeToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToggleTheme = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.btnQuickBaoCao = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickBaoCao.BorderRadius = 14;
            this.btnQuickThongKe = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickThongKe.BorderRadius = 14;
            this.btnQuickTraCuu = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickTraCuu.BorderRadius = 14;
            this.btnQuickHangHoa = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickHangHoa.BorderRadius = 14;
            this.btnQuickXuLyDon = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickXuLyDon.BorderRadius = 14;
            this.btnQuickDatHang = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnQuickDatHang.BorderRadius = 14;
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuCatalog,
            this.mnuBusiness,
            this.mnuReports,
            this.mnuAdministration,
            this.mnuThemeToggle});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectionConfig,
            this.mnuChangePassword,
            this.mnuLogout,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(79, 23);
            this.mnuSystem.Text = "Hệ Thống";
            // 
            // mnuConnectionConfig
            // 
            this.mnuConnectionConfig.Name = "mnuConnectionConfig";
            this.mnuConnectionConfig.Size = new System.Drawing.Size(260, 24);
            this.mnuConnectionConfig.Text = "Cấu Hình Kết Nối SQL (App.config)";
            this.mnuConnectionConfig.Click += new System.EventHandler(this.mnuConnectionConfig_Click);
            // 
            // mnuConnectionConfig
            // 
            this.mnuConnectionConfig.Name = "mnuConnectionConfig";
            this.mnuConnectionConfig.Size = new System.Drawing.Size(260, 24);
            this.mnuConnectionConfig.Text = "Cấu Hình Kết Nối SQL (App.config)";
            this.mnuConnectionConfig.Click += new System.EventHandler(this.mnuConnectionConfig_Click);
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(161, 24);
            this.mnuChangePassword.Text = "Đổi Mật Khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(161, 24);
            this.mnuLogout.Text = "Đăng Xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(161, 24);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuCatalog
            // 
            this.mnuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHangHoa,
            this.mnuLoaiHang,
            this.mnuNhaSanXuat,
            this.mnuKhachHang,
            this.mnuNhanVien});
            this.mnuCatalog.Name = "mnuCatalog";
            this.mnuCatalog.Size = new System.Drawing.Size(142, 23);
            this.mnuCatalog.Text = "Quản Lý Danh Mục";
            // 
            // mnuHangHoa
            // 
            this.mnuHangHoa.Name = "mnuHangHoa";
            this.mnuHangHoa.Size = new System.Drawing.Size(193, 24);
            this.mnuHangHoa.Text = "Hàng Hóa (Sản Phẩm)";
            this.mnuHangHoa.Click += new System.EventHandler(this.mnuHangHoa_Click);
            // 
            // mnuLoaiHang
            // 
            this.mnuLoaiHang.Name = "mnuLoaiHang";
            this.mnuLoaiHang.Size = new System.Drawing.Size(193, 24);
            this.mnuLoaiHang.Text = "Loại Hàng Hóa";
            this.mnuLoaiHang.Click += new System.EventHandler(this.mnuLoaiHang_Click);
            // 
            // mnuNhaSanXuat
            // 
            this.mnuNhaSanXuat.Name = "mnuNhaSanXuat";
            this.mnuNhaSanXuat.Size = new System.Drawing.Size(193, 24);
            this.mnuNhaSanXuat.Text = "Nhà Sản Xuất";
            this.mnuNhaSanXuat.Click += new System.EventHandler(this.mnuNhaSanXuat_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(193, 24);
            this.mnuKhachHang.Text = "Khách Hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(193, 24);
            this.mnuNhanVien.Text = "Nhân Viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuBusiness
            // 
            this.mnuBusiness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatHang,
            this.mnuXuLyDonHang,
            this.mnuTraCuu});
            this.mnuBusiness.Name = "mnuBusiness";
            this.mnuBusiness.Size = new System.Drawing.Size(150, 23);
            this.mnuBusiness.Text = "Nghiệp Vụ Giao Dịch";
            // 
            // mnuDatHang
            // 
            this.mnuDatHang.Name = "mnuDatHang";
            this.mnuDatHang.Size = new System.Drawing.Size(222, 24);
            this.mnuDatHang.Text = "Đặt Hàng Online";
            this.mnuDatHang.Click += new System.EventHandler(this.mnuDatHang_Click);
            // 
            // mnuXuLyDonHang
            // 
            this.mnuXuLyDonHang.Name = "mnuXuLyDonHang";
            this.mnuXuLyDonHang.Size = new System.Drawing.Size(222, 24);
            this.mnuXuLyDonHang.Text = "Xử Lý Đơn Hàng (FIFO)";
            this.mnuXuLyDonHang.Click += new System.EventHandler(this.mnuXuLyDonHang_Click);
            // 
            // mnuTraCuu
            // 
            this.mnuTraCuu.Name = "mnuTraCuu";
            this.mnuTraCuu.Size = new System.Drawing.Size(222, 24);
            this.mnuTraCuu.Text = "Tra Cứu Hàng Hóa";
            this.mnuTraCuu.Click += new System.EventHandler(this.mnuTraCuu_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChartDashboard,
            this.mnuThongKe,
            this.mnuBaoCaoDonHang,
            this.mnuInHoaDonReport,
            this.mnuBaoCaoTonKho});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(133, 23);
            this.mnuReports.Text = "Báo Cáo Thống Kê";
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(223, 24);
            this.mnuThongKe.Text = "Thống Kê Doanh Thu";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnuBaoCaoDonHang
            // 
            this.mnuBaoCaoDonHang.Name = "mnuBaoCaoDonHang";
            this.mnuBaoCaoDonHang.Size = new System.Drawing.Size(223, 24);
            this.mnuBaoCaoDonHang.Text = "Xem Báo Cáo Đơn Hàng";
            this.mnuBaoCaoDonHang.Click += new System.EventHandler(this.mnuBaoCaoDonHang_Click);
            // 
            // mnuChartDashboard
            // 
            this.mnuChartDashboard.Name = "mnuChartDashboard";
            this.mnuChartDashboard.Size = new System.Drawing.Size(260, 24);
            this.mnuChartDashboard.Text = "Dashboard Biểu Đồ & Thống Kê";
            this.mnuChartDashboard.Click += new System.EventHandler(this.mnuChartDashboard_Click);
            // 
            // mnuInHoaDonReport
            // 
            this.mnuInHoaDonReport.Name = "mnuInHoaDonReport";
            this.mnuInHoaDonReport.Size = new System.Drawing.Size(260, 24);
            this.mnuInHoaDonReport.Text = "In Hóa Đơn & Xuất Kho (RDLC)";
            this.mnuInHoaDonReport.Click += new System.EventHandler(this.mnuInHoaDonReport_Click);
            // 
            // mnuBaoCaoTonKho
            // 
            this.mnuBaoCaoTonKho.Name = "mnuBaoCaoTonKho";
            this.mnuBaoCaoTonKho.Size = new System.Drawing.Size(223, 24);
            this.mnuBaoCaoTonKho.Text = "Báo Cáo Tồn Kho";
            this.mnuBaoCaoTonKho.Click += new System.EventHandler(this.mnuBaoCaoTonKho_Click);
            // 
            // mnuAdministration
            // 
            this.mnuAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserManagement,
            this.mnuRoleManagement});
            this.mnuAdministration.Name = "mnuAdministration";
            this.mnuAdministration.Size = new System.Drawing.Size(76, 23);
            this.mnuAdministration.Text = "Quản Trị";
            // 
            // mnuUserManagement
            // 
            this.mnuUserManagement.Name = "mnuUserManagement";
            this.mnuUserManagement.Size = new System.Drawing.Size(217, 24);
            this.mnuUserManagement.Text = "Quản Lý Tài Khoản";
            this.mnuUserManagement.Click += new System.EventHandler(this.mnuUserManagement_Click);
            // 
            // mnuRoleManagement
            // 
            this.mnuRoleManagement.Name = "mnuRoleManagement";
            this.mnuRoleManagement.Size = new System.Drawing.Size(217, 24);
            this.mnuRoleManagement.Text = "Phân Quyền Hệ Thống";
            this.mnuRoleManagement.Click += new System.EventHandler(this.mnuRoleManagement_Click);
            // 
            // mnuThemeToggle
            // 
            this.mnuThemeToggle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuThemeToggle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.mnuThemeToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.mnuThemeToggle.Name = "mnuThemeToggle";
            this.mnuThemeToggle.Size = new System.Drawing.Size(125, 23);
            this.mnuThemeToggle.Text = "🌙 Giao diện Tối";
            this.mnuThemeToggle.Click += new System.EventHandler(this.btnToggleTheme_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUser,
            this.lblStatusRole,
            this.lblStatusTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 24);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(155, 19);
            this.lblStatusUser.Text = "Người dùng: [admin]";
            // 
            // lblStatusRole
            // 
            this.lblStatusRole.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStatusRole.Name = "lblStatusRole";
            this.lblStatusRole.Size = new System.Drawing.Size(123, 19);
            this.lblStatusRole.Text = "| Vai trò: [ADMIN]";
            // 
            // lblStatusTime
            // 
            this.lblStatusTime.Name = "lblStatusTime";
            this.lblStatusTime.Size = new System.Drawing.Size(691, 19);
            this.lblStatusTime.Spring = true;
            this.lblStatusTime.Text = "Thời gian: 00:00:00";
            this.lblStatusTime.Text = "Thời gian: 00:00:00";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // panelDashboard
            // 
            this.panelDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelDashboard.Controls.Add(this.btnQuickBaoCao);
            this.panelDashboard.Controls.Add(this.btnQuickThongKe);
            this.panelDashboard.Controls.Add(this.btnQuickTraCuu);
            this.panelDashboard.Controls.Add(this.btnQuickHangHoa);
            this.panelDashboard.Controls.Add(this.btnQuickXuLyDon);
            this.panelDashboard.Controls.Add(this.btnQuickDatHang);
            this.panelDashboard.Controls.Add(this.lblWelcome);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(0, 27);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(984, 560);
            this.panelDashboard.TabIndex = 2;
            // 
            // btnQuickBaoCao
            // 
            this.btnQuickBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnQuickBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickBaoCao.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnQuickBaoCao.Location = new System.Drawing.Point(780, 310);
            this.btnQuickBaoCao.Name = "btnQuickBaoCao";
            this.btnQuickBaoCao.Size = new System.Drawing.Size(320, 140);
            this.btnQuickBaoCao.TabIndex = 6;
            this.btnQuickBaoCao.Text = "BÁO CÁO ĐƠN HÀNG\r\n(Xem & In ấn)";
            this.btnQuickBaoCao.UseVisualStyleBackColor = false;
            this.btnQuickBaoCao.Click += new System.EventHandler(this.mnuBaoCaoDonHang_Click);
            // 
            // btnQuickThongKe
            // 
            this.btnQuickThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnQuickThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickThongKe.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickThongKe.ForeColor = System.Drawing.Color.White;
            this.btnQuickThongKe.Location = new System.Drawing.Point(430, 310);
            this.btnQuickThongKe.Name = "btnQuickThongKe";
            this.btnQuickThongKe.Size = new System.Drawing.Size(320, 140);
            this.btnQuickThongKe.TabIndex = 5;
            this.btnQuickThongKe.Text = "THỐNG KÊ DOANH THU\r\n(LINQ Aggregates)";
            this.btnQuickThongKe.UseVisualStyleBackColor = false;
            this.btnQuickThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // btnQuickTraCuu
            // 
            this.btnQuickTraCuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnQuickTraCuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTraCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTraCuu.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickTraCuu.ForeColor = System.Drawing.Color.White;
            this.btnQuickTraCuu.Location = new System.Drawing.Point(80, 310);
            this.btnQuickTraCuu.Name = "btnQuickTraCuu";
            this.btnQuickTraCuu.Size = new System.Drawing.Size(320, 140);
            this.btnQuickTraCuu.TabIndex = 4;
            this.btnQuickTraCuu.Text = "TRA CỨU HÀNG HÓA\r\n(Tìm kiếm nâng cao)";
            this.btnQuickTraCuu.UseVisualStyleBackColor = false;
            this.btnQuickTraCuu.Click += new System.EventHandler(this.mnuTraCuu_Click);
            // 
            // btnQuickHangHoa
            // 
            this.btnQuickHangHoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnQuickHangHoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickHangHoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickHangHoa.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickHangHoa.ForeColor = System.Drawing.Color.White;
            this.btnQuickHangHoa.Location = new System.Drawing.Point(780, 130);
            this.btnQuickHangHoa.Name = "btnQuickHangHoa";
            this.btnQuickHangHoa.Size = new System.Drawing.Size(320, 140);
            this.btnQuickHangHoa.TabIndex = 3;
            this.btnQuickHangHoa.Text = "QUẢN LÝ HÀNG HÓA\r\n(CRUD Sản phẩm)";
            this.btnQuickHangHoa.UseVisualStyleBackColor = false;
            this.btnQuickHangHoa.Click += new System.EventHandler(this.mnuHangHoa_Click);
            // 
            // btnQuickXuLyDon
            // 
            this.btnQuickXuLyDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnQuickXuLyDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickXuLyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickXuLyDon.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickXuLyDon.ForeColor = System.Drawing.Color.White;
            this.btnQuickXuLyDon.Location = new System.Drawing.Point(430, 130);
            this.btnQuickXuLyDon.Name = "btnQuickXuLyDon";
            this.btnQuickXuLyDon.Size = new System.Drawing.Size(320, 140);
            this.btnQuickXuLyDon.TabIndex = 2;
            this.btnQuickXuLyDon.Text = "XỬ LÝ ĐƠN HÀNG\r\n(Hàng đợi FIFO)";
            this.btnQuickXuLyDon.UseVisualStyleBackColor = false;
            this.btnQuickXuLyDon.Click += new System.EventHandler(this.mnuXuLyDonHang_Click);
            // 
            // btnQuickDatHang
            // 
            this.btnQuickDatHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnQuickDatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickDatHang.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickDatHang.ForeColor = System.Drawing.Color.White;
            this.btnQuickDatHang.Location = new System.Drawing.Point(80, 130);
            this.btnQuickDatHang.Name = "btnQuickDatHang";
            this.btnQuickDatHang.Size = new System.Drawing.Size(320, 140);
            this.btnQuickDatHang.TabIndex = 1;
            this.btnQuickDatHang.Text = "ĐẶT HÀNG ONLINE\r\n(Lập đơn hàng mới)";
            this.btnQuickDatHang.UseVisualStyleBackColor = false;
            this.btnQuickDatHang.Click += new System.EventHandler(this.mnuDatHang_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblWelcome.Location = new System.Drawing.Point(80, 45);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(718, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "BẢNG ĐIỀU KHIỂN HỆ THỐNG QUẢN LÝ BÁN HÀNG ONLINE";
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnToggleTheme.BorderRadius = 14;
            this.btnToggleTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleTheme.FlatAppearance.BorderSize = 0;
            this.btnToggleTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleTheme.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnToggleTheme.ForeColor = System.Drawing.Color.White;
            this.btnToggleTheme.Location = new System.Drawing.Point(950, 45);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(150, 38);
            this.btnToggleTheme.TabIndex = 7;
            this.btnToggleTheme.Text = "🌙 Chế độ Tối";
            this.btnToggleTheme.UseVisualStyleBackColor = false;
            this.btnToggleTheme.Click += new System.EventHandler(this.btnToggleTheme_Click);
            this.panelDashboard.Controls.Add(this.btnToggleTheme);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1180, 700);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bán Hàng Online - .NET Framework";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelDashboard.ResumeLayout(false);
            this.panelDashboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
