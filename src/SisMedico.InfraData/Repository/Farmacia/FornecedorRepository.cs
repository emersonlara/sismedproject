using SisMedico.InfraData.Repository.Base;
using SisMedico.Domain.Farmacia.Entities;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository.Farmacia;

public class FornecedorRepository : RepositoryGeneric<Fornecedor, Guid>, IFornecedorRepository
{
    public FornecedorRepository(ITDeveloperDbContext context) : base(context)
    {
    }

    public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
    {
        return await _context.Fornecedores.AsNoTracking()
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
    {
        return await _context.Fornecedores.AsNoTracking()
            .Include(c => c.Produtos)
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
