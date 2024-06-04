using MediatR;

namespace SisMedico.Domain.Messaging;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}
