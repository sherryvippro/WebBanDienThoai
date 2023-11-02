using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class NguoidungsController : Controller
    {
        private readonly QLBanDTContext _context;

        public NguoidungsController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: Nguoidungs
        public async Task<IActionResult> Index()
        {
              return _context.Nguoidungs != null ? 
                          View(await _context.Nguoidungs.ToListAsync()) :
                          Problem("Entity set 'QLBanDTContext.Nguoidungs'  is null.");
        }

        // GET: Nguoidungs/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Nguoidungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nguoidungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNguoiDung,Hoten,Email,Dienthoai,Matkhau,Idquyen,Diachi,Anhdaidien")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoidung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoidung);
        }

        // GET: Nguoidungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nguoidungs == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            if (nguoidung == null)
            {
                return NotFound();
            }
            return View(nguoidung);
        }

        // POST: Nguoidungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNguoiDung,Hoten,Email,Dienthoai,Matkhau,Idquyen,Diachi,Anhdaidien")] Nguoidung nguoidung)
        {
            if (id != nguoidung.MaNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoidung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoidungExists(nguoidung.MaNguoiDung))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguoidung);
        }

        // GET: Nguoidungs/Delete/5
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
