using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain.Produtos;

namespace CleanArchitecture.Application.Extensions;

internal static class ProdutoExtensions
{
    public static ProdutoResponse ToResponse(this Produto produto)
    {
        return new()
        {
            Id = produto.Id.Value,
            Nome = produto.Nome,
            Descrição = produto.Descrição,
            Cor = produto.Cor,
            Marca = produto.Marca,
            Garantia = produto.Garantia
        };
    }

    public static Produto ToEntity(
        this ProdutoRequest request,
        DateTime utcNow)
    {
        return Produto.Criar(
            request.Nome,
            request.Descrição,
            request.Cor,
            request.Marca,
            request.Garantia,
            utcNow);
    }
}
