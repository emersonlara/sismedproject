using SisMedico.InfraData.Repository.Base;
using SisMedico.Domain.Farmacia.Entities;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SisMedico.InfraData.Repository.Farmacia;

public class ProdutoRepository : RepositoryGeneric<Produto, Guid>, IProdutoRepository
{
    public ProdutoRepository(ITDeveloperDbContext context) : base(context) { }

    public async Task<Produto> ObterProdutoFornecedor(Guid id)
    {
        return await this._context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
    {
        return await _context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
            .OrderBy(p => p.Nome).ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
    {
        return await Buscar(p => p.FornecedorId == fornecedorId);
    }
}
