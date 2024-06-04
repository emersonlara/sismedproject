using SisMedico.Domain.Entities;

namespace Cooperchip.ITDeveloper.Application.Interfaces
{
    public interface IServicoAplicacaoPaciente
    {
        /* Queries */
        Task<PacienteViewModel> ObterPacientePorIdApplication(Guid id);
        List<EstadoPaciente> ListaEstadoPacienteApplication();
        Task<PacienteViewModel> ObterPacienteComEstadoPaciente(Guid pacienteId);
        bool TemPaciente(Guid pacienteId);
        Task<IEnumerable<PacienteViewModel>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId);
        Task<IEnumerable<PacienteViewModel>> PacienteParaPacienteViewModel();

        Task<IEnumerable<PacienteTeste>> ObterPacientesTeste();

        /* Commands */
        Task RemoverPacienteApplication(Guid id);
        Task AdicionarPacienteApplication(PacienteViewModel pacienteViewModel);
        Task EditarPacienteApplication(PacienteViewModel pacienteViewModel);

    }
}
