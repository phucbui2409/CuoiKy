using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmBaoCaoTonKho : System.Windows.Forms.Form
    {
        private readonly HangHoaRepository _hangHoaRepo = new HangHoaRepository();

        public frmBaoCaoTonKho()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            btnFilter.PerformClick();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int threshold = (int)numThreshold.Value;

            // LINQ: Lấy hàng tồn kho thấp sử dụng LINQ Where, OrderBy, Skip, Take
            var lowStock = _hangHoaRepo.GetLowStock(threshold, 0, 50);
            dgvInventory.DataSource = lowStock;

            lblWarningInfo.Text = $"⚠️ Có {lowStock.Count} mặt hàng tồn kho <= {threshold} cần nhập thêm gấp!";
            FormatGrid();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            var all = _hangHoaRepo.GetAll();
            dgvInventory.DataSource = all;
            lblWarningInfo.Text = $"Toàn bộ kho: {all.Count} mặt hàng.";
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvInventory.Columns["MaHang"] != null) dgvInventory.Columns["MaHang"].HeaderText = "Mã Hàng";
            if (dgvInventory.Columns["TenHang"] != null) dgvInventory.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            if (dgvInventory.Columns["TenLoai"] != null) dgvInventory.Columns["TenLoai"].HeaderText = "Loại Hàng";
            if (dgvInventory.Columns["TenNSX"] != null) dgvInventory.Columns["TenNSX"].HeaderText = "Nơi SX";
            if (dgvInventory.Columns["MauSac"] != null) dgvInventory.Columns["MauSac"].HeaderText = "Màu Sắc";
            if (dgvInventory.Columns["GiaBan"] != null)
            {
                dgvInventory.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvInventory.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
            if (dgvInventory.Columns["SoLuong"] != null)
            {
                dgvInventory.Columns["SoLuong"].HeaderText = "SL Tồn Kho";
            }
            if (dgvInventory.Columns["TinhTrang"] != null) dgvInventory.Columns["TinhTrang"].HeaderText = "Tình Trạng";

            if (dgvInventory.Columns["MaLoai"] != null) dgvInventory.Columns["MaLoai"].Visible = false;
            if (dgvInventory.Columns["MaNSX"] != null) dgvInventory.Columns["MaNSX"].Visible = false;
            if (dgvInventory.Columns["NgayNhapKho"] != null) dgvInventory.Columns["NgayNhapKho"].Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvInventory.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu tồn kho để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|CSV file (*.csv)|*.csv";
                sfd.FileName = $"BaoCaoTonKho_{DateTime.Now:yyyyMMdd_HHmm}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("=== BÁO CÁO XUẤT NHẬP TỒN KHO HÀNG HÓA ===");
                    sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine(new string('-', 85));
                    sb.AppendLine(string.Format("{0,-6} | {1,-30} | {2,-15} | {3,12} | {4,10}",
                                  "Mã", "Tên Hàng", "Nơi SX", "Giá Bán", "Tồn Kho"));
                    sb.AppendLine(new string('-', 85));

                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        sb.AppendLine(string.Format("{0,-6} | {1,-30} | {2,-15} | {3,12:N0} | {4,10}",
                                      row.Cells["MaHang"].Value,
                                      row.Cells["TenHang"].Value,
                                      row.Cells["TenNSX"].Value,
                                      row.Cells["GiaBan"].Value,
                                      row.Cells["SoLuong"].Value));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất báo cáo tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
