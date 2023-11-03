using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoai.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string passWord { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Compare("passWord", ErrorMessage = "Mật khẩu không khớp")]
        public string confirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email { get; set; }
    }
}
