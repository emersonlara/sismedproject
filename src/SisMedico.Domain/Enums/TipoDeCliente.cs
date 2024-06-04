using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum TipoDeCliente
{
    [Description("Conveniado")]Conveniado = 1,
    [Description("Particular")]Particular,
    [Description("Outros")]Outros

}
