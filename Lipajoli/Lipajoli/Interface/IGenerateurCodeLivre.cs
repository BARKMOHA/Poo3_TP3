namespace Lipajoli.Interface
{
    public interface IGenerateurCodeLivre
    {
        Task<string> GenererCodeAsync(int CategorieId);

    }
}
