using SisMedico.Domain.Entities;
using SisMedico.Domain.Messaging;

namespace SisMedico.Domain.Events.Pacientes;

public class PacienteCadastradoEvent : DomainEvent
{
    public Paciente Paciente { get; private set; }
    public PacienteCadastradoEvent(Guid aggregateId, Paciente paciente) :base(aggregateId)
    {
        Paciente = paciente;
    }
}
