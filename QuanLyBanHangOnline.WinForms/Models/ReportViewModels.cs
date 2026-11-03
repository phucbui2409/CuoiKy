using System;

namespace QuanLyBanHangOnline.WinForms.Models
{
    public class ChiTietXuatKhoItem
    {
        public int STT { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MauSac { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }

    public class BaoCaoDoanhThuItem
    {
        public int STT { get; set; }
        public int SoThuTu { get; set; }
        public string NgayDatHang { get; set; }
        public string TenKhachHang { get; set; }
        public string NhanVien { get; set; }
        public string TrangThai { get; set; }
        public decimal TongTien { get; set; }
    }

    public static class NumberToVietnameseWords
    {
        private static readonly string[] ChuSo = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] Tien = new string[] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };

        private static string DocBlockBaSo(int baso, bool daydu)
        {
            int tram = baso / 100;
            int chuc = (baso % 100) / 10;
            int donvi = baso % 10;
            string res = "";

            if (tram == 0 && chuc == 0 && donvi == 0) return "";

            if (tram != 0 || daydu)
            {
                res += ChuSo[tram] + " trăm ";
                if (chuc == 0 && donvi != 0) res += "lẻ ";
            }

            if (chuc != 0 && chuc != 1)
            {
                res += ChuSo[chuc] + " mươi ";
                if (chuc == 0 && donvi != 0) res += "lẻ ";
            }

            if (chuc == 1) res += "mười ";

            switch (donvi)
            {
                case 1:
                    if (chuc != 0 && chuc != 1) res += "mốt ";
                    else res += ChuSo[donvi] + " ";
                    break;
                case 5:
                    if (chuc == 0) res += ChuSo[donvi] + " ";
                    else res += "lăm ";
                    break;
                default:
                    if (donvi != 0) res += ChuSo[donvi] + " ";
                    break;
            }

            return res;
        }

        public static string ChuyenSoThanhChu(decimal tongTien)
        {
            if (tongTien <= 0) return "Không đồng";

            long soTien = (long)Math.Round(tongTien, 0);
            string strTien = soTien.ToString();
            int lan = 0;
            int i = strTien.Length;
            int baso = 0;
            string ketqua = "";

            while (i > 0)
            {
                if (i >= 3)
                {
                    baso = int.Parse(strTien.Substring(i - 3, 3));
                    i -= 3;
                }
                else
                {
                    baso = int.Parse(strTien.Substring(0, i));
                    i = 0;
                }

                if (baso > 0)
                {
                    string chu = DocBlockBaSo(baso, i > 0);
                    ketqua = chu + Tien[lan] + " " + ketqua;
                }
                lan++;
            }

            ketqua = ketqua.Trim();
            if (!string.IsNullOrEmpty(ketqua))
            {
                ketqua = char.ToUpper(ketqua[0]) + ketqua.Substring(1) + " đồng chẵn.";
            }

            return ketqua;
        }
    }
}
