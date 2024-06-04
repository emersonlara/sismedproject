using SisMedico.Domain.Base;
using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Interfaces.Repository;

public interface IRepositoryCid : IRepository<Cid, Guid>
{

    Task<PagedResult<Cid>> ObterTodosEFramework(int pageIndex, int pageSize, string query = null);


    /* Queries */
    Task<IEnumerable<Cid>> ObterTodas();
    bool TemCid(Guid id);
    Task<Cid> ObterPorId(Guid id);

}
