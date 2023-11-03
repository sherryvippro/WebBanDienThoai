using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;
using X.PagedList;

namespace WebBanDienThoai.Controllers
{
    public class NguoidungsController : BaseController
    {
        private readonly QLBanDTContext _context = new QLBanDTContext();
        
        public NguoidungsController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: Nguoidungs
        public async Task<IActionResult> Index()
        {
            var nguoidungs = await _context.Nguoidungs
                .Join(_context.PhanQuyens, p => p.MaNguoiDung, u => u.IDQuyen,
                    (p, u) => new User_Role
                    {
                        Hoten = p.Hoten,
                        Email = p.Email,
                        Matkhau = p.Matkhau,
                        Diachi = p.Diachi,
                        TenQuyen = u.TenQuyen
                    })
            .ToListAsync();

            return View(nguoidungs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Nguoidungs == null)
            {
                return NotFound();
            }

            var nguoidung = _context.Nguoidungs.Include(u=>u.IDQuyen)
                .FirstOrDefault(m => m.MaNguoiDung == id);
            if (nguoidung == null)
            {
                return NotFound();
            }
            ViewData["IDQuyen"] = new SelectList(_context.PhanQuyens, "IDQuyen", "TenQuyen");
            return View(nguoidung);
        }
        public IActionResult Create()
        {
            return View();  
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nguoidungs == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidungs
                .FirstOrDefaultAsync(m => m.MaNguoiDung == id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return View(nguoidung);
        }

        // POST: Nguoidungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nguoidungs == null)
            {
                return Problem("Entity set 'QLBanDTContext.Nguoidungs'  is null.");
            }
            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            if (nguoidung != null)
            {
                _context.Nguoidungs.Remove(nguoidung);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoidungExists(int id)
        {
          return (_context.Nguoidungs?.Any(e => e.MaNguoiDung == id)).GetValueOrDefault();
        }
    }
}
