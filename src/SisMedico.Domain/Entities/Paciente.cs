using SisMedico.Domain.Base;
using SisMedico.Domain.Enums;
using SisMedico.Domain.Interfaces;

namespace SisMedico.Domain.Entities;

public class Paciente : EntityBase, IAggregateRoot
{
    public Paciente()
    { 
        Ativo = true;
    }

    public Guid EstadoPacienteId { get; set; }
    public EstadoPaciente EstadoPaciente { get; set; }

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataInternacao { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; private set; }
    public string Cpf { get; set; }
    public TipoDeCliente TipoDeCliente { get; set; }
    public Sexo Sexo { get; set; }
    public string Rg { get; set; }
    public string RgOrgao { get; set; }
    public DateTime RgDataEmissao { get; set; }

    public string Motivo { get; set; }

    // Todo: Ad Roc Setters - Paciente
    public void AtivarPaciente() => this.Ativo = true;
    public void DesativarPaciente() => this.Ativo = false;
    public void SetarClienteConveniado() => this.TipoDeCliente = TipoDeCliente.Conveniado;
    public void SetarClienteParticular() => this.TipoDeCliente = TipoDeCliente.Particular;
    public void SetarClienteOutros() => this.TipoDeCliente = TipoDeCliente.Outros;

    // Teria um método chamado: 
    //AcomodarPacienteAoLeito(this.Id, DateTime dataHora, Leito leito)
    // ou Acomodaria um Paciente através do Leito ?

    // -------------------------------------------------------------------------
    // AdicionarProntuario(Paciente paciente, DateTime dataHora);
    // ApontarDataDaAdmissao(DateTime dataAdmissao);
    // ApontarEstadoClinico(string estadoClinico);
    // ApontarTipoEntradaPaciente(int tipoEntradaPaciente);
    // ApontarTipoSaidaPaciente(int tipoSaidaPaciente);
    // SetarTipoCliente; OK!
    // Historico ???

}
