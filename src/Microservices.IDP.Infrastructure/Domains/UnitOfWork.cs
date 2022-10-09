using Microservices.IDP.Infrastructure.Persistence;

namespace Microservices.IDP.Infrastructure.Domains;

public class UnitOfWork : IUnitOfWork
{
    private readonly MSIdentityContext _context;

    public UnitOfWork(MSIdentityContext context)
    {
        _context = context;
    }

    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}