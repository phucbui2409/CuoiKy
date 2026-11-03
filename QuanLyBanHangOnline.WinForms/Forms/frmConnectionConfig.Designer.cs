namespace QuanLyBanHangOnline.WinForms.Forms
{
    partial class frmConnectionConfig
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox cboServer;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnScanServers;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.ComboBox cboAuth;
        private System.Windows.Forms.Panel pnlSqlAuth;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cboDatabase;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnLoadDatabases;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblTimeoutUnit;
        private System.Windows.Forms.CheckBox chkTrustCertificate;
        private System.Windows.Forms.CheckBox chkEncryptConfig;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlActions;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnTestConnection;
        private QuanLyBanHangOnline.WinForms.UIExtension.ModernButton btnSave;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.pnlSqlAuth = new System.Windows.Forms.Panel();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cboAuth = new System.Windows.Forms.ComboBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.btnScanServers = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnScanServers.BorderRadius = 8;
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.chkEncryptConfig = new System.Windows.Forms.CheckBox();
            this.chkTrustCertificate = new System.Windows.Forms.CheckBox();
            this.lblTimeoutUnit = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.btnLoadDatabases = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnLoadDatabases.BorderRadius = 8;
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnClose = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnClose.BorderRadius = 8;
            this.btnSave = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnSave.BorderRadius = 8;
            this.btnTestConnection = new QuanLyBanHangOnline.WinForms.UIExtension.ModernButton();
            this.btnTestConnection.BorderRadius = 8;
            this.pnlHeader.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.pnlSqlAuth.SuspendLayout();
            this.grpDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.grpPreview.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(684, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 45);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(515, 15);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Quản lý chuỗi kết nối lưu trong App.config • Hỗ trợ đổi máy demo • Mã hóa bảo mật AES-256";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(434, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "CẤU HÌNH KẾT NỐI CƠ SỞ DỮ LIỆU SQL SERVER";
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.pnlSqlAuth);
            this.grpServer.Controls.Add(this.cboAuth);
            this.grpServer.Controls.Add(this.lblAuth);
            this.grpServer.Controls.Add(this.btnScanServers);
            this.grpServer.Controls.Add(this.cboServer);
            this.grpServer.Controls.Add(this.lblServer);
            this.grpServer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpServer.Location = new System.Drawing.Point(20, 85);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(644, 185);
            this.grpServer.TabIndex = 1;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "1. Thông Tin Máy Chủ & Xác Thực";
            // 
            // pnlSqlAuth
            // 
            this.pnlSqlAuth.Controls.Add(this.chkShowPassword);
            this.pnlSqlAuth.Controls.Add(this.txtPassword);
            this.pnlSqlAuth.Controls.Add(this.lblPassword);
            this.pnlSqlAuth.Controls.Add(this.txtUsername);
            this.pnlSqlAuth.Controls.Add(this.lblUsername);
            this.pnlSqlAuth.Location = new System.Drawing.Point(20, 105);
            this.pnlSqlAuth.Name = "pnlSqlAuth";
            this.pnlSqlAuth.Size = new System.Drawing.Size(608, 68);
            this.pnlSqlAuth.TabIndex = 5;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.Location = new System.Drawing.Point(495, 38);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(51, 19);
            this.chkShowPassword.TabIndex = 4;
            this.chkShowPassword.Text = "Hiện";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.Location = new System.Drawing.Point(170, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(315, 24);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPassword.Location = new System.Drawing.Point(5, 39);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsername.Location = new System.Drawing.Point(170, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(315, 24);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "sa";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.Location = new System.Drawing.Point(5, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(98, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên đăng nhập:";
            // 
            // cboAuth
            // 
            this.cboAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboAuth.FormattingEnabled = true;
            this.cboAuth.Items.AddRange(new object[] {
            "Windows Authentication (Xác thực tài khoản Windows)",
            "SQL Server Authentication (Nhập tên người dùng & mật khẩu)"});
            this.cboAuth.Location = new System.Drawing.Point(190, 68);
            this.cboAuth.Name = "cboAuth";
            this.cboAuth.Size = new System.Drawing.Size(438, 25);
            this.cboAuth.TabIndex = 4;
            this.cboAuth.SelectedIndexChanged += new System.EventHandler(this.cboAuth_SelectedIndexChanged);
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAuth.Location = new System.Drawing.Point(25, 71);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(134, 17);
            this.lblAuth.TabIndex = 3;
            this.lblAuth.Text = "Phương thức xác thực:";
            // 
            // btnScanServers
            // 
            this.btnScanServers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnScanServers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScanServers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanServers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnScanServers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnScanServers.Location = new System.Drawing.Point(520, 27);
            this.btnScanServers.Name = "btnScanServers";
            this.btnScanServers.Size = new System.Drawing.Size(108, 27);
            this.btnScanServers.TabIndex = 2;
            this.btnScanServers.Text = "Quét Server";
            this.btnScanServers.UseVisualStyleBackColor = false;
            this.btnScanServers.Click += new System.EventHandler(this.btnScanServers_Click);
            // 
            // cboServer
            // 
            this.cboServer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Items.AddRange(new object[] {
            ".",
            "(local)",
            "localhost",
            "127.0.0.1",
            ".\\SQLEXPRESS",
            "(localdb)\\MSSQLLocalDB"});
            this.cboServer.Location = new System.Drawing.Point(190, 28);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(320, 25);
            this.cboServer.TabIndex = 1;
            this.cboServer.Text = ".";
            this.cboServer.TextChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblServer.Location = new System.Drawing.Point(25, 31);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(147, 17);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Tên Máy Chủ (Server):";
            // 
            // grpDatabase
            // 
            this.grpDatabase.Controls.Add(this.chkEncryptConfig);
            this.grpDatabase.Controls.Add(this.chkTrustCertificate);
            this.grpDatabase.Controls.Add(this.lblTimeoutUnit);
            this.grpDatabase.Controls.Add(this.numTimeout);
            this.grpDatabase.Controls.Add(this.lblTimeout);
            this.grpDatabase.Controls.Add(this.btnLoadDatabases);
            this.grpDatabase.Controls.Add(this.cboDatabase);
            this.grpDatabase.Controls.Add(this.lblDatabase);
            this.grpDatabase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpDatabase.Location = new System.Drawing.Point(20, 276);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(644, 138);
            this.grpDatabase.TabIndex = 2;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "2. Cơ Sở Dữ Liệu & Tùy Chọn Nâng Cao";
            // 
            // chkEncryptConfig
            // 
            this.chkEncryptConfig.AutoSize = true;
            this.chkEncryptConfig.Checked = true;
            this.chkEncryptConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncryptConfig.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkEncryptConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.chkEncryptConfig.Location = new System.Drawing.Point(28, 103);
            this.chkEncryptConfig.Name = "chkEncryptConfig";
            this.chkEncryptConfig.Size = new System.Drawing.Size(437, 21);
            this.chkEncryptConfig.TabIndex = 7;
            this.chkEncryptConfig.Text = "Mã hóa chuỗi kết nối khi ghi vào App.config (Bảo mật AES-256 an toàn)";
            this.chkEncryptConfig.UseVisualStyleBackColor = true;
            // 
            // chkTrustCertificate
            // 
            this.chkTrustCertificate.AutoSize = true;
            this.chkTrustCertificate.Checked = true;
            this.chkTrustCertificate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrustCertificate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkTrustCertificate.Location = new System.Drawing.Point(340, 68);
            this.chkTrustCertificate.Name = "chkTrustCertificate";
            this.chkTrustCertificate.Size = new System.Drawing.Size(262, 21);
            this.chkTrustCertificate.TabIndex = 6;
            this.chkTrustCertificate.Text = "Tin cậy chứng chỉ (TrustServerCertificate)";
            this.chkTrustCertificate.UseVisualStyleBackColor = true;
            this.chkTrustCertificate.CheckedChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblTimeoutUnit
            // 
            this.lblTimeoutUnit.AutoSize = true;
            this.lblTimeoutUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeoutUnit.Location = new System.Drawing.Point(265, 71);
            this.lblTimeoutUnit.Name = "lblTimeoutUnit";
            this.lblTimeoutUnit.Size = new System.Drawing.Size(29, 15);
            this.lblTimeoutUnit.TabIndex = 5;
            this.lblTimeoutUnit.Text = "giây";
            // 
            // numTimeout
            // 
            this.numTimeout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numTimeout.Location = new System.Drawing.Point(190, 67);
            this.numTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTimeout.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(70, 24);
            this.numTimeout.TabIndex = 4;
            this.numTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTimeout.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimeout.Location = new System.Drawing.Point(25, 69);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(148, 17);
            this.lblTimeout.TabIndex = 3;
            this.lblTimeout.Text = "Thời gian chờ (Timeout):";
            // 
            // btnLoadDatabases
            // 
            this.btnLoadDatabases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnLoadDatabases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDatabases.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadDatabases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLoadDatabases.Location = new System.Drawing.Point(520, 28);
            this.btnLoadDatabases.Name = "btnLoadDatabases";
            this.btnLoadDatabases.Size = new System.Drawing.Size(108, 27);
            this.btnLoadDatabases.TabIndex = 2;
            this.btnLoadDatabases.Text = "Tải DS CSDL";
            this.btnLoadDatabases.UseVisualStyleBackColor = false;
            this.btnLoadDatabases.Click += new System.EventHandler(this.btnLoadDatabases_Click);
            // 
            // cboDatabase
            // 
            this.cboDatabase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Items.AddRange(new object[] {
            "QuanLyBanHangOnline"});
            this.cboDatabase.Location = new System.Drawing.Point(190, 29);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(320, 25);
            this.cboDatabase.TabIndex = 1;
            this.cboDatabase.Text = "QuanLyBanHangOnline";
            this.cboDatabase.TextChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDatabase.Location = new System.Drawing.Point(25, 32);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(155, 17);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Cơ Sở Dữ Liệu (Database):";
            // 
            // grpPreview
            // 
            this.grpPreview.Controls.Add(this.lblStatus);
            this.grpPreview.Controls.Add(this.txtPreview);
            this.grpPreview.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpPreview.Location = new System.Drawing.Point(20, 420);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(644, 115);
            this.grpPreview.TabIndex = 3;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "3. Chuỗi Kết Nối Thực Tế (Connection String Preview)";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStatus.Location = new System.Drawing.Point(15, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(268, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Trạng thái: Chưa kiểm tra kết nối với thông số này.";
            // 
            // txtPreview
            // 
            this.txtPreview.BackColor = System.Drawing.Color.White;
            this.txtPreview.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPreview.Location = new System.Drawing.Point(15, 25);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreview.Size = new System.Drawing.Size(613, 58);
            this.txtPreview.TabIndex = 0;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnClose);
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Controls.Add(this.btnTestConnection);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 545);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(684, 55);
            this.pnlActions.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnClose.Location = new System.Drawing.Point(544, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(340, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "💾 Lưu Vào App.config";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Location = new System.Drawing.Point(20, 10);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(185, 35);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "⚡ Thử Kết Nối (Test)";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // frmConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(684, 600);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.grpDatabase);
            this.Controls.Add(this.grpServer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu Hình Kết Nối Cơ Sở Dữ Liệu SQL Server (App.config)";
            this.Load += new System.EventHandler(this.frmConnectionConfig_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.pnlSqlAuth.ResumeLayout(false);
            this.pnlSqlAuth.PerformLayout();
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
