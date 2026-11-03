using QuanLyBanHangOnline.WinForms.UIExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanHangOnline.WinForms.Helpers;
using QuanLyBanHangOnline.WinForms.Models;
using QuanLyBanHangOnline.WinForms.Repositories;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmXemBaoCaoDoanhThuReport : Form
    {
        private readonly DateTime _from;
        private readonly DateTime _to;
        private readonly string _tieuChi;
        private readonly List<DonHangViewModel> _data;

        public frmXemBaoCaoDoanhThuReport(DateTime from, DateTime to, string tieuChi, List<DonHangViewModel> data)
        {
            InitializeComponent();
            UIThemeManager.ApplyTheme(this);
            this._from = from;
            this._to = to;
            this._tieuChi = tieuChi;
            this._data = data ?? new List<DonHangViewModel>();
        }

        private void frmXemBaoCaoDoanhThuReport_Load(object sender, EventArgs e)
        {
            try
            {
                string rdlcPath = FindReportFilePath("rptBaoCaoDoanhThu.rdlc");
                if (!File.Exists(rdlcPath))
                {
                    MessageBox.Show("Không tìm thấy file mẫu báo cáo: " + rdlcPath, "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rdlcPath;
                reportViewer1.LocalReport.DataSources.Clear();

                // 1. Chuyển đổi dữ liệu sang BaoCaoDoanhThuItem
                var items = _data.Select((d, index) => new BaoCaoDoanhThuItem
                {
                    STT = index + 1,
                    SoThuTu = d.SoThuTu,
                    NgayDatHang = d.NgayDatHang.ToString("dd/MM/yyyy HH:mm"),
                    TenKhachHang = d.TenKhachHang,
                    NhanVien = string.IsNullOrEmpty(d.MaNV) ? "Chưa gán" : d.MaNV,
                    TrangThai = d.TrangThai,
                    TongTien = d.TongTien
                }).ToList();

                ReportDataSource rds = new ReportDataSource("DataSetDoanhThu", items);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // 2. Thiết lập ReportParameter
                decimal tongDoanhThu = _data.Sum(d => d.TongTien);
                int tongSoDon = _data.Count;
                string nguoiLap = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.HoTen : "Ban Quản Trị";

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pTuNgay", _from.ToString("dd/MM/yyyy")),
                    new ReportParameter("pDenNgay", _to.ToString("dd/MM/yyyy")),
                    new ReportParameter("pTieuChi", string.IsNullOrEmpty(_tieuChi) ? "Tất cả" : _tieuChi),
                    new ReportParameter("pTongDoanhThu", $"{tongDoanhThu:N0}"),
                    new ReportParameter("pTongSoDon", $"{tongSoDon} đơn"),
                    new ReportParameter("pNguoiLapBaoCao", nguoiLap)
                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message + "\n" + ex.InnerException?.Message,
                                "Lỗi ReportViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FindReportFilePath(string fileName)
        {
            string p1 = Path.Combine(Application.StartupPath, "Reports", fileName);
            if (File.Exists(p1)) return p1;

            string p2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Reports", fileName);
            if (File.Exists(p2)) return Path.GetFullPath(p2);

            string p3 = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(p3)) return p3;

            return p1;
        }
    }
}
