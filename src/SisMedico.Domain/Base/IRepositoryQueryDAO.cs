using System.Linq.Expressions;


namespace SisMedico.Domain.Base;

public interface IRepositoryQueryDAO<TEntity, TKey> where TEntity : class
{
    Task<TEntity> SelecionarPorId(TKey id);
    Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
    Task<IEnumerable<TEntity>> Buscar(string q);
}
