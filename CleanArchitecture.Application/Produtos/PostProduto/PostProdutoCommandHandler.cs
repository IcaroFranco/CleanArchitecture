using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Produtos;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Produtos.PostProduto;

internal sealed class PostProdutoCommandHandler
    : ICommandHandler<PostProdutoCommand, int>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostProdutoCommandHandler(
        IProdutoRepository produtoRepository,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        PostProdutoCommand request,
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

            var produto = request.Produto.ToEntity(DateTime.UtcNow);

            _produtoRepository.Add(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(0);
        }
        catch
        {
            return Result.Failure<int>(ServerErrors.Error500);
        }
    }
}
