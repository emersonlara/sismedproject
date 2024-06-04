using SisMedico.Domain.Base;
using SisMedico.Domain.Farmacia.Entities;

namespace Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco, Guid>
{
    Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
}
