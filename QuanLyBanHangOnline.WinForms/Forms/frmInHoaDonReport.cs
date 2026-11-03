using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Models;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmInHoaDonReport : Form
    {
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();
        private readonly int? _initialOrderId;
        private bool _isLoaded = false;

        public frmInHoaDonReport(int? orderId = null)
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
            this._initialOrderId = orderId;
        }

        private void frmInHoaDonReport_Load(object sender, EventArgs e)
        {
            LoadOrderList();
            _isLoaded = true;

            if (cboOrders.Items.Count > 0)
            {
                if (_initialOrderId.HasValue)
                {
                    // Tìm đơn hàng tương ứng trong combobox
                    int foundIdx = -1;
                    for (int i = 0; i < cboOrders.Items.Count; i++)
                    {
                        var item = cboOrders.Items[i] as ComboBoxItem;
                        if (item != null && item.Value == _initialOrderId.Value)
                        {
                            foundIdx = i;
                            break;
                        }
                    }

                    cboOrders.SelectedIndex = foundIdx >= 0 ? foundIdx : 0;
                }
                else
                {
                    cboOrders.SelectedIndex = 0;
                }

                HienThiBaoCao();
            }
            else
            {
                MessageBox.Show("Hiện tại chưa có đơn hàng nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadOrderList()
        {
            try
            {
                var orders = _donHangRepo.GetAllOrders("ALL");
                cboOrders.Items.Clear();

                foreach (var ord in orders)
                {
                    cboOrders.Items.Add(new ComboBoxItem
                    {
                        Text = $"#{ord.SoThuTu} - {ord.TenKhachHang} ({ord.TongTien:N0} VND)",
                        Value = ord.SoThuTu
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                HienThiBaoCao();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThiBaoCao();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendEmailInvoice_Click(object sender, EventArgs e)
        {
            var selectedItem = cboOrders.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần gửi hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soThuTu = selectedItem.Value;
            var order = _donHangRepo.GetOrderById(soThuTu);
            if (order == null)
            {
                MessageBox.Show("Không tìm thấy thông tin đơn hàng #" + soThuTu, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xuất ReportViewer thành file PDF
            string tempPdfPath = string.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] pdfBytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                tempPdfPath = Path.Combine(Path.GetTempPath(), $"HoaDon_HD{order.SoThuTu:D4}.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Không thể xuất file PDF từ ReportViewer: " + ex.Message, "Lỗi kết xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            // Gợi ý địa chỉ email của khách
            string defaultEmail = "khachhang@demo.com";
            string recipientEmail = ShowPromptDialog(
                $"Nhập địa chỉ email người nhận để gửi Hóa đơn điện tử PDF (Đơn hàng #{order.SoThuTu}):",
                "Gửi Email Hóa Đơn Tự Động qua Gmail SMTP",
                defaultEmail);

            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                return; // Người dùng bấm Hủy
            }

            this.Cursor = Cursors.WaitCursor;
            bool sent = EmailHelper.SendInvoiceEmail(
                recipientEmail,
                order.TenKhachHang,
                $"HD{order.SoThuTu:D4}",
                order.TongTien,
                tempPdfPath,
                out string sendErr);
            this.Cursor = Cursors.Default;

            if (sent)
            {
                MessageBox.Show($"✔ Đã gửi thành công Hóa đơn điện tử file PDF đến email:\n{recipientEmail}\n\nTệp đính kèm: HoaDon_HD{order.SoThuTu:D4}.pdf ({new FileInfo(tempPdfPath).Length / 1024} KB)",
                    "Gửi Email Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Chưa thể gửi email thật (máy chạy demo chưa thiết lập Gmail App Password):\nChi tiết: {sendErr}\n\nTuy nhiên tệp hóa đơn PDF đã được tạo sẵn tại:\n{tempPdfPath}",
                    "Thông báo gửi Email (Demo)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HienThiBaoCao()
        {
            var selectedItem = cboOrders.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            int soThuTu = selectedItem.Value;
            var order = _donHangRepo.GetOrderById(soThuTu);
            if (order == null)
            {
                MessageBox.Show("Không tìm thấy thông tin đơn hàng #" + soThuTu, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách chi tiết đơn hàng
            var chiTietRaw = _donHangRepo.LayChiTietDonHang(soThuTu);
            var dsHangHoa = new List<ChiTietXuatKhoItem>();

            for (int i = 0; i < chiTietRaw.Count; i++)
            {
                var item = chiTietRaw[i];
                dsHangHoa.Add(new ChiTietXuatKhoItem
                {
                    STT = i + 1,
                    MaHang = item.MaHang,
                    TenHang = item.TenHang,
                    MauSac = string.IsNullOrEmpty(item.MauSac) ? "Tiêu chuẩn" : item.MauSac,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien
                });
            }

            try
            {
                // Tìm đường dẫn file RDLC
                string rdlcPath = FindReportFilePath("rptHoaDonXuatKho.rdlc");

                if (!File.Exists(rdlcPath))
                {
                    MessageBox.Show("Không tìm thấy file mẫu báo cáo: " + rdlcPath, "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rdlcPath;
                reportViewer1.LocalReport.DataSources.Clear();

                // 1. Truyền danh sách hàng hóa qua ReportDataSource
                ReportDataSource rds = new ReportDataSource("DataSetChiTietDonHang", dsHangHoa);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // 2. Truyền tham số đơn hàng qua ReportParameter
                string tongTienChu = NumberToVietnameseWords.ChuyenSoThanhChu(order.TongTien);
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pMaHD", $"HD{order.SoThuTu:D4}"),
                    new ReportParameter("pNgayLap", order.NgayDatHang.ToString("dd/MM/yyyy HH:mm:ss")),
                    new ReportParameter("pTenKhachHang", string.IsNullOrEmpty(order.TenKhachHang) ? "Khách lẻ" : order.TenKhachHang),
                    new ReportParameter("pDiaChi", string.IsNullOrEmpty(order.DiaChiGiaoHang) ? "Tại quầy" : order.DiaChiGiaoHang),
                    new ReportParameter("pSoDienThoai", string.IsNullOrEmpty(order.SoDienThoaiGiaoHang) ? "---" : order.SoDienThoaiGiaoHang),
                    new ReportParameter("pNhanVienLap", string.IsNullOrEmpty(order.MaNV) ? "NV01 (Bán hàng)" : order.MaNV),
                    new ReportParameter("pTrangThai", string.IsNullOrEmpty(order.TrangThai) ? "Đã xử lí" : order.TrangThai),
                    new ReportParameter("pTongTien", $"{order.TongTien:N0}"),
                    new ReportParameter("pTongTienChu", tongTienChu),
                    new ReportParameter("pGhiChu", string.IsNullOrEmpty(order.GhiChu) ? "Cảm ơn quý khách đã mua hàng!" : order.GhiChu)
                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message + "\n" + ex.InnerException?.Message,
                                "Lỗi ReportViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FindReportFilePath(string fileName)
        {
            string p1 = Path.Combine(Application.StartupPath, "Reports", fileName);
            if (File.Exists(p1)) return p1;

            string p2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Reports", fileName);
            if (File.Exists(p2)) return Path.GetFullPath(p2);

            string p3 = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(p3)) return p3;

            return p1;
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        private static string ShowPromptDialog(string prompt, string title, string defaultValue)
        {
            using (var promptForm = new Form())
            {
                promptForm.Width = 480;
                promptForm.Height = 180;
                promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promptForm.Text = title;
                promptForm.StartPosition = FormStartPosition.CenterParent;
                promptForm.MaximizeBox = false;
                promptForm.MinimizeBox = false;

                var textLabel = new Label() { Left = 20, Top = 15, Width = 430, Text = prompt, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
                var textBox = new TextBox() { Left = 20, Top = 45, Width = 430, Text = defaultValue, Font = new System.Drawing.Font("Segoe UI", 10.5F) };
                var confirmation = new Button() { Text = "Gửi Email", Left = 240, Width = 100, Top = 90, DialogResult = DialogResult.OK, BackColor = System.Drawing.Color.FromArgb(16, 185, 129), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
                var cancel = new Button() { Text = "Hủy", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.Cancel, BackColor = System.Drawing.Color.FromArgb(100, 116, 139), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };

                confirmation.Click += (sender, e) => { promptForm.Close(); };
                cancel.Click += (sender, e) => { promptForm.Close(); };

                promptForm.Controls.Add(textLabel);
                promptForm.Controls.Add(textBox);
                promptForm.Controls.Add(confirmation);
                promptForm.Controls.Add(cancel);
                promptForm.AcceptButton = confirmation;
                promptForm.CancelButton = cancel;

                return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : string.Empty;
            }
        }
    }
}
