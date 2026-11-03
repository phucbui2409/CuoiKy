using System;
using System.Drawing;
using System.IO;
using System.Net;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    /// <summary>
    /// Tiện ích tạo mã VietQR chuẩn ngân hàng Napas 247 và mã QR / Barcode
    /// </summary>
    public static class VietQRHelper
    {
        // Thông tin tài khoản nhận tiền mặc định của cửa hàng
        public const string DefaultBankId = "MB"; // MBBank
        public const string DefaultBankName = "MBBank (Ngân hàng Quân Đội)";
        public const string DefaultAccountNo = "0901112233";
        public const string DefaultAccountName = "SHOP BAN HANG ONLINE";

        /// <summary>
        /// Tạo link ảnh VietQR trực tuyến theo chuẩn Napas 247
        /// </summary>
        public static string GetVietQRUrl(string bankId, string accountNo, string accountName, decimal amount, string memo)
        {
            string cleanBank = string.IsNullOrWhiteSpace(bankId) ? DefaultBankId : bankId.Trim();
            string cleanAcc = string.IsNullOrWhiteSpace(accountNo) ? DefaultAccountNo : accountNo.Trim();
            string cleanName = Uri.EscapeDataString(string.IsNullOrWhiteSpace(accountName) ? DefaultAccountName : accountName.Trim());
            string cleanMemo = Uri.EscapeDataString(string.IsNullOrWhiteSpace(memo) ? "THANH TOAN DON HANG" : memo.Trim());
            long intAmount = (long)amount;

            // Template compact2 hiển thị logo ngân hàng và thông tin chuyển khoản rõ nét
            return $"https://img.vietqr.io/image/{cleanBank}-{cleanAcc}-compact2.png?amount={intAmount}&addInfo={cleanMemo}&accountName={cleanName}";
        }

        /// <summary>
        /// Tải hình ảnh VietQR trực tuyến từ API Napas
        /// </summary>
        public static Image DownloadVietQRImage(string bankId, string accountNo, string accountName, decimal amount, string memo)
        {
            try
            {
                string url = GetVietQRUrl(bankId, accountNo, accountName, amount, memo);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var wc = new WebClient())
                {
                    byte[] data = wc.DownloadData(url);
                    using (var ms = new MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                // Nếu không có mạng hoặc lỗi kết nối -> Tự sinh mã QR ngoại tuyến qua ZXing
                return GenerateQrCodeOffline(bankId, accountNo, accountName, amount, memo);
            }
        }

        /// <summary>
        /// Tự sinh mã QR ngoại tuyến (Offline) bằng thư viện ZXing.Net (Không cần Internet)
        /// </summary>
        public static Bitmap GenerateQrCodeOffline(string bankId, string accountNo, string accountName, decimal amount, string memo, int width = 300, int height = 300)
        {
            // Nội dung payload chuẩn chuyển khoản ngân hàng
            string payload = $"2|99|{accountNo}|{accountName}|{bankId}|0|0|{(long)amount}|{memo}|transfer_myqr";

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 1,
                    CharacterSet = "UTF-8"
                }
            };

            return writer.Write(payload);
        }

        /// <summary>
        /// Sinh mã vạch 1D Barcode (CODE_128) cho sản phẩm
        /// </summary>
        public static Bitmap GenerateBarcode128(string text, int width = 250, int height = 80)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 2,
                    PureBarcode = false
                }
            };

            return writer.Write(text);
        }
    }
}
