using Gerenciador_de_Produtos.CustomExceptions;
using Gerenciador_de_Produtos.Data;
using Gerenciador_de_Produtos.Dtos;
using Gerenciador_de_Produtos.Interfaces;
using Gerenciador_de_Produtos.Models;
using Gerenciador_de_Produtos.Validators;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Produtos.Services;

public class ProdutoService(ProdutoContext _context) : IProdutoInterface
{
    public async Task<List<ProdutoModel>> ObterTodosProdutos()
    {
        var listaDeProdutos = await _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Status != Enums.StatusProduto.Indisponivel)
            .ToListAsync();
        if(listaDeProdutos.Count == 0)
            throw new ExcecaoCustom("Nenhum produto encontrado");
        return listaDeProdutos;
    }

    public async Task<ProdutoModel> ObterProdutoPorId(string id)
    {
        var produto = await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id && p.Status != Enums.StatusProduto.Indisponivel);
        if(produto == null)
            throw new ExcecaoCustom("Produto não encontrado");
        return produto;
    }

    public async Task<List<ProdutoModel>> ObterProdutosPorCategoria(string categoryId)
    {
        var produtos = await _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.CategoryId == categoryId && p.Status != Enums.StatusProduto.Indisponivel)
            .ToListAsync();
        if(produtos.Count == 0)
            throw new ExcecaoCustom("Nenhum produto encontrado para essa categoria");
        return produtos;
    }

    public async Task<List<ProdutoModel>> CriarProduto(List<ProdutoModel> produtos)
    {
        foreach(var produto in produtos)
        {
            produto.Id = Guid.NewGuid().ToString();
            produto.Status = Enums.StatusProduto.EmEstoque;
            ValidaProduto.ValidarProduto(produto);
            _context.Produtos.Add(produto);
        }
        await _context.SaveChangesAsync();
        return produtos;
    }

    public async Task<List<ProdutoModel>> CriarProduto(List<CriarOuAtualizarProdutoDto> produtosDto)
    {
        var produtosParaAdicionar = new List<ProdutoModel>();

        foreach (var dto in produtosDto)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Nome == dto.NomeCategoria);

            if (categoria == null)
            {
                throw new ExcecaoCustom($"A categoria '{dto.NomeCategoria}' não foi encontrada.");
            }

            var produto = new ProdutoModel
            {
                Id = Guid.NewGuid().ToString(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                QtdEmEstoque = dto.QtdEmEstoque,
                Status = dto.QtdEmEstoque > 0 ? Enums.StatusProduto.EmEstoque : Enums.StatusProduto.Indisponivel,
                CategoryId = categoria.CategoryId,
                Categoria = categoria 
            };
            
            ValidaProduto.ValidarProduto(produto);
            produtosParaAdicionar.Add(produto);
        }

        _context.Produtos.AddRange(produtosParaAdicionar);
        await _context.SaveChangesAsync();
        
        return produtosParaAdicionar;
    }

    public async Task<ProdutoModel> AtualizarProduto(ProdutoModel produto)
    {
        if (produto == null)
        {
            throw new ExcecaoCustom("O objeto produto não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(produto.Id))
        {
            throw new ExcecaoCustom("O ID do produto não pode ser nulo ou vazio.");
        }

        var produtoExistente = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == produto.Id && p.Status != Enums.StatusProduto.Indisponivel);
        if (produtoExistente == null)
        {
            throw new ExcecaoCustom("Produto não encontrado");
        }

        ValidaProduto.ValidarProduto(produto);
        produtoExistente.Nome = produto.Nome;
        produtoExistente.Descricao = produto.Descricao;
        produtoExistente.Preco = produto.Preco;
        produtoExistente.QtdEmEstoque = produto.QtdEmEstoque;
        produtoExistente.CategoryId = produto.CategoryId;
        produtoExistente.Status = produto.Status;

        await _context.SaveChangesAsync();
        return produtoExistente;
    }

    public async Task<bool> DeletarProduto(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ExcecaoCustom("O ID do produto não pode ser nulo ou vazio.");
        }

        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null)
        {
            throw new ExcecaoCustom("Produto não encontrado");
        }

        produto.Status = Enums.StatusProduto.Indisponivel;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ProdutoModel>> ObterProdutosIndisponiveis()
    {
        var produtos =await _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Status == Enums.StatusProduto.Indisponivel)
            .ToListAsync();
        if(produtos.Count == 0)
            throw new ExcecaoCustom("Nenhum produto indisponível encontrado");
        return produtos;
    }
}