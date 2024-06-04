using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class StatusClinica : EntityBase
{
    public string Referencia { get; private set; }
    public int NumPacientesInternado { get; set; }
    public int NumLeitosTotal { get; set; }
    public int NumLeitosDisponivel { get; set; }
}
