using System.Security.Claims;
using SisMedico.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SisMedico.Domain.Extensions.Helpers;

public class AspNetUser : IUserInContext
{
    private readonly IHttpContextAccessor _accessor;
    private readonly ILogger<AspNetUser> _logger;
    private ClaimsPrincipal _user;

    public AspNetUser(IHttpContextAccessor accessor, ILogger<AspNetUser> logger)
    {
        _accessor = accessor;
        _user = _accessor.HttpContext.User;
        _logger = logger;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public Guid GetUserId()
    {
        _logger.LogInformation("Getting user Id");
        return IsAuthenticated() ? _user.GetUserId() : Guid.Empty;
    }


    public string GetUserEmail()
    {
        _logger.LogInformation("Getting user email");
        return IsAuthenticated() ? _user.GetUserEmail() : "";
    }

    public string GetUserApelido() { return IsAuthenticated() ? _user.GetUserApelido() : ""; }
    public string GetUserDataNascimento() { return IsAuthenticated() ? _user.GetUserDataNascimento() : ""; }
    public string GetUserImgProfilePath() { return IsAuthenticated() ? _user.GetUserImgProfilePath() : ""; }
    public string GetUserNomeCompleto() { return IsAuthenticated() ? _user.GetUserNomeCompleto() : ""; }
    public IEnumerable<Claim> GetClaimsIdentity() { return _user.Claims; }

    public bool IsInRole(string role) { return _user.IsInRole(role); }
    public bool IsAuthenticated() { return _user.Identity.IsAuthenticated; }

}
