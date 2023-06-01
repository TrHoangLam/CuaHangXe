﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangXe.Data;
using CuaHangXe.Models;

namespace CuaHangXe.Controllers
{
    public class XesController : Controller
    {
        private readonly CuaHangXeContext _context;

        public XesController(CuaHangXeContext context)
        {
            _context = context;
        }

        // GET: Xes
        public async Task<IActionResult> Index()
        {
              return _context.Xe != null ? 
                          View(await _context.Xe.ToListAsync()) :
                          Problem("Entity set 'CuaHangXeContext.Xe'  is null.");
        }

        // GET: Xes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }
            var xe = await _context.Xe
            .FirstOrDefaultAsync(m => m.Id == id);
            if (xe == null)
            {
                return NotFound();
            }
            return View(xe);

        }

        // GET: Xes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Xes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Xe xe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xe);
        }

        // GET: Xes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }

            var xe = await _context.Xe.FindAsync(id);
            if (xe == null)
            {
                return NotFound();
            }
            return View(xe);
        }

        // POST: Xes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Xe xe)
        {
            if (id != xe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XeExists(xe.Id))
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
            return View(xe);
        }

        // GET: Xes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }

            var xe = await _context.Xe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        // POST: Xes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Xe == null)
            {
                return Problem("Entity set 'CuaHangXeContext.Xe'  is null.");
            }
            var xe = await _context.Xe.FindAsync(id);
            if (xe != null)
            {
                _context.Xe.Remove(xe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XeExists(int id)
        {
          return (_context.Xe?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
