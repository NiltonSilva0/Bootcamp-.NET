using Gerenciador_de_Produtos.CustomExceptions;
using Gerenciador_de_Produtos.Dtos;
using Gerenciador_de_Produtos.Interfaces;
using Gerenciador_de_Produtos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_de_Produtos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GerenciadorController(IProdutoInterface produtoInterface) : ControllerBase
{
    private const string ExceptionMessage = "Ocorreu um erro interno no servidor.";
    
    [HttpGet("obter-todos-produtos")]
    public async Task<IActionResult> ObterTodosProdutos()
    {
        try
        {
            var produtos = await produtoInterface.ObterTodosProdutos();
            var responseDto = produtos.Select(p => new ResponseProdutoDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Categoria = p.Categoria.Nome.ToString(),
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QtdEmEstoque = p.QtdEmEstoque,
                Status = p.Status.ToString()
            });
            return Ok(responseDto);
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }

    [HttpGet("obter-produto-por-id/{id}")]
    public async Task<IActionResult> ObterProdutoPorId(string id)
    {
        try
        {
            var p = await produtoInterface.ObterProdutoPorId(id);
            var responseDto = new ResponseProdutoDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Categoria = p.Categoria.Nome.ToString(),
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QtdEmEstoque = p.QtdEmEstoque,
                Status = p.Status.ToString()
            };
            return Ok(responseDto);
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }

    [HttpGet("obter-produtos-por-categoria/{categoryId}")]
    public async Task<IActionResult> ObterProdutosPorCategoria(string categoryId)
    {
        try
        {
            var produtos = await produtoInterface.ObterProdutosPorCategoria(categoryId);
            var responseDto = produtos.Select(p => new ResponseProdutoDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Categoria = p.Categoria.Nome.ToString(),
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QtdEmEstoque = p.QtdEmEstoque,
                Status = p.Status.ToString()
            });
            return Ok(responseDto);
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }
    [HttpPost("criar-produto")]
    public async Task<IActionResult> CriarProduto([FromBody] List<CriarOuAtualizarProdutoDto> produtosDto)
    {
        try
        {
            var produtosCriados = await produtoInterface.CriarProduto(produtosDto);

            // 2. Mapeia do Modelo de Domínio para o DTO de Resposta
            var responseDto = produtosCriados.Select(p => new ResponseProdutoDto() 
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Categoria = p.Categoria.Nome.ToString(),
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QtdEmEstoque = p.QtdEmEstoque,
                Status = p.Status.ToString()
            }).ToList();

            // 3. Retorna 201 Created com a localização e os objetos criados
            return CreatedAtAction(nameof(ObterTodosProdutos), responseDto);
        }
        catch (ExcecaoCustom ex)
        {
            // 4. Retorna 400 Bad Request para erros de validação ou regras de negócio na criação
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }

    [HttpPut("atualizar-produto")]
    public async Task<IActionResult> AtualizarProduto([FromBody] ProdutoModel produto)
    {
        try
        {
            var produtoAtualizado = await produtoInterface.AtualizarProduto(produto);
            var responseDto = new ResponseProdutoDto
            {
                Id = produtoAtualizado.Id,
                CategoryId = produtoAtualizado.CategoryId,
                Categoria = produtoAtualizado.Categoria.Nome.ToString(),
                Nome = produtoAtualizado.Nome,
                Descricao = produtoAtualizado.Descricao,
                Preco = produtoAtualizado.Preco,
                QtdEmEstoque = produtoAtualizado.QtdEmEstoque,
                Status = produtoAtualizado.Status.ToString()
            };
            return Ok(responseDto);
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }

    [HttpDelete("deletar-produto/{id}")]
    public async Task<IActionResult> DeletarProduto(string id)
    {
        try
        {
            var sucesso = await produtoInterface.DeletarProduto(id);
            if (sucesso)
            {
                return NoContent();
            }
            return NotFound(new { message = "Produto não encontrado." });
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }

    [HttpGet("obter-produtos-indisponiveis")]
    public async Task<IActionResult> ObterProdutosIndisponiveis()
    {
        try
        {
            var produtos = await produtoInterface.ObterProdutosIndisponiveis();
            var responseDto = produtos.Select(p => new ResponseProdutoDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Categoria = p.Categoria.Nome.ToString(),
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                QtdEmEstoque = p.QtdEmEstoque,
                Status = p.Status.ToString()
            });
            return Ok(responseDto);
        }
        catch (ExcecaoCustom ex )
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ExceptionMessage });
        }
    }
}
