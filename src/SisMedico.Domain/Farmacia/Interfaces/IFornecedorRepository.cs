using SisMedico.Domain.Base;
using SisMedico.Domain.Farmacia.Entities;

namespace Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;

public interface IFornecedorRepository : IRepository<Fornecedor, Guid>
{
    Task<Fornecedor> ObterFornecedorEndereco(Guid id);
    Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
}
