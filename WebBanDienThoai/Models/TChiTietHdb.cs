using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class TChiTietHdb
    {
        public string SoHdb { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int? Slban { get; set; }
        public string? KhuyenMai { get; set; }
    }
}
