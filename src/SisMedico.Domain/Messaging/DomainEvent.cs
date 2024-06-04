namespace SisMedico.Domain.Messaging;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
