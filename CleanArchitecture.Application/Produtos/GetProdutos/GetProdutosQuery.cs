using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Produtos.Shared;

namespace CleanArchitecture.Application.Produtos.GetProdutos;

public sealed record GetProdutosQuery(
    Guid UsuarioId)
    : IQuery<IEnumerable<ProdutoResponse>>;
