using System.ComponentModel.DataAnnotations;

namespace Lipajoli.Models
{
    public class Usager
    {
        public int Id { get; set; }

        [Required]
        public string? NumeroAbonne { get; set; }

        [Required]
        public string? Nom { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Required]
        public StatutUsager Statut { get; set; }

        public int Defaillance { get; set; } = 0;

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Emprunt>? Emprunts { get; set; }
    }
    
}
