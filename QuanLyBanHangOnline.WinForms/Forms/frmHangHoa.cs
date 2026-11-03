using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmHangHoa : System.Windows.Forms.Form
    {
        private readonly HangHoaRepository _hangHoaRepo = new HangHoaRepository();
        private readonly LoaiHangRepository _loaiRepo = new LoaiHangRepository();
        private readonly NhaSanXuatRepository _nsxRepo = new NhaSanXuatRepository();
        private bool _isEditing = false;

        public frmHangHoa()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
            LoadData();
        }

        private void LoadComboboxes()
        {
            cboLoaiHang.DataSource = _loaiRepo.GetAll();
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "MaLoai";

            cboNSX.DataSource = _nsxRepo.GetAll();
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";
        }

        private void LoadData()
        {
            var list = _hangHoaRepo.GetAll();
            dgvHangHoa.DataSource = list;

            if (dgvHangHoa.Columns["MaHang"] != null) dgvHangHoa.Columns["MaHang"].HeaderText = "Mã Hàng";
            if (dgvHangHoa.Columns["TenHang"] != null) dgvHangHoa.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            if (dgvHangHoa.Columns["TenLoai"] != null) dgvHangHoa.Columns["TenLoai"].HeaderText = "Loại Hàng";
            if (dgvHangHoa.Columns["TenNSX"] != null) dgvHangHoa.Columns["TenNSX"].HeaderText = "Nơi SX";
            if (dgvHangHoa.Columns["MauSac"] != null) dgvHangHoa.Columns["MauSac"].HeaderText = "Màu";
            if (dgvHangHoa.Columns["GiaBan"] != null)
            {
                dgvHangHoa.Columns["GiaBan"].HeaderText = "Giá Bán (VNĐ)";
                dgvHangHoa.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
            if (dgvHangHoa.Columns["NgayNhapKho"] != null)
            {
                dgvHangHoa.Columns["NgayNhapKho"].HeaderText = "Ngày Nhập";
                dgvHangHoa.Columns["NgayNhapKho"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvHangHoa.Columns["SoLuong"] != null) dgvHangHoa.Columns["SoLuong"].HeaderText = "Tồn Kho";
            if (dgvHangHoa.Columns["TinhTrang"] != null) dgvHangHoa.Columns["TinhTrang"].HeaderText = "Tình Trạng";

            if (dgvHangHoa.Columns["MaLoai"] != null) dgvHangHoa.Columns["MaLoai"].Visible = false;
            if (dgvHangHoa.Columns["MaNSX"] != null) dgvHangHoa.Columns["MaNSX"].Visible = false;
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHangHoa.Rows[e.RowIndex];
                txtMaHang.Text = row.Cells["MaHang"].Value?.ToString();
                txtMaHang.Enabled = false; // Khóa mã khi chỉnh sửa
                _isEditing = true;

                txtTenHang.Text = row.Cells["TenHang"].Value?.ToString();
                cboLoaiHang.SelectedValue = row.Cells["MaLoai"].Value?.ToString();
                cboNSX.SelectedValue = row.Cells["MaNSX"].Value?.ToString();
                txtMauSac.Text = row.Cells["MauSac"].Value?.ToString();

                if (decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out decimal gia))
                    numGiaBan.Value = gia;

                if (DateTime.TryParse(row.Cells["NgayNhapKho"].Value?.ToString(), out DateTime dt))
                    dtpNgayNhap.Value = dt;

                if (int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int sl))
                    numSoLuong.Value = sl;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(maHang) || maHang.Length != 4)
            {
                MessageBox.Show("Mã hàng bắt buộc phải đúng 4 ký tự! (Ví dụ: HH09)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            string tenHang = txtTenHang.Text.Trim();
            if (string.IsNullOrEmpty(tenHang))
            {
                MessageBox.Show("Tên hàng hóa không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }

            var hh = new HangHoa
            {
                MaHang = maHang,
                TenHang = tenHang,
                MaLoai = cboLoaiHang.SelectedValue?.ToString(),
                MaNSX = cboNSX.SelectedValue?.ToString(),
                MauSac = txtMauSac.Text.Trim(),
                GiaBan = numGiaBan.Value,
                NgayNhapKho = dtpNgayNhap.Value,
                SoLuong = (int)numSoLuong.Value
            };

            bool ok = _hangHoaRepo.Add(hh, out string err);
            if (ok)
            {
                MessageBox.Show("Thêm hàng hóa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenHang = txtTenHang.Text.Trim();
            if (string.IsNullOrEmpty(tenHang))
            {
                MessageBox.Show("Tên hàng hóa không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }

            var hh = new HangHoa
            {
                MaHang = txtMaHang.Text.Trim(),
                TenHang = tenHang,
                MaLoai = cboLoaiHang.SelectedValue?.ToString(),
                MaNSX = cboNSX.SelectedValue?.ToString(),
                MauSac = txtMauSac.Text.Trim(),
                GiaBan = numGiaBan.Value,
                NgayNhapKho = dtpNgayNhap.Value,
                SoLuong = (int)numSoLuong.Value
            };

            bool ok = _hangHoaRepo.Update(hh, out string err);
            if (ok)
            {
                MessageBox.Show("Cập nhật hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaHang.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hàng hóa [{ma}] không?",
                                         "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool ok = _hangHoaRepo.Delete(ma, out string err);
                if (ok)
                {
                    MessageBox.Show("Đã xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            txtMaHang.Enabled = true;
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtMauSac.Clear();
            numGiaBan.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
            if (cboNSX.Items.Count > 0) cboNSX.SelectedIndex = 0;
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            var all = _hangHoaRepo.GetAll();
            if (string.IsNullOrEmpty(kw))
            {
                dgvHangHoa.DataSource = all;
            }
            else
            {
                // LINQ Where tìm kiếm
                dgvHangHoa.DataSource = all.Where(h => h.TenHang.ToLower().Contains(kw) || h.MaHang.ToLower().Contains(kw)).ToList();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hàng hóa để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"DanhSachHangHoa_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "Xuất Danh Sách Hàng Hóa Ra File Excel (.xlsx)";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bool ok = Helpers.ExcelHelper.ExportDataGridViewToExcel(
                        dgvHangHoa,
                        sfd.FileName,
                        "Danh Mục Hàng Hóa",
                        "BÁO CÁO DANH MỤC HÀNG HÓA & TỒN KHO",
                        out string err
                    );

                    if (ok)
                    {
                        var ask = MessageBox.Show($"Xuất file Excel thành công!\n\nĐường dẫn: {sfd.FileName}\n\nBạn có muốn mở file ngay bây giờ không?",
                                                  "Xuất Excel Thành Công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ask == DialogResult.Yes)
                        {
                            try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xuất Excel: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                ofd.Title = "Chọn file Excel (.xlsx) chứa danh mục hàng hóa cần Import";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var confirm = MessageBox.Show(
                        $"Bạn có chắc chắn muốn nhập dữ liệu từ file:\n{ofd.FileName} vào hệ thống?\n\n" +
                        "• Nếu mã hàng đã tồn tại: Hệ thống sẽ cập nhật thông tin và cộng dồn tồn kho.\n" +
                        "• Nếu mã hàng chưa có: Hệ thống sẽ tự động thêm mới vào CSDL.",
                        "Xác nhận Import Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        bool ok = Helpers.ExcelHelper.ImportHangHoaFromExcel(ofd.FileName, out int added, out int updated, out string err);
                        if (ok)
                        {
                            MessageBox.Show(
                                $"Import dữ liệu từ Excel thành công!\n\n" +
                                $"• Số sản phẩm thêm mới: {added}\n" +
                                $"• Số sản phẩm cập nhật: {updated}\n" +
                                $"• Tổng cộng: {added + updated} mặt hàng",
                                "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData(); // Nạp lại bảng
                        }
                        else
                        {
                            MessageBox.Show("Import thất bại:\n" + err, "Lỗi Import Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnTemplateExcel_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "Mau_Nhap_Hang_Hoa_Chuan.xlsx";
                sfd.Title = "Lưu file Excel mẫu nhập hàng hóa";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bool ok = Helpers.ExcelHelper.CreateHangHoaImportTemplate(sfd.FileName, out string err);
                    if (ok)
                    {
                        var ask = MessageBox.Show($"Đã tạo file mẫu Excel thành công tại:\n{sfd.FileName}\n\nBạn có muốn mở file mẫu để xem ngay không?",
                                                  "Thành Công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ask == DialogResult.Yes)
                        {
                            try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi tạo file mẫu: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
