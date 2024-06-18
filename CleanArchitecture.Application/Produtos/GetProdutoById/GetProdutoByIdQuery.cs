using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Produtos.Shared;

namespace CleanArchitecture.Application.Produtos.GetProdutoById;

public sealed record GetProdutoByIdQuery(
    Guid UsuarioId,
    int Id)
    : IQuery<ProdutoResponse>;
