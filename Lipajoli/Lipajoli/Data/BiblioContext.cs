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


    }
}
