using SisMedico.Domain.Base;
using SisMedico.Domain.Enums;

namespace SisMedico.Domain.Entities;

public class Telefone : EntityBase
{
    public string? Numero { get; set; }
    public string? DDD { get; set; }
    public TipoTelefone TipoTelefone { get; set; }
}
