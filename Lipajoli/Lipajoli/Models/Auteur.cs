namespace Lipajoli.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public List<LivreAuteur>? LivreAuteurs { get; set; }
    }
}
