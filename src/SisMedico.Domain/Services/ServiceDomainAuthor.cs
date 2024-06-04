using SisMedico.Domain.Entities;
using SisMedico.Domain.Events.Author;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Messaging;
using SisMedico.Domain.Notifications;
using SisMedico.Domain.Services.Abstractions;

namespace SisMedico.Domain.Services;

public class ServiceDomainAuthor : BaseService, IAuthorService
{
    private readonly IRepositoryAuthor _repoAuthor;
    private readonly INotificador _notificador;
    private readonly IMediatrHandler _bus;


    public ServiceDomainAuthor(IRepositoryAuthor repoAuthor,
                               INotificador notificador,
                               IMediatrHandler bus) : base(notificador)
    {
        _repoAuthor = repoAuthor;
        _notificador = notificador;
        _bus = bus;

    }


    // Aqui ainda precisamos inserir Regras de Negócios e Validaçpões;
    public async Task AdicionarAuthor(Author author)
    {
        await _repoAuthor.Inserir(author);
        await _bus.PublicarEvento(new AuthorCadastradoEvent(author.Id, author));
        await Task.CompletedTask;
    }

    public async Task AtualizarAutor(Author author)
    {
        await _repoAuthor.AtualizarAutor(author);
    }

    public async Task ExcluirAuthor(Author author)
    {
        await _repoAuthor.ExcluirAuthor(author);
    }

    public void Dispose()
    {
        _repoAuthor?.Dispose();
    }

}
