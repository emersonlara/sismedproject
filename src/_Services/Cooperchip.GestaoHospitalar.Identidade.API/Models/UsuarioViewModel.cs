﻿using System.ComponentModel.DataAnnotations;

namespace Cooperchip.GestaoHospitalar.Identidade.API.Models;

public class UsuarioViewModel
{
    [Required(ErrorMessage = "O campo {0} é requerido.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é requerido.")]
    [StringLength(maximumLength: 100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "As senhas não conferem")]
    public string SenhaConfirmacao { get; set; }
}
public class UsuarioLogin
{
    [Required(ErrorMessage = "O campo {0} é requerido.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é requerido.")]
    [StringLength(maximumLength: 100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Senha { get; set; }
}

public class UsuarioRespostaLogin
{
    public string AccessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UsuarioToken UsuarioToken { get; set; }
}

public class UsuarioToken
{
    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<UsuarioClaim> Claims { get; set; }
}

public class UsuarioClaim
{
    public string Value { get; set; }
    public string Type { get; set; }
}
