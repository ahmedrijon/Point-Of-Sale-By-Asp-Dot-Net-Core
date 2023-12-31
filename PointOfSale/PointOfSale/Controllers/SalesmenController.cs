﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.Models;

namespace PointOfSale.Controllers
{
    public class SalesmenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salesmen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salesman.ToListAsync());
        }

        // GET: Salesmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
        }

        // GET: Salesmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salesmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpId,Name,Contact,Email,Password")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesman);
        }

        // GET: Salesmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesman.FindAsync(id);
            if (salesman == null)
            {
                return NotFound();
            }
            return View(salesman);
        }

        // POST: Salesmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpId,Name,Contact,Email,Password")] Salesman salesman)
        {
            if (id != salesman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanExists(salesman.Id))
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
            return View(salesman);
        }

        // GET: Salesmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesman = await _context.Salesman.FindAsync(id);
            _context.Salesman.Remove(salesman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesman.Any(e => e.Id == id);
        }
    }
}
