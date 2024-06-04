using SisMedico.Domain.Base;
using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Interfaces.Repository;

public interface IRepositoryPaciente : IRepository<Paciente, Guid>
{
    Task<IEnumerable<Paciente>> ListaPacientesComEstado();
    List<EstadoPaciente> ListaEstadoPaciente();
    Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId);
    Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId);
    bool TemPaciente(Guid pacienteId);
    Task<EstadoPaciente> ObterEstadoPacientePorId(Guid id);
    Task InserirPacienteComEstadoPaciente(Paciente paciente);

    IEnumerable<Paciente> FindByName(string name);


}
