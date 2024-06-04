using Cooperchip.ITDeveloper.Application.Interfaces;
using Cooperchip.ITDeveloper.Application.Services;
using Cooperchip.ITDeveloper.Farmacia.Domain.Farmacia.Interfaces;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using Microsoft.AspNetCore.Identity.UI.Services;
using SisMedico.Domain.Farmacia.Interfaces;
using SisMedico.Domain.Farmacia.Services;
using SisMedico.Domain.Interfaces.NewRepository;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.Domain.Notifications;
using SisMedico.Domain.Services;
using SisMedico.Domain.Services.Abstractions;
using SisMedico.InfraData.NewRepositories;
using SisMedico.InfraData.Repository;
using SisMedico.InfraData.Repository.Farmacia;
using SisMedico.InfraData.UoW;
using SisMedico.Mvc.Extensions.Filters;
using SisMedico.Mvc.Extensions.IdentityServices;
using SisMedico.Mvc.Intra;

namespace SisMedico.Mvc.Configuration;

public static class DependencyInjectConfig
{
    public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services, IConfiguration configuration)
    {

        // Application
        services.AddScoped<IServicoAplicacaoPaciente, ServicoAplicacaoPaciente>();
        services.AddScoped<IServicoAplicacaoAuthor, ServicoAplicacaoAutor>();
        services.AddScoped<IAppTriagem, ServiceAppTriagem>();

        services.AddScoped<IServicoAplicacaoFornecedor, ServicoAplicacaoFornecedor>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();

        services.AddScoped<IProdutoService, ProdutoService>();


        // Domain => Service
        services.AddScoped<IAuthorService, ServiceDomainAuthor>();
        services.AddScoped<IPacienteService, ServiceDomainPaciente>();
        services.AddScoped<ITriagemService, ServiceDomainTriagem>();
        services.AddScoped<ICidService, ServiceDomainCid>();


        // Domain => Repository
        services.AddScoped<IRepositoryPaciente, PacienteRepository>();
        services.AddScoped<IRepositoryAuthor, AuthorRepository>();
        services.AddScoped<IRepositoryTriagem, TriagemRepositorio>();
        services.AddScoped<IRepositoryCid, RepositoryCid>();

        services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();

        services.AddScoped<IEnderecoRepository, EnderecoRepository>();

        services.AddScoped<IPacienteTesteRepository, PacienteTesteRepository>();

        // Medico, Especialidade and NewUnitOfWork
        services.AddScoped<INewMedicoRepository, NewMedicoRepository>();
        services.AddScoped<INewEspecialidadeRepository, NewEspecialidadeRepository>();
        services.AddScoped<INewUnitOfWork, NewUnitOfWork>();


        // Notificações
        services.AddScoped<INotificador, Notificador>();


        // The Unit of Work register need to be Scopped LC;
        services.AddScoped<Domain.Interfaces.IUnitOfWork, UnitOfWork>();

        services.AddTransient<IUnitOfUpload, UnitOfUpload>();


        services.AddScoped((context) => Logger.Factory.Get());
        services.AddScoped<AuditoriaIloggerFilter>();

        services.AddTransient<IEmailSender, EmailSender>();
        services.Configure<AuthMessageSenderOptions>(configuration);

        services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

        services.AddLogging(logging =>
        {
            logging.AddKissLog(options =>
            {
                options.Formatter = (FormatterArgs args) =>
                {
                    if (args.Exception == null)
                        return args.DefaultValue;

                    string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                    return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                };
            });
        });

        return services;
    }
}
