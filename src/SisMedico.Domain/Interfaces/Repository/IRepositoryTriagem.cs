using SisMedico.Domain.Base;
using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Interfaces.Repository;

//  public interface IRepositoryPaciente : IRepository<Paciente, Guid>
public interface IRepositoryTriagem : IRepository<Triagem, Guid>
{
    Task<Triagem> ObterTriagemPorId(Guid id);

    Task<IEnumerable<Triagem>> ListaTriagemPorData();

    Task<Triagem> ObterTriagemPorIdPaciente(Guid pacienteId);

    Task ExcluirTriagemPorIdPaciente(Guid pacienteId);


}
