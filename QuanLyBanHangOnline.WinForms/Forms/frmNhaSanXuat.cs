using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmNhaSanXuat : System.Windows.Forms.Form
    {
        private readonly NhaSanXuatRepository _repo = new NhaSanXuatRepository();
        private bool _isEditing = false;

        public frmNhaSanXuat()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvNSX.DataSource = _repo.GetAll();
            if (dgvNSX.Columns["MaNSX"] != null) dgvNSX.Columns["MaNSX"].HeaderText = "Mã NSX";
            if (dgvNSX.Columns["TenNSX"] != null) dgvNSX.Columns["TenNSX"].HeaderText = "Tên Nhà SX / Nơi SX";
            if (dgvNSX.Columns["QuocGia"] != null) dgvNSX.Columns["QuocGia"].HeaderText = "Quốc Gia";
            if (dgvNSX.Columns["DiaChi"] != null) dgvNSX.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            if (dgvNSX.Columns["SoDienThoai"] != null) dgvNSX.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
        }

        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNSX.Rows[e.RowIndex];
                txtMaNSX.Text = row.Cells["MaNSX"].Value?.ToString();
                txtMaNSX.Enabled = false;
                txtTenNSX.Text = row.Cells["TenNSX"].Value?.ToString();
                txtQuocGia.Text = row.Cells["QuocGia"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value?.ToString();
                _isEditing = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaNSX.Text.Trim().ToUpper();
            string ten = txtTenNSX.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Mã nhà sản xuất không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên nhà sản xuất không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNSX.Focus();
                return;
            }

            var item = new NhaSanXuat
            {
                MaNSX = ma,
                TenNSX = ten,
                QuocGia = txtQuocGia.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim()
            };

            if (_repo.Add(item, out string err))
            {
                MessageBox.Show("Thêm nhà sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn nhà sản xuất cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = txtTenNSX.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên nhà sản xuất không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNSX.Focus();
                return;
            }

            var item = new NhaSanXuat
            {
                MaNSX = txtMaNSX.Text.Trim(),
                TenNSX = ten,
                QuocGia = txtQuocGia.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim()
            };

            if (_repo.Update(item, out string err))
            {
                MessageBox.Show("Cập nhật nhà sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn nhà sản xuất cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaNSX.Text.Trim();
            var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà sản xuất [{ma}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (_repo.Delete(ma, out string err))
                {
                    MessageBox.Show("Đã xóa nhà sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaNSX.Enabled = true;
            txtMaNSX.Clear();
            txtTenNSX.Clear();
            txtQuocGia.Clear();
            txtDiaChi.Clear();
            txtPhone.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
