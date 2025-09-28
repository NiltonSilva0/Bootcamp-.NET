using Gerenciador_de_Produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Produtos.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
    {
    }

    public DbSet<Models.ProdutoModel> Produtos { get; set; }
    public DbSet<CategoryModel> Categorias { get; set; }
}