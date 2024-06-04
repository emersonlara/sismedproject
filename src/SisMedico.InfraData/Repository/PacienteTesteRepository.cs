using SisMedico.InfraData.Repository.Base;

namespace SisMedico.InfraData.Repository;

public class PacienteTesteRepository : RepositoryGeneric<PacienteTeste, Guid>, IPacienteTesteRepository
{

    public PacienteTesteRepository(ITDeveloperDbContext ctx) : base(ctx){}
    
}
