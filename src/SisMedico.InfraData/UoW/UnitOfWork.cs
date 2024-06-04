using SisMedico.Domain.Interfaces;

namespace SisMedico.InfraData.UoW;

public class UnitOfWork : IUnitOfWork
{
    // Lifetime of context is Scopped (this is important)
    private readonly ITDeveloperDbContext _context;
    public UnitOfWork(ITDeveloperDbContext context) { _context = context; }

    public async Task<bool> Commit()
    {
        var success = (await _context.SaveChangesAsync()) > 0;
        // Possibility to dispatch domain envent, audity, log, etc.
        return success;
    }

    public Task RollBack() 
    { 
        // Rollback anything, if necessary
        return Task.CompletedTask; 
    }      

    public void Dispose() => _context?.Dispose();
}
