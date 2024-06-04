using SisMedico.Mvc.Data;
using SisMedico.Mvc.Extensions.IdentityServices;
using SisMedico.Mvc.ServiceApp.Services;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace SisMedico.Mvc.Extensions.Middlewares;

public class DefaultUsersAndRolesMiddeware
{
    private readonly RequestDelegate _next;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DefaultUsersAndRolesMiddeware(RequestDelegate next, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _next = next;
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InvokeAsync(HttpContext _context)
    {
        Debug.WriteLine("RODANDO O PROCESSO DE VERIFICAÇÃO DE USUÁRIO E PAPEIS EXISTENTES. SE NÃO HOUVER CRIAR!");

        CriaUsersAndRoles.Seed(_dbContext, _userManager, _roleManager).Wait();
        await _next(_context);

        Debug.WriteLine("PROCESSO DE VERIFICAÇÃO DE USUÁRIO E PAPEIS TERMINADO!");

    }

}
