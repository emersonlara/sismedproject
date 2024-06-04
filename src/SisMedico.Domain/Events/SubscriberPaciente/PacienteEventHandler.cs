using System.Diagnostics;
using SisMedico.Domain.Entities;
using SisMedico.Domain.Events.Pacientes;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Messaging;
using MediatR;
using SisMedico.Domain.Services.Abstractions;

namespace SisMedico.Domain.Events.SubscriberPaciente;

public class PacienteEventHandler :
    INotificationHandler<PacienteSemAvaliacaoEvent>,
    INotificationHandler<PacienteCadastradoEvent>
{
    private readonly ITriagemService _service;
    private readonly IRepositoryTriagem _repoNotify;
    private readonly IMediatrHandler _bus;

    public PacienteEventHandler(ITriagemService service,
                                IRepositoryTriagem repoNotify,
                                IMediatrHandler bus)
    {
        _service = service;
        _repoNotify = repoNotify;
        _bus = bus;
    }

    public async Task Handle(PacienteCadastradoEvent notification, CancellationToken cancellationToken)
    {
        var mensagem = $"{notification.Paciente.Motivo}";

        if (notification.Paciente.EstadoPaciente.Descricao.Equals("Grave"))
        {
            Debug.WriteLine($"ANTES DA TRIAGEM, O Sr(a). {notification.Paciente.Nome} DEVE VERIFICAR SE TEM PRIORIDADE!");
        }
        else if(notification.Paciente.EstadoPaciente.Descricao.Equals("S/Avaliação"))
        {
            await _bus.PublicarEvento(new PacienteSemAvaliacaoEvent(notification.AggregateId,
                                                                    notification.Paciente,
                                                                    notification.Paciente.Motivo));
        }
        else
        {
            await _service.AdicionarTriagem(new Triagem(notification.AggregateId, notification.Paciente.Nome, notification.Timestamp, mensagem));
        }
        await Task.CompletedTask;

    }


    /// <summary>
    /// Todo: Ao invés de adicionar o Paciente à Triagem e, posteriormente, o excluir por ele ter saído à Revelia (um dos motivos), usar o "UnitOfWork Pattern". Pensar no caso...
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(PacienteSemAvaliacaoEvent notification, CancellationToken cancellationToken)
    {
        await _repoNotify.ExcluirTriagemPorIdPaciente(notification.AggregateId);

        Debug.WriteLine($"O Sr(a). {notification.Paciente.Nome} SAIU, À REVELIA.");
        Debug.WriteLine("PORTANTO DEVERÁ SER RETIRADO DA TRIAGEM.");

        await Task.CompletedTask;
    }

}
