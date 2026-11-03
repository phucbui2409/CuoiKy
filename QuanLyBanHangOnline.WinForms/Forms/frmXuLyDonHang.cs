using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmXuLyDonHang : System.Windows.Forms.Form
    {
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();

        public frmXuLyDonHang()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmXuLyDonHang_Load(object sender, EventArgs e)
        {
            LoadPendingOrders();
        }

        private void LoadPendingOrders()
        {
            // LINQ: Lấy đơn hàng theo nguyên tắc FIFO (NgayDatHang tăng dần)
            var pending = _donHangRepo.LayDanhSachChoXuLyFIFO();
            dgvPendingOrders.DataSource = pending;

            lblPendingCount.Text = $"Đang chờ: {pending.Count} đơn cần xử lý";

            if (dgvPendingOrders.Columns["SoThuTu"] != null) dgvPendingOrders.Columns["SoThuTu"].HeaderText = "STT Đơn";
            if (dgvPendingOrders.Columns["TenKhachHang"] != null) dgvPendingOrders.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
            if (dgvPendingOrders.Columns["SoDienThoaiGiaoHang"] != null) dgvPendingOrders.Columns["SoDienThoaiGiaoHang"].HeaderText = "SĐT Nhận";
            if (dgvPendingOrders.Columns["DiaChiGiaoHang"] != null) dgvPendingOrders.Columns["DiaChiGiaoHang"].HeaderText = "Địa Chỉ Giao";
            if (dgvPendingOrders.Columns["NgayDatHang"] != null)
            {
                dgvPendingOrders.Columns["NgayDatHang"].HeaderText = "Ngày Đặt (FIFO)";
                dgvPendingOrders.Columns["NgayDatHang"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            if (dgvPendingOrders.Columns["TongTien"] != null)
            {
                dgvPendingOrders.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvPendingOrders.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
            if (dgvPendingOrders.Columns["TrangThai"] != null) dgvPendingOrders.Columns["TrangThai"].HeaderText = "Trạng Thái";

            if (dgvPendingOrders.Columns["MaKH"] != null) dgvPendingOrders.Columns["MaKH"].Visible = false;
            if (dgvPendingOrders.Columns["MaNV"] != null) dgvPendingOrders.Columns["MaNV"].Visible = false;
            if (dgvPendingOrders.Columns["GhiChu"] != null) dgvPendingOrders.Columns["GhiChu"].Visible = false;

            if (pending.Count == 0)
            {
                dgvOrderDetails.DataSource = null;
            }
        }

        private void dgvPendingOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPendingOrders.CurrentRow != null)
            {
                int stt = Convert.ToInt32(dgvPendingOrders.CurrentRow.Cells["SoThuTu"].Value);
                var details = _donHangRepo.LayChiTietDonHang(stt);
                dgvOrderDetails.DataSource = details;

                if (dgvOrderDetails.Columns["MaHang"] != null) dgvOrderDetails.Columns["MaHang"].HeaderText = "Mã Hàng";
                if (dgvOrderDetails.Columns["TenHang"] != null) dgvOrderDetails.Columns["TenHang"].HeaderText = "Tên Sản Phẩm";
                if (dgvOrderDetails.Columns["SoLuong"] != null) dgvOrderDetails.Columns["SoLuong"].HeaderText = "Số Lượng Mua";
                if (dgvOrderDetails.Columns["DonGia"] != null)
                {
                    dgvOrderDetails.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvOrderDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvOrderDetails.Columns["ThanhTien"] != null)
                {
                    dgvOrderDetails.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgvOrderDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvOrderDetails.Columns["MaCT"] != null) dgvOrderDetails.Columns["MaCT"].Visible = false;
                if (dgvOrderDetails.Columns["SoThuTuDonHang"] != null) dgvOrderDetails.Columns["SoThuTuDonHang"].Visible = false;
            }
        }

        // Xử lý đơn hàng đầu tiên trong hàng đợi (Nguyên tắc FIFO)
        private void btnProcessFIFO_Click(object sender, EventArgs e)
        {
            var pending = _donHangRepo.LayDanhSachChoXuLyFIFO();
            if (pending.Count == 0)
            {
                MessageBox.Show("Hiện không có đơn hàng nào đang chờ xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var donDauTien = pending.First();
            var res = MessageBox.Show($"Xác nhận duyệt và xuất kho cho đơn hàng đặt sớm nhất:\n" +
                                      $"- Mã đơn: #{donDauTien.SoThuTu}\n" +
                                      $"- Khách hàng: {donDauTien.TenKhachHang}\n" +
                                      $"- Ngày đặt: {donDauTien.NgayDatHang:dd/MM/yyyy HH:mm:ss}\n" +
                                      $"- Tổng tiền: {donDauTien.TongTien:N0} VNĐ\n\n" +
                                      $"Hệ thống sẽ tự động trừ số lượng hàng trong kho và xóa đơn khỏi danh sách chờ xử lý.",
                                      "Xác nhận xử lý đơn hàng (FIFO)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                string maNV = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.TenDangNhap : "NV01";
                bool ok = _donHangRepo.XuLyDonHangFIFO(donDauTien.SoThuTu, maNV, out string err);

                if (ok)
                {
                    LoadPendingOrders();
                    var askPrint = MessageBox.Show($"Đã xử lý thành công đơn hàng #{donDauTien.SoThuTu}! Tồn kho đã được cập nhật.\n\nBạn có muốn xem và IN HÓA ĐƠN / PHIẾU XUẤT KHO (RDLC) ngay bây giờ không?",
                                                   "Xử lý thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (askPrint == DialogResult.Yes)
                    {
                        new frmInHoaDonReport(donDauTien.SoThuTu).ShowDialog(this);
                    }
                }
                else
                {
                    MessageBox.Show("Xử lý thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessSelected_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stt = Convert.ToInt32(dgvPendingOrders.CurrentRow.Cells["SoThuTu"].Value);
            string maNV = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.TenDangNhap : "NV01";

            bool ok = _donHangRepo.XuLyDonHangFIFO(stt, maNV, out string err);
            if (ok)
            {
                LoadPendingOrders();
                var askPrint = MessageBox.Show($"Đã xử lý thành công đơn hàng #{stt}! Tồn kho đã được cập nhật.\n\nBạn có muốn xem và IN HÓA ĐƠN / PHIẾU XUẤT KHO (RDLC) ngay bây giờ không?",
                                               "Xử lý thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (askPrint == DialogResult.Yes)
                {
                    new frmInHoaDonReport(stt).ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Xử lý thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stt = Convert.ToInt32(dgvPendingOrders.CurrentRow.Cells["SoThuTu"].Value);
            var res = MessageBox.Show($"Bạn có chắc chắn muốn HỦY đơn hàng #{stt}?",
                                      "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                bool ok = _donHangRepo.HuyDonHang(stt, out string err);
                if (ok)
                {
                    MessageBox.Show($"Đã hủy đơn hàng #{stt}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingOrders();
                }
                else
                {
                    MessageBox.Show("Hủy đơn thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingOrders();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
