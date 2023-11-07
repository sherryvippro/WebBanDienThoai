﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;
using WebBanDienThoai.Models.ViewModels;
using System.Drawing.Printing;
using WebBanDienThoai.Services;
using System.Net.NetworkInformation;


namespace WebBanDienThoai.Controllers
{
    public class THoaDonBansController : Controller
    {
        private readonly QLBanDTContext _context;
        private readonly ProductServices _productServices;
        public int pageSize = 10;

        public THoaDonBansController(QLBanDTContext context)
        {
            _context = context;
        }

        // GET: THoaDonBans
        [Route("HDB/List")]
        public async Task<IActionResult> Index(int invoiceOutPage = 1)
        {
            /*var qLBanDTContext = _context.THoaDonBans.Include(t => t.MaKhNavigation);
            return View(await qLBanDTContext.ToListAsync());*/

            return View(
                new InvoiceOutListViewModel
                {
                    InvoiceOut = _context.TChiTietHdbs.Include(t => t.SoHdbNavigation).Include(t => t.SoHdbNavigation.MaNguoiDung)
                    .Skip((invoiceOutPage - 1) * pageSize).Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        itemsPerPage = pageSize,
                        currentPage = invoiceOutPage,
                        totalItem = _context.TChiTietHdbs.Count()
                    }
                }
            ); ;

        }

        // GET: THoaDonBans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.THoaDonBans == null)
            {
                return NotFound();
            }

            var tHoaDonBan = await _context.THoaDonBans
                .Include(t => t.MaNguoiDung)
                .FirstOrDefaultAsync(m => m.SoHdb == id);
            if (tHoaDonBan == null)
            {
                return NotFound();
            }

            return View(tHoaDonBan);
        }

        // GET: THoaDonBans/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.Nguoidungs, "MaNguoiDung", "MaNguoiDung");
            return View();
        }

        // POST: THoaDonBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoHdb,NgayBan,MaNguoiDung,TongHdb,")] THoaDonBan tHoaDonBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tHoaDonBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.Nguoidungs, "MaNguoiDung", "MaNguoiDung", tHoaDonBan.MaNguoiDung);
            return View(tHoaDonBan);
        }

        // GET: THoaDonBans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.THoaDonBans == null)
            {
                return NotFound();
            }

            var tHoaDonBan = await _context.THoaDonBans.FindAsync(id);
            if (tHoaDonBan == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Nguoidungs, "MaNguoiDung", "MaNguoiDung", tHoaDonBan.MaNguoiDung);
            return View(tHoaDonBan);
        }

        // POST: THoaDonBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoHdb,NgayBan,MaKh,TongHdb")] THoaDonBan tHoaDonBan)
        {
            if (id != tHoaDonBan.SoHdb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tHoaDonBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!THoaDonBanExists(tHoaDonBan.SoHdb))
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
            ViewData["MaKh"] = new SelectList(_context.Nguoidungs, "MaNguoiDung", "MaNguoiDung", tHoaDonBan.MaNguoiDung);
            return View(tHoaDonBan);
        }

        // GET: THoaDonBans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.THoaDonBans == null)
            {
                return NotFound();
            }

            var tHoaDonBan = await _context.THoaDonBans
                .Include(t => t.MaNguoiDung)
                .FirstOrDefaultAsync(m => m.SoHdb == id);
            if (tHoaDonBan == null)
            {
                return NotFound();
            }

            return View(tHoaDonBan);
        }

        // POST: THoaDonBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.THoaDonBans == null)
            {
                return Problem("Entity set 'QLBanDTContext.THoaDonBans'  is null.");
            }
            var tHoaDonBan = await _context.THoaDonBans.FindAsync(id);
            if (tHoaDonBan != null)
            {
                _context.THoaDonBans.Remove(tHoaDonBan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool THoaDonBanExists(string id)
        {
          return (_context.THoaDonBans?.Any(e => e.SoHdb == id)).GetValueOrDefault();
        }
    }
}
