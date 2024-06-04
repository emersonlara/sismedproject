using AutoMapper;
using Cooperchip.ITDeveloper.Application.Interfaces;
using SisMedico.Domain.Farmacia.Entities;
using SisMedico.Domain.Farmacia.Interfaces;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using SisMedico.Mvc.ViewModels.Farmacia;

namespace Cooperchip.ITDeveloper.Application.Services;

public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;
    public ServicoAplicacaoProduto(IProdutoRepository produtoRepository,
                                   IFornecedorRepository fornecedorRepository,
                                   IProdutoService produtoService,
                                   IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoService = produtoService;
        _mapper = mapper;
    }

    //========/ Leitura =====================================//
    public async Task<IEnumerable<ProdutoViewModel>> ObterProdutosFornecedoresAplicacao()
    {
        return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
    }

    public async Task<ProdutoViewModel> ObterProdutoApplication(Guid id)
    {
        var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
        produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.SelecionarTodos());
        return produto;

    }

    public async Task<ProdutoViewModel> PopularFornecedoresApplication(ProdutoViewModel produtoViewModel)
    {
        produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.SelecionarTodos());
        return produtoViewModel;
    }

    //========/ Escrita =====================================//
    public async Task AdicionarApplication(ProdutoViewModel produtoViewModel)
    {
        await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
    }
    public async Task AtualizarApplication(ProdutoViewModel produtoAtualizacao)
    {
        await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));
    }
    public async Task RemoverApplication(Guid id) => await _produtoService.Remover(id);
}
