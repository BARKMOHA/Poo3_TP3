namespace Lipajoli.Models
{
    public class CategorieLivre
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public List<Livre>? Livres { get; set; }
    }
}