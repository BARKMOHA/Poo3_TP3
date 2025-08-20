namespace Lipajoli.Models
{
    public class CategorieLivre
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public List<Livre>? Livres{ get; set; }
    }
}