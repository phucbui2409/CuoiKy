using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmThanhToanVietQR : Form
    {
        private readonly string _maHD;
        private readonly decimal _soTien;
        private readonly string _tenKhachHang;

        // Danh sách các ngân hàng thông dụng ở Việt Nam
        private class BankItem
        {
            public string Code { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"{Code} - {Name}";
            }
        }

        public frmThanhToanVietQR(string maHD, decimal soTien, string tenKhachHang = "")
        {
            InitializeComponent();
            _maHD = string.IsNullOrWhiteSpace(maHD) ? "HD" + DateTime.Now.ToString("yyMMddHHmm") : maHD.Trim();
            _soTien = soTien;
            _tenKhachHang = tenKhachHang;

            InitForm();
        }

        private void InitForm()
        {
            cboBank.Items.Add(new BankItem { Code = "MB", Name = "MBBank (Ngân hàng Quân Đội)" });
            cboBank.Items.Add(new BankItem { Code = "VCB", Name = "Vietcombank (Ngoại thương VN)" });
            cboBank.Items.Add(new BankItem { Code = "TCB", Name = "Techcombank (Kỹ Thương VN)" });
            cboBank.Items.Add(new BankItem { Code = "BIDV", Name = "BIDV (Đầu tư & Phát triển VN)" });
            cboBank.Items.Add(new BankItem { Code = "ICB", Name = "VietinBank (Công thương VN)" });
            cboBank.Items.Add(new BankItem { Code = "ACB", Name = "ACB (Á Châu)" });
            cboBank.Items.Add(new BankItem { Code = "VPB", Name = "VPBank (Việt Nam Thịnh Vượng)" });
            cboBank.Items.Add(new BankItem { Code = "TPB", Name = "TPBank (Tiên Phong)" });
            cboBank.SelectedIndex = 0;

            txtAccountNo.Text = VietQRHelper.DefaultAccountNo;
            txtAccountName.Text = VietQRHelper.DefaultAccountName;
            lblAmountValue.Text = string.Format("{0:N0} VNĐ", _soTien);
            txtMemo.Text = $"THANH TOAN {_maHD}";

            if (!string.IsNullOrWhiteSpace(_tenKhachHang))
            {
                lblOrderInfo.Text = $"Đơn hàng: {_maHD} | Khách hàng: {_tenKhachHang}";
            }
            else
            {
                lblOrderInfo.Text = $"Đơn hàng: {_maHD}";
            }
        }

        private void frmThanhToanVietQR_Load(object sender, EventArgs e)
        {
            LoadQrCode();
        }

        private void LoadQrCode()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string bankCode = "MB";
                if (cboBank.SelectedItem is BankItem bi)
                {
                    bankCode = bi.Code;
                }

                string accNo = txtAccountNo.Text.Trim();
                string accName = txtAccountName.Text.Trim();
                string memo = txtMemo.Text.Trim();

                Image qrImage = VietQRHelper.DownloadVietQRImage(bankCode, accNo, accName, _soTien, memo);
                if (picQR.Image != null)
                {
                    picQR.Image.Dispose();
                }
                picQR.Image = qrImage;
            }
            catch (Exception ex)
            {
                try
                {
                    picQR.Image = VietQRHelper.GenerateQrCodeOffline("MB", txtAccountNo.Text, txtAccountName.Text, _soTien, txtMemo.Text);
                }
                catch
                {
                    MessageBox.Show("Không thể tạo mã VietQR: " + ex.Message, "Lỗi VietQR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadQrCode();
        }

        private void btnRefreshQR_Click(object sender, EventArgs e)
        {
            LoadQrCode();
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            if (picQR.Image == null)
            {
                MessageBox.Show("Chưa có hình ảnh mã VietQR để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Ảnh PNG (*.png)|*.png|Ảnh JPEG (*.jpg)|*.jpg";
                sfd.FileName = $"VietQR_{_maHD}.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageFormat format = ImageFormat.Png;
                        if (sfd.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                            format = ImageFormat.Jpeg;

                        picQR.Image.Save(sfd.FileName, format);
                        MessageBox.Show("Đã lưu ảnh mã QR thành công tại:\n" + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnConfirmPaid_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Xác nhận khách hàng đã chuyển khoản thành công số tiền {string.Format("{0:N0}", _soTien)} VNĐ cho hóa đơn {_maHD}?",
                "Xác nhận thanh toán VietQR",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
