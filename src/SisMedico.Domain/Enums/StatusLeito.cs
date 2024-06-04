using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum StatusLeito
{
    [Description("Em manutenção")] EmManutencao = 1,
    [Description("Ocupado")] Ocupado,
    [Description("Vago")] Vago,
    [Description("Desativado")] Desativado
}
