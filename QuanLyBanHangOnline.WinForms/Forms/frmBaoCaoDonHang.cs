using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmBaoCaoDonHang : System.Windows.Forms.Form
    {
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();

        public frmBaoCaoDonHang()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                UIThemeManager.ApplyTheme(this);
            }
        }

        private void frmBaoCaoDonHang_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;
            LoadOrders();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            string status = "ALL";
            if (cboStatus.SelectedIndex == 1) status = "Chờ xử lí";
            else if (cboStatus.SelectedIndex == 2) status = "Đã xử lí";
            else if (cboStatus.SelectedIndex == 3) status = "Đã hủy";

            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;

            var list = _donHangRepo.GetAllOrders(status, from, to);
            dgvOrders.DataSource = list;

            if (dgvOrders.Columns["SoThuTu"] != null) dgvOrders.Columns["SoThuTu"].HeaderText = "STT Đơn";
            if (dgvOrders.Columns["TenKhachHang"] != null) dgvOrders.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
            if (dgvOrders.Columns["SoDienThoaiGiaoHang"] != null) dgvOrders.Columns["SoDienThoaiGiaoHang"].HeaderText = "SĐT";
            if (dgvOrders.Columns["DiaChiGiaoHang"] != null) dgvOrders.Columns["DiaChiGiaoHang"].HeaderText = "Địa Chỉ";
            if (dgvOrders.Columns["NgayDatHang"] != null)
            {
                dgvOrders.Columns["NgayDatHang"].HeaderText = "Ngày Đặt";
                dgvOrders.Columns["NgayDatHang"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvOrders.Columns["TongTien"] != null)
            {
                dgvOrders.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvOrders.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
            if (dgvOrders.Columns["TrangThai"] != null) dgvOrders.Columns["TrangThai"].HeaderText = "Trạng Thái";

            if (dgvOrders.Columns["MaKH"] != null) dgvOrders.Columns["MaKH"].Visible = false;
            if (dgvOrders.Columns["MaNV"] != null) dgvOrders.Columns["MaNV"].Visible = false;
            if (dgvOrders.Columns["GhiChu"] != null) dgvOrders.Columns["GhiChu"].Visible = false;
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                int stt = Convert.ToInt32(dgvOrders.CurrentRow.Cells["SoThuTu"].Value);
                var details = _donHangRepo.LayChiTietDonHang(stt);
                dgvDetails.DataSource = details;

                if (dgvDetails.Columns["MaHang"] != null) dgvDetails.Columns["MaHang"].HeaderText = "Mã Hàng";
                if (dgvDetails.Columns["TenHang"] != null) dgvDetails.Columns["TenHang"].HeaderText = "Tên Sản Phẩm";
                if (dgvDetails.Columns["SoLuong"] != null) dgvDetails.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgvDetails.Columns["DonGia"] != null)
                {
                    dgvDetails.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvDetails.Columns["ThanhTien"] != null)
                {
                    dgvDetails.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgvDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvDetails.Columns["MaCT"] != null) dgvDetails.Columns["MaCT"].Visible = false;
                if (dgvDetails.Columns["SoThuTuDonHang"] != null) dgvDetails.Columns["SoThuTuDonHang"].Visible = false;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["SoThuTu"].Value);
                // Mở cửa sổ ReportViewer chuyên nghiệp với mẫu hóa đơn / phiếu xuất kho RDLC
                var fReport = new frmInHoaDonReport(orderId);
                fReport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            var row = dgvOrders.CurrentRow;
            int stt = Convert.ToInt32(row.Cells["SoThuTu"].Value);
            string tenKH = row.Cells["TenKhachHang"].Value?.ToString();
            string sdt = row.Cells["SoDienThoaiGiaoHang"].Value?.ToString();
            string diaChi = row.Cells["DiaChiGiaoHang"].Value?.ToString();
            DateTime ngayDat = Convert.ToDateTime(row.Cells["NgayDatHang"].Value);
            decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);
            string trangThai = row.Cells["TrangThai"].Value?.ToString();

            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 11, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 10);
            Font fontItalic = new Font("Arial", 9, FontStyle.Italic);

            int y = 50;
            g.DrawString("HỆ THỐNG QUẢN LÝ BÁN HÀNG ONLINE", fontTitle, Brushes.DarkBlue, new PointF(200, y));
            y += 35;
            g.DrawString("PHIẾU GIAO HÀNG & CHI TIẾT ĐƠN HÀNG", fontHeader, Brushes.Black, new PointF(250, y));
            y += 30;
            g.DrawLine(Pens.Black, 50, y, 750, y);
            y += 20;

            g.DrawString($"Mã số đơn hàng: #{stt}", fontHeader, Brushes.Black, 50, y);
            g.DrawString($"Ngày lập đơn: {ngayDat:dd/MM/yyyy HH:mm:ss}", fontRegular, Brushes.Black, 450, y);
            y += 25;
            g.DrawString($"Khách hàng   : {tenKH}", fontRegular, Brushes.Black, 50, y);
            g.DrawString($"Số điện thoại: {sdt}", fontRegular, Brushes.Black, 450, y);
            y += 25;
            g.DrawString($"Địa chỉ giao : {diaChi}", fontRegular, Brushes.Black, 50, y);
            g.DrawString($"Trạng thái   : {trangThai}", fontRegular, Brushes.Black, 450, y);
            y += 35;

            // Bảng chi tiết
            g.DrawLine(Pens.Gray, 50, y, 750, y);
            y += 10;
            g.DrawString("STT", fontHeader, Brushes.Black, 50, y);
            g.DrawString("Mã", fontHeader, Brushes.Black, 100, y);
            g.DrawString("Tên Hàng Hóa", fontHeader, Brushes.Black, 180, y);
            g.DrawString("SL", fontHeader, Brushes.Black, 450, y);
            g.DrawString("Đơn Giá", fontHeader, Brushes.Black, 520, y);
            g.DrawString("Thành Tiền", fontHeader, Brushes.Black, 640, y);
            y += 25;
            g.DrawLine(Pens.Gray, 50, y, 750, y);
            y += 10;

            var details = _donHangRepo.LayChiTietDonHang(stt);
            int idx = 1;
            foreach (var item in details)
            {
                g.DrawString(idx.ToString(), fontRegular, Brushes.Black, 50, y);
                g.DrawString(item.MaHang, fontRegular, Brushes.Black, 100, y);
                g.DrawString(item.TenHang, fontRegular, Brushes.Black, 180, y);
                g.DrawString(item.SoLuong.ToString(), fontRegular, Brushes.Black, 450, y);
                g.DrawString($"{item.DonGia:N0}", fontRegular, Brushes.Black, 520, y);
                g.DrawString($"{item.ThanhTien:N0}", fontRegular, Brushes.Black, 640, y);
                y += 25;
                idx++;
            }

            g.DrawLine(Pens.Black, 50, y, 750, y);
            y += 15;
            g.DrawString($"TỔNG CỘNG: {tongTien:N0} VNĐ", fontHeader, Brushes.DarkRed, 500, y);
            y += 50;

            g.DrawString("Người lập phiếu", fontItalic, Brushes.Black, 100, y);
            g.DrawString("Khách hàng ký nhận", fontItalic, Brushes.Black, 550, y);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
                sfd.FileName = $"BaoCaoDonHang_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        bool ok = Helpers.ExcelHelper.ExportDataGridViewToExcel(
                            dgvOrders,
                            sfd.FileName,
                            "DonHang",
                            "BÁO CÁO DANH SÁCH ĐƠN HÀNG TOÀN HỆ THỐNG",
                            out string err
                        );
                        if (ok)
                        {
                            var ask = MessageBox.Show($"Xuất báo cáo Excel thành công!\n\nĐường dẫn: {sfd.FileName}\n\nBạn có muốn mở file ngay không?",
                                                      "Thành Công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ask == DialogResult.Yes) { try { System.Diagnostics.Process.Start(sfd.FileName); } catch { } }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi xuất Excel: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    var sb = new StringBuilder();
                    sb.AppendLine("=== BÁO CÁO DANH SÁCH ĐƠN HÀNG ===");
                    sb.AppendLine($"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine(new string('-', 80));
                    sb.AppendLine(string.Format("{0,-8} | {1,-25} | {2,-12} | {3,-15} | {4,-15}",
                                  "Mã Đơn", "Khách Hàng", "SĐT", "Tổng Tiền", "Trạng Thái"));
                    sb.AppendLine(new string('-', 80));

                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        sb.AppendLine(string.Format("#{0,-7} | {1,-25} | {2,-12} | {3,15:N0} | {4,-15}",
                                      row.Cells["SoThuTu"].Value,
                                      row.Cells["TenKhachHang"].Value,
                                      row.Cells["SoDienThoaiGiaoHang"].Value,
                                      row.Cells["TongTien"].Value,
                                      row.Cells["TrangThai"].Value));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
