using SisMedico.Domain.Entities;

namespace SisMedico.Domain.Services.Abstractions;

public interface ITriagemService : IDisposable
{
    Task AdicionarTriagem(Triagem triagem);
    Task ExcluirTriagem(Triagem triagem);
}
