using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class THoaDonBan
    {
        public string SoHdb { get; set; } = null!;
        public DateTime? NgayBan { get; set; }
        public string? MaNguoiDung { get; set; }
        public decimal? TongHdb { get; set; }
    }
}
