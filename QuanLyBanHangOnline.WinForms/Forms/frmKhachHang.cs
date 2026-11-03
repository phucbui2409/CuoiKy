using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmKhachHang : System.Windows.Forms.Form
    {
        private readonly KhachHangRepository _repo = new KhachHangRepository();
        private bool _isEditing = false;

        public frmKhachHang()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = _repo.GetAll();
            if (dgvKhachHang.Columns["MaKH"] != null) dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
            if (dgvKhachHang.Columns["HoTen"] != null) dgvKhachHang.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvKhachHang.Columns["DiaChi"] != null) dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            if (dgvKhachHang.Columns["SoDienThoai"] != null) dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            if (dgvKhachHang.Columns["Email"] != null) dgvKhachHang.Columns["Email"].HeaderText = "Email";
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
                txtMaKH.Enabled = false;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                _isEditing = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text.Trim().ToUpper();
            string ten = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            var item = new KhachHang
            {
                MaKH = ma,
                HoTen = ten,
                DiaChi = diaChi,
                SoDienThoai = sdt,
                Email = txtEmail.Text.Trim()
            };

            if (_repo.Add(item, out string err))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var item = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = ten,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (_repo.Update(item, out string err))
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaKH.Text.Trim();
            var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng [{ma}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (_repo.Delete(ma, out string err))
                {
                    MessageBox.Show("Đã xóa khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaKH.Enabled = true;
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
