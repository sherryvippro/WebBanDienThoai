using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class THoaDonNhap
    {
        public string SoHdn { get; set; } = null!;
        public DateTime? NgayNhap { get; set; }
        public string? MaNcc { get; set; }
        public decimal? TongHdn { get; set; }
    }
}
