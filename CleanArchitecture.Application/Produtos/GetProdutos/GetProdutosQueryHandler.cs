using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Produtos;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Produtos.GetProdutos;

internal sealed class GetProdutosQueryHandler
    : IQueryHandler<GetProdutosQuery, IEnumerable<ProdutoResponse>>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public GetProdutosQueryHandler(
        IProdutoRepository produtoRepository,
        IUsuarioRepository usuarioRepository)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<IEnumerable<ProdutoResponse>>> Handle(
        GetProdutosQuery request,
        CancellationToken cancellationToken)
    {
        UsuarioId usuarioId = new(request.UsuarioId);

        var usuario = await _usuarioRepository.GetByIdAsync(usuarioId, cancellationToken);

        if(usuario is null || usuario.Admin is false)
        {
            return Result.Failure<IEnumerable<ProdutoResponse>>(UsuarioErrors.Unauthorized);
        }

        var produtos = await _produtoRepository.GetAllAsync(cancellationToken);

        return produtos is null
            ? Result.Failure<IEnumerable<ProdutoResponse>>(ProdutoErrors.NotFound)
            : Result.Success(produtos.Select(p => p.ToResponse()));
    }
}
