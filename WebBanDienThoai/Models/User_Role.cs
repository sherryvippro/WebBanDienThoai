namespace WebBanDienThoai.Models
{
    public class User_Role
    {
        public int MaNguoiDung { get; set; }
        /*   [Display(Name = "Ảnh đại diện")]*/
       
        public string Hoten { get; set; }
        public string Email { get; set; }
      
        public string Matkhau { get; set; }    
        public string Diachi { get; set; }
        public string DienThoai { get; set; }
        public string TenQuyen {  get; set; }
    }
}
