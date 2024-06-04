using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Interfaces.NewRepository;

public interface INewMedicoRepository : INewGenericRepository<Medico, Guid>
{
}
