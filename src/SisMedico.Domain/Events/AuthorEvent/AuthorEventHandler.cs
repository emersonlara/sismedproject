using SisMedico.Domain.Interfaces.Repository;
using MediatR;
using System.Diagnostics;

namespace SisMedico.Domain.Events.Author;

public class AuthorEventHandler : INotificationHandler<AuthorCadastradoEvent>
{
    private readonly IRepositoryAuthor _repoAuthor;

    public AuthorEventHandler(IRepositoryAuthor repoAuthor)
    {
        _repoAuthor = repoAuthor;
    }

    public async Task Handle(AuthorCadastradoEvent notification, CancellationToken cancellationToken)
    {
        var author = await _repoAuthor.SelecionarPorId(notification.AggregateId);
        var lembrete = $"Author {author.Name} Cadastrado.";
        Debug.WriteLine(lembrete);
        EscreverNomePropriedade(author);
        await Task.CompletedTask;
    }

    public static void EscreverNomePropriedade<T>(T objeto)
    {
        var props = objeto.GetType().GetProperties();
        Debug.WriteLine($"Quantidade de Property: {props.Length}");

        foreach (var prop in props)
        {
            // RedesSociais
            if (prop.Name.EndsWith("RedesSociais"))
            {
                //var obj = prop;
                //foreach (var rs in obj.GetType().GetProperties()) 
                //{
                //    Debug.WriteLine($"{rs.Name} = {rs.GetValue(objeto, null)}");
                //}
            } else
            {
                Debug.WriteLine($"{prop.Name} = {prop.GetValue(objeto, null)}");
            }
        }
    }
}
