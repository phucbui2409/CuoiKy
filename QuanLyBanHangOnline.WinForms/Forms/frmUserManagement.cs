using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmUserManagement : System.Windows.Forms.Form
    {
        private readonly NguoiDungRepository _userRepo = new NguoiDungRepository();
        private readonly PhanQuyenRepository _roleRepo = new PhanQuyenRepository();
        private int _selectedUserId = 0;

        public frmUserManagement()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            var roles = _roleRepo.GetAllRoles();
            cboRole.DataSource = roles;
            cboRole.DisplayMember = "TenVaiTro";
            cboRole.ValueMember = "MaVaiTro";
        }

        private void LoadUsers()
        {
            var list = _userRepo.GetAllUsers();
            dgvUsers.DataSource = list;

            if (dgvUsers.Columns["MaND"] != null) dgvUsers.Columns["MaND"].HeaderText = "Mã";
            if (dgvUsers.Columns["TenDangNhap"] != null) dgvUsers.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
            if (dgvUsers.Columns["HoTen"] != null) dgvUsers.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvUsers.Columns["Email"] != null) dgvUsers.Columns["Email"].HeaderText = "Email";
            if (dgvUsers.Columns["SoDienThoai"] != null) dgvUsers.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (dgvUsers.Columns["TenVaiTro"] != null) dgvUsers.Columns["TenVaiTro"].HeaderText = "Vai Trò";
            if (dgvUsers.Columns["TrangThaiHienThi"] != null) dgvUsers.Columns["TrangThaiHienThi"].HeaderText = "Trạng Thái";

            if (dgvUsers.Columns["MaVaiTro"] != null) dgvUsers.Columns["MaVaiTro"].Visible = false;
            if (dgvUsers.Columns["TrangThai"] != null) dgvUsers.Columns["TrangThai"].Visible = false;
            if (dgvUsers.Columns["NgayTao"] != null) dgvUsers.Columns["NgayTao"].Visible = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                _selectedUserId = Convert.ToInt32(row.Cells["MaND"].Value);
                txtUsername.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtUsername.Enabled = false; // Không cho sửa username
                txtPassword.Enabled = false; // Mật khẩu được quản lý riêng qua nút reset
                txtPassword.Text = "********";
                txtFullName.Text = row.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value?.ToString();

                string roleId = row.Cells["MaVaiTro"].Value?.ToString();
                if (!string.IsNullOrEmpty(roleId))
                {
                    cboRole.SelectedValue = roleId;
                }

                chkActive.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string role = cboRole.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password) || password == "********")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            bool ok = _userRepo.AddUser(username, password, fullName, email, phone, role, out string err);
            if (ok)
            {
                MessageBox.Show("Thêm người dùng mới thành công! Mật khẩu đã được mã hóa SHA-256 + Salt.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string role = cboRole.SelectedValue?.ToString();
            bool active = chkActive.Checked;

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = _userRepo.UpdateUser(_selectedUserId, fullName, email, phone, role, active, out string err);
            if (ok)
            {
                MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đặt lại mật khẩu của người dùng này về mặc định '123456'?",
                                          "Xác nhận đặt lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool ok = _userRepo.ResetPassword(_selectedUserId, "123456", out string err);
                if (ok)
                {
                    MessageBox.Show("Đã đặt lại mật khẩu về '123456' thành công (mã hóa SHA-256 + Salt mới).",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _selectedUserId = 0;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            chkActive.Checked = true;
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
