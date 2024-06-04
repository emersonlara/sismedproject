using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum TipoSaidaPaciente
{
    [Description("Recebeu Alta")] Alta = 1,
    [Description("Transferido")] Tranferencia,
    [Description("Saiu à Revelia")] ARevelia,
    [Description("Veio a Óbito")] Obito,
    [Description("Outros")] Outros
}