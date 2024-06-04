using SisMedico.Mvc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using SisMedico.Domain.Extensions.Helpers;
using SisMedico.Domain.Interfaces;
using SisMedico.Mvc.Extensions.IdentityServices;
using SisMedico.Mvc.Extensions;

namespace SisMedico.Mvc.Configuration;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        // Todo: Controlar nosso fluxo de identidade entre outre outras coisas com Cookie
        services.ConfigureApplicationCookie(c =>
        {
            c.AccessDeniedPath = "/Identity/Account/AccessDenied";
            c.Cookie.Name = "SisMedicoV6";
            c.Cookie.HttpOnly = true;
            c.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            c.SlidingExpiration = true;
            c.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            c.LoginPath = "/Identity/Account/Login";
            c.LogoutPath = "/Identity/Account/Logout";

        });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultITDeveloper")));

        services.AddDefaultIdentity<ApplicationUser>(opt =>
            {

                // User Config
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                // Lockout Config
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 4;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);

                // SignIn Config
                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedAccount = false;
                opt.SignIn.RequireConfirmedEmail = true;  // Pay Attention

                // Password Config          // Todo: Quer que a senha padrão seja Admin@123
                opt.Password.RequireUppercase = true;                   // A
                opt.Password.RequireLowercase = true;                   // dmin
                opt.Password.RequireNonAlphanumeric = true;             // @
                opt.Password.RequireDigit = true;                       // 123
                opt.Password.RequiredLength = 8;                        // Ok
                opt.Password.RequiredUniqueChars = 2;                   // 111


            }).AddRoles<IdentityRole>()
            .AddErrorDescriber<IdentityMensagensPortugues>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // =/ Adicionar Claims para HttpContext =========================================== //
        // =/ Este serviço deve ser registrado sempre após o registro do Identity ==========//
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsService>();

        services.AddScoped<IUserInContext, AspNetUser>();



        return services;
    }
}
