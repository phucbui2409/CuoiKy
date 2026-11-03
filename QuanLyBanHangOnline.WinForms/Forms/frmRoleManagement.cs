using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmRoleManagement : System.Windows.Forms.Form
    {
        private readonly PhanQuyenRepository _roleRepo = new PhanQuyenRepository();

        public frmRoleManagement()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            var roles = _roleRepo.GetAllRoles();
            cboRole.DataSource = roles;
            cboRole.DisplayMember = "TenVaiTro";
            cboRole.ValueMember = "MaVaiTro";
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatrix();
        }

        private void LoadMatrix()
        {
            string roleId = cboRole.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(roleId)) return;

            var list = _roleRepo.GetPermissionsMatrix(roleId);
            dgvPermissions.DataSource = list;

            if (dgvPermissions.Columns["MaChucNang"] != null)
            {
                dgvPermissions.Columns["MaChucNang"].HeaderText = "Mã Chức Năng";
                dgvPermissions.Columns["MaChucNang"].ReadOnly = true;
                dgvPermissions.Columns["MaChucNang"].Width = 140;
            }

            if (dgvPermissions.Columns["TenChucNang"] != null)
            {
                dgvPermissions.Columns["TenChucNang"].HeaderText = "Tên Chức Năng";
                dgvPermissions.Columns["TenChucNang"].ReadOnly = true;
                dgvPermissions.Columns["TenChucNang"].Width = 220;
            }

            if (dgvPermissions.Columns["MoTa"] != null)
            {
                dgvPermissions.Columns["MoTa"].HeaderText = "Mô Tả";
                dgvPermissions.Columns["MoTa"].ReadOnly = true;
            }

            if (dgvPermissions.Columns["CoQuyen"] != null)
            {
                dgvPermissions.Columns["CoQuyen"].HeaderText = "Được Phép Sử Dụng";
                dgvPermissions.Columns["CoQuyen"].Width = 130;
                // Nếu vai trò là ADMIN thì khóa không cho bỏ tick
                dgvPermissions.Columns["CoQuyen"].ReadOnly = (roleId == "ADMIN");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                row.Cells["CoQuyen"].Value = true;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            string roleId = cboRole.SelectedValue?.ToString();
            if (roleId == "ADMIN")
            {
                MessageBox.Show("Vai trò ADMIN bắt buộc có toàn quyền truy cập, không thể bỏ chọn tất cả!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                row.Cells["CoQuyen"].Value = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roleId = cboRole.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(roleId)) return;

            var map = new Dictionary<string, bool>();
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                string code = row.Cells["MaChucNang"].Value?.ToString();
                bool granted = Convert.ToBoolean(row.Cells["CoQuyen"].Value);
                if (!string.IsNullOrEmpty(code))
                {
                    map[code] = granted;
                }
            }

            bool ok = _roleRepo.SavePermissions(roleId, map, out string err);
            if (ok)
            {
                MessageBox.Show($"Lưu phân quyền thành công cho vai trò [{roleId}]!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phân quyền: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
