using Lipajoli.Models;

namespace Lipajoli.Data
{
    public class DbInitializer
    {
        
            public static void Initialize(BiblioContext context)
            {
                if (context.Livres.Any()) return;

            var lit = context.Categories.First(c => c.Code == "LIT");
            var sci = context.Categories.First(c => c.Code == "SCI");
            var inf = context.Categories.First(c => c.Code == "INF");
            var livres = new List<Livre>
            {
            new Livre
            {
                CodeUnique = "LIT001",
                Titre = "Les Misérables",
                ISBN10 = "1234567890",
                ISBN13 = "9781234567897",
                Quantite = 5,
                Prix = 25.00m,
                CategorieId = lit.Id
            },
            new Livre
            {
                CodeUnique = "LIT002",
                Titre = "1984",
                ISBN10 = "1234567894",
                ISBN13 = "9781234567801",
                Quantite = 3,
                Prix = 18.00m,
                CategorieId = lit.Id
            },
            new Livre
            {
                CodeUnique = "SCI001",
                Titre = "Les Principia",
                ISBN10 = "1234567892",
                ISBN13 = "9781234567899",
                Quantite = 2,
                Prix = 35.00m,
                CategorieId = sci.Id
            },
            new Livre
                {
                CodeUnique = "INF001",
                Titre = "Computing Machinery and Intelligence",
                ISBN10 = "1234567893",
                ISBN13 = "9781234567800",
                Quantite = 4,
                Prix = 30.00m,
                CategorieId = inf.Id
            }
            };

                context.Livres.AddRange(livres);
                context.SaveChanges();

                // Relations Livre <-> Auteur
                var auteurs = context.Auteurs.ToList();
                var livreBD = context.Livres.ToList();

                var livreAuteurs = new List<LivreAuteur>
            {
            new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Les Misérables").Id, AuteurId = auteurs.First(a => a.Nom == "Victor Hugo").Id },
            new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "1984").Id, AuteurId = auteurs.First(a => a.Nom == "George Orwell").Id },
            new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Les Principia").Id, AuteurId = auteurs.First(a => a.Nom == "Isaac Newton").Id },
            new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Computing Machinery and Intelligence").Id, AuteurId = auteurs.First(a => a.Nom == "Alan Turing").Id }
            };

                context.LivreAuteurs.AddRange(livreAuteurs);
                context.SaveChanges();
            }
        

    }
}
