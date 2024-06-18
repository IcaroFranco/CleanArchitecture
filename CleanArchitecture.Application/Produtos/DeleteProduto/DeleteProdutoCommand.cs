using CleanArchitecture.Application.Abstraction.Handlers;

namespace CleanArchitecture.Application.Produtos.DeleteProduto;

public sealed record DeleteProdutoCommand(
    Guid UsuarioId,
    int Id)
    : ICommand<int>;

