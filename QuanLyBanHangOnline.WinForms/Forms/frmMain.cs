using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        public frmMain()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CapNhatThongTinNguoiDung();
            ApDungPhanQuyenRBAC();
            CapNhatThoiGian();
            CapNhatNutTheme();
        }

        private void CapNhatThongTinNguoiDung()
        {
            if (SessionManager.CurrentUser != null)
            {
                lblStatusUser.Text = $"Người dùng: [{SessionManager.CurrentUser.HoTen} ({SessionManager.CurrentUser.TenDangNhap})]";
                lblStatusRole.Text = $"| Vai trò: [{SessionManager.CurrentUser.TenVaiTro}]";
            }
        }

        // ========================================================================
        // PHÂN QUYỀN RBAC (ROLE-BASED ACCESS CONTROL)
        // Kiểm tra quyền để Ẩn/Hiện (Visible) hoặc Kích hoạt/Vô hiệu hóa (Enabled)
        // ========================================================================
        private void ApDungPhanQuyenRBAC()
        {
            // Kiểm tra từng chức năng thông qua SessionManager.HasPermission()
            // 1. Quản lý danh mục
            mnuHangHoa.Visible = SessionManager.HasPermission("FN_HANGHOA");
            mnuLoaiHang.Visible = SessionManager.HasPermission("FN_LOAIHANG");
            mnuNhaSanXuat.Visible = SessionManager.HasPermission("FN_NHASANXUAT");
            mnuKhachHang.Visible = SessionManager.HasPermission("FN_KHACHHANG");
            mnuNhanVien.Visible = SessionManager.HasPermission("FN_NHANVIEN");

            // 2. Nghiệp vụ giao dịch
            mnuDatHang.Visible = SessionManager.HasPermission("FN_DATHANG");
            mnuXuLyDonHang.Visible = SessionManager.HasPermission("FN_XULYDONHANG");
            mnuTraCuu.Visible = SessionManager.HasPermission("FN_TRACUU");

            // 3. Báo cáo thống kê
            mnuThongKe.Visible = SessionManager.HasPermission("FN_THONGKE");
            mnuBaoCaoDonHang.Visible = SessionManager.HasPermission("FN_BAOCAO_DONHANG");
            mnuBaoCaoTonKho.Visible = SessionManager.HasPermission("FN_BAOCAO_TONKHO");

            // 4. Quản trị hệ thống (Chỉ Admin)
            mnuUserManagement.Visible = SessionManager.HasPermission("FN_USER_MANAGE");
            mnuRoleManagement.Visible = SessionManager.HasPermission("FN_ROLE_MANAGE");
            mnuAdministration.Visible = mnuUserManagement.Visible || mnuRoleManagement.Visible;

            // 5. Các nút Quick Button trên Dashboard
            btnQuickDatHang.Enabled = SessionManager.HasPermission("FN_DATHANG");
            btnQuickXuLyDon.Enabled = SessionManager.HasPermission("FN_XULYDONHANG");
            btnQuickHangHoa.Enabled = SessionManager.HasPermission("FN_HANGHOA");
            btnQuickTraCuu.Enabled = SessionManager.HasPermission("FN_TRACUU");
            btnQuickThongKe.Enabled = SessionManager.HasPermission("FN_THONGKE");
            btnQuickBaoCao.Enabled = SessionManager.HasPermission("FN_BAOCAO_DONHANG");
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        private void CapNhatThoiGian()
        {
            lblStatusTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        #region Xử lý Menu Hệ Thống
        private void mnuConnectionConfig_Click(object sender, EventArgs e)
        {
            using (var f = new frmConnectionConfig())
            {
                f.ShowDialog(this);
            }
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            var f = new frmChangePassword();
            f.ShowDialog(this);
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                                         "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SessionManager.ClearSession();
                this.Hide();
                var login = new frmLogin();
                login.Show();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?",
                                         "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region Mở các Form Danh Mục (CRUD)
        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            new frmHangHoa().ShowDialog(this);
        }

        private void mnuLoaiHang_Click(object sender, EventArgs e)
        {
            new frmLoaiHang().ShowDialog(this);
        }

        private void mnuNhaSanXuat_Click(object sender, EventArgs e)
        {
            new frmNhaSanXuat().ShowDialog(this);
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            new frmKhachHang().ShowDialog(this);
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            new frmNhanVien().ShowDialog(this);
        }
        #endregion

        #region Mở các Form Nghiệp Vụ / Giao Dịch
        private void mnuDatHang_Click(object sender, EventArgs e)
        {
            new frmDatHang().ShowDialog(this);
        }

        private void mnuXuLyDonHang_Click(object sender, EventArgs e)
        {
            new frmXuLyDonHang().ShowDialog(this);
        }

        private void mnuTraCuu_Click(object sender, EventArgs e)
        {
            new frmTraCuuHangHoa().ShowDialog(this);
        }
        #endregion

        #region Mở các Form Báo Cáo / Thống Kê
        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            new frmChartDashboard().ShowDialog(this);
        }

        private void mnuBaoCaoDonHang_Click(object sender, EventArgs e)
        {
            new frmBaoCaoDonHang().ShowDialog(this);
        }

        private void mnuBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            new frmBaoCaoTonKho().ShowDialog(this);
        }

        private void mnuChartDashboard_Click(object sender, EventArgs e)
        {
            new frmChartDashboard().ShowDialog(this);
        }

        private void mnuInHoaDonReport_Click(object sender, EventArgs e)
        {
            new frmInHoaDonReport().ShowDialog(this);
        }
        #endregion

        #region Mở các Form Quản Trị Hệ Thống
        private void mnuUserManagement_Click(object sender, EventArgs e)
        {
            new frmUserManagement().ShowDialog(this);
        }

        private void mnuRoleManagement_Click(object sender, EventArgs e)
        {
            new frmRoleManagement().ShowDialog(this);
            // Cập nhật lại quyền nếu vừa sửa
            ApDungPhanQuyenRBAC();
        }
        #endregion

        #region Chuyển đổi Dark / Light Mode Toàn Ứng Dụng
        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            UIThemeManager.ToggleTheme();
            CapNhatNutTheme();
        }

        private void CapNhatNutTheme()
        {
            if (UIThemeManager.CurrentTheme == ThemeMode.Dark)
            {
                btnToggleTheme.Text = "☀️ Chế độ Sáng";
                btnToggleTheme.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
                mnuThemeToggle.Text = "☀️ Chế độ Sáng";
                mnuThemeToggle.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            }
            else
            {
                btnToggleTheme.Text = "🌙 Chế độ Tối";
                btnToggleTheme.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
                mnuThemeToggle.Text = "🌙 Giao diện Tối";
                mnuThemeToggle.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            }
        }
        #endregion
    }
}
