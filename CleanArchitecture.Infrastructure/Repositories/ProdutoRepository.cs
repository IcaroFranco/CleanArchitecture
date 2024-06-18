using CleanArchitecture.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class ProdutoRepository
    : Repository<Produto, ProdutoId>, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    { }

    public async Task<Produto?> GetByIdAsync(
        ProdutoId produtoId,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Produto>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == produtoId, cancellationToken);
    }

    public async Task<IEnumerable<Produto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Produto>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
