using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Helpers;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmConnectionConfig : Form
    {
        private bool _isInitializing = true;

        public frmConnectionConfig()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmConnectionConfig_Load(object sender, EventArgs e)
        {
            try
            {
                // Đọc chuỗi kết nối hiện tại từ App.config
                string currentConn = ConfigHelper.GetConnectionString(out bool isEncrypted);

                ConfigHelper.ParseConnectionString(currentConn,
                    out string server,
                    out string database,
                    out bool isWindowsAuth,
                    out string username,
                    out string password,
                    out int timeout,
                    out bool trustServerCertificate);

                cboServer.Text = string.IsNullOrEmpty(server) ? "." : server;
                cboDatabase.Text = string.IsNullOrEmpty(database) ? "QuanLyBanHangOnline" : database;
                cboAuth.SelectedIndex = isWindowsAuth ? 0 : 1;
                txtUsername.Text = string.IsNullOrEmpty(username) ? "sa" : username;
                txtPassword.Text = password ?? string.Empty;
                numTimeout.Value = (timeout >= 2 && timeout <= 60) ? timeout : 5;
                chkTrustCertificate.Checked = trustServerCertificate;
                chkEncryptConfig.Checked = isEncrypted;

                pnlSqlAuth.Enabled = !isWindowsAuth;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp cấu hình hiện tại: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAuth.SelectedIndex = 0;
            }
            finally
            {
                _isInitializing = false;
                UpdatePreview();
            }
        }

        private void cboAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = cboAuth.SelectedIndex == 1;
            pnlSqlAuth.Enabled = isSqlAuth;
            UpdatePreview();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (!_isInitializing)
            {
                UpdatePreview();
            }
        }

        private void UpdatePreview()
        {
            bool isWindowsAuth = cboAuth.SelectedIndex == 0;
            string connStr = ConfigHelper.BuildConnectionString(
                cboServer.Text,
                cboDatabase.Text,
                isWindowsAuth,
                txtUsername.Text,
                txtPassword.Text,
                (int)numTimeout.Value,
                chkTrustCertificate.Checked);

            txtPreview.Text = connStr;
            lblStatus.Text = "Trạng thái: Chưa kiểm tra kết nối với thông số này.";
            lblStatus.ForeColor = Color.DarkSlateGray;
        }

        private async void btnScanServers_Click(object sender, EventArgs e)
        {
            btnScanServers.Enabled = false;
            btnScanServers.Text = "Đang quét...";
            Cursor = Cursors.WaitCursor;

            try
            {
                var servers = await Task.Run(() =>
                {
                    var list = new System.Collections.Generic.List<string>();
                    // Luôn thêm các server nội bộ phổ biến nhất
                    list.Add(".");
                    list.Add("(local)");
                    list.Add("localhost");
                    list.Add("127.0.0.1");
                    list.Add(@".\SQLEXPRESS");
                    list.Add(@"(localdb)\MSSQLLocalDB");

                    try
                    {
                        SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                        DataTable table = instance.GetDataSources();
                        foreach (DataRow row in table.Rows)
                        {
                            string serverName = row["ServerName"]?.ToString();
                            string instanceName = row["InstanceName"]?.ToString();
                            string fullName = string.IsNullOrEmpty(instanceName) ? serverName : $"{serverName}\\{instanceName}";
                            if (!string.IsNullOrEmpty(fullName) && !list.Contains(fullName))
                            {
                                list.Add(fullName);
                            }
                        }
                    }
                    catch { }

                    return list;
                });

                foreach (var s in servers)
                {
                    if (!cboServer.Items.Contains(s))
                    {
                        cboServer.Items.Add(s);
                    }
                }

                MessageBox.Show($"Đã quét và nạp {cboServer.Items.Count} máy chủ/instance vào danh sách!",
                                "Quét hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quét tìm máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnScanServers.Enabled = true;
                btnScanServers.Text = "Quét Server";
                Cursor = Cursors.Default;
            }
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboServer.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Tên Máy Chủ (Server Name) trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboServer.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnLoadDatabases.Enabled = false;
            btnLoadDatabases.Text = "Đang nạp...";

            try
            {
                // Tạo chuỗi kết nối tạm thời tới CSDL master
                bool isWinAuth = cboAuth.SelectedIndex == 0;
                string masterConn = ConfigHelper.BuildConnectionString(
                    cboServer.Text,
                    "master",
                    isWinAuth,
                    txtUsername.Text,
                    txtPassword.Text,
                    (int)numTimeout.Value,
                    chkTrustCertificate.Checked);

                using (var conn = new SqlConnection(masterConn))
                {
                    conn.Open();
                    string sql = "SELECT name FROM sys.databases WHERE database_id > 4 AND state_desc = 'ONLINE' ORDER BY name";
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cboDatabase.Items.Clear();
                        bool foundTarget = false;
                        while (reader.Read())
                        {
                            string dbName = reader["name"].ToString();
                            cboDatabase.Items.Add(dbName);
                            if (dbName.Equals("QuanLyBanHangOnline", StringComparison.OrdinalIgnoreCase))
                            {
                                foundTarget = true;
                            }
                        }

                        if (foundTarget)
                        {
                            cboDatabase.Text = "QuanLyBanHangOnline";
                        }
                        else if (cboDatabase.Items.Count > 0 && string.IsNullOrWhiteSpace(cboDatabase.Text))
                        {
                            cboDatabase.SelectedIndex = 0;
                        }

                        MessageBox.Show($"Đã tải thành công {cboDatabase.Items.Count} cơ sở dữ liệu từ máy chủ '{cboServer.Text}'!",
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách cơ sở dữ liệu từ máy chủ!\n\nChi tiết lỗi: " + ex.Message +
                                "\n\nGợi ý: Kiểm tra lại tên Server, thông tin tài khoản đăng nhập hoặc thử kết nối trước.",
                                "Lỗi kết nối máy chủ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadDatabases.Enabled = true;
                btnLoadDatabases.Text = "Tải DS CSDL";
                Cursor = Cursors.Default;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnTestConnection.Enabled = false;

            try
            {
                string connStr = txtPreview.Text;
                bool ok = DbContextHelper.TestConnectionWith(connStr, out string errorMessage, out string serverVersion);

                if (ok)
                {
                    lblStatus.Text = $"✓ Kết nối thành công! SQL Server v{serverVersion}";
                    lblStatus.ForeColor = Color.Green;

                    MessageBox.Show($"Kết nối đến Cơ Sở Dữ Liệu SQL Server thành công!\n\n" +
                                    $"• Máy chủ (Server): {cboServer.Text}\n" +
                                    $"• Cơ sở dữ liệu: {cboDatabase.Text}\n" +
                                    $"• Xác thực: {cboAuth.Text}\n" +
                                    $"• Phiên bản SQL Server: {serverVersion}\n\n" +
                                    $"Bạn có thể bấm 'Lưu Vào App.config' để lưu cấu hình này.",
                                    "Kết nối thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "✗ Kết nối thất bại: " + errorMessage;
                    lblStatus.ForeColor = Color.Red;

                    MessageBox.Show($"Không thể kết nối đến SQL Server!\n\nChi tiết lỗi:\n{errorMessage}\n\n" +
                                    "Gợi ý khắc phục khi đổi máy chạy demo:\n" +
                                    "1. Kiểm tra lại tên Server (thử '.' hoặc '(local)' hoặc '.\\SQLEXPRESS').\n" +
                                    "2. Chuyển đổi giữa Windows Authentication và SQL Server Authentication (sa).\n" +
                                    "3. Đảm bảo dịch vụ SQL Server (MSSQLSERVER/SQLEXPRESS) đang chạy trong Windows Services.",
                                    "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnTestConnection.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = txtPreview.Text;

            // Kiểm tra thử kết nối trước khi lưu
            bool ok = DbContextHelper.TestConnectionWith(connStr, out string errorMessage, out _);
            if (!ok)
            {
                var confirm = MessageBox.Show($"Thử nghiệm kết nối đến cơ sở dữ liệu hiện tại KHÔNG thành công:\n{errorMessage}\n\n" +
                                              "Bạn có chắc chắn VẪN MUỐN LƯU cấu hình này vào file App.config không?",
                                              "Cảnh báo kết nối", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes)
                {
                    return;
                }
            }

            bool encrypt = chkEncryptConfig.Checked;
            bool saved = ConfigHelper.SaveConnectionString(connStr, encrypt, out string saveError);

            if (saved)
            {
                // Cập nhật trạng thái kết nối trong bộ nhớ
                DbContextHelper.ConnectionString = connStr;
                DbContextHelper.ReloadConfiguration();

                string securityMsg = encrypt
                    ? "Chuỗi kết nối đã được MÃ HÓA BẢO MẬT AES-256 an toàn trong file cấu hình."
                    : "Chuỗi kết nối được lưu ở định dạng chuẩn (không mã hóa).";

                MessageBox.Show($"Đã lưu chuỗi kết nối vào file App.config thành công!\n\n" +
                                $"• Server: {cboServer.Text}\n" +
                                $"• Database: {cboDatabase.Text}\n" +
                                $"• Bảo mật: {securityMsg}\n\n" +
                                "Từ bây giờ mọi thao tác trong ứng dụng sẽ tự động sử dụng cấu hình kết nối mới này.",
                                "Lưu cấu hình thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi ghi cấu hình vào App.config: " + saveError, "Lỗi lưu file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
