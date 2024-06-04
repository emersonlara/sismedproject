namespace SisMedico.Domain.Messaging;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}
