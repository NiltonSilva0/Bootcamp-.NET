using Gerenciador_de_Produtos.Dtos;
using Gerenciador_de_Produtos.Models;

namespace Gerenciador_de_Produtos.Interfaces;

public interface IProdutoInterface
{
    public Task<List<ProdutoModel>> ObterTodosProdutos();
    public Task<ProdutoModel> ObterProdutoPorId(string id);
    public Task<List<ProdutoModel>> ObterProdutosPorCategoria(string categoryId);
    public Task<List<ProdutoModel>> CriarProduto(List<CriarOuAtualizarProdutoDto> produtosDto);
    public Task<ProdutoModel> AtualizarProduto(ProdutoModel produto);
    public Task<bool> DeletarProduto(string id);
    public Task<List<ProdutoModel>> ObterProdutosIndisponiveis();
}