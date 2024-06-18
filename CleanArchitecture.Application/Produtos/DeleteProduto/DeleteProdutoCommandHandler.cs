using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Produtos;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Produtos.DeleteProduto;

internal sealed class DeleteProdutoCommandHandler
    : ICommandHandler<DeleteProdutoCommand, int>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProdutoCommandHandler(
        IUsuarioRepository usuarioRepository,
        IProdutoRepository produtoRepository,
        IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        DeleteProdutoCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            UsuarioId usuarioId = new(request.UsuarioId);

            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId, cancellationToken);

            if (usuario is null || usuario.Admin is false)
            {
                return Result.Failure<int>(UsuarioErrors.Unauthorized);
            }

            var produto = await _produtoRepository.GetByIdAsync(
                ProdutoId.From(request.Id),
                cancellationToken);

            if (produto is null)
            {
                return Result.Failure<int>(ProdutoErrors.NotFound);
            }

            produto.Excluir(DateTime.UtcNow);

            _produtoRepository.Update(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(0);
        }
        catch
        {
            return Result.Failure<int>(ServerErrors.Error500);
        }
    }
}
