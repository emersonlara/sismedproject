using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Services.Abstractions;

public interface IAuthorService : IDisposable
{
    Task AdicionarAuthor(Author author);
    Task AtualizarAutor(Author author);
    Task ExcluirAuthor(Author author);
}
