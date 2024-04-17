using ApiRepositoryDapper.Model;
using Dapper;
using System.Data.SqlClient;
namespace ApiRepositoryDapper.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ProdutosModel>> CreateProdutos(ProdutosModel produto)
        {
            using (var con  = new SqlConnection(getConnection))
            {
                var sql = "INSERT INTO Produto (nome,descricao, preco) VALUES (@nome, @descricao, @preco)";
                await con.ExecuteAsync(sql, produto);
                return await con.QueryAsync<ProdutosModel>("select * from produto");
            }
        }

        public async Task<IEnumerable<ProdutosModel>> DeleteProdutos(int id)
        {
            using ( var con = new SqlConnection(getConnection))
            {
                var sql = "Delete from Produto where id = @id";
                await con.ExecuteAsync(sql, new { Id = id });
                return await con.QueryAsync<ProdutosModel>("select * from produto");
            }
        }

        public async Task<IEnumerable<ProdutosModel>> GetProdutosAsync()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Produto";
                return await con.QueryAsync<ProdutosModel>(sql);
            }
        }

        public async Task<ProdutosModel> GetProdutosAsyncId(int id)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM Produto WHERE Id = @Id";
                return await con.QueryFirstOrDefaultAsync<ProdutosModel>(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProdutosModel>> UpdateProdutosAsync(ProdutosModel produto)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "update Produto set nome = @nome, descricao = @descricao, preco = @preco where id = @id";
                await con.ExecuteAsync(sql, produto);
                return await con.QueryAsync<ProdutosModel>("select * from produto");
            }
        }
    }
}
