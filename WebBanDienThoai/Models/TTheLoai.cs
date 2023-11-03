using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models
{
    public partial class TTheLoai
    {
        public TTheLoai()
        {
            TSp = new HashSet<TSp>();
        }

        public string MaTl { get; set; } = null!;
        public string? TenTl { get; set; }

        public virtual ICollection<TSp> TSp { get; set; }
    }
}
