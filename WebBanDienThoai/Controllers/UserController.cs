using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Models;
using WebBanDienThoai.Models.ViewModels;

namespace WebBanDienThoai.Controllers
{
    public class UserController : Controller
    {
        private readonly QLBanDTContext _context;
        public UserController(QLBanDTContext context)
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
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord))
            {
                ViewBag.Error = "Chưa nhập email và mật khẩu";
                return View();
            }
            var user = _context.Nguoidungs.Where(t => t.Email == userName).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Tài khoản không tồn tại";
                return View();
            }
            if (user.Matkhau != passWord)
            {
                ViewBag.Error = "Mật khẩu không đúng";
            }
            HttpContext.Session.SetString("Email", user.Email);

            // return trang san pham hoac admin
            if (user.IDQuyen == 1)
            {
                return RedirectToAction("Index", "TSps");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }
        public IActionResult SignUp()
        {
            return View("SignUp");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignupViewModel signupViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Nguoidung()
                {
                    Hoten = signupViewModel.Name,
                    Matkhau = signupViewModel.passWord,
                    Email = signupViewModel.email
                };
                _context.Nguoidungs.Add(user);
                _context.SaveChanges();
                return View("Login");

            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
            }
            return View("SignUp");
        }
    }
}
