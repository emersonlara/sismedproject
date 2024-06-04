using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Services.Abstractions;

public interface IPacienteService : IDisposable
{
    Task AdicionarPaciente(Paciente paciente);
    Task AtualizarPaciente(Paciente paciente);
    Task ExcluirPaciente(Paciente paciente);
}
