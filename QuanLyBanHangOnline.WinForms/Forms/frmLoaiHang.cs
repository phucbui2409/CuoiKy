using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmLoaiHang : System.Windows.Forms.Form
    {
        private readonly LoaiHangRepository _repo = new LoaiHangRepository();
        private bool _isEditing = false;

        public frmLoaiHang()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvLoaiHang.DataSource = _repo.GetAll();
            if (dgvLoaiHang.Columns["MaLoai"] != null) dgvLoaiHang.Columns["MaLoai"].HeaderText = "Mã Loại";
            if (dgvLoaiHang.Columns["TenLoai"] != null) dgvLoaiHang.Columns["TenLoai"].HeaderText = "Tên Loại Hàng";
            if (dgvLoaiHang.Columns["MoTa"] != null) dgvLoaiHang.Columns["MoTa"].HeaderText = "Mô Tả";
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvLoaiHang.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["MaLoai"].Value?.ToString();
                txtMaLoai.Enabled = false;
                txtTenLoai.Text = row.Cells["TenLoai"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                _isEditing = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaLoai.Text.Trim().ToUpper();
            string ten = txtTenLoai.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Mã loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            var item = new LoaiHang { MaLoai = ma, TenLoai = ten, MoTa = txtMoTa.Text.Trim() };
            if (_repo.Add(item, out string err))
            {
                MessageBox.Show("Thêm loại hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn loại hàng cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = txtTenLoai.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            var item = new LoaiHang { MaLoai = txtMaLoai.Text.Trim(), TenLoai = ten, MoTa = txtMoTa.Text.Trim() };
            if (_repo.Update(item, out string err))
            {
                MessageBox.Show("Cập nhật loại hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn loại hàng cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaLoai.Text.Trim();
            var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại hàng [{ma}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (_repo.Delete(ma, out string err))
                {
                    MessageBox.Show("Đã xóa loại hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaLoai.Enabled = true;
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtMoTa.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
