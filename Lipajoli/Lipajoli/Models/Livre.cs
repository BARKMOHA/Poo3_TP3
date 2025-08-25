using System.ComponentModel.DataAnnotations;

namespace Lipajoli.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string? CodeUnique { get; set; }

        [Required(ErrorMessage = "Le numéro ISBN10 est obligatoire.")]
        [StringLength(10, ErrorMessage = "ISBN10 doit avoir 10 caractères.")]
        public string? ISBN10 { get; set; }

        [Required(ErrorMessage = "Le numéro ISBN10 est obligatoire.")]
        [StringLength(13, ErrorMessage = "ISBN13 doit avoir 13 caractères.")]
        public string? ISBN13 { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public string? Titre { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire.")]
        public int CategorieId  { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif.")]
        public int Quantite { get; set; }

        [Range(0, 999.99, ErrorMessage = "Le prix doit être un montant positif.")]
        public decimal Prix { get; set; }   
        
        public List<LivreAuteur>? LivreAuteurs { get; set; } 
        public CategorieLivre? Categorie { get; set; }
    }
}
