using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Produtos;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Produtos.GetProdutoById;

internal sealed class GetProdutoByIdQueryHandler
    : IQueryHandler<GetProdutoByIdQuery, ProdutoResponse>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public GetProdutoByIdQueryHandler(
        IProdutoRepository produtoRepository,
        IUsuarioRepository usuarioRepository)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<ProdutoResponse>> Handle(
        GetProdutoByIdQuery request,
        CancellationToken cancellationToken)
    {
        UsuarioId usuarioId = new(request.UsuarioId);

        var usuario = await _usuarioRepository.GetByIdAsync(usuarioId, cancellationToken);

        if (usuario is null || usuario.Admin is false)
        {
            return Result.Failure<ProdutoResponse>(UsuarioErrors.Unauthorized);
        }

        var produto = await _produtoRepository.GetByIdAsync(
            ProdutoId.From(request.Id),
            cancellationToken);

        return produto is null
            ? Result.Failure<ProdutoResponse>(ProdutoErrors.NotFound)
            : Result.Success(produto.ToResponse());
    }
}
