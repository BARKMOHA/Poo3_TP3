﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lipajoli.Data;
using Lipajoli.Models;

namespace Lipajoli.Controllers
{
    public class LivresController : Controller
    {
        private readonly BiblioContext _context;

        public LivresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: Livres
        public async Task<IActionResult> Index()
        {
            var biblioContext = _context.Livres.Include(l => l.Categorie);
            return View(await biblioContext.ToListAsync());
        }

        // GET: Livres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .Include(l => l.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // GET: Livres/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Livres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodeUnique,ISBN10,ISBN13,Titre,CategorieId,Quantite,Prix")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", livre.CategorieId);
            return View(livre);
        }

        // GET: Livres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", livre.CategorieId);
            return View(livre);
        }

        // POST: Livres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeUnique,ISBN10,ISBN13,Titre,CategorieId,Quantite,Prix")] Livre livre)
        {
            if (id != livre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.Id))
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
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", livre.CategorieId);
            return View(livre);
        }

        // GET: Livres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .Include(l => l.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre != null)
            {
                _context.Livres.Remove(livre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(int id)
        {
            return _context.Livres.Any(e => e.Id == id);
        }
    }
}
