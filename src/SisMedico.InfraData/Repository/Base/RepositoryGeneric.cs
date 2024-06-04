using System.Linq.Expressions;
using SisMedico.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase, new()
    {

        protected ITDeveloperDbContext _context;

        public RepositoryGeneric(ITDeveloperDbContext ctx) // Guardem essa info
        {
            this._context = ctx;
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            //_context.Entry(obj).State = EntityState.Modified;
            //await SaveAsync();

            _context.Set<TEntity>().Update(obj);
            await SaveAsync();
            _context.Entry(obj).State = EntityState.Detached;

        }


        public virtual async Task Excluir(TEntity obj)
        {
            //this._context.Entry(obj).State = EntityState.Deleted;
            //await SaveAsync();

            _context.Set<TEntity>().Remove(obj);
            await SaveAsync();
            _context.Entry(obj).State = EntityState.Detached;

        }

        public virtual async Task ExcluirPorId(TKey id)
        {
            TEntity obj = await SelecionarPorId(id);
            await Excluir(obj);

        }

        public virtual async Task Inserir(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await SaveAsync();
            _context.Entry(obj).State = EntityState.Detached;
        }

        public async Task<TEntity> SelecionarPorId(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null)
        {
            if(quando == null)
            {
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await _context.Set<TEntity>().AsNoTracking().Where(quando).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

    }
}
