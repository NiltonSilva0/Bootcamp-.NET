using System.ComponentModel.DataAnnotations;
using Gerenciador_de_Produtos.Models;

namespace Gerenciador_de_Produtos.Dtos;

public class CriarOuAtualizarProdutoDto
{
    [Required]
    public Enums.Categoria NomeCategoria { get; set; }
    [Required, StringLength(50)]
    public string Nome { get; set; }
    [StringLength(200)]
    public string Descricao { get; set; }
    [Required]
    public Enums.StatusProduto Status { get; set; }
    public decimal Preco { get; set; }
    public int QtdEmEstoque { get; set; }
}