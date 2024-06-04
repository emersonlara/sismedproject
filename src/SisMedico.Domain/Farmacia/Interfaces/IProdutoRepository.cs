using SisMedico.Domain.Base;
using SisMedico.Domain.Farmacia.Entities;

namespace Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;

public interface IProdutoRepository : IRepository<Produto, Guid>
{
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
    Task<IEnumerable<Produto>> ObterProdutosFornecedores();
    Task<Produto> ObterProdutoFornecedor(Guid id);
}
