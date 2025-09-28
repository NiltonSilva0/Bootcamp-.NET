using Gerenciador_de_Produtos.CustomExceptions;
using Gerenciador_de_Produtos.Models;

namespace Gerenciador_de_Produtos.Validators;

public abstract class ValidaProduto
{
    public static void ValidarProduto(ProdutoModel produto)
    {
        if (string.IsNullOrEmpty(produto.Nome) || produto.Nome.Length < 3)
            throw new ExcecaoCustom("Nome do produto inválido. Deve conter ao menos 3 caracteres.");
        if (string.IsNullOrEmpty(produto.Descricao) || produto.Descricao.Length < 5)
            throw new ExcecaoCustom("Descrição do produto inválida. Deve conter ao menos 5 caracteres.");
        if (produto.Preco <= 0)
            throw new ExcecaoCustom("Preço do produto inválido. Deve ser maior que zero.");
        if (produto.QtdEmEstoque < 0)
            throw new ExcecaoCustom("Quantidade em estoque inválida. Não pode ser negativa.");
    }
}