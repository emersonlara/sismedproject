using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class PacienteTeste : EntityBase
{
    public string ipAddress { get; set; }
    public string status { get; set; }
    public int port { get; set; }
    public DateTime adate { get; set; }
    public string user { get; set; }
    public string package { get; set; }
    public Decimal balance { get; set; }

}
