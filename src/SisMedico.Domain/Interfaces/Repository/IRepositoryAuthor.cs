using SisMedico.Domain.Base;
using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Interfaces.Repository;

public interface IRepositoryAuthor : IRepository<Author, Guid>
{
    Task AdicionarAuthor(Author author);
    Task AtualizarAutor(Author author);
    Task ExcluirAuthor(Author author);
}
