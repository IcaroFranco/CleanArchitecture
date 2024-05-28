using CleanArchitecture.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class UsuarioRepository
    : Repository<Usuario, UsuarioId>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    { }

    public async Task<Usuario?> GetByIdAsync(
           UsuarioId usuarioId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Usuario>()
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == usuarioId, cancellationToken);
    }

    public async Task<IEnumerable<Usuario>> 
        GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Usuario>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
