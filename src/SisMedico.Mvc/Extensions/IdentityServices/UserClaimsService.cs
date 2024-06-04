using SisMedico.Mvc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace SisMedico.Mvc.Extensions.IdentityServices;

public class UserClaimsService : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
{
    private readonly ApplicationDbContext _dbContext;
    public UserClaimsService(ApplicationDbContext dbContext,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
    {
        _dbContext = dbContext;
    }
    public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    {
        var principal = await base.CreateAsync(user);
        // Todo: Aqui podemos pegar as Claims do User no Banco de dados
        // ... // _dbContext ///
        // Add Claims
        ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Apelido", user.Apelido),
                new Claim("NomeCompleto", user.NomeCompleto),
                new Claim("Email", user.Email),
                new Claim("DataNascimento", user.DataNascimento.ToBrazilianDate()),
                new Claim("ImgProfilePath", !string.IsNullOrEmpty(user.ImgProfilePath) ? user.ImgProfilePath : "")
            });
        return principal;
    }
}
