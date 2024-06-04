using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Base;
using SisMedico.Domain.Interfaces.NewRepository;

namespace SisMedico.InfraData.NewRepositories;

public abstract class NewRepositoryGeneric<T, K> : INewGenericRepository<T, K> where T : EntityBase, new()
{

    protected ITDeveloperDbContext _context;

    public NewRepositoryGeneric(ITDeveloperDbContext ctx) // Guardem essa info
    {
        _context = ctx;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<T> GetByIdAsync(K id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T obj)
    {
        _context.Set<T>().Add(obj);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(T obj)
    {
        _context.Set<T>().Update(obj);
        await Task.CompletedTask;
    }

    public async Task RemoveAsync(T obj)
    {
        _context.Set<T>().Remove(obj);
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        _context?.DisposeAsync();
    }

}
