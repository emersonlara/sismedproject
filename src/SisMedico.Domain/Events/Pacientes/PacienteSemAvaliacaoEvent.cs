using SisMedico.Domain.Entities;
using SisMedico.Domain.Messaging;

namespace SisMedico.Domain.Events.Pacientes;

public class PacienteSemAvaliacaoEvent : DomainEvent
{
    public string Motivo { get; private set; }
    public Paciente Paciente { get; private set; }
    public PacienteSemAvaliacaoEvent(Guid aggregateId, Paciente paciente, string motivo) :base(aggregateId)
    {
        Motivo = motivo;
        Paciente = paciente;
    }
}
