using Gerenciador_de_Produtos.Models;

namespace Gerenciador_de_Produtos.Dtos;

public class ResponseProdutoDto
{
    public string Id { get; set; } = string.Empty;
    public string Categoria { get; set; }
    public string CategoryId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; }
    public decimal Preco { get; set; }
    public int QtdEmEstoque { get; set; }       
}