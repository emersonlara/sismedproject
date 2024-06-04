using SisMedico.Domain.Base;
using System.Linq.Expressions;

namespace SisMedico.InfraData.Repository.Base;

// Todo: Preparar este código para consultas diretas com ADO.NET
public abstract class RepositoryQueryDAO<TEntity, TKey> : IRepositoryQueryDAO<TEntity, TKey> where TEntity : EntityBase, new()
{

    public async Task<TEntity> SelecionarPorId(TKey id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<TEntity>> Buscar(string q)
    {
        throw new NotImplementedException();
    }

}
