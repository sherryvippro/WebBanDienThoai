using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class DanhMucSPController : Controller
    {
        QLBanDTContext _context = new QLBanDTContext();
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult partialViewSPHome()
        {

            var lstSachHome = _context.TSp.Take(8).ToList();
            return PartialView(lstSachHome);
        }

        public async Task<IActionResult> Details(string id)
        {
            var product = _context.TSp.Where(s => s.MaSp == id).FirstOrDefault();
            return View();
        }
    }
}
