using ApiRepositoryDapper.Model;
using ApiRepositoryDapper.Repository;
namespace ApiRepositoryDapper.Service
{
    public class ProdutoService : IProdutoServive
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutosModel>> CreateProdutos(ProdutosModel produto)
        {
            IEnumerable<ProdutosModel> produtosModels = await _produtoRepository.CreateProdutos(produto);
            return produtosModels;
        }

        public async Task<IEnumerable<ProdutosModel>> DeleteProdutos(int id)
        {
           IEnumerable<ProdutosModel> produtosModels = await _produtoRepository.DeleteProdutos(id);
           if (produtosModels == null)
            {
                throw new Exception("Registro não encontrado");
            }
           return produtosModels;
        }

        public async Task<IEnumerable<ProdutosModel>> GetProdutosAsync()
        {
            var response = await _produtoRepository.GetProdutosAsync();

            if (response == null)
            {
                throw new Exception("Nenhum registro encontrado com esse id");
            }

            return response;
        }

        public async Task<ProdutosModel> GetProdutosAsyncId(int id)
        {
            var response = await _produtoRepository.GetProdutosAsyncId(id);

            if (response == null)
            {
                throw new Exception("Sem registros");
            }

            return response;
        }

        public async Task<IEnumerable<ProdutosModel>> UpdateProdutosAsync(ProdutosModel produto)
        {
            IEnumerable<ProdutosModel> produtos = await _produtoRepository.UpdateProdutosAsync(produto);

            if(produtos == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return produtos;
        }
    }
}
