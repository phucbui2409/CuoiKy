using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.Helpers
{
    /// <summary>
    /// Tiện ích Xuất / Nhập Excel định dạng .xlsx chuẩn quốc tế sử dụng thư viện EPPlus
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// Xuất dữ liệu DataGridView ra file Excel (.xlsx) với định dạng bảng biểu, tiêu đề, đường viền và auto-fit cột
        /// </summary>
        public static bool ExportDataGridViewToExcel(DataGridView dgv, string filePath, string sheetTitle, string reportTitle, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (dgv == null || dgv.Rows.Count == 0)
            {
                errorMessage = "Không có dữ liệu trong bảng để xuất file Excel!";
                return false;
            }

            try
            {
                // Đảm bảo thư mục tồn tại
                string dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets.Add(string.IsNullOrWhiteSpace(sheetTitle) ? "Báo Cáo" : sheetTitle);
                    ws.View.ShowGridLines = true;

                    int currentRow = 1;

                    // 1. Dòng tiêu đề báo cáo
                    if (!string.IsNullOrWhiteSpace(reportTitle))
                    {
                        var visibleColsCount = dgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                        if (visibleColsCount > 0)
                        {
                            ws.Cells[currentRow, 1, currentRow, visibleColsCount].Merge = true;
                            ws.Cells[currentRow, 1].Value = reportTitle.ToUpper();
                            ws.Cells[currentRow, 1].Style.Font.Name = "Segoe UI";
                            ws.Cells[currentRow, 1].Style.Font.Size = 14;
                            ws.Cells[currentRow, 1].Style.Font.Bold = true;
                            ws.Cells[currentRow, 1].Style.Font.Color.SetColor(Color.FromArgb(21, 101, 192));
                            ws.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[currentRow, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Row(currentRow).Height = 35;
                            currentRow += 2;
                        }
                    }

                    // 2. Dòng thông tin ngày xuất
                    int totalCols = dgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                    ws.Cells[currentRow, 1, currentRow, totalCols].Merge = true;
                    ws.Cells[currentRow, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Hệ Thống Quản Lý Bán Hàng Online";
                    ws.Cells[currentRow, 1].Style.Font.Italic = true;
                    ws.Cells[currentRow, 1].Style.Font.Size = 9;
                    ws.Cells[currentRow, 1].Style.Font.Color.SetColor(Color.FromArgb(100, 116, 139));
                    currentRow++;

                    // 3. Header bảng
                    int headerRow = currentRow;
                    int colIndex = 1;

                    var visibleColumns = dgv.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .OrderBy(c => c.DisplayIndex)
                        .ToList();

                    foreach (var col in visibleColumns)
                    {
                        var cell = ws.Cells[headerRow, colIndex];
                        cell.Value = col.HeaderText;
                        cell.Style.Font.Name = "Segoe UI";
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.Size = 10;
                        cell.Style.Font.Color.SetColor(Color.White);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(21, 101, 192));
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(200, 200, 200));

                        colIndex++;
                    }
                    ws.Row(headerRow).Height = 26;
                    currentRow++;

                    // 4. Đổ dữ liệu hàng (Data rows)
                    int dataStartRow = currentRow;
                    for (int r = 0; r < dgv.Rows.Count; r++)
                    {
                        var dgvRow = dgv.Rows[r];
                        if (dgvRow.IsNewRow) continue;

                        colIndex = 1;
                        foreach (var col in visibleColumns)
                        {
                            var cell = ws.Cells[currentRow, colIndex];
                            object val = dgvRow.Cells[col.Index].Value;

                            if (val != null)
                            {
                                if (val is decimal || val is double || val is float || val is int || val is long)
                                {
                                    cell.Value = Convert.ToDouble(val);
                                    if (col.HeaderText.ToLower().Contains("giá") || col.HeaderText.ToLower().Contains("tiền") || col.HeaderText.ToLower().Contains("thu"))
                                    {
                                        cell.Style.Numberformat.Format = "#,##0";
                                    }
                                }
                                else if (val is DateTime dt)
                                {
                                    cell.Value = dt;
                                    cell.Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
                                }
                                else
                                {
                                    cell.Value = val.ToString();
                                }
                            }
                            else
                            {
                                cell.Value = "";
                            }

                            cell.Style.Font.Name = "Segoe UI";
                            cell.Style.Font.Size = 9.5F;
                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            // Căn lề theo kiểu dữ liệu
                            if (col.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
                            {
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            else if (col.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                            {
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            // Màu xen kẽ
                            if (r % 2 == 1)
                            {
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(248, 250, 252));
                            }

                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(226, 232, 240));
                            colIndex++;
                        }
                        ws.Row(currentRow).Height = 22;
                        currentRow++;
                    }

                    // 5. Tự động giãn độ rộng cột
                    ws.Cells[headerRow, 1, currentRow - 1, visibleColumns.Count].AutoFitColumns(12, 45);

                    package.Save();
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Tạo file Excel mẫu (.xlsx) danh mục hàng hóa để người dùng/giảng viên dùng import
        /// </summary>
        public static bool CreateHangHoaImportTemplate(string filePath, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (File.Exists(filePath)) File.Delete(filePath);

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets.Add("DanhMucHangHoa");

                    // Header
                    string[] headers = new string[] {
                        "Mã Hàng (* 4 ký tự)",
                        "Tên Hàng Hóa (*)",
                        "Mã Loại (THOITRANG / DIENTU / GPOADUNG)",
                        "Mã NSX (NSX01 / NSX02 / NSX03 / NSX04)",
                        "Màu Sắc",
                        "Giá Bán (VND)",
                        "Số Lượng Tồn"
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cells[1, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.Color.SetColor(Color.White);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(46, 125, 50)); // Green
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    // Dữ liệu mẫu (3 dòng mẫu)
                    object[,] sampleData = new object[,]
                    {
                        { "HH11", "Bàn phím cơ không dây Bluetooth", "DIENTU", "NSX04", "Đen RGB", 950000, 30 },
                        { "HH12", "Áo thun Polo thể thao nam cao cấp", "THOITRANG", "NSX01", "Xanh Navy", 299000, 60 },
                        { "HH13", "Máy xay sinh tố đa năng Sunhouse", "GPOADUNG", "NSX03", "Trắng", 680000, 25 }
                    };

                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 7; c++)
                        {
                            var cell = ws.Cells[r + 2, c + 1];
                            cell.Value = sampleData[r, c];
                            if (c == 5 || c == 6)
                            {
                                cell.Style.Numberformat.Format = "#,##0";
                            }
                        }
                    }

                    ws.Cells.AutoFitColumns();
                    package.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Import danh mục hàng hóa từ file Excel (.xlsx) vào Cơ Sở Dữ Liệu SQL Server
        /// </summary>
        public static bool ImportHangHoaFromExcel(string filePath, out int addedCount, out int updatedCount, out string errorMessage)
        {
            addedCount = 0;
            updatedCount = 0;
            errorMessage = string.Empty;

            if (!File.Exists(filePath))
            {
                errorMessage = "File Excel không tồn tại!";
                return false;
            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        errorMessage = "File Excel không chứa bất kỳ trang tính (Worksheet) nào!";
                        return false;
                    }

                    var ws = package.Workbook.Worksheets[1]; // Sheet đầu tiên (1-based index)
                    int rowCount = ws.Dimension != null ? ws.Dimension.Rows : 0;

                    if (rowCount < 2)
                    {
                        errorMessage = "File Excel không có dữ liệu hàng hóa (ít nhất cần 1 dòng tiêu đề và 1 dòng dữ liệu)!";
                        return false;
                    }

                    // Xác định chỉ số cột
                    int colMaHang = 1;
                    int colTenHang = 2;
                    int colMaLoai = 3;
                    int colMaNSX = 4;
                    int colMauSac = 5;
                    int colGiaBan = 6;
                    int colSoLuong = 7;

                    using (var db = DbContextHelper.GetContext())
                    {
                        for (int row = 2; row <= rowCount; row++)
                        {
                            string maHang = ws.Cells[row, colMaHang].Value?.ToString()?.Trim()?.ToUpper();
                            string tenHang = ws.Cells[row, colTenHang].Value?.ToString()?.Trim();
                            string maLoai = ws.Cells[row, colMaLoai].Value?.ToString()?.Trim()?.ToUpper();
                            string maNSX = ws.Cells[row, colMaNSX].Value?.ToString()?.Trim()?.ToUpper();
                            string mauSac = ws.Cells[row, colMauSac].Value?.ToString()?.Trim() ?? "Tiêu chuẩn";

                            // Bỏ qua dòng trống
                            if (string.IsNullOrWhiteSpace(maHang) && string.IsNullOrWhiteSpace(tenHang))
                                continue;

                            if (string.IsNullOrEmpty(maHang) || maHang.Length != 4)
                            {
                                errorMessage = $"Dòng {row}: Mã hàng '{maHang}' không hợp lệ (Mã hàng phải gồm đúng 4 ký tự, ví dụ: HH09).";
                                return false;
                            }

                            if (string.IsNullOrEmpty(tenHang))
                            {
                                errorMessage = $"Dòng {row}: Tên hàng hóa không được để trống!";
                                return false;
                            }

                            decimal giaBan = 0;
                            if (ws.Cells[row, colGiaBan].Value != null)
                            {
                                decimal.TryParse(ws.Cells[row, colGiaBan].Value.ToString(), out giaBan);
                            }

                            int soLuong = 0;
                            if (ws.Cells[row, colSoLuong].Value != null)
                            {
                                int.TryParse(ws.Cells[row, colSoLuong].Value.ToString(), out soLuong);
                            }

                            // Kiểm tra mã loại tồn tại, nếu không có lấy loại mặc định
                            if (string.IsNullOrEmpty(maLoai) || !db.LoaiHangs.Any(l => l.MaLoai == maLoai))
                            {
                                maLoai = db.LoaiHangs.Select(l => l.MaLoai).FirstOrDefault() ?? "THOITRANG";
                            }

                            // Kiểm tra mã NSX tồn tại, nếu không có lấy NSX mặc định
                            if (string.IsNullOrEmpty(maNSX) || !db.NhaSanXuats.Any(n => n.MaNSX == maNSX))
                            {
                                maNSX = db.NhaSanXuats.Select(n => n.MaNSX).FirstOrDefault() ?? "NSX01";
                            }

                            // Kiểm tra xem sản phẩm đã có trong CSDL chưa
                            var existing = db.HangHoas.FirstOrDefault(h => h.MaHang == maHang);
                            if (existing != null)
                            {
                                // Cập nhật hàng hóa hiện có
                                existing.TenHang = tenHang;
                                existing.MaLoai = maLoai;
                                existing.MaNSX = maNSX;
                                existing.MauSac = mauSac;
                                existing.GiaBan = giaBan;
                                existing.SoLuong += soLuong; // Cộng dồn số lượng nhập
                                updatedCount++;
                            }
                            else
                            {
                                // Thêm mới hàng hóa
                                var newHang = new HangHoa
                                {
                                    MaHang = maHang,
                                    TenHang = tenHang,
                                    MaLoai = maLoai,
                                    MaNSX = maNSX,
                                    MauSac = mauSac,
                                    GiaBan = giaBan,
                                    SoLuong = soLuong,
                                    NgayNhapKho = DateTime.Now
                                };
                                db.HangHoas.InsertOnSubmit(newHang);
                                addedCount++;
                            }
                        }

                        db.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
