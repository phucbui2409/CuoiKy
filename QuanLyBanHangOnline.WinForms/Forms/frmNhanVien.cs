using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmNhanVien : System.Windows.Forms.Form
    {
        private readonly NhanVienRepository _repo = new NhanVienRepository();
        private bool _isEditing = false;

        public frmNhanVien()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = _repo.GetAll();
            if (dgvNhanVien.Columns["MaNV"] != null) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns["HoTen"] != null) dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvNhanVien.Columns["GioiTinh"] != null) dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvNhanVien.Columns["NgaySinh"] != null)
            {
                dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvNhanVien.Columns["DiaChi"] != null) dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            if (dgvNhanVien.Columns["SoDienThoai"] != null) dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            if (dgvNhanVien.Columns["ChucVu"] != null) dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtMaNV.Enabled = false;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime dt))
                    dtpNgaySinh.Value = dt;
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
                _isEditing = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text.Trim().ToUpper();
            string ten = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var item = new NhanVien
            {
                MaNV = ma,
                HoTen = ten,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim()
            };

            if (_repo.Add(item, out string err))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var item = new NhanVien
            {
                MaNV = txtMaNV.Text.Trim(),
                HoTen = ten,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim()
            };

            if (_repo.Update(item, out string err))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaNV.Text.Trim();
            var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên [{ma}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (_repo.Delete(ma, out string err))
                {
                    MessageBox.Show("Đã xóa nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaNV.Enabled = true;
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtPhone.Clear();
            txtChucVu.Clear();
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
