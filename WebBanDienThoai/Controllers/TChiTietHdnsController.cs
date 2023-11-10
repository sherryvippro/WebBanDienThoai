using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;
using WebBanDienThoai.Services;

namespace WebBanDienThoai.Controllers
{
    public class TChiTietHdnsController : BaseController
    {
        private readonly QLBanDTContext _context;

        public TChiTietHdnsController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: TChiTietHdns
        public async Task<IActionResult> Index(string id)
        {
            var qLBanDTContext = _context.TChiTietHdns.Where(t => t.SoHdn == id)
                .Include(t => t.MaSpNavigation).Include(t => t.SoHdnNavigation).Include(t => t.SoHdnNavigation.MaNccNavigation);
            ViewBag.SoHdn = id;
            return View(await qLBanDTContext.ToListAsync());
        }

        // GET: TChiTietHdns/Details/5
        public async Task<IActionResult> Details(string id, string maSp)
        {
            if (id == null || _context.TChiTietHdns == null)
            {
                return NotFound();
            }

            var tChiTietHdn = await _context.TChiTietHdns.Where(x => x.SoHdn == id && x.MaSp == maSp).FirstOrDefaultAsync();

            if (tChiTietHdn == null)
            {
                return NotFound();
            }
            ViewData["SoHdn"] = id;
            return View(tChiTietHdn);
        }

        // GET: TChiTietHdns/Create
        public IActionResult Create(string id)
        {
            ViewData["MaSp"] = new SelectList(_context.TSp, "MaSp", "TenSp");

            ViewBag.SoHdn = id;
            /*ViewData["MaNcc"] = new SelectList(_context.THoaDonNhaps, "MaNcc", "TenNcc");*/
            return View();
        }

        // POST: TChiTietHdns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoHdn,MaSp,Slnhap,KhuyenMai")] TChiTietHdn tChiTietHdn)
        {
            try
            {
                _context.Add(tChiTietHdn);
                var hoaDonNhap = await _context.THoaDonNhaps.FindAsync(tChiTietHdn.SoHdn);
                var sp = await _context.TSp.FindAsync(tChiTietHdn.MaSp);
                hoaDonNhap.TongHdn += tChiTietHdn.Slnhap * sp.DonGiaNhap;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = tChiTietHdn.SoHdn });
            }
            catch (Exception)
            {

                ViewData["MaSp"] = new SelectList(_context.TSp, "MaSp", "TenSp", tChiTietHdn.MaSp);

                return View(tChiTietHdn);
            }

        }

        // GET: TChiTietHdns/Edit/5
        public async Task<IActionResult> Edit(string id, string maSp)
        {
            if (id == null || _context.TChiTietHdns == null)
            {
                return NotFound();
            }

            var tChiTietHdn = await _context.TChiTietHdns.Where(x => x.SoHdn == id && x.MaSp == maSp).FirstOrDefaultAsync();
            if (tChiTietHdn == null)
            {
                return NotFound();
            }
            return View(tChiTietHdn);
        }

        // POST: TChiTietHdns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string maSp, [Bind("SoHdn,MaSp,Slnhap,KhuyenMai")] TChiTietHdn tChiTietHdn)
        {
            if (id != tChiTietHdn.SoHdn)
            {
                return NotFound();
            }

            try
            {
                var hoaDonNhap = await _context.THoaDonNhaps.FindAsync(id);
                var sp = await _context.TSp.FindAsync(maSp);
                var chiTiet = await _context.TChiTietHdns.Where(_x => _x.SoHdn == id && _x.MaSp == maSp).FirstOrDefaultAsync();
                hoaDonNhap.TongHdn -= chiTiet.Slnhap * sp.DonGiaNhap;
                hoaDonNhap.TongHdn += tChiTietHdn.Slnhap * sp.DonGiaNhap;
                chiTiet.Slnhap = tChiTietHdn.Slnhap;
                chiTiet.KhuyenMai = tChiTietHdn.KhuyenMai;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id });
            }
            catch (DbUpdateConcurrencyException)
            {
                
                ViewData["MaSp"] = new SelectList(_context.TSp, "MaSp", "MaSp", tChiTietHdn.MaSp);
                ViewData["SoHdn"] = new SelectList(_context.THoaDonNhaps, "SoHdn", "SoHdn", tChiTietHdn.SoHdn);
                return View(tChiTietHdn);
            }



        }

        // GET: TChiTietHdns/Delete/5
        public async Task<IActionResult> Delete(string id, string maSp)
        {
            if (id == null || _context.TChiTietHdns == null)
            {
                return NotFound();
            }

            var tChiTietHdn = await _context.TChiTietHdns.Where(x => x.SoHdn == id && x.MaSp == maSp).FirstOrDefaultAsync();

            if (tChiTietHdn == null)
            {
                return NotFound();
            }
            ViewData["SoHdn"] = id;

            return View(tChiTietHdn);
        }

        // POST: TChiTietHdns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string maSp)
        {
            if (_context.TChiTietHdns == null)
            {
                return Problem("Entity set 'QLBanDTContext.TChiTietHdns'  is null.");
            }
            var tChiTietHdn = await _context.TChiTietHdns.Where(x => x.SoHdn == id && x.MaSp == maSp).FirstOrDefaultAsync();
            if (tChiTietHdn != null)
            {
                var hoaDonNhap = await _context.THoaDonNhaps.FindAsync(id);
                var sp = await _context.TSp.FindAsync(maSp);
                hoaDonNhap.TongHdn -= tChiTietHdn.Slnhap * sp.DonGiaNhap;
                _context.TChiTietHdns.Remove(tChiTietHdn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TChiTietHdnExists(string id)
        {
            return (_context.TChiTietHdns?.Any(e => e.SoHdn == id)).GetValueOrDefault();
        }
    }
}
