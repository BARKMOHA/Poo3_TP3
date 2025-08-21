using System.ComponentModel.DataAnnotations;

namespace Lipajoli.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string? CodeUnique { get; set; }
        [Required]
        public string? ISBN10 { get; set; }
        [Required]
        public string? ISBN13 { get; set; }
        [Required]
        public string? Titre { get; set; }
        public List<LivreAuteur>? LivreAuteurs { get; set; } 
        public CategorieLivre? Categorie { get; set; }
        public int CategorieId  { get; set; }
        [Required]
        public int Quantite { get; set; }
        [Required]
        public decimal Prix { get; set; }
    }
}
