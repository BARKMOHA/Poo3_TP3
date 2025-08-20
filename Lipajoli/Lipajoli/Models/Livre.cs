namespace Lipajoli.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string? CodeUnique { get; set; }  
        public string? ISBN10 { get; set; }      
        public string? ISBN13 { get; set; }      
        public string? Titre { get; set; }
        public List<LivreAuteur>? LivreAuteurs { get; set; } 
        public CategorieLivre? Categorie { get; set; }
        public int CategorieId  { get; set; }        

        public int Quantite { get; set; }
        public decimal Prix { get; set; }
    }
}
