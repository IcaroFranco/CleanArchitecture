using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Produtos;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Produtos.PutProduto;

internal sealed class PutProdutoCommandHandler
    : ICommandHandler<PutProdutoCommand, ProdutoResponse>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PutProdutoCommandHandler(
        IProdutoRepository produtoRepository,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProdutoResponse>> Handle(
        PutProdutoCommand request,
        CancellationToken cancellationToken)
    {
        try
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

            if (produto is null)
            {
                return Result.Failure<ProdutoResponse>(ProdutoErrors.NotFound);
            }

            var updateProduto = request.Produto.ToEntity(DateTime.Now);
            produto.Atualizar(updateProduto, DateTime.Now);

            _produtoRepository.Update(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(produto.ToResponse());
        }
        catch
        {
            return Result.Failure<ProdutoResponse>(ServerErrors.Error500);
        }
    }
}
