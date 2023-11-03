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
    public class PhanQuyensController : Controller
    {
        private readonly QLBanDTContext _context;

        public PhanQuyensController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: PhanQuyens
        public async Task<IActionResult> Index()
        {
              return _context.PhanQuyens != null ? 
                          View(await _context.PhanQuyens.ToListAsync()) :
                          Problem("Entity set 'QLBanDTContext.PhanQuyens'  is null.");
        }

        // GET: PhanQuyens/Details/5
       

        // GET: PhanQuyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanQuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.IDQuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanQuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanQuyenExists(phanQuyen.IDQuyen))
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
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens
                .FirstOrDefaultAsync(m => m.IDQuyen == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // POST: PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhanQuyens == null)
            {
                return Problem("Entity set 'QLBanDTContext.PhanQuyens'  is null.");
            }
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen != null)
            {
                _context.PhanQuyens.Remove(phanQuyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanQuyenExists(int id)
        {
          return (_context.PhanQuyens?.Any(e => e.IDQuyen == id)).GetValueOrDefault();
        }
    }
}
