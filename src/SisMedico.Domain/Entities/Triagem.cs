using System.ComponentModel.DataAnnotations;
using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Triagem : EntityBase
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Id")]
    public Guid CodigoPaciente { get; private set; }

    [StringLength(90, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Nome")]
    public string NomePaciente { get; private set; }

    [DataType(DataType.DateTime, ErrorMessage = "Data Inválida.")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Data")]
    public DateTime DataNotificacao { get; private set; }

    [StringLength(90, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; private set; }

    // to EF
    public Triagem() { }
    public Triagem(Guid codigoPaciente, 
                                        string nomePaciente, 
                                        DateTime dataNotificacao, 
                                        string mensagem)
    {
        CodigoPaciente = codigoPaciente;
        NomePaciente = nomePaciente;
        DataNotificacao = dataNotificacao;
        Mensagem = mensagem;
    }
}
