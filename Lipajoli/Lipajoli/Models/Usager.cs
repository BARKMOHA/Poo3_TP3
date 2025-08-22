using System.ComponentModel.DataAnnotations;

namespace Lipajoli.Models
{
    public class Usager
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro d’abonné est obligatoire.")]
        public string? NumeroAbonne { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string? Prenom { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire.")]
        public StatutUsager Statut { get; set; }

        [Required(ErrorMessage = "L’adresse courriel est obligatoire.")]
        [EmailAddress(ErrorMessage = "L’adresse courriel n’est pas valide.")]
        public string? Email { get; set; }

        public int Defaillance { get; set; } = 0;

        public ICollection<Emprunt>? Emprunts { get; set; }
    }
    
}
