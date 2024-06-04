using SisMedico.Domain.Entities;

namespace Cooperchip.ITDeveloper.Application.Interfaces;

public interface IAppTriagem
{

    /* NotifyProntuario */
    Task<Triagem> ObterPorId(Guid id);
    Task<Triagem> ObterPorIdDoPaciente(Guid pacienteId);
    Task IncluirTriagem(Triagem triagem);
    Task ExcluirTriagemPorId(Guid id);
    Task<Triagem> ObterTriagemPorId(Guid id);

    Task<IEnumerable<Triagem>> ListaTriagemPorData();


}
