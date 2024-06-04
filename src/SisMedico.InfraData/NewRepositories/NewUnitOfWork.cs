using SisMedico.Domain.Interfaces.NewRepository;

namespace SisMedico.InfraData.NewRepositories;

public class NewUnitOfWork : INewUnitOfWork
{
    // Lifetime of context is Scopped (this is important)
    private readonly ITDeveloperDbContext _context;
    public NewUnitOfWork(ITDeveloperDbContext context) { _context = context; }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
        // Possibility to dispatch domain envent, audity, log, etc.
    }

    public Task RollBack()
    {
        // Rollback anything, if necessary
        return Task.CompletedTask;
    }

    public void Dispose() => _context?.Dispose();
}
