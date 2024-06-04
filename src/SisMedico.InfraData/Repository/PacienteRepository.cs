using SisMedico.InfraData.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository;

public class PacienteRepository : RepositoryGeneric<Paciente, Guid>, IRepositoryPaciente
{

    public PacienteRepository(ITDeveloperDbContext ctx) : base(ctx){}

    public async Task<IEnumerable<Paciente>> ListaPacientesComEstado()
    {
        return await _context.Set<Paciente>().Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();
    }

    public List<EstadoPaciente> ListaEstadoPaciente()
    {
        return this._context.Set<EstadoPaciente>().AsNoTracking().ToListAsync().Result;
    }

    public async Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId)
    {
        return await _context.Set<Paciente>().Include(e => e.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == pacienteId);
    }

    public bool TemPaciente(Guid pacienteId)
    {
        return _context.Paciente.Any(x => x.Id == pacienteId);
    }

    public async Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId)
    {
        var lista = await _context.Set<Paciente>()
            .Include(ep => ep.EstadoPaciente)
            .AsNoTracking()
            .Where(x => x.EstadoPaciente.Id == estadoPacienteId)
            .OrderBy(order => order.Nome).ToListAsync();

        return lista;
    }

    public async Task<EstadoPaciente> ObterEstadoPacientePorId(Guid id)
    {
        return await _context.Set<EstadoPaciente>().FindAsync(id);
    }

    public async Task InserirPacienteComEstadoPaciente(Paciente paciente)
    {
        paciente.EstadoPaciente = await _context.EstadoPaciente.FindAsync(paciente.EstadoPacienteId);
        _context.Set<Paciente>().Add(paciente);
        await _context.SaveChangesAsync();
    }


    /// <summary>
    /// Gets a list of all lawyers whose last name exactly matches the search string.
    /// </summary>
    /// <param name="name">The last name that the system should search for.</param>
    /// <returns>An IEnumerable of Person with the matching people.</returns>
    /// 
    public IEnumerable<Paciente> FindByName(string name)
    {
        return _context.Set<Paciente>().Where(x => x.Nome == name);
    }
}
