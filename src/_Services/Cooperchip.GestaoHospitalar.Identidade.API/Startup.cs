﻿using Cooperchip.GestaoHospitalar.Identidade.API.Extensions;

namespace Cooperchip.GestaoHospitalar.Identidade.API;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IHostEnvironment hostEnvironment)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true).AddEnvironmentVariables();

        if (hostEnvironment.IsDevelopment() || hostEnvironment.IsStaging() || hostEnvironment.IsProduction())
        {
            builder.AddUserSecrets<Startup>();
        }

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityEJwtConfig(Configuration);
        services.AddApiConfig();
        services.AddAddSwaggerConfig();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwaggerConfig();
        app.UseApiConfig(env);
    }
}
