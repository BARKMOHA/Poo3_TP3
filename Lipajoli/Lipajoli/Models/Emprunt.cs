namespace Lipajoli.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public int UsagerId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }

        public Livre? Livre { get; set; }
        public Usager? Usager { get; set; }
    }
}
