using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Generico : EntityBase
{
    public Generico()
    {

    }

    public int Codigo { get; set; }
    public string Nome { get; set; }

}
