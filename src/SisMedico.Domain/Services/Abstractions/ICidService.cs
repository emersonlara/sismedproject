using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Services.Abstractions;

public interface ICidService : IDisposable
{
    /* Commands */
    Task RemoverCid(Guid id);
    Task AdicionarCid(Cid cid);
    Task AdicionarVariasCids(Cid cid);
    Task EditarCid(Cid cid);
}
