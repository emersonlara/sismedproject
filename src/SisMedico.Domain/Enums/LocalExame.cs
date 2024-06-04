using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum LocalExame
{
    [Description("Consultório")] Consultorio = 1,
    [Description("Internação")] Internacao,
    [Description("Externo")] Externo,
    [Description("Outro")] Outro
}
