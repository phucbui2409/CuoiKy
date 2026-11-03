using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmThongKeDoanhThu : System.Windows.Forms.Form
    {
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;
            ThucHienThongKe();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ThucHienThongKe();
        }

        private void ThucHienThongKe()
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;

            if (from > to)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Thống kê theo ngày (LINQ GroupBy & Sum & Count)
            var dailyData = _donHangRepo.ThongKeDoanhThuTheoNgay(from, to);
            dgvDailyRevenue.DataSource = dailyData;

            if (dgvDailyRevenue.Columns["Ngay"] != null)
            {
                dgvDailyRevenue.Columns["Ngay"].HeaderText = "Ngày";
                dgvDailyRevenue.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDailyRevenue.Columns["SoLuongDon"] != null)
            {
                dgvDailyRevenue.Columns["SoLuongDon"].HeaderText = "Số Đơn";
            }
            if (dgvDailyRevenue.Columns["TongTien"] != null)
            {
                dgvDailyRevenue.Columns["TongTien"].HeaderText = "Doanh Thu (VNĐ)";
                dgvDailyRevenue.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }

            // 2. Tổng hợp tổng doanh thu và tổng số đơn bằng LINQ Sum
            decimal tongDoanhThu = dailyData.Sum(d => d.TongTien);
            int tongSoDon = dailyData.Sum(d => d.SoLuongDon);

            lblTotalRevenueValue.Text = $"{tongDoanhThu:N0} VNĐ";
            lblTotalOrdersValue.Text = $"{tongSoDon} đơn hoàn tất";

            // 3. Top 5 sản phẩm bán chạy nhất (LINQ GroupBy, Sum, OrderByDescending, Take(5))
            var topProducts = _donHangRepo.GetTopSellingProducts(5);
            dgvTopProducts.DataSource = topProducts;

            if (dgvTopProducts.Columns["MaHang"] != null) dgvTopProducts.Columns["MaHang"].HeaderText = "Mã Hàng";
            if (dgvTopProducts.Columns["TenHang"] != null) dgvTopProducts.Columns["TenHang"].HeaderText = "Tên Sản Phẩm";
            if (dgvTopProducts.Columns["TongSoLuongBan"] != null) dgvTopProducts.Columns["TongSoLuongBan"].HeaderText = "SL Đã Bán";
            if (dgvTopProducts.Columns["TongDoanhThu"] != null)
            {
                dgvTopProducts.Columns["TongDoanhThu"].HeaderText = "Doanh Số";
                dgvTopProducts.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
