using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class LoginController : Controller
    {
        private readonly QLBanDTContext _context;
        public LoginController(QLBanDTContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string passWord)
        {
            if(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord))
            {
                ViewBag.Error = "Chưa nhập username và password";
                return View();
            }
            var user = _context.Nguoidungs.SingleOrDefault(t => t.Email == userName);
            if(user == null)
            {
                ViewBag.Error = "Tài khoản không tồn tại";
                return View();
            }
            if(user.Matkhau != passWord)
            {
                ViewBag.Error = "Mật khẩu không đúng";
            }
            //session
            return RedirectToAction("Index");
        }

    }
}
