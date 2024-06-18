using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Produtos.Shared;

namespace CleanArchitecture.Application.Produtos.PutProduto;

public sealed record PutProdutoCommand(
    Guid UsuarioId,
    int Id,
    ProdutoRequest Produto)
    : ICommand<ProdutoResponse>;
