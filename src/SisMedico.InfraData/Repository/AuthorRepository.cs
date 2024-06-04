using SisMedico.InfraData.Repository.Base;

namespace SisMedico.InfraData.Repository;

public class AuthorRepository : RepositoryGeneric<Author, Guid>, IRepositoryAuthor
{

    public AuthorRepository(ITDeveloperDbContext ctx) : base(ctx){}

    public async Task AdicionarAuthor(Author author)
    {
        //_ctx.Set<Author>().Add(author);
        //await _ctx.SaveChangesAsync();
        await AdicionarAuthor(author);
    }

    public async Task AtualizarAutor(Author author)
    {
        await Atualizar(author);
    }

    public async Task ExcluirAuthor(Author author)
    {
        //_ctx.Entry(author).State = EntityState.Deleted;
        //await _ctx.SaveChangesAsync();
        await Excluir(author);
    }

}
