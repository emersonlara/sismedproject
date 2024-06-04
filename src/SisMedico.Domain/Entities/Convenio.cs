using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Convenio : EntityBase
{
    public string Nome { get; private set; }
    public Guid PacienteId { get; private set; }
    public DateTime Validade { get; private set; }
}
