using SisMedico.Domain.Farmacia.Entities;

namespace Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;

public interface IFornecedorService : IDisposable
{
    Task Adicionar(Fornecedor fornecedor);
    Task Atualizar(Fornecedor fornecedor);
    Task Remover(Guid id);
    Task AtualizarEndereco(Endereco endereco);
}
