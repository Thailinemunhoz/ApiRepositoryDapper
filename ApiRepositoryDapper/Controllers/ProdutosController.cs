using ApiRepositoryDapper.Model;
using ApiRepositoryDapper.Service;
using Microsoft.AspNetCore.Mvc;
namespace ApiRepositoryDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoServive _produtoService;

        public ProdutosController(IProdutoServive produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> GetProdutosAsync()
        {
            try
            {
                IEnumerable<ProdutosModel> produtos = await _produtoService.GetProdutosAsync();
                return Ok(produtos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProdutosModel>> GetProdutosAsyncId(int id)
        {
            var response = await _produtoService.GetProdutosAsyncId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> CreateProdutos(ProdutosModel produto)
        {
            IEnumerable <ProdutosModel> produtos = await _produtoService.CreateProdutos(produto);

            return Ok(produtos);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> DeleteProdutos(int id)
        {
            IEnumerable<ProdutosModel> produtos = await _produtoService.DeleteProdutos(id);
            return Ok(produtos);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> UpdateProdutosAsync(ProdutosModel produto)
        {
            IEnumerable<ProdutosModel> produtos = await _produtoService.UpdateProdutosAsync(produto);
            return Ok(produtos);
        }
    }
}
