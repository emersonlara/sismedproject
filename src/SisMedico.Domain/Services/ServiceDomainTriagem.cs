using SisMedico.Domain.Entities;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Notifications;
using SisMedico.Domain.Services.Abstractions;

namespace SisMedico.Domain.Services;

public class ServiceDomainTriagem : BaseService, ITriagemService
{
    private readonly IRepositoryTriagem _repoNotify;
    private readonly INotificador _notificador;


    public ServiceDomainTriagem(IRepositoryTriagem repoNotify,
                                INotificador notificador):base(notificador)
    {
        _repoNotify = repoNotify;
        _notificador = notificador;
    }

    public async Task AdicionarTriagem(Triagem triagem)
    {
        await _repoNotify.Inserir(triagem);
    }

    public async Task ExcluirTriagem(Triagem triagem)
    {
        await _repoNotify.Excluir(triagem);
    }

    public async Task ExcluirTriagemPorIdPaciente(Guid pacienteId)
    {
        await _repoNotify.ExcluirTriagemPorIdPaciente(pacienteId);
    }

    public void Dispose()
    {
        _repoNotify?.Dispose();
    }

}
