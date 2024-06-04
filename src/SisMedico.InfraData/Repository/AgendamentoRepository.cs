using SisMedico.InfraData.Repository.Base;

namespace SisMedico.InfraData.Repository;

public class AgendamentoRepository : RepositoryGeneric<AgendaEventos, Guid>, IAgendamentoRepository
{
    public AgendamentoRepository(ITDeveloperDbContext ctx) : base(ctx)
    {
    }
}
