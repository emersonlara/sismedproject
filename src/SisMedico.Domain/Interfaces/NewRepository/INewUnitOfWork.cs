namespace SisMedico.Domain.Interfaces.NewRepository;

public interface INewUnitOfWork
{
    Task<bool> CommitAsync();
    Task RollBack();
}
