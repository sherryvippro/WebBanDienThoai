using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstSP = _context.TSp.Take(4).ToList();
            return View(lstSP);
        }
        public IActionResult ProductHeader()
        {
            string img = "slider";
            var sp = _context.TSp.Where(t => t.SoLuong > 0 && t.Anh.Contains(img)).Take(3).ToList();
            return PartialView(sp);
        }

        public IActionResult ProductApple()
        {
            string mah = "apple";
            var sp = _context.TSp.Where(t => t.MaHang == mah ).Take(4).ToList();
            return PartialView(sp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
