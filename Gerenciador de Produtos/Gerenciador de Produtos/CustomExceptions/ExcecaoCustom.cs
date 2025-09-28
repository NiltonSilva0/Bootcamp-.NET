namespace Gerenciador_de_Produtos.CustomExceptions;

public class ExcecaoCustom : Exception
{
    public ExcecaoCustom(string message) : base(message)
    {
    }
    public ExcecaoCustom(string message, Exception inner) : base(message, inner)
    {
    }
}