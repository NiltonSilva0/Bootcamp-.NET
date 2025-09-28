using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador_de_Produtos.Models;

public class ProdutoModel
{
    [Required, StringLength(10)]
    public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 10);
    [Required] 
    public string CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public CategoryModel Categoria { get; set; }
    
    [Required, StringLength(50)]
    public string Nome { get; set; } = string.Empty;
    [StringLength(200)]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public Enums.StatusProduto Status { get; set; } 
    public decimal Preco { get; set; }
    public int QtdEmEstoque { get; set; }
}
