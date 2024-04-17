using ApiRepositoryDapper.Model;
namespace ApiRepositoryDapper.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutosModel>> GetProdutosAsync();

        Task<ProdutosModel> GetProdutosAsyncId(int id);

        Task<IEnumerable<ProdutosModel>> CreateProdutos(ProdutosModel produto);

        Task<IEnumerable<ProdutosModel>> UpdateProdutosAsync(ProdutosModel produtos);

        Task<IEnumerable<ProdutosModel>> DeleteProdutos(int id);
    }
}
