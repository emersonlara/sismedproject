using SisMedico.Mvc.ViewModels.Farmacia;

namespace Cooperchip.ITDeveloper.Application.Interfaces;

public interface IServicoAplicacaoFornecedor
{

    // ========/ Leitura =========================================//
    Task<IEnumerable<FornecedorViewModel>> ObterTodosApplication();
    Task<FornecedorViewModel> ObterFornecedorEnderecoApplication(Guid id);
    Task<FornecedorViewModel> ObterFornecedorProdutosEnderecoApplication(Guid id);

    // ========/ Escrita =========================================//
    Task AdicionarApplication(FornecedorViewModel fvm);
    Task AtualizarApplication(FornecedorViewModel fvm);
    Task RemoverApplication(Guid id);
    Task AtualizarEnderecoApplication(FornecedorViewModel fvm);
}
