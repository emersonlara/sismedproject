using System.Linq.Expressions;
using SisMedico.Domain.Base;

namespace SisMedico.Domain.Interfaces.NewRepository;


public interface INewGenericRepository<T, K> : IDisposable where T : EntityBase, new()
{

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> quando = null);
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate = null);
    Task<T> GetByIdAsync(K id);
    Task AddAsync(T obj);
    Task UpdateAsync(T obj);
    Task RemoveAsync(T obj);
}
