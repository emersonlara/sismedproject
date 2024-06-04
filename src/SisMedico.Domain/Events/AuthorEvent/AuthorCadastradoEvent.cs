using SisMedico.Domain.Messaging;

namespace SisMedico.Domain.Events.Author;

public class AuthorCadastradoEvent : DomainEvent
{
    public SisMedico.Domain.Entities.Author Author { get; private set; }

    public AuthorCadastradoEvent(Guid aggregateId,
                                 SisMedico.Domain.Entities.Author author) : base(aggregateId)
    {                
    }
}
