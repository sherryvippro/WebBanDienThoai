using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class TNhaCungCap
    {
        public TNhaCungCap()
        {
            THoaDonNhaps = new HashSet<THoaDonNhap>();
        }

        public string MaNcc { get; set; } = null!;
        public string? TenNcc { get; set; }

        public virtual ICollection<THoaDonNhap> THoaDonNhaps { get; set; }
    }
}
