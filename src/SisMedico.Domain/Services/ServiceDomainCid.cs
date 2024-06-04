using SisMedico.Domain.Entities;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Notifications;
using SisMedico.Domain.Services.Abstractions;

namespace SisMedico.Domain.Services;

public class ServiceDomainCid : BaseService, ICidService
{
    private readonly IRepositoryCid _repoCid;
    private readonly INotificador _notificador;

    public ServiceDomainCid(INotificador notificador,
                            IRepositoryCid repoCid) : base(notificador)
    {
        _repoCid = repoCid;
        _notificador = notificador;
    }

    /* Commands */

    public Task AdicionarCid(Cid cid)
    {
        throw new NotImplementedException();
    }

    public Task AdicionarVariasCids(Cid cid)
    {
        throw new NotImplementedException();
    }

    public Task EditarCid(Cid cid)
    {
        throw new NotImplementedException();
    }

    public Task RemoverCid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _repoCid?.Dispose();
    }
}
