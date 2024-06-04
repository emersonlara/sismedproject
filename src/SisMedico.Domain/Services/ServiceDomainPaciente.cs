using SisMedico.Domain.Entities;
using SisMedico.Domain.Entities.Validations;
using SisMedico.Domain.Events.Pacientes;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Messaging;
using SisMedico.Domain.Notifications;
using SisMedico.Domain.Services.Abstractions;

namespace SisMedico.Domain.Services
{
    public class ServiceDomainPaciente : BaseService, IPacienteService
    {

        private readonly IRepositoryPaciente _repoPaciente;
        private readonly IMediatrHandler _bus;

        public ServiceDomainPaciente(IRepositoryPaciente repoPaciente,
                                   INotificador notificador,
                                   IMediatrHandler bus) : base(notificador)
        {
            _repoPaciente = repoPaciente;
            _bus = bus;
        }

        /* Aqui um evento passando AggregateId e Paciente*/
        public async Task AdicionarPaciente(Paciente paciente)
        {

            if (!ExecutarValidacao(new PacienteValidation(), paciente))
            {
                return;
            }

            if (_repoPaciente.Buscar(c => c.Cpf == paciente.Cpf).Result.Any())
            {
                Notificar("Já existe um Paciente com este Cpf informado");
                return;
            }

            await _repoPaciente.InserirPacienteComEstadoPaciente(paciente);

            await _bus.PublicarEvento(new PacienteCadastradoEvent(paciente.Id, paciente));
            await Task.CompletedTask;
        }

        /* Aqui outro evento 3 parâmetros, um AggregateId, um Enum e uma string */
        public async Task AtualizarPaciente(Paciente paciente)
        {

            if (!ExecutarValidacao(new PacienteValidation(), paciente))
            {
                return;
            }

            if (_repoPaciente.Buscar(c => c.Cpf == paciente.Cpf && c.Id != paciente.Id).Result.Any())
            {
                Notificar("Já existe um Paciente com este Cpf informado");
                return;
            }

            await _repoPaciente.Atualizar(paciente);
        }

        public async Task ExcluirPaciente(Paciente paciente)
        {
            if(_repoPaciente.Buscar(ep=>ep.EstadoPacienteId == paciente.EstadoPaciente.Id).Result.Any())
            {
                Notificar("Este Paciente tem 'Estado de Paciente', portanto não pode ser excluído!");
                return;
            }
            await _repoPaciente.Excluir(paciente);
        }


        public void Dispose()
        {
            _repoPaciente?.Dispose();
        }
    }
}
