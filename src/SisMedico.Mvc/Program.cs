using System.Reflection;
using AspNetCoreHero.ToastNotification;
using MediatR;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using SisMedico.Domain.Events.Author;
using SisMedico.Domain.Events.Pacientes;
using SisMedico.Domain.Events.SubscriberPaciente;
using SisMedico.Domain.Messaging;
using SisMedico.Mvc.Configuration;
using SisMedico.Mvc.Extensions.Attibutes;
using SisMedico.Mvc.Extensions.IdentityServices;
using SisMedico.Mvc.Models;

namespace SisMedico.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurações de Configuration
        var configuration = builder.Configuration;
        configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        if (builder.Environment.IsDevelopment())
        {
            configuration.AddUserSecrets<Program>();
        }


        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddLoggerConfig();

        builder.Services.AddDbContextConfig(configuration); // In DbContextConfig
        builder.Services.AddIdentityConfig(configuration);  // In IdentityConfig
        builder.Services.AddMvcAndRazor(); // In MvcAndRazor
        builder.Services.AddDependencyInjectConfig(configuration); // In DependencyInjectConfig


        // Prover Suporte para Code Page (1252) (windows-1252)
        builder.Services.AddCodePageProviderNotSupportedInDotNetCoreForAnsi();

        builder.Services.Configure<SmartSettings>(configuration.GetSection(SmartSettings.SectionName));

        // Note: This line is for demonstration purposes only, I would not recommend using this as a shorthand approach for accessing settings
        // While having to type '.Value' everywhere is driving me nuts (>_<), using this method means reloaded appSettings.json from disk will not work
        builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);


        // Todo: Criando minha própria IOptions: StyleButtom
        builder.Services.Configure<StyleButtom>(configuration.GetSection(StyleButtom.SectionName));
        builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<StyleButtom>>().Value);


        // Todo: Criando minha própria IOptions: LeitosCapacidade
        builder.Services.Configure<LeitosESetores>(configuration.GetSection(LeitosESetores.SectionName));
        builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<LeitosESetores>>().Value);


        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


        // Domain Bus (Mediator)
        builder.Services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Subscrcrição para os Eventos  - (Observer / Subscriber / Mediator)
        builder.Services.AddScoped<INotificationHandler<PacienteCadastradoEvent>, PacienteEventHandler>();
        builder.Services.AddScoped<INotificationHandler<PacienteSemAvaliacaoEvent>, PacienteEventHandler>();

        builder.Services.AddScoped<INotificationHandler<AuthorCadastradoEvent>, AuthorEventHandler>();


        builder.Services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();


        builder.Services.AddNotyf(config =>
        { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });


        var app = builder.Build();

        /* Comentei o CriaUsersAndRoles então comento aqui por warn
         * ApplicationDbContext context,
         * UserManager<ApplicationUser> userManager,
         * RoleManager<IdentityRole> roleManager
         */

        // Configurações do pipeline HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.AddLoggerConfig(configuration);

        var authMsgSenderOpt = new AuthMessageSenderOptions
        {
            SendGridUser = configuration["SendGridUser"],
            SendGridKey = configuration["SendGridKey"]
        };

        //CriaUsersAndRoles.Seed(context, userManager, roleManager).Wait();
        //app.UseMiddleware<DefaultUsersAndRolesMiddeware>();            
        //app.UseAddUserAndRoles();

        app.UseGlobalizationConfig();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        app.MapControllerRoute(
            name: "intel",
            pattern: "{controller=Intel}/{action=AnalyticsDashboard}");

        app.MapRazorPages();

        app.Run();

    }
}
