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
    public class TSpsController : Controller
    {
        private readonly QLBanDTContext _context;

        public TSpsController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: TSps
        public async Task<IActionResult> Index()
        {
              return _context.TSp != null ? 
                          View(await _context.TSp.ToListAsync()) :
                          Problem("Entity set 'QLBanDTContext.TSp'  is null.");
        }

        // GET: TSps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TSp == null)
            {
                return NotFound();
            }

            var tSp = await _context.TSp
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (tSp == null)
            {
                return NotFound();
            }

            return View(tSp);
        }

        // GET: TSps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,MaTl,MaHang,DonGiaNhap,DonGiaBan,SoLuong,Anh")] TSp tSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tSp);
        }

        // GET: TSps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TSp == null)
            {
                return NotFound();
            }

            var tSp = await _context.TSp.FindAsync(id);
            if (tSp == null)
            {
                return NotFound();
            }
            return View(tSp);
        }

        // POST: TSps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSp,TenSp,MaTl,MaHang,DonGiaNhap,DonGiaBan,SoLuong,Anh")] TSp tSp)
        {
            if (id != tSp.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSpExists(tSp.MaSp))
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
            return View(tSp);
        }

        // GET: TSps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TSp == null)
            {
                return NotFound();
            }

            var tSp = await _context.TSp
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (tSp == null)
            {
                return NotFound();
            }

            return View(tSp);
        }

        // POST: TSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TSp == null)
            {
                return Problem("Entity set 'QLBanDTContext.TSp'  is null.");
            }
            var tSp = await _context.TSp.FindAsync(id);
            if (tSp != null)
            {
                _context.TSp.Remove(tSp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TSpExists(string id)
        {
          return (_context.TSp?.Any(e => e.MaSp == id)).GetValueOrDefault();
        }
    }
}
