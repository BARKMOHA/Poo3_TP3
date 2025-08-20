namespace Lipajoli.Models
{
    public class LivreAuteur
    {
        public int LivreId {  get; set; }
        public Livre? Livre { get; set; }

        public int? AuteurId { get; set; }

        public Auteur? Auteur { get; set; } 
    }
}
