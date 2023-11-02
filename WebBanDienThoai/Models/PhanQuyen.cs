using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoai.Models
{
    public partial class PhanQuyen
    {
        public PhanQuyen()
        {
            Nguoidung = new HashSet<Nguoidung>();
        }

        [Key]
        public int IDQuyen { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên quyền")]

        public string TenQuyen { get; set; }

        public virtual ICollection<Nguoidung> Nguoidung { get; set; }
    }
}
