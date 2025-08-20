using Lipajoli.Models;
using Microsoft.EntityFrameworkCore;

namespace Lipajoli.Data
{
    public class BiblioContext : DbContext
    {
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options) { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<CategorieLivre> Categories { get; set; }
        public DbSet<LivreAuteur> LivreAuteurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clé primaire composite pour BookAuthor
            modelBuilder.Entity<LivreAuteur>()
                .HasKey(ba => new { ba.LivreId, ba.AuteurId });

            // Relation Book <-> BookAuthor
            modelBuilder.Entity<LivreAuteur>()
                .HasOne(ba => ba.Livre)
                .WithMany(b => b.LivreAuteurs)
                .HasForeignKey(ba => ba.LivreId);

            modelBuilder.Entity<LivreAuteur>()
                .HasOne(ba => ba.Auteur)
                .WithMany(a => a.LivreAuteurs)
                .HasForeignKey(ba => ba.AuteurId);

            // Relation Book <-> Category par CategoryName
            modelBuilder.Entity<Livre>()
                .HasOne(b => b.Categorie)
                .WithMany(c => c.Livres)
                .HasForeignKey(b => b.NomCategorie)
                .HasPrincipalKey(c => c.Nom);

            // Contraindre Code à être unique
            modelBuilder.Entity<Livre>()
                .HasIndex(b => b.CodeUnique)
                .IsUnique();

            // Contraindre Category.Name à être unique (pour pouvoir faire la FK)
            modelBuilder.Entity<CategorieLivre>()
                .HasIndex(c => c.Nom)
                .IsUnique();
        }
    }

}
