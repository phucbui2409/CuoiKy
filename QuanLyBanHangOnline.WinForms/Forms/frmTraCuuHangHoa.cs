using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmTraCuuHangHoa : System.Windows.Forms.Form
    {
        private readonly HangHoaRepository _hangHoaRepo = new HangHoaRepository();
        private readonly LoaiHangRepository _loaiRepo = new LoaiHangRepository();
        private readonly NhaSanXuatRepository _nsxRepo = new NhaSanXuatRepository();

        public frmTraCuuHangHoa()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmTraCuuHangHoa_Load(object sender, EventArgs e)
        {
            LoadFilterCombos();
            ThucHienTraCuu();
        }

        private void LoadFilterCombos()
        {
            var loaiList = new List<LoaiHang> { new LoaiHang { MaLoai = "ALL", TenLoai = "-- Tất cả loại --" } };
            loaiList.AddRange(_loaiRepo.GetAll());
            cboLoai.DataSource = loaiList;
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";

            var nsxList = new List<NhaSanXuat> { new NhaSanXuat { MaNSX = "ALL", TenNSX = "-- Tất cả nơi SX --" } };
            nsxList.AddRange(_nsxRepo.GetAll());
            cboNSX.DataSource = nsxList;
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";

            cboStatus.SelectedIndex = 0;
            numPriceFrom.Value = 0;
            numPriceTo.Value = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ThucHienTraCuu();
        }

        private void ThucHienTraCuu()
        {
            string kw = txtKeyword.Text.Trim();
            string maLoai = cboLoai.SelectedValue?.ToString() ?? "ALL";
            string maNSX = cboNSX.SelectedValue?.ToString() ?? "ALL";

            decimal? giaTu = numPriceFrom.Value > 0 ? (decimal?)numPriceFrom.Value : null;
            decimal? giaDen = numPriceTo.Value > 0 ? (decimal?)numPriceTo.Value : null;

            string status = "ALL";
            if (cboStatus.SelectedIndex == 1) status = "CONHANG";
            else if (cboStatus.SelectedIndex == 2) status = "HETHANG";

            // LINQ Search
            var results = _hangHoaRepo.TraCuu(kw, maLoai, maNSX, giaTu, giaDen, status);
            dgvResults.DataSource = results;

            lblResultCount.Text = $"Tìm thấy: {results.Count} sản phẩm phù hợp";

            if (dgvResults.Columns["MaHang"] != null) dgvResults.Columns["MaHang"].HeaderText = "Mã Hàng";
            if (dgvResults.Columns["TenHang"] != null) dgvResults.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            if (dgvResults.Columns["TenLoai"] != null) dgvResults.Columns["TenLoai"].HeaderText = "Loại Hàng";
            if (dgvResults.Columns["TenNSX"] != null) dgvResults.Columns["TenNSX"].HeaderText = "Nơi SX";
            if (dgvResults.Columns["MauSac"] != null) dgvResults.Columns["MauSac"].HeaderText = "Màu Sắc";
            if (dgvResults.Columns["GiaBan"] != null)
            {
                dgvResults.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvResults.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
            if (dgvResults.Columns["NgayNhapKho"] != null)
            {
                dgvResults.Columns["NgayNhapKho"].HeaderText = "Ngày Nhập Kho";
                dgvResults.Columns["NgayNhapKho"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvResults.Columns["SoLuong"] != null) dgvResults.Columns["SoLuong"].HeaderText = "Tồn Kho";
            if (dgvResults.Columns["TinhTrang"] != null) dgvResults.Columns["TinhTrang"].HeaderText = "Tình Trạng";

            if (dgvResults.Columns["MaLoai"] != null) dgvResults.Columns["MaLoai"].Visible = false;
            if (dgvResults.Columns["MaNSX"] != null) dgvResults.Columns["MaNSX"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboLoai.SelectedIndex = 0;
            cboNSX.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            numPriceFrom.Value = 0;
            numPriceTo.Value = 0;
            ThucHienTraCuu();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
