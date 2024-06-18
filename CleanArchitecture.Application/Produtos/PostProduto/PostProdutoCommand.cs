using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Produtos.Shared;

namespace CleanArchitecture.Application.Produtos.PostProduto;

public sealed record PostProdutoCommand(
    Guid UsuarioId,
    ProdutoRequest Produto)
    : ICommand<int>;
