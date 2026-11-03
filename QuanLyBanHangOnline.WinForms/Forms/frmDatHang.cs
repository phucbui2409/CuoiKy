using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHangOnline.WinForms.DataContext;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmDatHang : System.Windows.Forms.Form
    {
        private readonly HangHoaRepository _hangHoaRepo = new HangHoaRepository();
        private readonly KhachHangRepository _khachHangRepo = new KhachHangRepository();
        private readonly DonHangRepository _donHangRepo = new DonHangRepository();

        private List<ChiTietItemViewModel> _cartItems = new List<ChiTietItemViewModel>();

        public frmDatHang()
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadAvailableProducts();
            RefreshCartGrid();
        }

        private void LoadCustomers()
        {
            var customers = _khachHangRepo.GetAll();
            cboKhachHang.DataSource = customers;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedItem is KhachHang kh)
            {
                txtCustomerName.Text = kh.HoTen;
                txtAddress.Text = kh.DiaChi;
                txtPhone.Text = kh.SoDienThoai;
            }
        }

        private void LoadAvailableProducts()
        {
            // LINQ Where: Chỉ hiển thị các mặt hàng còn số lượng > 0 theo yêu cầu đề bài
            var all = _hangHoaRepo.GetAll();
            var available = all.Where(h => h.SoLuong > 0).ToList();

            dgvProducts.DataSource = available;

            if (dgvProducts.Columns["MaHang"] != null) dgvProducts.Columns["MaHang"].HeaderText = "Mã";
            if (dgvProducts.Columns["TenHang"] != null) dgvProducts.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            if (dgvProducts.Columns["GiaBan"] != null)
            {
                dgvProducts.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvProducts.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
            if (dgvProducts.Columns["SoLuong"] != null) dgvProducts.Columns["SoLuong"].HeaderText = "Tồn";

            if (dgvProducts.Columns["MaLoai"] != null) dgvProducts.Columns["MaLoai"].Visible = false;
            if (dgvProducts.Columns["MaNSX"] != null) dgvProducts.Columns["MaNSX"].Visible = false;
            if (dgvProducts.Columns["TenLoai"] != null) dgvProducts.Columns["TenLoai"].Visible = false;
            if (dgvProducts.Columns["TenNSX"] != null) dgvProducts.Columns["TenNSX"].Visible = false;
            if (dgvProducts.Columns["MauSac"] != null) dgvProducts.Columns["MauSac"].Visible = false;
            if (dgvProducts.Columns["NgayNhapKho"] != null) dgvProducts.Columns["NgayNhapKho"].Visible = false;
            if (dgvProducts.Columns["TinhTrang"] != null) dgvProducts.Columns["TinhTrang"].Visible = false;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm vào giỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.CurrentRow;
            string maHang = row.Cells["MaHang"].Value?.ToString();
            string tenHang = row.Cells["TenHang"].Value?.ToString();
            decimal giaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value);
            int tonKho = Convert.ToInt32(row.Cells["SoLuong"].Value);
            int soLuongMua = (int)numQuantity.Value;

            // Kiểm tra số lượng tồn kho khả dụng
            var itemTrongGio = _cartItems.FirstOrDefault(c => c.MaHang == maHang);
            int daChon = itemTrongGio != null ? itemTrongGio.SoLuong : 0;
            int tongMua = daChon + soLuongMua;

            if (tongMua > tonKho)
            {
                MessageBox.Show($"Số lượng đặt ({tongMua}) vượt quá số lượng hàng đang có ({tonKho})!",
                                "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemTrongGio != null)
            {
                itemTrongGio.SoLuong += soLuongMua;
                itemTrongGio.ThanhTien = itemTrongGio.SoLuong * itemTrongGio.DonGia;
            }
            else
            {
                _cartItems.Add(new ChiTietItemViewModel
                {
                    MaHang = maHang,
                    TenHang = tenHang,
                    SoLuong = soLuongMua,
                    DonGia = giaBan,
                    ThanhTien = soLuongMua * giaBan
                });
            }

            RefreshCartGrid();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                string ma = dgvCart.CurrentRow.Cells["MaHang"].Value?.ToString();
                var item = _cartItems.FirstOrDefault(c => c.MaHang == ma);
                if (item != null)
                {
                    _cartItems.Remove(item);
                    RefreshCartGrid();
                }
            }
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cartItems;

            if (dgvCart.Columns["MaHang"] != null) dgvCart.Columns["MaHang"].HeaderText = "Mã";
            if (dgvCart.Columns["TenHang"] != null) dgvCart.Columns["TenHang"].HeaderText = "Tên Hàng";
            if (dgvCart.Columns["SoLuong"] != null) dgvCart.Columns["SoLuong"].HeaderText = "SL";
            if (dgvCart.Columns["DonGia"] != null)
            {
                dgvCart.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvCart.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvCart.Columns["ThanhTien"] != null)
            {
                dgvCart.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvCart.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            if (dgvCart.Columns["MaCT"] != null) dgvCart.Columns["MaCT"].Visible = false;
            if (dgvCart.Columns["SoThuTuDonHang"] != null) dgvCart.Columns["SoThuTuDonHang"].Visible = false;

            // Tính tổng tiền đơn hàng bằng LINQ Sum
            decimal tong = _cartItems.Sum(c => c.ThanhTien);
            lblTotalPrice.Text = $"{tong:N0} VNĐ";
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            // Kiểm tra không để trống hoặc chỉ chứa khoảng trắng
            string tenKH = txtCustomerName.Text.Trim();
            string diaChi = txtAddress.Text.Trim();
            string sdt = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống hoặc chỉ nhập khoảng trắng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Địa chỉ nhận hàng không được để trống hoặc chỉ nhập khoảng trắng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống hoặc chỉ nhập khoảng trắng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Đơn hàng phải có ít nhất một mặt hàng trong giỏ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = cboKhachHang.SelectedValue?.ToString() ?? "KH01";

            var donHang = new DonHang
            {
                MaKH = maKH,
                TenKhachHang = tenKH,
                DiaChiGiaoHang = diaChi,
                SoDienThoaiGiaoHang = sdt,
                GhiChu = txtNote.Text.Trim()
            };

            var chiTietList = _cartItems.Select(c => new ChiTietDonHang
            {
                MaHang = c.MaHang,
                SoLuong = c.SoLuong,
                DonGia = c.DonGia,
                ThanhTien = c.ThanhTien
            }).ToList();

            decimal tongTienDonHang = _cartItems.Sum(c => c.ThanhTien);

            bool ok = _donHangRepo.TaoDonHang(donHang, chiTietList, out string err);
            if (ok)
            {
                // In ra thông báo đúng yêu cầu đề bài: "Đơn hàng đang chờ xử lí"
                MessageBox.Show("Đơn hàng đang chờ xử lí\nĐã đưa đơn hàng vào danh sách các đơn hàng đang chờ xử lí (Mã đơn: #" + donHang.SoThuTu + ")",
                                "Đặt Hàng Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gợi ý mở mã thanh toán VietQR
                var askQR = MessageBox.Show("Bạn có muốn tạo mã VietQR Napas 247 để khách hàng quét chuyển khoản ngay không?",
                                            "Thanh Toán VietQR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (askQR == DialogResult.Yes)
                {
                    string maHD = $"HD{donHang.SoThuTu:D4}";
                    using (var qrForm = new frmThanhToanVietQR(maHD, tongTienDonHang, donHang.TenKhachHang))
                    {
                        qrForm.ShowDialog();
                    }
                }

                _cartItems.Clear();
                RefreshCartGrid();
                txtNote.Clear();
                LoadAvailableProducts();
            }
            else
            {
                MessageBox.Show("Đặt hàng thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScanBarcode_Click(object sender, EventArgs e)
        {
            using (var scanForm = new frmScanBarcode())
            {
                if (scanForm.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(scanForm.ScannedCode))
                {
                    string code = scanForm.ScannedCode.Trim();

                    // Tìm sản phẩm trong dgvProducts theo MaHang hoặc TenHang
                    bool found = false;
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        string maHang = row.Cells["MaHang"].Value?.ToString() ?? "";
                        string tenHang = row.Cells["TenHang"].Value?.ToString() ?? "";

                        if (maHang.Equals(code, StringComparison.OrdinalIgnoreCase) ||
                            tenHang.IndexOf(code, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            dgvProducts.ClearSelection();
                            row.Selected = true;
                            dgvProducts.CurrentCell = row.Cells[0];
                            found = true;

                            // Tự động thêm vào giỏ hàng
                            btnAddToCart_Click(this, EventArgs.Empty);

                            MessageBox.Show($"✔ Đã nhận diện Barcode [{code}] và tự động thêm [{tenHang}] vào giỏ hàng!",
                                "Quét Barcode thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show($"Không tìm thấy sản phẩm nào có mã barcode hoặc tên khớp với: '{code}'",
                            "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnPayVietQR_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng hiện đang trống! Vui lòng chọn sản phẩm vào giỏ trước khi tạo mã QR thanh toán.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tong = _cartItems.Sum(c => c.ThanhTien);
            string maTam = "DH" + DateTime.Now.ToString("yyMMddHHmm");
            string tenKH = string.IsNullOrWhiteSpace(txtCustomerName.Text) ? "Khách Hàng" : txtCustomerName.Text.Trim();

            using (var qrForm = new frmThanhToanVietQR(maTam, tong, tenKH))
            {
                qrForm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
