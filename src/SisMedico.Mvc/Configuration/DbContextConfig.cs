using Microsoft.EntityFrameworkCore;
using SisMedico.InfraData.ORM;

namespace SisMedico.Mvc.Configuration;

public static class DbContextConfig
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ITDeveloperDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultITDeveloper")));


        services.AddDatabaseDeveloperPageExceptionFilter(); // Adiciona suporte para página de exceções para desenvolvedores

        return services;
    }
}
