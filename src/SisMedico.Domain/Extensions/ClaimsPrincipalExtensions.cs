using System.Security.Claims;

namespace SisMedico.Domain.Extensions;

public static class ClaimsPrincipalExtensions
{

    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        var userIdValue = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(userIdValue, out var userId))
        {
            return userId;
        }
        return Guid.Empty;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        return principal.FindFirst(x => x.Type == "Email")?.Value ?? "";
    }

    public static string GetUserApelido(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        return principal.FindFirst(x => x.Type == "Apelido")?.Value ?? "";
    }


    public static string GetUserDataNascimento(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        return principal.FindFirst(x => x.Type == "DataNascimento")?.Value;
    }

    public static string GetUserImgProfilePath(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        return principal.FindFirst(x => x.Type == "ImgProfilePath")?.Value ?? "";
    }


    public static string GetUserNomeCompleto(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        return principal.FindFirst(x => x.Type == "NomeCompleto")?.Value;
    }

}
