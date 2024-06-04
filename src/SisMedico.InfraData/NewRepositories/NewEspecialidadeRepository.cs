using SisMedico.Domain.Interfaces.NewRepository;

namespace SisMedico.InfraData.NewRepositories;

public class NewEspecialidadeRepository: NewRepositoryGeneric<Especialidade, Guid>, INewEspecialidadeRepository
{
    public NewEspecialidadeRepository(ITDeveloperDbContext ctx) : base(ctx)
    {
    }
}
