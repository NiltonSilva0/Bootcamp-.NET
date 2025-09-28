using System.ComponentModel.DataAnnotations;

namespace Gerenciador_de_Produtos.Models;

public class CategoryModel
{
    [Key]
    [Required, StringLength(10)] 
    public string CategoryId { get; set; } = Guid.NewGuid().ToString().Substring(0, 10);
    [Required]
    public Enums.Categoria Nome { get; set; } 
    public ICollection<ProdutoModel> Produtos { get; set; }
}