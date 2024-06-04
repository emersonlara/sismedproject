using SisMedico.Domain.Interfaces.NewRepository;

namespace SisMedico.InfraData.NewRepositories;

public class NewMedicoRepository : NewRepositoryGeneric<Medico, Guid>, INewMedicoRepository
{
    public NewMedicoRepository(ITDeveloperDbContext ctx) : base(ctx)
    {
    }

}
