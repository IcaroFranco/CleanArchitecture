using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Application.Abstraction.Data;

public interface IApplicationDbContext
{
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
