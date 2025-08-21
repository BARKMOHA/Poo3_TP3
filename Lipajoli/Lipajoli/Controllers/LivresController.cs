using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lipajoli.Data;
using Lipajoli.Models;
using Lipajoli.Interface;

namespace Lipajoli.Controllers
{
    public class LivresController : Controller
    {
        private readonly BiblioContext _context;
        private readonly IGenerateurCodeLivre _generateurCode;
        public LivresController(BiblioContext context, IGenerateurCodeLivre generateurCode)
        {
            _context = context;
            _generateurCode = generateurCode;
        }

        // GET: Livres
        public async Task<IActionResult> Index(string searchString, string categoryFilter, string authorFilter, string sortOrder)
        {
            var livres = _context.Livres
                .Include(b => b.Categorie)
                .Include(b => b.LivreAuteurs)
                    .ThenInclude(ba => ba.Auteur)
                .AsQueryable();

            //  Filtres
            if (!string.IsNullOrEmpty(searchString))
            {
                livres = livres.Where(b => b.Titre.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                livres = livres.Where(b => b.Categorie.Nom == categoryFilter);
            }

            if (!string.IsNullOrEmpty(authorFilter))
            {
                livres = livres.Where(b => b.LivreAuteurs.Any(ba => ba.Auteur.Nom.Contains(authorFilter)));
            }

            // Tri
            ViewBag.CodeSortParam = string.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.TitleSortParam = sortOrder == "Title" ? "title_desc" : "Title";

            livres = sortOrder switch
            {
                "code_desc" => livres.OrderByDescending(b => b.CodeUnique),
                "Title" => livres.OrderBy(b => b.Titre),
                "title_desc" => livres.OrderByDescending(b => b.Titre),
                _ => livres.OrderBy(b => b.CodeUnique),
            };

            

            return View(await livres.ToListAsync());
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
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Nom");
            return View();
        }

        // POST: Livres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Livre livre)
        {
            if (ModelState.IsValid)
            {
                livre.CodeUnique= await _generateurCode.GenererCodeAsync(livre.CategorieId);

                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateCategoriesDropDownList(livre.CategorieId);
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

        private void PopulateCategoriesDropDownList(object selectedCategoryId =null)
        {
            var categories = _context.Categories
                .OrderBy(c => c.Nom)
                .ToList();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Nom", selectedCategoryId);
        }
    }
}
