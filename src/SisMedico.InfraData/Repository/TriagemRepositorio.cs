using SisMedico.InfraData.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository;

public class TriagemRepositorio : RepositoryGeneric<Triagem, Guid>, IRepositoryTriagem
{
    public TriagemRepositorio(ITDeveloperDbContext ctx) : base(ctx){}

    public async Task<Triagem> ObterTriagemPorId(Guid id)
    {
        return await _context.Set<Triagem>().FindAsync(id);
    }

    public async Task<IEnumerable<Triagem>> ListaTriagemPorData()
    {
        return await _context.Set<Triagem>().AsNoTracking().OrderBy(x => x.DataNotificacao).ToListAsync();
    }

    public async Task<Triagem> ObterTriagemPorIdPaciente(Guid pacienteId)
    {
        return await _context.Set<Triagem>().AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPaciente == pacienteId);
    }

    public async Task ExcluirTriagemPorIdPaciente(Guid pacienteId)
    {
        var notfy = await ObterTriagemPorIdPaciente(pacienteId);

        _context.Entry(notfy).State = EntityState.Deleted;
        //await Excluir(await ObterTriagemPorIdPaciente(pacienteId));
        await _context.SaveChangesAsync();
        _context.Entry(notfy).State = EntityState.Detached;

    }

}
