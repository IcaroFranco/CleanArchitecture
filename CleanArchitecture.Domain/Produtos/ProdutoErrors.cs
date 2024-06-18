using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Produtos;

public static class ProdutoErrors
{
    public static readonly Error NotFound = new (
        "Produto.NotFound",
        "Produto(s) não encontrado(s)");

    public static readonly Error BadRequest = new(
        "Produto.BadRequest",
        "Produto informado não está de acordo com as especifícações.");
}
