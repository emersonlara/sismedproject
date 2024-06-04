using SisMedico.Domain.Farmacia.Entities;

namespace SisMedico.Domain.Farmacia.Interfaces;

public interface IProdutoService : IDisposable
{
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Guid id);
}
