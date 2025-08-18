namespace Lipajoli.Models
{
    public class Livre
    {
        public string? CodeUnique { get; set; }  
        public string? ISBN10 { get; set; }      
        public string? ISBN13 { get; set; }      
        public string? Titre { get; set; }
        public ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
        public CategorieLivre? Categorie { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
    }
}
