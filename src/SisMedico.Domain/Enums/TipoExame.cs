using System.ComponentModel;

namespace SisMedico.Domain.Enums;

public enum TipoExame
{
    [Description("Consulta")] Consulta = 1,
    [Description("Hemograma Completo")] HemogramaCompleto,
    [Description("Colonoscopia")] Colonoscopia
}
