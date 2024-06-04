using System.Linq.Expressions;


namespace SisMedico.Domain.Base;

public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
{
    Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
    Task<TEntity> SelecionarPorId(TKey id);
    Task Inserir(TEntity obj);
    Task Atualizar(TEntity obj);
    Task Excluir(TEntity obj);
    Task ExcluirPorId(TKey id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveAsync();
}
