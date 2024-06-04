using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum Sexo
{
    [Description("Feminino")] Feminino = 1,
    [Description("Masculino")] Masculio,
    [Description("Não Declarado")] NaoDeclarado,
    [Description("Outro")] Outro
}
