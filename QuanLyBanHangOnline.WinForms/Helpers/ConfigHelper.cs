using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    public static class ConfigHelper
    {
        public const string CONNECTION_STRING_NAME = "QuanLyBanHangOnline.WinForms.Properties.Settings.QuanLyBanHangOnlineConnectionString";
        private const string ENCRYPT_PREFIX = "ENC:";
        private static readonly byte[] CryptoKey;

        static ConfigHelper()
        {
            using (var sha = SHA256.Create())
            {
                // Băm mật khẩu ứng dụng thành đúng chuẩn 32 bytes (256-bit) cho AES-256
                CryptoKey = sha.ComputeHash(Encoding.UTF8.GetBytes("QuanLyBanHangOnline_SecretKey_AES256_2026"));
            }
        }

        #region Mã Hóa & Giải Mã (AES-256)
        /// <summary>
        /// Mã hóa chuỗi kết nối bằng AES-256
        /// </summary>
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            using (var aes = Aes.Create())
            {
                aes.Key = CryptoKey;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Ghi 16 bytes IV vào đầu
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs, Encoding.UTF8))
                    {
                        sw.Write(plainText);
                    }
                    return ENCRYPT_PREFIX + Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Giải mã chuỗi kết nối AES-256 (tự động nhận diện tiền tố ENC:)
        /// </summary>
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;
            if (!cipherText.StartsWith(ENCRYPT_PREFIX)) return cipherText; // Không mã hóa

            try
            {
                string base64 = cipherText.Substring(ENCRYPT_PREFIX.Length);
                byte[] allBytes = Convert.FromBase64String(base64);

                using (var aes = Aes.Create())
                {
                    aes.Key = CryptoKey;
                    byte[] iv = new byte[16];
                    Array.Copy(allBytes, 0, iv, 0, 16);
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream(allBytes, 16, allBytes.Length - 16))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                // Nếu giải mã lỗi, trả về chuỗi gốc
                return cipherText;
            }
        }

        public static bool IsEncrypted(string connectionString)
        {
            return !string.IsNullOrEmpty(connectionString) && connectionString.StartsWith(ENCRYPT_PREFIX);
        }
        #endregion

        #region Đọc & Ghi File App.config
        /// <summary>
        /// Đọc ConnectionString từ file App.config (tự động giải mã nếu được mã hóa)
        /// </summary>
        public static string GetConnectionString(out bool isEncrypted)
        {
            isEncrypted = false;
            try
            {
                ConfigurationManager.RefreshSection("connectionStrings");
                var setting = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME];
                if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    string raw = setting.ConnectionString;
                    if (IsEncrypted(raw))
                    {
                        isEncrypted = true;
                        return Decrypt(raw);
                    }
                    return raw;
                }
            }
            catch { }

            // Mặc định dự phòng
            return "Data Source=.;Initial Catalog=QuanLyBanHangOnline;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5";
        }

        /// <summary>
        /// Ghi chuỗi kết nối vào file App.config và đồng bộ file *.exe.config đang chạy
        /// </summary>
        public static bool SaveConnectionString(string plainConnectionString, bool encrypt, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string valueToSave = encrypt ? Encrypt(plainConnectionString) : plainConnectionString;

                // 1. Cập nhật file *.exe.config của ứng dụng đang chạy qua ConfigurationManager
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.ConnectionStrings.ConnectionStrings[CONNECTION_STRING_NAME] != null)
                {
                    config.ConnectionStrings.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString = valueToSave;
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
                        CONNECTION_STRING_NAME,
                        valueToSave,
                        "System.Data.SqlClient"));
                }

                // Cập nhật appSettings cờ IsConnectionStringEncrypted
                if (config.AppSettings.Settings["IsConnectionStringEncrypted"] == null)
                {
                    config.AppSettings.Settings.Add("IsConnectionStringEncrypted", encrypt.ToString().ToLower());
                }
                else
                {
                    config.AppSettings.Settings["IsConnectionStringEncrypted"].Value = encrypt.ToString().ToLower();
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                ConfigurationManager.RefreshSection("appSettings");

                // 2. Đồng thời cập nhật file App.config gốc trong thư mục dự án (nếu đang chạy từ bin\Debug hoặc bin\Release)
                UpdateProjectSourceAppConfig(valueToSave, encrypt);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static void UpdateProjectSourceAppConfig(string valueToSave, bool encrypt)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                // Thử tìm file App.config ở thư mục cha (..\..\App.config)
                string projectConfig = Path.GetFullPath(Path.Combine(baseDir, @"..\..\App.config"));
                if (File.Exists(projectConfig))
                {
                    UpdateXmlConfigFile(projectConfig, valueToSave, encrypt);
                }
            }
            catch { }
        }

        private static void UpdateXmlConfigFile(string xmlPath, string valueToSave, bool encrypt)
        {
            var doc = new XmlDocument();
            doc.Load(xmlPath);

            var connNodes = doc.SelectNodes($"//connectionStrings/add[@name='{CONNECTION_STRING_NAME}']");
            if (connNodes != null && connNodes.Count > 0)
            {
                foreach (XmlNode node in connNodes)
                {
                    node.Attributes["connectionString"].Value = valueToSave;
                }
            }

            // Ghi thêm hoặc sửa appSettings
            var appSettingsNode = doc.SelectSingleNode("//appSettings");
            if (appSettingsNode == null)
            {
                appSettingsNode = doc.CreateElement("appSettings");
                doc.DocumentElement.AppendChild(appSettingsNode);
            }

            var encryptSetting = appSettingsNode.SelectSingleNode("add[@key='IsConnectionStringEncrypted']");
            if (encryptSetting == null)
            {
                var elem = doc.CreateElement("add");
                elem.SetAttribute("key", "IsConnectionStringEncrypted");
                elem.SetAttribute("value", encrypt.ToString().ToLower());
                appSettingsNode.AppendChild(elem);
            }
            else
            {
                ((XmlElement)encryptSetting).SetAttribute("value", encrypt.ToString().ToLower());
            }

            doc.Save(xmlPath);
        }
        #endregion

        #region Tạo Chuỗi Kết Nối Tiện Ích
        public static string BuildConnectionString(string server, string database, bool isWindowsAuth, string username, string password, int timeout = 5, bool trustServerCertificate = true)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = string.IsNullOrWhiteSpace(server) ? "." : server.Trim(),
                InitialCatalog = string.IsNullOrWhiteSpace(database) ? "QuanLyBanHangOnline" : database.Trim(),
                ConnectTimeout = timeout > 0 ? timeout : 5,
                TrustServerCertificate = trustServerCertificate
            };

            if (isWindowsAuth)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = username?.Trim();
                builder.Password = password;
            }

            return builder.ConnectionString;
        }

        public static void ParseConnectionString(string connectionString, out string server, out string database, out bool isWindowsAuth, out string username, out string password, out int timeout, out bool trustServerCertificate)
        {
            server = ".";
            database = "QuanLyBanHangOnline";
            isWindowsAuth = true;
            username = "sa";
            password = string.Empty;
            timeout = 5;
            trustServerCertificate = true;

            if (string.IsNullOrWhiteSpace(connectionString)) return;

            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                server = builder.DataSource;
                database = builder.InitialCatalog;
                isWindowsAuth = builder.IntegratedSecurity;
                username = builder.UserID;
                password = builder.Password;
                timeout = builder.ConnectTimeout > 0 ? builder.ConnectTimeout : 5;
                trustServerCertificate = builder.TrustServerCertificate;
            }
            catch { }
        }
        #endregion
    }
}
