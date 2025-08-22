using System;
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
    public class UsagersController : Controller
    {
        private readonly BiblioContext _context;

        public UsagersController(BiblioContext context)
        {
            _context = context;
        }

        // GET: Usagers
        public async Task<IActionResult> Index(string searchString)
        {
            var usagers = from u in _context.Usagers
                          select u;

            if (!string.IsNullOrEmpty(searchString))
            {
                usagers = usagers.Where(u => u.Nom.Contains(searchString) || u.Prenom.Contains(searchString));
            }

            return View(await _context.Usagers.ToListAsync());
        }

        // GET: Usagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usager = await _context.Usagers
                .Include(u => u.Emprunts)
                .ThenInclude(e => e.Livre)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (usager == null)
            {
                return NotFound();
            }

            return View(usager);
        }

        // GET: Usagers/Create
        public IActionResult Create()
        {
            ViewBag.Statuts = new SelectList(Enum.GetValues(typeof(StatutUsager)));

            return View();
        }

        // POST: Usagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroAbonne,Nom,Prenom,Statut,Defaillance,Email")] Usager usager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usager);
        }

        // GET: Usagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usager = await _context.Usagers.FindAsync(id);
            if (usager == null)
            {
                return NotFound();
            }
            return View(usager);
        }

        // POST: Usagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroAbonne,Nom,Prenom,Statut,Defaillance,Email")] Usager usager)
        {
            if (id != usager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsagerExists(usager.Id))
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
            return View(usager);
        }

        // GET: Usagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usager = await _context.Usagers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usager == null)
            {
                return NotFound();
            }

            return View(usager);
        }

        // POST: Usagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usager = await _context.Usagers.FindAsync(id);
            if (usager != null)
            {
                _context.Usagers.Remove(usager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsagerExists(int id)
        {
            return _context.Usagers.Any(e => e.Id == id);
        }
    }
}
