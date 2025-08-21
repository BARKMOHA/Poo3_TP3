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
                var category = await _context.Categories
               
                .FirstOrDefaultAsync(c => c.Id == categorieId);

                if (category == null)
                    throw new Exception("Catégorie introuvable.");

                string prefix = category.Nom.Length >= 3
                    ? category.Nom.Substring(0, 3).ToUpper()
                    : category.Nom.ToUpper().PadRight(3, 'X'); 

                // Compter combien de livres existent déjà avec ce préfixe
                int count = await _context.Livres
                    .CountAsync(b => b.CodeUnique.StartsWith(prefix));

                // Incrémenter et formater : INF001, INF002
                string code = $"{prefix}{(count + 1):D3}";

                return code;
        }
    }
        

    
}
