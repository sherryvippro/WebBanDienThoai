using WebBanDienThoai.Models;

namespace WebBanDienThoai.InputModels
{
    public class InputProducts
    {

        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public string? MaTl { get; set; }
        public string? MaHang { get; set; }
        public decimal? DonGiaNhap { get; set; }
        public decimal? DonGiaBan { get; set; }
        public int? SoLuong { get; set; }
        public IFormFile Anh { get; set; }

    }
}
