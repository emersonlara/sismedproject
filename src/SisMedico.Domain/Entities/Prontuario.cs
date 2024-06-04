using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Prontuario : EntityBase
{
    public Prontuario(){}

    public string CodigoAtendimento { get; private set; }
    public Guid PacienteId { get; private set; }
    public virtual Paciente Paciente { get; private set; }
    public string DiagnosticoInicial { get; private set; }
    public virtual ICollection<ProntuarioDiagnostico> ProntuarioDiagnosticos{ get; set; }

}


public class ProntuarioDiagnostico : EntityBase
{
    public ProntuarioDiagnostico() { }

    public Guid ProntuarioId { get; private set; }
    public Guid MedicoId { get; private set; }
    public DateTime DataHora { get; private set; }
    public string Diagnostico { get; private set; }
    public Prontuario Prontuario { get; private set; }
}

public class Prescricao : EntityBase
{
    public Prescricao(){}
}

public class Evolucao : EntityBase
{
    public Evolucao(){}
}

public class HistoricoPaciente : EntityBase
{
    public HistoricoPaciente(){}
}
