using Lipajoli.Data;
using Lipajoli.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lipajoli.Service
{
    public class GenerateurCodeLivreService : IGenerateurCodeLivre
    {
        
            private readonly BiblioContext _context;

            public GenerateurCodeLivreService(BiblioContext context)
            {
                _context = context;
            }

            public async Task<string> GenererCodeAsync(int categorieId)
            {
            // 1. Récupérer la catégorie
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categorieId);

            if (category == null)
                throw new ArgumentException("Catégorie inconnue.");

            var categoryCode = category.Code;

            // 2. Compter les livres existants pour cette catégorie
            var count = await _context.Livres
                .CountAsync(b => b.CategorieId == categorieId);

            // 3. Générer le code : "LIT001", "SCI002", etc.
            var bookCode = $"{categoryCode}{(count + 1):D3}";

            return bookCode;
        }
    }
        

    
}
