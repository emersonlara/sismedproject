
using Cooperchip.ITDeveloper.Application.Interfaces;
using Cooperchip.ITDeveloper.Application.Services;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using SisMedico.Domain.Farmacia.Interfaces;
using SisMedico.Domain.Farmacia.Services;
using SisMedico.Domain.Notifications;
using SisMedico.InfraData.Repository.Farmacia;

namespace SisMedico.Mvc.Configuration;

public static class BoundedContextFarmacia
{
    public static IServiceCollection AddBoundedContextFarmacia(this IServiceCollection services, IConfiguration configuration)
    {

        // Farmacia
        services.AddScoped<IServicoAplicacaoFornecedor, ServicoAplicacaoFornecedor>();
        services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
        // +
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();

        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        // Farmacia

        return services;
    }
}
