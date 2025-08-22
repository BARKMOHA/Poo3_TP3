using Lipajoli.Models;

namespace Lipajoli.Data
{
    public class DbInitializer
    {

        //public static void Initialize(BiblioContext context)
        //{
        //    if (context.Livres.Any())
        //    {

        //        var lit = context.Categories.First(c => c.Nom.StartsWith("Lit", StringComparison.OrdinalIgnoreCase));
        //        var sci = context.Categories.First(c => c.Nom.StartsWith("Sci", StringComparison.OrdinalIgnoreCase));
        //        var inf = context.Categories.First(c => c.Nom.StartsWith("Inf", StringComparison.OrdinalIgnoreCase));
        //        var livres = new List<Livre>
        //    {
        //    new Livre
        //    {
        //        CodeUnique = "LIT001",
        //        Titre = "Les Misérables",
        //        ISBN10 = "1234567890",
        //        ISBN13 = "9781234567897",
        //        Quantite = 5,
        //        Prix = 25.00m,
        //        CategorieId = lit.Id
        //    },
        //    new Livre
        //    {
        //        CodeUnique = "LIT002",
        //        Titre = "1984",
        //        ISBN10 = "1234567894",
        //        ISBN13 = "9781234567801",
        //        Quantite = 3,
        //        Prix = 18.00m,
        //        CategorieId = lit.Id
        //    },
        //    new Livre
        //    {
        //        CodeUnique = "SCI001",
        //        Titre = "Les Principia",
        //        ISBN10 = "1234567892",
        //        ISBN13 = "9781234567899",
        //        Quantite = 2,
        //        Prix = 35.00m,
        //        CategorieId = sci.Id
        //    },
        //    new Livre
        //        {
        //        CodeUnique = "INF001",
        //        Titre = "Computing Machinery and Intelligence",
        //        ISBN10 = "1234567893",
        //        ISBN13 = "9781234567800",
        //        Quantite = 4,
        //        Prix = 30.00m,
        //        CategorieId = inf.Id
        //    }
        //    };

        //        context.Livres.AddRange(livres);
        //        context.SaveChanges();

        //        // Relations Livre <-> Auteur
        //        var auteurs = context.Auteurs.ToList();
        //        var livreBD = context.Livres.ToList();

        //        var livreAuteurs = new List<LivreAuteur>
        //    {
        //    new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Les Misérables").Id, AuteurId = auteurs.First(a => a.Nom == "Victor Hugo").Id },
        //    new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "1984").Id, AuteurId = auteurs.First(a => a.Nom == "George Orwell").Id },
        //    new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Les Principia").Id, AuteurId = auteurs.First(a => a.Nom == "Isaac Newton").Id },
        //    new LivreAuteur { LivreId = livreBD.First(b => b.Titre == "Computing Machinery and Intelligence").Id, AuteurId = auteurs.First(a => a.Nom == "Alan Turing").Id }
        //    };

        //        context.LivreAuteurs.AddRange(livreAuteurs);
        //        context.SaveChanges();

        //        // Vérifie si des usagers existent déjà
        //        if (!context.Usagers.Any())
        //        {
        //            var usagers = new List<Usager>
        //        {
        //            new Usager
        //            {
        //                NumeroAbonne = "U001",
        //                Nom = "Durand",
        //                Prenom = "Claire",
        //                Statut = StatutUsager.Etudiant,
        //                Email = "claire.durand@example.com"
        //            },
        //            new Usager
        //            {
        //                NumeroAbonne = "U002",
        //                Nom = "Lemoine",
        //                Prenom = "Jean",
        //                Statut = StatutUsager.Enseignant,
        //                Email = "jean.lemoine@example.com"
        //            }
        //        };

        //            context.Usagers.AddRange(usagers);
        //            context.SaveChanges();

        //            Console.WriteLine("Usagers ajoutés !");

        //        }

        //        if (!context.Emprunts.Any())
        //        {
        //            var usager1 = context.Usagers.First(u => u.NumeroAbonne == "U001");
        //            var usager2 = context.Usagers.First(u => u.NumeroAbonne == "U002");

        //            var livre1 = context.Livres.First(l => l.Titre == "1984");
        //            var livre2 = context.Livres.First(l => l.Titre == "Les Principia");

        //            var emprunts = new List<Emprunt>
        //        {
        //            new Emprunt
        //            {
        //                UsagerId = usager1.Id,
        //                LivreId = livre1.Id,
        //                DateEmprunt = DateTime.Now.AddDays(-10),
        //                DateRetour = null // non retourné
        //            },
        //            new Emprunt
        //            {
        //                UsagerId = usager2.Id,
        //                LivreId = livre2.Id,
        //                DateEmprunt = DateTime.Now.AddDays(-20),
        //                DateRetour = DateTime.Now.AddDays(-5) // déjà retourné
        //            }
        //        };

        //            context.Emprunts.AddRange(emprunts);
        //            context.SaveChanges();
        //        }

        public static void Initialize(BiblioContext context)
        {
            Console.WriteLine("Début de l'initialisation...");

            // Initialiser les livres s’ils n’existent pas
            if (!context.Livres.Any())
            {
                var lit = context.Categories.First(c => c.Nom.StartsWith("Lit", StringComparison.OrdinalIgnoreCase));
                var sci = context.Categories.First(c => c.Nom.StartsWith("Sci", StringComparison.OrdinalIgnoreCase));
                var inf = context.Categories.First(c => c.Nom.StartsWith("Inf", StringComparison.OrdinalIgnoreCase));

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

                Console.WriteLine("Livres ajoutés !");
            }

            // Relations Livre <-> Auteur
            if (!context.LivreAuteurs.Any())
            {
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
                Console.WriteLine("Relations Livre-Auteur ajoutées !");
            }

            // Usagers
            if (!context.Usagers.Any())
            {
                var usagers = new List<Usager>
        {
            new Usager
            {
                NumeroAbonne = "U001",
                Nom = "Durand",
                Prenom = "Claire",
                Statut = StatutUsager.Etudiant,
                Email = "claire.durand@example.com"
            },
            new Usager
            {
                NumeroAbonne = "U002",
                Nom = "Lemoine",
                Prenom = "Jean",
                Statut = StatutUsager.Enseignant,
                Email = "jean.lemoine@example.com"
            }
        };

                context.Usagers.AddRange(usagers);
                context.SaveChanges();
                Console.WriteLine("Usagers ajoutés !");
            }

            // Emprunts
            if (!context.Emprunts.Any())
            {
                var usager1 = context.Usagers.First(u => u.NumeroAbonne == "U001");
                var usager2 = context.Usagers.First(u => u.NumeroAbonne == "U002");

                var livre1 = context.Livres.First(l => l.Titre == "1984");
                var livre2 = context.Livres.First(l => l.Titre == "Les Principia");

                var emprunts = new List<Emprunt>
        {
            new Emprunt
            {
                UsagerId = usager1.Id,
                LivreId = livre1.Id,
                DateEmprunt = DateTime.Now.AddDays(-10),
                DateRetour = null
            },
            new Emprunt
            {
                UsagerId = usager2.Id,
                LivreId = livre2.Id,
                DateEmprunt = DateTime.Now.AddDays(-20),
                DateRetour = DateTime.Now.AddDays(-5)
            }
        };

                context.Emprunts.AddRange(emprunts);
                context.SaveChanges();
                Console.WriteLine("Emprunts ajoutés !");
            }

            Console.WriteLine("✅ Initialisation terminée !");
        }




    }
}
