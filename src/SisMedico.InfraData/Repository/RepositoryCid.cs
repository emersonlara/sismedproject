using SisMedico.InfraData.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository;

public class RepositoryCid : RepositoryGeneric<Cid, Guid>, IRepositoryCid
{
    public RepositoryCid(ITDeveloperDbContext ctx)
        : base(ctx)
    {}

    public Task<Cid> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cid>> ObterTodas()
    {
        return await _context.Cid.AsNoTracking().ToListAsync();
    }


    public async Task<PagedResult<Cid>> ObterTodosEFramework(int pageIndex, int pageSize, string query = null)
    {
        IEnumerable<Cid> data = new List<Cid>();
        var source = _context.Cid.AsQueryable();
        data = query != null
            ? await source.Where(x => x.Diagnostico.Contains(query) || x.Codigo.Contains(query)).ToListAsync()
            : await source.ToListAsync();

        var count = data.Count();
        data = data.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

        return new PagedResult<Cid>()
        {
            Data = data,
            TotalResults = count,
            PageIndex = pageIndex,
            PageSize = pageSize,
            Query = query,


            //TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            //HasNext = pageIndex > 1,
            //HasPrevious = pageIndex < count
        };
    }


    public bool TemCid(Guid id)
    {
        throw new NotImplementedException();
    }

}
