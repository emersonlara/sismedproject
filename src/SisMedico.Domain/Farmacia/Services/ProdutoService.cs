using SisMedico.Domain.Farmacia.Entities;
using SisMedico.Domain.Farmacia.Entities.Validations;
using SisMedico.Domain.Farmacia.Interfaces;
using SisMedico.Domain.Notifications;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;

namespace SisMedico.Domain.Farmacia.Services;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository,
                          INotificador notificador) : base(notificador)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto produto)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        await _produtoRepository.Inserir(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        await _produtoRepository.Atualizar(produto);
    }

    public async Task Remover(Guid id)
    {
        await _produtoRepository.ExcluirPorId(id);
    }

    public void Dispose()
    {
        _produtoRepository?.Dispose();
    }
}
