using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class TSp
    {
        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public string? MaTl { get; set; }
        public string? MaHang { get; set; }
        public decimal? DonGiaNhap { get; set; }
        public decimal? DonGiaBan { get; set; }
        public int? SoLuong { get; set; }
        public byte[]? Anh { get; set; }
    }
}
