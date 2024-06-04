using SisMedico.InfraData.Repository.Base;
using SisMedico.Domain.Farmacia.Entities;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository.Farmacia;

public class EnderecoRepository : RepositoryGeneric<Endereco, Guid>, IEnderecoRepository
{
    public EnderecoRepository(ITDeveloperDbContext context) : base(context) { }

    public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
    {
        return await _context.Enderecos.AsNoTracking()
            .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
    }
}
