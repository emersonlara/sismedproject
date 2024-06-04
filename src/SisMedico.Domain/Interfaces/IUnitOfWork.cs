namespace SisMedico.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
    Task RollBack();
}
