using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Models;
using QuanLyBanHangOnline.WinForms.Repositories;
using QuanLyBanHangOnline.WinForms.UIExtension;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmChartDashboard : Form
    {
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();
        private List<DonHangViewModel> _currentFilteredList = new List<DonHangViewModel>();
        private bool _isInitializing = true;

        public frmChartDashboard()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            // Khởi tạo ComboBox Năm (2026, 2025, 2024...)
            cboYear.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear + 1; y >= currentYear - 3; y--)
            {
                cboYear.Items.Add(y);
            }
            cboYear.SelectedItem = currentYear;

            // Khởi tạo ComboBox Tháng (Tất cả 12 tháng, Tháng 1..12)
            cboMonth.Items.Clear();
            cboMonth.Items.Add("Tất cả các tháng");
            for (int m = 1; m <= 12; m++)
            {
                cboMonth.Items.Add($"Tháng {m}");
            }
            cboMonth.SelectedIndex = 0; // Mặc định cả năm

            // Khởi tạo Tiêu chí trạng thái đơn
            cboCriterion.SelectedIndex = 0; // Tất cả đơn hàng

            _isInitializing = false;

            // Thực hiện thống kê và vẽ biểu đồ ngay khi mở form
            ThucHienThongKe();
        }

        private void FilterControls_Changed(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            ThucHienThongKe();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ThucHienThongKe();
        }

        private void ThucHienThongKe()
        {
            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            int selectedMonth = cboMonth.SelectedIndex > 0 ? cboMonth.SelectedIndex : 0;

            // 1. Xác định tiêu chí trạng thái
            string filterStatus = "ALL";
            switch (cboCriterion.SelectedIndex)
            {
                case 1: filterStatus = "Đã xử lí"; break;
                case 2: filterStatus = "Chờ xử lí"; break;
                case 3: filterStatus = "Đã hủy"; break;
                default: filterStatus = "ALL"; break;
            }

            // 2. Lấy dữ liệu đơn hàng trong kỳ
            DateTime fromDate = selectedMonth > 0 ? new DateTime(selectedYear, selectedMonth, 1) : new DateTime(selectedYear, 1, 1);
            DateTime toDate = selectedMonth > 0 ? 
                (selectedMonth == 12 ? new DateTime(selectedYear + 1, 1, 1).AddSeconds(-1) : new DateTime(selectedYear, selectedMonth + 1, 1).AddSeconds(-1)) : 
                new DateTime(selectedYear + 1, 1, 1).AddSeconds(-1);

            var all = _donHangRepo.GetAllOrders(filterStatus, fromDate, toDate);
            _currentFilteredList = all;

            // 3. Tính toán các chỉ số KPI bằng LINQ Sum & Count & Average
            decimal tongDoanhThu = _currentFilteredList.Sum(d => d.TongTien);
            int tongSoDon = _currentFilteredList.Count();
            decimal donTrungBinh = tongSoDon > 0 ? _currentFilteredList.Average(d => d.TongTien) : 0;

            // Tính tổng sản phẩm đã bán ra bằng LINQ Sum
            int tongSanPham = 0;
            foreach (var ord in _currentFilteredList)
            {
                var ct = _donHangRepo.LayChiTietDonHang(ord.SoThuTu);
                tongSanPham += ct.Sum(x => x.SoLuong);
            }

            // Hiển thị KPI lên Cards
            lblTotalRevenue.Text = $"{tongDoanhThu:N0} VND";
            lblTotalOrders.Text = $"{tongSoDon} Đơn";
            lblAvgOrder.Text = $"{donTrungBinh:N0} VND";
            lblTotalProductsSold.Text = $"{tongSanPham} Món";

            // 4. Vẽ Biểu đồ 1: LINE CHART - Doanh thu 12 tháng trong năm
            VeBieuDoLine12Thang(selectedYear, filterStatus);

            // 5. Vẽ Biểu đồ 2: COLUMN / BAR CHART - Top 5 sản phẩm bán chạy nhất trong tháng
            VeBieuDoColumnTop5(selectedYear, selectedMonth);

            // 6. Vẽ Biểu đồ 3: PIE / DOUGHNUT CHART - Tỷ lệ doanh thu theo Danh mục hàng hóa
            VeBieuDoPieDanhMuc(selectedYear, selectedMonth);

            // 7. Cập nhật Grid chi tiết đơn hàng
            HienThiGridDetails();
        }

        // =========================================================================
        // 1. VẼ BIỂU ĐỒ ĐƯỜNG (LINE / SPLINE CHART): DOANH THU 12 THÁNG TRONG NĂM
        // Kỹ thuật: LINQ GroupBy(d => d.NgayDatHang.Month) và Sum(TongTien)
        // =========================================================================
        private void VeBieuDoLine12Thang(int nam, string trangThai)
        {
            var data12Thang = _donHangRepo.ThongKeDoanhThu12Thang(nam, trangThai);

            SeriesChartType chartType = radLine.Checked ? SeriesChartType.Line : SeriesChartType.Spline;

            // Vẽ lên Chart nhỏ ở Tab Tổng quan
            VeLineChartInternal(chartOverviewLine, data12Thang, chartType, isOverview: true, nam: nam);

            // Vẽ lên Chart lớn ở Tab Chi tiết
            VeLineChartInternal(chartDetailLine, data12Thang, chartType, isOverview: false, nam: nam);
        }

        private void VeLineChartInternal(Chart chart, List<ThongKeThangModel> data, SeriesChartType type, bool isOverview, int nam)
        {
            chart.Series.Clear();

            Series series = new Series("DoanhThu")
            {
                ChartType = type,
                Color = Color.FromArgb(30, 136, 229),
                BorderWidth = isOverview ? 3 : 4,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = isOverview ? 6 : 9,
                MarkerColor = Color.FromArgb(13, 71, 161),
                MarkerBorderColor = Color.White,
                MarkerBorderWidth = 1,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", isOverview ? 7.5F : 9F, FontStyle.Bold)
            };

            foreach (var item in data)
            {
                int idx = series.Points.AddXY(item.TenThang, item.DoanhThu);
                series.Points[idx].ToolTip = $"{item.TenThang}/{nam}: {item.DoanhThu:N0} VND ({item.SoLuongDon} đơn hàng)";

                if (item.DoanhThu > 0)
                {
                    series.Points[idx].Label = item.DoanhThu >= 1000000 ? $"{item.DoanhThu / 1000000.0m:F1}tr" : $"{item.DoanhThu / 1000m:N0}k";
                    series.Points[idx].LabelForeColor = Color.FromArgb(13, 71, 161);
                }
                else
                {
                    series.Points[idx].Label = "";
                }
            }

            chart.Series.Add(series);

            if (chart.ChartAreas.Count > 0)
            {
                var ca = chart.ChartAreas[0];
                ca.AxisX.Interval = 1;
                ca.AxisX.MajorGrid.LineColor = Color.FromArgb(238, 242, 246);
                ca.AxisY.MajorGrid.LineColor = Color.FromArgb(238, 242, 246);
                ca.AxisX.LabelStyle.Font = new Font("Segoe UI", isOverview ? 8F : 9F);
                ca.AxisY.LabelStyle.Font = new Font("Segoe UI", isOverview ? 8F : 9F);
                ca.AxisY.LabelStyle.Format = "N0";
            }

            if (chart.Titles.Count > 0)
            {
                chart.Titles[0].Text = isOverview ? 
                    $"1. DOANH THU 12 THÁNG NĂM {nam} (LINE)" : 
                    $"ĐƯỜNG XU HƯỚNG DOANH THU 12 THÁNG TRONG NĂM {nam} (VND)";
            }
        }

        private void LineChartType_CheckedChanged(object sender, EventArgs e)
        {
            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            string filterStatus = cboCriterion.SelectedIndex == 1 ? "Đã xử lí" : (cboCriterion.SelectedIndex == 2 ? "Chờ xử lí" : (cboCriterion.SelectedIndex == 3 ? "Đã hủy" : "ALL"));
            VeBieuDoLine12Thang(selectedYear, filterStatus);
        }

        // =========================================================================
        // 2. VẼ BIỂU ĐỒ CỘT (COLUMN / BAR CHART): TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
        // Kỹ thuật: LINQ GroupBy(ct => ct.MaHang), Sum(SoLuong), OrderByDescending, Take(5)
        // =========================================================================
        private void VeBieuDoColumnTop5(int nam, int thang)
        {
            var top5 = _donHangRepo.GetTop5ProductsInMonth(nam, thang);

            SeriesChartType chartType = radBar.Checked ? SeriesChartType.Bar : SeriesChartType.Column;

            VeColumnChartInternal(chartOverviewColumn, top5, chartType, isOverview: true, nam: nam, thang: thang);
            VeColumnChartInternal(chartDetailColumn, top5, chartType, isOverview: false, nam: nam, thang: thang);
        }

        private void VeColumnChartInternal(Chart chart, List<TopSanPhamModel> top5, SeriesChartType type, bool isOverview, int nam, int thang)
        {
            chart.Series.Clear();

            Series series = new Series("Top5")
            {
                ChartType = type,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", isOverview ? 8F : 9F, FontStyle.Bold)
            };

            Color[] palette = new Color[]
            {
                Color.FromArgb(21, 101, 192),  // Xanh dương
                Color.FromArgb(0, 137, 123),   // Xanh ngọc
                Color.FromArgb(251, 140, 0),   // Cam đậm
                Color.FromArgb(142, 36, 170),  // Tím
                Color.FromArgb(229, 57, 53)    // Đỏ
            };

            if (top5.Count == 0)
            {
                series.Points.AddXY("Chưa có dữ liệu", 0);
            }
            else
            {
                for (int i = 0; i < top5.Count; i++)
                {
                    var p = top5[i];
                    string shortName = p.TenHang.Length > 16 ? p.TenHang.Substring(0, 14) + ".." : p.TenHang;
                    int idx = series.Points.AddXY(shortName, p.TongSoLuongBan);
                    series.Points[idx].Color = palette[i % palette.Length];
                    series.Points[idx].Label = $"{p.TongSoLuongBan} cái";
                    series.Points[idx].ToolTip = $"{p.TenHang}\nSố lượng bán: {p.TongSoLuongBan} cái\nDoanh thu: {p.TongDoanhThu:N0} VND";
                    series.Points[idx].LegendText = p.TenHang;
                }
            }

            chart.Series.Add(series);

            if (chart.ChartAreas.Count > 0)
            {
                var ca = chart.ChartAreas[0];
                ca.AxisX.Interval = 1;
                ca.AxisX.MajorGrid.LineColor = Color.FromArgb(238, 242, 246);
                ca.AxisY.MajorGrid.LineColor = Color.FromArgb(238, 242, 246);
                ca.AxisX.LabelStyle.Font = new Font("Segoe UI", isOverview ? 7.5F : 8.5F);
                ca.AxisY.LabelStyle.Font = new Font("Segoe UI", isOverview ? 7.5F : 8.5F);
            }

            string kyThoiGian = thang > 0 ? $"THÁNG {thang}/{nam}" : $"NĂM {nam}";
            if (chart.Titles.Count > 0)
            {
                chart.Titles[0].Text = isOverview ? 
                    $"2. TOP 5 SẢN PHẨM BÁN CHẠY ({kyThoiGian})" : 
                    $"TOP 5 SẢN PHẨM BÁN CHẠY NHẤT ({kyThoiGian})";
            }
        }

        private void ColumnChartType_CheckedChanged(object sender, EventArgs e)
        {
            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            int selectedMonth = cboMonth.SelectedIndex > 0 ? cboMonth.SelectedIndex : 0;
            VeBieuDoColumnTop5(selectedYear, selectedMonth);
        }

        // =========================================================================
        // 3. VẼ BIỂU ĐỒ TRÒN / VÀNH KHUYÊN (PIE / DOUGHNUT CHART): TỶ LỆ DOANH THU THEO DANH MỤC
        // Kỹ thuật: LINQ Join HangHoa & LoaiHang, GroupBy(LoaiHang), Sum(ThanhTien)
        // =========================================================================
        private void VeBieuDoPieDanhMuc(int nam, int thang)
        {
            SeriesChartType chartType = chkDoughnut.Checked ? SeriesChartType.Doughnut : SeriesChartType.Pie;

            if (radCategory.Checked)
            {
                // Thống kê theo Danh mục hàng hóa
                var catData = _donHangRepo.ThongKeDoanhThuTheoDanhMuc(nam, thang);
                VePieCategoryInternal(chartOverviewPie, catData, chartType, isOverview: true, nam: nam, thang: thang);
                VePieCategoryInternal(chartDetailPie, catData, chartType, isOverview: false, nam: nam, thang: thang);
            }
            else
            {
                // Thống kê theo Trạng thái đơn hàng
                var statusData = _donHangRepo.ThongKeTheoTrangThai(nam, thang);
                VePieStatusInternal(chartOverviewPie, statusData, chartType, isOverview: true, nam: nam, thang: thang);
                VePieStatusInternal(chartDetailPie, statusData, chartType, isOverview: false, nam: nam, thang: thang);
            }
        }

        private void VePieCategoryInternal(Chart chart, List<ThongKeDanhMucModel> data, SeriesChartType type, bool isOverview, int nam, int thang)
        {
            chart.Series.Clear();

            Series series = new Series("DanhMuc")
            {
                ChartType = type,
                Font = new Font("Segoe UI", isOverview ? 8F : 9F, FontStyle.Bold),
                IsValueShownAsLabel = true
            };

            Color[] colors = new Color[]
            {
                Color.FromArgb(30, 136, 229),  // Xanh dương
                Color.FromArgb(67, 160, 71),   // Xanh lá
                Color.FromArgb(251, 140, 0),   // Cam
                Color.FromArgb(142, 36, 170),  // Tím
                Color.FromArgb(0, 172, 193)    // Lam ngọc
            };

            if (data.Count == 0)
            {
                series.Points.AddXY("Không có dữ liệu", 1);
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var c = data[i];
                    int idx = series.Points.AddXY(c.TenLoai, c.TongDoanhThu);
                    series.Points[idx].Color = colors[i % colors.Length];
                    series.Points[idx].LegendText = $"{c.TenLoai} ({c.TyLePhanTram:F1}%)";
                    series.Points[idx].Label = $"{c.TyLePhanTram:F1}%";
                    series.Points[idx].ToolTip = $"{c.TenLoai}\nDoanh thu: {c.TongDoanhThu:N0} VND ({c.TyLePhanTram:F1}%)\nTổng bán: {c.TongSoLuong} sản phẩm";
                }
            }

            chart.Series.Add(series);

            string kyThoiGian = thang > 0 ? $"T{thang}/{nam}" : $"{nam}";
            if (chart.Titles.Count > 0)
            {
                chart.Titles[0].Text = isOverview ? 
                    $"3. TỶ LỆ DANH MỤC HÀNG HÓA ({kyThoiGian})" : 
                    $"TỶ TRỌNG DOANH THU THEO DANH MỤC HÀNG HÓA ({kyThoiGian})";
            }
        }

        private void VePieStatusInternal(Chart chart, List<ThongKeTrangThaiModel> data, SeriesChartType type, bool isOverview, int nam, int thang)
        {
            chart.Series.Clear();

            Series series = new Series("TrangThai")
            {
                ChartType = type,
                Font = new Font("Segoe UI", isOverview ? 8F : 9F, FontStyle.Bold),
                IsValueShownAsLabel = true
            };

            Color[] colors = new Color[]
            {
                Color.FromArgb(67, 160, 71),   // Đã xử lí (Xanh lá)
                Color.FromArgb(251, 140, 0),   // Chờ xử lí (Cam)
                Color.FromArgb(229, 57, 53)    // Đã hủy (Đỏ)
            };

            if (data.Count == 0)
            {
                series.Points.AddXY("Không có dữ liệu", 1);
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var s = data[i];
                    int idx = series.Points.AddXY(s.TrangThai, s.SoLuongDon);
                    series.Points[idx].Color = colors[i % colors.Length];
                    series.Points[idx].LegendText = $"{s.TrangThai} ({s.TyLePhanTram:F1}%)";
                    series.Points[idx].Label = $"{s.TyLePhanTram:F1}%";
                    series.Points[idx].ToolTip = $"{s.TrangThai}\nSố đơn: {s.SoLuongDon} đơn ({s.TyLePhanTram:F1}%)\nTổng tiền: {s.TongTien:N0} VND";
                }
            }

            chart.Series.Add(series);

            string kyThoiGian = thang > 0 ? $"T{thang}/{nam}" : $"{nam}";
            if (chart.Titles.Count > 0)
            {
                chart.Titles[0].Text = isOverview ? 
                    $"3. TỶ LỆ THEO TRẠNG THÁI ĐƠN ({kyThoiGian})" : 
                    $"CƠ CẤU TRẠNG THÁI ĐƠN HÀNG ({kyThoiGian})";
            }
        }

        private void PieCriteria_CheckedChanged(object sender, EventArgs e)
        {
            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            int selectedMonth = cboMonth.SelectedIndex > 0 ? cboMonth.SelectedIndex : 0;
            VeBieuDoPieDanhMuc(selectedYear, selectedMonth);
        }

        private void chkDoughnut_CheckedChanged(object sender, EventArgs e)
        {
            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            int selectedMonth = cboMonth.SelectedIndex > 0 ? cboMonth.SelectedIndex : 0;
            VeBieuDoPieDanhMuc(selectedYear, selectedMonth);
        }

        // =========================================================================
        // HIỂN THỊ DỮ LIỆU ĐƠN HÀNG LÊN DATAGRIDVIEW
        // =========================================================================
        private void HienThiGridDetails()
        {
            var displayData = _currentFilteredList.Select((d, index) => new
            {
                STT = index + 1,
                MaDon = $"#{d.SoThuTu}",
                NgayDat = d.NgayDatHang.ToString("dd/MM/yyyy HH:mm"),
                KhachHang = d.TenKhachHang,
                DienThoai = d.SoDienThoaiGiaoHang,
                NhanVien = string.IsNullOrEmpty(d.MaNV) ? "Chưa chỉ định" : d.MaNV,
                TrangThai = d.TrangThai,
                DoanhThu = d.TongTien
            }).ToList();

            dgvDetails.DataSource = displayData;

            if (dgvDetails.Columns["STT"] != null) { dgvDetails.Columns["STT"].HeaderText = "STT"; dgvDetails.Columns["STT"].Width = 50; }
            if (dgvDetails.Columns["MaDon"] != null) { dgvDetails.Columns["MaDon"].HeaderText = "Mã Đơn"; dgvDetails.Columns["MaDon"].Width = 85; }
            if (dgvDetails.Columns["NgayDat"] != null) { dgvDetails.Columns["NgayDat"].HeaderText = "Ngày Đặt"; dgvDetails.Columns["NgayDat"].Width = 140; }
            if (dgvDetails.Columns["KhachHang"] != null) { dgvDetails.Columns["KhachHang"].HeaderText = "Khách Hàng"; }
            if (dgvDetails.Columns["DienThoai"] != null) { dgvDetails.Columns["DienThoai"].HeaderText = "SĐT Nhận"; dgvDetails.Columns["DienThoai"].Width = 115; }
            if (dgvDetails.Columns["NhanVien"] != null) { dgvDetails.Columns["NhanVien"].HeaderText = "Nhân Viên"; dgvDetails.Columns["NhanVien"].Width = 100; }
            if (dgvDetails.Columns["TrangThai"] != null) { dgvDetails.Columns["TrangThai"].HeaderText = "Trạng Thái"; dgvDetails.Columns["TrangThai"].Width = 110; }
            if (dgvDetails.Columns["DoanhThu"] != null)
            {
                dgvDetails.Columns["DoanhThu"].HeaderText = "Doanh Thu (VND)";
                dgvDetails.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                dgvDetails.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetails.Columns["DoanhThu"].Width = 150;
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (_currentFilteredList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đơn hàng trong khoảng thời gian này để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedYear = cboYear.SelectedItem != null ? Convert.ToInt32(cboYear.SelectedItem) : DateTime.Now.Year;
            int selectedMonth = cboMonth.SelectedIndex > 0 ? cboMonth.SelectedIndex : 0;
            DateTime fromDate = selectedMonth > 0 ? new DateTime(selectedYear, selectedMonth, 1) : new DateTime(selectedYear, 1, 1);
            DateTime toDate = selectedMonth > 0 ? 
                (selectedMonth == 12 ? new DateTime(selectedYear + 1, 1, 1).AddSeconds(-1) : new DateTime(selectedYear, selectedMonth + 1, 1).AddSeconds(-1)) : 
                new DateTime(selectedYear + 1, 1, 1).AddSeconds(-1);

            var fReport = new frmXemBaoCaoDoanhThuReport(
                fromDate,
                toDate,
                cboCriterion.Text,
                _currentFilteredList
            );
            fReport.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        bool ok = Helpers.ExcelHelper.ExportDataGridViewToExcel(
                            dgvDetails,
                            sfd.FileName,
                            "DoanhThu",
                            $"BÁO CÁO DOANH THU NĂM {cboYear.SelectedItem} ({cboMonth.SelectedItem})",
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
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Header with UTF-8 BOM
                        sb.AppendLine("HỆ THỐNG QUẢN LÝ BÁN HÀNG ONLINE - BÁO CÁO THỐNG KÊ DOANH THU");
                        sb.AppendLine($"Kỳ thống kê: Năm {cboYear.SelectedItem} - {cboMonth.SelectedItem}");
                        sb.AppendLine($"Tiêu chí lọc: {cboCriterion.Text}");
                        sb.AppendLine($"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        sb.AppendLine();

                        // Column headers
                        sb.AppendLine("STT,Mã Đơn,Ngày Đặt,Khách Hàng,Điện Thoại,Nhân Viên,Trạng Thái,Doanh Thu (VND)");

                        // Rows
                        for (int i = 0; i < dgvDetails.Rows.Count; i++)
                        {
                            var r = dgvDetails.Rows[i];
                            sb.AppendLine($"{r.Cells["STT"].Value},\"{r.Cells["MaDon"].Value}\",\"{r.Cells["NgayDat"].Value}\",\"{r.Cells["KhachHang"].Value}\",\"{r.Cells["DienThoai"].Value}\",\"{r.Cells["NhanVien"].Value}\",\"{r.Cells["TrangThai"].Value}\",{r.Cells["DoanhThu"].Value}");
                        }

                        // Summary
                        decimal tongDoanhThu = _currentFilteredList.Sum(d => d.TongTien);
                        sb.AppendLine();
                        sb.AppendLine($",,,,,,TỔNG DOANH THU:,{tongDoanhThu}");

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file báo cáo CSV thành công tại:\n" + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
