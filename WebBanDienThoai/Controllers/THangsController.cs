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
    public class THangsController : Controller
    {
        private readonly QLBanDTContext _context;

        public THangsController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: THangs
        public async Task<IActionResult> Index()
        {
            return _context.THangs != null ?
                        View(await _context.THangs.ToListAsync()) :
                        Problem("Entity set 'QLBanDTContext.THangs'  is null.");
        }

        // GET: THangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: THangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang")] THang tHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tHang);
        }

        // GET: THangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.THangs == null)
            {
                return NotFound();
            }

            var tHang = await _context.THangs.FindAsync(id);
            if (tHang == null)
            {
                return NotFound();
            }
            return View(tHang);
        }

        // POST: THangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHang,TenHang")] THang tHang)
        {
            if (id != tHang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!THangExists(tHang.MaHang))
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
            return View(tHang);
        }

        // GET: THangs/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.THangs == null)
            {
                return NotFound();
            }

            var tHang = await _context.THangs
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (tHang == null)
            {
                return NotFound();
            }

            return View(tHang);
        }

        // POST: THangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.THangs == null)
            {
                return Problem("Entity set 'QLBanDTContext.THangs'  is null.");
            }
            var tHang = await _context.THangs.FindAsync(id);
            if (tHang != null)
            {
                _context.THangs.Remove(tHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool THangExists(string id)
        {
          return (_context.THangs?.Any(e => e.MaHang == id)).GetValueOrDefault();
        }
    }
}
